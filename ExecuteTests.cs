namespace ci_automation_enterpriseportalui
{
    public class ExecuteTests
    {
        static int Main()
        {
            Stopwatch timer = new();
            IConfiguration configuration = SettingsConfig.Get();
            MessageData messageData = ParseArguments.PullFromEnvVariables();
            messageData.ValidateContent();
            Serilog.Core.Logger logger = Logger.CreateSystemLogger(messageData.StandardTestParameters);
            IWebDriver driver = SpinUpDriver(messageData.Browser, messageData.Url);
            try
            {
                timer.Start();
                logger.Information("Kicking off Enterprise Portal UI Tests.  Message received {@Message}", messageData);
                SeleniumActions actions = new SeleniumActions(driver);
                TestCaseData testCaseData = new TestCaseData();
                TestResults testResults = new TestResults(messageData.StandardTestParameters);
                testResults.NumberOfTestsCreated = testCaseData.Tests.Count;
                foreach (TestCaseData.ReflectionData test in testCaseData.Tests)
                {
                    testResults.LogIndividualResults(RunTest(test, actions));
                }
                
                timer.Stop();
                testResults.SecondsToExecute = Convert.ToInt32(timer.ElapsedMilliseconds / 1000);
                testResults.LogFinalResults();
                logger.Verbose("Tests Completed");
                logger.Verbose("Number of Tests Run : {@Num}", testResults.NumberTestsExecuted);
                logger.Verbose("Number of Tests Passed: {@Num}", testResults.NumberTestsPassed);
                logger.Verbose("Number of Tests Failed: {@Num}", testResults.NumberTestsFailed);
                logger.Verbose("Number of Tests Warnings: {@Num}", testResults.NumberTestsWithWarning);
                logger.Verbose("Number of Tests Errors: {@Num}", testResults.NumberTestsWithError);
                driver.Dispose();
                return 0;
            }
            catch (Exception e)
            {
                logger.Fatal("Exception Message: {@Message}", e.Message);
                logger.Fatal("Exception StackTrace: {@Exception}", e.StackTrace);
                driver.Dispose();
                return 1;
            }
        }
        private static IWebDriver SpinUpDriver(string browser, string url)
        {
            var assembley = Assembly.Load("WebDriver");
            var typeString = "OpenQA.Selenium." + browser;
            var t = assembley.GetType(typeString);
            var chromeOptions = new ChromeOptions();
            //chromeOptions.AddUserProfilePreference("download.default_directory",".\\");
            //chromeOptions.AddArgument("headless"); //will allow selenium to run in chrome headless version.
            //chromeOptions.AddArgument("--no-sandbox");
            //chromeOptions.AddArgument("--disable-setuid-sandbox");
            //chromeOptions.AddArgument("--disable-dev-shm-usage");
            //chromeOptions.AddArgument("--disable-gpu");
            //chromeOptions.AddArgument("--disable-infobars");
            //Driver = new ChromeDriver(chromeOptions);
            IWebDriver driver = Activator.CreateInstance(t, chromeOptions) as IWebDriver;
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            return driver;
        }
        private static TestResults.TestDetails RunTest(TestCaseData.ReflectionData reflectionData, SeleniumActions seleniumActions)
        {
            TestResults.TestDetails testDetails = new TestResults.TestDetails
            {
                TestCaseName = reflectionData.Function+"_"+reflectionData.MethodName,
                TestCaseStep = reflectionData.Function + "_" + reflectionData.MethodName,
                ExecutionDate = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss")
            };
            Stopwatch timer = new();
            timer.Start();
            try
            {
                var assembley = Assembly.Load("ci_automation_enterpriseportalui");
                var t = assembley.GetType(reflectionData.Function);
                object testClass = Activator.CreateInstance(t, seleniumActions);
                testClass.GetType().GetMethod(reflectionData.MethodName).Invoke(testClass, null);
                timer.Stop();
                testDetails.MilliSecondsToExecute = timer.ElapsedMilliseconds;
                testDetails.Status = TestResults.Status.Passed;
            }
            catch (Exception e)
            {
                timer.Stop();
                testDetails.MilliSecondsToExecute=timer.ElapsedMilliseconds;
                testDetails.Status = TestResults.Status.Failed;
                testDetails.FailureMessage = e.StackTrace;
            }

            return testDetails;
        }
    }
}
