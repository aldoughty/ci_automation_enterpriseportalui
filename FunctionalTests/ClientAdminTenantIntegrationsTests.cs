namespace ci_automation_enterpriseportalui.FunctionalTests
{
    public class ClientAdminTenantIntegrationsTests
    {
        public SeleniumActions Actions;
        public Dictionary<string, object> TestClassParameters;
        public List<By> Elements;
        public string CurrDateTime;  //This variable is used to keep the TenantKey unique because it currently 500s for duplicates

        public ClientAdminTenantIntegrationsTests()
        {
            //SCENARIOS NEEDED
            //
        }
        public ClientAdminTenantIntegrationsTests(SeleniumActions actions)
        {
            Actions = actions;
            CurrDateTime = DateTime.Now.ToString("MMddyyyyHHmmss");
        }
        //public void CAdminTenantIntegrations_ValidateTitle()
        //{
        //    Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
        //    Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
        //    Thread.Sleep(2000);
        //    Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "westminster");
        //    Actions.ClickElement(ClientAdminTenantsPage.TenantIntegrations("westminster"));
        //    Thread.Sleep(2000);
        //    Actions.ElementIsPresent(ClientAdminTenantIntegrationsPage.Title("The Westminster Schools")).Should().BeTrue();
        //    Thread.Sleep(2000);
        //    Actions.ElementIsPresent(ClientAdminTenantIntegrationsPage.StatusChip("Appetize", "Active")).Should().BeTrue();
        //}
        //public void CAdminTenantIntegrations_BrowserBack()
        //{
        //    Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
        //    Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
        //    Thread.Sleep(2000);
        //    Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "sooners");
        //    Actions.ClickElement(ClientAdminTenantsPage.TenantIntegrations("sooners"));
        //    Actions.BrowserBack();
        //    Actions.ElementIsPresent(ClientAdminTenantsPage.ClientAdminTenantsTitle).Should().BeTrue();
        //}
        //public void CAdminTenantIntegrations_Close()
        //{
        //    Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
        //    Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
        //    Thread.Sleep(2000);
        //    Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "sooners");
        //    Actions.ClickElement(ClientAdminTenantsPage.TenantIntegrations("sooners"));
        //    Actions.ClickElement(ClientAdminTenantIntegrationsPage.CloseButton);
        //    Actions.ElementIsPresent(ClientAdminTenantsPage.ClientAdminTenantsTitle).Should().BeTrue();
        //}
        //public void CAdminTenantIntegrations_NavToEdit()
        //{
        //    Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
        //    Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
        //    Thread.Sleep(2000);
        //    Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "sooners");
        //    Actions.ClickElement(ClientAdminTenantsPage.TenantIntegrations("sooners"));
        //    Actions.ClickElement(ClientAdminTenantIntegrationsPage.EditTab);
        //    Thread.Sleep(2000);
        //    Actions.ElementIsPresent(EditTenantPage.EditTenantTitle).Should().BeTrue();
        //}
        ////public void CAdminTenantIntegrations_Add()
        ////{
        ////    Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
        ////    Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
        ////    Thread.Sleep(2000);
        ////    Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "sooners");
        ////    Actions.ClickElement(ClientAdminTenantsPage.TenantIntegrations("sooners"));
        ////    Thread.Sleep(2000);
        ////    Actions.ClickElement(ClientAdminTenantIntegrationsPage.AddIntegrationButton);
        ////    Thread.Sleep(2000);
        ////    Actions.EnterText(ClientAdminTenantAddIntegrationPage.SearchIntegrations, "BlackBaud");
        ////    Actions.ClickElement(ClientAdminTenantAddIntegrationPage.Add("Stitch"));
        ////    Actions.ElementIsPresent(BlackbaudCRMConfigPage.Title("Blackbaud CRM Configuration Page")).Should().BeTrue();
        ////}
        //public void CAdminTenantIntegrations_Add_GoBack()
        //{
        //    Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
        //    Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
        //    Thread.Sleep(2000);
        //    Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "sooners");
        //    Actions.ClickElement(ClientAdminTenantsPage.TenantIntegrations("sooners"));
        //    Thread.Sleep(2000);
        //    Actions.ClickElement(ClientAdminTenantIntegrationsPage.AddIntegrationButton);
        //    Thread.Sleep(2000);
        //    Actions.ClickElement(ClientAdminTenantAddIntegrationPage.GoBack);
        //}
        ////public void CAdminTenantIntegrations_Add_SearchByName()
        ////{
        ////    //verify searching by Name X filters to results containing Name X
        ////    //requires min 3 char; not case sensitive; displays in desc order alphabetically by type
        ////    Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
        ////    Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
        ////    Thread.Sleep(2000);
        ////    Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "sooners");
        ////    Actions.ClickElement(ClientAdminTenantsPage.TenantIntegrations("sooners"));
        ////    Thread.Sleep(2000);
        ////    Actions.ClickElement(ClientAdminTenantIntegrationsPage.AddIntegrationButton);
        ////    Thread.Sleep(2000);
        ////    Actions.EnterText(ClientAdminTenantAddIntegrationPage.SearchIntegrations, "Black");
        ////    Actions.GetSearchFilterResults(ClientAdminTenantAddIntegrationPage.IntegrationName("Black")).Should().BeEquivalentTo(new[] { "BlackBaud", "Blackbaud CRM" });
        ////}
        ////public void CAdminTenantIntegrations_Add_SearchByType()
        ////{
        ////    //verify searching by Type X filters to results containing Type X
        ////    //requires min 3 char; not case sensitive; displays in desc order alphabetically by type
        ////    Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
        ////    Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
        ////    Thread.Sleep(2000);
        ////    Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "sooners");
        ////    Actions.ClickElement(ClientAdminTenantsPage.TenantIntegrations("sooners"));
        ////    Thread.Sleep(2000);
        ////    Actions.ClickElement(ClientAdminTenantIntegrationsPage.AddIntegrationButton);
        ////    Thread.Sleep(2000);
        ////    Actions.EnterText(ClientAdminTenantAddIntegrationPage.SearchIntegrations, "Stitch");
        ////    Actions.GetSearchFilterResults(ClientAdminTenantAddIntegrationPage.IntegrationType("Stitch")).Should().BeEquivalentTo("Stitch");
        ////}
    }
}
