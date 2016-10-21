using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="InspectionDistrictIds">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="InspectionDistrictId"/>
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
    public class clsInspectionDistrictIds : clsElementList
    {
        // Members
        [XmlElement(ElementName = "InspectionDistrictId")]
        public List<clsInspectionDistrictId> InspectionDistrictId { get; set; }

        // Constructors
        public clsInspectionDistrictIds()
        {
        }

        //Methods
        public void Add(string pInspectionDistrictId)
        {
            if (InspectionDistrictId == null)
            {
                InspectionDistrictId = new List<clsInspectionDistrictId>();
            }
            InspectionDistrictId.Add(new clsInspectionDistrictId(pInspectionDistrictId));
        }
    }
}
