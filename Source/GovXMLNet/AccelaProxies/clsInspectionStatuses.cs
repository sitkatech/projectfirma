using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="InspectionStatuses">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="InspectionStatus"/>
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
    public class clsInspectionStatuses : clsElementList
    {
        // Members
        [XmlElement(ElementName = "InspectionStatus")]
        public List<clsInspectionStatus> InspectionStatus { get; set; }

        // Constructors
        public clsInspectionStatuses()
        {
        }


        // Methods
        public void Add(string pG6Status)
        {
            if (InspectionStatus == null)
            {
                InspectionStatus = new List<clsInspectionStatus>();
            }
            InspectionStatus.Add(new clsInspectionStatus(pG6Status));
        }
    }
}
