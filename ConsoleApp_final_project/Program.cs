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
    class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "CMD";
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;

            Operations op = new Operations();
            op.Start();

        }
    }
}
