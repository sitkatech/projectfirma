using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="HoldTypeIds">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="HoldTypeId"/>
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
    public class clsHoldTypeIds : clsElementList
    {
        // Members
        [XmlElement(ElementName = "HoldTypeId")]
        public List<clsHoldTypeId> HoldTypeId { get; set; }

        // Constructors
        public clsHoldTypeIds()
        {
        }

        // Methods
        public void Add(string pHoldType)
        {
            if (HoldTypeId == null)
            {
                HoldTypeId = new List<clsHoldTypeId>();
            }
            HoldTypeId.Add(new clsHoldTypeId(pHoldType));
        }
    }
}
