// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="AssetId">
		<xsd:complexContent>
			<xsd:extension base="Identifier">
				<xsd:sequence minOccurs="0">
					<xsd:element name="TrackingNumber" type="xsd:nonNegativeInteger" form="qualified" minOccurs="0"/>
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
    public class clsAssetId : clsIdentifier
    {
        // Members
        private uint? _TrackingNumber = null;
        public uint? TrackingNumber
        {
            get
            {
                if (_TrackingNumber.HasValue)
                {
                    return _TrackingNumber.Value;
                }
                else
                {
                    return null;
                }
            }

            set { _TrackingNumber = value; }
        }
        public bool TrackingNumberSpecified
        {
            get { return _TrackingNumber != null; }
        }


        // Constructors
        public clsAssetId()
        {
        }
    }
}
