// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 7.1
	<xsd:complexType name="GetAssetCAs">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest" >
				<xsd:sequence>
					<xsd:element name="assetCAId" type="xsd:string"/>
					<xsd:element ref="AssetCAType"/>
					<xsd:element name="AssetId" type="xsd:string"/>
					<xsd:element ref="AssetType"/>
					<xsd:element ref="Department"/>
					<xsd:element ref="AssetTypes"/>
					<xsd:element ref="Departments"/>
					<xsd:element ref="StaffPerson"/>
					<xsd:element name="AssetCAStatus" type="Status"/>
					<xsd:element name="comment" type="xsd:string"/>
					<xsd:element name="inspectionDateRanges" type="DateRange"/>
					<xsd:element name="scheduledDateRanges" type="DateRange"/>
					<xsd:element name="spentHoursRanges" type="Range"/>
					<xsd:element ref="AssetIds"/>
					<xsd:element ref="AssetCAIds"/>
					<xsd:element ref="DateRanges"/>
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
    public class msgGetAssetCAs : clsOperationRequest
    {
        // Members
        private string _assetCAId;
        public string assetCAId
        {
            get { return _assetCAId; }
            set { _assetCAId = value; }
        }

        public clsAssetCAType AssetCAType { get; set; }

        private string _AssetId;
        public string AssetId
        {
            get { return _AssetId; }
            set { _AssetId = value; }
        }

        public clsAssetType AssetType { get; set; }
        public clsDepartment Department { get; set; }
        public clsAssetTypes AssetTypes { get; set; }
        public clsDepartments Departments { get; set; }
        public clsStaffPerson StaffPerson { get; set; }
        public clsStatus AssetCAStatus {get; set; }

        private string _comment;
        public string comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        public clsDateRange inspectionDateRanges { get; set; }
        public clsDateRange scheduledDateRanges { get; set; }
        public clsRange spentHoursRanges { get; set; }

        public clsAssetIds AssetIds { get; set; }
        public clsAssetCAIds AssetCAIds { get; set; }
        public clsDateRanges DateRanges { get; set; }

        // Constructors
        public msgGetAssetCAs()
        {
        }
    }
}
