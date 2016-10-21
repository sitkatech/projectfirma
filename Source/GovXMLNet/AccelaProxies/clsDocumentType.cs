// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="DocumentType">
		<xsd:complexContent>
			<xsd:extension base="element">
				<xsd:sequence>
					<xsd:element ref="Keys"/>
					<xsd:element ref="IdentifierDisplay"/>
					<xsd:element name="AutoDownload" type="xsd:boolean" form="qualified" minOccurs="0"/>
					<xsd:element ref="Description" minOccurs="0"/>
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
    public class clsDocumentType : clsElement
    {
        // Members
        public clsKeys Keys { get; set; }

        private string _IdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return _IdentifierDisplay; }
            set { _IdentifierDisplay = value; }
        }

        private bool? _AutoDownload = null;
        public bool? AutoDownload
        {
            get
            {
                if (_AutoDownload.HasValue)
                {
                    return _AutoDownload.Value;
                }
                else
                {
                    return null;
                }
            }

            set { _AutoDownload = value; }
        }
        public bool AutoDownloadSpecified
        {
            get { return _AutoDownload != null; }
        }


        private string _Description = null;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        // Constructors
        public clsDocumentType()
        {
        }
    }
}
