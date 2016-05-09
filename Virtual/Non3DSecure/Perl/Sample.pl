#!c:/Perl64/bin/perl   

use strict;
use warnings;

use CGI;
*CGI::br = sub { '<br />' };

my $q = CGI->new();

# Setting variables that get sent to MyGate
my $URL  = "https://virtual.mygateglobal.com/PaymentPage.cfm";
my $Mode = "0";     # 0 = Test Mode. 1 = Live Mode

# Be sure to populate these variables with the ones
# you generated in the MyGate Developer Center.
# Go there now by going to http://developer.mygateglobal.com
my $MerchantID    = "F5785ECF-1EAE-40A0-9D37-93E2E8A4BAB3";
my $ApplicationID = "1DBBBAAE-958E-4346-A27A-6BB5171CEEDC";

# Currency and price of transaction
my $Price   = "10.00";
my $Currency = "USD";

# Redirect Details
my $RedirectSuccess = "http://localhost:81/QA/PerlSampleCode/processResults.pl";
my $RedirectFailed  = "http://localhost:81/QA/PerlSampleCode/processResults.pl";

my $MerchantReference  = "MyMerchantRef1";

print $q->header(
    -type    => 'text/html',
    -charset => 'UTF-8',
  ),
  $q->start_html(
    -dtd   => [ '-//W3C//DTD XHTML 1.0 Transitional//EN', 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd' ],
    -title => 'Perl MyVirtual Example',
    -meta => { 'Copyright' => 'MyGate Communications (Pty) Ltd 2007', },
  ),
  $q->h1('My Virtual Example'),    # perltidy hack
  $q->start_form(
    -name    => 'Virtual Post',
    -enctype => 'multipart/form-data',    # or 'application/x-www-form-urlencoded',
    -method  => 'POST',
    -action  => $URL,
  ),
  $q->hidden( -name => 'Mode',          -value => $Mode ),          $q->br(),
  $q->hidden( -name => 'txtMerchantID',    -value => $MerchantID ),    $q->br(),
  $q->hidden( -name => 'txtApplicationID', -value => $ApplicationID ), $q->br(),
  $q->hidden( -name => 'txtMerchantReference', -value => $MerchantReference ), $q->br(),
  $q->hidden( -name => 'txtRedirectSuccessfulURL', -value => $RedirectSuccess ), $q->br(),
  $q->hidden( -name => 'txtRedirectFailedURL',     -value => $RedirectFailed ),  $q->br(),
  'Amount: R', $q->textfield( -name => 'txtPrice', -value => $Price ), $q->br(),
  $q->hidden( -name => 'txtCurrencyCode', -value => $Currency ), $q->br(),
  $q->hidden( -name => 'txtDisplayPrice', -value => $Price ), $q->br(),
  $q->hidden( -name => 'txtDisplayCurrencyCode', -value => $Currency ), $q->br(),
  $q->submit( -name => 'submit', -value => 'Process Transaction' ), $q->br(),
  $q->end_form(),
  $q->end_html();

=head1 NAME

sample.pl - MyGate Communications example
 
 =head1 LICENCE
 
 +---------------------------------------------------------------------------+
 | MyGate Communications - Perl Enterprise Auth and Settle Sample            |
 | Copyright (c) 2007 MyGate Communications (Pty) Ltd                  		 |
 | All rights reserved.                                                      |
 +---------------------------------------------------------------------------+
 | The initial developer of the original code is MyGate Global		         |
 +---------------------------------------------------------------------------+
 
 * "Perl MyVirtual Sample" payment page
 *
 * @category   Code Sample
 * @package    MyGate Communications (Pty) Ltd
 * @subpackage Virtual Transaction (Please contact MyGate to enable immediate settlement if your account requires it)
 * @author     MyGate Global
 * @copyright  Copyright (c) 2007 MyGate Communications (Pty) Ltd
 * @link       http://www.mygateglobal.com/
 * 
 * @Note	   This code serves as an example only. It is not recommended that you use this code for production purposes.


=cut

