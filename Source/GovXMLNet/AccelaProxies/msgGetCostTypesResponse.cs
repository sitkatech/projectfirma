// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="GetCostTypesResponse">
		<xsd:complexContent>
			<xsd:extension base="OperationResponse">
				<xsd:sequence minOccurs="0">
					<xsd:element ref="CostTypes" minOccurs="0"/>
					<xsd:element ref="CostFactors" minOccurs="0"/>
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
    public class msgGetCostTypesResponse : clsOperationResponse
    {
        // Members
        private clsCostTypes _CostTypes = null;
        public clsCostTypes CostTypes
        {
            get { return _CostTypes; }
            set { _CostTypes = value; }
        }
        public bool CostTypesSpecified
        {
            get { return _CostTypes != null; }
        }

        private clsCostFactors _CostFactors = null;
        public clsCostFactors CostFactors
        {
            get { return _CostFactors; }
            set { _CostFactors = value; }
        }
        public bool CostFactorsSpecified
        {
            get { return _CostFactors != null; }
        }

        // Constructors
        public msgGetCostTypesResponse()
        {
        }
    }
}
