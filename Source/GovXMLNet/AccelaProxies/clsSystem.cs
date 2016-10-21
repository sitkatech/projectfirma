// Defined in AccelaGovXMLSystemDataObjects

/* Version Last Modified: 7.1
  <xsd:complexType name="System">
    <xsd:sequence>
      <xsd:element ref="XMLVersion" minOccurs="0" maxOccurs="1"/>
      <xsd:element ref="SenderVersion" minOccurs="0" maxOccurs="1"/>
      <xsd:element ref="ServiceProviderCode" minOccurs="0" maxOccurs="1"/>
      <xsd:element ref="Username" minOccurs="0" maxOccurs="1"/>
      <xsd:element ref="DataSource" minOccurs="0" maxOccurs="1"/>
      <xsd:element ref="MaxRows" minOccurs="0" maxOccurs="1"/>
      <xsd:element ref="StartRow" minOccurs="0" maxOccurs="1"/>
      <xsd:element ref="EndRow" minOccurs="0" maxOccurs="1"/>
      <xsd:element ref="TotalRows" minOccurs="0" maxOccurs="1"/>
      <xsd:element ref="SortOrder" minOccurs="0" maxOccurs="1"/>
      <xsd:element ref="ApplicationState" minOccurs="0" maxOccurs="1"/>
      <xsd:element ref="AuthenticationRequired" minOccurs="0" maxOccurs="1"/>
      <xsd:element ref="Context" minOccurs="0" maxOccurs="1"/>
      <xsd:element ref="Messages" minOccurs="0" maxOccurs="1" />
      <xsd:element ref="Error" minOccurs="0" maxOccurs="1"/>
      <xsd:element ref="LanguageID" minOccurs="0" maxOccurs="1"/>
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
    public class clsSystem
    {
        // Members        
        private string _XMLVersion = Constants.cDefaultXMLVersion;
        public string XMLVersion
        {
            get { return _XMLVersion; }
            set { _XMLVersion = value; }
        }

        private string _SenderVersion = null;
        public string SenderVersion
        {
            get { return _SenderVersion; }
            set { _SenderVersion = value; }
        }

        private string _ServiceProviderCode = null;
        public string ServiceProviderCode
        {
            get { return _ServiceProviderCode; }
            set { _ServiceProviderCode = value; }
        }

        private string _Username = null;
        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        private clsDataSource _DataSource = null;
        public clsDataSource DataSource
        {
            get { return _DataSource; }
            set { _DataSource = value; }
        }
        public bool DataSourceSpecified
        {
            get { return _DataSource != null; }
        }

        private int? _MaxRows = null;
        public int? MaxRows
        {
            get { return _MaxRows; }
            set { _MaxRows = value; }
        }
        public bool MaxRowsSpecified 
        {
            get { return _MaxRows != null; } 
        }

        private int? _StartRow = null;
        public int? StartRow
        {
            get { return _StartRow; }
            set { _StartRow = value; }
        }
        public bool StartRowSpecified 
        {
            get { return _StartRow != null; } 
        }

        private int? _EndRow = null;
        public int? EndRow
        {
            get { return _EndRow; }
            set { _EndRow = value; }
        }
        public bool EndRowSpecified 
        {
            get { return _EndRow != null; } 
        }

        private int? _TotalRows = null;
        public int? TotalRows
        {
            get { return _TotalRows; }
            set { _TotalRows = value; }
        }
        public bool TotalRowsSpecified 
        {
            get { return _TotalRows != null; } 
        }

        private string _SortOrder = null;
        public string SortOrder
        {
            get { return _SortOrder; }
            set { _SortOrder = value; }
        }

        private string _ApplicationState = null;
        public string ApplicationState
        {
            get { return _ApplicationState; }
            set { _ApplicationState = value; }
        }

        private bool? _AuthenticationRequired = null;
        public bool? AuthenticationRequired
        {
            get { return _AuthenticationRequired; }
            set { _AuthenticationRequired = value; }
        }
        [System.Xml.Serialization.XmlIgnore]
        public bool AuthenticationRequiredSpecified 
        {
            get { return _AuthenticationRequired != null; } 
        }

        private contextEnumType? _Context = null;
        public contextEnumType? Context
        {
            get
            {
                if (_Context.HasValue)
                {
                    return _Context.Value;
                }
                else
                {
                    return null;
                }
            }
            set { _Context = value; }
        }
        public bool ContextSpecified
        {
            get { return _Context != null; }
        }

        private clsMessages _Messages = null;
        public clsMessages Messages
        {
            get { return _Messages; }
            set { _Messages = value; }
        }
        public bool MessagesSpecified
        {
            get { return _Messages != null; }
        }

        public clsError Error { get; set; }

        private string _LanguageID = null;
        public string LanguageID
        {
            get { return _LanguageID; }
            set { _LanguageID = value; }
        }

        // Constructors
        public clsSystem()
        {
        }

        public clsSystem(string pServiceProviderCode, string pUserName)
        {
            ServiceProviderCode = pServiceProviderCode;
            Username = pUserName;
            MaxRows = 0;
            StartRow = 0;
        }

        public clsSystem(string pServiceProviderCode, string pUserName, string pApplicationState)
        {
            ServiceProviderCode = pServiceProviderCode;
            Username = pUserName;
            ApplicationState = pApplicationState;
        }

    }
}
