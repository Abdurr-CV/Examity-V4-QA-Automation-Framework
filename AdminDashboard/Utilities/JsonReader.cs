using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace AdminDashboard.Utilities
{
    public class JsonReader
    {
        public string extractDataLoginCredentials(String tokenName)
        {
            String myJsonString = File.ReadAllText(@"C:\selenium_automation_framework\selenium_automation_framework\AdminDashboard\Utilities\TestDataFiles\LoginCredentials-testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }
    }
}
