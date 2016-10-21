using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="PIN">
		<xsd:complexContent>
			<xsd:extension base="SpatialDescriptor">
				<xsd:sequence>
					<xsd:choice>
						<xsd:element name="String" type="text" form="qualified" maxOccurs="unbounded"/>
						<xsd:element ref="Value"/>
					</xsd:choice>
					<xsd:element name="referenceAddress" type="text" form="qualified" minOccurs="0"/>
					<xsd:element name="referenceEntity" type="text" form="qualified" minOccurs="0"/>
					<xsd:element name="referenceLandType" type="text" form="qualified" minOccurs="0"/>
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
    public class clsPIN : clsSpatialDescriptor
    {
        enum eChoicePIN
        {
            scString,
            scValue
        }

        // Start Choice
        [XmlElement(ElementName = "String")]
        private string _String = null;
        public string String
        {
            get { return _String; }
            set { _String = value; }
        }

        private string _Value = null;
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        // End Choice

        private string _referenceAddress = null;
        public string referenceAddress
        {
            get { return _referenceAddress; }
            set { _referenceAddress = value; }
        }

        private string _referenceEntity = null;
        public string referenceEntity
        {
            get { return _referenceEntity; }
            set { _referenceEntity = value; }
        }

        private string _referenceLandType = null;
        public string referenceLandType
        {
            get { return _referenceLandType; }
            set { _referenceLandType = value; }
        }

        // Constructors
        public clsPIN()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoicePIN pSelectedChoice)
        {
            if (pSelectedChoice != eChoicePIN.scString)
            {
                _String = null;
            }
            if (pSelectedChoice != eChoicePIN.scValue)
            {
                _Value = null;
            }
        }
    }
}
