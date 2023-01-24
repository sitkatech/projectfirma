using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.IO;

using System.Web;


using OpenExcel.OfficeOpenXml.Style;
using OpenExcel.OfficeOpenXml;
//using DocumentFormat.OpenXml.Spreadsheet;
///TODO: add text color, vertical alignment, horizontal alignment, colspan, rowspan
namespace DHTMLX.Export.Excel
{
    public class ExcelWriter
    {
        private ExcelDocument wb;
	    private ExcelWorksheet sheet;
	    private ExcelColumn[][] cols;
	    private int colsNumber = 0;
	    private ExcelXmlParser parser;
        
	    public int headerOffset = 0;
	    public int scale = 6;
	    public String pathToImgs = "";//optional, physical path

        public double RowHeight { get; set; }
        public double HeaderFontSize { get; set; }
        public double FooterFontSize { get; set; }
        public string FontFamily { get; set; }
        public double GridFontSize { get; set; }
        public double WatermarkFontSize { get; set; }
        public string OutputFileName { get; set; }
        public Dictionary<int, int> Widths { get; set; }

        public string BGColor { get; set; }
        public string LineColor { get; set; }
        
        public string ScaleOneColor { get; set; }
        public string ScaleTwoColor { get; set; }

        protected string GridTextColor { get; set; }
        protected string WatermarkTextColor { get; set; }
        protected string HeaderTextColor { get; set; }

	    private int cols_stat;
	    private int rows_stat;
        public bool PrintFooter { get; set; }
	    private String watermark = null;


        public ExcelWriter()
        {
            PrintFooter = false;
            RowHeight = 22.5;
            FontFamily = "Arial";
            HeaderFontSize = FooterFontSize = 9;

            GridFontSize = WatermarkFontSize =10;

            BGColor = "";
            LineColor = "";
            HeaderTextColor = "";
            ScaleOneColor = "";
            ScaleTwoColor = "";
            GridTextColor = "";
            WatermarkTextColor = "";
            OutputFileName = "grid.xlsx";
        }

        public void Generate(string xml, Stream output){
            parser = new ExcelXmlParser();
            try {
                parser.setXML(xml);
                createExcel(output);
                setColorProfile();
                headerPrint(parser);
          
                rowsPrint(parser, output);
                wb.Workbook.Document.Styles.Save();
                if(PrintFooter)
                    footerPrint(parser);
                insertHeader(parser, output);
                insertFooter(parser, output);
                watermarkPrint(parser);
         
                wb.Dispose();
            } catch (Exception e) {
                throw;
            }
        }

	    private void createExcel(Stream resp){

		    wb = ExcelDocument.CreateWorkbook(resp);
            
		    sheet = wb.Workbook.Worksheets.Add("First Sheet");
            wb.EnsureStylesDefined();

	    }

        public void Generate(HttpContext context)
        {
            Generate(HttpUtility.UrlDecode(context.Request.Form["grid_xml"]), context.Response);
        }


        public MemoryStream Generate(string xml)
        {
            var data = new MemoryStream();

            Generate(xml, data);
            return data;
        }
        public MemoryStream Generate(NameValueCollection form)
        {
            var xml = HttpUtility.UrlDecode(form["grid_xml"]);
            var data = new MemoryStream();
            Generate(xml, data);
            return data;
        }
        public string ContentType
        {
            get
            {
                return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            }
        }
        public void Generate(string xml, HttpResponse resp)
        {
            var data = new MemoryStream();

            resp.ContentType = ContentType;
		    resp.HeaderEncoding = Encoding.UTF8;
            resp.AppendHeader("Content-Disposition", string.Format("attachment;filename={0}", OutputFileName));
		    resp.AppendHeader("Cache-Control", "max-age=0");
            Generate(xml, data);

            data.WriteTo(resp.OutputStream);
            
            
	    }
        public void Generate(string xml, HttpResponseBase resp)
        {
            var data = new MemoryStream();

            resp.ContentType = ContentType;
            resp.HeaderEncoding = Encoding.UTF8;
            resp.AppendHeader("Content-Disposition", "attachment;filename=grid.xlsx");
            resp.AppendHeader("Cache-Control", "max-age=0");
            Generate(xml, data);

            data.WriteTo(resp.OutputStream);


        }


