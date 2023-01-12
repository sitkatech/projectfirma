using System;
using System.Xml;
using System.Xml.XPath;
namespace DHTMLX.Export.Excel
{
    public class ExcelXmlParser
    {
        private XmlElement root;
	    private ExcelColumn[][] columns;
	    private ExcelRow[] rows;
	    private int[] widths;
	    private Boolean header = false;
	    private Boolean footer = false;
	    private Boolean without_header = false;
	    private string profile = "gray";
      
	    public void setXML(string xml)
	    {
          
            XmlDocument dom = new XmlDocument(); ;
		    try {
            ///TODO: handle exceptions, log maybe
            dom.LoadXml(xml);
		    }catch(Exception) {

		    }
		    root = dom.DocumentElement;

		    String header_text = root.GetAttribute("header");
		    if ((header_text != null)&&(header_text.ToLower().Equals("true") == true)) {
			    header = true;
		    }
		    String footer_text = root.GetAttribute("footer");
            if ((footer_text != null) && (footer_text.ToLower().Equals("true") == true))
            {
			    footer = true;
		    }
		    String profile_text = root.GetAttribute("profile");
		    if (profile_text != null) {
			    profile = profile_text;
		    }
		    String w_header = root.GetAttribute("without_header");
            if ((w_header != null) && (w_header.ToLower().Equals("true") == true))
			    without_header = true;
	    }

	    public ExcelColumn[][] getColumnsInfo(String mode) {
		    ExcelColumn[] colLine = null;

		    try {
			    String path = "/rows/" + mode + "/columns";

                var n1 = root.SelectNodes(path);
			   
                if ((n1 != null) && (n1.Count > 0))
                {

                    columns = new ExcelColumn[n1.Count][];
                    for (int i = 0; i < n1.Count; i++)
                    {
                        XmlElement cols = (XmlElement)n1[i];
                        var n2 = cols.GetElementsByTagName("column");
                        if ((n2 != null) && (n2.Count > 0))
                        {
                            colLine = new ExcelColumn[n2.Count];
                            for (int j = 0; j < n2.Count; j++)
                            {
                                XmlElement col_xml = (XmlElement)n2[j];
                                ExcelColumn col = new ExcelColumn();
                                col.Parse(col_xml);
                                colLine[j] = col;
                            }
                        }
                        columns[i] = colLine;
                    }
                }
                
		    } catch (Exception ) {

		    }
		
		    createWidthsArray();
		    optimizeColumns();
		    return columns;
	    }

	    private void createWidthsArray() {
		    widths = new int[columns[0].Length];
            for (int i = 0; i < columns[0].Length; i++)
            {
			    widths[i] = columns[0][i].GetWidth();
		    }
	    }

	    private void optimizeColumns() {
            for (int i = 1; i < columns.Length; i++)
            {
                for (int j = 0; j < columns[i].Length; j++)
                {
				    columns[i][j].SetWidth(columns[0][j].GetWidth());
			    }
		    }
            for (int i = 0; i < columns.Length; i++)
            {
                for (int j = 0; j < columns[i].Length; j++)
                {
				    if (columns[i][j].GetColspan() > 0) {
                        for (int k = j + 1; k < j + columns[i][j].GetColspan() && k < columns[i].Length; k++)
                        {
                           
						    columns[i][j].SetWidth(columns[i][j].GetWidth() + columns[i][k].GetWidth());
						    columns[i][k].SetWidth(0);
					    }
				    }
				    if (columns[i][j].GetRowspan() > 0) {
					    for (int k = i + 1; k < i + columns[i][j].GetRowspan() && k < columns.Length; k++) {
						    columns[i][j].SetHeight(columns[i][j].GetHeight() + 1);
						    columns[k][j].SetHeight(0);
					    }
				    }
			    }
		    }
	    }

	    public ExcelRow[] getGridContent() {
		    var nodes = root.GetElementsByTagName("row");
		    if ((nodes != null)&&(nodes.Count > 0)) {
                rows = new ExcelRow[nodes.Count];
                for (int i = 0; i < nodes.Count; i++)
                {
				    rows[i] = new ExcelRow();
				    rows[i].parse(nodes[i]);
			    }
		    }
		    return rows;
	    }

	    public int[] getWidths() {
		    return widths;
	    }

	    public bool getHeader() {
		    return header;
	    }

        public bool getFooter()
        {
		    return footer;
	    }

	    public String getProfile() {
		    return profile;
	    }

        public bool getWithoutHeader()
        {
		    return without_header;
	    }
    }
}
