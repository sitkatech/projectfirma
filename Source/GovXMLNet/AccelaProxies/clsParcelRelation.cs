// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="ParcelRelation">
    <xsd:complexContent>
      <xsd:extension base="element">
        <xsd:sequence>
          <xsd:element ref="Identifier" minOccurs="0">
            <xsd:element name="contextType" ref="capRelationContextTypeEnum" form="qualified" minOccurs="0"/>
            <xsd:element name="type" ref="parcelsGenealogyTypeEnum" form="qualified" minOccurs="0"/>
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
    public class clsParcelRelation : clsElement
    {
        public clsIdentifier Identifier { get; set; }

        private capRelationContextTypeEnum? _contextType = null;
        public capRelationContextTypeEnum? contextType
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

        private capRelationContextTypeEnum? _type = null;
        public capRelationContextTypeEnum? type
        {
            get
            {
                if (_type.HasValue)
                {
                    return _type.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _type = value; }
        }
        public bool typeSpecified
        {
            get { return _type != null; }
        }

        // Constructors
        public clsParcelRelation()
        {
        }
    }
}
