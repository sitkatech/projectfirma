// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="StandardCommentsGroup">
		<xsd:complexContent>
			<xsd:extension base="element">
				<xsd:sequence>
					<xsd:element ref="Keys" minOccurs="0"/>
					<xsd:element ref="IdentifierDisplay" minOccurs="0"/>
					<xsd:element name="contextType" type="datasetChangeEnum" form="qualified" minOccurs="0"/>
					<xsd:element ref="Description" minOccurs="0"/>
					<xsd:element ref="StandardComments"/>
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
    public class clsStandardCommentsGroup : clsElement
    {
        // Members
        public clsKeys Keys { get; set; }

        private string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        private datasetChangeEnum? _contextType = null;
        public datasetChangeEnum? contextType
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

        public clsStandardComments StandardComments { get; set; }

        // Constructors
        public clsStandardCommentsGroup()
        {
        }
    }
}
