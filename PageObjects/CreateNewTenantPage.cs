namespace ci_automation_enterpriseportalui.PageObjects
{
    public static class CreateNewTenantPage
    {
        //Create New Tenant Page Elements

        //Titles, Labels
        public static By CreateNewTenantTitle => By.Id("client-admin-new-tenant-title");

        //Buttons, Links
        public static By Cancel => By.Id("client-admin-tenant-cancel-button");
        public static By Create => By.Id("client-admin-tenant-save-button");

        //Textfields
        public static By TenantName => By.Id("name-input");
        public static By TenantKey => By.Id("key-input");

        //Validation Errors
        public static By TenantNameError => By.Id("name_validation_errors");
        public static By TenantKeyError => By.Id("key_validation_errors");

    }
}
