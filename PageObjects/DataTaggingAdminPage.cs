namespace ci_automation_enterpriseportalui.PageObjects
{
    public static class DataTaggingAdminPage
    {

        //Data Tagging Administration Page Elements

        //Titles, Labels
        public static By DataTaggingAdminTitle => By.Id("data-tagging-administration-title");
        public static By DataTaggingAdminDescription => By.Id("data-tagging-administration-description");

        //Sections, Containers 
        public static By ConfigureDataTaggingContainer => By.Id("data-tag-configuration-container");

        //Buttons, Switches
        public static By Save => By.Id("data-tag-configuration-save-button");
        public static By ActiveSwitch => By.Id("active-switch-control-input");
        public static By SavedConfigAddButton => By.Id("data-tag-add-new-config-button");

        //SavedConfig Rows
        public static By SavedConfigRow => By.XPath("//li[contains(@id, 'config')]");
        public static By SavedConfigRowByYearRange(string yearRange) => By.XPath(string.Format("//p[contains(text(), '{0}')]", yearRange));
        public static By SavedConfigRowByDataModel(string dataModel) => By.XPath(string.Format("//span[contains(text(), '{0}')]", dataModel));

        //DropDowns
        //DropDown - used for opening/validating the dropdown
        public static By TenantDropDown => By.CssSelector("#orgId-select");
        public static By TaggingTypeDropDown => By.Id("taggingType-select");
        public static By DataModelDropDown => By.Id("dataModel-select");
        public static By StartYearDropDown => By.Id("startYear-select");
        public static By EndYearDropDown => By.Id("endYear-select");

        //DropDownItems - used for getting all dropdown items
        public static By StartYearDropDownItems => By.XPath("//li[contains(@id, 'startYear-select-item')]");
        public static By EndYearDropDownItems => By.XPath("//li[contains(@id, 'endYear-select-item')]");

        //DropDownItem(string menuOption) - used for selecting/validating a specific dropdown item
        public static By TenantDropDownItem(string menuOption) => By.XPath(string.Format("//li[contains(@id, 'orgId-select-item')][contains(text(), '{0}')]", menuOption));
        public static By TaggingTypeDropDownItem(string menuOption) => By.XPath(string.Format("//li[contains(@id, 'taggingType-select-item')][contains(text(), '{0}')]", menuOption));
        public static By DataModelDropDownItem(string menuOption) => By.XPath(string.Format("//li[contains(@id, 'dataModel-select-item')][contains(text(), '{0}')]", menuOption));
        public static By StartYearDropDownItem(string menuOption) => By.XPath(string.Format("//li[contains(@id, 'startYear-select-item')][contains(text(), '{0}')]", menuOption));
        public static By EndYearDropDownItem(string menuOption) => By.XPath(string.Format("//li[contains(@id, 'endYear-select-item')][contains(text(), '{0}')]", menuOption));

        //Common DropDown Sets
        public static Dictionary<By, By> TenantAndTagType(string tenantOption, string tagOption) { return new Dictionary<By, By>() { { TenantDropDown, TenantDropDownItem(tenantOption) }, { TaggingTypeDropDown, TaggingTypeDropDownItem(tagOption) } }; }
        public static Dictionary<By, By> StartAndEndYear(string startYear, string endYear) { return new Dictionary<By, By>() { { StartYearDropDown, StartYearDropDownItem(startYear) }, { EndYearDropDown, EndYearDropDownItem(endYear) } }; }
        public static Dictionary<By, By> DataModelStartAndEndYear(string dataModel, string startYear, string endYear) { return new Dictionary<By, By>() { { DataModelDropDown, DataModelDropDownItem(dataModel) }, { StartYearDropDown, StartYearDropDownItem(startYear) }, { EndYearDropDown, EndYearDropDownItem(endYear) } }; }

        //Validation Errors
        public static By StartYearError => By.Id("startYear_validation_errors");
    }
}
