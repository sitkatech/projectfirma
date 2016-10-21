// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="LegalDescription">
    <xsd:complexContent>
      <xsd:extension base="SpatialDescriptor">
        <xsd:sequence>
          <xsd:choice>
            <xsd:element name="String" type="text" form="qualified" maxOccurs="unbounded"/>
            <xsd:element name="Text" type="xsd:string"/>
          </xsd:choice>
          <xsd:element name="referenceAddress" type="text" form="qualified" minOccurs="0"/>
          <xsd:element name="referenceEntity" type="text" form="qualified" minOccurs="0"/>
          <xsd:element name="referenceLandType" type="text" form="qualified" minOccurs="0"/>
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
    public class clsLegalDescription : clsSpatialDescriptor
    {
        enum eChoiceLegalDescription
        {
            scString,
            scText
        }

        // Members

        // Start Choice
        private string _String = null;
        public string String
        {
            get { return _String; }
            set
            {
                _String = value;
                ChoiceClearAllBut(eChoiceLegalDescription.scString);
            }
        }

        private string _Text = null;
        public string Text
        {
            get { return _Text; }
            set
            {
                _Text = value;
                ChoiceClearAllBut(eChoiceLegalDescription.scText);
            }
        }
        // End Choice

        private string _referenceAddress = null;
        public string referenceAddress
        {
            get { return _referenceAddress; }
            set { _referenceAddress = value; }
        }

        private string _referenceEntity = null;
        public string referenceEntity
        {
            get { return _referenceEntity; }
            set { _referenceEntity = value; }
        }

        private string _referenceLandType = null;
        public string referenceLandType
        {
            get { return _referenceLandType; }
            set { _referenceLandType = value; }
        }

        // Constructors
        public clsLegalDescription()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceLegalDescription pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceLegalDescription.scString)
            {
                _String = null;
            }
            if (pSelectedChoice != eChoiceLegalDescription.scText)
            {
                _Text = null;
            }
        }
    }
}
