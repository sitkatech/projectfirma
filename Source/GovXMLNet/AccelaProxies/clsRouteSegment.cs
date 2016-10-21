// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
    <xsd:complexType name="RouteSegment">
      <xsd:complexContent>
        <xsd:extension base="element">
          <xsd:sequence>
            <xsd:element ref="Keys" minOccurs="0"/>
            <xsd:element ref="IdentifierDisplay" minOccurs="0"/>
            <xsd:element name="Text" type="xsd:string"/>
            <xsd:element name="fromRouteNodeId" type="RouteNodeId" form="qualified" minOccurs="0"/>
            <xsd:element name="toRouteNodeId" type="RouteNodeId" form="qualified" minOccurs="0"/>
            <xsd:element ref="GISObjectIds" minOccurs="0"/>
            <xsd:element ref="GPSReferences" minOccurs="0"/>
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
    public class clsRouteSegment : clsElement
    {
        // Members
        public clsKeys Keys { get; set; }

        private string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        private string _Text = null;
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }

        public clsRouteNodeId fromRouteNodeId { get; set; }
        public clsRouteNodeId toRouteNodeId { get; set; }
        public clsGISObjectIds GISObjectIds { get; set; }
        public clsGPSReferences GPSReferences { get; set; }
        
        // Constructors
        public clsRouteSegment()
        {
        }
    }
}
