namespace ci_automation_enterpriseportalui.FunctionalTests
{
    public class LeftNavTests
    {
        public SeleniumActions Actions;
        public List<By> Present;
        public List<By> NotPresent;

        public LeftNavTests()
        {
            //SCENARIOS NEEDED
            //Correct icons display for each menu option
            //Nav directly to url for menu options that role/org does not have access to

            //NOTES:
            //all modules require launch darkly feature flag = on (not covered in automation)
            //then,
            //all modules require min role(for now):  super - admin
            //except for: role = admin displays dt admin / assign
            //org = ssb displays dt admin, client admin; org != ssb does not display dt admin, client admin
            // SSB Org: dbo.TenantOrgMapping = org_KlOYPcLaAzMYiwzx
        }
        public LeftNavTests(SeleniumActions actions)
        {
            Actions = actions;
        }
        public void LeftNavSuperAdminSSBOrg()
        {
            //verify Left Nav options for SuperAdmin user in an SSB Org

            Present = new List<By>() { LeftNavMenu.ProjectOverview, LeftNavMenu.ClientAdmin, LeftNavMenu.ClientAdminTenants, LeftNavMenu.ClientAdminIntegrations, LeftNavMenu.SegmentationAdmin, LeftNavMenu.Profile, LeftNavMenu.DataTagging, LeftNavMenu.DataTaggingAdmin, LeftNavMenu.DataTaggingAssignments };

            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.ClickElement(LeftNavMenu.OpenMenu, 20);
            Actions.ClickElement(LeftNavMenu.OpenClientAdminMenu, 20);
            Actions.ClickElement(LeftNavMenu.OpenDataTaggingMenu, 20);
            Actions.ElementsArePresent(Present).Should().BeTrue();
        }
        public void LeftNavSuperAdminNonSSBOrg()
        {
            //verify Left Nav options for SuperAdmin user in a Non SSB Org

            Present = new List<By>() { LeftNavMenu.ProjectOverview, LeftNavMenu.SegmentationAdmin, LeftNavMenu.Profile, LeftNavMenu.DataTagging, LeftNavMenu.DataTaggingAssignments };
            NotPresent = new List<By>() { LeftNavMenu.ClientAdmin, LeftNavMenu.ClientAdminTenants, LeftNavMenu.ClientAdminIntegrations, LeftNavMenu.DataTaggingAdmin };

            Actions.Login("uofqa_admin", "superadmin@affinaquest.com", "Test@123");
            Actions.ClickElement(LeftNavMenu.OpenMenu, 20);
            Actions.ClickElement(LeftNavMenu.OpenDataTaggingMenu, 20);
            Actions.ElementsArePresent(Present).Should().BeTrue();
            Actions.ElementsArePresent(NotPresent).Should().BeFalse();
        }
        public void LeftNavAdminSSBOrg()
        {
            //verify Left Nav options for Admin user in a SSB Org

            Present = new List<By>() { LeftNavMenu.ClientAdmin, LeftNavMenu.ClientAdminTenants, LeftNavMenu.ClientAdminIntegrations, LeftNavMenu.DataTagging, LeftNavMenu.DataTaggingAdmin, LeftNavMenu.DataTaggingAssignments };
            NotPresent = new List<By>() { LeftNavMenu.ProjectOverview, LeftNavMenu.SegmentationAdmin, LeftNavMenu.Profile };

            Actions.Login("ssb", "admin@affinaquest.com", "Test@123");
            Actions.ClickElement(LeftNavMenu.OpenMenu, 20);
            Actions.ClickElement(LeftNavMenu.OpenClientAdminMenu, 20);
            Actions.ClickElement(LeftNavMenu.OpenDataTaggingMenu, 20);
            Actions.ElementsArePresent(Present).Should().BeTrue();
            Actions.ElementsArePresent(NotPresent).Should().BeFalse();
        }
        public void LeftNavAdminNonSSBOrg()
        {
            //verify Left Nav options for Admin user in an Non SSB Org

            Present = new List<By>() { LeftNavMenu.DataTagging, LeftNavMenu.DataTaggingAssignments };
            NotPresent = new List<By>() { LeftNavMenu.ProjectOverview, LeftNavMenu.ClientAdmin, LeftNavMenu.ClientAdminTenants, LeftNavMenu.ClientAdminIntegrations, LeftNavMenu.SegmentationAdmin, LeftNavMenu.Profile, LeftNavMenu.DataTaggingAdmin };

            Actions.Login("uofqa_admin", "admin@affinaquest.com", "Test@123");
            Actions.ClickElement(LeftNavMenu.OpenMenu, 20);
            Actions.ClickElement(LeftNavMenu.OpenDataTaggingMenu, 20);
            Actions.ElementsArePresent(Present).Should().BeTrue();
            Actions.ElementsArePresent(NotPresent).Should().BeFalse();
        }
    }
}
