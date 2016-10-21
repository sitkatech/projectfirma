using System.Collections.Generic;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="InspectorId">
		<xsd:complexContent>
			<xsd:extension base="PeopleId"/>
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
    public class clsInspectorId : clsPeopleId
    {
        // Constructors
        public clsInspectorId()
        {
        }

        public clsInspectorId(string pUserName)
        {
            if (Keys == null)
            {
                Keys = new clsKeys(new string[] { pUserName });
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
                Keys.Key.AddRange(new string[] { pUserName });
            }
        }
    }
}
