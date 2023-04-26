namespace Lab2
{
    internal class Convert_json_to_yaml
    {
        public static void run(Deserialize_json deserializeData, string destinationFileLocaiton)
        {
            Console.WriteLine("let's convert JSON to Yaml");

            var yamlSerializer = new YamlDotNet.Serialization.Serializer();
            string yaml = yamlSerializer.Serialize(deserializeData.data);
            File.WriteAllText(destinationFileLocaiton, yaml);

            Console.WriteLine("it's done");
        }

        public static void run(string filename, string destinationFileLocaiton)
        {
            Console.WriteLine("let's convert JSON to Yaml with filepath");

            Deserialize_json deserializator = new Deserialize_json(filename);
            Convert_json_to_yaml.run(deserializator, destinationFileLocaiton);

            Console.WriteLine("it's done");
        }
    }
}
