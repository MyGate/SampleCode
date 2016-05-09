
package com.mygateglobal.api;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for resTdsLookup complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="resTdsLookup">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="code" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="message" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="authRequired" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="liabilityShift" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="ccAuthAllowed" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="eciFlag" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="enrolled" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="acsUrl" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="payload" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="action" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "resTdsLookup", propOrder = {
    "code",
    "message",
    "authRequired",
    "liabilityShift",
    "ccAuthAllowed",
    "eciFlag",
    "enrolled",
    "acsUrl",
    "payload",
    "action"
})
public class ResTdsLookup {

    @XmlElement(required = true)
    protected String code;
    @XmlElement(required = true)
    protected String message;
    @XmlElement(required = true)
    protected String authRequired;
    @XmlElement(required = true)
    protected String liabilityShift;
    @XmlElement(required = true)
    protected String ccAuthAllowed;
    @XmlElement(required = true)
    protected String eciFlag;
    @XmlElement(required = true)
    protected String enrolled;
    @XmlElement(required = true)
    protected String acsUrl;
    @XmlElement(required = true)
    protected String payload;
    @XmlElement(required = true)
    protected String action;

    /**
     * Gets the value of the code property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getCode() {
        return code;
    }

    /**
     * Sets the value of the code property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setCode(String value) {
        this.code = value;
    }

    /**
     * Gets the value of the message property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getMessage() {
        return message;
    }

    /**
     * Sets the value of the message property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setMessage(String value) {
        this.message = value;
    }

    /**
     * Gets the value of the authRequired property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getAuthRequired() {
        return authRequired;
    }

    /**
     * Sets the value of the authRequired property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setAuthRequired(String value) {
        this.authRequired = value;
    }

    /**
     * Gets the value of the liabilityShift property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getLiabilityShift() {
        return liabilityShift;
    }

    /**
     * Sets the value of the liabilityShift property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setLiabilityShift(String value) {
        this.liabilityShift = value;
    }

    /**
     * Gets the value of the ccAuthAllowed property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getCcAuthAllowed() {
        return ccAuthAllowed;
    }

    /**
     * Sets the value of the ccAuthAllowed property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setCcAuthAllowed(String value) {
        this.ccAuthAllowed = value;
    }

    /**
     * Gets the value of the eciFlag property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getEciFlag() {
        return eciFlag;
    }

    /**
     * Sets the value of the eciFlag property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setEciFlag(String value) {
        this.eciFlag = value;
    }

    /**
     * Gets the value of the enrolled property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getEnrolled() {
        return enrolled;
    }

    /**
     * Sets the value of the enrolled property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setEnrolled(String value) {
        this.enrolled = value;
    }

    /**
     * Gets the value of the acsUrl property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getAcsUrl() {
        return acsUrl;
    }

    /**
     * Sets the value of the acsUrl property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setAcsUrl(String value) {
        this.acsUrl = value;
    }

    /**
     * Gets the value of the payload property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getPayload() {
        return payload;
    }

    /**
     * Sets the value of the payload property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setPayload(String value) {
        this.payload = value;
    }

    /**
     * Gets the value of the action property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getAction() {
        return action;
    }

    /**
     * Sets the value of the action property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setAction(String value) {
        this.action = value;
    }

}
