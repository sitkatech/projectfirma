// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="CAPRelation">
		<xsd:complexContent>
			<xsd:extension base="element">
				<xsd:sequence>
					<xsd:element ref="Keys" minOccurs="0"/>
					<xsd:element ref="CAPId"/>
					<xsd:element name="contextType" type="capRelationContextTypeEnum" form="qualified" minOccurs="0"/>
					<xsd:element ref="Description" minOccurs="0"/>
					<xsd:element ref="AdditionalInformation" minOccurs="0"/>
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
    public class clsCAPRelation : clsElement
    {
        // Members
        public clsKeys Keys { get; set; }

        public clsCAPId CAPId { get; set; }

        private capRelationContextTypeEnum? _contextType = null;
        public capRelationContextTypeEnum? contextType
        {
            get
            {
                if (_contextType.HasValue)
                {
                    return _contextType.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _contextType = value; }
        }
        public bool contextTypeSpecified
        {
            get { return _contextType != null; }
        }

        private string _Description = null;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public clsAdditionalInformation AdditionalInformation { get; set; }

        // Constructors
        public clsCAPRelation()
        {
        }
    }
}
