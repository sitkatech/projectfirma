using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="InspectionTypes">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="InspectionType"/>
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
    public class clsInspectionTypes : clsElementList
    {
        // Members
        [XmlElement(ElementName = "InspectionType")]
        public List<clsInspectionType> InspectionType { get; set; }

        // Constructors
        public clsInspectionTypes()
        {
        }

        // Methods
        public void Add(string pInspectionType)
        {
            if (InspectionType == null)
            {
                InspectionType = new List<clsInspectionType>();
            }
            InspectionType.Add(new clsInspectionType(pInspectionType));
        }
        public void Add(string pInspectionGroupCode, string pInspectionType, int pInspectionTypeSeqNbr)
        {
            if (InspectionType == null)
            {
                InspectionType = new List<clsInspectionType>();
            }
            InspectionType.Add(new clsInspectionType());

        }
    }
}
