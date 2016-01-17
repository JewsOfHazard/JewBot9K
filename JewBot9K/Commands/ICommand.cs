namespace JewBot9K.Commands {

    public interface ICommand
    {
        string execute(string channel, string sender, string[] parameters);
        CLevel getCommandLevel();
        string getCommandText();
    }
}