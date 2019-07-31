// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using HtmlAgilityPack;
using NDepend;
using NDepend.Path;
using NDepend.Project;

using System.Threading.Tasks;

using System.Xml.Linq;
namespace NdependProj
{
    class SampleCodeForToolTesting2
    {
        static void Main(string[] args)
        {

            


            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;
            try
            {
                ostrm = new FileStream("./ReSharper.txt", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open Redirect.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }
            Console.SetOut(writer);
            





            XDocument ReportToolsVersion = XDocument.Load(@"C:\Users\320053936\Downloads\ReSharper\reportNew.xml");
            
            
            Console.WriteLine("Types of issues");
            
            foreach (XElement childNode in ReportToolsVersion.Descendants("Report"))
            {
                foreach (XElement categoryNode in childNode.Descendants("IssueTypes"))
                {
                    int counter = 1;
                    foreach (XElement issueType in categoryNode.Descendants("IssueType"))
                    {
                        
                        Console.Write(counter + "    " + issueType.Attribute("Severity").Value + ":");
                        Console.WriteLine(issueType.Attribute("Category").Value);
                        Console.WriteLine(issueType.Attribute("Description").Value);
                        counter = counter + 1;
                        Console.WriteLine("\n\n");

                        
                        
                    }
                }
                foreach (XElement categoryNode in childNode.Descendants("Issues"))
                {
                    foreach (XElement project in childNode.Descendants("Project"))
                    {
                        int counter = 1;
                        foreach (XElement issue in childNode.Descendants("Issue"))
                        {
                            

                            Console.WriteLine(counter + "  " +  issue.Attribute("File"));
                            Console.WriteLine(issue.Attribute("Line"));
                            Console.WriteLine(issue.Attribute("Message"));
                            counter = counter + 1;
                            Console.WriteLine("\n\n");

                        }
                    }
                }
            }
            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();
            Console.WriteLine("ReSharper Output printed to text file successfully");
        }

    }
}