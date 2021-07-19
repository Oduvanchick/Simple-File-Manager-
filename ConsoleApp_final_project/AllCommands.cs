using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_final_project
{
    class AllCommands
    {
        Dictionary<string, string> help = new Dictionary<string, string>
        {
            ["cd"] = "move to the folder",
            ["cd .."] = "return to previous folder",
            ["drives"] = "show exists drives",
            ["dir"] = "show all folders & files in current directory",
            ["renfileenum"] = "rename all files in directory: enumarated every file",
            ["create"] = "create new file",
            ["read"] = "read file",
            ["attrib"] = "show files attributes",
            ["mkdir"] = "create new directory",
            ["rmdir"] = "remove directory if it empty",
            ["searchfile"] = "searching files",
            ["movedir"] = "move directory",
            ["movefile"] = "move file",
            ["copydir"] = "copy directory",
            ["copyfile"] = "copy file",
            ["create rec"] = "create file with oportunity to record in it"
        };
        public void Show()
        {
            foreach (KeyValuePair<string, string> keyValue in help)
                Console.WriteLine(keyValue.Key + "\t-\t" + keyValue.Value);
        }
        public void ShowDecription(string key)
        {
            try
            {
                Console.WriteLine(key + "\t-\t" + help[key]);
            }
            catch (Exception e) 
            {
                Console.WriteLine("Command doesnt exist");
            }
        }
    }
}
