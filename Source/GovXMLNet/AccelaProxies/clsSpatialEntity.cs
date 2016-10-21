// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="SpatialEntity" abstract="true">
    <xsd:complexContent>
      <xsd:extension base="element">
        <xsd:sequence>
          <xsd:element ref="Keys"/>
          <xsd:element ref="IdentifierDisplay"/>
          <xsd:element name="contextType" type="spatialReferenceTypeEnum" form="qualified" minOccurs="0"/>
          <xsd:element ref="Description" minOccurs="0"/>
          <xsd:element name="Text" type="text" minOccurs="0"/>
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
    public class clsSpatialEntity : clsElement
    {
        // Members
        public clsKeys Keys = new clsKeys();

        private string _IdentifierDisplay;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        private spatialReferenceTypeEnum? _contextType = null;
        public spatialReferenceTypeEnum? contextType
        {
            get
            {
                if (_contextType.HasValue)
                {
                    return _contextType.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _contextType = value; }
        }
        public bool contextTypeSpecified
        {
            get { return _contextType != null; }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private string _text;
        public string text
        {
            get { return _text; }
            set { _text = value; }
        }

        // Constructors
        public clsSpatialEntity()
        {
        }

    }
}
