using System.Xml;

namespace DHTMLX.Export.Excel
{
    public class ExcelColumn
    {
        private string colName;
        private string type;
        private string align;
        private int colspan;
        private int rowspan;
        private int width = 0;
        private int height = 1;
        private bool is_footer = false;

        public void Parse(XmlElement parent)
        {
            is_footer = parent.ParentNode.ParentNode.Name.Equals("foot");

            XmlNode text_node = parent.FirstChild;
            if (text_node != null)
                colName = text_node.Value;
            else
                colName = "";

            string width_string = parent.GetAttribute("width");

            if (width_string.Length > 0)
            {
                if (!int.TryParse(width_string, out width))
                    width = 0;
            }

            type = parent.GetAttribute("type");
            align = parent.GetAttribute("align");
            string colspan_string = parent.GetAttribute("colspan");
            if (colspan_string.Length > 0)
            {
                if (!int.TryParse(colspan_string, out colspan))
                    colspan = 0;
            }
            string rowspan_string = parent.GetAttribute("rowspan");
            if (rowspan_string.Length > 0)
            {
                if (!int.TryParse(rowspan_string, out rowspan))
                    rowspan = 0;
            }
        }

        public int GetWidth()
        {
            return width;
        }

        public bool IsFooter()
        {
            return is_footer;
        }

        public void SetWidth(int width)
        {
            this.width = width;
        }

        public int GetColspan()
        {
            return colspan;
        }

        public int GetRowspan()
        {
            return rowspan;
        }

        public int GetHeight()
        {
            return height;
        }

        public void SetHeight(int height)
        {
            this.height = height;
        }

        public string GetName()
        {
            return colName;
        }

        public string getAlign()
        {
            return align;
        }

        public string getType()
        {
            return type;
        }
    }
}
