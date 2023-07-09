using Newtonsoft.Json;
using System.Xml;

namespace Server.Services.Data
{
    public class XMLDeserializer
    {
        public static string[] polutions = { "SO2", "NO2", "NOx", "CO", "O3", "C6H6", "PM10", "PM25" };

        private struct PreciseValue
        {
            long integerPart = 0;
            short fractionalPart = 0;

            public PreciseValue(double val)
            {
                this.fractionalPart = (short)Math.Round(val % 1 * 10);
                this.integerPart = (int)val;
            }

            public void Add(double val)
            {
                this.integerPart += (int)val;
                this.fractionalPart += (short)Math.Round(val % 1 * 10);
                if (this.fractionalPart >= 10)
                {
                    this.integerPart += 1;
                    this.fractionalPart -= 10;
                }
            }

            public static PreciseValue Add(PreciseValue val1, PreciseValue val2)
            {
                val1.Add(val2.GetValue());
                return val1;
            }

            public double GetValue()
            {
                return this.integerPart + (double)this.fractionalPart / 10;
            }

            public static PreciseValue Parse(string? s)
            {
                if (s == null)
                    return new PreciseValue();
                if (s.Contains('.'))
                {
                    s = s.Replace('.', ',');
                }
                double val = double.Parse(s);
                PreciseValue ret = new PreciseValue(val);
                return ret;
            }
        }


        public static bool FormatXMLToJSON(string xmlpath, string jsonpath, string[] pollutionNames)
        {
            XmlDocument doc = new();

            FileInfo jsonFile = new(jsonpath);
            FileInfo xmlFile = new(xmlpath);

            if (jsonFile.Exists)
            {
                if (!xmlFile.Exists || xmlFile.LastWriteTimeUtc < jsonFile.LastWriteTimeUtc)
                    return true;
            }
            else if (!xmlFile.Exists)
                return false;

            try
            {
                doc.Load(xmlpath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("XMLDeserializer - Error while reading file");
                return false;
            }

            //zapisywany obiekt
            Dictionary<string, Dictionary<string, List<Dictionary<string, dynamic>>>> json = new();

            foreach (string pollutionName in pollutionNames)
            {
                XmlNodeList nodeList = doc.GetElementsByTagName(pollutionName);

                //pusty node
                if (nodeList.Count == 0)
                    continue;

                //zmienna przechowuje rok i województwo jako klucz oraz sumę średnich i liczbę pomiarów jako wartość
                Dictionary<Tuple<int, string>, Tuple<PreciseValue, int>> meanValues = FillDictionary(nodeList);

                json[pollutionName] = CreateVoivodeshipDict(meanValues);
            }

            try
            {
                //Serializacja i zapis JSON
                JsonSerializer serializer = new();
                using StreamWriter sw = new(jsonpath);
                using JsonWriter writer = new JsonTextWriter(sw);
                serializer.Serialize(writer, json);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("XMLDeserializer - Error while saving file");
            }

            return true;
        }


        private static Dictionary<Tuple<int, string>, Tuple<PreciseValue, int>> FillDictionary(XmlNodeList nodeList)
        {
            Dictionary<Tuple<int, string>, Tuple<PreciseValue, int>> meanValues = new();
            foreach (XmlNode pollution in nodeList)
            {
                //jednostki
                if (pollution["Rok"]?.InnerText == "(-)")
                {
                    continue;
                }

                Tuple<int, string> index = new(int.Parse(pollution["Rok"].InnerText), pollution["Województwo"].InnerText);
                if (meanValues.ContainsKey(index))
                {
                    Tuple<PreciseValue, int> values = new(PreciseValue.Add(meanValues[index].Item1,
                        PreciseValue.Parse(pollution["Średnia"]?.InnerText)),
                        meanValues[index].Item2 + 1);
                    meanValues[index] = values;
                }
                else
                {
                    meanValues[index] = new Tuple<PreciseValue, int>(PreciseValue.Parse(pollution["Średnia"]?.InnerText), 1);
                }
            }
            return meanValues;
        }


        private static Dictionary<string, List<Dictionary<string, dynamic>>> CreateVoivodeshipDict(Dictionary<Tuple<int, string>, Tuple<PreciseValue, int>> meanValues)
        {
            Dictionary<string, List<Dictionary<string, dynamic>>> output = new();

            string currentVoivodeship = "";

            List<Dictionary<string, dynamic>> row = new();

            var sortedByVoivodeship = from entry in meanValues orderby entry.Key.Item2 ascending select entry;
            foreach (var year_voivodeship in sortedByVoivodeship)
            {
                //tylko dziesięć ostatnich lat
                if (year_voivodeship.Key.Item1 < (meanValues.Keys.Last().Item1 - 10))
                    continue;

                //zapis wyników jednego województwa
                if (currentVoivodeship != year_voivodeship.Key.Item2)
                {
                    if (currentVoivodeship != "")
                    {
                        output[currentVoivodeship] = row;
                        row = new List<Dictionary<string, dynamic>>();
                    }
                    currentVoivodeship = year_voivodeship.Key.Item2;
                }
                double mean = double.Parse((year_voivodeship.Value.Item1.GetValue() / year_voivodeship.Value.Item2).ToString("0.0"));

                Dictionary<string, dynamic> value = new()
                {
                    ["mean"] = mean,
                    ["year"] = year_voivodeship.Key.Item1
                };
                row.Add(value);

                if (sortedByVoivodeship.Last().Equals(year_voivodeship))
                {
                    output[currentVoivodeship] = row;
                }
            }
            return output;
        }
    }
}
