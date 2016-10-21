// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="ConditionTypeId">
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
    public class clsConditionTypeId : clsIdentifier
    {
        // Constructors
        public clsConditionTypeId()
        {
        }

        public clsConditionTypeId(string pConditionType)
        {
            // Add keys and identifier if not null.
            if (Keys != null)
            {
                Keys = new clsKeys();
            }
            Keys.Key.Add(pConditionType);
        }
    }
}
