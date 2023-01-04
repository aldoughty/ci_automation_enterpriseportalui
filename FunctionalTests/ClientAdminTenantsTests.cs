namespace ci_automation_enterpriseportalui.FunctionalTests
{
    public class ClientAdminTenantsTests
    {
        public SeleniumActions Actions;
        public List<By> Elements;
        public string CurrDateTime;  //This variable is used to keep the TenantKey unique because it currently 500s for duplicates

        public ClientAdminTenantsTests()
        {
            //SCENARIOS NEEDED
            //
        }
        public ClientAdminTenantsTests(SeleniumActions actions)
        {
            Actions = actions;
            CurrDateTime = DateTime.Now.ToString("MMddyyHHmmss");
        }
        public void ClientAdminTenantsPage_CreateNewTenantPage_ValidateRequiredFields()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
            Actions.ClickElement(ClientAdminTenantsPage.AddTenant);

            //Validate required fields:  TenantName, TenantKey
            //Auth0 Requirements for TenantKey:  Not Empty/Required
            Actions.ClickElement(CreateNewTenantPage.Create);
            Actions.GetElementText(ToastifyNotification.ToastNotification("error")).Should().BeEquivalentTo("Please Correct Validation Errors");
            Actions.GetElementCssValue(ToastifyNotification.ToastNotification("error"), 10, "background-color").Should().BeEquivalentTo("rgba(176, 0, 32, 1)");  //red
            Actions.GetElementText(CreateNewTenantPage.TenantNameError).Should().BeEquivalentTo("Tenant Name is required");
            Actions.GetElementCssValue(CreateNewTenantPage.TenantNameError, 10, "color").Should().BeEquivalentTo("rgba(176, 0, 32, 1)"); //red
            Actions.GetElementText(CreateNewTenantPage.TenantKeyError).Should().BeEquivalentTo("Tenant Key is required");
            Actions.GetElementCssValue(CreateNewTenantPage.TenantKeyError, 10, "color").Should().BeEquivalentTo("rgba(176, 0, 32, 1)"); //red
        }
        public void ClientAdminTenantsPage_CreateNewTenantPage_ValidateFieldMinimums()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
            Actions.ClickElement(ClientAdminTenantsPage.AddTenant);

            //Validate Min:  TenantName 3, TenantKey 3
            //Auth0 Requirements for TenantKey:  Min 3 Char
            Thread.Sleep(2000);
            Actions.EnterText(CreateNewTenantPage.TenantName, "AB");
            Actions.EnterText(CreateNewTenantPage.TenantKey, "CD");
            Actions.ClickElement(CreateNewTenantPage.Create);
            Actions.GetElementText(ToastifyNotification.ToastNotification("error")).Should().BeEquivalentTo("Please Correct Validation Errors");
            Actions.GetElementCssValue(ToastifyNotification.ToastNotification("error"), 10, "background-color").Should().BeEquivalentTo("rgba(176, 0, 32, 1)");  //red
            Actions.ClickElement(ToastifyNotification.CloseToast);
            Actions.GetElementText(CreateNewTenantPage.TenantNameError).Should().BeEquivalentTo("Tenant Name must be between 3 and 100 characters long");
            Actions.GetElementCssValue(CreateNewTenantPage.TenantNameError, 10, "color").Should().BeEquivalentTo("rgba(176, 0, 32, 1)"); //red
            Actions.GetElementText(CreateNewTenantPage.TenantKeyError).Should().BeEquivalentTo("Tenant Key must be between 3 and 15 characters long");
            Actions.GetElementCssValue(CreateNewTenantPage.TenantKeyError, 10, "color").Should().BeEquivalentTo("rgba(176, 0, 32, 1)"); //red
            Actions.ClearText(CreateNewTenantPage.TenantName);
            Actions.ClearText(CreateNewTenantPage.TenantKey);
        }
        public void ClientAdminTenantsPage_CreateNewTenantPage_ValidateTenantKeyConvertsToAllLower()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
            Actions.ClickElement(ClientAdminTenantsPage.AddTenant);

            Thread.Sleep(2000);
            Actions.EnterText(CreateNewTenantPage.TenantKey, "TESTING123");
            Actions.ClickElement(CreateNewTenantPage.Create);
            Actions.GetElementText(CreateNewTenantPage.TenantKey).Should().BeLowerCased();
            Actions.ClearText(CreateNewTenantPage.TenantKey);
            Thread.Sleep(2000);
            Actions.EnterText(CreateNewTenantPage.TenantKey, "TeStInG123");
            Actions.ClickElement(CreateNewTenantPage.Create);
            Actions.GetElementText(CreateNewTenantPage.TenantKey).Should().BeLowerCased();
            Actions.ClearText(CreateNewTenantPage.TenantKey);
            Thread.Sleep(2000);
            Actions.EnterText(CreateNewTenantPage.TenantKey, "tEsTiNg123");
            Actions.ClickElement(CreateNewTenantPage.Create);
            Actions.GetElementText(CreateNewTenantPage.TenantKey).Should().BeLowerCased();
            Actions.ClearText(CreateNewTenantPage.TenantKey);
            Thread.Sleep(2000);
            Actions.EnterText(CreateNewTenantPage.TenantKey, "testing123");
            Actions.ClickElement(CreateNewTenantPage.Create);
            Actions.GetElementText(CreateNewTenantPage.TenantKey).Should().BeLowerCased();
            Actions.ClearText(CreateNewTenantPage.TenantKey);
        }
        public void ClientAdminTenantsPage_CreateNewTenantPage_ValidateFieldMaximums()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
            Actions.ClickElement(ClientAdminTenantsPage.AddTenant);

            //Validate Max:  TenantName 100, TenantKey 50
            //Auth0 Requirements for TenantKey:  Max 50 Char
            Thread.Sleep(2000);
            Actions.EnterText(CreateNewTenantPage.TenantName, "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVW");
            Actions.EnterText(CreateNewTenantPage.TenantKey, "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXY");
            Actions.ClickElement(CreateNewTenantPage.Create);
            Actions.GetElementText(ToastifyNotification.ToastNotification("error")).Should().BeEquivalentTo("Please Correct Validation Errors");
            Actions.GetElementCssValue(ToastifyNotification.ToastNotification("error"), 10, "background-color").Should().BeEquivalentTo("rgba(176, 0, 32, 1)");  //red
            Actions.ClickElement(ToastifyNotification.CloseToast);
            Actions.GetElementText(CreateNewTenantPage.TenantNameError).Should().BeEquivalentTo("Tenant Name must be between 3 and 100 characters long");
            Actions.GetElementCssValue(CreateNewTenantPage.TenantNameError, 10, "color").Should().BeEquivalentTo("rgba(176, 0, 32, 1)"); //red
            Actions.GetElementText(CreateNewTenantPage.TenantKeyError).Should().BeEquivalentTo("Tenant Key must be between 3 and 15 characters long");
            Actions.GetElementCssValue(CreateNewTenantPage.TenantKeyError, 10, "color").Should().BeEquivalentTo("rgba(176, 0, 32, 1)"); //red
            Actions.ClearText(CreateNewTenantPage.TenantName);
            Actions.ClearText(CreateNewTenantPage.TenantKey);
        }
        public void ClientAdminTenantsPage_CreateNewTenantPage_ValidateFieldAllowableCharacters()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
            Actions.ClickElement(ClientAdminTenantsPage.AddTenant);

            //Validate Allowable Characters:  TenantKey No Special or Spaces, must not start with a number
            //Auth0 Requirements for TenantKey:  Upper/Lower Alpha, Numeric, dash(-) and underscore(_); No spaces
            Thread.Sleep(2000);
            Actions.EnterText(CreateNewTenantPage.TenantKey, "ABC 123 !@#");
            Actions.ClickElement(CreateNewTenantPage.Create);
            Actions.GetElementText(ToastifyNotification.ToastNotification("error")).Should().BeEquivalentTo("Please Correct Validation Errors");
            Actions.GetElementCssValue(ToastifyNotification.ToastNotification("error"), 10, "background-color").Should().BeEquivalentTo("rgba(176, 0, 32, 1)");  //red
            Actions.ClickElement(ToastifyNotification.CloseToast);
            Actions.GetElementText(CreateNewTenantPage.TenantKeyError).Should().BeEquivalentTo("Tenant Key cannot contain spaces");
            Actions.GetElementCssValue(CreateNewTenantPage.TenantKeyError, 10, "color").Should().BeEquivalentTo("rgba(176, 0, 32, 1)"); //red
            Actions.ClearText(CreateNewTenantPage.TenantKey);
            Actions.EnterText(CreateNewTenantPage.TenantKey, "ABC123!@#");
            Actions.ClickElement(CreateNewTenantPage.Create);
            Actions.GetElementText(ToastifyNotification.ToastNotification("error")).Should().BeEquivalentTo("Please Correct Validation Errors");
            Actions.GetElementCssValue(ToastifyNotification.ToastNotification("error"), 10, "background-color").Should().BeEquivalentTo("rgba(176, 0, 32, 1)");  //red
            Actions.GetElementText(CreateNewTenantPage.TenantKeyError).Should().BeEquivalentTo("Tenant Key may not contain special characters.");
            Actions.GetElementCssValue(CreateNewTenantPage.TenantKeyError, 10, "color").Should().BeEquivalentTo("rgba(176, 0, 32, 1)"); //red
            Actions.ClearText(CreateNewTenantPage.TenantKey);
            Actions.EnterText(CreateNewTenantPage.TenantKey, "1ABC123!@#");
            Actions.ClickElement(CreateNewTenantPage.Create);
            Actions.GetElementText(ToastifyNotification.ToastNotification("error")).Should().BeEquivalentTo("Please Correct Validation Errors");
            Actions.GetElementCssValue(ToastifyNotification.ToastNotification("error"), 10, "background-color").Should().BeEquivalentTo("rgba(176, 0, 32, 1)");  //red
            Actions.GetElementText(CreateNewTenantPage.TenantKeyError).Should().BeEquivalentTo("Tenant Key cannot begin with a number");
            Actions.GetElementCssValue(CreateNewTenantPage.TenantKeyError, 10, "color").Should().BeEquivalentTo("rgba(176, 0, 32, 1)"); //red
            Actions.ClearText(CreateNewTenantPage.TenantKey);
        }
        public void ClientAdminTenantsPage_CreateNewTenantPage_Cancel()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
            Thread.Sleep(2000);
            Actions.ClickElement(ClientAdminTenantsPage.AddTenant);
            Actions.ClickElement(CreateNewTenantPage.Cancel);
            Actions.ElementIsPresent(ClientAdminTenantsPage.ClientAdminTenantsTitle).Should().BeTrue();
        }
        public void ClientAdminTenantsPage_CreateNewTenantPage_BrowserBack()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
            Actions.ClickElement(ClientAdminTenantsPage.AddTenant);
            Actions.BrowserBack();
            Actions.ElementIsPresent(ClientAdminTenantsPage.ClientAdminTenantsTitle).Should().BeTrue();
        }
        public void ClientAdminTenantsPage_CreateNewTenantPage_CreateNewTenantAndValidateSearch()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
            Actions.ClickElement(ClientAdminTenantsPage.AddTenant);
            Thread.Sleep(2000);
            Actions.EnterText(CreateNewTenantPage.TenantName, "U of QA 123 '.,-&");
            Actions.EnterText(CreateNewTenantPage.TenantKey, "QA" + CurrDateTime);  //"UofQA" + 
            Actions.ClickElement(CreateNewTenantPage.Create);
            Actions.GetElementText(ToastifyNotification.ToastNotification("success")).Should().BeEquivalentTo("Tenant Saved");
            Actions.GetElementCssValue(ToastifyNotification.ToastNotification("success"), 10, "background-color").Should().BeEquivalentTo("rgba(11, 0, 76, 1)");  //blue
            Actions.GetElementAttribute(EditTenantPage.TenantName, 10, "value").Should().BeEquivalentTo("U of QA 123 '.,-&");
            Actions.GetElementAttribute(EditTenantPage.TenantKey, 10, "value").Should().BeEquivalentTo("QA" + CurrDateTime);
            Thread.Sleep(2000);
            Actions.ClickElement(EditTenantPage.BackToClientAdmin);
            Thread.Sleep(2000);
            Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "QA" + CurrDateTime);
            Actions.ElementIsPresent(ClientAdminTenantsPage.EditTenant("QA" + CurrDateTime));
        }
        //public void ClientAdminTenantsPage_CreateNewTenantPage_CreateNewTenantWithError()
        //{
        //    Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
        //    Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
        //    Actions.ClickElement(ClientAdminTenantsPage.AddTenant);
        //    Thread.Sleep(2000);
        //    Actions.EnterText(CreateNewTenantPage.TenantName, "U of QA 123 -_:&");
        //    Actions.EnterText(CreateNewTenantPage.TenantKey, "UofQA");
        //    Actions.ClickElement(CreateNewTenantPage.Create);
        //    Actions.GetElementText(ToastifyNotification.ToastNotification("error")).Should().BeEquivalentTo("There was an error");
        //    Actions.GetElementCssValue(ToastifyNotification.ToastNotification("error"), 10, "background-color").Should().BeEquivalentTo("rgba(176, 0, 32, 1)");  //red
        //    Actions.ElementIsPresent(CreateNewTenantPage.TenantName);
        //}
        public void ClientAdminTenantsPage_EditTenantPage_DeactivateTenant()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
            Thread.Sleep(2000);
            Actions.ClickElement(ClientAdminTenantsPage.AddTenant);
            Thread.Sleep(2000);
            Actions.EnterText(CreateNewTenantPage.TenantName, "Deactivate" + CurrDateTime);
            Actions.EnterText(CreateNewTenantPage.TenantKey, "QA" + CurrDateTime);  //"UofQA" + 
            Actions.ClickElement(CreateNewTenantPage.Create);
            Thread.Sleep(2000);
            Actions.ClickElement(ToastifyNotification.CloseToast);
            Thread.Sleep(2000);
            Actions.ClickElement(EditTenantPage.BackToClientAdmin);
            Thread.Sleep(2000);
            Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "Deactivate" + CurrDateTime);
            Actions.ClickElement(ClientAdminTenantsPage.EditTenant("Deactivate" + CurrDateTime));
            Actions.ClickElement(EditTenantPage.ActiveSwitch);
            Actions.ClickElement(EditTenantPage.Update);
            Actions.GetElementText(ToastifyNotification.ToastNotification("success")).Should().BeEquivalentTo("Tenant Successfully Deactivated");
            Actions.GetElementCssValue(ToastifyNotification.ToastNotification("success"), 10, "background-color").Should().BeEquivalentTo("rgba(11, 0, 76, 1)");  //blue
        }
        public void ClientAdminTenantsPage_EditTenantPage_ValidateDisabledElements()
        {
            Elements = new List<By>() { EditTenantPage.TenantName, EditTenantPage.TenantKey };

            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
            Thread.Sleep(2000);
            Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "sooners");
            Actions.ClickElement(ClientAdminTenantsPage.EditTenant("sooners"));
            Actions.ElementsAreDisabled(Elements).Should().BeTrue();
            Actions.ClickElement(EditTenantPage.BackToClientAdmin);
        }
        public void ClientAdminTenantsPage_EditTenantPage_BrowserBack()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
            Thread.Sleep(2000);
            Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "sooners");
            Actions.ClickElement(ClientAdminTenantsPage.EditTenant("sooners"));
            Actions.BrowserBack();
            Actions.ElementIsPresent(ClientAdminTenantsPage.ClientAdminTenantsTitle).Should().BeTrue();
        }
        public void ClientAdminTenantsPage_EditTenantPage_BackToClientAdmin()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
            Thread.Sleep(2000);
            Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "sooners");
            Actions.ClickElement(ClientAdminTenantsPage.EditTenant("sooners"));
            Actions.ClickElement(EditTenantPage.BackToClientAdmin);
            Actions.ElementIsPresent(ClientAdminTenantsPage.ClientAdminTenantsTitle).Should().BeTrue();
        }
        public void ClientAdminTenantsPage_EditTenantPage_CloseButton()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
            Thread.Sleep(2000);
            Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "sooners");
            Actions.ClickElement(ClientAdminTenantsPage.EditTenant("sooners"));
            Actions.ClickElement(EditTenantPage.CloseButton);
            Actions.ElementIsPresent(ClientAdminTenantsPage.ClientAdminTenantsTitle).Should().BeTrue();
        }
        public void ClientAdminTenantsPage_EditTenantPage_NavToIntegrations()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToClientAdminTenants);
            Thread.Sleep(2000);
            Actions.EnterText(ClientAdminTenantsPage.SearchForTenant, "sooners");
            Actions.ClickElement(ClientAdminTenantsPage.EditTenant("sooners"));
            Actions.ClickElement(EditTenantPage.IntegrationsTab);
            Actions.ElementIsPresent(ClientAdminTenantIntegrationsPage.AddIntegrationButton).Should().BeTrue();
        }
    }
}
