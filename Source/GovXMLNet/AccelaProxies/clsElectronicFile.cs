using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="ElectronicFile">
		<xsd:complexContent>
			<xsd:extension base="element">
				<xsd:sequence>
					<xsd:element ref="Keys" minOccurs="0"/>
					<xsd:element ref="IdentifierDisplay"/>
					<xsd:element ref="Description" minOccurs="0"/>
					<xsd:element name="fileName" type="xsd:string" form="qualified"/>
					<xsd:element name="fileDateTime" type="dateAndTime" form="qualified" minOccurs="0"/>
					<xsd:element name="fileSize" type="xsd:string" form="qualified" minOccurs="0"/>
					<xsd:element name="fileType" type="xsd:string" form="qualified" minOccurs="0"/>
					<xsd:element name="mimeType" type="xsd:string" form="qualified"/>
					<xsd:element name="data" type="xsd:base64Binary" form="qualified"/>
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
    public class clsElectronicFile : clsElement
    {
        // Members
        public clsKeys Keys { get; set; }

        private string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        private string _Description = null;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private string _fileName = null;
        public string fileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        [XmlIgnore]
        public DateTime? fileDateTime { get; set; }
        [XmlElement("fileDateTime")]
        public string fileDateTimeString
        {
            get
            {
                if (fileDateTime.HasValue)
                {
                    return fileDateTime.Value.ToString(Constants.cDateTimeFormat); ;
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
                    fileDateTime = td;
                }
                else
                {
                    fileDateTime = null;
                }
            }
        }
        public bool fileDateTimeStringSpecified
        {
            get { return fileDateTime != null; }
        }

        private string _fileSize = null;
        public string fileSize
        {
            get { return _fileSize; }
            set { _fileSize = value; }
        }

        private string _fileType = null;
        public string fileType
        {
            get { return _fileType; }
            set { _fileType = value; }
        }

        private string _mimeType = null;
        public string mimeType
        {
            get { return _mimeType; }
            set { _mimeType = value; }
        }

        private byte[] _data = null;
        public byte[] data
        {
            get { return _data; }
            set { _data = value; }
        }

        // Constructors
        public clsElectronicFile()
        {
        }
    }
}
