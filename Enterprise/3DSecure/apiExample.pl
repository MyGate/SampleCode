use strict;
use LWP::Simple;
use CGI qw(:standard);
use Data::Dump qw(dump);
use POSIX qw(strftime);
use HTML::Entities;
use SOAP::Lite;
use warnings FATAL => 'all';

my $merchantUID = 'F5785ECF-1EAE-40A0-9D37-93E2E8A4BAB3';
my $merchantToken = 'F5785ECF-1EAE-40A0-9D37-93E2E8A4BAB3';
my $applicationUID = "5A02E47D-7E2E-452B-A940-E3E946265037";	# 3D Secure

my $actionResponse = '';
my $now_string = strftime "%Y%m%d_%H%M%S", localtime;

#		Action	Action Name
#		1		Authorise
#		2		Authorise - Reversal
#		3		Capture
#		4		Credits (Follow-On)
#		5		Sale
#		12		Credits - Sale
#		14		ThreeD Secure - Lookup
#		15		ThreeD Secure - Authenticate
#		19		Reports

my $actionTypeID = '1';

my %replace = (
    '{mode}'              => '0',
    '{applicationUID}'    => $applicationUID,
    '{transactionIndex}'  => '00000000-0000-0000-0000-000000000000',
    '{merchantReference}' => 'merchantReference_'.$now_string,
    '{cardHolder}'        => 'Test Card',
    '{cardNumber}'        => '4000000000000002',
    '{expiryMonth}'       => '02',
    '{expiryYear}'        => '2020',
    '{cvvNumber}'         => '123',
    '{amount}'            => '10.36',
    '{verbalAuthCode}'    => '123456',
    '{paresPayload}'      => '' );

if ($actionTypeID == 1 || $actionTypeID == 5)
{

    my $tdsAuthenticate = param( "tdsAuthenticate" );
    my $md = param( "MD" );
    my $PaRes = param( "PaRes" );

    if (defined ( $tdsAuthenticate ) && defined( $md ) > 0 && defined( $PaRes ) > 0)
    {
        $replace{'{transactionIndex}'} = $md;
        $replace{'{paresPayload}'} = $PaRes;

        my $authResponse = processRequest( $merchantUID, $merchantToken, 15, %replace );

        print '<br><b>=================================================</b><br>';
        print '<b>ThreeDSecure Auth Response</b>';
        print '<br><b>=================================================</b><br>';
        print '<pre>'.encode_entities( dump( $authResponse ) ).'</pre>';
        print '<br><b>=================================================</b><br>';

        $replace{'{transactionIndex}'} = $authResponse->uidTransactionIndex;
        $actionResponse = processRequest( $merchantUID, $merchantToken, $actionTypeID, %replace );
    }
    else
    {
        my $lookupResponse = processRequest( $merchantUID, $merchantToken, 14, %replace );

        print '<br><b>=================================================</b><br>';
        print '<b>ThreeDSecure Lookup Response</b>';
        print '<br><b>=================================================</b><br>';
        print '<pre>'.encode_entities( dump( $lookupResponse ) ).'</pre>';
        print '<br><b>=================================================</b><br>';

        if ( $lookupResponse->valueof('//tdsLookup/authRequired') eq "Y") {

            acsPage( $lookupResponse->valueof('//tdsLookup/acsUrl'),
                'https://'.$ENV{SERVER_NAME}.":".$ENV{SERVER_PORT}.'/'.$ENV{'_'}.'?tdsAuthenticate=true',
                $lookupResponse->valueof('//tdsLookup/payload'), $lookupResponse->valueof('//uidTransactionIndex') );
        } else {

            $replace{'{transactionIndex}'} = $lookupResponse->valueof('//uidTransactionIndex');
            $actionResponse = processRequest( $merchantUID, $merchantToken, $actionTypeID, %replace );
        }
    }
}
else {
    $actionResponse = processRequest( $merchantUID, $merchantToken, $actionTypeID, %replace );
}

print '<br><b>=================================================</b><br>';
print '<b>Action '.$actionTypeID.' Response</b>';
print '<br><b>=================================================</b><br>';
print '<pre>'.encode_entities( dump( $actionResponse ) ).'</pre>';
print '<br><b>=================================================</b><br>';


