namespace ci_automation_enterpriseportalui.Objects
{
    public class GeneralTableAttributes
    {
        public List<Column> Columns;
        public List<Dictionary<string, string>> Data;
        public List<Filter> Filters;

        public class Column
        {
            public string Name;
            public string HeaderName;
            public string Type;
            public bool IsFilterable;
            public bool IsEditiable;
        }
        public class Filter
        {
            public string Name;
            public string HeaderName;
            public string Operator;
            public string Value;
            public string SortDirection;

            public string GetFilterUiOperator()
            {
                switch (Operator.ToLower())
                {
                    case "equals":
                        return $@"Equals";
                    case "not equals":
                        return $@"Not equal";
                    case "less than":
                        return $@"Less than";
                    case "less than or equals":
                        return $@"Less than or equals";
                    case "greater than":
                        return $@"Greater than or equals";
                    case "in range":
                        return $@"In range";
                    case "blank":
                        return "Blank";
                    case "not blank":
                        return "Not blank";
                    default:
                        return "";
                }
            }
        }

        public GeneralTableAttributes()
        {
            Columns = GetColumns();
            Data = GetData();
            Filters = new List<Filter>();

        }
        public GeneralTableAttributes(string ruleName)
        {
            Columns = GetColumns();
            Filters = GetRuleFilter(ruleName);
            Data = GetData();
        }
        public List<Column> GetColumns()
        {
            var command = $@"SELECT a.field,a.Header,b.Name,a.Filterable,a.Editable,a.IsCurrency FROM taggingUI.ColumnDefinition a
                            JOIN taggingUI.ColumnType b ON b.Id = a.ColumnTypeId";

            var dt = DataBaseExecuter.ExecuteCommand("SQL",SecretsManager.SQLConnectionString(), command);
            return (from DataRow row in dt.Rows select new Column { Name = row["Field"].ToString(), HeaderName = row["Header"].ToString(), Type = Convert.ToBoolean(row["IsCurrency"]) ? "money" : row["Name"].ToString(), IsEditiable = Convert.ToBoolean(row["Editable"]), IsFilterable = Convert.ToBoolean(row["Filterable"]) }).ToList();
        }

        public List<Dictionary<string, string>> GetData()
        {
            //Note that we will eventually need to figure out how the columns are ordered on the UI and change this accordingly.  For now I have hard coded the order with the Select statement
            //We will also need to swap out the SQL column with the UI column once we know the order
            var command = $@"SELECT 
                            AppliedDate[Applied Date],
                            ChangeFlag[Change Flag],
                            AssignmentType[Assignment Type],
                            RuleName[Rule Name],
                            NativeCode2[Native Code 2],
                            NativeDescription[Native Description],
                            NativeCode[Native Code],
                            NativeDescription2[Native Description 2],
                            NativeCode3[Native Code 3],
                            AssignedDataTag[Assigned Data Tag],
                            FORMAT(CAST(TotalRevenue AS DECIMAL(18,2)),'C')[Total Revenue],
                            [Count],
                            ConflictCount[Conflict Count]
                            FROM taggingUI.TagData 
                            WHERE 1=1 {GetWhereAndOrderByClauseFromFilter()}";

            var dt = DataBaseExecuter.ExecuteCommand("SQL", SecretsManager.SQLConnectionString(), command);
            var columns = dt.Columns;
            return (from DataRow row in dt.Rows select columns.Cast<DataColumn>().ToDictionary(column => column.ColumnName, column => row[column.ColumnName].ToString())).ToList();
        }

        public List<Filter> GetRuleFilter(string ruleName)
        {
            var command = $@"SELECT tr.Name,c.Field,c.Header,f.Operator,f.Value,ISNULL(s.Direction,'')[Direction]
                            FROM taggingUI.TagRule tr
                            JOIN taggingUI.TagRuleFilter f ON f.TagRuleId = tr.Id
                            JOIN taggingUI.ColumnDefinition c ON c.Id = f.ColumnDefinitionId
                            LEFT JOIN taggingUI.TagRuleSort s ON s.TagRuleId = tr.Id AND s.ColumnDefinitionId = f.ColumnDefinitionId
                            WHERE tr.Name='{ruleName}'";
            var dt = DataBaseExecuter.ExecuteCommand("SQL", SecretsManager.SQLConnectionString(), command);
            return (from DataRow row in dt.Rows select new Filter { Name = row["Field"].ToString(), HeaderName = row["Header"].ToString(), Operator = row["Operator"].ToString(), Value = row["Value"].ToString(), SortDirection = row["Direction"].ToString() }).ToList();
        }

        public string GetWhereAndOrderByClauseFromFilter()
        {
            //Where
            var results = Filters.Aggregate("", (current, filter) => current + $@" AND {filter.Name} {GetSqlOperatorWithValue(filter.Operator, filter.Value)} ");
            //Order By
            var sortFilters = Filters.Where(x => !string.IsNullOrEmpty(x.SortDirection)).ToList();
            if (sortFilters.Count <= 0) return results;

            results += " ORDER BY ";
            results = sortFilters.Aggregate(results, (current, filter) => current + $@"{filter.Name} {filter.SortDirection} ,");
            results = results.Substring(0, results.Length - 1);

            return results;
        }

        public string GetSqlOperatorWithValue(string tableOperator, string value)
        {
            switch (tableOperator.ToLower())
            {
                case "equals":
                    return $@" = '{value}'";
                case "notequals":
                    return $@" != '{value}'";
                case "gte":
                    return $@" >= {value}";
                case "gt":
                    return $@" > {value}";
                case "lte":
                    return $@" <= {value}";
                case "lt":
                    return $@" < {value}";
                case "empty":
                    return " = ''";
                case "notempty":
                    return " != ''";
                case "contains":
                    return $@" LIKE '%{value}%'";
                case "notcontains":
                    return $@" NOT LIKE '%{value}%'";
                case "startswith":
                    return $@" LIKE '{value}%'";
                case "endswith":
                    return $@" LIKE '%{value}'";
                case "inlist":
                    return $@" IN ('{value.Replace(",", "','")}')";
                case "inrange":
                    var startEnd = value.Split(',');
                    return $@" BETWEEN {startEnd[0].Replace("start:", "")} AND {startEnd[1].Replace("end:", "")}";
                case "notinrange":
                    startEnd = value.Split(',');
                    return $@" NOT BETWEEN {startEnd[0].Replace("start:", "")} AND {startEnd[1].Replace("end:", "")}";
                default:
                    return "";
            }
        }
    }
}
