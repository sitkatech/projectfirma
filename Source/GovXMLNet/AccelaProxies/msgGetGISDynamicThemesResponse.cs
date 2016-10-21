// Defined in AccelaOperationRepository_GIS

/* Version Last Modified: 6.7
	<xsd:complexType name="GetGISDynamicThemesResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence>
					<xsd:element ref="GISDynamicThemeGroups" minOccurs="0"/>
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
    public class msgGetGISDynamicThemesResponse : clsOperationResponse
    {
        // Members
        public clsGISDynamicThemeGroups GISDynamicThemeGroups { get; set; }
        
        // Constructors
        public msgGetGISDynamicThemesResponse()
        {
        }
    }
}
