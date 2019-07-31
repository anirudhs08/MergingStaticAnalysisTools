using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PractiseApp
{
    class StaticAnalysisToolNDepend
    {
        public static void RunNDependTool()
        {
            string stringCommandText;
            System.Environment.CurrentDirectory = System.Configuration.ConfigurationManager.AppSettings["NDependAddress"];
            try
            {
                stringCommandText = System.Configuration.ConfigurationManager.AppSettings["ExecutionNDepend"];
                System.Diagnostics.Process processToRunCommandPrompt = System.Diagnostics.Process.Start("CMD.exe", stringCommandText);
                processToRunCommandPrompt.WaitForExit();
                processToRunCommandPrompt.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public static void ParseNDependReport()
        {
            FileStream fileStream;
            StreamWriter streamWriter;
            TextWriter textWriter = Console.Out;
            try
            {
                fileStream = new FileStream(@"C:\Users\320053936\Desktop\Reports\Ndepend.txt", FileMode.OpenOrCreate, FileAccess.Write);
                streamWriter = new StreamWriter(fileStream);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open Ndepend.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }
            Console.SetOut(streamWriter);
            ////////

            NdependParsing();

            ////////
            Console.SetOut(textWriter);
            streamWriter.Close();
            fileStream.Close();
            Console.WriteLine("NDepend Output printed to text file successfully\n");

        }

        public static void NdependParsing()
        {
            string html;

            using (var client = new WebClient())
            {

                html = new WebClient().DownloadString(@"C:\Users\320053936\source\repos\PractiseApp\NDependOut\NDependReport.html");
            }

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            StringBuilder sb = new StringBuilder();
            foreach (HtmlTextNode node in doc.DocumentNode.SelectNodes("//text()"))
            {
                sb.AppendLine(node.Text);
            }
            string final = sb.ToString();

            int start, end, start1, end1;

            System.IO.File.WriteAllText(@"C:\Users\320053936\source\repos\CaseStudy1\NDependOut\NDependText.txt", final);

            Console.WriteLine("************************NDepend Report*********************************");


            int indexOfComment = final.IndexOf("Comment");
            Console.WriteLine("Percentage of commented out codes" + final.Substring(indexOfComment + 7, 10));

            Console.WriteLine("RULES VIOLATED SUMMARY");

            string strStart = " Number of Rules violated:";
            string strEnd = "Rules can be checked live at";
            start = final.IndexOf(strStart, 0) + strStart.Length;
            end = final.IndexOf(strEnd, start);
            Console.WriteLine("Number of rules violated" + final.Substring(start, end - start));

            string issuesMatched = "issues matched";
            int indexIssues = final.IndexOf(issuesMatched);
            int numberOfIssues = Int32.Parse(final.Substring(indexIssues - 3, 2));
            Console.WriteLine("Number of issues due to the rules violated\t" + "\n" + numberOfIssues);


            int rulesIterated = 0;
            int indexOfRule;
            int firstNewLine;
            int secondNewLine;
            while (rulesIterated < numberOfIssues)
            {
                indexOfRule = final.IndexOf("Rule violated:", indexIssues);
                firstNewLine = final.IndexOf("\n", indexOfRule);
                secondNewLine = final.IndexOf("\n", firstNewLine + 1);
                Console.WriteLine(rulesIterated + 1 + ".Violation");
                Console.WriteLine(final.Substring(indexOfRule, secondNewLine - indexOfRule));
                Console.WriteLine("\n\n");
                indexIssues = indexOfRule + 1;
                rulesIterated = rulesIterated + 1;
            }


            Console.WriteLine("QUALITY GATES SUMMARY\n");
            Console.WriteLine("Quality Gates Passed\n");
            string value = "Quality Gate Pass";
            int counter = 1;
            for (int index = 0; ; index += value.Length)
            {

                index = final.IndexOf(value, index);
                if (index == -1)
                    break;
                int newLineIndex = final.IndexOf("Quality Gate Description", index);
                Console.WriteLine("QualityGateRule" + counter);
                Console.WriteLine(final.Substring(index, newLineIndex - 3 - index) + "\n");
                counter = counter + 1;


            }

            Console.WriteLine("Quality Gates Failed\n");
            string failCheck = "Quality Gate Fail";
            int counterFailCheck = 1;
            for (int index = 0; ; index += failCheck.Length)
            {

                index = final.IndexOf(failCheck, index);
                if (index == -1)
                    break;
                int newLineIndex = final.IndexOf("Quality Gate Description", index);
                Console.WriteLine("QualityGateRule" + counterFailCheck);
                Console.WriteLine(final.Substring(index, newLineIndex - 3 - index) + "\n");
                counterFailCheck = counterFailCheck + 1;

            }
        }

    }
}
