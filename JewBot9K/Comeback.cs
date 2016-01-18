
namespace JewBot9K.Commands
{
    class Comeback : ICommand
    {
        public CLevel getCommandLevel()
        {
            return CLevel.Normal;
        }


        public string getCommandText()
        {
            return "comeback";
        }

        public string execute(string channel, string sender, string[] parameters)
        {
            return $"{parameters[0]} COME BACK! YOU CAN BLAME IT ALL ON ME!";
        }
    }
}
