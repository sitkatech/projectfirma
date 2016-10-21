// Defined in AccelaOperationRepository_Authentication

/* Version Last Modified: 6.7
  <xsd:complexType name="AuthenticateUserResponse">
    <xsd:complexContent>
      <xsd:extension base="OperationResponse">
        <xsd:sequence>
          <xsd:choice minOccurs="0" maxOccurs="1">
            <xsd:group ref="PeopleIdSelect"/>
            <xsd:element ref="User"/>
            <xsd:element name="aboutExpiredDays" type="xsd:string"/>
            <xsd:element name="allowChangePassword" type="xsd:boolean"/>
            <xsd:element name="activeInspector" type="xsd:boolean"/>
            <xsd:element name="hasGISLicense" type="xsd:boolean"/>
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
 * 04/06/2012 Bob Thiele - Updated to version 7.1
*/

namespace GovXMLNet
{
    public class msgAuthenticateUserResponse : clsOperationResponse
    {
        // Members
       
        // Start Group PeopleIdSelect
        // Start Choice
        private clsInspectorId _InspectorId = null;
        public clsInspectorId InspectorId
        {
            get { return _InspectorId; }
            set
            {
                _InspectorId = value;
                ChoiceClearAllBut(eChoicePeopleIdSelect.scInspectorId);
            }
        }
        [System.Xml.Serialization.XmlIgnore]
        public bool InspectorIdSpecified { get { return this._InspectorId != null; } }
        
        private clsPeopleId _PeopleId = null;
        public clsPeopleId PeopleId
        {
            get { return _PeopleId; }
            set
            {
                _PeopleId = value;
                ChoiceClearAllBut(eChoicePeopleIdSelect.scPeopleId);
            }
        }
        [System.Xml.Serialization.XmlIgnore]
        public bool PeopleIdSpecified { get { return this._PeopleId != null; } }
        
        private clsUserId _UserId = null;
        public clsUserId UserId
        {
            get { return _UserId; }
            set
            {
                _UserId = value;
                ChoiceClearAllBut(eChoicePeopleIdSelect.scUserId);
            }
        }
        [System.Xml.Serialization.XmlIgnore]
        public bool UserIdSpecified { get { return this._UserId != null; } }
        // End Choice
        // End Group PeopleIdSelect

        private string _AboutExpiredDays;
        public string AboutExpiredDays
        {
            get { return _AboutExpiredDays; }
            set { _AboutExpiredDays = value; }
        }

        private bool _AllowChangePassword = false;
        public bool AllowChangePassword
        {
            get { return _AllowChangePassword; }
            set { _AllowChangePassword = value; }
        }

        private bool _ActiveInspector = false;
        public bool ActiveInspector
        {
            get { return _ActiveInspector; }
            set { _ActiveInspector = value; }
        }

        // Not present in Sitka; might reappear in new version?
        //private bool _hasGISLicense = false;
        //public bool hasGISLicense
        //{
        //    get { return _hasGISLicense; }
        //    set { _hasGISLicense = value; }
        //}

        // Constructors
        public msgAuthenticateUserResponse()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoicePeopleIdSelect pSelectedChoice)
        {
            if (pSelectedChoice != eChoicePeopleIdSelect.scInspectorId)
            {
                _InspectorId = null;
            }
            if (pSelectedChoice != eChoicePeopleIdSelect.scPeopleId)
            {
                _PeopleId = null;
            }
            if (pSelectedChoice != eChoicePeopleIdSelect.scUserId)
            {
                _UserId = null;
            }
        }
    }
}
