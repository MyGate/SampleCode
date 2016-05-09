
package com.mygateglobal.api;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for resTdsAuth complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="resTdsAuth">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="code" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="message" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="liabilityShift" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="ccAuthAllowed" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="eciFlag" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="paresStatus" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="signatureVerification" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="xid" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="cavv" type="{http://www.w3.org/2001/XMLSchema}string"/>
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
@XmlType(name = "resTdsAuth", propOrder = {
    "code",
    "message",
    "liabilityShift",
    "ccAuthAllowed",
    "eciFlag",
    "paresStatus",
    "signatureVerification",
    "xid",
    "cavv",
    "action"
})
public class ResTdsAuth {

    @XmlElement(required = true)
    protected String code;
    @XmlElement(required = true)
    protected String message;
    @XmlElement(required = true)
    protected String liabilityShift;
    @XmlElement(required = true)
    protected String ccAuthAllowed;
    @XmlElement(required = true)
    protected String eciFlag;
    @XmlElement(required = true)
    protected String paresStatus;
    @XmlElement(required = true)
    protected String signatureVerification;
    @XmlElement(required = true)
    protected String xid;
    @XmlElement(required = true)
    protected String cavv;
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
     * Gets the value of the paresStatus property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getParesStatus() {
        return paresStatus;
    }

    /**
     * Sets the value of the paresStatus property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setParesStatus(String value) {
        this.paresStatus = value;
    }

    /**
     * Gets the value of the signatureVerification property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getSignatureVerification() {
        return signatureVerification;
    }

    /**
     * Sets the value of the signatureVerification property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setSignatureVerification(String value) {
        this.signatureVerification = value;
    }

    /**
     * Gets the value of the xid property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getXid() {
        return xid;
    }

    /**
     * Sets the value of the xid property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setXid(String value) {
        this.xid = value;
    }

    /**
     * Gets the value of the cavv property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getCavv() {
        return cavv;
    }

    /**
     * Sets the value of the cavv property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setCavv(String value) {
        this.cavv = value;
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
