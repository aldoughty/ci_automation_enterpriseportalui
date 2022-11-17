namespace ci_automation_enterpriseportalui.PageObjects
{
    public static class ClientAdminTenantAddIntegrationPage
    {
        //Client Admin Tenant Add Integration Page Elements

        //Titles, Labels                                                                                                
        public static By Tenant(string tenant) => By.XPath(string.Format("//h5[contains(@class, 'left-header') and contains(., '{0}')]", tenant));
        public static By Title(string title) => By.XPath(string.Format("//h5[contains(@class, 'integrations_header') and contains(., '{0}')]", title));
        public static By Description(string text) => By.XPath(string.Format("//h6[contains(@class, 'integrations_subheader') and contains(., '{0}')]", text));

        //Buttons, Checkboxes, Tabs
        public static By GoBack => By.XPath("//button[contains(., 'Go Back')]");

        //Textfields
        public static By SearchIntegrations => By.Id(":r1a:");

        //Integration Cards
        public static By IntegrationCard => By.XPath("//div[contains(text(), 'CardContainer')]");   ////div[contains(text(), '{0}')]//following::div//descendant::button[@aria-label='Edit']
        public static By IntegrationName(string integrationName) => By.XPath(string.Format("//h5[contains(text(), '{0}')]", integrationName));
        public static By IntegrationType(string integrationType) => By.XPath(string.Format("//h6[contains(@class, 'infoCardHeader_subheader') and contains(text(), '{0}')]", integrationType));
        //integration could be the Name or Type
        public static By Add(string integration) => By.XPath(string.Format("//div[contains(text(), '{0}')]//following::div//descendant::button[contains(@class, 'integrations_add-integration-button')]", integration));
    }
}
