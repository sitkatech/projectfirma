// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
	<xsd:complexType name="GetDocumentList">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element ref="ObjectId"/>
					<xsd:element name="includeContent" type="xsd:boolean" default="false" form="qualified" minOccurs="0"/>
                    <xsd:element ref="EDMSAdapters" minOccurs="0" maxOccurs="1"/>
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
    public class msgGetDocumentList : clsOperationRequest
    {
        // Members
        public clsObjectId ObjectId { get; set; }

        private bool? _includeContent = null;
        public bool? includeContent
        {
            get
            {
                if (_includeContent.HasValue)
                {
                    return _includeContent.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _includeContent = value; }
        }
        public bool includeContentSpecified
        {
            get { return _includeContent != null; }
        }


        public clsEDMSAdapters EDMSAdapters { get; set; }

        // Constructors
        public msgGetDocumentList()
        {
        }
    }
}
