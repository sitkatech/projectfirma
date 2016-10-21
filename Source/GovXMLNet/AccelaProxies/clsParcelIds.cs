using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="ParcelIds">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="ParcelId"/>
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
    public class clsParcelIds : clsElementList
    {
        // Members
        [XmlElement(ElementName = "ParcelId")]
        public List<clsParcelId> ParcelId { get; set; }

        // Constructors
        public clsParcelIds()
        {
        }

        // Methods
        public void Add(string pParcelId)
        {
            Add(new clsParcelId(pParcelId));
        }

        public void Add(clsParcelId parcelId)
        {
            if (ParcelId == null)
            {
                ParcelId = new List<clsParcelId>();
            }

            ParcelId.Add(parcelId);
        }

    }
}
