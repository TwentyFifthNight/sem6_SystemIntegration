using Newtonsoft.Json;

namespace Lab2
{
    internal class Deserialize_json
    {
        public List<Dictionary<string, dynamic>> data = new List<Dictionary<string, dynamic>>();

        public Deserialize_json(string filename)
        {
            Console.WriteLine("let's deserialize something");
            using (StreamReader sr = new StreamReader(filename))
            {
                string json = sr.ReadToEnd();
                data = JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(json);
            }
            Console.WriteLine("it is done");
        }

        public void Somestats()
        {
            var example_stat = 0;
            var dictionary = new Dictionary<string, Dictionary<string, int>>();

            foreach (var record in data)
            {
                if (record["typ_JST"] == "GM" && record["Województwo"] == "dolnośląskie")
                    example_stat++;


                var wojewodztwo = record["Województwo"].Replace(" ", "");

                if (!dictionary.ContainsKey(wojewodztwo))
                {
                    var dict = new Dictionary<string, int>();
                    dictionary[wojewodztwo] = dict;
                }

                if (!dictionary[wojewodztwo].ContainsKey(record["typ_JST"]))
                {
                    dictionary[wojewodztwo][record["typ_JST"]] = 0;
                }
                dictionary[wojewodztwo][record["typ_JST"]]++;
            }

            Console.WriteLine("Liczba urzędów miejskich w województwie dolnośląskim: " + ' ' + example_stat);
            Console.WriteLine();

            foreach (var dict in dictionary)
            {
                Console.WriteLine("Województwo: " + dict.Key);
                foreach (var record in dict.Value)
                {
                    Console.WriteLine("Liczba wystąpień urzędów typu " + record.Key + ": " + record.Value);
                }
                Console.WriteLine();
            }
        }
    }
}
