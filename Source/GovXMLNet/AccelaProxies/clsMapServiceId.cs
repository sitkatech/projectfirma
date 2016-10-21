// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="MapServiceId">
		<xsd:complexContent>
			<xsd:extension base="Identifier"/>
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
    public class clsMapServiceId : clsIdentifier
    {
        // Constructors
        public clsMapServiceId()
        {
        }

        public clsMapServiceId(string pMapServiceID)
        {
            if (Keys == null)
            {
                Keys = new clsKeys(new string[] {pMapServiceID});
            }
        }

    }
}
