
package com.mygateglobal.api;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlElementDecl;
import javax.xml.bind.annotation.XmlRegistry;
import javax.xml.namespace.QName;


/**
 * This object contains factory methods for each 
 * Java content interface and Java element interface 
 * generated in the com.mygateglobal.api package. 
 * <p>An ObjectFactory allows you to programatically 
 * construct new instances of the Java representation 
 * for XML content. The Java representation of XML 
 * content can consist of schema derived interfaces 
 * and classes representing the binding of schema 
 * type definitions, element declarations and model 
 * groups.  Factory methods for each of these are 
 * provided in this class.
 * 
 */
@XmlRegistry
public class ObjectFactory {

    private final static QName _Authenticate_QNAME = new QName("https://api.mygateglobal.com/", "authenticate");
    private final static QName _RequestMessage_QNAME = new QName("https://api.mygateglobal.com/", "requestMessage");

    /**
     * Create a new ObjectFactory that can be used to create new instances of schema derived classes for package: com.mygateglobal.api
     * 
     */
    public ObjectFactory() {
    }

    /**
     * Create an instance of {@link ResponseMessage }
     * 
     */
    public ResponseMessage createResponseMessage() {
        return new ResponseMessage();
    }

    /**
     * Create an instance of {@link ResWarning }
     * 
     */
    public ResWarning createResWarning() {
        return new ResWarning();
    }

    /**
     * Create an instance of {@link ResError }
     * 
     */
    public ResError createResError() {
        return new ResError();
    }

    /**
     * Create an instance of {@link ResMGMessage }
     * 
     */
    public ResMGMessage createResMGMessage() {
        return new ResMGMessage();
    }

    /**
     * Create an instance of {@link ResFspMessage }
     * 
     */
    public ResFspMessage createResFspMessage() {
        return new ResFspMessage();
    }

    /**
     * Create an instance of {@link ResTdsLookup }
     * 
     */
    public ResTdsLookup createResTdsLookup() {
        return new ResTdsLookup();
    }

    /**
     * Create an instance of {@link ResTdsAuth }
     * 
     */
    public ResTdsAuth createResTdsAuth() {
        return new ResTdsAuth();
    }

    /**
     * Create an instance of {@link Authenticate }
     * 
     */
    public Authenticate createAuthenticate() {
        return new Authenticate();
    }

    /**
     * Create an instance of {@link ResMessages }
     * 
     */
    public ResMessages createResMessages() {
        return new ResMessages();
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link Authenticate }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "https://api.mygateglobal.com/", name = "authenticate")
    public JAXBElement<Authenticate> createAuthenticate(Authenticate value) {
        return new JAXBElement<Authenticate>(_Authenticate_QNAME, Authenticate.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link String }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "https://api.mygateglobal.com/", name = "requestMessage")
    public JAXBElement<String> createRequestMessage(String value) {
        return new JAXBElement<String>(_RequestMessage_QNAME, String.class, null, value);
    }

}
