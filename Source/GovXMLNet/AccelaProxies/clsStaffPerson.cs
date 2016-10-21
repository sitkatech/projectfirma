// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="StaffPerson">
		<xsd:complexContent>
			<xsd:extension base="element">
				<xsd:sequence maxOccurs="unbounded">
					<xsd:element ref="Keys" minOccurs="0"/>
					<xsd:element ref="IdentifierDisplay" minOccurs="0"/>
					<xsd:sequence maxOccurs="unbounded">
						<xsd:element name="firstName" type="xsd:string" minOccurs="0"/>
						<xsd:element name="lastName" type="xsd:string" minOccurs="0"/>
						<xsd:element name="auditStatus" type="xsd:string" minOccurs="0"/>
						<xsd:element name="serviceProviderCode" type="xsd:string" minOccurs="0"/>
						<xsd:element name="userId" type="xsd:string" minOccurs="0"/>
						<xsd:element name="agencyCode" type="xsd:string" minOccurs="0"/>
						<xsd:element name="bureauCode" type="xsd:string" minOccurs="0"/>
						<xsd:element name="divisionCode" type="xsd:string" minOccurs="0"/>
						<xsd:element name="sectionCode" type="xsd:string" minOccurs="0"/>
						<xsd:element name="groupCode" type="xsd:string" minOccurs="0"/>
						<xsd:element name="officeCode" type="xsd:string" minOccurs="0"/>
						<xsd:element name="userStatus" type="xsd:string" minOccurs="0"/>
					</xsd:sequence>
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
 * Bob Thiele 3/21/2012
 *   GovXML 7.1 modified class to correct the following: 
 *   Documented:	<xsd:element name="userId" type="xsd:string" minOccurs="0"/>
 *   Found     :    <userID>ANONYMOUS_IVR</userID>
*/

namespace GovXMLNet
{
    public class clsStaffPerson : clsElement
    {
        // Members
        public clsKeys Keys { get; set; }

        private string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        private string _firstName = null;
        public string firstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        private string _lastName = null;
        public string lastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        private string _auditStatus = null;
        public string auditStatus
        {
            get { return _auditStatus; }
            set { _auditStatus = value; }
        }

        private string _serviceProviderCode = null;
        public string serviceProviderCode
        {
            get { return _serviceProviderCode; }
            set { _serviceProviderCode = value; }
        }

        private string _userID = null;
        public string userID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        private string _agencyCode = null;
        public string agencyCode
        {
            get { return _agencyCode; }
            set { _agencyCode = value; }
        }

        private string _bureauCode = null;
        public string bureauCode
        {
            get { return _bureauCode; }
            set { _bureauCode = value; }
        }

        private string _divisionCode = null;
        public string divisionCode
        {
            get { return _divisionCode; }
            set { _divisionCode = value; }
        }

        private string _sectionCode = null;
        public string sectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        private string _groupCode = null;
        public string groupCode
        {
            get { return _groupCode; }
            set { _groupCode = value; }
        }

        private string _officeCode = null;
        public string officeCode
        {
            get { return _officeCode; }
            set { _officeCode = value; }
        }

        private string _userStatus = null;
        public string userStatus
        {
            get { return _userStatus; }
            set { _userStatus = value; }
        }

        // Constructors
        public clsStaffPerson()
        {
        }
    }
}
