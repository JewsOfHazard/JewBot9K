using System;
using JewBot9K.Commands;

namespace JewBot9K.Commands
{
    class Fight : ICommand
    {
        public string execute(string channel, string sender, string[] parameters)
        {
            return $"{sender} puts up his digs in preparation to punch {parameters[0]}";
        }

        public CLevel getCommandLevel()
        {
            return CLevel.Normal;
        }

        public string getCommandText()
        {
            return "fight";
        }
    }
}
