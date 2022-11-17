namespace ci_automation_enterpriseportalui.PageObjects
{
    public static class DataTaggingAssignPage
    {
        //Data Tagging Assignments Page Elements

        public static By DataTaggingAssignTitle => By.Id("ticket-tag-assignment-title");
        public static By TenantDropDown => By.Id("orgId-select");
        //used for selecting dropdown item
        public static By TenantDropDownItem(string menuOption) => By.XPath(string.Format("//li[contains(@id, 'orgId-select-item')][contains(text(), '{0}')]", menuOption));
        public static By TaggingTypeDropDown => By.Id("taggingType-select");
        //used for selecting dropdown item
        public static By TaggingTypeDropDownItem(string menuOption) => By.XPath(string.Format("//li[contains(@id, 'taggingType-select-item')][contains(text(), '{0}')]", menuOption));
        public static By SavedConfigAddButton => By.Id("data-tag-add-new-config-button");
        public static By SavedConfigRow => By.CssSelector("li[id^=\"config-\"]");
        //public static By SavedConfigRow => By.XPath("//span[contains(text(), '" + text + "')]");
    }
}
