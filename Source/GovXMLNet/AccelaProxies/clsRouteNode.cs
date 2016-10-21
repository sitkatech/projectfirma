// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="RouteNode">
		<xsd:complexContent>
			<xsd:extension base="element">
				<xsd:sequence>
					<xsd:element ref="Keys"/>
					<xsd:element ref="IdentifierDisplay" minOccurs="0"/>
					<xsd:element name="requestedOrderingPosition" type="gisRouteNodeRequestedOrderingPositionEnum" default="Any" form="qualified" minOccurs="0"/>
					<xsd:choice>
						<xsd:element ref="CAPId"/>
						<xsd:element ref="City"/>
						<xsd:element ref="CompactAddressId"/>
						<xsd:element ref="DetailAddress"/>
						<xsd:element ref="EstablishmentId"/>
						<xsd:element ref="GISObjectId"/>
						<xsd:element ref="InspectionId"/>
						<xsd:element ref="InspectionDistrictId"/>
						<xsd:element ref="ParcelId"/>
						<xsd:element ref="PostalCode"/>
						<xsd:element ref="SpatialDescriptor"/>
						<xsd:element ref="SpatialObjectId"/>
						<xsd:element ref="StructureId"/>
					</xsd:choice>
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
    public class clsRouteNode : clsElement
    {
        enum eChoiceRouteNode
        {
            scCAPId,
            scCity,
            scCompactAddressId,
            scDetailAddress,
            scEstablishmentId,
            scGISObjectId,
            scInspectionId,
            scInspectionDistrictId,
            scParcelId,
            scPostalCode,
            scSpatialDescriptor,
            scSpatialObjectId,
            scStructureId
        }

        // Members
        public clsKeys Keys { get; set; }

        private string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        private gisRouteNodeRequestedOrderingPositionEnum? _requestedOrderingPosition = gisRouteNodeRequestedOrderingPositionEnum.Any;
        public gisRouteNodeRequestedOrderingPositionEnum? requestedOrderingPosition
        {
            get
            {
                if (_requestedOrderingPosition.HasValue)
                {
                    return _requestedOrderingPosition.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _requestedOrderingPosition = value; }
        }
        public bool requestedOrderingPositionSpecified
        {
            get { return _requestedOrderingPosition != null; }
        }


        // Begin Choice        
        private clsCAPId _CAPId = null;
        public clsCAPId CAPId
                {
                    get { return _CAPId; }
            set
            {
                _CAPId = value;
                ChoiceClearAllBut(eChoiceRouteNode.scCAPId);
            }
        }

        private string _City = null;
        public string City
        {
            get { return _City; }
            set
            {
                _City = value;
                ChoiceClearAllBut(eChoiceRouteNode.scCity);
            }
        }

        private clsCompactAddressId _CompactAddressId = null;
        public clsCompactAddressId CompactAddressId
        {
            get { return _CompactAddressId; }
            set
            {
                _CompactAddressId = value;
                ChoiceClearAllBut(eChoiceRouteNode.scCompactAddressId);
            }
        }

        private clsDetailAddress _DetailAddress = null;
        public clsDetailAddress DetailAddress
        {
            get { return _DetailAddress; }
            set
            {
                _DetailAddress = value;
                ChoiceClearAllBut(eChoiceRouteNode.scDetailAddress);
            }
        }

        private clsEstablishmentId _EstablishmentId = null;
        public clsEstablishmentId EstablishmentId
        {
            get { return _EstablishmentId; }
            set
            {
                _EstablishmentId = value;
                ChoiceClearAllBut(eChoiceRouteNode.scEstablishmentId);
            }
        }

        private clsGISObjectId _GISObjectId = null;
        public clsGISObjectId GISObjectId
        {
            get { return _GISObjectId; }
            set
            {
                _GISObjectId = value;
                ChoiceClearAllBut(eChoiceRouteNode.scGISObjectId);
            }
        }

        private clsInspectionId _InspectionId = null;
        public clsInspectionId InspectionId
        {
            get { return _InspectionId; }
            set
            {
                _InspectionId = value;
                ChoiceClearAllBut(eChoiceRouteNode.scInspectionId);
            }
        }

        private clsInspectionDistrictId _InspectionDistrictId = null;
        public clsInspectionDistrictId InspectionDistrictId
        {
            get { return _InspectionDistrictId; }
            set
            {
                _InspectionDistrictId = value;
                ChoiceClearAllBut(eChoiceRouteNode.scInspectionDistrictId);
            }
        }

        private clsParcelId _ParcelId = null;
        public clsParcelId ParcelId
        {
            get { return _ParcelId; }
            set
            {
                _ParcelId = value;
                ChoiceClearAllBut(eChoiceRouteNode.scParcelId);
            }
        }

        private string _PostalCode = null;
        public string PostalCode
        {
            get { return _PostalCode; }
            set
            {
                _PostalCode = value;
                ChoiceClearAllBut(eChoiceRouteNode.scPostalCode);
            }
        }

        private clsSpatialDescriptor _SpatialDescriptor = null;
        public clsSpatialDescriptor SpatialDescriptor
        {
            get { return _SpatialDescriptor; }
            set
            {
                _SpatialDescriptor = value;
                ChoiceClearAllBut(eChoiceRouteNode.scSpatialDescriptor);
            }
        }

        private clsSpatialObjectId _SpatialObjectId = null;
        public clsSpatialObjectId SpatialObjectId
        {
            get { return _SpatialObjectId; }
            set
            {
                _SpatialObjectId = value;
                ChoiceClearAllBut(eChoiceRouteNode.scSpatialObjectId);
            }
        }

        private clsStructureId _StructureId = null;
        public clsStructureId StructureId
        {
            get { return _StructureId; }
            set
            {
                _StructureId = value;
                ChoiceClearAllBut(eChoiceRouteNode.scStructureId);
            }
        }
        // End Choice

        // Constructors
        public clsRouteNode()
        {
        }

        public clsRouteNode(clsParcelId pParcelId)
        {
            ParcelId = pParcelId;
        }

        public clsRouteNode(clsCAPId pCAPId)
        {
            CAPId = pCAPId;
        }

        public clsRouteNode(clsInspectionId pInspectionId)
        {
            InspectionId = pInspectionId;
        }
        
        // Methods
        private void ChoiceClearAllBut(eChoiceRouteNode pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceRouteNode.scCAPId)
            {
                _CAPId = null;
            }
            if (pSelectedChoice != eChoiceRouteNode.scCity)
            {
                _City = null;
            }
            if (pSelectedChoice != eChoiceRouteNode.scCompactAddressId)
            {
                _CompactAddressId = null;
            }
            if (pSelectedChoice != eChoiceRouteNode.scDetailAddress)
            {
                _DetailAddress = null;
            }
            if (pSelectedChoice != eChoiceRouteNode.scEstablishmentId)
            {
                _EstablishmentId = null;
            }
            if (pSelectedChoice != eChoiceRouteNode.scGISObjectId)
            {
                _GISObjectId = null;
            }
            if (pSelectedChoice != eChoiceRouteNode.scInspectionId)
            {
                _InspectionId = null;
            }
            if (pSelectedChoice != eChoiceRouteNode.scInspectionDistrictId)
            {
                _InspectionDistrictId = null;
            }
            if (pSelectedChoice != eChoiceRouteNode.scParcelId)
            {
                _ParcelId = null;
            }
            if (pSelectedChoice != eChoiceRouteNode.scPostalCode)
            {
                _PostalCode = null;
            }
            if (pSelectedChoice != eChoiceRouteNode.scSpatialDescriptor)
            {
                _SpatialDescriptor = null;
            }
            if (pSelectedChoice != eChoiceRouteNode.scSpatialObjectId)
            {
                _SpatialObjectId = null;
            }
            if (pSelectedChoice != eChoiceRouteNode.scStructureId)
            {
                _StructureId = null;
            }
        }
    }
}
