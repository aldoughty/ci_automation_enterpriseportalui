namespace ci_automation_enterpriseportalui.FunctionalTests
{
    public class ClientAdminTenantIntegrationsTests
    {
        public SeleniumActions Actions;
        public string CurrDateTime;  //This variable is used to keep the TenantKey unique because it currently 500s for duplicates
        public string[] IntegrationsPresent;

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
        public void CAdminTenantIntegrations_ValidateTitle()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
            Thread.Sleep(3000);
            Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "umich");
            Actions.ClickElement(ClientAdminTenantsPage.TenantIntegrations("umich"));
            Thread.Sleep(2000);
            Actions.ElementIsPresent(ClientAdminTenantIntegrationsPage.Title("University of Michigan - Athletics")).Should().BeTrue();
            Thread.Sleep(2000);
            Actions.ElementIsPresent(ClientAdminTenantIntegrationsPage.StatusChip("Adobe", "Not Configured")).Should().BeTrue();
        }
        public void CAdminTenantIntegrations_BrowserBack()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
            Thread.Sleep(2000);
            Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "sooners");
            Actions.ClickElement(ClientAdminTenantsPage.TenantIntegrations("sooners"));
            Actions.BrowserBack();
            Actions.ElementIsPresent(ClientAdminTenantsPage.ClientAdminTenantsTitle).Should().BeTrue();
        }
        public void CAdminTenantIntegrations_Close()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
            Thread.Sleep(2000);
            Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "sooners");
            Actions.ClickElement(ClientAdminTenantsPage.TenantIntegrations("sooners"));
            Actions.ClickElement(ClientAdminTenantIntegrationsPage.CloseButton);
            Actions.ElementIsPresent(ClientAdminTenantsPage.ClientAdminTenantsTitle).Should().BeTrue();
        }
        public void CAdminTenantIntegrations_NavToEdit()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
            Thread.Sleep(2000);
            Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "sooners");
            Actions.ClickElement(ClientAdminTenantsPage.TenantIntegrations("sooners"));
            Actions.ClickElement(ClientAdminTenantIntegrationsPage.EditTab);
            Thread.Sleep(2000);
            Actions.ElementIsPresent(EditTenantPage.EditTenantTitle).Should().BeTrue();
        }
        public void CAdminTenantIntegrations_Add_GoBack()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
            Thread.Sleep(2000);
            Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "sooners");
            Actions.ClickElement(ClientAdminTenantsPage.TenantIntegrations("sooners"));
            Thread.Sleep(2000);
            Actions.ClickElement(ClientAdminTenantIntegrationsPage.AddIntegrationButton);
            Thread.Sleep(2000);
            Actions.ClickElement(ClientAdminTenantAddIntegrationPage.GoBack);
        }
        public void CAdminTenantIntegrations_Add_SearchByName()
        {
            //verify searching by Name X filters to results containing Name X
            //requires min 3 char; not case sensitive
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
            Thread.Sleep(2000);
            Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "sooners");
            Actions.ClickElement(ClientAdminTenantsPage.TenantIntegrations("sooners"));
            Thread.Sleep(2000);
            Actions.ClickElement(ClientAdminTenantIntegrationsPage.AddIntegrationButton);
            Thread.Sleep(2000);
            Actions.EnterText(ClientAdminTenantAddIntegrationPage.SearchIntegrations, "ent");
            Actions.GetSearchFilterResults(ClientAdminTenantAddIntegrationPage.IntegrationName("Eventbrite")).Should().BeEquivalentTo(new[] { "Eventbrite" });
        }
        public void CAdminTenantIntegrations_Add_SearchByType()
        {
            //verify searching by Type X filters to results containing Type X
            //requires min 3 char; not case sensitive
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
            Thread.Sleep(2000);
            Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "sooners");
            Actions.ClickElement(ClientAdminTenantsPage.TenantIntegrations("sooners"));
            Thread.Sleep(2000);
            Actions.ClickElement(ClientAdminTenantIntegrationsPage.AddIntegrationButton);
            Thread.Sleep(2000);
            Actions.EnterText(ClientAdminTenantAddIntegrationPage.SearchIntegrations, "SFTP");
            Actions.GetSearchFilterResults(ClientAdminTenantAddIntegrationPage.IntegrationType("SFTP")).Should().BeEquivalentTo("SFTP");
        }
        //public void CAdminTenantIntegrations_Add()
        //{
        //    //Success banner displays after successful add and can be closed manually.
        //    //Add Integrations shows ALL Integrations but disables those that have been added.  Displays Added in place of Add.

        //    Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
        //    Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
        //    Thread.Sleep(2000);
        //    Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "huskers");
        //    Actions.ClickElement(ClientAdminTenantsPage.TenantIntegrations("huskers"));
        //    Thread.Sleep(2000);
        //    Actions.ClickElement(ClientAdminTenantIntegrationsPage.AddIntegrationButton);
        //    Thread.Sleep(2000);
        //    Actions.EnterText(ClientAdminTenantAddIntegrationPage.SearchIntegrations, "SFTP");
        //    Thread.Sleep(2000);
        //    Actions.ClickElement(ClientAdminTenantAddIntegrationPage.Add("Adobe"));
        //    Thread.Sleep(2000);
        //    Actions.ElementIsPresent(ClientAdminTenantIntegrationsPage.AlertBanner("Integration Added Successfully")).Should().BeTrue();
        //    Actions.ClickElement(ClientAdminTenantIntegrationsPage.AlertBannerClose);
        //    Actions.ClickElement(ClientAdminTenantIntegrationsPage.AddIntegrationButton);
        //    Thread.Sleep(2000);
        //    Actions.EnterText(ClientAdminTenantAddIntegrationPage.SearchIntegrations, "SFTP");
        //    Thread.Sleep(2000);
        //    Actions.ElementIsPresent(ClientAdminTenantAddIntegrationPage.AddedStatus("Adobe", "Added")).Should().BeTrue();
        //}
        public void CAdminTenantIntegrations_AddAndConfigureAdobeSFTP()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
            Thread.Sleep(2000);
            Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "huskers");
            Actions.ClickElement(ClientAdminTenantsPage.TenantIntegrations("huskers"));
            Thread.Sleep(2000);
            Actions.ClickElement(ClientAdminTenantIntegrationsPage.AddIntegrationButton);
            Thread.Sleep(2000);
            Actions.EnterText(ClientAdminTenantAddIntegrationPage.SearchIntegrations, "SFTP");
            Thread.Sleep(2000);
            Actions.ClickElement(ClientAdminTenantAddIntegrationPage.Add("Adobe"));
            Thread.Sleep(2000);
            Actions.ClickElement(ClientAdminTenantIntegrationsPage.Configure("Adobe"));
            Thread.Sleep(2000);
            Actions.EnterText(ConfigureSftpPage.SearchSftpConnections, "ssb_user");
            Thread.Sleep(2000);
            Actions.ClickElement(ConfigureSftpPage.FirstRow);
            Thread.Sleep(2000);
            Actions.ClickElement(ConfigureSftpPage.Select("c95b2e16-a6dd-4647-aea0-027b6eef0ed5"));
            Thread.Sleep(2000);
            Actions.EnterText(ConfigureSftpPage.SourceDirectory, "Source Directory");
            Actions.EnterText(ConfigureSftpPage.ArchiveDirectory, "Archive Directory");
            Actions.EnterText(ConfigureSftpPage.SourceFilename, "Source Filename");
            Actions.EnterText(ConfigureSftpPage.BlobDestination, "Blob Destination");
            Actions.EscapeFocus();
            Actions.ClickElement(ConfigureSftpPage.Save);
            Thread.Sleep(2000);
        }
        public void CAdminTenantIntegrations_AddAndConfigureEloquaSFTP()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
            Thread.Sleep(2000);
            Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "huskers");
            Actions.ClickElement(ClientAdminTenantsPage.TenantIntegrations("huskers"));
            Thread.Sleep(2000);
            Actions.ClickElement(ClientAdminTenantIntegrationsPage.AddIntegrationButton);
            Thread.Sleep(2000);
            Actions.EnterText(ClientAdminTenantAddIntegrationPage.SearchIntegrations, "SFTP");
            Thread.Sleep(2000);
            Actions.ClickElement(ClientAdminTenantAddIntegrationPage.Add("Eloqua"));
            Thread.Sleep(2000);
            Actions.ClickElement(ClientAdminTenantIntegrationsPage.Configure("Eloqua"));
            Thread.Sleep(2000);
            Actions.EnterText(ConfigureSftpPage.SearchSftpConnections, "ssb_user");
            Thread.Sleep(2000);
            Actions.ClickElement(ConfigureSftpPage.FirstRow);
            Thread.Sleep(2000);
            Actions.ClickElement(ConfigureSftpPage.Select("c95b2e16-a6dd-4647-aea0-027b6eef0ed5"));
            Thread.Sleep(2000);
            Actions.EnterText(ConfigureSftpPage.SourceDirectory, "Source Directory");
            Actions.EnterText(ConfigureSftpPage.ArchiveDirectory, "Archive Directory");
            Actions.EnterText(ConfigureSftpPage.SourceFilename, "Source Filename");
            Actions.EnterText(ConfigureSftpPage.BlobDestination, "Blob Destination");
            Actions.EscapeFocus();
            Actions.ClickElement(ConfigureSftpPage.Save);
            Thread.Sleep(2000);
        }
        public void CAdminTenantIntegrations_AddAndConfigureFanaticsSFTP()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
            Thread.Sleep(2000);
            Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "huskers");
            Actions.ClickElement(ClientAdminTenantsPage.TenantIntegrations("huskers"));
            Thread.Sleep(2000);
            Actions.ClickElement(ClientAdminTenantIntegrationsPage.AddIntegrationButton);
            Thread.Sleep(2000);
            Actions.EnterText(ClientAdminTenantAddIntegrationPage.SearchIntegrations, "SFTP");
            Thread.Sleep(2000);
            Actions.ClickElement(ClientAdminTenantAddIntegrationPage.Add("Fanatics"));
            Thread.Sleep(2000);
            Actions.ClickElement(ClientAdminTenantIntegrationsPage.Configure("Fanatics"));
            Thread.Sleep(2000);
            Actions.EnterText(ConfigureSftpPage.SearchSftpConnections, "ssb_user");
            Thread.Sleep(2000);
            Actions.ClickElement(ConfigureSftpPage.FirstRow);
            Thread.Sleep(2000);
            Actions.ClickElement(ConfigureSftpPage.Select("c95b2e16-a6dd-4647-aea0-027b6eef0ed5"));
            Thread.Sleep(2000);
            Actions.EnterText(ConfigureSftpPage.SourceDirectory, "Source Directory");
            Actions.EnterText(ConfigureSftpPage.ArchiveDirectory, "Archive Directory");
            Actions.EnterText(ConfigureSftpPage.SourceFilename, "Source Filename");
            Actions.EnterText(ConfigureSftpPage.BlobDestination, "Blob Destination");
            Actions.EscapeFocus();
            Actions.ClickElement(ConfigureSftpPage.Save);
            Thread.Sleep(2000);
        }
        public void CAdminTenantIntegrations_AddAndConfigurePaciolanSFTP()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
            Thread.Sleep(2000);
            Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "huskers");
            Actions.ClickElement(ClientAdminTenantsPage.TenantIntegrations("huskers"));
            Thread.Sleep(2000);
            Actions.ClickElement(ClientAdminTenantIntegrationsPage.AddIntegrationButton);
            Thread.Sleep(2000);
            Actions.EnterText(ClientAdminTenantAddIntegrationPage.SearchIntegrations, "SFTP");
            Thread.Sleep(2000);
            Actions.ClickElement(ClientAdminTenantAddIntegrationPage.Add("Paciolan"));
            Thread.Sleep(2000);
            Actions.ClickElement(ClientAdminTenantIntegrationsPage.Configure("Paciolan"));
            Thread.Sleep(2000);
            Actions.EnterText(ConfigureSftpPage.SearchSftpConnections, "ssb_user");
            Thread.Sleep(2000);
            Actions.ClickElement(ConfigureSftpPage.FirstRow);
            Thread.Sleep(2000);
            Actions.ClickElement(ConfigureSftpPage.Select("c95b2e16-a6dd-4647-aea0-027b6eef0ed5"));
            Thread.Sleep(2000);
            Actions.EnterText(ConfigureSftpPage.SourceDirectory, "Source Directory");
            Actions.EnterText(ConfigureSftpPage.ArchiveDirectory, "Archive Directory");
            Actions.EnterText(ConfigureSftpPage.SourceFilename, "Source Filename");
            Actions.EnterText(ConfigureSftpPage.BlobDestination, "Blob Destination");
            Actions.EscapeFocus();
            Actions.ClickElement(ConfigureSftpPage.Save);
            Thread.Sleep(2000);
        }
    }
}
