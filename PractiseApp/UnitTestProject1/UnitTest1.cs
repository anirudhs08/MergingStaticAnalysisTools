using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Configuration;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

     
        [TestMethod]
        public void ReportExistancePVSstudio()
        {
           
            var flag = true;
            string path = @"C:\Users\320053936\source\repos\PractiseApp.plog";
            
            try
            {
                string[] linesOfFile = File.ReadAllLines(path);
            }
            catch (Exception e)
            {
                flag = false;
            }
            Assert.IsTrue(flag);
        }

        [TestMethod]

        public void TextfileExistancePVSstudio()
        {
            string path = @"C:\Users\320053936\Desktop\Reports\PVSReport.txt";
            var flag = true;
            
            try
            {
                string[] linesOfFile = File.ReadAllLines(path);
            }
            catch (Exception e)
            {
                flag = false;
            }
            Assert.IsTrue(flag);

        }

        [TestMethod]

        public void ContentCheckInReportPVSstudio()
        {
            string path = @"C:\Users\320053936\Desktop\Reports\PVSReport.txt";
            var flag = true;
          
            string[] linesOfFile = File.ReadAllLines(path);

            if (new FileInfo(path).Length == 0)
            {
                flag = false;
            }
            Assert.IsTrue(flag);
        }
        ////////////////////////////////////////////////////// for Ndepend
        [TestMethod]
        public void ReportExistanceNdepend()
        {
            
            var flag = true;
            string path = @"C:\Users\320053936\source\repos\PractiseApp\NDependOut\NDependReport.html";
            try
            {
                string[] linesOfFile = File.ReadAllLines(path);
            }
            catch (Exception e)
            {
                flag = false;
            }
            Assert.IsTrue(flag);
        }

        [TestMethod]

        public void TextfileExistanceNdepend()
        {
            string path = @"C:\Users\320053936\Desktop\Reports\Ndepend.txt";
            var flag = true;
            
            try
            {
                string[] linesOfFile = File.ReadAllLines(path);
            }
            catch (Exception e)
            {
                flag = false;
            }
            Assert.IsTrue(flag);

        }

        [TestMethod]

        public void ContentCheckInReportNdepend()
        {
            string path = @"C:\Users\320053936\Desktop\Reports\Ndepend.txt";
            var flag = true;
            
            string[] linesOfFile = File.ReadAllLines(path);

            if (new FileInfo(path).Length == 0)
            {
                flag = false;
            }
            Assert.IsTrue(flag);
        }


       

        [TestMethod]
        public void ReportExistanceResharper()
        {
            
            var flag = true;
            string path = @"C:\Users\320053936\Downloads\ReSharper\ModifiedReport4.xml";
            try
            {
                string[] linesOfFile = File.ReadAllLines(path);
            }
            catch (Exception e)
            {
                flag = false;
            }
            Assert.IsTrue(flag);
        }

        [TestMethod]

        public void TextfileExistanceResharper()
        {
            string path = @"C:\Users\320053936\Desktop\Reports\ReSharper.txt";
            var flag = true;
            
            try
            {
                string[] linesOfFile = File.ReadAllLines(path);
            }
            catch (Exception e)
            {
                flag = false;
            }
            Assert.IsTrue(flag);

        }

        [TestMethod]

        public void ContentCheckInReportResharper()
        {
            string path = @"C:\Users\320053936\Desktop\Reports\ReSharper.txt";
            var flag = true;
            
            string[] linesOfFile = File.ReadAllLines(path);

            if (new FileInfo(path).Length == 0)
            {
                flag = false;
            }
            Assert.IsTrue(flag);
        }

        /*For testing merged report*/
        
        [TestMethod]
        public void TextfileExistanceFinalMergedReport()
        {
            string path = @"C:\Users\320053936\Desktop\Reports\FinalMergedReport.txt";
            var flag = true;
            
            try
            {
                string[] linesOfFile = File.ReadAllLines(path);
            }
            catch (Exception e)
            {
                flag = false;
            }
            Assert.IsTrue(flag);

        }
    }
}
