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
        public static bool followerResponseEnabled { get; set; }
        public static string followerResponseText { get; set; }
        public static string pointsName { get; set; }
        public static bool pointsEnabled { get; set; }


        private static FileIniDataParser parser = new FileIniDataParser();
        private static byte[] salt = { 212, 22, 10, 73, 56, 166, 62, 245, 234, 90, 187, 130, 50, 174, 2, 250, 196, 182, 63, 175 };
        private static string settingsLocation = Application.StartupPath + "\\JewBot9KSettings.ini";


        private static IniData GetIniData()
        {
            try
            {
                return parser.ReadFile(settingsLocation);
            }
            catch (IniParser.Exceptions.ParsingException)
            {
                return new IniData();
            }
        }


        public static void logOut()
        {
            IniData data = GetIniData();
            if (data.Sections.ContainsSection("LoginInformation"))
            {
                data.Sections.RemoveSection("LoginInformation");
            }
            parser.WriteFile(settingsLocation, data);
        }

        public static void SavePassword(string username, string oauth, bool encrypt = true)
        {

            IniData data = GetIniData();


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


            IniData data = GetIniData();


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

            IniData data = GetIniData();

            try
            {
                data["DashboardSettings"]["CommercialsEnabled"] = commercialEnabled.ToString();
                data["DashboardSettings"]["AutoCommercialsEnabled"] = autoCommercialEnabled.ToString();
                data["DashboardSettings"]["NewFollowerNotificationEnabled"] = followerResponseEnabled.ToString();
                data["DashboardSettings"]["NewFollowerNotificationText"] = followerResponseText;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                data.Sections.AddSection("DashboardSettings");
                data["DashboardSettings"].AddKey("CommercialsEnabled", commercialEnabled.ToString());
                data["DashboardSettings"].AddKey("AutoCommercialsEnabled", autoCommercialEnabled.ToString());
                data["DashboardSettings"].AddKey("NewFollowerNotificationEnabled", followerResponseEnabled.ToString());
                data["DashboardSettings"].AddKey("NewFollowerNotificationText", followerResponseText);
            }


            parser.WriteFile(settingsLocation, data);
        }

        public static object[] LoadDashboardFromFile()
        {

            IniData data = GetIniData();

            return new object[] {
                data["DashboardSettings"]["CommercialsEnabled"],
                data["DashboardSettings"]["AutoCommercialsEnabled"],
                data["DashboardSettings"]["NewFollowerNotificationEnabled"],
                data["DashboardSettings"]["NewFollowerNotificationText"]
            };
        }


        public static void WritePoints()
        {

            IniData data = GetIniData();

            try
            {
                data["Points"]["Enabled"] = pointsEnabled.ToString();
                data["Points"]["Name"] = pointsName;
            }
            catch (NullReferenceException)
            {
                data.Sections.AddSection("Points");
                data["Points"].AddKey("Enabled", pointsEnabled.ToString());
                data["Points"].AddKey("Name", pointsName);
            }


            parser.WriteFile(settingsLocation, data);
        }

        public static object[] LoadPointsSettings()
        {

            IniData data = GetIniData();

            return new object[] {
                data["Points"]["Enabled"],
                data["Points"]["Name"]
            };
        }
    }

}