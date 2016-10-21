using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="InspectionTypeIds">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="InspectionTypeId"/>
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
    public class clsInspectionTypeIds : clsElementList
    {
        // Members
        [XmlElement(ElementName = "InspectionTypeId")]
        public List<clsInspectionTypeId> InspectionTypeId { get; set; }

        // Constructors
        public clsInspectionTypeIds()
        {
        }


        // Methods
        public void Add(string pInspCode, string pInspType, int pInspSeqNbr)
        {
            if (InspectionTypeId == null)
            {
                InspectionTypeId = new List<clsInspectionTypeId>();
            }
            InspectionTypeId.Add(new clsInspectionTypeId(pInspCode, pInspType, pInspSeqNbr));
        }        
    }
}
