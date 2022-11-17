namespace ci_automation_enterpriseportalui.PageObjects
{
    public static class ToastifyNotification
    {
        //Toast Notification Elements

        //TYPES = error, success
        public static By ToastNotification(string type) => By.XPath(string.Format("//div[contains(@class, 'Toastify__toast Toastify__toast--{0}')]", type));

        //MESSAGES
        //Please Correct Validation Errors
        //Configuration Saved
        //Failed To Save Configuration: Error: Request Failed with status code [ResponseCode]
        //Configuration Successfully Deactivated
        //Tenant Saved
        //Tenant Successfully Deactivated
        public static By ToastMessage(string msg) => By.XPath(string.Format("//div[@id='Toastify__toast-body')][contains(text(), '{0}')]", msg));
        public static By CloseToast => By.XPath(string.Format("//button[contains(@class, 'Toastify__close-button')]"));
    }
}
