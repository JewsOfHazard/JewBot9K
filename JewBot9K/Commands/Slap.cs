using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewBot9K.Commands
{
    class Slap : ICommand
    {


        public string execute(string channel, string sender, string[] parameters)
        {
            throw new NotImplementedException();
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
