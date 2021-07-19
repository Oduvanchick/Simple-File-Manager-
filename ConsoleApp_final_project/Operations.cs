using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_final_project
{
    class Operations
    {
        string dirName = "C:\\Users\\";
        string[] commands;

        public void Initialize()
        {
            string input = Console.ReadLine();
            commands = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public void ForOneCommand(DirectoryOperations directory, FilesOperations file)
        {
            string[] Drives = Environment.GetLogicalDrives();

            if (commands[0] == "help")
            {
                AllCommands help = new AllCommands();
                help.Show();
            }
            else if (commands[0] == "clear")
            {
                Clear();
            }
            else if (commands[0] == "drives")
            {
                foreach (string s in Drives)
                    Console.WriteLine(s);
            }
            else if (commands[0] == "dir")
            {
                directory.Display();
            }
            else if (commands[0] == "renfileenum")
            {
                file.RenFileEnum();
            }
            else
            {
                bool b = false;
                foreach (string d in Drives)
                {
                    if (commands[0] == d)
                    {
                        dirName = commands[0];
                        directory.dirName = dirName;
                        file.Filename = dirName;
                        b = true;
                    }
                }
                if (b == false)
                    Console.WriteLine("Incorrect command");
            }
        }

        public void ForTwoCommands(DirectoryOperations directory, FilesOperations file)
        {
            directory.path = directory.dirName + commands[1];
            file.Filename = dirName + commands[1];

            switch (commands[0])
            {
                case "help":
                    {
                        AllCommands help = new AllCommands();
                        help.ShowDecription(commands[1]);
                        break;
                    }
                case "cd":
                    {
                        if (commands[1] == "..")
                            directory.ToPredDir();
                        else
                            directory.ToNextDir(commands[1]);
                        dirName = directory.dirName;
                        break;
                    }
                case "create":
                    {
                        file.Create();
                        break;
                    }
                case "read":
                    {
                        file.ReadFile();
                        break;
                    }
                case "attrib":
                    {
                        file.GetAttributes();
                        break;
                    }

                case "mkdir":
                    {
                        directory.CreateDir();
                        break;
                    }
                case "rmdir": // удаляет подкаталог каталога, в кот мы находимся
                    {
                        directory.RemoveDir();
                        break;
                    }
                case "searchfile":
                    {
                        file.SearchFile(dirName, commands[1]);
                        break;
                    }
                default:
                    Console.WriteLine("Incorrect command");
                    break;
            }
        }

        public void ForThreeCommands(DirectoryOperations directory, FilesOperations file)
        {
            switch (commands[0])
            {
                case "movedir":
                    {
                        directory.MoveDir(commands[1], commands[2]);
                        break;
                    }
                case "movefile":
                    {
                        file.MoveFile(commands[1], commands[2]);
                        break;
                    }
                case "copydir":
                    {
                        directory.CopyDir(commands[1], commands[2]);
                        break;
                    }
                case "copyfile":
                    {
                        file.CopyFile(commands[1], commands[2]);
                        break;
                    }
                case "create":
                    {
                        file.Filename = dirName + commands[2];
                        if (commands[1] == "rec")
                            file.CreateRecord();
                        else
                            Console.WriteLine("Wrong command");
                        break;
                    }
                default:
                    Console.WriteLine("Incorrect command");
                    break;
            }
        }

        public void Start()
        {
            DirectoryOperations directory = new DirectoryOperations();
            directory.dirName = dirName;
            directory.path = dirName;

            FilesOperations file = new FilesOperations();
            file.Filename = dirName;

            int q = 11;
            do
            {
                Console.Write(dirName + ">");
                Initialize();

                if (commands.Length == 1)
                    ForOneCommand(directory, file);

                if (commands.Length == 2)
                    ForTwoCommands(directory, file);

                if (commands.Length == 3)
                    ForThreeCommands(directory, file);
            } while (q != 0);
            Console.ReadLine();
        }
        static void Clear()
        {
            Console.Clear();
            Console.WriteLine("Exit - ESC");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Console.ReadKey();
            }
            Console.Clear();
        }
    }
}
