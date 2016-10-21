using System.Collections.Generic;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="InvoiceId">
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
    public class clsInvoiceId : clsIdentifier
    {
        // Constructors
        public clsInvoiceId()
        {
        }

        public clsInvoiceId(long pInvoiceNbr)
        {
            if (Keys == null)
            {
                Keys = new clsKeys(new string[]{pInvoiceNbr.ToString()});
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
                Keys.Key.AddRange(new string[] { pInvoiceNbr.ToString() });
            }
        }

    
    }
}