	    private void headerPrint(ExcelXmlParser parser){
		    cols = parser.getColumnsInfo("head");
		//Widths
		    int[] widths = parser.getWidths();
            if (this.Widths != null)
            {
                foreach (var index in this.Widths.Keys)
                {
                    if (index >= 0 && index < widths.Length)
                    {
                        widths[index] = Widths[index];
                    }
                }
            }
		    this.cols_stat = widths.Length;

             

		    int sumWidth = 0;
		    for (int i = 0; i < widths.Length; i++) {
			    sumWidth += widths[i];
		    }
           
		    if (parser.getWithoutHeader() == false) {
                ExcelFont font = wb.CreateFont(FontFamily, HeaderFontSize);
                font.Bold = true;
                if (HeaderTextColor != "FF000000")
                    font.Color = HeaderTextColor;

                ExcelBorder border = getBorder();  


			    for (uint row = 1; row <= cols.Length; row++) {

                    sheet.Rows[row].Height = RowHeight;
				    for (uint col = 1; col <= cols[row-1].Length; col++) {

                        
                        sheet.Cells[row, col].Style.Font = font;//if bold font assigned after border - all table will be bold, weird, find out later
                        
                        sheet.Cells[row, col].Style.Border = border;

                        sheet.Columns[col].Width = widths[col-1] / scale;
					    String name = cols[row-1][col-1].GetName();
                        if (BGColor != "FFFFFFFF")
                            sheet.Cells[row, col].Style.Fill.ForegroundColor = BGColor;
                        

                        

                        ///TODO: 
                        ///font color, merge cells, alignment
                        sheet.Cells[row, col].Value = name;
					    colsNumber = (int)col;
				    }
			    }
			    headerOffset = cols.Length;
		    }
	    }


        protected ExcelBorder getBorder()
        {
            ExcelBorder border = new ExcelBorder(null, wb.Styles, 0);           
            border.BottomStyle = OpenExcel.OfficeOpenXml.Style.ExcelBorderStyleValues.Thin;
            border.BottomColor = LineColor;
            border.LeftStyle = OpenExcel.OfficeOpenXml.Style.ExcelBorderStyleValues.Thin;
            border.LeftColor = LineColor;
            border.RightStyle = OpenExcel.OfficeOpenXml.Style.ExcelBorderStyleValues.Thin;
            border.RightColor = LineColor;
            border.TopStyle = OpenExcel.OfficeOpenXml.Style.ExcelBorderStyleValues.Thin;
            border.TopColor = LineColor;
            return border;
        }

	    private void footerPrint(ExcelXmlParser parser){
		    cols = parser.getColumnsInfo("foot");
            ExcelBorder border = getBorder();  
		    if (parser.getWithoutHeader() == false) {
                ExcelFont font = wb.CreateFont(FontFamily, FooterFontSize);
                
                font.Bold = true;
                if (HeaderTextColor != "FF000000")
                    font.Color = HeaderTextColor;
			    for (uint row = 1; row <= cols.Length; row++) {
                    
                    uint rowInd = (uint)(row + headerOffset);
                    sheet.Rows[rowInd].Height = RowHeight;
                 
				    for (uint col = 1; col <= cols[row-1].Length; col++) {
					
                        if (BGColor != "FFFFFFFF")
                            sheet.Cells[rowInd, col].Style.Fill.ForegroundColor = BGColor;
                        sheet.Cells[rowInd, col].Style.Font = font;
                        //TODO add text color, vertical alignment, horizontal alignment
                        sheet.Cells[rowInd, col].Style.Border = border;
                        sheet.Cells[rowInd, col].Value = cols[row - 1][col - 1].GetName();
				    }
			    }
		    }
		    headerOffset += cols.Length;
	    }

	    private void watermarkPrint(ExcelXmlParser parser){
		    if (watermark == null) return;
            ExcelFont font = wb.CreateFont(FontFamily, WatermarkFontSize);
            font.Bold = true;
            font.Color = WatermarkTextColor;
            
		    ExcelBorder border = getBorder();

		   // f.setAlignment(Alignment.CENTRE);
            sheet.Cells[(uint)(headerOffset + 1), 0].Value = watermark;
	    }

	    private void rowsPrint(ExcelXmlParser parser, Stream resp) {
		    
		    ExcelRow[] rows = parser.getGridContent();

		    this.rows_stat = rows.Length;
           
            ExcelBorder border = getBorder();
            ExcelFont font = wb.CreateFont(FontFamily, GridFontSize);

		    for (uint row = 1; row <= rows.Length; row++) {
			    ExcelCell[] cells = rows[row-1].getCells();
                uint rowInd = (uint)(row + headerOffset);
                sheet.Rows[rowInd].Height = 20;
	 
			    for (uint col = 1; col <= cells.Length; col++) {
                    if (cells[col - 1].GetBold() || cells[col - 1].GetItalic())
                    {
                        ExcelFont curFont = wb.CreateFont(FontFamily, GridFontSize); ;
                       // if (gridTextColor != "FF000000")
                     //       font.Color = gridTextColor;
                        if (cells[col - 1].GetBold())
                            font.Bold = true;
                        
                        if (cells[col - 1].GetItalic())
                            font.Italic = true;

                        sheet.Cells[rowInd, col].Style.Font = curFont;
                    }
                    else
                    {
                        sheet.Cells[rowInd, col].Style.Font = font;
                    }

                    sheet.Cells[rowInd, col].Style.Border = border;
   

                    if ((!cells[col - 1].GetBgColor().Equals(""))&&(parser.getProfile().Equals("full_color"))) 
                    {
                        sheet.Cells[rowInd, col].Style.Fill.ForegroundColor = "FF" + cells[col - 1].GetBgColor();
				    } 
                    else 
                    {
					    //Colour bg;
                        if (row % 2 == 0 && ScaleTwoColor != "FFFFFFFF")
                        {
                            sheet.Cells[rowInd, col].Style.Fill.ForegroundColor = ScaleTwoColor;						
					    } else {
                            if (ScaleOneColor != "FFFFFFFF")
                                sheet.Cells[rowInd, col].Style.Fill.ForegroundColor = ScaleOneColor;
					    }
				    }

                    
                    int intVal;
              

                    if (int.TryParse(cells[col - 1].GetValue(), out intVal))
                    {
                        sheet.Cells[rowInd, col].Value = intVal;
                    }
                    else
                    {
                        sheet.Cells[rowInd, col].Value = cells[col - 1].GetValue();
                    }
                        
                    
                    //COLOR!
				   
                    /*
				    

				    String al = cells[row].getAlign();
				    if (al == "")
					    al = cols[0][row].getAlign();
				    if (al.equalsIgnoreCase("left")) {
					    f.setAlignment(Alignment.LEFT);
				    } else {
					    if (al.equalsIgnoreCase("right")) {
						    f.setAlignment(Alignment.RIGHT);
					    } else {
						    f.setAlignment(Alignment.CENTRE);
					    }
				    }*/
				   
			    }
		    }
		    headerOffset += rows.Length;
	    }

