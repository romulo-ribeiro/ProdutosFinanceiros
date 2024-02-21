using Newtonsoft.Json;

namespace ProdutosFinanceiros.Infra.Helpers
{
    public static class InfraHelper
    {
        public static string GetConnectionString(string value)
        {
            string envFilePath = "../.env";
            string jsonString = File.ReadAllText(envFilePath);
            var json = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
            Console.WriteLine(json[value]);
            return json[value];
        }
    }
}