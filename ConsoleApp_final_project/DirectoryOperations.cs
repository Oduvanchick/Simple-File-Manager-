using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.CodeDom.Compiler;
using System.Configuration;
using System.ComponentModel.Design;
using System.Data;

namespace ConsoleApp_final_project
{
    class DirectoryOperations
    {
        public string dirName { get; set; }
        public string path { get; set; }
        public void ToPredDir()
        {
            string[] dirSplit = dirName.Split(new char[] { '\\' });
            dirName = "";
            for (int i = 0; i < dirSplit.Length - 2; i++)
                dirName += dirSplit[i] + "\\";
        }
        public void ToNextDir(string name)
        {
            if (Directory.Exists(dirName + name))
                dirName += name + "\\";
            else
                Console.WriteLine("This directory doesnt exist (");
        }
        public void CreateDir()
        {
            try
            {
                if (Directory.Exists(path))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }

                DirectoryInfo di = Directory.CreateDirectory(path);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
        public void RemoveDir()
        {
            try
            {
                // Determine whether the directory exists.
                if (!Directory.Exists(path))
                {
                    Console.WriteLine("That path doesnt exists");
                    return;
                }

                if (Directory.GetFiles(path).Length == 0)
                {

                    Directory.Delete(path);

                    Console.WriteLine("The directory was deleted successfully.");
                }
                else
                    Console.WriteLine("The directory not empty");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        public void Display()
        {
            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Подкаталоги:");
                string[] dirs = Directory.GetDirectories(dirName);
                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
            }
        }

        public void MoveDir(string oldPath, string newPath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(oldPath);
            if (dirInfo.Exists && Directory.Exists(newPath) == false)
            {
                dirInfo.MoveTo(newPath);
                Console.WriteLine("Done");

            }
            else
                Console.WriteLine("Path wrong");
        }

        public void CopyDir(string oldPath, string newPath)
        {
            DirectoryInfo sourceDir = new DirectoryInfo(oldPath);
            DirectoryInfo destinationDir = new DirectoryInfo(newPath);
            CopyDirectory(sourceDir, destinationDir);
            Console.WriteLine("Okay");
        }
        static void CopyDirectory(DirectoryInfo source, DirectoryInfo destination)
        {
            if (!destination.Exists)
            {
                destination.Create();

                // Copy all files.
                FileInfo[] files = source.GetFiles();
                foreach (FileInfo file in files)
                {
                    file.CopyTo(Path.Combine(destination.FullName,
                        file.Name));
                }

                // Process subdirectories.
                DirectoryInfo[] dirs = source.GetDirectories();
                foreach (DirectoryInfo dir in dirs)
                {
                    // Get destination directory.
                    string destinationDir = Path.Combine(destination.FullName, dir.Name);

                    // Call CopyDirectory() recursively.
                    CopyDirectory(dir, new DirectoryInfo(destinationDir));
                }

            }
            else Console.WriteLine(":((  You should write new name of copyfolder");
        }
    }
}
