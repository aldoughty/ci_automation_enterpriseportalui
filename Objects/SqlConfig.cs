namespace ci_automation_enterpriseportalui.Objects
{
    public class SqlConfig
    {
        public string MetadataServer { get; set; }
        public string MetadataDatabase { get; set; }
        public string MetadataUser { get; set; }
        public string MetadataPassword { get; set; }
        public string TestResultsSchema { get; set; }

        public SqlConfig(SecretClient client)
        {
            KeyVaultSecret secret = client.GetSecret("MetadataServer");
            MetadataServer = secret.Value;
            secret = client.GetSecret("MetadataDatabase");
            MetadataDatabase = secret.Value;
            secret = client.GetSecret("MetadataUser");
            MetadataUser = secret.Value;
            secret = client.GetSecret("MetadataPassword");
            MetadataPassword = secret.Value;
            secret = client.GetSecret("TestResultsSchema");
            TestResultsSchema = secret.Value;

        }
        public string ConnectionString()
        {
            var server = $"server={MetadataServer}";
            var database = $"database={MetadataDatabase}";
            var userId = $"User Id={MetadataUser}";
            var password = $"Password={MetadataPassword}";
            string[] words = { server, database, userId, password };
            return string.Join(";", words);
        }
    }
}