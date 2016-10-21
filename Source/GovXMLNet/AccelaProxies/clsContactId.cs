using System.Collections.Generic;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="ContactId">
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
    public class clsContactId : clsIdentifier
    {
        // Constructors
        public clsContactId()
        {
        }

        public clsContactId(string pB1PerID1, string pB1PerID2, string pB1PerID3, long pB1ContactNbr)
        {
            if (Keys == null)
            {
                Keys = new clsKeys(new string[] { pB1PerID1, pB1PerID2, pB1PerID3, pB1ContactNbr.ToString() });
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
                Keys.Key.AddRange(new string[] { pB1PerID1, pB1PerID2, pB1PerID3, pB1ContactNbr.ToString() });
            }
        }
    }
}
