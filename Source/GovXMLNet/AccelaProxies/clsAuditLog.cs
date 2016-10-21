using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
    <xsd:complexType name="AuditLog">
      <xsd:complexContent>
        <xsd:extension base="element">
          <xsd:sequence>
            <xsd:element ref="Keys"/>
            <xsd:element ref="Entity"/>
            <xsd:element name="logAction" type="xsd:string" minOccurs="0"/>
            <xsd:element name="dateTime" type="xsd:string" minOccurs="0"/>
            <xsd:element name="field" type="xsd:string" minOccurs="0"/>
            <xsd:element name="fieldValue" type="xsd:string" minOccurs="0"/>
            <xsd:element name="product" type="xsd:string" minOccurs="0"/>
            <xsd:element name="operator" type="xsd:string" minOccurs="0"/>
          </xsd:sequence>
        </xsd:extension>
      </xsd:complexContent>
    </xsd:complexType>
*/

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 4/11/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class clsAuditLog : clsElement
    {
        // Members
        public clsKeys Keys { get; set; }
        public clsEntity Entity { get; set; }

        private string _logAction = null;
        public string logAction
        {
            get { return _logAction; }
            set { _logAction = value; }
        }

        [XmlIgnore]
        public DateTime? dateTime { get; set; }
        [XmlElement("dateTime")]
        public string dateTimeString
        {
            get
            {
                if (dateTime.HasValue)
                {
                    return dateTime.Value.ToString(Constants.cDateFormat); ;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                DateTime td;
                if (DateTime.TryParse(value, out td))
                {
                    dateTime = td;
                }
            }
        }
        public bool dateTimeStringSpecified
        {
            get { return dateTime != null; }
        }


        private string _field = null;
        public string field
        {
            get { return _field; }
            set { _field = value; }
        }

        private string _fieldValue = null;
        public string fieldValue
        {
            get { return _fieldValue; }
            set { _fieldValue = value; }
        }

        private string _product = null;
        public string product
        {
            get { return _product; }
            set { _product = value; }
        }

        private string _Operator = null;
        [XmlElement("operator")]
        public string Operator
        {
            get { return _Operator; }
            set { _Operator = value; }
        }


        // Constructors
        public clsAuditLog()
        {
        }
    }
}
