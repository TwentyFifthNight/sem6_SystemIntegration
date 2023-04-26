using System.Xml.XPath;
using System.Xml;
using System;

namespace IS_Lab1_XML
{
    internal class XMLReadWithXLSTDOM
    {
        public static void Read(string filepath)
        {
            XPathDocument document = new XPathDocument(filepath);
            XPathNavigator navigator = document.CreateNavigator();
            XmlNamespaceManager manager = new XmlNamespaceManager(navigator.NameTable);
            manager.AddNamespace("x","http://rejestrymedyczne.ezdrowie.gov.pl/rpl/eksport-danych-v1.0");

            XPathExpression query = navigator.Compile("/x:produktyLecznicze/x:produktLeczniczy[@postac='Krem' and @nazwaPowszechnieStosowana='Mometasoni furoas']");
            query.SetContext(manager);
            int count = navigator.Select(query).Count;

            Console.WriteLine("Liczba produktów leczniczych w postaci kremu, których " +
                "jedyną substancją czynną jest Mometasoni furoas {0}", count );


            //Ilość preparatów leczniczych o takiej samie nazwie powszechnej, pod różnymi postaciami (Zad 1.2.4)
            static IEnumerable<(string postac, string nazwaPowszechna)> GetProductAttributes(XPathExpression query, XPathNavigator navigator, XmlNamespaceManager manager)
            {
                query = navigator.Compile("/x:produktyLecznicze/x:produktLeczniczy/@postac");
                query.SetContext(manager);
                XPathNodeIterator postaci = navigator.Select(query);

                query = navigator.Compile("//x:produktyLecznicze/x:produktLeczniczy/@nazwaPowszechnieStosowana");
                query.SetContext(manager);
                XPathNodeIterator nazwyPowszechne = navigator.Select(query);
                
                while (postaci.MoveNext() && nazwyPowszechne.MoveNext())
                {
                    string postac = postaci.Current.ToString();
                    string nazwaPowszechna = nazwyPowszechne.Current.ToString();
                    yield return (postac, nazwaPowszechna);
                    
                }
            }
            
            var sumPreparaty = GetProductAttributes(query, navigator, manager)
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
            XPathDocument document = new XPathDocument(filepath);
            XPathNavigator navigator = document.CreateNavigator();
            XmlNamespaceManager manager = new XmlNamespaceManager(navigator.NameTable);
            manager.AddNamespace("x", "http://rejestrymedyczne.ezdrowie.gov.pl/rpl/eksport-danych-v1.0");


            static IEnumerable<string> GetProductAttributes(XPathNodeIterator products)
            {
                while (products.MoveNext())
                {
                    yield return products.Current.GetAttribute("podmiotOdpowiedzialny", "");
                }
            }

            //Krem
            XPathExpression query = navigator.Compile("/x:produktyLecznicze/x:produktLeczniczy[@postac='Krem']");
            query.SetContext(manager);
            XPathNodeIterator Krem = navigator.Select(query);

            var productCount = GetProductAttributes(Krem)
                .GroupBy(y => y)
                .Select(z => new {
                    Podmiot = z.Key,
                    Count = z.Count()
                })
                .OrderByDescending(cnt => cnt.Count);

            var result = productCount.First();
            Console.WriteLine("Podmiot z największą liczbą kremów:\nPodmiot: {0}", result.Podmiot);
            
            //Tabletki
            query = navigator.Compile("/x:produktyLecznicze/x:produktLeczniczy[@postac='Tabletki']");
            query.SetContext(manager);
            XPathNodeIterator Tabletki = navigator.Select(query);

            productCount = GetProductAttributes(Tabletki)
                .GroupBy(y => y)
                .Select(z => new {
                    Podmiot = z.Key,
                    Count = z.Count()
                })
                .OrderByDescending(cnt => cnt.Count);

            result = productCount.First();
            Console.WriteLine("Podmiot z największą liczbą Tabletek:\nPodmiot: {0}", result.Podmiot);
        }

        //3 pierwsze podmioty pod względem ilości kremów
        public static void trzyMaxKrem(string filepath)
        {
            XPathDocument document = new XPathDocument(filepath);
            XPathNavigator navigator = document.CreateNavigator();
            XmlNamespaceManager manager = new XmlNamespaceManager(navigator.NameTable);
            manager.AddNamespace("x", "http://rejestrymedyczne.ezdrowie.gov.pl/rpl/eksport-danych-v1.0");


            static IEnumerable<string> GetProductAttributes(XPathNodeIterator products)
            {
                while (products.MoveNext())
                {
                    yield return products.Current.GetAttribute("podmiotOdpowiedzialny", "");
                }
            }

            //Krem
            XPathExpression query = navigator.Compile("/x:produktyLecznicze/x:produktLeczniczy[@postac='Krem']");
            query.SetContext(manager);
            XPathNodeIterator Krem = navigator.Select(query);

            var productCount = GetProductAttributes(Krem)
                .GroupBy(y => y)
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
    }
}