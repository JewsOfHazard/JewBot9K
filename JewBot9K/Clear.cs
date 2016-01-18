
using System;

namespace JewBot9K.Commands
{
    class Clear : ICommand
    {
        public string execute(string channel, string sender, string[] parameters)
        {
            return "/clear";
        }

        public CLevel getCommandLevel()
        {
            return CLevel.Mod;
        }

        public string getCommandText()
        {
            return "clear";
        }
    }
}
