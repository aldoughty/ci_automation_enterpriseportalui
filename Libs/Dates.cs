namespace ci_automation_enterpriseportalui.Libs
{
    internal class Dates
    {
        public static List<string> GetYearList(int startYear, int endYear)
        {
            var yearList = new List<string>();
            for (int year = endYear; year >= startYear; year--)
            {
                yearList.Add(year.ToString());
            }
            return yearList;
        }
        public static List<string> GetYearListWithTextValue(string value, int startYear, int endYear)
        {
            var yearList = new List<string>();

            yearList.Add(value);
            //for debugging
            //Logger.WriteLine(string.Join(Environment.NewLine, value), 3);

            for (int year = endYear; year >= startYear; year--)
            {
                yearList.Add(year.ToString());
                //for debugging
                //Logger.WriteLine(string.Join(Environment.NewLine, year), 3);
            }
            //for debugging
            //Logger.WriteLine("Number of Items: " + yearList.Count.ToString(),3);

            return yearList;
        }
    }
}
