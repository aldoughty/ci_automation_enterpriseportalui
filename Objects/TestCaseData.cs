namespace ci_automation_enterpriseportalui.Objects
{
    public class TestCaseData
    {
        public List<ReflectionData> Tests;

        public class ReflectionData
        {
            public string NameSpace { get; set; }
            public string Function { get; set; }
            public string MethodName { get; set; }
            public ReflectionData(string nameSpace, string function, string methodName)
            {
                NameSpace = nameSpace;
                Function = function;
                MethodName = methodName;
            }
        }

        public TestCaseData()
        {
            string whatToDo = "FunctionalTests"; //FunctionalTests = All....otherwise pick a class from Functional Tests
            Tests = new List<ReflectionData>();
            string nameSpace = "ci_automation_enterpriseportalui";
            Type[] types = Assembly.Load(nameSpace).GetTypes().Where(x => x.FullName.Contains(whatToDo)).ToArray(); 
            foreach (var type in types)
            {
                foreach (var method in type.GetMethods().Where(x => x.ReturnType.Name.Equals("Void")))
                {
                    Tests.Add(new ReflectionData(nameSpace, type.FullName, method.Name));
                }
            }
        }
        
    }
}
