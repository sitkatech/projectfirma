// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="GetInspectionTypes">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element name="returnElements" form="qualified" minOccurs="0">
						<xsd:complexType>
							<xsd:sequence maxOccurs="unbounded">
								<xsd:element name="returnElement" form="qualified">
									<xsd:complexType>
										<xsd:simpleContent>
											<xsd:extension base="inspectionTypeDetailReturnEnum">
												<xsd:attribute name="detailLevels" type="xsd:nonNegativeInteger" use="optional"/>
											</xsd:extension>
										</xsd:simpleContent>
									</xsd:complexType>
								</xsd:element>
							</xsd:sequence>
						</xsd:complexType>
					</xsd:element>
					<xsd:element name="collectionsLevelQueryLogic" type="queryLogicEnum" default="OR" form="qualified" minOccurs="0"/>
					<xsd:element name="collectionLevelQueryLogic" type="queryLogicEnum" default="OR" form="qualified" minOccurs="0"/>
					<xsd:choice minOccurs="0" maxOccurs="unbounded">
						<xsd:group ref="InspectionTypeSearchCollectionSelect"/>
					</xsd:choice>
				</xsd:sequence>
			</xsd:extension>
		</xsd:complexContent>
	</xsd:complexType>
  
  
  
 	<xsd:group name="InspectionTypeSearchCollectionSelect">
		<xsd:choice>
			<xsd:element ref="CAPId"/>
			<xsd:element ref="CAPTypeId"/>
			<xsd:element ref="InspectorId"/>
			<xsd:element name="GetByCode" form="qualified" minOccurs="0">
				<xsd:complexType>
					<xsd:sequence>
						<xsd:element ref="CAPId" />
						<xsd:element ref="IVRCode" />
					</xsd:sequence>
				</xsd:complexType>
			</xsd:element>
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
    public class lctGetInspectionTypesGetByCode
    {
        // Members
        public clsCAPId CAPId { get; set; }

        private int _IVRCode = 0;
        public int IVRCode
        {
            get { return _IVRCode; }
            set { _IVRCode = value; }
        }

        // Constructors
        public lctGetInspectionTypesGetByCode()
        {
            CAPId = new clsCAPId();
        }

        public lctGetInspectionTypesGetByCode(clsCAPId pCAPId)
        {
            CAPId = pCAPId;
        }

        public lctGetInspectionTypesGetByCode(int pIVRCode)
        {
            IVRCode = pIVRCode;
        }

    }
}