sub processRequest
{

    ($merchantUID, $merchantToken, $actionTypeID, my %replace_local) = @_;

    my $ns = "https://api.mygateglobal.com/";

    #/*
    #	 * The xml files here are only used as an example. It should be changed to the requirements of the customer.
    #	 * The sample xml can be downloaded from https:/ / github.com / MyGateGlobal / SampleCode / tree / master / XML%20Actions
    #	 * or generated according to specifications on https://developers.mygateglobal.com
    #*/

    my $fileUrl = $ns.'api/xmlactions/action_'.$actionTypeID.'.xml';
    my $file = get $fileUrl;
    my @search = ( '{mode}', '{applicationUID}', '{transactionIndex}', '{merchantReference}', '{cardHolder}',
        '{cardNumber}', '{expiryMonth}', '{expiryYear}', '{cvvNumber}', '{amount}', '{verbalAuthCode}',
        '{paresPayload}' );

    my $xmlRequest = $file;
    foreach my $item (@search)
    {
        $xmlRequest = str_replace( $item, $replace_local{$item}, $xmlRequest );
    }

    print '<b>Submission Data for action :'.$actionTypeID.'</b>';
    print '<br><b>=================================================</b><br>';
    print '<pre>'.encode_entities( dump( $xmlRequest ) ).'</pre>';
    print '<br><b>=================================================</b><br>';

    my $service = SOAP::Lite
        ->proxy( "https://api.mygateglobal.com/api/" )
        ->uri( $ns )
        ->ns( $ns )
        ->on_fault( \&soapError )
        ->readable( 1 );

    my $authHeader = SOAP::Header->name( "authenticate" =>
        \SOAP::Header->value(
            SOAP::Header->name( 'merchantUID' )->value( $merchantUID )->type( 'xsd:string' ),
            SOAP::Header->name( 'merchantToken' )->value( $merchantToken )->type( 'xsd:string' ),
            SOAP::Header->name( 'actionTypeID' )->value( $actionTypeID )->type( 'xsd:string' ),
        ) );

    my $xmldata = SOAP::Data->type( 'xml' => encode_entities( $xmlRequest ) );
    my $result = $service->requestMessage( $xmldata, $authHeader );

    return $result;
}

sub acsPage
{
    my $ascUrl = shift;
    my $returnUrl = shift;
    my $payload = shift;
    my $transactionIndex = shift;

    print '	<script type="text/javascript">
				if (window.parent.document.getElementById("divProcessingImage"))
					window.parent.fadeProcessingImage();

				setTimeout( function(){ window.parent.fadeProcessingImage() },90000 );
			</script>

			<form id="frmLaunchACS" name="frmLaunchACS" method="POST" action="'.$ascUrl.'">
				<!--<noscript>-->
				<table align="center"  width="50%">
					<tr>
						<td>
							<h1>3D Secure</h1>
							<div>
								<p>3D Secure is led by the credit card schemes and is designed to make online shopping transactions safer by authenticating a cardholder&rsquo;s identity at the time of purchase, through the likes of Verified by Visa and MasterCard SecureCode.</p>
								<p>A transaction using Verified by Visa or SecureCode will redirect cardholders to the website of their card-issuing bank. The cardholder may then be requested by their bank to enter a password to be authenticated. If a customer is not registered with 3D Secure they are still able to make a purchase from your website.</p>
								<p>3D Secure is one method for online merchants to combat fraud.</p>
							</div>
							<h3>Benefits</h3>
							<div>
								<ul>
									<li>Creates a level of consumer trust and confidence in online shopping.</li>
									<li>Reduces disputes and fraudulent activity.</li>
								</ul>
							</div>

						</td>
					</tr>

					<tr>
						<td colspan="2">
							<div align="center">
								<input type="submit" value="Authenticate" style="width:250" >
							</div>
						</td>
					</tr>
				</table>
				<!--</noscript>-->
				<input type="hidden" style="width:400" id="PaReq" name="PaReq" value="'.$payload.'"/>
				<input type="hidden" style="width:400" id="TermUrl" name="TermUrl" value="'.$returnUrl.'"/>
				<input type="hidden" style="width:400" id="MD" name="MD" value="'.$transactionIndex.'"/>
			</form>
			<script type="text/javascript">
				//window.name = "#MAIN_BROWSER_WINDOW_NAME#";
				//document.getElementById("frmLaunchACS").submit();
			</script>';

}

sub str_replace {
    my $replace_this = shift;
    my $with_this = shift;
    my $string = shift;

    my $length = length( $string );
    my $target = length( $replace_this );

    for (my $i = 0; $i < $length - $target + 1; $i++) {
        if (substr( $string, $i, $target ) eq $replace_this) {
            $string = substr( $string, 0, $i ).$with_this.substr( $string, $i + $target );
            return $string;
        }
    }
    return $string;
}

sub soapError {

    my $soap = shift;
    my $res = shift;

    print '<br>=================================================<br>';
    print '<br>            S O A P  -  E R R O R<br>';
    print '<br>!=================================================!<br>';
    dump ( encode_entities ( $soap ) );
    print '<br>=================================================<br>';
    dump ( encode_entities ( $res ) );
    print '<br>=================================================<br>';

    return 1;
}
