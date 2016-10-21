// Defined in AccelaOperationRepository_Authentication

/* Version Last Modified: 6.7
  <xsd:complexType name="AuthenticateUser">
    <xsd:complexContent>
      <xsd:extension base="OperationRequest">
        <xsd:sequence>
          <xsd:choice>
            <xsd:sequence>
              <xsd:element ref="Username"/>
              <xsd:element ref="Password"/>
              <xsd:element name="newPassword" type="password" minOccurs="0" maxOccurs="1" form="qualified"/>
            </xsd:sequence>
            <xsd:sequence>
              <xsd:element ref="SSOSessionId"/>
            </xsd:sequence>
          </xsd:choice>
          <xsd:element ref="Jurisdiction" minOccurs="0" maxOccurs="1"/>
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
    public class msgAuthenticateUser : clsOperationRequest
    {
        // Members
        // Start Choice
        private string _Username;
        public string Username
        {
            get { return _Username; }
            set
            {
                _Username = value;
                system.Username = value;
                ChoiceClearAllBut(eChoiceAuthenticateUser.scUserNamePassword);
            }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set 
            { 
                _Password = value;
                ChoiceClearAllBut(eChoiceAuthenticateUser.scUserNamePassword);
            }
        }

        private string _newPassword;
        public string newPassword
        {
            get { return _newPassword; }
            set 
            { 
                _newPassword = value;
                ChoiceClearAllBut(eChoiceAuthenticateUser.scUserNamePassword);
            }
        }

        private string _SSOSessionId;
        public string SSOSessionId
        {
            get { return _SSOSessionId; }
            set 
            { 
                _SSOSessionId = value;
                ChoiceClearAllBut(eChoiceAuthenticateUser.scSSOSessionId);
            }
        }
        // End Choice

        private string _Jurisdiction;
        public string Jurisdiction
        {
            get { return _Jurisdiction; }
            set { _Jurisdiction = value; }
        }


        // Constructors
        public msgAuthenticateUser()
        {
            system = new clsSystem();
        }

        public msgAuthenticateUser(string pServiceProvider, string pUserName, string pPassword)
        {
            system = new clsSystem(pServiceProvider, pUserName);
            Username = pUserName;
            Password = pPassword;

            // Seems like the most advanced context for getting the most data
            system.Context = contextEnumType.AccelaWirelessInspection;
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceAuthenticateUser pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceAuthenticateUser.scUserNamePassword)
            {
                _Username = null;
                _Password = null;
                _newPassword = null;
            }
            if (pSelectedChoice != eChoiceAuthenticateUser.scSSOSessionId)
            {
                _SSOSessionId = null;
            }
        }
    }
}
