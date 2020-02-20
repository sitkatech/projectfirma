using System;
using System.Collections.Generic;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LtInfo.Common;
using SharpDocx;
using SharpDocx.Extensions;
using ImageHelper = SharpDocx.ImageHelper;

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
                "Microsoft.CSharp.dll"
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
            run.RunProperties.Color = new Color { Val = color };
        }

        /// <summary>
        /// This is an override to the DocumentBase implementation of Image. This way we can catch the exception that is occuring on images
        /// that have corrupt color profiles and move on with the document generation.
        /// More info on corrupt color profiles: https://www.hanselman.com/blog/DealingWithImagesWithBadMetadataCorruptedColorProfilesInWPF.aspx
        /// 
        /// todo: create pull request on SharpDocx to fix this at the core instead of overloading it here
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="percentage"></param>
        protected new void Image(string filePath, int percentage = 100)
        {
            if (string.IsNullOrEmpty(Path.GetDirectoryName(filePath)) &&
                !string.IsNullOrEmpty(ImageDirectory))
            {
                filePath = $"{ImageDirectory}/{filePath}";
            }

            var imageTypePart = ImageHelper.GetImagePartType(filePath);

            const long emusPerTwip = 635;
            var maxWidthInEmus = GetPageContentWidthInTwips() * emusPerTwip;

            // This try catch here was what was modified from the original -- 2/20/2020 SMG 
            try
            {
                Drawing drawing;
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    drawing = ImageHelper.CreateDrawing(Package, fs, imageTypePart, percentage, maxWidthInEmus);
                }

                CurrentCodeBlock.Placeholder.InsertAfterSelf(drawing);

                if (!CurrentCodeBlock.Placeholder.GetParent<Paragraph>().HasText())
                {
                    // Insert a zero-width space, so the image doesn't get deleted by CodeBlock.RemoveEmptyParagraphs.
                    CurrentCodeBlock.Placeholder.Text = "\u200B";
                }
            }
            catch (Exception exception)
            {
                CurrentCodeBlock.Placeholder.Text = "(Couldn't insert image due to corrupted color profiles on the image file)";
                var run = CurrentCodeBlock.Placeholder.GetParent<Run>();
                if (run != null)
                {
                    run.RunProperties.Color = new Color { Val = "#FF0000" };
                }
                SitkaLogger.Instance.LogDetailedErrorMessage($"There was an error inserting an image into a document template. Possible image color profile corruption. Temporary image file location:\"{filePath}\"", exception);
            }

        }

    }
}