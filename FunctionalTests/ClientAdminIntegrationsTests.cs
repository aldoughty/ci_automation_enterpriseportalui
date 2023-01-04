namespace ci_automation_enterpriseportalui.FunctionalTests
{
    public class ClientAdminIntegrationsTests
    {
        public SeleniumActions Actions;

        public ClientAdminIntegrationsTests()
        {
            //SCENARIOS NEEDED
        }
        public ClientAdminIntegrationsTests(SeleniumActions actions)
        {
            Actions = actions;
        }
        public void CAdminIntegrations_NavToIntegrations()
        {
            //verify navigation to Client Admin Integrations
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminIntegrations);
            Thread.Sleep(2000);
            Actions.ElementIsPresent(ClientAdminIntegrationsPage.ClientAdminIntegrationsTitle).Should().BeTrue();
        }
        public void CAdminIntegrations_ValidateAlphabeticalOrder()
        {
            //verify cards display in desc order alphabetically by name
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminIntegrations);
            Thread.Sleep(2000);
            Actions.ValidateElementTextListAlphabeticalOrder(ClientAdminIntegrationsPage.IntegrationName()).Should().BeTrue();
        }
        public void CAdminIntegrations_SearchByName()
        {
            //verify searching by Name X filters to results containing Name X
            //requires min 3 char; not case sensitive; displays in desc order alphabetically by name
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminIntegrations);
            Thread.Sleep(2000);
            Actions.EnterText(ClientAdminIntegrationsPage.SearchIntegrations, "elo");
            Actions.GetSearchFilterResults(ClientAdminIntegrationsPage.IntegrationName()).Should().BeEquivalentTo("Eloqua");
            Actions.GetSearchFilterResults(ClientAdminIntegrationsPage.IntegrationType()).Should().BeEquivalentTo(new[] { "SFTP", "CIDT" });
        }
        public void CAdminIntegrations_SearchByType()
        {
            //verify searching by Type X filters to results containing Type X
            //requires min 3 char; not case sensitive; displays in desc order alphabetically by name
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminIntegrations);
            Thread.Sleep(2000);

            Actions.EnterText(ClientAdminIntegrationsPage.SearchIntegrations, "CID");
            Actions.GetSearchFilterResults(ClientAdminIntegrationsPage.IntegrationType()).Should().BeEquivalentTo("CIDT");
            Actions.GetSearchFilterResults(ClientAdminIntegrationsPage.IntegrationName()).Should().BeEquivalentTo(new[] { "Eventbrite", "Eloqua", "Appetize", "Dyehard", "Firebase", "TradableBits" });
        }
        public void CAdminIntegrations_ClickViewTenants()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminIntegrations);
            Thread.Sleep(2000);
            Actions.EnterText(ClientAdminIntegrationsPage.SearchIntegrations, "cid");
            Actions.ClickElement(ClientAdminIntegrationsPage.ViewTenants("Firebase"));
        }
    }
}
