using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DHTMLX.Export.Excel
{
    public class RGBColor
    {
        private static Dictionary<String, double[]> parsedColors = new Dictionary<String, double[]>();

        public static double[] GetColor(String color)
        {
            if (parsedColors.ContainsKey(color))
                return (double[])parsedColors[color];
            String original = color;
            color = RGBColor.ProcessColorForm(color);
            double[] result = new double[3];
            String r = color.Substring(0, 2);
            String g = color.Substring(2, 2);
            String b = color.Substring(4, 2);

            result[0] = int.Parse(r, System.Globalization.NumberStyles.HexNumber) / 255.0;
            result[1] = int.Parse(g, System.Globalization.NumberStyles.HexNumber) / 255.0;
            result[2] = int.Parse(b, System.Globalization.NumberStyles.HexNumber) / 255.0;
            parsedColors.Add(original, result);
            return result;
        }

       

        public static String ProcessColorForm(String color)
        {
            if (color.Equals("transparent"))
            {
                return "";
            }
            if (Regex.IsMatch(color, "#[0-9A-Fa-f]{6}"))
            {
                return color.Substring(1);
            }

            if (Regex.IsMatch(color, "[0-9A-Fa-f]{6}"))
            {
                return color;
            }

            var m3 = Regex.Match(color, "rgb\\s?\\(\\s?(\\d{1,3})\\s?,\\s?(\\d{1,3})\\s?,\\s?(\\d{1,3})\\s?\\)");

            if (m3.Length > 0)
            {
                color = "";
                String r = m3.Groups[1].Value;
                String g = m3.Groups[2].Value;
                String b = m3.Groups[3].Value;
                r = int.Parse(r).ToString("x");
                r = (r.Length == 1) ? "0" + r : r;
                g = int.Parse(g).ToString("x");
                g = (g.Length == 1) ? "0" + g : g;
                b = int.Parse(b).ToString("x");
                b = (b.Length == 1) ? "0" + b : b;
                color = r + g + b;
                return color;
            }
            return "";
        }
    }
}
