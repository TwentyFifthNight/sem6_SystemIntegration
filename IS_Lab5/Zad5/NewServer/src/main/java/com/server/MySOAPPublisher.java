package com.server;

import javax.xml.ws.Endpoint;

public class MySOAPPublisher {

    public static void main(String[] args){
        Endpoint.publish("http://localhost:7779/ws/first", new MyWS());
    }
}
