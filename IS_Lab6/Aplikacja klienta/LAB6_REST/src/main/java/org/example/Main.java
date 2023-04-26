package org.example;

import org.json.JSONArray;
import org.json.JSONObject;


public class Main {
    public static void main(String[] args) {
        RestClient client = new RestClient("http://localhost/IS_LAB6_REST/cities/read");
        JSONArray data = client.getData("cities");
        if(data != null)
            data.forEach( element -> {
                JSONObject obj = (JSONObject) element;
                System.out.println("City name: " + obj.get("Name"));
                System.out.println("Country code: " + obj.get("CountryCode"));
                System.out.println("District: " + obj.get("District"));
                System.out.println("Population: " + obj.get("Population"));
                System.out.println();
            });
    }
}