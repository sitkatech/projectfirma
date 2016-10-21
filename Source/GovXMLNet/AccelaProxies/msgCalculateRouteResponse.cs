// Defined in AccelaOperationRepository_Authentication

/* Version Last Modified: 6.7
	<xsd:complexType name="CalculateRouteResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence minOccurs="0">
					<xsd:choice minOccurs="0">
						<xsd:element ref="RouteNodeIds"/>
						<xsd:element ref="RouteNodes"/>
					</xsd:choice>
					<xsd:element ref="RouteSegments" minOccurs="0"/>
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
    public class msgCalculateRouteResponse : clsOperationResponse
    {
        // Members

        // Start Choice
        private clsRouteNodeIds _RouteNodeIds = null;
        public clsRouteNodeIds RouteNodeIds
        {
            get { return _RouteNodeIds; }
            set
            {
                _RouteNodeIds = value;
                ChoiceClearAllBut(eChoiceCalculateRouteResponse.scRouteNodeIds);
            }
        }

        private clsRouteNodes _RouteNodes = null;
        public clsRouteNodes RouteNodes
        {
            get { return _RouteNodes; }
            set
            {
                _RouteNodes = value;
                ChoiceClearAllBut(eChoiceCalculateRouteResponse.scRouteNodes);
            }
        }
        // End Choice
        public clsRouteSegments RouteSegments { get; set; }

        // Constructors
        public msgCalculateRouteResponse()
        {
        }


        // Methods
        private void ChoiceClearAllBut(eChoiceCalculateRouteResponse pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceCalculateRouteResponse.scRouteNodeIds)
            {
                _RouteNodeIds = null;
            }
            if (pSelectedChoice != eChoiceCalculateRouteResponse.scRouteNodes)
            {
                _RouteNodes = null;
            }
        }
    }
}
