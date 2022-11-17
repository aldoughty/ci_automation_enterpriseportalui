namespace ci_automation_enterpriseportalui.PageObjects
{
    public static class WelcomePage
    {
        //Welcome Page Elements
        public static By Org => By.Id("organizationName");
        public static By Username => By.Id("username");
        public static By Password => By.Id("password");
        public static By Continue => By.XPath("//button[@name='action'][contains(text(), 'Continue')]");
        public static By LogOut => By.Id("logout-button");
    }
}