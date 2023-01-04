namespace ci_automation_enterpriseportalui.PageObjects
{
    public static class ClientAdminTenantConfigureIntegrationPage
    {
        //Client Admin Tenant Configure Integration Page Elements

        //Titles, Labels                                                                                                
        public static By Tenant(string tenant) => By.XPath(string.Format("//h6[contains(@class, 'left-header_text') and contains(., '{0}')]", tenant));
        public static By Title(string title) => By.XPath(string.Format("//h5[@id, 'tenant_integration_header' and contains(., '{0}')]", title));

        //Buttons, Checkboxes, Tabs
        public static By GoBack => By.XPath("//button[contains(., 'Go Back')]");
        public static By ChangeConnection => By.XPath("//button[contains(@class, 'change_connection_button')]");

        //Textfields
        public static By SearchIntegrations => By.XPath(string.Format("//div[contains(@class, 'add_tenant_integrations_search')]//descendant::input"));

        //Integration Cards
        public static By IntegrationCard => By.XPath("//div[contains(text(), 'CardContainer')]");   ////div[contains(text(), '{0}')]//following::div//descendant::button[@aria-label='Edit']
        public static By IntegrationName(string integrationName) => By.XPath(string.Format("//h5[contains(text(), '{0}')]", integrationName));
        public static By IntegrationType(string integrationType) => By.XPath(string.Format("//h6[contains(@class, 'infoCardHeader_subheader') and contains(text(), '{0}')]", integrationType));
        //integration could be the Name or Type
        //public static By Add(string integration) => By.XPath(string.Format("//div[contains(text(), '{0}')]//following::div//descendant::button[contains(@class, 'integrations_add-integration-button')]", integration));
        //public static By AddedStatus(string integration, string status) => By.XPath(string.Format("//div[contains(text(), '{0}')]//following::div//descendant::button[contains(@class, 'integrations_add-integration-button') and contains(text(), '{1}']", integration, status));
        
    }
}
