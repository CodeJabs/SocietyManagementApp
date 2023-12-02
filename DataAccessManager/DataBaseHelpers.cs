using Microsoft.Win32;
using System;

namespace DataAccessManager
{
    internal sealed class DataBaseHelpers
    {
        RegistryView registryView;
        private const string SEMI_COLON = ";";
        private const string INITIAL_CATALOG = "Initial Catalog=";
        private const string USER_NAME = "UID=";
        private const string PASSWORD = "password=";
        private string DataBaseName = "HSMS";
        private string UserName = "sa";
        private string Password = "JaborniDrive@09";
        public string GetConnectionString()
        {
            string connectionString = GetServerName()+ SEMI_COLON + INITIAL_CATALOG + DataBaseName + SEMI_COLON + USER_NAME + UserName + SEMI_COLON + PASSWORD + Password+ SEMI_COLON;
            return connectionString;
        }
        public DataBaseHelpers()
        {
            registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
        }
        private string GetServerName()
        {
            string serverName = string.Empty;
            string MachineName = Environment.MachineName;
            using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey registryKey = key.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (registryKey != null)
                {
                    foreach (string keyName in registryKey.GetValueNames())
                    {
                        //serverName = $"{MachineName}{"\\"}{keyName}";
                        serverName = $"{MachineName}";
                    }
                }
                return "Data Source="+serverName;
            }
        }
    }
}
