namespace ci_automation_enterpriseportalui.FunctionalTests
{
    public class DataTaggingAssignmentsTests
    {
        public SeleniumActions Actions;

        public DataTaggingAssignmentsTests()
        {
        }
        public DataTaggingAssignmentsTests(SeleniumActions actions)
        {
            Actions = actions;
        }
        public void CheckDataTaggingAssignmentsSelections()
        {

            //Logger.WriteLine("I'm in Assignments, trying to click the Left Nav Menu.", 1);
            //Actions.ClickMenu("DataTagging");
            //Logger.WriteLine("I clicked Data Tagging and I'm looking for Assignments.", 1);
            //Actions.ClickMenu("DataTagging-Assignments");
            //var expectedTitle = "Data Tag Assignment";
            //var uiTitle = Actions.GetElementText(DataTaggingAssignPage.DataTaggingAssignTitle);
            //uiTitle.Should().Be(expectedTitle);

            ////example of validating a dropdown
            ////var uiEntityList = Actions.GetDropDownItems("Tag Entity");
            ////var expectedEntityList = ManageQueries.GetTagEntities(ActionMessage);
            ////uiEntityList.Should().BeEquivalentTo(expectedEntityList);

            //////example of entering values in dropdowns
            ////Get Table Data
            //Actions.SetDropDownItem("entity-select", "Mens basketball regular season");
            //Actions.SetDropDownItem("season-select", "2021");
            //Actions.SetDropDownItem("dimension-select", "Plan Type");
            //Actions.SetDropDownItem("hierarchy-select", "Renewal Flag");
            //////example to add a new rule name
            ////Actions.SetDropDownItem("Tag Rule", "Create New Rule");
            ////Actions.SetInPutField("Rule Name", "DudeRocks");
            ////Actions.ClickButton("Save");
            ////var whatyougot = Actions.IsWarningWithMessagePresent("Please correct validation errors");

            //////Test Assignment Mode
            ////Actions.SetDataTagAssignmentMode("Advanced");

            //////Test Re-order save rule pop-up
            //var myMadeUpOrder = new List<string>()
            //    //{"AK New", "AK Rule 4", "AK Rule 2", "AK Rule 6", "AK Rule 1", "AK Rule 7", "AK Rule 5", "AK Rule 3"};
            //    {"ak rule 1", "ak rule 2", "ak rule 4", "ak rule 3", "cm test", "ak rule 5", "ak rule 6", "ak rule 7", "ak new"};
            //Actions.SetDropDownItem("selectedRule-select", "AK Rule 2");
            ////Actions.ClickButton("Save");
            //Actions.ClickButton("tagRule_save_button");
            //Actions.GetUpdateTagRuleHighlighted().Should().BeEquivalentTo("AK Rule 2");
            //Actions.GetUpdateTagRuleOrder().ConvertAll(d => d.ToLower()).Should().Equal(myMadeUpOrder.ConvertAll(d => d.ToLower()));
            //Actions.SetUpdateTagRules("", myMadeUpOrder, "tagrule_confirm_dialog_cancel_button");
            ////var whatyougot = Actions.IsWarningWithMessagePresent("Please correct validation errors");



            ////var tableAttributes = new GeneralTableAttributes(ActionMessage, "AK Rule 5");
            ////var expectedTableData = tableAttributes.Data;
            ////Actions.SetFilters(tableAttributes.Filters);
            ////var uiGrid = Actions.GetGridData();
            ////uiGrid.Should().BeEquivalentTo(expectedTableData);

            ////Example of entering a rule
            ////Actions.SetFilters(tableAttributes.Filters);
            ////Actions.SetDropDownItem("Tag Rule", "Create New Rule");
            ////Actions.SetInPutField("Rule Name", "AutomationRule1");
        }
    }
}
