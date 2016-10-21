using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="ElectronicFileUploaded">
		<xsd:complexContent>
			<xsd:extension base="element">
				<xsd:sequence>
					<xsd:element ref="Keys" minOccurs="0"/>
					<xsd:element ref="IdentifierDisplay" minOccurs="0"/>
					<xsd:element ref="Description" minOccurs="0"/>
					<xsd:element name="uploadedByIdentifier" type="text" form="qualified"/>
					<xsd:element name="uploadedBy" form="qualified" minOccurs="0">
						<xsd:complexType>
							<xsd:choice>
								<xsd:group ref="ifc:ActorSelect"/>
							</xsd:choice>
						</xsd:complexType>
					</xsd:element>
					<xsd:element name="uploadedDate" type="dateAndTime" form="qualified" minOccurs="0"/>
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
    public class clsElectronicFileUploaded : clsElement
    {

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

        private string _UploadedByIdentifier = null;
        public string uploadedByIdentifier
        {
            get { return _UploadedByIdentifier; }
            set { _UploadedByIdentifier = value; }
        }

        public clsIFCActorSelect uploadedBy { get; set; }

        [XmlIgnore]
        public DateTime? uploadedDate = null;
        [XmlElement("uploadedDate")]
        public string uploadedDateString
        {
            get
            {
                if (uploadedDate.HasValue)
                {
                    return uploadedDate.Value.ToString(Constants.cDateTimeFormat); ;
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
                    uploadedDate = td;
                }
                else
                {
                    uploadedDate = null;
                }
            }
        }
        public bool uploadedDateStringSpecified
        {
            get { return uploadedDate != null; }
        }

        // Constructors
        public clsElectronicFileUploaded()
        {
        }
    }
}
