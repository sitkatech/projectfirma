// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="UpdateWorksheet">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element name="contextType" type="datasetChangeEnum" form="qualified"/>
					<xsd:element ref="Worksheet"/>
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
    public class msgUpdateWorksheet : clsOperationRequest
    {
        // Members
        private datasetChangeEnum _contextType;
        public datasetChangeEnum contextType
        {
            get { return _contextType; }
            set { _contextType = value; }
        }

        public clsWorksheet Worksheet { get; set; }


        // Constructors
        public msgUpdateWorksheet()
        {
        }
    }
}
