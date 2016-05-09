
package com.mygateglobal.api;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for anonymous complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType>
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="status" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="uidTransactionIndex" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="TransactionDateTime" type="{http://www.w3.org/2001/XMLSchema}string"/>
 *         &lt;element name="warnings" type="{https://api.mygateglobal.com/}resWarning" minOccurs="0"/>
 *         &lt;element name="errors" type="{https://api.mygateglobal.com/}resError" minOccurs="0"/>
 *         &lt;element name="mgMessage" type="{https://api.mygateglobal.com/}resMGMessage" minOccurs="0"/>
 *         &lt;element name="fspMessage" type="{https://api.mygateglobal.com/}resFspMessage" minOccurs="0"/>
 *         &lt;element name="tdsLookup" type="{https://api.mygateglobal.com/}resTdsLookup" minOccurs="0"/>
 *         &lt;element name="tdsAuth" type="{https://api.mygateglobal.com/}resTdsAuth" minOccurs="0"/>
 *         &lt;element name="rptReports" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "", propOrder = {
    "status",
    "uidTransactionIndex",
    "transactionDateTime",
    "warnings",
    "errors",
    "mgMessage",
    "fspMessage",
    "tdsLookup",
    "tdsAuth",
    "rptReports"
})
@XmlRootElement(name = "responseMessage")
public class ResponseMessage {

    @XmlElement(required = true)
    protected String status;
    @XmlElement(required = true)
    protected String uidTransactionIndex;
    @XmlElement(name = "TransactionDateTime", required = true)
    protected String transactionDateTime;
    protected ResWarning warnings;
    protected ResError errors;
    protected ResMGMessage mgMessage;
    protected ResFspMessage fspMessage;
    protected ResTdsLookup tdsLookup;
    protected ResTdsAuth tdsAuth;
    protected String rptReports;

    /**
     * Gets the value of the status property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getStatus() {
        return status;
    }

    /**
     * Sets the value of the status property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setStatus(String value) {
        this.status = value;
    }

    /**
     * Gets the value of the uidTransactionIndex property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getUidTransactionIndex() {
        return uidTransactionIndex;
    }

    /**
     * Sets the value of the uidTransactionIndex property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setUidTransactionIndex(String value) {
        this.uidTransactionIndex = value;
    }

    /**
     * Gets the value of the transactionDateTime property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getTransactionDateTime() {
        return transactionDateTime;
    }

    /**
     * Sets the value of the transactionDateTime property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setTransactionDateTime(String value) {
        this.transactionDateTime = value;
    }

    /**
     * Gets the value of the warnings property.
     * 
     * @return
     *     possible object is
     *     {@link ResWarning }
     *     
     */
    public ResWarning getWarnings() {
        return warnings;
    }

    /**
     * Sets the value of the warnings property.
     * 
     * @param value
     *     allowed object is
     *     {@link ResWarning }
     *     
     */
    public void setWarnings(ResWarning value) {
        this.warnings = value;
    }

    /**
     * Gets the value of the errors property.
     * 
     * @return
     *     possible object is
     *     {@link ResError }
     *     
     */
    public ResError getErrors() {
        return errors;
    }

    /**
     * Sets the value of the errors property.
     * 
     * @param value
     *     allowed object is
     *     {@link ResError }
     *     
     */
    public void setErrors(ResError value) {
        this.errors = value;
    }

    /**
     * Gets the value of the mgMessage property.
     * 
     * @return
     *     possible object is
     *     {@link ResMGMessage }
     *     
     */
    public ResMGMessage getMgMessage() {
        return mgMessage;
    }

    /**
     * Sets the value of the mgMessage property.
     * 
     * @param value
     *     allowed object is
     *     {@link ResMGMessage }
     *     
     */
    public void setMgMessage(ResMGMessage value) {
        this.mgMessage = value;
    }

    /**
     * Gets the value of the fspMessage property.
     * 
     * @return
     *     possible object is
     *     {@link ResFspMessage }
     *     
     */
    public ResFspMessage getFspMessage() {
        return fspMessage;
    }

    /**
     * Sets the value of the fspMessage property.
     * 
     * @param value
     *     allowed object is
     *     {@link ResFspMessage }
     *     
     */
    public void setFspMessage(ResFspMessage value) {
        this.fspMessage = value;
    }

    /**
     * Gets the value of the tdsLookup property.
     * 
     * @return
     *     possible object is
     *     {@link ResTdsLookup }
     *     
     */
    public ResTdsLookup getTdsLookup() {
        return tdsLookup;
    }

    /**
     * Sets the value of the tdsLookup property.
     * 
     * @param value
     *     allowed object is
     *     {@link ResTdsLookup }
     *     
     */
    public void setTdsLookup(ResTdsLookup value) {
        this.tdsLookup = value;
    }

    /**
     * Gets the value of the tdsAuth property.
     * 
     * @return
     *     possible object is
     *     {@link ResTdsAuth }
     *     
     */
    public ResTdsAuth getTdsAuth() {
        return tdsAuth;
    }

    /**
     * Sets the value of the tdsAuth property.
     * 
     * @param value
     *     allowed object is
     *     {@link ResTdsAuth }
     *     
     */
    public void setTdsAuth(ResTdsAuth value) {
        this.tdsAuth = value;
    }

    /**
     * Gets the value of the rptReports property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getRptReports() {
        return rptReports;
    }

    /**
     * Sets the value of the rptReports property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setRptReports(String value) {
        this.rptReports = value;
    }

}
