namespace ci_automation_enterpriseportalui.PageObjects
{
    public static class ClientAdminTenantsPage
    {
        //Client Admin Tenants Page Elements

        //Titles, Labels
        public static By ClientAdminTenantsTitle => By.Id("client-admin-title");

        //Buttons, Checkboxes
        public static By RefreshTable => By.XPath("/html/body/div[1]/div/div/div[2]/div[1]/div[1]/div/button"); ///html/body/div[1]/div/div/div[2]/div[1]/div/div/div[2]/div/div/button 
        public static By AddTenant => By.Id("add-tenant-button");
        public static By ShowInactive => By.Id("show-inactive-checkbox-control-input");
        //tenantValue could be the TenantName or TenantKey bc they're both in that row
        public static By EditTenant(string tenantValue) => By.XPath(string.Format("//div[contains(text(), '{0}')]//following::div//descendant::button[@aria-label='Edit']", tenantValue));
        public static By TenantIntegrations(string tenantValue) => By.XPath(string.Format("//div[contains(text(), '{0}')]//following::div//descendant::button[@aria-label='Integrations']", tenantValue));

        //Textfields
        public static By SearchForTenant => By.Id("search-input");

        //Tooltips
        //public By 

        //Results Rows Summary
        public static By FirstRowOfResults => By.Id("ag-8-first-row");
        public static By LastRowOfResults => By.Id("ag-8-last-row");
        public static By TotalRowsOfResults => By.Id("ag-8-row-count");

        //Paging Summary
        public static By FirstPage => By.XPath("//div[@aria-label='First Page']");
        public static By PreviousPage => By.XPath("//div[@aria-label='Previous Page']");
        public static By NextPage => By.XPath("//div[@aria-label='Next Page']");
        public static By LastPage => By.XPath("//div[@aria-label='Last Page']");

    }
}
