// Defined in AccelaOperationRepository_GovXML

/* Version Last Modified: 6.7
	<xsd:complexType name="CalculateRoute">
		<xsd:complexContent>
			<xsd:extension base="OperationRequest">
				<xsd:sequence>
					<xsd:sequence>
						<xsd:element ref="MapServiceId" minOccurs="0"/>
						<xsd:element name="calculationMethod" type="routeCalculationMethodEnum" form="qualified" minOccurs="0"/>
						<xsd:element name="calculationPriority" type="routeCalculationPriorityEnum" form="qualified" minOccurs="0"/>
						<xsd:element name="reorderRoute" type="xsd:boolean" default="true" form="qualified" minOccurs="0"/>
						<xsd:element name="returnRouteSegments" type="xsd:boolean" default="true" form="qualified" minOccurs="0"/>
						<xsd:element name="returnRouteToFirstNode" type="xsd:boolean" default="false" form="qualified" minOccurs="0"/>
						<xsd:element ref="RouteNodes"/>
					</xsd:sequence>
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
    public class msgCalculateRoute : clsOperationRequest
    {
        // Members
        public clsMapServiceId MapServiceId { get; set; }

        private routeCalculationMethodEnum? _calculationMethod = null;
        public routeCalculationMethodEnum? calculationMethod
        {
            get
            {
                if (_calculationMethod.HasValue)
                {
                    return _calculationMethod.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _calculationMethod = value; }
        }
        public bool calculationMethodSpecified
        {
            get { return _calculationMethod != null; }
        }

        private routeCalculationPriorityEnum? _calculationPriority = null;
        public routeCalculationPriorityEnum? calculationPriority
        {
            get
            {
                if (_calculationPriority.HasValue)
                {
                    return _calculationPriority.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _calculationPriority = value; }
        }
        public bool calculationPrioritySpecified
        {
            get { return _calculationPriority != null; }
        }

        private bool? _reorderRoute = false;
        public bool? reorderRoute
        {
            get
            {
                if (_reorderRoute.HasValue)
                {
                    return _reorderRoute.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _reorderRoute = value; }
        }
        public bool reorderRouteSpecified
        {
            get { return _reorderRoute != null; }
        }

        private bool? _returnRouteSegments = false;        
        public bool? returnRouteSegments
        {
            get
            {
                if (_returnRouteSegments.HasValue)
                {
                    return _returnRouteSegments.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _returnRouteSegments = value; }
        }
        public bool returnRouteSegmentsSpecified
        {
            get { return _returnRouteSegments != null; }
        }

        private bool? _returnRouteToFirstNode = false;
        public bool? returnRouteToFirstNode
        {
            get
            {
                if (_returnRouteToFirstNode.HasValue)
                {
                    return _returnRouteToFirstNode.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _returnRouteToFirstNode = value; }
        }
        public bool returnRouteToFirstNodeSpecified
        {
            get { return _returnRouteToFirstNode != null; }
        }

        public clsRouteNodes RouteNodes { get; set; }

        // Constructors
        public msgCalculateRoute()
        {
        }
    }
}
