using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="Statuses">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="Status"/>
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
    public class clsStatuses : clsElementList
    {
        // Members
        [XmlElement(ElementName = "Status")]
        public List<clsStatus> Status { get; set; }

        // Constructors
        public clsStatuses()
        {
        }

        // Methods
        public void Add(string pStatus)
        {
            if (Status == null)
            {
                Status = new List<clsStatus>();
            }
            Status.Add(new clsStatus(pStatus));
        }
    }
}
