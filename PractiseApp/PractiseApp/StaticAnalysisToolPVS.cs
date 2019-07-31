using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PractiseApp
{
    class StaticAnalysisToolPVS
    {
        public static void RunPVSTool()
        {
            string stringCommandText1, stringCommandText2, stringCommandText3, stringCommandText4, stringCommandText;
            System.Environment.CurrentDirectory = System.Configuration.ConfigurationManager.AppSettings["PVSStudioAddress"];
            try
            {
                stringCommandText1 = System.Configuration.ConfigurationManager.AppSettings["ExecutionPVSStudio1"];
                stringCommandText2 = System.Configuration.ConfigurationManager.AppSettings["ExecutionPVSStudio2"];
                stringCommandText3 = System.Configuration.ConfigurationManager.AppSettings["ExecutionPVSStudio3"];
                stringCommandText4 = System.Configuration.ConfigurationManager.AppSettings["ExecutionPVSStudio4"];

                stringCommandText = stringCommandText1 + stringCommandText2 + stringCommandText3 + stringCommandText4;
                Console.WriteLine(stringCommandText);

                System.Diagnostics.Process processToRunCommandPrompt = System.Diagnostics.Process.Start("CMD.exe", stringCommandText);

                processToRunCommandPrompt.WaitForExit();
                processToRunCommandPrompt.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public static void ParsePVSReport()
        {
            FileStream fileStream;
            StreamWriter streamWriter;
            TextWriter textWriter = Console.Out;
            try
            {
                fileStream = new FileStream(@"C:\Users\320053936\Desktop\Reports\PVSReport.txt", FileMode.OpenOrCreate, FileAccess.Write);
                streamWriter = new StreamWriter(fileStream);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open PVSReport.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }
            Console.SetOut(streamWriter);

            //////
            PVSParsing();
            ///////
            Console.SetOut(textWriter);
            streamWriter.Close();
            fileStream.Close();
            Console.WriteLine("PVSStudio Output printed to text file successfully");
        }

        public static void PVSParsing()
        {
            XDocument ReportToolsVersion = XDocument.Load(@"C:\Users\320053936\source\repos\PractiseApp.plog");


            Console.WriteLine("************************PVS Studio Report*********************************");

            foreach (XElement childNode in ReportToolsVersion.Descendants("NewDataSet"))
            {
                foreach (XElement targetNode in childNode.Descendants("PVS-Studio_Analysis_Log"))
                {

                    foreach (XElement usedNode in targetNode.Descendants("Project"))
                    {
                        Console.WriteLine("Project:   " + usedNode.Value);
                    }
                    foreach (XElement usedNode in targetNode.Descendants("ShortFile"))
                    {
                        Console.WriteLine("FileName:   " + usedNode.Value);
                    }
                    foreach (XElement usedNode in targetNode.Descendants("Line"))
                    {

                        Console.WriteLine("LineNumber:   " + usedNode.Value);
                    }
                    foreach (XElement usedNode in targetNode.Descendants("Message"))
                    {
                        Console.WriteLine("Message:   " + usedNode.Value);
                    }

                    Console.WriteLine("\n\n\n");

                }

            }

        }
    }
}
