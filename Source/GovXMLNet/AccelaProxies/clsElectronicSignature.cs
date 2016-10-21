using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="ElectronicSignature">
		<xsd:complexContent>
			<xsd:extension base="element">
				<xsd:sequence>
					<xsd:element ref="Keys" minOccurs="0"/>
					<xsd:element ref="IdentifierDisplay"/>
					<xsd:element ref="Description" minOccurs="0"/>
					<xsd:element name="signedByIdentifier" type="text" form="qualified"/>
					<xsd:element name="signedBy" form="qualified" minOccurs="0">
						<xsd:complexType>
							<xsd:choice>
								<xsd:group ref="ifc:ActorSelect"/>
							</xsd:choice>
						</xsd:complexType>
					</xsd:element>
					<xsd:element name="signedDate" type="dateAndTime" form="qualified" minOccurs="0"/>
					<xsd:element ref="dsg:Signature" minOccurs="0"/>
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
    public class clsElectronicSignature : clsElement
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

        private string _signedByIdentifier = null;
        public string signedByIdentifier
        {
            get { return _signedByIdentifier; }
            set { _signedByIdentifier = value; }
        }

        public clsIFCActorSelect signedBy { get; set; }

        [XmlIgnore]
        public DateTime? signedDate { get; set; }
        [XmlElement("signedDate")]
        public string signedDateString
        {
            get
            {
                if (signedDate.HasValue)
                {
                    return signedDate.Value.ToString(Constants.cDateFormat); ;
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
                    signedDate = td;
                }
                else
                {
                    signedDate = null;
                }
            }
        }
        public bool signedDateStringSpecified
        {
            get { return signedDate != null; }
        }

        private string vSignature = null;
        public string Signature
        {
            get { return vSignature; }
            set { vSignature = value; }
        }

        // Constructors
        public clsElectronicSignature()
        {
        }
    }
}
