using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_final_project
{
    interface IMyCommand
    {
        void Execute();
    }
    class CommandHelp : IMyCommand
    {
        public void Execute()
        {
            Console.WriteLine("Help");
        }
    }
    class CommandCd : IMyCommand
    {
        public void Execute()
        {
            Console.WriteLine("Cd");
        }
    }
    class CommandCreate : IMyCommand
    {
        public void Execute()
        {
            Console.WriteLine("Cd");
        }
    }
}
