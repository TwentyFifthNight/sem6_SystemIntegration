using ServiceReference1;

internal class Program
{
    static async Task Main()
    {
        Console.WriteLine("My First SOAP Client!");
        MyFirstSOAPInterfaceClient client = new MyFirstSOAPInterfaceClient();
        string text = await client.getHelloWorldAsStringAsync("Damian");
        Console.WriteLine(text);

        string startDate = "10 04 2023";
        string endDate = "25 04 2023";

        long days = await client.getDaysBetweenDatesAsync(startDate, endDate);
        Console.WriteLine("Dni między " + startDate + ", a " + endDate + ": " + days);
        Console.ReadLine();
    }
}
