namespace ci_automation_enterpriseportalui.PageObjects
{
    public static class LeftNavMenu
    {
        //LeftNavMenu Elements
        public static By OpenMenu => By.CssSelector("svg[data-testid='MenuIcon']");
        public static By ProjectOverview => By.Id("ProjectOverview");
        public static By ClientAdmin => By.Id("ClientAdmin");
        public static By OpenClientAdminMenu => By.Id("ClientAdmin-nav-menu-expand-more");
        public static By CloseClientAdminMenu => By.Id("ClientAdmin-nav-menu-expand-less");
        public static By ClientAdminTenants => By.Id("ClientAdmin-Tenants");
        public static By ClientAdminIntegrations => By.Id("ClientAdmin-Integrations");
        public static By SegmentationAdmin => By.Id("SegmentationAdmin");
        public static By Profile => By.Id("Profile");
        public static By DataTagging => By.Id("DataTagging");
        public static By OpenDataTaggingMenu => By.Id("DataTagging-nav-menu-expand-more");
        public static By CloseDataTaggingMenu => By.Id("DataTagging-nav-menu-expand-less");
        public static By DataTaggingAdmin => By.Id("DataTagging-Administration");
        public static By DataTaggingAssignments => By.Id("DataTagging-Assignments");
        public static By LeftNavMenuItems => By.CssSelector("div[class^=\"MuiListItemText\"] span");
        public static By LeftNavDataTaggingMenuItems => By.CssSelector("li[id^='DataTagging-'] div span");

        //Left Nav Navigation
        public static List<By> NavToClientAdminTenants { get { return new List<By>() { ClientAdmin, ClientAdminTenants }; } }
        public static List<By> NavToClientAdminIntegrations { get { return new List<By>() { ClientAdmin, ClientAdminIntegrations }; } }
        public static List<By> NavToDataTaggingAdmin { get { return new List<By>() { DataTagging, DataTaggingAdmin }; } }
        public static List<By> NavToDataTaggingAssignments { get { return new List<By>() { DataTagging, DataTaggingAssignments }; } }

    }
}