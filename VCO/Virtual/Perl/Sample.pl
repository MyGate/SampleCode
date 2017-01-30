#!/usr/bin/perl -w

use strict;
use warnings;

use CGI;
*CGI::br = sub { '<br />' };

my $q = CGI->new();

# Setting variables that get sent to MyGate
my $URL  = "https://virtual.mygateglobal.com/PaymentPage.cfm";
my $Mode = "0";     # 0 = Test Mode. 1 = Live Mode

my $MerchantID    = "F5785ECF-1EAE-40A0-9D37-93E2E8A4BAB3";
my $ApplicationID = "A7342EAB-B55B-4626-B3D5-9A48FEC1E5A5";

# Currency and price of transaction
my $Price   = "0.01";
my $Currency = "ZAR";

# Redirect Details
my $RedirectSuccess = "http://localhost:8888/cgi-bin/Virtual/processResults.pl";
my $RedirectFailed  = "http://localhost:8888/cgi-bin/Virtual/processResults.pl";

my $MerchantReference  = "";

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
  $q->hidden( -name => 'MerchantID',    -value => $MerchantID ),    $q->br(),
  $q->hidden( -name => 'ApplicationID', -value => $ApplicationID ), $q->br(),
  $q->hidden( -name => 'MerchantReference', -value => $MerchantReference ), $q->br(),
  $q->hidden( -name => 'RedirectSuccessfulURL', -value => $RedirectSuccess ), $q->br(),
  $q->hidden( -name => 'RedirectFailedURL',     -value => $RedirectFailed ),  $q->br(),
  'Amount: R', $q->textfield( -name => 'Price', -value => $Price ), $q->br(),
  $q->hidden( -name => 'CurrencyCode', -value => $Currency ), $q->br(),
  $q->hidden( -name => 'DisplayPrice', -value => $Price ), $q->br(),
  $q->hidden( -name => 'DisplayCurrencyCode', -value => $Currency ), $q->br(),
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

