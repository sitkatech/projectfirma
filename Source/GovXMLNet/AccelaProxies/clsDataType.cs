// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="DataType">
    <xsd:complexContent>
      <xsd:extension base="element">
        <xsd:sequence>
          <xsd:element name="type" form="qualified">
            <xsd:simpleType>
              <xsd:restriction base="xsd:string">
                <xsd:enumeration value="Checkbox"/>
                <xsd:enumeration value="Date"/>
                <xsd:enumeration value="Enumeration"/>
                <xsd:enumeration value="Float"/>
                <xsd:enumeration value="Integer"/>
                <xsd:enumeration value="ReadOnlyText"/>
                <xsd:enumeration value="String"/>
                <xsd:enumeration value="YesNo"/>
                <xsd:enumeration value="Currency"/>
              </xsd:restriction>
            </xsd:simpleType>
          </xsd:element>
          <xsd:choice minOccurs="0">
            <xsd:element name="enumeration" type="StringList" form="qualified"/>
            <xsd:element ref="Enumerations" minOccurs="0" maxOccurs="1"/>
            <xsd:element name="enumerationListId" type="enumerationListIdentifier" form="qualified"/>
            <xsd:element name="inputRange" type="Range" form="qualified"/>
          </xsd:choice>
          <xsd:element name="inputRequired" type="xsd:boolean" form="qualified" minOccurs="0"/>
          <xsd:element name="readOnly" type="xsd:boolean" form="qualified" minOccurs="0"/>
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
    public class clsDataType : clsElement
    {


        // Members
        private enumDataType _type;
        public enumDataType type
        {
            get { return _type; }
            set { _type = value; }
        }

        // Begin choice
        private clsStringList _enumeration = null;
        public clsStringList enumeration
        {
            get { return _enumeration; }
            set 
            { 
                _enumeration = value;
                // Sitka removed this, was erasing enumeration: ChoiceClearAllBut(eChoiceDataType.scEnumeration);
            }
        }

        private clsEnumerations _Enumerations = null;
        public clsEnumerations Enumerations
        {
            get { return _Enumerations; }
            set 
            {
                _Enumerations = value;
                // ChoiceClearAllBut(eChoiceDataType.scEnumerations);
            }
        }

        private string _enumerationListIdentier = null;
        public string enumerationListIdentifier
        {
            get { return _enumerationListIdentier; }
            set 
            { 
                _enumerationListIdentier = value;
                // Sitka removed this, was erasing enumeration: ChoiceClearAllBut(eChoiceDataType.scEnumerationListId);
            }
        }

        private clsRange _inputRange = null;
        public clsRange inputRange
        {
            get { return _inputRange; }
            set 
            {
                _inputRange = value;
                // Sitka removed this, was erasing enumeration: ChoiceClearAllBut(eChoiceDataType.scInputRange);
            }
        }
        // End choice

        private bool? _inputRequired = null;
        public bool? inputRequired
        {
            get
            {
                if (_inputRequired.HasValue)
                {
                    return _inputRequired.Value;
                }
                else
                {
                    return null;
                }
            }

            set { _inputRequired = value; }
        }
        public bool inputRequiredSpecified
        {
            get { return _inputRequired != null; }
        }

        private bool? _readOnly = null;
        public bool? readOnly
        {
            get
            {
                if (_readOnly.HasValue)
                {
                    return _readOnly.Value;
                }
                else
                {
                    return null;
                }
            }

            set { _readOnly = value; }
        }
        public bool readOnlySpecified
        {
            get { return _readOnly != null; }
        }
        
        // Constructors
        public clsDataType()
        {
        }

        // Sitka removed this, was erasing enumeration: 
        //
        //enum eChoiceDataType
        //{
        //    scEnumeration,
        //    scEnumerations,
        //    scEnumerationListId,
        //    scInputRange
        //}
        // // Methods
        //private void ChoiceClearAllBut(eChoiceDataType pSelectedChoice)
        //{
        //    /*
        //    if (pSelectedChoice != eChoiceDataType.scEnumeration)
        //    {
        //        _enumeration = null;
        //    }
        //    if (pSelectedChoice != eChoiceDataType.scEnumerations)
        //    {
        //        _Enumerations = null;
        //    }*/
        //    // Both enumeration and Enumerations appear so grouping together here
        //    if (pSelectedChoice != eChoiceDataType.scEnumeration && pSelectedChoice != eChoiceDataType.scEnumerations)
        //    {
        //        _enumeration = null;
        //        _Enumerations = null;
        //    }
        //    if (pSelectedChoice != eChoiceDataType.scEnumerationListId)
        //    {
        //        _enumerationListIdentier = null;
        //    }
        //    if (pSelectedChoice != eChoiceDataType.scInputRange)
        //    {
        //        _inputRange = null;
        //    }
        // }
    }
}
