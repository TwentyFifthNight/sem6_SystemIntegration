using Lab2;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;



var deserializer = new DeserializerBuilder()
    .WithNamingConvention(CamelCaseNamingConvention.Instance)
    .Build();
StreamReader sr = new StreamReader("Assets/basic_config.yaml");
var conf_data = deserializer.Deserialize<dynamic>(sr);


Deserialize_json newDeserializator = new(conf_data["paths"]["source_folder"] + conf_data["paths"]["json_source_file"]);



foreach (string operation in conf_data["operations"])
{
    switch (operation)
    {
        case "someStats":
            newDeserializator.Somestats();
            break;
        case "serialize":
            Serialize_json.run(newDeserializator, conf_data["paths"]["source_folder"] + conf_data["paths"]["json_destination_file"]);
            break;
        case "convertJsonToYaml":
            if (conf_data["serializationSource"] == "file")
            {
                Convert_json_to_yaml.run(conf_data["paths"]["source_folder"] + conf_data["paths"]["json_source_file"] , 
                                        conf_data["paths"]["source_folder"] + conf_data["paths"]["yaml_destination_file"]);
            }
            else if(conf_data["serializationSource"] == "object")
            {
                Convert_json_to_yaml.run(newDeserializator, conf_data["paths"]["source_folder"] + conf_data["paths"]["yaml_destination_file"]);
            }
            break;
    }
}


Console.ReadLine();