using System.Collections.Generic;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="LicenseTypeId">
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
    public class clsLicenseTypeId : clsIdentifier
    {
        // Constructors
        public clsLicenseTypeId()
        {
        }

        public clsLicenseTypeId(string pLicenseType)
        {
            if (Keys == null)
            {
                Keys = new clsKeys(new string[] { pLicenseType });
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
                Keys.Key.AddRange(new string[] { pLicenseType });
            }
        }
}
}
