// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.IO;
using System.Configuration;

namespace PractiseApp
{
    class SampleCodeForToolTesting1
    {
        static void Main(string[] args)
        {

            string strCmdText1;
            System.Environment.CurrentDirectory = System.Configuration.ConfigurationManager.AppSettings["NDependAddress"];
            try
            {
                strCmdText1 = System.Configuration.ConfigurationManager.AppSettings["ExecutionNDepend"];
                System.Diagnostics.Process p = System.Diagnostics.Process.Start("CMD.exe", strCmdText1);
                p.WaitForExit();
                p.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;
            try
            {
                ostrm = new FileStream("./Ndepend.txt", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open Redirect.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }
            Console.SetOut(writer);
            
            



            string html;
            // obtain some arbitrary html....
            using (var client = new WebClient())
            {
                //html = client.DownloadString("http://stackoverflow.com/questions/2038104");
                html = new WebClient().DownloadString(@"C:\Users\320053936\source\repos\CaseStudy1\NDependOut\NDependReport.html");
            }
            // use the html agility pack: http://www.codeplex.com/htmlagilitypack
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            StringBuilder sb = new StringBuilder();
            foreach (HtmlTextNode node in doc.DocumentNode.SelectNodes("//text()"))
            {
                sb.AppendLine(node.Text);
            }
            string final = sb.ToString();
            //Console.WriteLine(final);
            int start, end, start1, end1;

            System.IO.File.WriteAllText(@"C:\Users\320053936\source\repos\CaseStudy1\NDependOut\NDependText.txt", final);

            int indexOfComment = final.IndexOf("Comment");
            Console.WriteLine("% of commented out codes" + final.Substring(indexOfComment + 7, 10));

            Console.WriteLine("********RULES VIOLATED SUMMARY********");

            string strStart = " Number of Rules violated:";
            string strEnd = "Rules can be checked live at";
            start = final.IndexOf(strStart, 0) + strStart.Length;
            end = final.IndexOf(strEnd, start);
            Console.WriteLine("Number of rules violated" + final.Substring(start, end - start));

            string issuesMatched = "issues matched";
            int indexIssues = final.IndexOf(issuesMatched);
            int numberOfIssues = Int32.Parse(final.Substring(indexIssues - 3, 2));
            Console.WriteLine("Number of issues due to the rules violated\t" + "\n" + numberOfIssues);

            /*Iterate through all the rule violations*/
            int rulesIterated = 0;
            int indexOfRule;
            int firstNewLine;
            int secondNewLine;
            while (rulesIterated < numberOfIssues)
            {
                indexOfRule = final.IndexOf("Rule violated:", indexIssues);
                firstNewLine = final.IndexOf("\n", indexOfRule);
                secondNewLine = final.IndexOf("\n", firstNewLine + 1);
                Console.WriteLine(rulesIterated + 1+".Violation");
                Console.WriteLine(final.Substring(indexOfRule, secondNewLine - indexOfRule));
                Console.WriteLine("\n\n");
                indexIssues = indexOfRule + 1;
                rulesIterated = rulesIterated + 1;
            }


            Console.WriteLine("********QUALITY GATES SUMMARY********\n");
            Console.WriteLine("Quality Gates Passed\n");
            string value = "Quality Gate Pass";
            int counter = 1;
            for (int index = 0; ; index += value.Length)
            {
                
                index = final.IndexOf(value, index);
                if (index == -1)
                    break;
                int newLineIndex = final.IndexOf("Quality Gate Description",index);
                Console.WriteLine("QualityGateRule" + counter + "\n" + final.Substring(index,newLineIndex-index) +"\n");
                counter = counter + 1;
                

            }
            /*To find all the rules violated*/

            Console.WriteLine("Quality Gates Failed\n");
            string failCheck = "Quality Gate Fail";
            int counterFailCheck = 1;
            for (int index = 0; ; index += failCheck.Length)
            {

                index = final.IndexOf(failCheck, index);
                if (index == -1)
                    break;
                int newLineIndex = final.IndexOf("Quality Gate Description", index);
                Console.WriteLine("QualityGateRule" + counterFailCheck + "\n" + final.Substring(index, newLineIndex - index) + "\n");
                counterFailCheck = counterFailCheck + 1;


            }


            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();
            Console.WriteLine("Output printed to text file successfully");



            /*
            string strStart1 = "Application Statistics are available.";
            string strEnd1 = "&nbsp;&nbsp;&nbsp;";
            start1 = final.IndexOf(strStart1, 0) + strStart1.Length;
            end1 = final.IndexOf(strEnd1, start1);
            Console.WriteLine("Number of lines of code" + final.Substring(start1 + 10));
            */




        }
    }
}
