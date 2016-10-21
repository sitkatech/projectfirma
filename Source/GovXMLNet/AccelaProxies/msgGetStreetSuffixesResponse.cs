// Defined in AccelaOperationRepository_GIS

/* Version Last Modified: 7.1
    <xsd:complexType name="GetStreetSuffixesResponse">
        <xsd:complexContent>
            <xsd:extension base="OperationResponse">
                <xsd:sequence minOccurs="0">
                    <xsd:element ref="StreetSuffixes" minOccurs="0"/>
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
    public class msgGetStreetSuffixesResponse : clsOperationResponse
    {
        // Members
        public clsStreetSuffixes StreetSuffixes { get; set; }

        // Constructors
        public msgGetStreetSuffixesResponse()
        {
        }
    }
}
