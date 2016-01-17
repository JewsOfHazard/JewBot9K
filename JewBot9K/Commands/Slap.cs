using System;

namespace JewBot9K.Commands
{
    class Slap : ICommand
    {


        public string execute(string channel, string sender, string[] parameters)
        {
            Console.WriteLine("What is this shit");
            return $"{sender} slaps {parameters[0]} in the face really hard.";
        }

        public CLevel getCommandLevel()
        {
            return CLevel.Normal;
        }

        public string getCommandText()
        {
            return "slap";
        }

    }
}
