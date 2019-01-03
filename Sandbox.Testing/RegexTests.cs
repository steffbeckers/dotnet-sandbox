using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sandbox.Testing
{
    [TestClass]
    public class RegexTests
    {
        [TestMethod]
        public void HTMLTag()
        {
            string pattern = @"<tr>(?:.*?\r?\n?)*<\/tr>";
            string input = @"<table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0
                             style='margin-left:35.05pt;border-collapse:collapse'>
                             <tr>
                              <td width=170 valign=top style='width:127.7pt;border:solid white 1.0pt;
                              background:#2E74B5;padding:0cm 5.4pt 0cm 5.4pt'>
                              <p class=MsoNormal><i><span style='font-size:10.0pt;font-family:""Hind Regular"";
                              color:white'>aariXa Reference</span></i></p>
                              </td>
                              <td width=529 valign=top style='width:396.8pt;border:solid #767171 1.0pt;
                              border-left:none;padding:0cm 5.4pt 0cm 5.4pt'>
                              <p class=MsoNormal><span style='font-size:10.0pt;font-family:""Hind Regular""'>$requestforresource_template_mycompany_reference</span></p>
                              </td>
                             </tr>
                             <tr>
                              <td width=170 valign=top style='width:127.7pt;border:solid white 1.0pt;
                              border-top:none;background:#2E74B5;padding:0cm 5.4pt 0cm 5.4pt'>
                              <p class=MsoNormal><i><span style='font-size:10.0pt;font-family:""Hind Regular"";
                              color:white'>Customer</span></i></p>
                              </td>
                              <td width=529 valign=top style='width:396.8pt;border-top:none;border-left:
                              none;border-bottom:solid #767171 1.0pt;border-right:solid #767171 1.0pt;
                              padding:0cm 5.4pt 0cm 5.4pt'>
                              <p class=MsoNormal><span style='font-size:10.0pt;font-family:""Hind Regular""'>$requestforresource_template_customer</span></p>
                              </td>
                             </tr>
                            </table>
                            ";
            RegexOptions options = RegexOptions.Multiline | RegexOptions.IgnoreCase;

            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
}
