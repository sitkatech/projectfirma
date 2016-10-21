// Contents of this should be the same as clsIFCActorSelect, the only difference is inheriting from clsElement
// Defined in ifc2x_final_stage2_03

/* Version Last Modified: 6.7
<xsd:group name="ActorSelect">
	<xsd:choice>
		<xsd:element ref="Organization"/>
		<xsd:element ref="Person"/>
		<xsd:element ref="PersonAndOrganization"/>
	</xsd:choice>
</xsd:group>
*/

/*
 * Author: Bob Thiele
 * Organization:  Allen County/City of Fort Wayne
 * Date: 2/14/2012
 * Modifications:
*/

namespace GovXMLNet
{
    public class clsIFCActorSelectBasedOnElement : clsElement
    {
        enum eChoiceAddressSelect
        {
            scOrganization,
            scPerson,
            scPersonAndOrganization
        }

        // Members

        // Start Group ActorSelect
        // End choice
        private clsIFCOrganization _Organization = null;
        public clsIFCOrganization Organization
        {
            get { return _Organization; }
            set
            {
                _Organization = value;
                ChoiceClearAllBut(eChoiceAddressSelect.scOrganization);
            }
        }

        private clsIFCPerson _Person = null;
        public clsIFCPerson Person
        {
            get { return _Person; }
            set
            {
                _Person = value;
                ChoiceClearAllBut(eChoiceAddressSelect.scPerson);
            }
        }

        private clsIFCPersonAndOrganization _PersonAndOrganization = null;
        public clsIFCPersonAndOrganization PersonAndOrganization
        {
            get { return _PersonAndOrganization; }
            set
            {
                _PersonAndOrganization = value;
                ChoiceClearAllBut(eChoiceAddressSelect.scPersonAndOrganization);
            }
        }
        // End choice
        // Stop Group ActorSelect


        // Constructors
        public clsIFCActorSelectBasedOnElement()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceAddressSelect pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceAddressSelect.scOrganization)
            {
                _Organization = null;
            }
            if (pSelectedChoice != eChoiceAddressSelect.scPerson)
            {
                _Person = null;
            }
            if (pSelectedChoice != eChoiceAddressSelect.scPersonAndOrganization)
            {
                _PersonAndOrganization = null;
            }
        }

    }
}
