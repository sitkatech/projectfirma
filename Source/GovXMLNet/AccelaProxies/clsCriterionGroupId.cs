using System.Collections.Generic;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="CriterionGroupId">
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
    public class clsCriterionGroupId : clsIdentifier
    {
        // Constructors
        public clsCriterionGroupId()
        {
        }

        public clsCriterionGroupId(string pCriterion)
        {
            if (Keys == null)
            {
                Keys = new clsKeys(new string[] { pCriterion });
            }
            else
            {
                if (Keys.Key == null)
                {
                    Keys.Key = new List<string>();
                }
                else
                {
                    Keys.Key.Clear();
                }
                Keys.Key.Add(pCriterion);
            }
        }
    }
}
