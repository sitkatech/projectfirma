// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 7.1
    <xsd:complexType name="TimeAccountingType">
      <xsd:complexContent>
        <xsd:extension base="Identifier">
          <xsd:sequence>
            <xsd:element name="usage" type="xsd:string" minOccurs="0" maxOccurs="1" />
            <xsd:element name="security" type="xsd:string" minOccurs="0" maxOccurs="1" />
            <xsd:element name="RecordGroup" type="xsd:string" minOccurs="0" />
            <xsd:element name="RecordType" type="xsd:string" minOccurs="0" />
            <xsd:element name="RecordSubType" type="xsd:string" minOccurs="0" />
            <xsd:element name="RecordCategory" type="xsd:string" minOccurs="0" />
          </xsd:sequence>
        </xsd:extension>
      </xsd:complexContent>
    </xsd:complexType>
*/

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 4/11/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class clsTimeAccountingType : clsIdentifier
    {
        // Members
        private string _usage = null;
        public string usage
        {
            get { return _usage; }
            set { _usage = value; }
        }

        private string _security = null;
        public string security
        {
            get { return _security; }
            set { _security = value; }
        }

        private string _RecordGroup = null;
        public string RecordGroup
        {
            get { return _RecordGroup; }
            set { _RecordGroup = value; }
        }

        private string _RecordType = null;
        public string RecordType
        {
            get { return _RecordType; }
            set { _RecordType = value; }
        }

        private string _RecordSubType = null;
        public string RecordSubType
        {
            get { return _RecordSubType; }
            set { _RecordSubType = value; }
        }

        private string _RecordCategory = null;
        public string RecordCategory
        {
            get { return _RecordCategory; }
            set { _RecordCategory = value; }
        }

        // Constructors
        public clsTimeAccountingType()
        {
        }
    }
}
