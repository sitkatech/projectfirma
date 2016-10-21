using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="InspectorIds">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="InspectorId"/>
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
    public class clsInspectorIds : clsElementList
    {
        // Members
        [XmlElement(ElementName = "InspectorId")]
        public List<clsInspectorId> InspectorId { get; set; }

        // Constructors
        public clsInspectorIds()
        {
        }

        public clsInspectorIds(string[] pUserNames)
        {
            foreach (string user in pUserNames)
            {
                Add(user);
            }
        }


        // Methods
        public void Add(string pUserName)
        {
            if (InspectorId == null)
            {
                InspectorId = new List<clsInspectorId>();
            }
            InspectorId.Add(new clsInspectorId(pUserName));
        }
    }
}
