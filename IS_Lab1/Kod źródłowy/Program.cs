using System;
using System.Collections.Generic;
using System.IO;

namespace IS_Lab1_XML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string xmlpath = Path.Combine("Assets", "data.xml");
            
            // odczyt danych z wykorzystaniem DOM
            Console.WriteLine("XML loaded by DOM Approach");
            XMLReadWithDOMApproach.Read(xmlpath);
            Console.WriteLine();
            XMLReadWithDOMApproach.maxKremITabletki(xmlpath);
            Console.WriteLine("\nTrzy podmioty produkujące najwięcej kremów:");
            XMLReadWithDOMApproach.trzyMaxKrem(xmlpath);

            
            Console.WriteLine();
            Console.WriteLine();

            // odczyt danych z wykorzystaniem SAX
            Console.WriteLine("XML loaded by SAX Approach");
            XMLReadWithSAXApproach.Read(xmlpath);
            Console.WriteLine();
            XMLReadWithSAXApproach.maxKremITabletki(xmlpath);
            Console.WriteLine("\nTrzy podmioty produkujące najwięcej kremów:");
            XMLReadWithSAXApproach.trzyMaxKrem(xmlpath);

            Console.WriteLine();
            Console.WriteLine();
            
            // odczyt danych z wykorzystaniem XPath i DOM
            Console.WriteLine("XML loaded with XPath");
            XMLReadWithXLSTDOM.Read(xmlpath);
            Console.WriteLine();
            XMLReadWithXLSTDOM.maxKremITabletki(xmlpath);
            Console.WriteLine("\nTrzy podmioty produkujące najwięcej kremów:");
            XMLReadWithXLSTDOM.trzyMaxKrem(xmlpath);

            Console.WriteLine();

            //Identyfikowanie produktów leczniczych zawierających jedną lub kilka substancji czynnych.
            XMLReadWithDOMApproach.identyfikacja(xmlpath);

            Console.WriteLine();
            Console.WriteLine("Naciśnij przycisk, aby zakończyć działanie programu");
            Console.ReadLine();

        }
    }
}
