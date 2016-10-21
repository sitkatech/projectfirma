// Defined in ifc2x_final_stage2_03

/* Version Last Modified: 7.1
<xsd:complexType name="ActorRole">
	<xsd:complexContent>
		<xsd:extension base="elementID">
			<xsd:sequence>
				<xsd:element type="RoleEnum" name="role"/>
				<xsd:element type="Label" minOccurs="0" name="userDefinedRole"/>
				<xsd:element ref="UserDefinedRoleId" minOccurs="0" maxOccurs="1"/>
				<xsd:element type="Text" minOccurs="0" name="description"/>
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
    public class clsIFCActorRole : clsIFCelementID
    {
        // Members
        private RoleEnum _role;
        public RoleEnum role
        {
            get { return _role; }
            set { _role = value; }
        }

        private string _userDefinedRole = null;
        public string userDefinedRole
        {
            get { return _userDefinedRole; }
            set { _userDefinedRole = value; }
        }

        public clsIFCUserDefinedRoleId UserDefinedRoleId { get; set; }

        private string _description = null;
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        // Constructors
        public clsIFCActorRole()
        {
        }
    }
}
