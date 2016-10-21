using System;
using System.Xml.Serialization;

// Defined in AccelaOperationRepository_GovXML

/*
 * Note this sequence appears multiple times without a parent element so list is declared in parent, but still 
 * need the class for List<class>
*/

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
    public class aeAvailableDate
    {
        // Members
        [XmlIgnore]
        public DateTime? availableDate { get; set; }
        [XmlElement("availableDate")]
        public string availableDateString
        {
            get
            {
                if (availableDate.HasValue)
                {
                    return availableDate.Value.ToString(Constants.cDateFormat); ;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                DateTime td;
                if (DateTime.TryParse(value, out td))
                {
                    availableDate = td;
                }
                else
                {
                    availableDate = null;
                }
            }
        }
        public bool availableDateStringSpecified
        {
            get { return availableDate != null; }
        }

        // Constructors
        public aeAvailableDate()
        {
        }

        public aeAvailableDate(DateTime pAvailableDate)
        {
            availableDate = pAvailableDate;
        }
    }
}
