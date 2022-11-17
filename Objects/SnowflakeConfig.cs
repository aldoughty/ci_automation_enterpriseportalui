namespace ci_automation_enterpriseportalui.Objects
{
    public class SnowflakeConfig
    {
        public string SnowflakeUser { get; set; }
        public string SnowflakePassword { get; set; }
        public string SnowflakeAccount { get; set; }
        public string SnowflakeRole { get; set; }
        public string SnowflakeWareHouse { get; set; }
        public string SnowflakeTestDatabase { get; set; }
        public string TestResultsSchema { get; set; }
        public string SnowflakeHost { get; set; }

        public SnowflakeConfig(SecretClient client, string account, string warehouse)
        {
            KeyVaultSecret secret = client.GetSecret("SnowflakeTRUser-" + account);
            SnowflakeUser = secret.Value;
            secret = client.GetSecret("SnowflakeTRPassword-" + account);
            SnowflakePassword = secret.Value;
            secret = client.GetSecret("SnowflakeAccount-" + account);
            SnowflakeAccount = secret.Value;
            secret = client.GetSecret("SnowflakeRole-" + account);
            SnowflakeRole = secret.Value;
            SnowflakeWareHouse = string.IsNullOrEmpty(warehouse) ? ((KeyVaultSecret)client.GetSecret("SnowflakeWarehouse-" + account)).Value : warehouse;
            secret = client.GetSecret("SnowflakeDatabase-" + account);
            SnowflakeTestDatabase = secret.Value;
            secret = client.GetSecret("TestResultsSchema");
            TestResultsSchema = secret.Value;
            secret = client.GetSecret("SnowflakeHost-" + account);
            SnowflakeHost = secret.Value;
        }

        public string ConnectionString()
        {
            var account = $"account={SnowflakeAccount}";
            var user = $"user={SnowflakeUser}";
            var password = $"password={SnowflakePassword}";
            var warehouse = $"warehouse={SnowflakeWareHouse}";
            var db = $"db={SnowflakeTestDatabase}";
            var host = $"host={SnowflakeHost}";
            var role = $"role={SnowflakeRole}";
            string[] words = { account, user, password, warehouse, db, host, role };
            return string.Join(";", words);
        }
        public string ConnectionString(string tenantRole, string warehouse)
        {
            var account = $"account={SnowflakeAccount}";
            var user = $"user={SnowflakeUser}";
            var password = $"password={SnowflakePassword}";
            var mywarehouse = $"warehouse={warehouse}";
            var db = $"db={SnowflakeTestDatabase}";
            var host = $"host={SnowflakeHost}";
            var role = $"role={tenantRole}";
            string[] words = { account, user, password, mywarehouse, db, host, role };
            return string.Join(";", words);
        }
    }
}