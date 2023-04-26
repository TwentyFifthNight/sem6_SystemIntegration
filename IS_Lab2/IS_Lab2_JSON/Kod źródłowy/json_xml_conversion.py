from json2xml import json2xml
from json2xml.utils import readfromjson
import json
import xmltodict


def extract(data, extension = 'json'):
    separation_sign = '_'
    if extension == 'xml':
        separation_sign = ' '

    lst = []
    for dep in data:
        powiat = '-'
        if 'Powiat' in dep:
            powiat = dep['Powiat']
        lst.append({
            "Kod_TERYT": dep['Kod_TERYT'],
            "Województwo": dep['Województwo'],
            "Powiat": powiat,
            "typ_JST": dep['typ_JST'],
            "nazwa_urzędu_JST": dep['nazwa_urzędu_JST'],
            "miejscowość": dep['miejscowość'],
            "telefon_z_numerem_kierunkowym": str(dep['telefon' + separation_sign + 'kierunkowy']) + '-' + str(dep['telefon'])
        })
    return lst


def convertJsonToXML(json_file_path, xml_file_path):
    print("let's convert JSON to XML")
    data = readfromjson(json_file_path)
    data = extract(data, 'xml')
    data = json2xml.Json2xml(data, attr_type=False).to_xml()
    print("let's save extracted XML")
    with open(xml_file_path, 'w', encoding='utf8') as f:
        f.write(str(data))
    print("both are done\n")


def convertXMLToJson(xml_file_path, json_file_path):
    print("let's convert XML to JSON")
    with open(xml_file_path, 'r', encoding='utf8') as myfile:
        obj = xmltodict.parse(myfile.read(), encoding='utf-8', xml_attribs=False)

    obj = obj['all']['item']
    lst = extract(obj)
    jsontemp = {"departaments": lst}
    print("let's save extracted JSON")
    with open(json_file_path, 'w', encoding='utf-8') as f:
        json.dump(jsontemp, f, ensure_ascii=False)
    print("both are done\n")
