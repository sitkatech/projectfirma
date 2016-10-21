// Defined in AccelaOperationRepository_GIS

/* Version Last Modified: 6.7
	<xsd:complexType name="GetGISObjects">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element name="returnElements" form="qualified" minOccurs="0">
						<xsd:complexType>
							<xsd:sequence maxOccurs="unbounded">
								<xsd:element name="returnElement" form="qualified">
									<xsd:complexType>
										<xsd:simpleContent>
											<xsd:extension base="gisObjectDetailReturnEnum">
												<xsd:attribute name="detailLevels" type="xsd:nonNegativeInteger" use="optional"/>
											</xsd:extension>
										</xsd:simpleContent>
									</xsd:complexType>
								</xsd:element>
							</xsd:sequence>
						</xsd:complexType>
					</xsd:element>
					<xsd:element ref="MapServiceId"/>
					<xsd:choice maxOccurs="unbounded">
						<xsd:group ref="GISObjectsSearchCollectionSelect"/>
					</xsd:choice>
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
    public class msgGetGISObjects : clsOperationRequest
    {
        // Members
        public lctGetGISObjectsReturnElements returnElements { get; set; }
        public clsMapServiceId MapServiceId { get; set; }

        // Begin Group GISObjectsSearchCollectionSelect
        // Start Choice
        private clsAttributes _Attributes = null;
        public clsAttributes Attributes
        {
            get { return _Attributes; }
            set
            {
                _Attributes = value;
                ChoiceClearAllBut(eChoiceGISObjectsSearchCollectionSelect.scAttributes);
            }
        }

        private clsCriterions  _Criterions = null;
        public clsCriterions Criterions
        {
            get { return _Criterions; }
            set
            {
                _Criterions = value;
                ChoiceClearAllBut(eChoiceGISObjectsSearchCollectionSelect.scCriterions);
            }
        }

        private clsGISDynamicTheme _GISDynamicTheme = null;
        public clsGISDynamicTheme GISDynamicTheme
        {
            get { return _GISDynamicTheme; }
            set
            {
                _GISDynamicTheme = value;
                ChoiceClearAllBut(eChoiceGISObjectsSearchCollectionSelect.scGISDynamicTheme);
            }
        }

        private clsGISLayerId _GISLayerId = null;
        public clsGISLayerId GISLayerId
        {
            get { return _GISLayerId; }
            set
            {
                _GISLayerId = value;
                ChoiceClearAllBut(eChoiceGISObjectsSearchCollectionSelect.scGISLayerId);
            }
        }

        private clsGISObjectIds _GISObjectIds = null;
        public clsGISObjectIds GISObjectIds
        {
            get { return _GISObjectIds; }
            set
            {
                _GISObjectIds = value;
                ChoiceClearAllBut(eChoiceGISObjectsSearchCollectionSelect.scGISObjectIds);
            }
        }

        private clsGISObjectTypes _GISObjectTypes = null;
        public clsGISObjectTypes GISObjectTypes
        {
            get { return _GISObjectTypes; }
            set
            {
                _GISObjectTypes = value;
                ChoiceClearAllBut(eChoiceGISObjectsSearchCollectionSelect.scGISObjectTypes);
            }
        }
        // End Choice
        // End Group GISObjectsSearchCollectionSelect

        public msgGetGISObjects()
        {
        }


        // Methods
        private void ChoiceClearAllBut(eChoiceGISObjectsSearchCollectionSelect pSelectedChoice)
        {
            if (pSelectedChoice != eChoiceGISObjectsSearchCollectionSelect.scAttributes)
            {
                _Attributes = null;
            }
            if (pSelectedChoice != eChoiceGISObjectsSearchCollectionSelect.scCriterions)
            {
                _Criterions = null;
            }
            if (pSelectedChoice != eChoiceGISObjectsSearchCollectionSelect.scGISDynamicTheme)
            {
                _GISDynamicTheme = null;
            }
            if (pSelectedChoice != eChoiceGISObjectsSearchCollectionSelect.scGISLayerId)
            {
                _GISLayerId = null;
            }
            if (pSelectedChoice != eChoiceGISObjectsSearchCollectionSelect.scGISObjectIds)
            {
                _GISObjectIds = null;
            }
            if (pSelectedChoice != eChoiceGISObjectsSearchCollectionSelect.scGISObjectTypes)
            {
                _GISObjectTypes = null;
            }
        }

    }
}
