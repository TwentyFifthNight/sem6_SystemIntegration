using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace Server.Services.Data
{
    public class DataServiceImpl : IDataService
    {
        public async Task<string>? GetIndustriesData(string voivodeship)
        {
            string industriesPath = Path.Combine("Assets", "Industries.json");
            //sprawdzenie czy plik z danymi przemysłów istnieje, lub został stworzony
            if (await BDLApi.FormatJSON(industriesPath, BDLApi.industries.Keys.ToArray<string>()))
            {
                try
                {
                    using StreamReader sr = new(industriesPath);
                    string json = sr.ReadToEnd();
                    var data = JsonConvert.DeserializeObject<dynamic>(json);

                    if (data == null)
                        return null;

                    //dane wybranego województwa dla każdego z przemysłów
                    Dictionary<string, Dictionary<string, List<Dictionary<string, dynamic>>>> output = new();
                    foreach (var industry in data)
                    {
                        //elementy listy postaci {year: rok, value: wynik finansowy}
                        List<Dictionary<string, dynamic>> voivodeshipDataList = new();

                        voivodeshipDataList = data[industry.Name][voivodeship].ToObject<List<Dictionary<string, dynamic>>>();
                        Dictionary<string, List<Dictionary<string, dynamic>>> voivodeshipData = new()
                        {
                            [voivodeship] = voivodeshipDataList
                        };

                        output[industry.Name] = voivodeshipData;
                    }

                    return JsonConvert.SerializeObject(output);
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("DataService - Error while reading industrie");
                }
            }
            return null;
        }

        public string? GetPollutionsData(string voivodeship)
        {
            string xmlpath = Path.Combine("Assets", "Statystyki.xml");
            string pollutionsPath = Path.Combine("Assets", "Pollutions.json");

            //sprawdzenie czy plik z danymi zanieczyszczeń istnieje, lub został stworzony
            if (XMLDeserializer.FormatXMLToJSON(xmlpath, pollutionsPath, XMLDeserializer.polutions))
            {
                try
                {
                    using StreamReader sr = new(pollutionsPath);
                    string json = sr.ReadToEnd();
                    var data = JsonConvert.DeserializeObject<dynamic>(json);

                    if (data == null)
                        return null;

                    //dane wybranego województwa dla każdego z zanieczyszczeń
                    Dictionary<string, Dictionary<string, List<Dictionary<string, dynamic>>>> output = new();
                    foreach (var industry in data)
                    {
                        //elementy listy postaci {year: rok, mean: średnie roczne stężenie}
                        List<Dictionary<string, dynamic>> voivodeshipDataList = new();

                        voivodeshipDataList = data[industry.Name][voivodeship].ToObject<List<Dictionary<string, dynamic>>>();
                        Dictionary<string, List<Dictionary<string, dynamic>>> voivodeshipData = new()
                        {
                            [voivodeship] = voivodeshipDataList
                        };

                        output[industry.Name] = voivodeshipData;
                    }
                    return JsonConvert.SerializeObject(output);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("DataService - Error while reading pollutions");
                }
            }
            return null;
        }
    }
}
