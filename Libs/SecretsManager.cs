namespace ci_automation_enterpriseportalui.Libs
{
    public static class SecretsManager
    {
        private static SqlConfig SqlConfig;
        private static SnowflakeConfig SnowflakeConfig;
        private static string GithubToken;

        public static void Setup(string environment, string account, string warehouse)
        {

            SecretClientOptions options = new SecretClientOptions()
            {
                Retry = {
                    Delay= TimeSpan.FromSeconds(2),
                    MaxDelay = TimeSpan.FromSeconds(16),
                    MaxRetries = 5,
                    Mode = RetryMode.Exponential
                }
            };
            var settings = SettingsConfig.Get();
            string vaultName = SettingsHandler.GetSettingString("KeyVaultName", settings);
            string tenantId = SettingsHandler.GetSettingString("KeyVaultTenantId", settings);
            string clientId = SettingsHandler.GetSettingString("KeyVaultClientId", settings);
            string clientSecret = SettingsHandler.GetSettingString("KeyVaultClientSecret", settings);
            string vaultUrl = $"https://{vaultName}-{environment}.vault.azure.net/";
            ClientSecretCredential token = new(tenantId, clientId, clientSecret);
            SecretClient client = new(new Uri(vaultUrl), token);
            SqlConfig = new SqlConfig(client);
            SnowflakeConfig = new SnowflakeConfig(client, account, warehouse);
            //KeyVaultSecret ghToken = client.GetSecret("GithubToken");
            //GithubToken = ghToken.Value;
        }
        public static string SQLConnectionString()
        {
            return SqlConfig.ConnectionString();
        }

        public static string SQLMetadataDatabase()
        {
            return SqlConfig.MetadataDatabase;
        }

        public static string SnowflakeTestResultDb()
        {
            return SnowflakeConfig.SnowflakeTestDatabase;
        }

        public static string TestResultsSchema()
        {
            return SqlConfig.TestResultsSchema;
        }

        public static string SnowflakeConnectionString()
        {
            return SnowflakeConfig.ConnectionString();
        }
        public static string SnowflakeConnectionString(string tenantRole, string warehouse)
        {
            return SnowflakeConfig.ConnectionString(tenantRole, warehouse);
        }
        public static string SnowflakeStandardRole()
        {
            return SnowflakeConfig.SnowflakeRole;
        }
        public static string GetGithubToken()
        {
            return GithubToken;
        }
    }
}
