import yaml
from deserialize_json import DeserializeJson
from serialize_json import SerializeJson
from convert_json_to_yaml import ConvertJsonToYaml
from json_xml_conversion import convertJsonToXML, convertXMLToJson


def call_serialize():
    SerializeJson.run(newDeserializator, conf_data['paths']['source_folder'] +
                      conf_data['paths']['json_destination_file'])


def call_converter():
    source = newDeserializator
    if conf_data['serializationSource'] == 'file':
        source = 'Assets/data.json'
    ConvertJsonToYaml.run(source, conf_data['paths']['source_folder'] +
                          conf_data['paths']['yaml_destination_file'])


conf_file = open('Assets/basic_config.yaml', encoding="utf8")
conf_data = yaml.load(conf_file, Loader=yaml.FullLoader)

newDeserializator = DeserializeJson(conf_data['paths']['source_folder'] +
                                    conf_data['paths']['json_source_file'])

operations = {
    'someStats': newDeserializator.somestats,
    'serialize': call_serialize,
    'convertJsonToYaml': call_converter
}

for operation in conf_data['operations']:
    operations[operation]()

convertJsonToXML(conf_data['paths']['source_folder'] + conf_data['paths']['json_source_file'],
                 conf_data['paths']['source_folder'] + conf_data['paths']['xml_destination_file'])

convertXMLToJson(conf_data['paths']['source_folder'] + conf_data['paths']['xml_source_file'],
                 conf_data['paths']['source_folder'] + conf_data['paths']['json_destination_from_xml'])

