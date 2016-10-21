// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="SeverityLevel">
		<xsd:complexContent>
			<xsd:extension base="element">
				<xsd:sequence>
					<xsd:element ref="Keys" minOccurs="0"/>
					<xsd:element ref="IdentifierDisplay"/>
					<xsd:element name="level" type="severityLevelEnum" form="qualified" minOccurs="0"/>
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
    public class clsSeverityLevel : clsElement
    {
        // Members
        public clsKeys Keys { get; set; }

        string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        private severityLevelEnum? _Level = null;
        public severityLevelEnum? Level
        {
            get
            {
                if (_Level.HasValue)
                {
                    return _Level.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _Level = value; }
        }
        public bool LevelSpecified
        {
            get { return _Level != null; }
        }

        // Constructors
        public clsSeverityLevel()
        {
        }
    }
}
