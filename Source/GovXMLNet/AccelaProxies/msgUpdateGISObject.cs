// Defined in AccelaOperationRepository_GIS

/* Version Last Modified: 6.7
	<xsd:complexType name="UpdateGISObject">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element ref="Keys"/>
					<xsd:element ref="IdentifierDisplay" minOccurs="0"/>
					<xsd:element name="contextType" type="datasetChangeEnum" form="qualified"/>
					<xsd:choice>
						<xsd:element ref="Attributes"/>
						<xsd:element ref="Extent"/>
						<xsd:element ref="GISLayerId"/>
						<xsd:element ref="MapServiceId"/>
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
    public class msgUpdateGISObject : clsOperationRequest
    {
        public clsKeys Keys { get; set; }

        private string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        private datasetChangeEnum _contextType;
        public datasetChangeEnum contextType
        {
            get { return _contextType; }
            set { _contextType = value; }
        }

        // Begin choice
        private clsAttributes _Attributes = null;
        public clsAttributes Attributes
        {
            get { return _Attributes; }
            set
            {
                _Attributes = value;
                ChoiceClearAllBut(eChoiceUpdateGISObject.scAttributes);
            }
        }

        private clsExtent _Extent = null;
        public clsExtent Extent
        {
            get { return _Extent; }
            set
            {
                _Extent = value;
                ChoiceClearAllBut(eChoiceUpdateGISObject.scExtent);
            }
        }

        private clsGISLayerId _GISLayerId = null;
        public clsGISLayerId GISLayerId
        {
            get { return _GISLayerId; }
            set
            {
                _GISLayerId = value;
                ChoiceClearAllBut(eChoiceUpdateGISObject.scGISLayerId);
            }
        }

        private clsMapServiceId _MapServiceId = null;
        public clsMapServiceId MapServiceId
        {
            get { return _MapServiceId; }
            set
            {
                _MapServiceId = value;
                ChoiceClearAllBut(eChoiceUpdateGISObject.scMapServiceId);
            }
        }
        // End choice

        // Constructors
        public msgUpdateGISObject()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceUpdateGISObject pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceUpdateGISObject.scAttributes)
            {
                _Attributes = null;
            }
            if (pSelectedChoice != eChoiceUpdateGISObject.scExtent)
            {
                _Extent = null;
            }
            if (pSelectedChoice != eChoiceUpdateGISObject.scGISLayerId)
            {
                _GISLayerId = null;
            }
            if (pSelectedChoice != eChoiceUpdateGISObject.scMapServiceId)
            {
                _MapServiceId = null;
            }
        }
    }
}
