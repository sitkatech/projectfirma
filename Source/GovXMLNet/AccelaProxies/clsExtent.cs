// Defined in AccelaGovXMLDataObjects

/* Version Last Modified: 6.7
	<xsd:complexType name="Extent">
		<xsd:complexContent>
			<xsd:extension base="element">
				<xsd:choice>
					<xsd:sequence>
						<xsd:element name="minX" type="xsd:double" form="qualified"/>
						<xsd:element name="minY" type="xsd:double" form="qualified"/>
						<xsd:element name="maxX" type="xsd:double" form="qualified"/>
						<xsd:element name="maxY" type="xsd:double" form="qualified"/>
					</xsd:sequence>
					<xsd:sequence>
						<xsd:sequence minOccurs="0">
							<xsd:element name="centerX" type="xsd:double" form="qualified"/>
							<xsd:element name="centerY" type="xsd:double" form="qualified"/>
						</xsd:sequence>
						<xsd:element ref="Radius"/>
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
    public class clsExtent : clsElement
    {
        // Members
        private string _minX = null;
        public string minX
        {
            get { return _minX; }
            set { _minX = value; }
        }

        private string _minY = null;
        public string minY
        {
            get { return _minY; }
            set { _minY = value; }
        }

        private string _maxX = null;
        public string maxX
        {
            get { return _maxX; }
            set { _maxX = value; }
        }

        private string _maxY = null;
        public string maxY
        {
            get { return _maxY; }
            set { _maxY = value; }
        }

        private double? _centerX = null;
        public double? centerX
        {
            get
            {
                if (_centerX.HasValue)
                {
                    return _centerX.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _centerX = value; }
        }
        public bool centerXSpecified
        {
            get { return _centerX != null; }
        }

        private double? _centerY = null;
        public double? centerY
        {
            get
            {
                if (_centerY.HasValue)
                {
                    return _centerY.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _centerY = value; }
        }
        public bool centerYSpecified
        {
            get { return _centerY != null; }
        }

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

        // Constructors
        public clsExtent()
        {
        }
    }
}
