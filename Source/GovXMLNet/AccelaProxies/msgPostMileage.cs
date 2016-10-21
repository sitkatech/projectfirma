// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="PostMileage">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element ref="InspectorId"/>
					<xsd:element ref="DistanceAndTimes"/>
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
    public class msgPostMileage : clsOperationRequest
    {
        // Members
        public clsInspectorId InspectorId { get; set; }

        public clsDistanceAndTimes DistanceAndTimes { get; set; }

        // Constructors
        public msgPostMileage()
        {
        }
    }
}
