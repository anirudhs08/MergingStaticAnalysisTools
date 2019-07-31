using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PractiseApp
{
    class StaticAnalysisToolReSharper
    {
        public static void RunReSharperTool()
        {
            string stringCommandText;
            System.Environment.CurrentDirectory = System.Configuration.ConfigurationManager.AppSettings["ReSharperAddress"];
            try
            {
                stringCommandText = System.Configuration.ConfigurationManager.AppSettings["ExecutionReSharper"];
                System.Diagnostics.Process processToRunCommandPrompt = System.Diagnostics.Process.Start("CMD.exe", stringCommandText);
                processToRunCommandPrompt.WaitForExit();

                processToRunCommandPrompt.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public static void ParseReSharperReport()
        {
            FileStream fileStream;
            StreamWriter streamWriter;
            TextWriter textWriter = Console.Out;
            try
            {
                fileStream = new FileStream(@"C:\Users\320053936\Desktop\Reports\ReSharper.txt", FileMode.OpenOrCreate, FileAccess.Write);
                streamWriter = new StreamWriter(fileStream);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open ReSharper.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }
            Console.SetOut(streamWriter);

            // parsing code written in the following function.....
            ReSharperParser();




            Console.SetOut(textWriter);
            streamWriter.Close();
            fileStream.Close();
            Console.WriteLine("ReSharper Output printed to text file successfully");


        }

        public static void ReSharperParser()
        {
            XDocument Root = XDocument.Load(@"C:\Users\320053936\Downloads\ReSharper\reportNew.xml");


            Console.WriteLine("************************ReSharper Report*********************************");

            foreach (XElement childNode in Root.Descendants("Report"))
            {
                foreach (XElement categoryNode in childNode.Descendants("IssueTypes"))
                {
                    int counter2 = 1;
                    foreach (XElement issueType in categoryNode.Descendants("IssueType"))
                    {

                        Console.Write(counter2 + ".    " + issueType.Attribute("Severity").Value + ":");
                        Console.WriteLine(issueType.Attribute("Category").Value);
                        Console.WriteLine(issueType.Attribute("Description").Value);
                        counter2 = counter2 + 1;
                        Console.WriteLine("\n\n");



                    }
                }
                foreach (XElement categoryNode in childNode.Descendants("Issues"))
                {
                    foreach (XElement project in childNode.Descendants("Project"))
                    {
                        int counter2 = 1;
                        foreach (XElement issue in childNode.Descendants("Issue"))
                        {


                            Console.WriteLine(counter2 + ".  " + issue.Attribute("File"));
                            Console.WriteLine(issue.Attribute("Line"));
                            Console.WriteLine(issue.Attribute("Message"));
                            counter2 = counter2 + 1;
                            Console.WriteLine("\n\n");

                        }
                    }
                }
            }

        }

    }
}
