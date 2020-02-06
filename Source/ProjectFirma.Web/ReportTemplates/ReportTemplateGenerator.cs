using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.ReportTemplates.Models;
using ProjectFirmaModels.Models;
using SharpDocx;

namespace ProjectFirma.Web.ReportTemplates
{
    public class ReportTemplateGenerator
    {
        public const string TemplateTempDirectory = "ProjectFirmaReportTemplates";
        public const int TemplateTempDirectoryFileLifespanInDays = 1;
        protected ProjectFirmaModels.Models.ReportTemplate ReportTemplate { get; set; }
        protected ReportTemplateModelEnum ReportTemplateModelEnum { get; set; }
        protected ReportTemplateModelTypeEnum ReportTemplateModelTypeEnum { get; set; }
        protected List<int> SelectedModelIDs { get; set; }
        /// <summary>
        /// ReportTemplateUniqueIdentifier is used for file names in the TEMP directory.
        /// </summary>
        protected Guid ReportTemplateUniqueIdentifier { get; set; }
        
        public ReportTemplateGenerator(ProjectFirmaModels.Models.ReportTemplate reportTemplate, List<int> selectedModelIDs)
        {
            ReportTemplate = reportTemplate;
            ReportTemplateModelEnum = reportTemplate.ReportTemplateModel.ToEnum;
            ReportTemplateModelTypeEnum = reportTemplate.ReportTemplateModelType.ToEnum;
            SelectedModelIDs = selectedModelIDs;
            ReportTemplateUniqueIdentifier = Guid.NewGuid();
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
            
            var document = DocumentFactory.Create<ProjectFirmaDocxDocument>(templatePath, templateViewModel);
            
            // TODO: Figure out solution/need for images in the reports
            //document.ImageDirectory =
            //    "C:\\git\\sitkatech\\projectfirma\\Source\\ProjectFirma.Web\\Content\\document-templates\\images";

            var compilePath = GetCompilePath();
            document.Generate(compilePath);

            DeleteDirectory(GetFullTemporaryTemplateDirectory());
        }

        public ActionResult GenerateAndDownload()
        {
            Generate();
            var fileData = System.IO.File.ReadAllBytes(GetCompilePath());
            var stream = new MemoryStream(fileData);
            return new FileResourceResult(ReportTemplate.FileResource.GetOriginalCompleteFileName(), stream, ProjectFirmaModels.Models.FileResourceMimeType.WordDOCX);
        }

        private void DeleteDirectory(string targetDirectory)
        {
            if (Directory.Exists(targetDirectory))
            {
                var fileEntries = Directory.GetFiles(targetDirectory);
                foreach (string fileName in fileEntries)
                    DeleteFile(fileName);
                var directories = Directory.GetDirectories(targetDirectory);
                foreach (string directory in directories)
                    DeleteDirectory(directory);
            }
        }

        private void DeleteFile(string filePath)
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
            System.IO.File.WriteAllBytes(filePath, ReportTemplate.FileResource.FileResourceData);
        }

        /// <summary>
        /// Get the intended template path for this ReportTemplate. 
        /// </summary>
        /// <returns></returns>
        private string GetTemplatePath()
        {
            var fileName = new System.IO.FileInfo($"{GetFullTemporaryTemplateDirectory()}{ReportTemplateUniqueIdentifier}-{ReportTemplate.FileResource.GetOriginalCompleteFileName()}");
            fileName.Directory.Create();
            return fileName.FullName;
        }

        /// <summary>
        /// Get the compile path for this ReportTemplate that the .docx template will compile to.
        /// </summary>
        /// <returns></returns>
        private string GetCompilePath()
        {
            var fileName = new System.IO.FileInfo($"{GetFullTemporaryTemplateDirectory()}{ReportTemplateUniqueIdentifier}-generated-{ReportTemplate.FileResource.GetOriginalCompleteFileName()}");
            fileName.Directory.Create();
            return fileName.FullName;
        }

        private string GetFullTemporaryTemplateDirectory()
        {
            return $"{System.IO.Path.GetTempPath()}{TemplateTempDirectory}\\";
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

    }
}