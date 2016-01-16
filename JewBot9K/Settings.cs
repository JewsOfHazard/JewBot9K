using IniParser;
using IniParser.Model;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace JewBot9K
{
    class Settings
    {
        //subscribers /subscribersoff /slow /slowoff /r9kbeta /r9kbetaoff
        public static string displayName { get; set; }
        public static bool isAuthorized { get; set; }
        public static bool isConnected { get; set; }
        public static string username { get; set; }
        public static string oauth { get; set; }
        public static bool commercialEnabled { get; set; }
        public static bool autoCommercialEnabled { get; set; }
        public static bool isPartnered { get; set; }
        public static bool subscriberMode { get; set; }
        public static bool slowMode { get; set; }
        public static bool r9kmode { get; set; }
        public static int autoCommercialLength { get; set; }
        


        private static byte[] salt = { 212, 22, 10, 73, 56, 166, 62, 245, 234, 90, 187, 130, 50, 174, 2, 250, 196, 182, 63, 175 };
        private static string settingsLocation = Application.StartupPath + "\\JewBot9KSettings.ini";


        public static void SavePassword(string username, string oauth, bool encrypt = true)
        {
            var parser = new FileIniDataParser();
            IniData data;
            try
            {
                data = parser.ReadFile(settingsLocation);
            }
            catch (IniParser.Exceptions.ParsingException)
            {
                data = new IniData();
            }


            if (encrypt)
            {
                byte[] usernameByteArray = Encoding.UTF8.GetBytes(username);
                byte[] oauthByteArray = Encoding.UTF8.GetBytes(oauth);

                byte[] protectedUsername = ProtectedData.Protect(usernameByteArray, salt, DataProtectionScope.CurrentUser);
                byte[] protectedOAuth = ProtectedData.Protect(oauthByteArray, salt, DataProtectionScope.CurrentUser);

                username = Convert.ToBase64String(protectedUsername);
                oauth = Convert.ToBase64String(protectedOAuth);
            }

            data.Sections.AddSection("LoginInformation");
            data["LoginInformation"].AddKey("Username", username);
            data["LoginInformation"].AddKey("OAuth", oauth);
            data["LoginInformation"].AddKey("Encrypted", encrypt.ToString());


            parser.WriteFile(settingsLocation, data);

        }

        public static string[] LoadPasswordFromFile()
        {

            var parser = new FileIniDataParser();
            IniData data;
            try
            {
                data = parser.ReadFile(settingsLocation);
            }
            catch (IniParser.Exceptions.ParsingException)
            {
                data = new IniData();
            }
            string username = data["LoginInformation"]["Username"];
            string oauth = data["LoginInformation"]["OAuth"];
            bool encrypted = Convert.ToBoolean(data["LoginInformation"]["Encrypted"]);

            if (encrypted)
            {
                byte[] usernameCipher = Convert.FromBase64String(username);
                byte[] oauthCipher = Convert.FromBase64String(oauth);

                byte[] decryptedUsername = ProtectedData.Unprotect(usernameCipher, salt, DataProtectionScope.CurrentUser);
                byte[] decryptedOAuth = ProtectedData.Unprotect(oauthCipher, salt, DataProtectionScope.CurrentUser);

                username = Encoding.Default.GetString(decryptedUsername);
                oauth = Encoding.Default.GetString(decryptedOAuth);
            }

            return new string[] { username, oauth };
        }
        public static void WriteDashboardToFile()
        {

            var parser = new FileIniDataParser();
            IniData data;
            try
            {
                data = parser.ReadFile(settingsLocation);
            }
            catch (IniParser.Exceptions.ParsingException)
            {
                data = new IniData();
            }

            if (data.Sections.ContainsSection("DashboardSettings"))
            {
                data["DashboardSettings"]["CommercialsEnabled"] = commercialEnabled.ToString();
                data["DashboardSettings"]["AutoCommercialsEnabled"] = autoCommercialEnabled.ToString();
            }
            else
            {
                data.Sections.AddSection("DashboardSettings");
                data["DashboardSettings"].AddKey("CommercialsEnabled", commercialEnabled.ToString());
                data["DashboardSettings"].AddKey("AutoCommercialsEnabled", autoCommercialEnabled.ToString()); 
            }


            parser.WriteFile(settingsLocation, data);
        }

        public static object[] LoadDashboardFromFile()
        {

            var parser = new FileIniDataParser();
            IniData data;
            try
            {
                data = parser.ReadFile(settingsLocation);
            }
            catch (IniParser.Exceptions.ParsingException)
            {
                data = new IniData();
            }

            bool commercialsEnabled = Convert.ToBoolean(data["DashboardSettings"]["CommercialsEnabled"]);

            return new object[] { commercialsEnabled };
        }

    }

}