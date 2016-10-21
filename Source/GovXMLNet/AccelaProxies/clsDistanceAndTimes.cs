using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="DistanceAndTimes">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="DistanceAndTime"/>
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
    public class clsDistanceAndTimes : clsElementList
    {
        // Members
        [XmlElement(ElementName = "DistanceAndTime")]
        public List<clsDistanceAndTime> DistanceAndTime { get; set; }

        // Constructors
        public clsDistanceAndTimes()
        {
        }

        // Methods
        public void Add(clsDistanceAndTime pDistanceAndTime)
        {
            if (DistanceAndTime == null)
            {
                DistanceAndTime = new List<clsDistanceAndTime>();
            }
            DistanceAndTime.Add(pDistanceAndTime);
        }
    }
}
