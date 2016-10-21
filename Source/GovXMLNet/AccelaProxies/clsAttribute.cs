// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="Attribute">
    <xsd:complexContent>
      <xsd:extension base="element">
        <xsd:sequence>
          <xsd:element name="name" type="text" form="qualified"/>
          <xsd:choice minOccurs="0">
            <xsd:element name="type" type="attributeTypeEnum" form="qualified"/>
            <xsd:element name="value" type="text" form="qualified"/>
            <xsd:element name="dispalyOrder" type="xsd:string"/>
          </xsd:choice>
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
    public class clsAttribute : clsElement
    {
        enum eChoiceAttribute
        {
            scType,
            scValue,
            scDisplayOrder
        }

        // Members
        private string _Name = null;
        public string name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        // Start choice
        private attributeTypeEnum? _type = null;
        public attributeTypeEnum? type
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
            set 
            { 
                _type = value;
                ChoiceClearAllBut(eChoiceAttribute.scType);
            }
        }
        public bool typeSpecified
        {
            get { return _type != null; }
        }

        private string _value = null;
        public string value
        {
            get { return _value; }
            set 
            { 
                _value = value;
                ChoiceClearAllBut(eChoiceAttribute.scValue);
            }
        }

        private string _displayOrder = null;
        public string displayOrder
        {
            get { return _displayOrder; }
            set 
            { 
                _displayOrder = value;
                ChoiceClearAllBut(eChoiceAttribute.scDisplayOrder);
            }
        }
        // End Choice

        // Constructors
        public clsAttribute()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceAttribute pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceAttribute.scType)
            {
                _type = null;
            }
            if (pSelectedChoice != eChoiceAttribute.scValue)
            {
                _value = null;
            }
            if (pSelectedChoice != eChoiceAttribute.scDisplayOrder)
            {
                _displayOrder = null;
            }
        }
    }
}
