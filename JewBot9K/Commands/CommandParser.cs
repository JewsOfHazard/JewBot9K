using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JewBot9K.Commands
{
    class CommandParser
    {
        private static Dictionary<string, ICommand> commands;

        private static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => string.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }


        public static void init()
        {
            commands = new Dictionary<string, ICommand>();

            Type[] temp = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "JewBot9K.Commands"); //list of every command in namespace JewBot9K.Commands and <>c__DisplayClass1_0
            List<Type> typelist = new List<Type>();
            for (int i = 0; i < temp.Length; i++)
            {
                if (!new string[] { "Command", "CommandParser", "ICommand", "CLevel", "<>c__DisplayClass1_0" }.Contains(temp[i].Name) && !temp[i].GetInterface("ICommand").Equals(""))
                {
                    typelist.Add(temp[i]);
                }
            }



            foreach (Type cClass in typelist)
            {
                object instance = Activator.CreateInstance(cClass);
                ICommand newClass = (ICommand)instance;
                try
                {
                    commands.Add(newClass.getCommandText(), (ICommand)newClass);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }


            //type list is a full list classes we have that implement ICommand and arent ICommand, CommandParser, ICommand, CLevel, and <>c__DisplayClass1_0
        }



        /*
         @param command - command that was sent without the leading !
         @param sender - person who sent the command
         @param channel - Channel the command was sent in
         @param parameters - parameters sent along with the command
         @return {@link ICommand#execute(String, String, String[])} or null if the command does not exist
        */
        public static string parse(string command, string user, string channel, string[] parameters)
        {
            command = command.ToLower();
            ICommand c = commands[command];
            if (c != null && hasAccess(c, user, channel))
            {
                List<string> passed = new List<string>();
                int i = 0;

                while (i < parameters.Length)
                {
                    if (parameters[i].StartsWith("\""))
                    {
                        if (parameters[i].EndsWith("\""))
                        {
                            passed.Add(parameters[i].Replace("\"", ""));
                            continue;
                        }
                        string temp = parameters[i].Replace("\"", "") + " ";
                        i++;
                        bool endQuote = true;
                        while (!parameters[i].EndsWith("\""))
                        {
                            temp += parameters[i] + " ";
                            i++;
                            if (i >= parameters.Length)
                            {
                                endQuote = false;
                                break;
                            }
                        }
                        if (endQuote)
                        {
                            temp += parameters[i].Replace("\"", "");
                        }
                        i++;
                        passed.Add(temp);
                        continue;
                    }
                    passed.Add(parameters[i]);
                    i++;
                }
                return c.execute(channel, user, toStringArray(passed));
            }

            return null;
        }

        private static bool hasAccess(ICommand c, string sender, string channel)
        {
            switch (c.getCommandLevel())
            {
                case CLevel.Mod:
                    throw new NotImplementedException(); //get moderators from something
                case CLevel.Owner:
                    return sender.ToLower().Equals(Settings.username);
                case CLevel.Normal:
                    return true;
            }
            return false;
        }

        private static string[] toStringArray(List<string> passed)
        {
            string[] result = new string[passed.Count];
            for (int i = 0; i < passed.Count; i++)
            {
                result[i] = passed[i];
            }
            return result;
        }
    }
}
