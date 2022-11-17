namespace ci_automation_enterpriseportalui.PageObjects
{
    internal static class EnterOrgPage
    {
        //Enter Org Page Elements
        public static By Org => By.Id("organizationName");
        public static By Continue => By.XPath("//button[@name='action'][contains(text(), 'Continue')]");
    }
}
