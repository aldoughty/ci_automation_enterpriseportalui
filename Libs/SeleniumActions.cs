namespace ci_automation_enterpriseportalui.Libs
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                Thread.Sleep(100);
                //return wait.Until(ExpectedConditions.ElementIsVisible(by));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                //return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public static ReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => (drv.FindElements(by).Count > 0) ? drv.FindElements(by) : null);
            }
            return driver.FindElements(by);
        }
    }
    public class SeleniumActions 
    {
        public IWebDriver Driver;
        public int Timeout;
        public Actions SelActions;
        public SeleniumActions()
        {
        }
        public SeleniumActions(IWebDriver driver)
        {
            IConfiguration settings = SettingsConfig.Get();
            Driver = driver;
            Timeout = Convert.ToInt32(SettingsHandler.GetSettingString("SeleniumTimeout", settings));
            SelActions = new Actions(driver);
        }
        public void NavToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }
        public void BrowserBack()
        {
            Driver.Navigate().Back();
        }
        public bool ElementIsDisabled(By element)
        {
            return Driver.FindElement(element, 5).GetAttribute("class").Contains("disabled");
        }
        public bool ElementsAreDisabled(List<By> Elements)
        {
            return Elements.TrueForAll(element => Driver.FindElement(element, 5).GetAttribute("class").Contains("disabled"));
        }
        public bool ElementIsPresent(By element)
        {
            return Driver.FindElements(element).Count() > 0;
        }
        public bool ElementsArePresent(List<By> Elements)
        {
            return Elements.TrueForAll(element => Driver.FindElements(element).Count() > 0);
        }
        public void ClickElement(By element)
        {
            Driver.FindElement(element, 5).Click();
        }
        public void ClickElement(By element, int timeout)
        {
            Driver.FindElement(element, timeout).Click();
        }
        public void EnterText(By element, string text)
        {
            Driver.FindElement(element).SendKeys(text);
        }
        public void EnterText(By element, int timeout, string text)
        {
            Driver.FindElement(element, timeout).SendKeys(text);
        }
        public void ClearText(By element)
        {
            Driver.FindElement(element).Clear();
        }
        public string GetElementText(By element)
        {
            return Driver.FindElement(element, 5).Text;
        }
        public string GetElementCssValue(By element, int timeout, string value)
        {
            return Driver.FindElement(element, timeout).GetCssValue(value);
        }
        public string GetElementAttribute(By element, int timeout, string value)
        {
            return Driver.FindElement(element, timeout).GetAttribute(value);
        }
        public void SetDropDown(By dropdown, By option)
        {
            Driver.FindElement(dropdown).Click();
            Driver.FindElement(option).Click();
        }
        public void SetDropDown(By dropdown, By option, int timeout)
        {
            Driver.FindElement(dropdown, 10).Click();
            Driver.FindElement(option).Click();
        }
        public void SetDropDowns(Dictionary<By, By> DropDowns)
        {
            DropDowns.ToList().ForEach
            (
                pair =>
                {
                    ClickElement(pair.Key, 5);       //opens dropdown
                    ClickElement(pair.Value, 5);     //selects option
                    EscapeFocus();
                }
            );
        }
        public List<string> GetDropDownItems(By dropdown, By items)
        {
            Driver.FindElement(dropdown, 10).Click();
            var listItems = Driver.FindElements(items, 10);
            //for debugging
            //Logger.WriteLine("Drop-down: " + dropdown + "   ***   Number of Items: " + listItems.Count.ToString(),3);
            //Logger.WriteLine(string.Join(Environment.NewLine, listItems.Select(item => item.Text).ToList()), 3);
            return listItems.Select(item => item.Text).ToList();
        }
        public HashSet<string> GetSearchFilterResults(By element)
        {
            //gets all elements and adds unique text values to HashSet
            
            IList<IWebElement> all = Driver.FindElements(element, 10);

            HashSet<string> elementText = new();

            foreach (IWebElement webElement in all)
            {
                elementText.Add(webElement.Text);
            }

            return elementText;
        }
        public bool ValidateElementTextListAlphabeticalOrder(By element)
        {
            //gets all elements, adds text values to List and validates for alphabetical order

            IList<IWebElement> all = Driver.FindElements(element, 10);

            List<string> elementText = new();

            foreach (IWebElement webElement in all)
            {
                elementText.Add(webElement.Text);
            }

            var alphabetical = true;
            for (int i = 0; i < elementText.Count - 1; i++)
            {
                if (StringComparer.Ordinal.Compare(elementText[i], elementText[i + 1]) > 0)
                {
                    alphabetical = false;
                    break;
                }
            }

            return alphabetical;
        }
        public void Login(string org, string username, string password)
        {
            try
            {
                ClickElement(WelcomePage.LogOut, 5);
                EnterText(EnterOrgPage.Org, 5, org);
                ClickElement(EnterOrgPage.Continue, 5);
                EnterText(WelcomePage.Username, 5, username);
                EnterText(WelcomePage.Password, 5, password);
                ClickElement(WelcomePage.Continue, 5);
            }
            catch
            {
                EnterText(EnterOrgPage.Org, 5, org);
                ClickElement(EnterOrgPage.Continue, 30);
                EnterText(WelcomePage.Username, 5, username);
                EnterText(WelcomePage.Password, 5, password);
                ClickElement(WelcomePage.Continue, 5);
            }

        }
        public void NavLeftNav(List<By> MenuNav)
        {
            ClickElement(LeftNavMenu.OpenMenu, 5);
            MenuNav.ForEach(option => ClickElement(option, 5));
            //Clicking the Org label in the header to move focus off Left Nav so it will close
            Driver.FindElement(By.XPath("/html/body/div/div/div/header/div/div/div[3]")).Click();
        }
        //public List<By> GetListOfElements(By elements)
        //{
        //    List<By> allElems = driver.FindElements(elements);

        //    allElems.ToList().ForEach
        //    (
        //        pair =>
        //        {
        //            ClickElement(pair.Key, 5);       //opens dropdown
        //            ClickElement(pair.Value, 5);     //selects option
        //            EscapeFocus();
        //        }
        //    );

        //}
        //public List<By> ConvertToBy(string listOfBys)
        //{
        //split string and convert to bys
        //var splitString = listOfBys.Split(',').ToList();
        //object[] bys = listOfBys.Split(',');
        //IList<Object> objects = splitString.Cast<Object>().ToList();
        //List<By> result = objects.Cast<By>().ToList();
        //var results = splitString.Cast<By>();
        //splitString.(item => TypeDescriptor.GetConverter(typeof(By)).ConvertFromString(item));
        //splitString.Select(item => TypeDescriptor.GetConverter(typeof(By)).ConvertFromString(item)).ToList();
        //TypeDescriptor.GetConverter(typeof(By)).ConvertFromString(item);
        //List<By> results = (List<By>)splitString;
        //var results = (splitString as IEnumerable<By>).ToList();
        //return splitString.Select(item => TypeDescriptor.GetConverter(typeof(By)).ConvertFromString(item)).ToList();
        //splitString.Select(item => List<By>.Add(item));
        //return new List<By>() { splitString };
        //return new List<By> { splitString.Select(item => List<By>.Add(item)) };
        //return splitString.Select(item => By(item)).ToList();
        //splitString.Select(item => object(item));
        //IEnumerable<By> bys = splitString.Select(item => EnumerableQuery(item));
        //return bys;
        //var bys = listOfBys.Split(',').OfType<By>();
        //    return listOfBys.Split(',').Cast<By>().ToList();
        //}
        public List<string> GetLeftNavMenuItems(By menu)
        {
            Thread.Sleep(1000);
            var menuItems = Driver.FindElements(menu, 10);
            //for debugging
            //Logger.WriteLine("Menu: " + menu + "   ***   Number of Items: " + menuItems.Count.ToString(),3);
            //Logger.WriteLine(string.Join(Environment.NewLine, menuItems.Select(item => item.Text).ToList()), 3);

            return menuItems.Select(item => item.Text).ToList();
        }
        public List<Dictionary<string, string>> GetGridData()
        {
            Driver.FindElement(By.CssSelector("div[class='InovuaReactDataGrid__header-layout'] div[class ^='InovuaReactDataGrid__column-header__content']"), Timeout);
            var results = new List<Dictionary<string, string>>();
            var moreOnList = true;
            var headers = new List<string>();
            foreach (var webElement in Driver.FindElements(By.CssSelector("div[class='InovuaReactDataGrid__header-layout'] div[class ^='InovuaReactDataGrid__column-header__content']")))
            {
                headers.Add(webElement.Text);
            }

            //Need to make sure that we are on the first page
            var atBeginning = Driver.FindElement(By.XPath("//div[@class='inovua-react-pagination-toolbar__region']//div[contains(@class,'FIRST_PAGE')]/div[1]")).GetAttribute("Class").Contains("disable");
            if (!atBeginning) Driver.FindElement(By.CssSelector("div[class='inovua-react-pagination-toolbar__region'] div[class *='FIRST_PAGE']")).Click();


            moreOnList = true;
            while (moreOnList)
            {
                foreach (var row in Driver.FindElements(By.CssSelector("div[class^='InovuaReactDataGrid__row ']")))
                {
                    var rowData = new Dictionary<string, string>();
                    var rowNum = 0;
                    foreach (var rowElement in row.FindElements(By.CssSelector("div[class='InovuaReactDataGrid__cell__content']")))
                    {
                        rowData.Add(headers[rowNum], rowElement.Text);
                        rowNum = rowNum + 1;
                    }

                    results.Add(rowData);
                }

                moreOnList = !Driver.FindElement(By.XPath("//div[@class='inovua-react-pagination-toolbar__region']//div[contains(@class,'NEXT_PAGE')]/div[1]")).GetAttribute("Class").Contains("disable");
                if (moreOnList) Driver.FindElement(By.CssSelector("div[class='inovua-react-pagination-toolbar__region'] div[class *='NEXT_PAGE']")).Click();
            }

            return results;

        }
        public List<string> GetUpdateTagRuleOrder()
        {
            var rules = Driver.FindElements(By.CssSelector("ul[id='tagrule_sort_list'] li"), Timeout);
            return rules.Select(rule => rule.Text).ToList();
        }

        public string GetUpdateTagRuleHighlighted()
        {
            Driver.FindElement(By.CssSelector("ul[id='tagrule_sort_list']"), Timeout);
            return Driver.FindElement(By.CssSelector("ul[id='tagrule_sort_list'] div[class*='css-xyddjj']")).Text;
        }
        public void SetDataTagAssignmentMode(string mode)
        {
            //Right now mode values would either be Basic or Advanced
            Driver.FindElement(By.CssSelector("div[id='mode-radio-group']"), Timeout);
            Driver.FindElement(By.CssSelector("div[id='mode-radio-group'] label[id^='" + mode + "']")).Click();
        }
        public void SetInPutField(string label, string value)
        {
            Driver.FindElement(By.XPath("//div[contains(@class,'MuiFormControl')]//label[contains(.,'" + label + "')]/parent::div//input"), Timeout).Clear();
            Driver.FindElement(By.XPath("//div[contains(@class,'MuiFormControl')]//label[contains(.,'" + label + "')]/parent::div//input")).SendKeys(value);
        }


        public void ClickOnTagRuleSaveButton()
        {
            Driver.FindElement(By.Id("tagRule_save_button")).Click();

        }
        public bool IsWarningPresent(string label)
        {
            try
            {
                Driver.FindElement(By.XPath("//div[@class='Toastify__toast-body']"), 1);
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }

        }


        public void SetFilters(List<GeneralTableAttributes.Filter> filters)
        {
            var tableHeaders = Driver.FindElements(By.CssSelector("div[class*='ag-header-row ag-header-row-column']"), Timeout);
            //Clear all filters (this isn't working)
            //tableHeaders.Last().FindElement(By.CssSelector("div[class='InovuaReactDataGrid__column-header__filter-settings']")).Click();
            //driver.FindElement(By.XPath("//table[@class='inovua-react-toolkit-menu__table']//td[.='Clear all']")).Click();

            foreach (var filter in filters)
            {
                var header = tableHeaders.FirstOrDefault(x => x.Text.Equals(filter.HeaderName));
                header.FindElement(By.CssSelector("button[class='ag-floating-filter-button-button']")).Click();
                header.FindElement(By.CssSelector("button[class='ag-picker-field-icon']")).Click();
                Driver.FindElement(By.XPath("//div[@class='ag-picker-field-display']//[contains(text(),'" + filter.GetFilterUiOperator() + "')]")).Click();
                switch (filter.GetFilterUiOperator().ToLower())
                {
                    case "equals":
                        header.FindElement(By.CssSelector("input[id='ag-115-input']")).SendKeys(filter.Value);
                        break;
                    case "not equal":
                        header.FindElement(By.CssSelector("input[id='ag-115-input']")).SendKeys(filter.Value);
                        break;
                    case "less than":
                        header.FindElement(By.CssSelector("input[id='ag-115-input']")).SendKeys(filter.Value);
                        break;
                    case "less than or equals":
                        header.FindElement(By.CssSelector("input[id='ag-115-input']")).SendKeys(filter.Value);
                        break;
                    case "greater than":
                        header.FindElement(By.CssSelector("input[id='ag-115-input']")).SendKeys(filter.Value);
                        break;
                    case "greater than or equals":
                        header.FindElement(By.CssSelector("input[id='ag-115-input']")).SendKeys(filter.Value);
                        break;
                    case "in range":
                        header.FindElement(By.CssSelector("input[id='ag-115-input']")).SendKeys(filter.Value);
                        header.FindElement(By.CssSelector("input[id='ag-116-input']")).SendKeys(filter.Value);
                        break;
                    case "blank":
                        break;
                    case "not blank":
                        break;
                    default:
                        //Send Text to input field
                        header.FindElement(By.CssSelector("input[id='ag-115-input']")).SendKeys(filter.Value);
                        break;
                }
                ////Set Sort order
                //if (string.IsNullOrEmpty(filter.SortDirection)) continue;
                //header.FindElement(By.CssSelector("div[class *='InovuaReactDataGrid__column-header--direction-ltr']")).Click();
                //Thread.Sleep(500);
                //var correctDirection = header.FindElement(By.CssSelector("div[class *='InovuaReactDataGrid__column-header--direction-ltr']")).GetAttribute("class").ToLower().Contains(filter.SortDirection.ToLower());
                //if(!correctDirection) header.FindElement(By.CssSelector("div[class *='InovuaReactDataGrid__column-header--direction-ltr']")).Click();
            }
        }

        public void SetUpdateTagRules(string description, List<string> newRuleOrder, string actionToTake)
        {
            //Enter description
            Driver.FindElement(By.Id("saveDescription-input"), Timeout).Clear();
            Driver.FindElement(By.Id("saveDescription-input")).SendKeys(description);
            //Re-order the list (holy crap)
            var seleniumAction = new Actions(Driver);
            for (var i = 1; i < newRuleOrder.Count; i++)
            {
                var itemToMove = Driver.FindElement(By.XPath("//ul[@id='tagrule_sort_list']/li[" + i + "]/div"));
                var positionToMoveTo = Driver.FindElement(By.XPath("//ul[@id='tagrule_sort_list']/li[" + (i + 1) + "]/div"));
                seleniumAction.DragAndDrop(itemToMove, positionToMoveTo).Build().Perform();
                Thread.Sleep(500);
            }
            //Click the appropriate action
            //ClickButton(actionToTake);
        }


        public bool IsAlertPresent()
        {
            Thread.Sleep(500);
            try
            {
                Driver.SwitchTo().Alert();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsWarningWithMessagePresent(string message)
        {
            try
            {
                var warningBox = Driver.FindElement(By.CssSelector("div[class='Toastify__toast-body'][role='alert']"), 1);
                return warningBox.Text.ToLower().Equals(message.ToLower());
            }
            catch
            {
                return false;
            }
        }
        public void EscapeFocus()
        {
            var actionObject = new OpenQA.Selenium.Interactions.Actions(Driver);
            actionObject.SendKeys(Keys.Escape).Perform();

        }
    }
}
