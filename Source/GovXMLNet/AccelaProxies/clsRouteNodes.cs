using System.Collections.Generic;
using System.Xml.Serialization;

// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="RouteNodes">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="RouteNode"/>
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
    public class clsRouteNodes : clsElementList
    {
        // Members
        [XmlElement(ElementName = "RouteNode")]
        public List<clsRouteNode> RouteNode { get; set; }

        // Constructors
        public clsRouteNodes()
        {
        }

        // Methods
        public void AddCAP(string pB1PerId1, string pB1PerId2, string pB1PerId3)
        {
            if (RouteNode == null)
            {
                RouteNode = new List<clsRouteNode>();
            }
            RouteNode.Add(new clsRouteNode(new clsCAPId(pB1PerId1, pB1PerId2, pB1PerId3)));
        }

        public void AddCAP(clsCAPId pCAPId)
        {
            if (RouteNode == null)
            {
                RouteNode = new List<clsRouteNode>();
            }
            RouteNode.Add(new clsRouteNode(pCAPId));
        }


        public void AddParcelId(clsParcelId pParcelId)
        {
            if (RouteNode == null)
            {
                RouteNode = new List<clsRouteNode>();
            }
            RouteNode.Add(new clsRouteNode(pParcelId));
        }

        public void AddInspectionId(clsInspectionId pInspectionId)
        {
            if (RouteNode == null)
            {
                RouteNode = new List<clsRouteNode>();
            }
            RouteNode.Add(new clsRouteNode(pInspectionId));
        }

    }
}
