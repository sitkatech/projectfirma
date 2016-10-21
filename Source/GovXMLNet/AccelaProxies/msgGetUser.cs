// Defined in AccelaOperationRepository_Authentication
// Valid only for AccelaIvr context

/* Version Last Modified: 6.7
  <xsd:complexType name="GetUser">
    <xsd:complexContent>
      <xsd:extension base="OperationRequest">
        <xsd:sequence>
          <xsd:choice>
            <xsd:group ref="PeopleIdSelect"/>
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
    public class msgGetUser : clsOperationRequest
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

        // Constructors
        public msgGetUser()
        {
            system = new clsSystem();
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
