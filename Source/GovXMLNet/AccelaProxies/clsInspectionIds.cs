using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="InspectionIds">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="InspectionId"/>
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
    public class clsInspectionIds : clsElementList
    {
        // Members
        [XmlElement(ElementName = "InspectionId")]
        public List<clsInspectionId> InspectionId { get; set; }

        // Constructors
        public clsInspectionIds()
        {
        }

        //Methods
        public void Add(string pB1PerID1, string pB1PerID2, string pB1PerID3, long pG6ActNum)
        {
            if (InspectionId == null)
            {
                InspectionId = new List<clsInspectionId>();
            }
            InspectionId.Add(new clsInspectionId(pB1PerID1, pB1PerID2, pB1PerID3, pG6ActNum));
        }
        
    }
}
