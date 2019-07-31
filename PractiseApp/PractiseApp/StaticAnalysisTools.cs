// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace PractiseApp
{


    class StaticAnalysisTools
    {

        private static void MergeAllReports()
        {
            string[] files = new string[] { @"C:\Users\320053936\Desktop\Reports\PVSReport.txt", @"C:\Users\320053936\Desktop\Reports\ReSharper.txt", @"C:\Users\320053936\Desktop\Reports\Ndepend.txt" };

            string fileContent = string.Empty;
            foreach (var fileName in files)
            {
                using (System.IO.StreamReader Reader = new System.IO.StreamReader(fileName))
                {
                    fileContent += Reader.ReadToEnd();
                }
            }
            fileContent = fileContent.Replace(',', '.');

            System.IO.File.WriteAllText(@"C:\Users\320053936\Desktop\Reports\FinalMergedReport.txt", fileContent);
            Console.WriteLine("\n\n");
            Console.WriteLine("Successfully merged all reports");

        }
        static void Main(string[] args)
        {
            StaticAnalysisToolNDepend.RunNDependTool();
            StaticAnalysisToolPVS.RunPVSTool();
            StaticAnalysisToolPVS.ParsePVSReport();
            StaticAnalysisToolReSharper.RunReSharperTool();
            StaticAnalysisToolReSharper.ParseReSharperReport();
            StaticAnalysisToolNDepend.ParseNDependReport();
            MergeAllReports();



        }
    }
}



