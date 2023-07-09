package com.soap;

import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebService;
import javax.jws.soap.SOAPBinding;
import javax.jws.soap.SOAPBinding.Style;

@WebService
@SOAPBinding(style = Style.RPC)
public interface SOAPInterface {
    @WebMethod
    String login(@WebParam(name="username")String username, @WebParam(name="password")String password);

    @WebMethod
    Boolean registerUser(@WebParam(name="username")String username, @WebParam(name="password")String password, @WebParam(name="voivodeship")String voivodeship);
}
