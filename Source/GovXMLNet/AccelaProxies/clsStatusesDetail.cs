// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="StatusesDetail">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element name="Closed" type="StatusDetail" minOccurs="0"/>
					<xsd:element name="Assigned" type="StatusDetail" minOccurs="0"/>
					<xsd:element name="Completed" type="StatusDetail" minOccurs="0"/>
					<xsd:element name="Scheduled" type="StatusDetail" minOccurs="0"/>
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
    public class clsStatusesDetail : clsElementList
    {
        // TODO this is wrong, maybe needs a struct, but need example to finish
        public clsStatusDetail Closed { get; set; }
        public clsStatusDetail Assigned { get; set; }
        public clsStatusDetail Completed { get; set; }
        public clsStatusDetail Scheduled { get; set; }

        // Constructors
        public clsStatusesDetail()
        {
        }
    }
}
