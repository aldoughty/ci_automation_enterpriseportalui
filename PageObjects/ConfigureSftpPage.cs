using Amazon.S3.Model;
using Google.Apis.Util;

namespace ci_automation_enterpriseportalui.PageObjects
{
    public static class ConfigureSftpPage
    {
        //Client Admin Tenant Integration Configure SFTP Page Elements

        //Titles, Labels                                                                                                
        public static By Tenant(string tenant) => By.XPath(string.Format("//h6[contains(@class, 'left-header_text') and contains(., '{0}')]", tenant));
        public static By Title(string title) => By.XPath(string.Format("//h5[@id, 'tenant_integration_header' and contains(., '{0}')]", title));
        public static By StepDescription => By.Id("client-admin-title");

        //Table    //descendant::div[@class, 'ag-center-cols-container']   div[@id='sftp-connection-table']
        //public static By FirstRow => By.XPath("//div[@class, 'ag-center-cols-container']//descendant::div[contains(@class, 'ag-row-first']");
        public static By FirstRow => By.CssSelector("#sftp-connection-table > div > div > div.ag-root-wrapper-body.ag-focus-managed.ag-layout-normal > div.ag-root.ag-unselectable.ag-layout-normal > div.ag-body-viewport.ag-row-animation.ag-layout-normal > div.ag-center-cols-clipper > div > div > div.ag-row-no-focus.ag-row.ag-row-level-0.ag-row-position-absolute.ag-row-even.ag-row-first");

        //Buttons, Checkboxes, Tabs
        public static By GoBack => By.XPath("//button[contains(., 'Go Back')]");
        public static By ChangeConnection => By.XPath("//button[contains(@class, 'change_connection_button')]");
        public static By ShowInactive => By.Id("show-inactive-checkbox-control-input");
        public static By Refresh => By.XPath("//button[contains(@class, 'MuiButton-root')]descendant::span[contains(text(), 'Refresh')]");
        //connectionValue could be the Id, Hostname, Username, KeyFilPath; any value in that row
        public static By Select(string connectionValue) => By.XPath(string.Format("//div[contains(text(), '{0}')]//following::div//descendant::button[contains(text(), 'select')]", connectionValue));
        public static By HostnameCopy => By.XPath("//div[contains(@class, 'hostname_copy_icon')]//descendant::svg[@data-testid, 'ContentCopyIcon')]");
        public static By UsernameCopy => By.XPath("//div[contains(@class, 'username_copy_icon')]//descendant::svg[@data-testid, 'ContentCopyIcon')]");
        public static By KeyFilePathCopy => By.XPath("//div[contains(@class, 'keyFilePath_copy_icon')]//descendant::svg[@data-testid, 'ContentCopyIcon')]");
        //value is true for selected or "" for not selected
        public static By DeleteFromSource(string value) => By.XPath(string.Format("//input[@name, 'sftpDeleteFromSource' and @value, '{0}']", value));
        public static By LatestOnly(string value) => By.XPath(string.Format("//input[@name, 'sftpLatestOnly' and @value, '{0}']", value));
        //public static By UseEncryption(string value) => By.XPath(string.Format("//input[@name, 'useEncryption' and @value, '{0}']", value));
        public static By Cancel => By.XPath("//button[contains(text(), 'Cancel']");
        //public static By Save => By.XPath("//button[contains(@class, 'MuiButton-root') and contains(text(), 'Save']");
        public static By Save => By.XPath("//*[@id=\"client-admin-tenant-form\"]/div/form/div[3]/button[2]");

        //Textfields
        public static By SearchSftpConnections => By.Id("search-input");
        public static By Hostname(string hostname) => By.XPath(string.Format("//div[contains(@class, 'hostname_textField')]//following::div//descendant::input[contains(@class, 'Mui-disabled') and contains(@value, '{0}')]", hostname));
        public static By Username(string username) => By.XPath(string.Format("//div[contains(@class, 'username_textField')]//following::div//descendant::input[contains(@class, 'Mui-disabled') and contains(@value, '{0}')]", username));
        public static By Password(string password) => By.XPath(string.Format("//div[contains(@class, 'password_textField')]//following::div//descendant::input[contains(@class, 'Mui-disabled') and contains(@value, '{0}')]", password));
        public static By KeyFilePath(string keyfilepath) => By.XPath(string.Format("//div[contains(@class, 'keyFilePath_textField')]//following::div//descendant::input[contains(@class, 'Mui-disabled') and contains(@value, '{0}')]", keyfilepath));
        public static By SourceDirectory => By.Id("sourceDirectory-input");
        public static By ArchiveDirectory => By.Id("sftpArchiveDirectory-input");
        public static By SourceFilename => By.Id("sourceFilename-input");
        public static By BlobDestination => By.Id("blobDestination-input");

        //Results Rows Summary
        public static By FirstRowOfResults => By.Id("ag-8-first-row");
        public static By LastRowOfResults => By.Id("ag-8-last-row");
        public static By TotalRowsOfResults => By.Id("ag-8-row-count");

        //Paging Summary
        public static By FirstPage => By.XPath("//div[@aria-label='First Page']");
        public static By PreviousPage => By.XPath("//div[@aria-label='Previous Page']");
        public static By NextPage => By.XPath("//div[@aria-label='Next Page']");
        public static By LastPage => By.XPath("//div[@aria-label='Last Page']");

        //Validation Errors
        public static By SourceDirectoryError => By.Id("sourceDirectory_validation_errors");
        public static By ArchiveDirectoryError => By.Id("sftpArchiveDirectory_validation_errors");
        public static By SourceFilenameError => By.Id("sourceFilename_validation_errors");
        public static By BlobDestinationError => By.Id("blobDestination_validation_errors");
    }
}
