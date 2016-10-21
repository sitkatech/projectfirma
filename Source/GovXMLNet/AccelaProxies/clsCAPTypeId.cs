using System.Collections.Generic;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="CAPTypeId">
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
    public class clsCAPTypeId : clsIdentifier
    {
        // Constructors
        public clsCAPTypeId()
        {
        }

        public clsCAPTypeId(string pB1PerGroup, string pB1PerType, string pB1PerSubType, string pB1PerCategory, string pIdentifierDisplay = null)
        {
            // Add keys and identifier if not null.  The keys are nested because they are required in order.
            if (Keys == null)
            {
                Keys = new clsKeys();
            }
            if (pB1PerGroup != null)
            {
                if (Keys.Key == null)
                {
                    Keys.Key = new List<string>();
                }
                Keys.Key.Add(pB1PerGroup);

                if (pB1PerType != null)
                {
                    Keys.Key.Add(pB1PerType);

                    if (pB1PerSubType != null)
                    {
                        Keys.Key.Add(pB1PerSubType);

                        if (pB1PerCategory != null)
                        {
                            Keys.Key.Add(pB1PerCategory);
                        }
                    }
                }
            }
            if (pIdentifierDisplay != null)
            {
               IdentifierDisplay = pIdentifierDisplay;
            }

        }

    }
}
