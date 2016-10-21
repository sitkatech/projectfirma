using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
	<xsd:complexType name="GISObject">
		<xsd:complexContent>
			<xsd:extension base="element">
				<xsd:sequence>
					<xsd:element ref="Keys"/>
					<xsd:element ref="IdentifierDisplay" minOccurs="0"/>
					<xsd:element ref="MapServiceId" minOccurs="0"/>
					<xsd:element ref="GISLayerId" minOccurs="0"/>
					<xsd:element ref="Attributes" minOccurs="0"/>
					<xsd:choice minOccurs="0">
						<xsd:element ref="CompactAddresses"/>
						<xsd:element ref="DetailAddresses"/>
					</xsd:choice>
					<xsd:element ref="Extent" minOccurs="0"/>
					<xsd:element ref="SpatialDescriptors" minOccurs="0"/>
					<xsd:element ref="Contacts" minOccurs="0"/>
					<xsd:element name="action" type="xsd:string"/>	
					<xsd:element ref="ObjectId"/>	
					<xsd:element ref="GISLayerId"/>	
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
    public class clsGISObject : clsElement
    {
        enum eChoiceGISObject
        {
            scCompactAddress,
            scDetailAddress
        }

        // Members
        public clsKeys Keys { get; set; }

        private string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        public clsMapServiceId MapServiceId { get; set; }
        public clsGISLayerId GISLayerId { get; set; }
        public clsAttributes Attributes { get; set; }

        // Start Choice
        private clsCompactAddresses _CompactAddresses = null;
        public clsCompactAddresses CompactAddresses
        {
            get { return _CompactAddresses; }
            set
            {
                _CompactAddresses = value;
                ChoiceClearAllBut(eChoiceGISObject.scCompactAddress);
            }
        }

        private clsDetailAddresses _DetailAddresses = null;
        public clsDetailAddresses DetailAddresses
        {
            get { return _DetailAddresses; }
            set
            {
                _DetailAddresses = value;
                ChoiceClearAllBut(eChoiceGISObject.scCompactAddress);
            }
        }
        // End Choice

        public clsExtent Extent { get; set; }
        public clsSpatialDescriptors SpatialDescriptors { get; set; }
        public clsContacts Contacts { get; set; }

        
        private string _actionElement = null;
        [XmlElement("action")]
        public string actionElement
        {
            get { return _actionElement; }
            set { _actionElement = value; }
        }
        
        public clsObjectId ObjectId { get; set; }
        
        // Constructors
        public clsGISObject()
        {
        }
        
        // Methods
        private void ChoiceClearAllBut(eChoiceGISObject pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceGISObject.scCompactAddress)
            {
                _CompactAddresses = null;
            }
            if (pSelectedChoice != eChoiceGISObject.scDetailAddress)
            {
                _DetailAddresses = null;
            }
        }

    }
}
