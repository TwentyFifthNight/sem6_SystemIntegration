using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Xml;

namespace IS_Lab1_XML
{
    internal class XMLReadWithDOMApproach
    {
        public static void Read(string filepath)
        {
            // odczyt zawartości dokumentu
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            string postac;
            string sc;
            int count = 0;
            var drugs = doc.GetElementsByTagName("produktLeczniczy");

            foreach (XmlNode drug in drugs)
            {
                postac = drug.Attributes.GetNamedItem("postac").Value;
                sc = drug.Attributes.GetNamedItem("nazwaPowszechnieStosowana").Value;
                if (postac == "Krem" && sc == "Mometasoni furoas")
                    count++;
            }

            Console.WriteLine("Liczba produktów leczniczych w postaci kremu, " +
                "których jedyną substancją czynną jest Mometasoni furoas {0}", count);



            //Ilość preparatów leczniczych o takiej samie nazwie powszechnej, pod różnymi postaciami (Zad 1.2.4)
            static IEnumerable<(string postac, string nazwaPowszechna)> GetProductAttributes(XmlNodeList drugs)
            {

                foreach (XmlNode drug in drugs)
                {
                    string postac = drug.Attributes.GetNamedItem("postac").Value;
                    string nazwaPowszechna = drug.Attributes.GetNamedItem("nazwaPowszechnieStosowana").Value;
                    yield return (postac, nazwaPowszechna);
                }
            }

            var sumPreparaty = GetProductAttributes(drugs)
                .Distinct()
                .GroupBy(y => y.nazwaPowszechna)
                .Select(z => new
                {
                    Podmiot = z.Key,
                    Count = z.Count()
                })
                .Where(x => x.Count > 1)
                .OrderBy(podm => podm.Podmiot)
                .Count();
            
            Console.WriteLine("Liczba preparatów leczniczych o takiej samie nazwie powszechnej, pod różnymi postaciami: {0}", sumPreparaty);

        }



        public static void maxKremITabletki(string filepath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            XmlNodeList drugs = doc.GetElementsByTagName("produktLeczniczy");

            static IEnumerable<(string postac, string podmiotOdpowiedzialny)> GetProductAttributes(XmlNodeList drugs)
            {

                foreach (XmlNode drug in drugs)
                {
                    string postac = drug.Attributes.GetNamedItem("postac").Value;
                    string podmiotOdpowiedzialny = drug.Attributes.GetNamedItem("podmiotOdpowiedzialny").Value;
                    yield return (postac, podmiotOdpowiedzialny);
                }
            }

            //Krem
            var productCount = GetProductAttributes(drugs)
                .Where(x => x.postac == "Krem")
                .GroupBy(y => y.podmiotOdpowiedzialny)
                .Select(z => new{
                    Podmiot = z.Key,
                    Count = z.Count()
                })
                .OrderByDescending(cnt => cnt.Count);

            var result = productCount.First();
            Console.WriteLine("Podmiot z największą liczbą kremów:\nPodmiot: {0}", result.Podmiot);

            //Tabletki
            productCount = GetProductAttributes(drugs)
                .Where(x => x.postac == "Tabletki")
                .GroupBy(y => y.podmiotOdpowiedzialny)
                .Select(z => new {
                    Podmiot = z.Key,
                    Count = z.Count()
                })
                .OrderByDescending(cnt => cnt.Count);

            result = productCount.First();
            Console.WriteLine("Podmiot z największą liczbą tabletek:\nPodmiot: {0}", result.Podmiot);
        }


        //3 pierwsze podmioty pod względem ilości kremów
        public static void trzyMaxKrem(string filepath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            XmlNodeList drugs = doc.GetElementsByTagName("produktLeczniczy");

            static IEnumerable<(string postac, string podmiotOdpowiedzialny)> GetProductAttributes(XmlNodeList drugs)
            {
                foreach (XmlNode drug in drugs)
                {
                    string postac = drug.Attributes.GetNamedItem("postac").Value;
                    string podmiotOdpowiedzialny = drug.Attributes.GetNamedItem("podmiotOdpowiedzialny").Value;
                    yield return (postac, podmiotOdpowiedzialny);
                
                }
            }

            var productCount = GetProductAttributes(drugs)
                .Where(x => x.postac == "Krem")
                .GroupBy(y => y.podmiotOdpowiedzialny)
                .Select(z => new {
                    Podmiot = z.Key,
                    Count = z.Count()
                })
                .OrderByDescending(cnt => cnt.Count);

            var result = productCount.ToList();
            for (var i = 0; i < 3; i++)
            {
                Console.WriteLine("Podmiot: {0}, Ilosc kremów: {1}", result[i].Podmiot, result[i].Count);
            }
        }



        public static void identyfikacja(string filepath)
        {
            //Podanie przez użytkownika substancji czynnych
            Console.WriteLine("\nPodaj ile substancji czynnych chcesz wprowadzić:");
            int ilosc = 0;
            bool isNumeric;
            do
            {
                string input = Console.ReadLine();
                isNumeric = int.TryParse(input, out ilosc);

                if (!isNumeric)
                    Console.WriteLine("Podaj liczbę!");
            } while (ilosc < 1 && !isNumeric);

            HashSet<string> chosenSubstances = new HashSet<string>();
            while (ilosc > 0)
            {
                Console.WriteLine("Podaj substancję:");
                string substance = Console.ReadLine();

                if (chosenSubstances.Contains(substance))
                {
                    Console.WriteLine("Ta substancja została już podana!");
                }
                else if (substance != "")
                {
                    chosenSubstances.Add(substance);
                    ilosc--;
                }
                else
                {
                    Console.WriteLine("Błędne dane!");
                }

            }


            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            XmlNodeList nodeList = doc.GetElementsByTagName("produktLeczniczy");

            var products = new List<Tuple<string, HashSet<String>>>();

            //wypełnianie zmiennej danymi
            foreach (XmlNode product in nodeList)
            {
                HashSet<String> substances = new HashSet<string>();
                string id = product.Attributes.GetNamedItem("id").Value;

                foreach (XmlNode substance in product["substancjeCzynne"])
                {
                    substances.Add(substance.InnerText);
                }
                products.Add(new Tuple<string, HashSet<String>>(id, substances));
            }


            bool contains;
            bool atLeastOnce = false;
            foreach (Tuple<string, HashSet<String>> tuple in products)
            {
                contains = true;
                foreach (string substance in chosenSubstances)
                {
                    if (!tuple.Item2.Contains(substance))
                    {
                        contains = false;
                    }
                }
                if (contains)
                {
                    Console.WriteLine("Id produktu: {0}", tuple.Item1);
                    atLeastOnce = true;
                }
            }
            if (!atLeastOnce)
                Console.WriteLine("Brak produktów o podanych substancjach");

        }

    }
}