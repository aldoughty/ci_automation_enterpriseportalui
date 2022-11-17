namespace ci_automation_enterpriseportalui.Libs
{
    public class ParseArguments
    {
        public static MessageData PullFromEnvVariables()
        {
            MessageData results = new();
            IConfiguration settings = SettingsConfig.Get();
            results.TenantId = SettingsHandler.GetSettingString("TenantId", settings);
            results.BatchId = SettingsHandler.GetSettingString("BatchId", settings, Guid.NewGuid().ToString());
            results.ApplicationUnderTest = SettingsHandler.GetSettingString("ApplicationUnderTest", settings);
            results.Environment = SettingsHandler.GetSettingString("Environment", settings, "Dev");
            results.SnowflakeAccount = SettingsHandler.GetSettingString("SnowflakeAccount", settings, "af01");
            results.SnowflakeWarehouse = SettingsHandler.GetSettingString("SnowflakeWarehouse", settings, "AQ_XSMALL");
            results.SnowflakeRole = SettingsHandler.GetSettingString("SnowflakeRole", settings, "ROLE_SVC_WRITER");
            results.Dag_Identifier = SettingsHandler.GetSettingString("DAG_Identifier", settings, "");
            results.LocalLogs = Convert.ToBoolean(SettingsHandler.GetSettingString("LocalLogs", settings, "false"));
            results.Browser = SettingsHandler.GetSettingString("SeleniumBrowser", settings, "Chrome.ChromeDriver");
            results.Url = SettingsHandler.GetSettingString("UrlUnderTest", settings, "https://testportal.affinaquest.com/");
            return results;
        }
    }
}
