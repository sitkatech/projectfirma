// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="SetInspectionPriority">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element ref="Inspections"/>
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
    public class msgSetInspectionPriority : clsOperationRequest
    {
        // Members
        public clsInspections Inspections { get; set; }

        // Constructors
        public msgSetInspectionPriority()
        {
        }
    }
}
