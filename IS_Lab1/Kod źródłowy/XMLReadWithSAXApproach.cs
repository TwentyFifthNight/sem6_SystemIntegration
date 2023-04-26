using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace IS_Lab1_XML
{
    internal class XMLReadWithSAXApproach
    {
        public static void Read(string filepath)
        {
            // konfiguracja początkowa dla XmlReadera
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;
            settings.IgnoreProcessingInstructions = true;
            settings.IgnoreWhitespace = true;

            // odczyt zawartości dokumentu
            XmlReader reader = XmlReader.Create(filepath, settings);
            // zmienne pomocnicze
            int count = 0;
            string postac = "";
            string sc = "";
            reader.MoveToContent();

            // analiza każdego z węzłów dokumentu
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "produktLeczniczy")
                {
                    postac = reader.GetAttribute("postac");
                    sc = reader.GetAttribute("nazwaPowszechnieStosowana");
                    if (postac == "Krem" && sc == "Mometasoni furoas")
                        count++;
                }
            }
            Console.WriteLine("Liczba produktów leczniczych w postaci kremu, których " +
                "jedyną substancją czynną jest Mometasoni furoas {0}", count);




            //Ilość preparatów leczniczych o takiej samie nazwie powszechnej, pod różnymi postaciami (Zad 1.2.4)
            reader = XmlReader.Create(filepath, settings);
            reader.MoveToContent();

            
            static IEnumerable<(string postac, string nazwaPowszechna)> GetProductAttributes(XmlReader reader)
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "produktLeczniczy")
                    {
                        string postac = reader.GetAttribute("postac");
                        string nazwaPowszechna = reader.GetAttribute("nazwaPowszechnieStosowana");
                        yield return (postac, nazwaPowszechna);
                    }
                }
            }

            var sumPreparaty = GetProductAttributes(reader)
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


        //Podmioty z największą liczbą kremów i tabletek
        public static void maxKremITabletki(string filepath)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;
            settings.IgnoreProcessingInstructions = true;
            settings.IgnoreWhitespace = true;

            XmlReader reader = XmlReader.Create(filepath, settings);
            reader.MoveToContent();

            static IEnumerable<(string postac, string podmiotOdpowiedzialny)> GetProductAttributes(XmlReader reader)
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "produktLeczniczy")
                    {
                        string postac = reader.GetAttribute("postac");

                        string podmiotOdpowiedzialny = reader.GetAttribute("podmiotOdpowiedzialny");

                        yield return (postac, podmiotOdpowiedzialny);
                    }
                }
            }

            //Krem
            var productCount = GetProductAttributes(reader)
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
            reader = XmlReader.Create(filepath, settings);
            reader.MoveToContent();

            productCount = GetProductAttributes(reader)
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
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;
            settings.IgnoreProcessingInstructions = true;
            settings.IgnoreWhitespace = true;

            XmlReader reader = XmlReader.Create(filepath, settings);
            reader.MoveToContent();

            static IEnumerable<(string postac, string podmiotOdpowiedzialny)> GetProductAttributes(XmlReader reader)
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "produktLeczniczy")
                    {
                        string postac = reader.GetAttribute("postac");

                        string podmiotOdpowiedzialny = reader.GetAttribute("podmiotOdpowiedzialny");

                        yield return (postac, podmiotOdpowiedzialny);
                    }
                }
            }

            var productCount = GetProductAttributes(reader)
                .Where(x => x.postac == "Krem")
                .GroupBy(y => y.podmiotOdpowiedzialny)
                .Select(z => new {
                    Podmiot = z.Key,
                    Count = z.Count()
                })
                .OrderByDescending(cnt => cnt.Count);


            var result = productCount.ToList();

            for (var i = 0; i < 3; i++){
                Console.WriteLine("Podmiot: {0}, Ilosc kremów: {1}", result[i].Podmiot, result[i].Count);
            }
        }
    }
}
