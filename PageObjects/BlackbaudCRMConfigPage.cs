namespace ci_automation_enterpriseportalui.PageObjects
{
    public static class BlackbaudCRMConfigPage
    {
        //Blackbaud CRM Configuration Page Elements

        //Titles, Labels                                                                                                
        public static By Tenant(string tenant) => By.XPath(string.Format("//div[contains(@class, 'left-header') and contains(., '{0}')]", tenant));
        public static By Title(string title) => By.XPath(string.Format("//p[contains(., '{0}')]", title));

        //Buttons, Checkboxes, Tabs
        public static By GoBack => By.XPath("//button[contains(., 'Go Back')]");

    }
}
