using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JewBot9K.Commands
{
    class CommandParser
    {
        private static Dictionary<string, Command> commands;

        private static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => string.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }

        public static void init()
        {
            commands = new Dictionary<string, Command>();

            Type[] temp = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "JewBot9K.Commands"); //list of every command in namespace JewBot9K.Commands and <>c__DisplayClass1_0
            List<Type> typelist = new List<Type>();
            for (int i = 0 ; i < temp.Length; i++)
            {
                if (! new string []{"Command", "CommandParser", "ICommand", "CLevel", "<>c__DisplayClass1_0" }.Contains(temp[i].Name))
                {
                    typelist.Add(temp[i]);
                }  
            }

            //type list is a full list of the commands we have

            //Set<Class<Command>> commandClassList = typeof(Slap).IsSubclassOf(typeof(Command));

            //Console.WriteLine(typelist[0].IsSubclassOf(Command));
        }

    }
}
