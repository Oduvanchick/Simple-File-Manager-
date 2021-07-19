using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp_final_project
{
    class FilesOperations
    {
        public string Filename { get; set; }
        public void Create()
        {
            FileStream fs = new FileStream(Filename,
                                                FileMode.Create,
                                                    FileAccess.Write,
                                                        FileShare.ReadWrite);
            Console.WriteLine("File succesfully created");
        }
        public void ReadFile()
        {
            if (File.Exists(Filename))
            {
                using (FileStream fs = new FileStream(Filename, FileMode.Open))
                using (StreamReader sr = new StreamReader(fs))
                {

                    while (!sr.EndOfStream)
                    {
                        Console.WriteLine(sr.ReadLine());
                    }
                }
            }
            else
                Console.WriteLine("File doesnt exist");
        }
        public void GetAttributes()
        {
            if (File.Exists(Filename))
            {
                FileAttributes attributes = File.GetAttributes(Filename);
                if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    Console.WriteLine("read-only file");
                else
                    Console.WriteLine("not read-only file");

                if ((attributes & FileAttributes.Archive) == FileAttributes.Archive)
                    Console.WriteLine("archive file");
                else
                    Console.WriteLine("not archive file");

                if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                    Console.WriteLine("Hidden file");
                else
                    Console.WriteLine("not Hidden file");

                if ((attributes & FileAttributes.Normal) == FileAttributes.Normal)
                    Console.WriteLine("Normal file");
                else
                    Console.WriteLine("not Normal file");

                if ((attributes & FileAttributes.Compressed) == FileAttributes.Compressed)
                    Console.WriteLine("Compressed file");
                else
                    Console.WriteLine("not Compressed file");
            }
            else
                Console.WriteLine("File doesnt exist");
        }

        public void SearchFile(string dirName, string search)
        {
            try
            {
                string[] dirs = Directory.GetFiles(dirName, search);
                Console.WriteLine();
                foreach (string dir in dirs)
                    Console.WriteLine(dir);
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        public void MoveFile(string oldPath, string newPath)
        {
            FileInfo fileInf = new FileInfo(oldPath);
            if (fileInf.Exists)
            {
                fileInf.MoveTo(newPath);
                Console.WriteLine("Done");
            }
            else
                Console.WriteLine("Path wrong");
        }
        public void CopyFile(string oldPath, string newPath)
        {
            FileInfo fileInf = new FileInfo(oldPath);
            if (fileInf.Exists)
            {
                fileInf.CopyTo(newPath, true);
                Console.WriteLine("Done");
            }
            else
                Console.WriteLine("Path wrong");
        }
        public void CreateRecord()
        {
            FileStream fs =
                    new FileStream(Filename,
                                FileMode.Create,
                                FileAccess.Write,
                                FileShare.ReadWrite);
            Console.WriteLine("File succesfully created");
            Console.WriteLine("Press ESC starting on a new line when finished writing\n");
            using (StreamWriter sw = new StreamWriter(fs))
            {
                while (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    string str = Console.ReadLine();
                    sw.WriteLine(str);
                }
            }
        }
        public void RenFileEnum()
        {
            string dirName = Filename;
            int count = 1;
            IEnumerable<FileInfo> filesToRename = Directory.GetFiles(dirName)
                                                            .Select(f => new FileInfo(f));
            foreach (FileInfo file in filesToRename)
            {
                string newFileName = $@"{Path.GetFileNameWithoutExtension(file.Name)}{count++}{file.Extension}";
                string newFileFullPath = Path.Combine(file.DirectoryName, newFileName);
                File.Move(file.FullName, newFileFullPath);
            }
        }
    }
}
