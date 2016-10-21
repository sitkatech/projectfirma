using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="InspectionDistricts">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="InspectionDistrict"/>
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
    public class clsInspectionDistricts : clsElementList
    {
        // Members
        [XmlElement(ElementName = "InspectionDistrict")]
        public List<clsInspectionDistrict> InspectionDistrict { get; set; }

        // Constructors
        public clsInspectionDistricts()
        {
        }


        // Methods
        public void Add(string pInspectionDistrict)
        {
            if (InspectionDistrict == null)
            {
                InspectionDistrict = new List<clsInspectionDistrict>();
            }
            InspectionDistrict.Add(new clsInspectionDistrict(pInspectionDistrict));
        }
    }
}
