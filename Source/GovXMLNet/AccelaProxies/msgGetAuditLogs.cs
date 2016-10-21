// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
  <xsd:complexType name="GetAuditLogs">
    <xsd:complexContent>
      <xsd:extension base="OperationRequest">
        <xsd:sequence>
          <xsd:element name="EntityKeys " ref="Keys" minOccurs="0"/>
          <xsd:element name="entityId" type="xsd:string" minOccurs="0"/>
          <xsd:element name="entityType" type="xsd:entityTypeEnum" minOccurs="0"/>
          <xsd:element name="field" type="xsd:string" minOccurs="0"/>
          <xsd:element name="fieldValue" type="xsd:string" minOccurs="0"/>
          <xsd:element name=" DateRange" ref="DateRange" minOccurs="0"/>
          <xsd:element name=" InspectorId" ref="InspectorId" minOccurs="0"/>
          <xsd:element name=" OrderBy" ref="Enumerations" minOccurs="0"/>
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
    public class msgGetAuditLogs : clsOperationRequest
    {
        // Members
        public clsKeys EntityKeys { get; set; }

        private string _entityId;
        public string entityId
        {
            get { return _entityId; }
            set { _entityId = value; }
        }

        private entityTypeEnum? _entityType = null;
        public entityTypeEnum? entityType
        {
            get
            {
                if (_entityType.HasValue)
                {
                    return _entityType.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _entityType = value; }
        }
        public bool entityTypeSpecified
        {
            get { return _entityType != null; }
        }

        private string _field;
        public string field
        {
            get { return _field; }
            set { _field = value; }
        }

        private string _fieldValue;
        public string fieldValue
        {
            get { return _fieldValue; }
            set { _fieldValue = value; }
        }

        public clsDateRange DateRange { get; set; }
        public clsInspectorId InspectorId { get; set; }
        public clsEnumerations OrderBy { get; set; }

        // Constructors
        public msgGetAuditLogs()
        {
        }

    }
}
