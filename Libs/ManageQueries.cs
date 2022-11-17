namespace ci_automation_enterpriseportalui.Libs
{
    public static class ManageQueries
    {
        public static List<string> GetTagEntities()
        {
            const string command = "SELECT Name FROM taggingUI.Entity WHERE Active = 1";
            var dt = DataBaseExecuter.ExecuteCommand("SQL", SecretsManager.SQLConnectionString(), command);
            return (from DataRow dataRow in dt.Rows select dataRow["Name"].ToString()).ToList();
        }
        public static List<string> GetEntitySeason(string entity)
        {
            var command = $@"SELECT s.Name FROM taggingUI.EntitySeason a 
                          JOIN taggingUi.Entity e ON e.Id = a.EntityId 
                          JOIN taggingUI.Season s ON s.Id = a.SeasonId ";
            //Active flag is not being used right now
            //WHERE s.Active=1 AND e.Active=1 AND e.Name = '{entity}'";

            var dt = DataBaseExecuter.ExecuteCommand("SQL", SecretsManager.SQLConnectionString(), command);
            return (from DataRow dataRow in dt.Rows select dataRow["Name"].ToString()).ToList();
        }
        public static List<string> GetEntitySeasonTagDimension(string entity, string season)
        {
            var command = $@"SELECT d.Name FROM taggingUI.EntitySeasonDimension a
                            JOIN taggingUI.Entity e ON e.Id = a.EntityId
                            JOIN taggingUI.Season s ON s.Id = a.SeasonId
                            JOIN taggingUI.Dimension d ON d.Id = a.DimensionId 
                            WHERE e.Name = '{entity}' AND s.Name = '{season}'";
            //Active flag is not being used right now
            //WHERE e.Active = 1 AND s.Active = 1 AND d.Active = 1 AND e.Name = '{entity}' AND s.Name = '{season}'";

            var dt = DataBaseExecuter.ExecuteCommand("SQL", SecretsManager.SQLConnectionString(), command);
            return (from DataRow dataRow in dt.Rows select dataRow["Name"].ToString()).ToList();
        }
        public static List<string> GetEntitySeasonDimensionHierarchy(string entity, string season, string dimension)
        {
            var command = $@"SELECT h.Name FROM taggingUI.EntitySeasonDimensionHierarchy a
                            JOIN taggingUI.Entity e ON e.Id = a.EntityId
                            JOIN taggingUI.Season s ON s.Id = a.SeasonId
                            JOIN taggingUI.Dimension d ON d.Id = a.DimensionId
                            JOIN taggingUI.Hierarchy h ON h.Id = a.HierarchyId
                            WHERE e.Name='{entity}' AND s.Name='{season}'AND d.name='{dimension}'";
            //Active flag is not being used right now
            //WHERE e.Active=1 AND s.Active=1 AND d.Active=1 AND h.Active=1 AND e.Name='{entity}' AND s.Name='{season}'AND d.name='{dimension}'";

            var dt = DataBaseExecuter.ExecuteCommand("SQL", SecretsManager.SQLConnectionString(), command);
            return (from DataRow dataRow in dt.Rows select dataRow["Name"].ToString()).ToList();
        }
        public static List<string> GetTagRule(string entity, string season, string dimension, string hierarchy)
        {
            var command = $@"SELECT a.Name FROM taggingUI.TagRule a
                            JOIN taggingUI.Entity e ON e.Id = a.EntityId
                            JOIN taggingUI.Season s ON s.Id = a.SeasonId
                            JOIN taggingUI.Dimension d ON d.Id = a.DimensionId
                            LEFT JOIN taggingUI.Hierarchy h ON h.Id = a.HierarchyId
                            WHERE e.name='{entity}' AND s.Name='{season}' AND d.Name='{dimension}' AND ISNULL(h.Name,'')='{hierarchy}'";
            //Active flag is not being used right now
            //WHERE a.Active=1 AND e.Active=1 AND s.Active=1 AND ISNULL(h.Active,1)=1 AND e.name='{entity}' AND s.Name='{season}' AND d.Name='{dimension}' AND ISNULL(h.Name,'')='{hierarchy}'";

            var dt = DataBaseExecuter.ExecuteCommand("SQL", SecretsManager.SQLConnectionString(), command);
            return (from DataRow dataRow in dt.Rows select dataRow["Name"].ToString()).ToList();
        }

        public static void RemoveTagRule(string ruleName)
        {
            var command = $@"DELETE FROM taggingUI.TagRuleFilter WHERE TagRuleId=(SELECT Id FROM taggingUI.TagRule WHERE Name='{ruleName}')";
            DataBaseExecuter.ExecuteCommand("SQL", SecretsManager.SQLConnectionString(), command);
            command = $@"DELETE FROM taggingUI.TagRuleSort WHERE TagRuleId=(SELECT Id FROM taggingUI.TagRule WHERE Name='{ruleName}')";
            DataBaseExecuter.ExecuteCommand("SQL", SecretsManager.SQLConnectionString(), command);
            command = $@"DELETE FROM taggingUI.TagRule WHERE Name='{ruleName}'";
            DataBaseExecuter.ExecuteCommand("SQL", SecretsManager.SQLConnectionString(), command);
        }
    }
}
