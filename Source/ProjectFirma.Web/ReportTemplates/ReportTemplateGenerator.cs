using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.ReportTemplates.Models;
using ProjectFirmaModels.Models;
using SharpDocx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            
            var models = GetListOfModels();
            var templateViewModel = new ReportTemplateBaseViewModel()
            {
                ReportTitle = ReportTemplate.DisplayName,
                ReportModel = models
            };

            var templatePath = GetTemplatePath();

            SaveTemplateFileToTempDirectory();
            SaveImageFilesToTempDirectory();
            
            var document = DocumentFactory.Create<ProjectFirmaDocxDocument>(templatePath, templateViewModel);
            
            document.ImageDirectory = FullTemplateTempImageDirectory;

            var compilePath = GetCompilePath();
            document.Generate(compilePath);

            CleanTempDirectoryOfOldFiles(FullTemplateTempDirectory);
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
                        File.WriteAllBytes(imagePath, projectImage.FileResource.FileResourceData);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
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
        
        private List<ReportTemplateBaseModel> GetListOfModels()
        {
            var listOfModels = new List<ReportTemplateBaseModel>();

            switch (ReportTemplateModelEnum)
            {
                case ReportTemplateModelEnum.Project:
                    var projectsList = HttpRequestStorage.DatabaseEntities.Projects.Where(x => SelectedModelIDs.Contains(x.ProjectID)).ToList();
                    var orderedProjectList = projectsList.OrderBy(p => SelectedModelIDs.IndexOf(p.ProjectID)).ToList();
                    orderedProjectList.ForEach(x => listOfModels.Add(new ReportTemplateProjectModel(x)));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

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