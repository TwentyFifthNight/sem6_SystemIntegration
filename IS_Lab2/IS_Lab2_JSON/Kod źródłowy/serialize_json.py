# -*- coding: utf-8 -*-
"""
seria
"""

import json


class SerializeJson:

    # metoda statyczna
    @staticmethod
    def run(deserializeddata, filelocation):
        print("let's serialize JSON")

        lst = []
        for dep in deserializeddata.data:
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
                "telefon_z_numerem_kierunkowym": str(dep['telefon kierunkowy']) + '-' + str(dep['telefon'])
            })
        jsontemp = {"departaments": lst}
        with open(filelocation, 'w', encoding='utf-8') as f:
            json.dump(jsontemp, f, ensure_ascii=False)
        print("it is done\n")
