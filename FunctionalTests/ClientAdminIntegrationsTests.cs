namespace ci_automation_enterpriseportalui.FunctionalTests
{
    public class ClientAdminIntegrationsTests
    {
        public SeleniumActions Actions;
        //public LeftNavMenu LeftNav;
        //public ToastifyNotification Toast;
        //public ClientAdminIntegrationsPage CAdminIntegrations;
        //public List<By> Elements;

        public ClientAdminIntegrationsTests()
        {
            //SCENARIOS NEEDED
        }
        public ClientAdminIntegrationsTests(SeleniumActions actions)
        {
            Actions = actions;
        }
        //public void CAdminIntegrations_NavToIntegrations()
        //{
        //    //verify navigation to Client Admin Integrations
        //    Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
        //    Actions.NavLeftNav(LeftNavMenu.NavToClientAdminIntegrations);
        //    Thread.Sleep(2000);
        //    Actions.ElementIsPresent(ClientAdminIntegrationsPage.ClientAdminIntegrationsTitle).Should().BeTrue();
        //}
        //public void CAdminIntegrations_SearchByName()
        //{
        //    //verify searching by Name X filters to results containing Name X
        //    //requires min 3 char; not case sensitive; displays in desc order alphabetically by type
        //    Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
        //    Actions.NavLeftNav(LeftNavMenu.NavToClientAdminIntegrations);
        //    Thread.Sleep(2000);
        //    Actions.EnterText(ClientAdminIntegrationsPage.SearchIntegrations, "App");
        //    Actions.GetSearchFilterResults(ClientAdminIntegrationsPage.IntegrationName("App")).Should().BeEquivalentTo(new[] { "Appetize" });
        //}
        //public void CAdminIntegrations_SearchByType()
        //{
        //    //verify searching by Type X filters to results containing Type X
        //    //requires min 3 char; not case sensitive; displays in desc order alphabetically by type
        //    Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
        //    Actions.NavLeftNav(LeftNavMenu.NavToClientAdminIntegrations);
        //    Thread.Sleep(2000);
        //    Actions.EnterText(ClientAdminIntegrationsPage.SearchIntegrations, "CID");
        //    Actions.GetSearchFilterResults(ClientAdminIntegrationsPage.IntegrationType("CIDT")).Should().BeEquivalentTo("CIDT");
        //}
    }
}
