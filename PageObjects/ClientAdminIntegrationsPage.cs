namespace ci_automation_enterpriseportalui.PageObjects
{
    public static class ClientAdminIntegrationsPage
    {
        //Client Admin Tenants Page Elements

        //Titles, Labels
        public static By ClientAdminIntegrationsTitle => By.XPath("//*[@id=\"main-container\"]/div/div[1]/h5");

        //Buttons, Checkboxes


        //Textfields
        public static By SearchIntegrations => By.Id(":r1:");

        //Integration Cards
        public static By IntegrationCard => By.XPath("//div[contains(text(), 'CardContainer')]");
        public static By IntegrationName(string integrationName) => By.XPath(string.Format("//h5[contains(@class, 'h5') and contains(text(), '{0}')]", integrationName));
        public static By IntegrationType(string integrationType) => By.XPath(string.Format("//h6[contains(@class, 'infoCardHeader_subheader') and contains(text(), '{0}')]", integrationType));
        public static By IntegrationName() => By.XPath(string.Format("//div[contains(@class, 'integrations_cardsContainer')]//descendant::h5[contains(@class, 'h5')]"));
        public static By IntegrationType() => By.XPath(string.Format("//div[contains(@class, 'integrations_cardsContainer')]//descendant::h6[contains(@class, 'infoCardHeader_subheader')]"));
        //integration could be the Name or Type
        public static By ViewTenants(string integrationName) => By.XPath(string.Format("//div[contains(@class, 'integrations_cardsContainer')]//descendant::h5[contains(@class, 'h5') and contains(text(), '{0}')]//following::button[contains(text(), 'View Tenants')]", integrationName));
    }
}