# -*- coding: utf-8 -*-
"""
deserialize json
"""
import json


class DeserializeJson:
    # konstruktor
    def __init__(self, filename):
        print("let's deserialize something")
        tempdata = open(filename, encoding="utf8")
        self.data = json.load(tempdata)

    # przykładowe statystyki
    def somestats(self):
        example_stat = 0
        dictionary = dict()
        for dep in self.data:
            if dep['typ_JST'] == 'GM' and dep['Województwo'] == 'dolnośląskie':
                example_stat += 1

            wojewodztwo = dep['Województwo'].replace(" ", "")
            if wojewodztwo not in dictionary:
                dictionary[wojewodztwo] = dict()

            if dep['typ_JST'] not in dictionary[wojewodztwo]:
                dictionary[wojewodztwo][dep['typ_JST']] = 0
            dictionary[wojewodztwo][dep['typ_JST']] += 1

        print('liczba urzędów miejskich w województwie dolnośląskim: ' + ' ' + str(example_stat))

        for records in dictionary:
            print("Województwo: " + str(records))
            for record in dictionary[records]:
                print("Liczba wystąpień urzędów typu " + str(record) + ": " + str(dictionary[records][record]))
            print()
