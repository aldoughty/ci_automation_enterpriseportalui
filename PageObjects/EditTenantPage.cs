namespace ci_automation_enterpriseportalui.PageObjects
{
    public static class EditTenantPage
    {
        //Edit Tenant Page Elements

        //Titles, Labels
        public static By EditTenantTitle => By.Id("client-admin-edit-tenant-title");

        //Buttons, Links, Swtiches, Tabs
        public static By BackToClientAdmin => By.Id("client-admin-tenant-back-button");
        public static By Update => By.Id("client-admin-tenant-save-button");
        public static By ActiveSwitch => By.XPath("//*[@id='active-switch-control-label']/span[1]/span[1]");
        public static By CloseButton => By.XPath("//button[contains(@class, 'close-button')]");
        public static By IntegrationsTab => By.Id("tab-integrations");
        public static By EditTab => By.Id("tab-edit");

        //Textfields
        public static By TenantName => By.Id("name-input");
        public static By TenantKey => By.Id("key-input");

        //Textfield Values
        public static By TenantNameValue(string value) => By.XPath(string.Format("//input[@id='name-input' and @value='{0}')]", value));
        public static By TenantKeyValue(string value) => By.XPath(string.Format("//input[@id='tenantKeyinput' and @value='{0}')]", value));

    }
}
