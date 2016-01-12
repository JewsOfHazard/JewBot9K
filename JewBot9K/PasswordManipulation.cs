using IniParser;
using IniParser.Model;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace JewBot9K.Security
{
    class PasswordManipulation
    {
        private static byte[] salt = { 15, 215, 140, 130, 8, 183, 11, 162, 117, 160, 68, 139, 80, 204, 173, 222, 232, 175, 234, 3 };
        private static string settingsLocation = Application.StartupPath + "\\JewBot9KSettings.ini";

        public static void SavePassword(string username, string oauth)
        {
            byte[] usernameByteArray = Encoding.UTF8.GetBytes(username);
            byte[] oauthByteArray = Encoding.UTF8.GetBytes(oauth);

            byte[] protectedUsername = ProtectedData.Protect(usernameByteArray, salt, DataProtectionScope.CurrentUser);
            byte[] protectedOAuth = ProtectedData.Protect(oauthByteArray, salt, DataProtectionScope.CurrentUser);

            string cipheredUsername = Convert.ToBase64String(protectedUsername);
            string cipheredOAuth = Convert.ToBase64String(protectedOAuth);

            var parser = new FileIniDataParser();
            IniData data = new IniData();

            data.Sections.AddSection("LoginInformation");
            data["LoginInformation"].AddKey("Username", cipheredUsername);
            data["LoginInformation"].AddKey("OAuth", cipheredOAuth);

            parser.WriteFile(settingsLocation, data);

        }

        public static string[] GetPassword()
        {

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(settingsLocation);
            string username = data["LoginInformation"]["Username"];
            string oauth = data["LoginInformation"]["OAuth"];

            byte[] usernameCipher = Convert.FromBase64String(username);
            byte[] oauthCipher = Convert.FromBase64String(oauth);

            byte[] decryptedUsername = ProtectedData.Unprotect(usernameCipher, salt, DataProtectionScope.CurrentUser);
            byte[] decryptedOAuth = ProtectedData.Unprotect(oauthCipher, salt, DataProtectionScope.CurrentUser);

            username = Encoding.Default.GetString(decryptedUsername);
            oauth = Encoding.Default.GetString(decryptedOAuth);

            return new string[]{ username, oauth };
        }

    }
}
