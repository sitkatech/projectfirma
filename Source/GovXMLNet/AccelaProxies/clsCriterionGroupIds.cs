using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="CriterionGroupIds">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="CriterionGroupId"/>
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
    public class clsCriterionGroupIds : clsElementList
    {
        // Members
        [XmlElement(ElementName = "CriterionGroupId")]
        public List<clsCriterionGroupId> CriterionGroupId { get; set; }

        // Constructors
        public clsCriterionGroupIds()
        {
        }

        // Method
        public void Add(string pCriterionValue)
        {
            if (CriterionGroupId == null)
            {
                CriterionGroupId = new List<clsCriterionGroupId>();
            }
            CriterionGroupId.Add(new clsCriterionGroupId(pCriterionValue));
        }

    }
}
