namespace ci_automation_enterpriseportalui.PageObjects
{
    public static class ClientAdminTenantIntegrationsPage
    {
        //Client Admin Tenant Integrations Page Elements

        //Titles, Labels                                                                                                
        public static By Title(string tenant) => By.XPath(string.Format("//h5[contains(@class, 'integrations-header') and contains(., 'Integrations - {0}')]", tenant));
        public static By Description(string text) => By.XPath(string.Format("//h6[contains(@class, 'integrations-subheader') and contains(., '{0}')]", text));

        //Buttons, Checkboxes, Tabs
        public static By IntegrationsTab => By.Id("tab-integrations");
        public static By EditTab => By.Id("tab-edit");
        public static By CloseButton => By.XPath("//button[contains(@class, 'close-button')]");
        public static By AddIntegrationButton => By.Id("add-integration-button");

        //Tenant Integration Cards
        public static By StatusChip(string integration, string statusValue) => By.XPath(string.Format("//div[contains(@class, 'integrations_infoCardHeader') and contains(., '{0}') and contains(., '{1}')]", integration, statusValue));
        //public By EditConfiguration(string integrationValue) => By.XPath(string.Format("//div//descendant::button[contains(@class, 'configure-integraton-button') and contains(., '{0}')]", integration, statusValue));

        //Textfields



    }
}