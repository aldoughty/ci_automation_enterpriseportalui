namespace ci_automation_enterpriseportalui.FunctionalTests
{
    public class DataTaggingAdminTests
    {
        public SeleniumActions Actions;
        public List<By> Elements;

        public DataTaggingAdminTests()
        {
            //SCENARIOS NEEDED
            //Tenant has no records in TenantSaveScheme
        }
        public DataTaggingAdminTests(SeleniumActions actions)
        {
            Actions = actions;
        }
        public void DataTaggingAdminPage_ValidateConfigYearDropDowns()
        {
            var currYear = Int32.Parse(DateTime.Now.ToString("yyyy"));
            var endYear = Int32.Parse(DateTime.Now.AddYears(2).ToString("yyyy"));

            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToDataTaggingAdmin);

            //Validate Start/EndYear DropDowns for New Config
            Thread.Sleep(1000);
            Actions.SetDropDowns(DataTaggingAdminPage.TenantAndTagType("U of QA - Internal Admin", "Ticketing"));
            Actions.ClickElement(DataTaggingAdminPage.SavedConfigAddButton, 5);
            Actions.SetDropDown(DataTaggingAdminPage.DataModelDropDown, DataTaggingAdminPage.DataModelDropDownItem("Ticket Master - V1"));

            //Initial Display:  StartYear = 2000 to CurrentYear; EndYear = 2000 to (CurrentYear + 2)
            Actions.GetDropDownItems(DataTaggingAdminPage.StartYearDropDown, DataTaggingAdminPage.StartYearDropDownItems).Should().BeEquivalentTo(Dates.GetYearList(2000, currYear));
            Actions.EscapeFocus();
            Actions.GetDropDownItems(DataTaggingAdminPage.EndYearDropDown, DataTaggingAdminPage.EndYearDropDownItems).Should().BeEquivalentTo(Dates.GetYearListWithTextValue("None", 2000, endYear));
            Actions.EscapeFocus();

            //StartYear Selected:  EndYear = Selected StartYear to (CurrentYear + 2)
            Actions.SetDropDown(DataTaggingAdminPage.StartYearDropDown, DataTaggingAdminPage.StartYearDropDownItem("2000"), 10);
            Actions.GetDropDownItems(DataTaggingAdminPage.EndYearDropDown, DataTaggingAdminPage.EndYearDropDownItems).Should().BeEquivalentTo(Dates.GetYearListWithTextValue("None", 2000, endYear));
            Actions.EscapeFocus();
            Actions.SetDropDown(DataTaggingAdminPage.StartYearDropDown, DataTaggingAdminPage.StartYearDropDownItem("2011"), 10);
            Actions.GetDropDownItems(DataTaggingAdminPage.EndYearDropDown, DataTaggingAdminPage.EndYearDropDownItems).Should().BeEquivalentTo(Dates.GetYearListWithTextValue("None", 2011, endYear));
            Actions.EscapeFocus();
            Thread.Sleep(1000);
            Actions.SetDropDown(DataTaggingAdminPage.StartYearDropDown, DataTaggingAdminPage.StartYearDropDownItem("2022"), 10);
            Actions.GetDropDownItems(DataTaggingAdminPage.EndYearDropDown, DataTaggingAdminPage.EndYearDropDownItems).Should().BeEquivalentTo(Dates.GetYearListWithTextValue("None", 2022, endYear));
            Actions.EscapeFocus();

            //Validate New Config EndYear Nulls if StartYear is Updated to StartYear > EndYear
            Actions.SetDropDowns(DataTaggingAdminPage.StartAndEndYear("2018", "2018"));
            Actions.GetElementText(DataTaggingAdminPage.EndYearDropDown).Should().BeEquivalentTo("2018");
            Actions.SetDropDown(DataTaggingAdminPage.StartYearDropDown, DataTaggingAdminPage.StartYearDropDownItem("2020"), 10);
            Actions.EscapeFocus();
            Actions.GetElementText(DataTaggingAdminPage.EndYearDropDown).Should().BeEquivalentTo("");
            Actions.EscapeFocus();

            //Validate Start/End DropDowns for Saved Config without EndYear
            Actions.ClickElement(DataTaggingAdminPage.SavedConfigRowByYearRange("2016 - present"));
            Actions.GetDropDownItems(DataTaggingAdminPage.StartYearDropDown, DataTaggingAdminPage.StartYearDropDownItems).Should().BeEquivalentTo(Dates.GetYearList(2016, currYear));
            Actions.EscapeFocus();
            Actions.GetDropDownItems(DataTaggingAdminPage.EndYearDropDown, DataTaggingAdminPage.EndYearDropDownItems).Should().BeEquivalentTo(Dates.GetYearListWithTextValue("None", 2016, endYear));
            Actions.EscapeFocus();

            //Validate Start/End DropDowns for Saved Config with EndYear
            Actions.ClickElement(DataTaggingAdminPage.SavedConfigRowByYearRange("2000 - 2011"));
            Actions.GetDropDownItems(DataTaggingAdminPage.StartYearDropDown, DataTaggingAdminPage.StartYearDropDownItems).Should().BeEquivalentTo(Dates.GetYearList(2000, currYear));
            Actions.EscapeFocus();
            Actions.GetDropDownItems(DataTaggingAdminPage.EndYearDropDown, DataTaggingAdminPage.EndYearDropDownItems).Should().BeEquivalentTo(Dates.GetYearListWithTextValue("None", 2000, endYear));
            Actions.EscapeFocus();

            //Validate Saved Config EndYear Nulls if StartYear is Updated to StartYear > EndYear
            Actions.ClickElement(DataTaggingAdminPage.SavedConfigRowByYearRange("2000 - 2011"));
            Actions.SetDropDown(DataTaggingAdminPage.StartYearDropDown, DataTaggingAdminPage.StartYearDropDownItem("2018"), 10);
            Actions.EscapeFocus();
            Thread.Sleep(1000);
            Actions.GetElementText(DataTaggingAdminPage.EndYearDropDown).Should().BeEquivalentTo("");
            Actions.EscapeFocus();

        }
        public void DataTaggingAdminPage_AddNewConfigFieldValidation()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToDataTaggingAdmin);
            Actions.SetDropDowns(DataTaggingAdminPage.TenantAndTagType("U of QA - Internal Admin", "Ticketing"));
            Actions.ClickElement(DataTaggingAdminPage.SavedConfigAddButton, 5);

            //Active switch does not display on new config
            Actions.ElementIsPresent(DataTaggingAdminPage.ActiveSwitch).Should().BeFalse();

            Elements = new List<By>() { DataTaggingAdminPage.StartYearDropDown, DataTaggingAdminPage.EndYearDropDown, DataTaggingAdminPage.Save };

            //All fields are disabled until Data Model is selected
            Actions.ElementsAreDisabled(Elements).Should().BeTrue();
            //Actions.ElementsAreDisabled(Actions.ConvertToBy("DataTaggingAdminPage.StartYearDropDown, DataTaggingAdminPage.EndYearDropDown, DataTaggingAdminPage.Save")).Should().BeTrue();
            Actions.SetDropDown(DataTaggingAdminPage.DataModelDropDown, DataTaggingAdminPage.DataModelDropDownItem("Ticket Master - V1"));
            Actions.ElementsAreDisabled(Elements).Should().BeFalse();
            //Actions.ElementsAreDisabled(Actions.ConvertToBy("DataTaggingAdminPage.StartYearDropDown, DataTaggingAdminPage.EndYearDropDown, DataTaggingAdminPage.Save")).Should().BeFalse();
            Actions.ClickElement(DataTaggingAdminPage.Save);

            //Validate required fields
            Actions.GetElementText(ToastifyNotification.ToastNotification("error")).Should().BeEquivalentTo("Please Correct Validation Errors");
            Actions.GetElementCssValue(ToastifyNotification.ToastNotification("error"), 10, "background-color").Should().BeEquivalentTo("rgba(176, 0, 32, 1)");  //red
            Actions.GetElementText(DataTaggingAdminPage.StartYearError).Should().BeEquivalentTo("Start Year is required");
            Actions.GetElementCssValue(DataTaggingAdminPage.StartYearError, 10, "color").Should().BeEquivalentTo("rgba(176, 0, 32, 1)"); //red
        }
        public void DataTaggingAdminPage_SavedConfigFieldValidation()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToDataTaggingAdmin);
            Actions.SetDropDowns(DataTaggingAdminPage.TenantAndTagType("U of QA - Internal Admin", "Ticketing"));
            Actions.ClickElement(DataTaggingAdminPage.SavedConfigRow);

            //Active switch displays on saved config
            Actions.ElementIsPresent(DataTaggingAdminPage.ActiveSwitch).Should().BeTrue();

            //Validate Data Model dropdown is disabled for existing config
            Actions.ElementIsDisabled(DataTaggingAdminPage.DataModelDropDown).Should().BeTrue();
        }
        public void DataTaggingAdminPage_SaveAndEditNewConfig()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToDataTaggingAdmin);
            Actions.SetDropDowns(DataTaggingAdminPage.TenantAndTagType("U of QA - Internal Admin", "Ticketing"));
            Actions.ClickElement(DataTaggingAdminPage.SavedConfigAddButton, 5);
            Actions.SetDropDowns(DataTaggingAdminPage.DataModelStartAndEndYear("SaveNDelete - V1", "2018", "None"));

            Actions.ClickElement(DataTaggingAdminPage.Save, 25);
            Actions.GetElementText(ToastifyNotification.ToastNotification("success")).Should().BeEquivalentTo("Configuration Saved.");
            Actions.GetElementCssValue(ToastifyNotification.ToastNotification("success"), 10, "background-color").Should().BeEquivalentTo("rgba(11, 0, 76, 1)");  //blue
            Actions.ClickElement(ToastifyNotification.CloseToast, 5);
            Thread.Sleep(1000);
            Actions.GetElementText(DataTaggingAdminPage.SavedConfigRowByYearRange("2018 - present")).Should().BeEquivalentTo("2018 - present");
            Actions.ClickElement(DataTaggingAdminPage.SavedConfigRowByDataModel("SaveNDelete - V1"));
            Actions.SetDropDown(DataTaggingAdminPage.StartYearDropDown, DataTaggingAdminPage.StartYearDropDownItem("2020"), 10);
            Actions.SetDropDown(DataTaggingAdminPage.EndYearDropDown, DataTaggingAdminPage.EndYearDropDownItem("2024"), 10);
            Actions.ClickElement(DataTaggingAdminPage.Save);
            Actions.GetElementText(ToastifyNotification.ToastNotification("success")).Should().BeEquivalentTo("Configuration Saved.");
            Actions.GetElementCssValue(ToastifyNotification.ToastNotification("success"), 10, "background-color").Should().BeEquivalentTo("rgba(11, 0, 76, 1)");  //blue
            Actions.ClickElement(ToastifyNotification.CloseToast, 5);
            Thread.Sleep(1000);
            Actions.GetElementText(DataTaggingAdminPage.SavedConfigRowByYearRange("2020 - 2024")).Should().BeEquivalentTo("2020 - 2024");
            Actions.ClickElement(DataTaggingAdminPage.SavedConfigRowByDataModel("SaveNDelete - V1"));
            Actions.ClickElement(DataTaggingAdminPage.ActiveSwitch);
            Actions.ClickElement(DataTaggingAdminPage.Save);
        }
        public void DataTaggingAdminPage_SaveAndDeactivateNewConfig()
        {
            Actions.Login("ssb", "superadmin@affinaquest.com", "Test@123");
            Actions.NavLeftNav(LeftNavMenu.NavToDataTaggingAdmin);

            Actions.SetDropDowns(DataTaggingAdminPage.TenantAndTagType("U of QA - Internal Admin", "Ticketing"));
            Actions.ClickElement(DataTaggingAdminPage.SavedConfigAddButton, 5);
            Actions.SetDropDowns(DataTaggingAdminPage.DataModelStartAndEndYear("SaveNDelete - V1", "2021", "None"));

            Actions.ClickElement(DataTaggingAdminPage.Save, 25);
            Actions.GetElementText(ToastifyNotification.ToastNotification("success")).Should().BeEquivalentTo("Configuration Saved.");
            Actions.GetElementCssValue(ToastifyNotification.ToastNotification("success"), 10, "background-color").Should().BeEquivalentTo("rgba(11, 0, 76, 1)");  //blue
            Actions.ClickElement(ToastifyNotification.CloseToast, 5);
            Thread.Sleep(1000);
            Actions.GetElementText(DataTaggingAdminPage.SavedConfigRowByYearRange("2021 - present")).Should().BeEquivalentTo("2021 - present");
            Actions.ClickElement(DataTaggingAdminPage.SavedConfigRowByDataModel("SaveNDelete - V1"));
            Actions.ClickElement(DataTaggingAdminPage.ActiveSwitch);
            Actions.ClickElement(DataTaggingAdminPage.Save);
            Actions.GetElementText(ToastifyNotification.ToastNotification("success")).Should().BeEquivalentTo("Configuration Successfully Deactivated");
            Actions.GetElementCssValue(ToastifyNotification.ToastNotification("success"), 10, "background-color").Should().BeEquivalentTo("rgba(11, 0, 76, 1)");  //blue
            Actions.ClickElement(ToastifyNotification.CloseToast, 5);
            Actions.ElementIsPresent(DataTaggingAdminPage.ConfigureDataTaggingContainer).Should().BeFalse();
        }
    }
}