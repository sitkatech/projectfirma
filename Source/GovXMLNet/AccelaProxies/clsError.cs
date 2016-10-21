// Defined in AccelaGovXMLSystemDataObjects

/* Version Last Modified: 6.7
  <xsd:complexType name="Error">
    <xsd:sequence>
      <xsd:element ref="ErrorCode"/>
      <xsd:element ref="ErrorClass" minOccurs="0" maxOccurs="1"/>
      <xsd:element ref="ErrorDetail" minOccurs="0" maxOccurs="1"/>
      <xsd:element ref="ErrorMessage" minOccurs="0" maxOccurs="1"/>
    </xsd:sequence>
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
    public class clsError
    {
        // Members
        private string _ErrorCode = null;
        public string ErrorCode
        {
            get { return _ErrorCode; }
            set { _ErrorCode = value; }
        }

        private errorClassEnumType? _ErrorClass = null;
        public errorClassEnumType? ErrorClass
        {
            get
            {
                if (_ErrorClass.HasValue)
                {
                    return _ErrorClass.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _ErrorClass = value; }
        }
        public bool ErrorClassSpecified
        {
            get { return _ErrorClass != null; }
        }

        private string _ErrorDetail = null;
        public string ErrorDetail
        {
            get { return _ErrorDetail; }
            set { _ErrorDetail = value; }
        }

        private string _ErrorMessage = null;
        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set { _ErrorMessage = value; }
        }

        // Constructors
        public clsError()
        {
        }

        public clsError(string pErrorCode = null, errorClassEnumType pErrorClass = errorClassEnumType.Undefined, string pErrorDetail = null, string pErrorMessage = null)
        {
            _ErrorCode = pErrorCode;
            //_ErrorClass = pErrorClass;
            _ErrorDetail = pErrorDetail;
            _ErrorMessage = pErrorMessage;
        }
    }
}
