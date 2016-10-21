using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="Keys">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence minOccurs="0" maxOccurs="unbounded">
					<xsd:element ref="Key"/>
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
    public class clsKeys : clsElementList
    {
        // Members
        [XmlElement(ElementName = "Key")]
        public List<string> Key { get; set; }

        // Constructors
        public clsKeys()
        {            
        }

        public clsKeys(string[] pKeys)
        {
            if (Key == null)
            {
                Key = new List<string>();
            }
            SetKeys(pKeys);
        }

        // Methods
        public void SetKeys(string[] pKeys)
        {
            if (Key == null)
            {
                Key = new List<string>();
            }
            else
            {
                Key.Clear();
            }
            Key.AddRange(pKeys);
        }
    }
}
