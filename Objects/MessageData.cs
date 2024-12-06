namespace ci_automation_enterpriseportalui.Objects
{
    public class MessageData
    {
        public string TenantId { get; set; }
        public string BatchId { get; set; }
        public string ApplicationUnderTest { get; set; }
        public string Environment { get; set; }
        public string Dag_Identifier { get; set; }
        public bool LocalLogs { get; set; }
        public StandardTestParameters StandardTestParameters { get; set; }
        public string SnowflakeAccount { get; set; }
        public string SnowflakeWarehouse { get; set; }
        public string SnowflakeRole { get; set; }
        public string Browser { get; set; }
        public string Url { get; set; }

        public MessageData()
        {
            StandardTestParameters = new StandardTestParameters();
            StandardTestParameters.AutomationMicroService = GetType().Namespace;
        }
        public void ValidateContent()
        {
            StandardTestParameters.BatchId = BatchId;
            StandardTestParameters.ApplicationUnderTest = ApplicationUnderTest;
            StandardTestParameters.Environment = Environment;
            StandardTestParameters.LocalLogs = LocalLogs;
            //TenantId.Should().NotBeNullOrEmpty("TenantId is Empty");
            StandardTestParameters.BatchId.Should().NotBeNullOrEmpty("BatchId Is Empty");
            StandardTestParameters.Environment.Should().NotBeNullOrEmpty("Environment is EmptyCollection");
            StandardTestParameters.ApplicationUnderTest.Should().NotBeNullOrEmpty("Application Under Test is Empty");
            SecretsManager.Setup(Environment, SnowflakeAccount, SnowflakeWarehouse);
            var cs = SecretsManager.SQLConnectionString();
            StandardTestParameters.TenantName = string.IsNullOrEmpty(TenantId) ? "Multi-Tenant" : TenantData.GetTenantName(SecretsManager.SQLConnectionString(), TenantId);
        }
    }
}
