
namespace JewBot9K.Commands
{
    class Fatality : ICommand
    {
        public string execute(string channel, string sender, string[] parameters)
        {
            return ($"It turns out that {sender} has killed {parameters[0]}... Run, RUN!");
        }

        public CLevel getCommandLevel()
        {
            return CLevel.Normal;
        }

        public string getCommandText()
        {
            return "fatality";
        }
    }
}
