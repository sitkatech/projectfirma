// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="Criterion">
		<xsd:complexContent>
			<xsd:extension base="element">
				<xsd:sequence>
					<xsd:element ref="Keys"/>
					<xsd:element ref="IdentifierDisplay" minOccurs="0"/>
					<xsd:choice minOccurs="0">
						<xsd:sequence>
							<xsd:element ref="DataType"/>
						</xsd:sequence>
						<xsd:sequence>
							<xsd:element name="comparisonOperator" type="comparisonOperatorEnum" form="qualified"/>
						</xsd:sequence>
					</xsd:choice>
					<xsd:element ref="Value"/>
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
    public class clsCriterion : clsElement
    {
        enum eChoiceCriterion
        {
            scDataType,
            scComparisonOperator
        }
        // Members
        public clsKeys Keys { get; set; }

        private string vIdentifierDisplay = null;
        public string IdentifierDisplay
        {
            get { return vIdentifierDisplay; }
            set { vIdentifierDisplay = value; }
        }

        // Start choice
        private clsDataType _DataType = null;
        public clsDataType DataType
        {
            get { return _DataType; }
            set
            {
                _DataType = value;
                ChoiceClearAllBut(eChoiceCriterion.scDataType);
            }
        }

        private comparisonOperatorEnum? _comparisonOperator = null;
        public comparisonOperatorEnum? comparisonOperator
        {
            get
            {
                if (_comparisonOperator.HasValue)
                {
                    return _comparisonOperator.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _comparisonOperator = value; }
        }
        public bool comparisonOperatorSpecified
        {
            get { return _comparisonOperator != null; }
        }
        // End choice

        private string _Value = null;
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        // Constructors
        public clsCriterion()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceCriterion pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceCriterion.scDataType)
            {
                DataType = null;
            }
            if (pSelectedChoice != eChoiceCriterion.scComparisonOperator)
            {
                _comparisonOperator = null;
            }
        }

    }
}
