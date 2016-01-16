namespace JewBot9K.Commands
{
    public abstract class Command
    {

        /**
         * @return the level that the user must be to perform the command
         */
        public abstract CLevel getCommandLevel();

        /**
         * @return the command without the leading ! or parameters
         */
        public abstract string getCommandText();

        /**
         * @param channel - channel the command was sent in
         * @param sender - user who sent the command
         * @param parameters - parameters sent with the command
         * @return a formatted message to send to the channel or null if no message is required
         */
        public abstract string execute(string channel, string sender, string[] parameters);

    }
}