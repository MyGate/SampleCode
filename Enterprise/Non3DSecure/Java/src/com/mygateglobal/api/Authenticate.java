
package com.mygateglobal.api;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for authenticate complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="authenticate">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="merchantUID" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="merchantToken" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="actionTypeID" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "authenticate", propOrder = {
    "merchantUID",
    "merchantToken",
    "actionTypeID"
})
public class Authenticate {

    @XmlElement(required = true)
    protected String merchantUID;
    @XmlElement(required = true)
    protected String merchantToken;
    @XmlElement(required = true)
    protected String actionTypeID;

    /**
     * Gets the value of the merchantUID property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getMerchantUID() {
        return merchantUID;
    }

    /**
     * Sets the value of the merchantUID property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setMerchantUID(String value) {
        this.merchantUID = value;
    }

    /**
     * Gets the value of the merchantToken property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getMerchantToken() {
        return merchantToken;
    }

    /**
     * Sets the value of the merchantToken property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setMerchantToken(String value) {
        this.merchantToken = value;
    }

    /**
     * Gets the value of the actionTypeID property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getActionTypeID() {
        return actionTypeID;
    }

    /**
     * Sets the value of the actionTypeID property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setActionTypeID(String value) {
        this.actionTypeID = value;
    }

}
