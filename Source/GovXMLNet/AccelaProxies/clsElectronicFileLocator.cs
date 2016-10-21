using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="ElectronicFileLocator">
		<xsd:complexContent>
			<xsd:extension base="DocumentLocator">
				<xsd:sequence>
					<xsd:element name="fileName" type="xsd:string" form="qualified"/>
					<xsd:element name="fileDateTime" type="dateAndTime" form="qualified" minOccurs="0"/>
					<xsd:element name="fileLocation" type="xsd:string" form="qualified" minOccurs="0"/>
					<xsd:element name="fileSize" type="xsd:string" form="qualified" minOccurs="0"/>
					<xsd:element name="fileType" type="xsd:string" form="qualified" minOccurs="0"/>
					<xsd:element name="serverAddress" type="xsd:string" form="qualified" minOccurs="0"/>
					<xsd:element name="serverDescription" type="xsd:string" form="qualified" minOccurs="0"/>
					<xsd:element name="serverType" type="electronicFileServerTypeEnum" form="qualified" minOccurs="0"/>
					<xsd:element name="serverPlatform" type="electronicFileServerPlatformEnum" form="qualified" minOccurs="0"/>
					<xsd:element name="serverVendor" type="electronicFileServerVendorEnum" form="qualified" minOccurs="0"/>
					<xsd:element ref="ElectronicSignature" minOccurs="0"/>
					<xsd:element ref="ElectronicFileUploaded" minOccurs="0"/>
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
    public class clsElectronicFileLocator : clsDocumentLocator
    {
        // Members
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

        private string _fileLocation = null;
        public string fileLocation
        {
            get { return _fileLocation; }
            set { _fileLocation = value; }
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

        private string _serverAddress = null;
        public string serverAddress
        {
            get { return _serverAddress; }
            set { _serverAddress = value; }
        }

        private string _serverDescription = null;
        public string serverDescription
        {
            get { return _serverDescription; }
            set { _serverDescription = value; }
        }

        private electronicFileServerTypeEnum? _serverType = null;
        public electronicFileServerTypeEnum? serverType
        {
            get
            {
                if (_serverType.HasValue)
                {
                    return _serverType.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _serverType = value; }
        }
        public bool serverTypeSpecified
        {
            get { return _serverType != null; }
        }

        private electronicFileServerPlatformEnum? _serverPlatform = null;
        public electronicFileServerPlatformEnum? serverPlatform
        {
            get
            {
                if (_serverPlatform.HasValue)
                {
                    return _serverPlatform.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _serverPlatform = value; }
        }
        public bool serverPlatformSpecified
        {
            get { return _serverPlatform != null; }
        }

        private electronicFileServerVendorEnum? _serverVendor = null;
        public electronicFileServerVendorEnum? serverVendor
        {
            get
            {
                if (_serverVendor.HasValue)
                {
                    return _serverVendor.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _serverVendor = value; }
        }
        public bool serverVendorSpecified
        {
            get { return _serverVendor != null; }
        }

        public clsElectronicSignature ElectronicSignature { get; set; }
        public clsElectronicFileUploaded ElectronicFileUploaded { get; set; }

        // Constructors
        public clsElectronicFileLocator()
        {
        }
    }
}
