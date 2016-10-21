using System;
using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="DateRanges">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="DateRange"/>
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
    public class clsDateRanges : clsElementList
    {
        // Members
        [XmlElement(ElementName = "DateRange")]
        public List<clsDateRange> DateRange { get; set; }

        // Constructors
        public clsDateRanges()
        {
        }

        // Methods
        public void Add(DateTime pFrom, DateTime pTo)
        {
            if (DateRange == null)
            {
                DateRange = new List<clsDateRange>();
            }
            DateRange.Add(new clsDateRange(pFrom, pTo));
        }
    }
}
