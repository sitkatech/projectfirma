using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="GetAvailableInspectionDatesResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence>
					<xsd:element name="availableDate" type="calendarDate" minOccurs="0" maxOccurs="unbounded"/>
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
    public class msgGetAvailableInspectionDatesResponse : clsOperationResponse
    {
        // Members
        [XmlElement("availableDate")]
        public List<aeAvailableDate> availableDate { get; set; }

        // Constructors
        public msgGetAvailableInspectionDatesResponse()
        {
        }
    }
}
