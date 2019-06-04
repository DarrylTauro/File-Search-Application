using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string noOfCopies = "";
            string fileName = "";
            string targetPath = "";
            string sourcePath = Directory.GetCurrentDirectory();
            Console.WriteLine("Enter The Source Filename (From Current Directory Ex:test.txt):");
            fileName = Console.ReadLine();
            while (!File.Exists(sourcePath + "\\" + fileName))
            {
                Console.WriteLine("File with given name not found in current directory, Please Keep the file in current direcory or check the entered filename");
                Console.WriteLine("Enter The Source Filename (From Current Directory Ex:test.txt):");
                fileName = Console.ReadLine();
            }

            Console.WriteLine("Enter Number of File Copies:");
            noOfCopies = Console.ReadLine();
            int copies = 0;
            while (!int.TryParse(noOfCopies, out copies))
            {
                Console.WriteLine("Please Enter Valid Integer");
                Console.WriteLine("Enter Number of File Copies:");
                noOfCopies = Console.ReadLine();
            }
            Console.WriteLine("Enter The Target Directory Path (Ex: C:\\SearchFolder\\)");
            targetPath = @"" + Console.ReadLine();

            string filenameNoExtension = fileName.Split('.')[0];
            try
            {
                if (!Directory.Exists(targetPath))
                {
                    Directory.CreateDirectory(targetPath);
                }
                string sourceFile = Path.Combine(sourcePath, fileName);
                if (File.Exists(sourceFile))
                {
                    for (int i = 1; i <= copies; i++)
                    {
                        if (!File.Exists(targetPath + filenameNoExtension + i + ".txt"))
                            File.Copy(sourceFile, targetPath +"\\"+ filenameNoExtension + i + ".txt");
                    }
                }
                Console.WriteLine("Files Created");
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception Occured: {0}",e.Message);
            }

            Console.ReadLine();
        }

    }
}
