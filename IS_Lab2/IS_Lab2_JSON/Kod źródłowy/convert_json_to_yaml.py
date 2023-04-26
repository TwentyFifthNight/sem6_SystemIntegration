# -*- coding: utf-8 -*-
"""
json to yaml converter
"""
import yaml
from functools import singledispatch


class ConvertJsonToYaml:

    @singledispatch
    @staticmethod
    def run(deserializeddata, destinationfilelocaiton):
        print("let's convert JSON to Yaml")
        with open(destinationfilelocaiton, 'w', encoding='utf8') as f:
            yaml.dump(deserializeddata, f, allow_unicode=True)
        print("it is done\n")

    @run.register
    @staticmethod
    def _(filename: str, destinationfilelocaiton):
        print("let's convert JSON to Yaml with filepath")
        from deserialize_json import DeserializeJson
        deserializeddata = DeserializeJson(filename)

        with open(destinationfilelocaiton, 'w', encoding='utf8') as f:
            yaml.dump(deserializeddata, f, allow_unicode=True)
        print("it is done\n")
