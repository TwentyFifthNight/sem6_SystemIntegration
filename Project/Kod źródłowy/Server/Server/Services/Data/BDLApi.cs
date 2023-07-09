using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Server.Services.Data
{
    public class BDLApi
    {
        public static readonly Dictionary<string, string> industries = new()
        {
            { "GórnictwoIWydobywanie", "215907" },
            { "PrzetwórstwoPrzemysłowe", "214936" },
            { "Wytwarzanie i zaopatrywanie w energię elektryczną, gaz, parę wodną, gorącą wodę i powietrze do układów klimatyzacyjnych", "213786" }
        };

        public static async Task<bool> FormatJSON(string jsonpath, string[] industryNames)
        {
            if (!await UpdateIndustries())
                return false;

            //Sprawdzenie czy wymagana jest aktualizacja danych
            FileInfo jsonFile = new(jsonpath);
            if (jsonFile.Exists)
            {
                bool isUpdateNeeded = false;
                foreach (var industry in industryNames)
                {
                    if (!industries.ContainsKey(industry))
                        continue;
                    FileInfo sourceFile = new(Path.Combine("Assets", industry + ".json"));
                    if (sourceFile.CreationTimeUtc > jsonFile.CreationTimeUtc)
                    {
                        isUpdateNeeded = true;
                        break;
                    }
                }
                if (!isUpdateNeeded)
                    return true;
            }

            //zapisywany obiekt
            Dictionary<string, Dictionary<string, List<Dictionary<string, dynamic>>>>? output = FillDictionary(industryNames);
            if (output == null)
                return false;

            //Serializacja i zapis JSON
            JsonSerializer serializer = new();
            using StreamWriter sw = new(jsonpath);
            using JsonWriter writer = new JsonTextWriter(sw);
            serializer.Serialize(writer, output);
            return true;
        }

        private static async Task<bool> UpdateIndustries()
        {
            bool updatedSuccessfuly = true;
            foreach (var industry in industries)
            {
                string path = Path.Combine("Assets", industry.Key + ".json");
                FileInfo industryFile = new(path);
                if (industryFile.Exists &&
                    (industryFile.CreationTimeUtc.Month >= DateTime.UtcNow.Month &&
                    industryFile.CreationTimeUtc.Year == DateTime.UtcNow.Year))
                {
                    continue;

                }
                if (!await DownloadDataOfIndustry(industry.Key))
                    updatedSuccessfuly = false;
            }
            return updatedSuccessfuly;
        }

        private static async Task<bool> DownloadDataOfIndustry(string industry)
        {
            if (!industries.ContainsKey(industry))
                return false;

            string industryPath = Path.Combine("Assets", industry + ".json");
            try
            {
                dynamic? response = await GetDataByIndustry(BDLApi.industries[industry]);
                JsonSerializer serializer = new();
                using StreamWriter sw = new(industryPath);
                using JsonWriter writer = new JsonTextWriter(sw);
                serializer.Serialize(writer, response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("BDLApi - Error while saving");
                return false;
            }

            return true;
        }

        private static async Task<JObject?> GetDataByIndustry(string industry)
        {
            string URL = "https://bdl.stat.gov.pl/api/v1/data/by-variable/" + industry + "?unit-level=2&page-size=30";
            try
            {
                using HttpClient client = new();
                using HttpResponseMessage res = await client.GetAsync(URL);
                using HttpContent content = res.Content;
                var data = await content.ReadAsStringAsync();

                return data != null ? JsonConvert.DeserializeObject<dynamic>(data) : null;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("BDLApi - Error while fetching");
                return null;
            }
        }

        private static Dictionary<string, Dictionary<string, List<Dictionary<string, dynamic>>>>? FillDictionary(string[] industryNames)
        {
            Dictionary<string, Dictionary<string, List<Dictionary<string, dynamic>>>> output = new();
            foreach (var industry in industryNames)
            {
                if (!industries.ContainsKey(industry))
                    continue;
                string path = Path.Combine("Assets", industry + ".json");
                try
                {
                    using StreamReader sr = new(path);
                    string json = sr.ReadToEnd();
                    var data = JsonConvert.DeserializeObject<dynamic>(json);
                    output[industry] = FormatJSON(data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("BDLApi - Error while filling dictionary");
                    return null;
                }
            }
            return output;
        }

        private static Dictionary<string, List<Dictionary<string, dynamic>>> FormatJSON(JObject json)
        {
            Dictionary<string, List<Dictionary<string, dynamic>>> financialResult = new();
            dynamic? data = json["data"];

            if (data == null)
                return null;

            foreach (var voivodeship in data)
            {
                List<Dictionary<string, dynamic>> yearValues = new();
                foreach (var value in voivodeship.attributes.values)
                {
                    yearValues.Add(new Dictionary<string, dynamic>()
                    {
                        ["value"] = value.val,
                        ["year"] = value.year.ToObject<int>()

                    });
                }
                financialResult[voivodeship.attributes.name.ToString().ToLower()] = yearValues;
            }
            return financialResult;
        }
    }
}
