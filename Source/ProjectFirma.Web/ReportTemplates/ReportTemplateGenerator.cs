using DocumentFormat.OpenXml.Packaging;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.ReportTemplates.Models;
using ProjectFirmaModels.Models;
using SharpDocx;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace ProjectFirma.Web.ReportTemplates
{
    public class ReportTemplateGenerator
    {
        public const string TemplateTempDirectoryName = "ProjectFirmaReportTemplates";
        public const string TemplateTempImageDirectoryName = "Images";
        public const int TemplateTempDirectoryFileLifespanInDays = 2;
        protected ReportTemplate ReportTemplate { get; set; }
        protected ReportTemplateModelEnum ReportTemplateModelEnum { get; set; }
        protected ReportTemplateModelTypeEnum ReportTemplateModelTypeEnum { get; set; }
        protected List<int> SelectedModelIDs { get; set; }
        protected string FullTemplateTempDirectory { get; set; }
        protected string FullTemplateTempImageDirectory { get; set; }

        /// <summary>
        /// ReportTemplateUniqueIdentifier is used for file names in the TEMP directory.
        /// </summary>
        protected Guid ReportTemplateUniqueIdentifier { get; set; }
        
        public ReportTemplateGenerator(ReportTemplate reportTemplate, List<int> selectedModelIDs)
        {
            ReportTemplate = reportTemplate;
            ReportTemplateModelEnum = reportTemplate.ReportTemplateModel.ToEnum;
            ReportTemplateModelTypeEnum = reportTemplate.ReportTemplateModelType.ToEnum;
            SelectedModelIDs = selectedModelIDs;
            ReportTemplateUniqueIdentifier = Guid.NewGuid();
            InitializeTempFolders();
        }

        private void InitializeTempFolders()
        {
            var tempPath = new DirectoryInfo(SitkaConfiguration.GetRequiredAppSetting("TempFolder"));
            var baseTempDirectory = new DirectoryInfo($"{tempPath.FullName}\\{TemplateTempDirectoryName}\\");
            baseTempDirectory.Create();
            FullTemplateTempDirectory = baseTempDirectory.FullName;
            FullTemplateTempImageDirectory = baseTempDirectory.CreateSubdirectory(TemplateTempImageDirectoryName).FullName;
        }

        public void Generate()
        {
            var templatePath = GetTemplatePath();
            ProjectFirmaDocxDocument document;
            SaveTemplateFileToTempDirectory();

            // todo: if someone generates a report with all projects, the resulting .docx can get up to 3gb+ depending on the tenant, how do we want to handle this situation?
            if (TemplateHasImages(templatePath))
            {
                SaveImageFilesToTempDirectory();
            }

            switch (ReportTemplateModelEnum)
            {
                case ReportTemplateModelEnum.Project:
                    var baseViewModel = new ReportTemplateProjectBaseViewModel()
                    {
                        ReportTitle = ReportTemplate.DisplayName,
                        ReportModel = GetListOfProjectModels()
                    };
                    document = DocumentFactory.Create<ProjectFirmaDocxDocument>(templatePath, baseViewModel);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var compilePath = GetCompilePath();
            document.ImageDirectory = FullTemplateTempImageDirectory;
            document.Generate(compilePath);

            CleanTempDirectoryOfOldFiles(FullTemplateTempDirectory);
        }

        /// <summary>
        /// Simple regex to test to see if a word document template has any Image() methods in it.
        /// </summary>
        /// <param name="templatePath"></param>
        /// <returns></returns>
        private static bool TemplateHasImages(string templatePath)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(templatePath, true))
            {
                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                {
                    var docText = sr.ReadToEnd();
                    var regexForImage = @"Image\(";
                    var match = Regex.Match(docText, regexForImage);
                    return match.Success;
                }
            }
        }

        /// <summary>
        /// Because Sharpdocx uses directories for images we need to save the images that can be used with the chosen model into a directory that can be accessed
        /// when the report generates. This allows us to create a helper on the ReportTemplateProjectImage model that can then call Image() and pass in the
        /// same file name (that uses the file resource unique GUID)
        /// </summary>
        private void SaveImageFilesToTempDirectory()
        {
            switch (ReportTemplateModelEnum)
            {
                case ReportTemplateModelEnum.Project:
                    var projectsList = HttpRequestStorage.DatabaseEntities.Projects.Where(x => SelectedModelIDs.Contains(x.ProjectID)).ToList();
                    var projectImages = projectsList.SelectMany(x => x.ProjectImages).ToList();
                    foreach (var projectImage in projectImages)
                    {
                        var imagePath = $"{FullTemplateTempImageDirectory}\\{projectImage.FileResource.GetFullGuidBasedFilename()}";
                        CorrectImageProblemsAndSaveToDisk(projectImage, imagePath);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// In testing the sharpdocx image functionality at least two issues with images uploaded to ProjectFirma came up
        /// 1. Encountered an image with a corrupt color profile
        /// 2. Encountered an image with no DPI set
        ///
        /// In case #1, this caused caused the generation to crash
        /// In case #2, this caused the the image in the OpenXML for the .docx to have invalid x and y extents, corrupting the .docx file
        ///
        /// It is likely that doing this will fix other potential issues with uploaded images to ProjectFirma
        ///
        /// We can also take the opportunity here to do some scaling of the images so that they don't need to generate massive images files that have been uploaded
        /// to ProjectFirma
        ///
        /// todo: let the owner of the SharpDocx repository know about these issues to be able to set defaults there instead
        /// </summary>
        /// <param name="projectImage"></param>
        /// <param name="imagePath"></param>
        private static void CorrectImageProblemsAndSaveToDisk(ProjectImage projectImage, string imagePath)
        {
            // in order to save time on subsequent reports, we should check to see if the file already exists at the path and return early
            var fileInfo = new FileInfo(imagePath);
            if (fileInfo.Exists)
            {
                return;
            }

            using (var ms = new MemoryStream(projectImage.FileResource.FileResourceData))
            {
                var bitmap = new Bitmap(ms);
                using (Bitmap newBitmap = new Bitmap(bitmap))
                {
                    newBitmap.Save(imagePath, ImageFormat.Jpeg);
                }
            }
        }
        
        public ActionResult GenerateAndDownload()
        {
            Generate();
            var fileData = File.ReadAllBytes(GetCompilePath());
            var stream = new MemoryStream(fileData);
            return new FileResourceResult(ReportTemplate.FileResource.GetOriginalCompleteFileName(), stream, FileResourceMimeType.WordDOCX);
        }

        private void CleanTempDirectoryOfOldFiles(string targetDirectory)
        {
            if (Directory.Exists(targetDirectory))
            {
                var fileEntries = Directory.GetFiles(targetDirectory);
                foreach (string fileName in fileEntries)
                    DeleteFileIfOlderThanLifespan(fileName);
                var directories = Directory.GetDirectories(targetDirectory);
                foreach (string directory in directories)
                    CleanTempDirectoryOfOldFiles(directory);
            }
        }

        private void DeleteFileIfOlderThanLifespan(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            if(fileInfo.LastAccessTime < DateTime.Now.AddDays(-TemplateTempDirectoryFileLifespanInDays))
                fileInfo.Delete();
        }

        /// <summary>
        /// Stores the uploaded ReportTemplate .docx file in the temp directory.
        /// </summary>
        private void SaveTemplateFileToTempDirectory()
        {
            var filePath = GetTemplatePath();
            File.WriteAllBytes(filePath, ReportTemplate.FileResource.FileResourceData);
        }

        /// <summary>
        /// Get the intended template path for this ReportTemplate. 
        /// </summary>
        /// <returns></returns>
        private string GetTemplatePath()
        {
            var fileName = new FileInfo($"{FullTemplateTempDirectory}{ReportTemplateUniqueIdentifier}-{ReportTemplate.FileResource.GetOriginalCompleteFileName()}");
            fileName.Directory.Create();
            return fileName.FullName;
        }
        
        /// <summary>
        /// Get the compile path for this ReportTemplate that the .docx template will compile to.
        /// </summary>
        /// <returns></returns>
        private string GetCompilePath()
        {
            var fileName = new FileInfo($"{FullTemplateTempDirectory}{ReportTemplateUniqueIdentifier}-generated-{ReportTemplate.FileResource.GetOriginalCompleteFileName()}");
            fileName.Directory.Create();
            return fileName.FullName;
        }
        
        private List<ReportTemplateProjectModel> GetListOfProjectModels()
        {
            var listOfModels = new List<ReportTemplateProjectModel>();
            var projectsList = HttpRequestStorage.DatabaseEntities.Projects.Where(x => SelectedModelIDs.Contains(x.ProjectID)).ToList();
            var orderedProjectList = projectsList.OrderBy(p => SelectedModelIDs.IndexOf(p.ProjectID)).ToList();
            orderedProjectList.ForEach(x => listOfModels.Add(new ReportTemplateProjectModel(x)));
            return listOfModels;
        }

        public static void ValidateReportTemplate(ReportTemplate reportTemplate, out bool reportIsValid, out string errorMessage, out string sourceCode)
        {
            errorMessage = "";
            sourceCode = "";

            var reportTemplateModel = reportTemplate.ReportTemplateModel.ToEnum;
            List<int> selectedModelIDs;
            switch (reportTemplateModel)
            {
                case ReportTemplateModelEnum.Project:
                    // select 10 random models to test the report with
                    // SMG 2/17/2020 this can cause problems with templates failing only some of the time, but it feels costly to validate against every single model in the system
                    selectedModelIDs = HttpRequestStorage.DatabaseEntities.Projects
                        .Select(x => x.ProjectID).Take(10).ToList();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            ValidateReportTemplateForSelectedModelIDs(reportTemplate, selectedModelIDs, out reportIsValid, out errorMessage, out sourceCode);
        }

        public static void ValidateReportTemplateForSelectedModelIDs(ReportTemplate reportTemplate, List<int> selectedModelIDs, out bool reportIsValid, out string errorMessage, out string sourceCode)
        {
            errorMessage = "";
            sourceCode = "";
            var reportTemplateGenerator = new ReportTemplateGenerator(reportTemplate, selectedModelIDs);
            var tempDirectory = reportTemplateGenerator.GetCompilePath();
            try
            {
                reportTemplateGenerator.Generate();
                reportIsValid = true;
            }
            catch (SharpDocxCompilationException exception)
            {
                errorMessage = exception.Errors;
                sourceCode = exception.SourceCode;
                reportIsValid = false;
                SitkaLogger.Instance.LogDetailedErrorMessage($"There was a SharpDocxCompilationException validating a report template. Temporary template file location:\"{tempDirectory}\" Error Message: \"{errorMessage}\". Source Code: \"{sourceCode}\"", exception);
            }
            catch (Exception exception)
            {
                reportIsValid = false;

                // SMG 2/12/2020 submitted an issue on the SharpDocx repo https://github.com/egonl/SharpDocx/issues/13 for better exceptions to be able to refactor this out later.
                switch (exception.Message)
                {
                    case "No end tag found for code.":
                        errorMessage =
                            $"CodeBlockBuilder exception: \"{exception.Message}\". Could not find a matching closing tag \"%>\" for an opening tag.";
                        break;
                    case "TextBlock is not terminated with '<% } %>'.":
                        errorMessage = $"CodeBlockBuilder exception: \"{exception.Message}\".";
                        break;
                    default:
                        errorMessage = exception.Message;
                        break;
                }

                sourceCode = exception.StackTrace;
                SitkaLogger.Instance.LogDetailedErrorMessage($"There was a SharpDocxCompilationException validating a report template. Temporary template file location:\"{tempDirectory}\". Error Message: \"{errorMessage}\".", exception);
            }
        }

    }
}