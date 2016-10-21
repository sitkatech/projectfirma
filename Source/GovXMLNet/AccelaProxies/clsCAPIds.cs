using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="CAPIds">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="CAPId"/>
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
    public class clsCAPIds : clsElementList
    {
        // Members
        [XmlElement(ElementName = "CAPId")]
        public List<clsCAPId> CAPId { get; set; }

        // Constructors
        public clsCAPIds()
        {
        }

        // Methods
        public void Add(string pB1PerID1, string pB1PerID2, string pB1PerID3)
        {
            if (CAPId == null)
            {
                CAPId = new List<clsCAPId>();
            }
            CAPId.Add(new clsCAPId(pB1PerID1, pB1PerID2, pB1PerID3));
        }
    }
}
