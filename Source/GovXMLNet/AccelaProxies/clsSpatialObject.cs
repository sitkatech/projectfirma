// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="SpatialObject">
		<xsd:complexContent>
			<xsd:extension base="SpatialEntity">
				<xsd:sequence>
					<xsd:element ref="SpatialDescriptors" minOccurs="0"/>
					<xsd:element ref="SpatialObjects" minOccurs="0"/>
					<xsd:element ref="SpatialElements" minOccurs="0"/>
					<xsd:element ref="GISObjects" minOccurs="0"/>
					<xsd:choice minOccurs="0">
						<xsd:element ref="CAPIds" minOccurs="0"/>
						<xsd:element ref="CAPs" minOccurs="0"/>
					</xsd:choice>
					<xsd:choice minOccurs="0">
						<xsd:element ref="Addresses"/>
						<xsd:element ref="CompactAddresses"/>
					</xsd:choice>
					<xsd:element ref="Conditions" minOccurs="0"/>
					<xsd:element ref="Contacts" minOccurs="0"/>
					<xsd:element ref="Holds" minOccurs="0"/>
					<xsd:element ref="AdditionalInformation" minOccurs="0"/>
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
    public class clsSpatialObject : clsSpatialEntity
    {
        enum eChoiceSpatialObjectCAP
        {
            scCAPIds,
            scCAPs
        }

        enum eChoiceSpatialObjectAddress
        {
            scAddresses,
            scCompactAddresses
        }

        // Members
        public clsSpatialDescriptors SpatialDescriptors { get; set; }

        public clsSpatialObjects SpatialObjects { get; set; }

        public clsSpatialElements SpatialElements { get; set; }

        public clsGISObjects GISObjects { get; set; }
        
        // Start Choice CAPs
        // Parcel has both come through, so disable the choice for the moment
        private clsGISObjects _CAPIds = null;
        public clsGISObjects CAPIds
        {
            get { return _CAPIds; }
            set
            {
                _CAPIds = value;
                //ChoiceClearAllBut(eChoiceSpatialObjectCAP.scCAPIds);
            }
        }

        private clsCAPs _CAPs = null;
        public clsCAPs CAPs
        {
            get { return _CAPs; }
            set
            {
                _CAPs = value;
                //ChoiceClearAllBut(eChoiceSpatialObjectCAP.scCAPs);
            }
        }
        // End Choice CAPs

        // Start Choice Addresses
        private clsAddresses _Addresses = null;
        public clsAddresses Addresses
        {
            get { return _Addresses; }
            set
            {
                _Addresses = value;
                ChoiceClearAllBut(eChoiceSpatialObjectAddress.scAddresses);
            }
        }

        private clsCompactAddresses _CompactAddresses = null;
        public clsCompactAddresses CompactAddresses
        {
            get { return _CompactAddresses; }
            set
            {
                _CompactAddresses = value;
                ChoiceClearAllBut(eChoiceSpatialObjectAddress.scCompactAddresses);
            }
        }
        // End Choice Addresses
        
        public clsConditions Conditions { get; set; }

        public clsContacts Contacts { get; set; }

        public clsHolds Holds { get; set; }
        public clsAdditionalInformation AdditionalInformation { get; set; }
        
        // Constructors
        public clsSpatialObject()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceSpatialObjectCAP pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceSpatialObjectCAP.scCAPIds)
            {
                _CAPIds = null;
            }
            if (pSelectedChoice != eChoiceSpatialObjectCAP.scCAPs)
            {
                _CAPs = null;
            }
        }

        private void ChoiceClearAllBut(eChoiceSpatialObjectAddress pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceSpatialObjectAddress.scAddresses)
            {
                _Addresses = null;
            }
            if (pSelectedChoice != eChoiceSpatialObjectAddress.scCompactAddresses)
            {
                _CompactAddresses = null;
            }
        }

    }
}
