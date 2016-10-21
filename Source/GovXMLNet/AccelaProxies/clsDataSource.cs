// Defined in AccelaGovXMLSystemDataObjects

/* Version Last Modified: 6.7
  <xsd:complexType name="DataSource">
    <xsd:sequence>
      <xsd:choice>
        <xsd:element name="connectionString" type="xsd:string" form="qualified"/>
        <xsd:element name="dataSourceName" type="xsd:string" form="qualified"/>
        <xsd:element name="url" type="xsd:string" form="qualified"/>
      </xsd:choice>
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
    public class clsDataSource
    {
        private string _connectionString = null;
        public string connectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        private string _dataSourceName = null;
        public string dataSourceName
        {
            get { return _dataSourceName; }
            set { _dataSourceName = value; }
        }

        private string _url = null;
        public string url
        {
            get { return _url; }
            set { _url = value; }
        }


        // Constructors
        public clsDataSource()
        {
        }

        public clsDataSource(string pConnectionString = null, string pDataSourceName = null, string pURL = null)
        {
            _connectionString = pConnectionString;
            _dataSourceName = pDataSourceName;
            _url = pURL;
        }

    }
}