	    private void insertHeader(ExcelXmlParser parser, Stream resp){
		   /* if (parser.getHeader() == true) {
			    sheet.insertRow(0);
			    sheet.setRowView(0, 5000);
			    File imgFile = new File(pathToImgs + "/header.png");
			    WritableImage img = new WritableImage(0, 0, cols[0].length, 1, imgFile);
			    sheet.addImage(img);
			    headerOffset++;
		    }*/
           // sheet.
	    }

	    private void insertFooter(ExcelXmlParser parser, Stream resp) {
		 /*   if (parser.getFooter() == true) {
			    sheet.setRowView(headerOffset, 5000);
			    File imgFile = new File(pathToImgs + "/footer.png");
			    WritableImage img = new WritableImage(0, headerOffset, cols[0].length, 1, imgFile);
			    sheet.addImage(img);
		    }*/
	    }

	    public int getColsStat() {
		    return this.cols_stat;
	    }
	
	    public int getRowsStat() {
		    return this.rows_stat;
	    }
        private string _stripColor(string usersValue, string internalValue)
        {
            if (!string.IsNullOrEmpty(usersValue))
            {
                return usersValue.Replace("#", "");
            }
            else
            {
                return internalValue;
            }
        }
	    private void setColorProfile() {
            var alpha = "FF";
		    String profile = parser.getProfile();
		    if ((profile.ToLower().Equals("color"))||profile.ToLower().Equals("full_color")) {
                BGColor =           alpha + _stripColor(BGColor, "D1E5FE");
                LineColor =         alpha + _stripColor(LineColor, "A4BED4");
                HeaderTextColor =   alpha + _stripColor(HeaderTextColor, "000000");
                ScaleOneColor =     alpha + _stripColor(ScaleOneColor, "FFFFFF");
                ScaleTwoColor =     alpha + _stripColor(ScaleTwoColor, "E3EFFF");
                GridTextColor =     alpha + _stripColor(GridTextColor, "00FF00");
                WatermarkTextColor =alpha + _stripColor(WatermarkTextColor, "8b8b8b");
		    } else {
			    if (profile.ToLower().Equals("gray")) {
                    BGColor =alpha + _stripColor(BGColor, "E3E3E3");
                    LineColor = alpha + _stripColor(LineColor, "B8B8B8");
                    HeaderTextColor = alpha + _stripColor(HeaderTextColor, "000000");
                    ScaleOneColor = alpha + _stripColor(ScaleOneColor, "FFFFFF");
                    ScaleTwoColor = alpha + _stripColor(ScaleTwoColor, "EDEDED");
                    GridTextColor = alpha + _stripColor(GridTextColor, "000000");
                    WatermarkTextColor = alpha + _stripColor(WatermarkTextColor, "8b8b8b");
			    } else {
                    BGColor = alpha + _stripColor(BGColor, "FFFFFF");
                    LineColor =alpha +  _stripColor(LineColor, "000000");
                    HeaderTextColor = alpha + _stripColor(HeaderTextColor, "000000");
                    ScaleOneColor =alpha +  _stripColor(ScaleOneColor, "FFFFFF");
                    ScaleTwoColor = alpha + _stripColor(ScaleTwoColor, "FFFFFF");
                    GridTextColor = alpha + _stripColor(GridTextColor, "000000");
                    WatermarkTextColor = alpha + _stripColor(WatermarkTextColor, "000000");
			    }
		    }
	    }
	
	    public void setWatermark(String mark) {
		    watermark = mark;	
	    }
    }
}
