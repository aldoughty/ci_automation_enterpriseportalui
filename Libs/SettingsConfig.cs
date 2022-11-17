namespace ci_automation_enterpriseportalui.Libs
{
    public static class SettingsConfig
    {
        public static IConfiguration Get()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
        }
    }
}