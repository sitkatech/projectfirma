using System;
using System.Text;
using System.Linq;
using System.Xml;

namespace DHTMLX.Export.Excel
{
    public class CSVxml
    {
        private XmlDocument dom;
        private XmlNodeList header;
        private XmlNodeList rows;
        private XmlNodeList footer;
        private int headerPos;
        private int footerPos;
        private int rowsPos;
        private void parseXmlString(String xml_string)
        {
            try
            {

             //   inputSource.setEncoding("UTF-8");
                dom.LoadXml(xml_string);

                header = dom.GetElementsByTagName("head");
                if (header.Count > 0)
                {
                    header = header[0].ChildNodes;
                }
                headerPos = 0;

                footer = dom.GetElementsByTagName("head");
                if (footer.Count > 0)
                {
                    footer = footer[0].ChildNodes;
                }
                footerPos = 0;

                rows = dom.GetElementsByTagName("row");
                rowsPos = 0;

            }           
            catch (Exception ioe)
            {
                
            }
        }

        public CSVxml(String xml)
        {
            parseXmlString(xml);
        }

        private String[] getDataArray(XmlNode node)
        {
            XmlNodeList columns = node.ChildNodes;
            String[] data = new String[columns.Count];
            for (int i = columns.Count - 1; i >= 0; i--)
                data[i] = columns[i].InnerText;

            return data;
        }
        public String[] getHeader()
        {
            if (header == null || header.Count <= headerPos) return null;
            XmlNode node = header[headerPos];
            headerPos += 1;

            return getDataArray(node);
        }
        public String[] getFooter()
        {
            if (footer == null || footer.Count <= footerPos) return null;
            XmlNode node = footer[footerPos];
            footerPos += 1;

            return getDataArray(node);
        }
        public String[] getRow()
        {
            if (rows == null || rows.Count <= rowsPos) return null;
            XmlNode node = rows[rowsPos];
            rowsPos += 1;

            return getDataArray(node);
        }
    }
}
