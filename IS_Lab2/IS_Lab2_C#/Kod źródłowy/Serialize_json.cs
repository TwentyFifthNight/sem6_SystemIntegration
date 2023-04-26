
using Newtonsoft.Json;

namespace Lab2
{
    internal class Serialize_json
    {
        public static void run(Deserialize_json deserializeData, string filelocation)
        {
            Console.WriteLine("let's serialize JSON");

            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;

            List<Dictionary<string, dynamic>> data = new List<Dictionary<string, dynamic>>();

            foreach (var dep in deserializeData.data)
            {
                var powiat = "-";
                if (dep.ContainsKey("Powiat"))
                {
                    powiat = dep["Powiat"];
                }

                var record = new Dictionary<string, dynamic>();

                string[] fieldList = {"Kod_TERYT", "Województwo", "Powiat", "typ_JST", "nazwa_urzędu_JST", "miejscowość", "telefon_z_numerem_kierunkowym"};

                foreach(var field in fieldList)
                {
                    if (field == "Powiat")
                        record.Add(field, powiat);
                    else if (field == "telefon_z_numerem_kierunkowym")
                        record.Add(field, (dep["telefon kierunkowy"].ToString() + '-' + dep["telefon"].ToString()));
                    else
                        record.Add(field, dep[field]);
                }
                data.Add(record);
            }

            using (StreamWriter sw = new StreamWriter(filelocation))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {

                serializer.Serialize(writer, data);
            }

            Console.WriteLine("it is done");
        }
    }
}
