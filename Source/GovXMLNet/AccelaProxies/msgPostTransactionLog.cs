using System;
using System.Xml.Serialization;

// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="PostTransactionLog">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element ref="Username"/>
					<xsd:element name="ipAddress" type="xsd:string" minOccurs="0"/>
					<xsd:element name="errorString" type="xsd:string" minOccurs="0"/>
					<xsd:element name="operation" type="xsd:string" minOccurs="0"/>
					<xsd:element name="transactionId" type="xsd:string"/>
					<xsd:element name="timestamp" type="xsd:dateTime"/>
					<xsd:element name="product" type="xsd:string"/>
					<xsd:element name="location" type="xsd:string" minOccurs="0"/>
					<xsd:element name="request" type="xsd:string" minOccurs="0"/>
					<xsd:element name="response" type="xsd:string" minOccurs="0"/>
				</xsd:sequence>
			</xsd:extension>
		</xsd:complexContent>
	</xsd:complexType>
*/

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 2/14/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class msgPostTransactionLog : clsOperationRequest
    {
        // Members
        private string _Username = null;
        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        private string _ipAddress = null;
        public string ipAddress
        {
            get { return _ipAddress; }
            set { _ipAddress = value; }
        }

        private string _errorString = null;
        public string errorString
        {
            get { return _errorString; }
            set { _errorString = value; }
        }

        private string _operation = null;
        public string operation
        {
            get { return _operation; }
            set { _operation = value; }
        }

        private string _transactionId = null;
        public string transactionId
        {
            get { return _transactionId; }
            set { _transactionId = value; }
        }

        private DateTime _timestamp = DateTime.Now;
        [XmlIgnore]
        public DateTime timestamp
        {
            get { return _timestamp; }
            set { _timestamp = value; }
        }
        [XmlElement("timestamp")]
        public string timestampString
        {
            get { return _timestamp.ToString(Constants.cDateTimeFormat); }
            set
            {
                DateTime td;
                if (DateTime.TryParse(value, out td))
                {
                    _timestamp = td;
                }
            }
        }

        private string _product = null;
        public string product
        {
            get { return _product; }
            set { _product = value; }
        }

        private string _location = null;
        public string location
        {
            get { return _location; }
            set { _location = value; }
        }

        private string _request = null;
        public string request
        {
            get { return _request; }
            set { _request = value; }
        }

        private string _response = null;
        public string response
        {
            get { return _response; }
            set { _response = value; }
        }

        // Constructors
        public msgPostTransactionLog()
        {
        }
    }
}
