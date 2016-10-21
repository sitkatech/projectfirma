using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="CAPTypeIds">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="CAPTypeId"/>
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
    public class clsCAPTypeIds : clsElementList
    {
        // Members
        [XmlElement(ElementName = "CAPTypeId")]
        public List<clsCAPTypeId> CAPTypeId { get; set; }

        // Constructors
        public clsCAPTypeIds()
        {
        }

        // Methods
        public void Add(string pB1PerGroup = null, string pB1PerType = null, string pB1PerSubType = null, string pB1PerCategory = null, string pDescription = null)
        {
            if (CAPTypeId == null)
            {
                CAPTypeId = new List<clsCAPTypeId>();
            }
            CAPTypeId.Add(new clsCAPTypeId(pB1PerGroup, pB1PerType, pB1PerSubType, pB1PerCategory, pDescription));
        }
    }
}
