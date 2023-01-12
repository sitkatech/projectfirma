using System;
using System.Xml;

namespace DHTMLX.Export.Excel
{
    public class ExcelRow
    {
        private ExcelCell[] cells;

        public void parse(XmlNode parent)
        {
            XmlNodeList nodes = ((XmlElement)parent).GetElementsByTagName("cell");
            XmlNode text_node;
            if ((nodes != null) && (nodes.Count > 0))
            {
                cells = new ExcelCell[nodes.Count];
                for (int i = 0; i < nodes.Count; i++)
                {
                    text_node = nodes[i];
                    ExcelCell cell = new ExcelCell();
                    if (text_node != null)
                        cell.Parse(text_node);
                    cells[i] = cell;
                }
            }
        }

        public ExcelCell[] getCells()
        {
            return cells;
        }
    }
}
