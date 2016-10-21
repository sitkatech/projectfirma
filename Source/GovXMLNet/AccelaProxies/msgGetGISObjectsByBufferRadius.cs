// Defined in AccelaOperationRepository_GIS

/* Version Last Modified: 6.7
	<xsd:complexType name="GetGISObjectsByBufferRadius">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:element ref="MapServiceId"/>
					<xsd:element ref="Radius" minOccurs="0"/>
					<xsd:element ref="BufferLayer" minOccurs="0"/>
					<xsd:element ref="BufferObjects" minOccurs="0"/>
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
    public class msgGetGISObjectsByBufferRadius : clsOperationRequest
    {
        // Members
        public clsMapServiceId MapServiceId { get; set; }

        private double? _Radius = null;
        public double? Radius
        {
            get
            {
                if (_Radius.HasValue)
                {
                    return _Radius.Value;
                }
                else
                {
                    return null;
                }
            }

            set { _Radius = value; }
        }
        public bool RadiusSpecified
        {
            get { return _Radius != null; }
        }

        public clsBufferLayer BufferLayer { get; set; }
        public clsBufferObjects BufferObjects { get; set; }


        // Constructors
        public msgGetGISObjectsByBufferRadius()
        {
        }
    }
}
