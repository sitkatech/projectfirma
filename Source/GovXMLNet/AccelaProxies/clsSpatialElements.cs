// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="SpatialElements">
		<xsd:complexContent>
			<xsd:extension base="elementList">
				<xsd:choice>
					<!-- ifcXML implementation -->
					<xsd:sequence>
						<xsd:choice maxOccurs="unbounded">
							<xsd:element ref="ifc:Product"/>
							<xsd:element ref="ifc:RelConnects"/>
						</xsd:choice>
					</xsd:sequence>
					<!-- GovXML implementation -->
					<xsd:sequence>
						<xsd:sequence maxOccurs="unbounded">
							<xsd:element ref="SpatialElement"/>
						</xsd:sequence>
						<xsd:sequence minOccurs="0" maxOccurs="unbounded">
							<xsd:element ref="SpatialElementConnector"/>
						</xsd:sequence>
					</xsd:sequence>
				</xsd:choice>
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
    public class clsSpatialElements : clsElementList
    {
        enum eChoiceSpatialElements
        {
            scProduct,
            scRelConnects,
            scSpatialElement,
            scSpatialElementConnector
        }

        // Members
        // TODO not sure if these need to be in a struct, need an example to see how list compares

        // Start Choice ifcXML/GovXML implemntation
        
        // IFC implemtantion
        //------------------------------
        // Start Choice IFC
        private clsIFCProduct _Product = null;
        public clsIFCProduct Product
        {
            get { return _Product; }
            set
            {
                _Product = value;
                ChoiceClearAllBut(eChoiceSpatialElements.scProduct);
            }
        }
        private clsIFCRelConnects _RelConnects = null;
        public clsIFCRelConnects RelConnects
        {
            get { return _RelConnects; }
            set
            {
                _RelConnects = value;
                ChoiceClearAllBut(eChoiceSpatialElements.scRelConnects);
            }
        }
        // End Choice IFC

        // GovXML Implemntation
        //----------------------------------
        private clsSpatialElement _SpatialElement = null;
        public clsSpatialElement SpatialElement
        {
            get { return _SpatialElement; }
            set
            {
                _SpatialElement = value;
                ChoiceClearAllBut(eChoiceSpatialElements.scSpatialElement);
            }
        }

        private clsSpatialElementConnector _SpatialElementConnector = null;
        public clsSpatialElementConnector SpatialElementConnector
        {
            get { return _SpatialElementConnector; }
            set
            {
                _SpatialElementConnector = value;
                ChoiceClearAllBut(eChoiceSpatialElements.scSpatialElementConnector);
            }
        }

        //End Choice ifcXML/GovXML implemntation

        // Constructors
        public clsSpatialElements()
        {
        }

        // Methods
        private void ChoiceClearAllBut(eChoiceSpatialElements pSelectedChoice)  
        {
            // Note this one is checking for the current value rather than not the current value to take care of all conditions due to the nested choice
            
            if (pSelectedChoice == eChoiceSpatialElements.scProduct)  // Part of both IFC Choice and implementation choice
            {
                _RelConnects = null;
                _SpatialElement = null;
                _SpatialElementConnector = null;
            }
            if (pSelectedChoice == eChoiceSpatialElements.scRelConnects)  // Part of both IFC Choice and implementation choice
            {
                _Product = null;
                _SpatialElement = null;
                _SpatialElementConnector = null;
            }
            if (pSelectedChoice == eChoiceSpatialElements.scSpatialElement)  // Implementation choice
            {
                _Product = null;
                _RelConnects = null;
            }
            if (pSelectedChoice == eChoiceSpatialElements.scSpatialElementConnector) // Implementation choice
            {
                _Product = null;
                _RelConnects = null;
            }
        }

    }
}
