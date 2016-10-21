using System;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="StatusDetail">
		<xsd:complexContent>
			<xsd:extension base="element">
				<xsd:sequence>
					<xsd:element ref="Department" minOccurs="0"/>
					<xsd:element ref="Staff" minOccurs="0"/>
					<xsd:element ref="Date" minOccurs="0"/>
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
    public class clsStatusDetail : clsElement
    {
        // Members
        public clsDepartment Department { get; set; }
        public clsStaff Staff { get; set; }

        [XmlIgnore]
        public DateTime? Date  { get; set; }
        [XmlElement("Date")]
        public string DateString
        {
            get
            {
                if (Date.HasValue)
                {
                    return Date.Value.ToString(Constants.cDateFormat); ;
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
                    Date = td;
                }
                else
                {
                    Date = null;
                }
            }
        }
        public bool DateStringSpecified
        {
            get { return Date != null; }
        }

        // Constructors
        public clsStatusDetail()
        {
        }
    }
}
