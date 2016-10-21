using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="ConditionTypeIds">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="ConditionTypeId"/>
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
    public class clsConditionTypeIds : clsElementList
    {
        // Members
        [XmlElement(ElementName = "ConditionTypeId")]
        public List<clsConditionTypeId> ConditionTypeId { get; set; }

        // Constructors
        public clsConditionTypeIds()
        {
        }

        // Methods
        public void Add(string pConditionType)
        {
            if (ConditionTypeId != null)
            {
                ConditionTypeId = new List<clsConditionTypeId>();
            }
            ConditionTypeId.Add(new clsConditionTypeId(pConditionType));
        }
    }
}
