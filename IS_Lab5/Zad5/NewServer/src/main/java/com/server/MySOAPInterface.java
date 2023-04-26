package com.server;

import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebService;
import javax.jws.soap.SOAPBinding;
import javax.jws.soap.SOAPBinding.Style;

@WebService // oznaczenie klasy jako SEO (Service Endpoint Interface)
@SOAPBinding(style = Style.RPC)
public interface MySOAPInterface {
    @WebMethod
    User getUser(@WebParam(name="id") Long id);

}
