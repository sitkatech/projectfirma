// Defined in AccelaOperationRepository_GIS

/* Version Last Modified: 6.7
	<xsd:complexType name="ViewGISDynamicTheme">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element ref="MapServiceId" minOccurs="0"/>
					<xsd:element ref="GISDynamicTheme"/>
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
    public class msgViewGISDynamicTheme : clsOperationRequest
    {
        // Members
        public clsMapServiceId MapServiceId { get; set; }

        public clsGISDynamicTheme GISDynamicTheme { get; set; }

        // Constructors
        public msgViewGISDynamicTheme()
        {
        }
    }
}
