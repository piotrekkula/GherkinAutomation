using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebTestAutomation.Steps.Helper
{
    class Reporting
    {
        public static String preamble = @"
        <!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Strict//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd'>
        <html xmlns='http://www.w3.org/1999/xhtml' xml:lang='en' lang='en'>
        <head>
	        <meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />
	        <title>Source code</title>
	        <script type='text/javascript' src='scripts/shCore.js'></script>
	        <script type='text/javascript' src='scripts/shBrushXml.js'></script>
            <script type='text/javascript' src='scripts/shBrushJScript.js'></script>
	        <link type='text/css' rel='stylesheet' href='styles/shThemeMidnight.css'/>
	        <script type='text/javascript'>
		        SyntaxHighlighter.all();
	        </script>
            <style>
                .syntaxhighlighter {
                width: 100% !important;
                margin: 1em 0 1em 0 !important;
                position: relative !important;
                overflow: auto !important;
                font-size: 8pt !important; 
                }
            </style>
        </head>
        <body style='background-color: #0F192A'>
        <pre class='brush: js, html-script: true, toolbar: false, gutter: false'>";

        public static String postamble = @"</pre>
        </body>
        </html>";
    }
}
