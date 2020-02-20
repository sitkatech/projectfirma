using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using SharpDocx;
using SharpDocx.Extensions;
using System.Collections.Generic;
using Color = DocumentFormat.OpenXml.Wordprocessing.Color;

namespace ProjectFirma.Web.ReportTemplates
{
    public abstract class ProjectFirmaDocxDocument : DocumentBase
    {
        public string MyProperty { get; set; }

        public new static List<string> GetUsingDirectives()
        {
            return new List<string>
            {
                "using ProjectFirma.Web.ReportTemplates;",
                "using ProjectFirma.Web.Models;",
                "using System.Collections.Generic;",
                "using Microsoft.CSharp.RuntimeBinder;",
                "using System.Linq;"

            };
        }

        // referencing required assemblies
        public new static List<string> GetReferencedAssemblies()
        {
            return new List<string>
            {
                "System.Core.dll",
                "Microsoft.CSharp.dll",
                "System.Collections.dll",
                "System.Runtime.dll",
            };
        }

        protected void SetCellColor(string color)
        {
            if (color == null) return;
            color = color.Replace("#", "");

            var cell = CurrentCodeBlock.Placeholder.GetParent<TableCell>();
            if (cell == null) return;
            cell.TableCellProperties.Shading = new Shading
            {
                Fill = color,
                Color = "auto",
                Val = new EnumValue<ShadingPatternValues>(ShadingPatternValues.Clear)
            };
        }

        protected void SetTextColor(string color)
        {
            var run = CurrentCodeBlock.Placeholder.GetParent<Run>();
            if (run == null) return;
            run.RunProperties.Color = new Color {Val = color};
        }

    }
    
}