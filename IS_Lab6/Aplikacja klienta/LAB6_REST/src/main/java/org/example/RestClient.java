package org.example;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.URL;
import java.util.stream.Collectors;

public class RestClient {
    private JSONObject data;

    public RestClient(String url){
        try {
            URL Url = new URL(url);
            InputStream is = Url.openStream();
            String source = new BufferedReader(new InputStreamReader(is))
                    .lines().collect(Collectors.joining("\n"));
            data = new JSONObject(source);
        } catch (Exception e) {
            System.err.println("Wystąpił nieoczekiwany błąd!!! ");
            e.printStackTrace(System.err);
        }
    }

    public JSONArray getData(String tableName){
        if(data == null)
            return null;
        else if(data.has(tableName))
            return (JSONArray) data.get(tableName);
        return null;
    }
}
