using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security.Shared;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class FileResourceController : LakeTahoeInfoBaseController
    {
        [AnonymousUnclassifiedFeature]
        [CrossAreaRoute]
        public ActionResult DisplayResource(string fileResourceGuidAsString)
        {
            Guid fileResourceGuid;
            var isStringAGuid = Guid.TryParse(fileResourceGuidAsString, out fileResourceGuid);
            if (isStringAGuid)
            {
                var fileResource = HttpRequestStorage.DatabaseEntities.FileResources.SingleOrDefault(x => x.FileResourceGUID == fileResourceGuid);

                return DisplayResourceImpl(fileResourceGuidAsString, fileResource);
            }
            // Unhappy path - return an HTTP 404
            // ---------------------------------
            var message = string.Format("File Resource {0} Not Found in database. It may have been deleted.", fileResourceGuidAsString);
            throw new HttpException(404, message);
        }

        private ActionResult DisplayResourceImpl(string fileResourcePrimaryKey, FileResource fileResource)
        {
            if (fileResource == null)
            {
                var message = string.Format("File Resource {0} Not Found in database. It may have been deleted.", fileResourcePrimaryKey);
                throw new HttpException(404, message);
            }

            switch (fileResource.FileResourceMimeType.ToEnum)
            {
                case FileResourceMimeTypeEnum.ExcelXLS:
                case FileResourceMimeTypeEnum.ExcelXLSX:
                case FileResourceMimeTypeEnum.xExcelXLSX:
                    return new ExcelResult(new MemoryStream(fileResource.FileResourceData), fileResource.OriginalCompleteFileName);
                case FileResourceMimeTypeEnum.PDF:
                    return new PdfResult(fileResource);
                case FileResourceMimeTypeEnum.WordDOCX:
                case FileResourceMimeTypeEnum.WordDOC:
                case FileResourceMimeTypeEnum.PowerpointPPTX:
                case FileResourceMimeTypeEnum.PowerpointPPT:
                    return new FileResourceResult(fileResource.OriginalCompleteFileName, fileResource.FileResourceData, fileResource.FileResourceMimeType);
                case FileResourceMimeTypeEnum.XPNG:
                case FileResourceMimeTypeEnum.PNG:
                case FileResourceMimeTypeEnum.TIFF:
                case FileResourceMimeTypeEnum.BMP:
                case FileResourceMimeTypeEnum.GIF:
                case FileResourceMimeTypeEnum.JPEG:
                case FileResourceMimeTypeEnum.PJPEG:
                    return File(fileResource.FileResourceData, fileResource.FileResourceMimeType.FileResourceMimeTypeName);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        [LoggedInUnclassifiedFeature]
        [CrossAreaRoute]
        public ActionResult DisplayResourceByID(FileResourcePrimaryKey fileResourcePrimaryKey)
        {
            var fileResource = fileResourcePrimaryKey.EntityObject;
            return DisplayResourceImpl(fileResourcePrimaryKey.PrimaryKeyValue.ToString(), fileResource);
        }

        [AnonymousUnclassifiedFeature]
        [CrossAreaRoute]
        public ActionResult GetFileResourceResized(string fileResourceGuidAsString, int maxWidth, int maxHeight)
        {
            Guid fileResourceGuid;
            var isStringAGuid = Guid.TryParse(fileResourceGuidAsString, out fileResourceGuid);
            if (isStringAGuid)
            {
                var fileResource = HttpRequestStorage.DatabaseEntities.FileResources.SingleOrDefault(x => x.FileResourceGUID == fileResourceGuid);
                if (fileResource != null)
                {
                    // Happy path - return the resource
                    // ---------------------------------
                    switch (fileResource.FileResourceMimeType.ToEnum)
                    {
                        case FileResourceMimeTypeEnum.ExcelXLS:
                        case FileResourceMimeTypeEnum.ExcelXLSX:
                        case FileResourceMimeTypeEnum.xExcelXLSX:
                        case FileResourceMimeTypeEnum.PDF:
                        case FileResourceMimeTypeEnum.WordDOCX:
                        case FileResourceMimeTypeEnum.WordDOC:
                        case FileResourceMimeTypeEnum.PowerpointPPTX:
                        case FileResourceMimeTypeEnum.PowerpointPPT:
                            throw new ArgumentOutOfRangeException(string.Format("Not supported mime type {0}", fileResource.FileResourceMimeType.FileResourceMimeTypeDisplayName));
                        case FileResourceMimeTypeEnum.XPNG:
                        case FileResourceMimeTypeEnum.PNG:
                        case FileResourceMimeTypeEnum.TIFF:
                        case FileResourceMimeTypeEnum.BMP:
                        case FileResourceMimeTypeEnum.GIF:
                        case FileResourceMimeTypeEnum.JPEG:
                        case FileResourceMimeTypeEnum.PJPEG:
                            using (var scaledImage = ImageHelper.ScaleImage(fileResource.FileResourceData, maxWidth, maxHeight))
                            {
                                using (var ms = new MemoryStream())
                                {
                                    scaledImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    return File(ms.ToArray(), FileResourceMimeType.PNG.FileResourceMimeTypeName);
                                }
                            }
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            // Unhappy path - return an HTTP 404
            // ---------------------------------
            var message = string.Format("File Resource {0} Not Found in database. It may have been deleted.", fileResourceGuidAsString);
            throw new HttpException(404, message);
        }

        /// <summary>
        /// Dummy fake HTTP "GET" for <see cref="CkEditorUploadFileResource(ProjectFirmaPagePrimaryKey, CkEditorImageUploadViewModel)"/>
        /// </summary>
        /// <returns></returns>
        [CrossAreaRoute]
        [HttpGet]
        [ProjectFirmaPageManageFeature]
        public ContentResult CkEditorUploadFileResource(ProjectFirmaPagePrimaryKey projectFirmaPagePrimaryKey)
        {
            return Content(String.Empty);
        }

        [CrossAreaRoute]
        [HttpPost]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        [ProjectFirmaPageManageFeature]
        public ContentResult CkEditorUploadFileResource(ProjectFirmaPagePrimaryKey projectFirmaPagePrimaryKey, CkEditorImageUploadViewModel viewModel)
        {
            var fileResource = FileResource.CreateNewFromHttpPostedFileAndSave(viewModel.upload, CurrentPerson);
            var projectFirmaPage = projectFirmaPagePrimaryKey.EntityObject;
            var ppImage = new ProjectFirmaPageImage(projectFirmaPage, fileResource);
            HttpRequestStorage.DatabaseEntities.ProjectFirmaPageImages.Add(ppImage);
            return Content(viewModel.GetCkEditorJavascriptContentToReturn(fileResource));
        }

        /// <summary>
        /// Dummy fake HTTP "GET" for <see cref="CkEditorUploadFileResource(ProjectFirmaPagePrimaryKey, CkEditorImageUploadViewModel)"/>
        /// </summary>
        /// <returns></returns>
        [CrossAreaRoute]
        [HttpGet]
        [ProjectFirmaPageManageFeature]
        public ContentResult CkEditorUploadFileResourceForProjectFirmaPage(ProjectFirmaPagePrimaryKey projectFirmaPagePrimaryKey)
        {
            return Content(String.Empty);
        }


        [CrossAreaRoute]
        [HttpPost]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        [ProjectFirmaPageManageFeature]
        public ContentResult CkEditorUploadFileResourceForProjectFirmaPage(ProjectFirmaPagePrimaryKey projectFirmaPagePrimaryKey, CkEditorImageUploadViewModel viewModel)
        {
            var fileResource = FileResource.CreateNewFromHttpPostedFileAndSave(viewModel.upload, CurrentPerson);
            var projectFirmaPage = projectFirmaPagePrimaryKey.EntityObject;
            var ppImage = new ProjectFirmaPageImage(projectFirmaPage, fileResource);
            HttpRequestStorage.DatabaseEntities.ProjectFirmaPageImages.Add(ppImage);
            return Content(viewModel.GetCkEditorJavascriptContentToReturn(fileResource));
        }

        /// <summary>
        /// Dummy fake HTTP "GET" for <see cref="CkEditorUploadFileResourceForFocusArea(FocusAreaPrimaryKey, CkEditorImageUploadViewModel)"/>
        /// </summary>
        /// <returns></returns>
        [CrossAreaRoute]
        [HttpGet]
        [FocusAreaManageFeature]
        public ContentResult CkEditorUploadFileResourceForFocusArea(FocusAreaPrimaryKey focusAreaPrimaryKey)
        {
            return Content(String.Empty);
        }

        [CrossAreaRoute]
        [HttpPost]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        [FocusAreaManageFeature]
        public ContentResult CkEditorUploadFileResourceForFocusArea(FocusAreaPrimaryKey focusAreaPrimaryKey, CkEditorImageUploadViewModel viewModel)
        {
            var fileResource = FileResource.CreateNewFromHttpPostedFileAndSave(viewModel.upload, CurrentPerson);
            var focusArea = focusAreaPrimaryKey.EntityObject;
            var image = new FocusAreaImage(focusArea, fileResource);
            HttpRequestStorage.DatabaseEntities.FocusAreaImages.Add(image);
            return Content(viewModel.GetCkEditorJavascriptContentToReturn(fileResource));
        }

        /// <summary>
        /// Dummy fake HTTP "GET" for <see cref="CkEditorUploadFileResourceForProgram(ProgramPrimaryKey, CkEditorImageUploadViewModel)"/>
        /// </summary>
        /// <returns></returns>
        [CrossAreaRoute]
        [HttpGet]
        [ProgramManageFeature]
        public ContentResult CkEditorUploadFileResourceForProgram(ProgramPrimaryKey programPrimaryKey)
        {
            return Content(String.Empty);
        }

        [CrossAreaRoute]
        [HttpPost]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        [ProgramManageFeature]
        public ContentResult CkEditorUploadFileResourceForProgram(ProgramPrimaryKey programPrimaryKey, CkEditorImageUploadViewModel viewModel)
        {
            var fileResource = FileResource.CreateNewFromHttpPostedFileAndSave(viewModel.upload, CurrentPerson);
            var program = programPrimaryKey.EntityObject;
            var image = new ProgramImage(program, fileResource);
            HttpRequestStorage.DatabaseEntities.ProgramImages.Add(image);
            return Content(viewModel.GetCkEditorJavascriptContentToReturn(fileResource));
        }

        /// <summary>
        /// Dummy fake HTTP "GET" for <see cref="CkEditorUploadFileResourceForActionPriority(ActionPriorityPrimaryKey, CkEditorImageUploadViewModel)"/>
        /// </summary>
        /// <returns></returns>
        [CrossAreaRoute]
        [HttpGet]
        [ActionPriorityManageFeature]
        public ContentResult CkEditorUploadFileResourceForActionPriority(ActionPriorityPrimaryKey actionPriorityPrimaryKey)
        {
            return Content(String.Empty);
        }

        [CrossAreaRoute]
        [HttpPost]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        [ActionPriorityManageFeature]
        public ContentResult CkEditorUploadFileResourceForActionPriority(ActionPriorityPrimaryKey actionPriorityPrimaryKey, CkEditorImageUploadViewModel viewModel)
        {
            var fileResource = FileResource.CreateNewFromHttpPostedFileAndSave(viewModel.upload, CurrentPerson);
            var actionPriority = actionPriorityPrimaryKey.EntityObject;
            var image = new ActionPriorityImage(actionPriority, fileResource);
            HttpRequestStorage.DatabaseEntities.ActionPriorityImages.Add(image);
            return Content(viewModel.GetCkEditorJavascriptContentToReturn(fileResource));
        }

        /// <summary>
        /// Dummy fake HTTP "GET" for <see cref="CkEditorUploadFileResourceForActionPriority(ActionPriorityPrimaryKey, CkEditorImageUploadViewModel)"/>
        /// </summary>
        /// <returns></returns>
        [CrossAreaRoute]
        [HttpGet]
        [IndicatorManageFeature]
        public ContentResult CkEditorUploadFileResourceForThresholdCategory(ThresholdCategoryPrimaryKey thresholdCategoryPrimary)
        {
            return Content(String.Empty);
        }

        [CrossAreaRoute]
        [HttpPost]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        [IndicatorManageFeature]
        public ContentResult CkEditorUploadFileResourceForThresholdCategory(ThresholdCategoryPrimaryKey thresholdCategoryPrimary, CkEditorImageUploadViewModel viewModel)
        {
            var fileResource = FileResource.CreateNewFromHttpPostedFileAndSave(viewModel.upload, CurrentPerson);
            var thresholdCategory = thresholdCategoryPrimary.EntityObject;
            var image = new ThresholdCategoryImage(thresholdCategory, fileResource);
            HttpRequestStorage.DatabaseEntities.ThresholdCategoryImages.Add(image);
            return Content(viewModel.GetCkEditorJavascriptContentToReturn(fileResource));
        }

        /// <summary>
        /// Dummy fake HTTP "GET" for <see cref="CkEditorUploadFileResourceForTransportationObjective(TransportationObjectivePrimaryKey, CkEditorImageUploadViewModel)"/>
        /// </summary>
        /// <returns></returns>
        [CrossAreaRoute]
        [HttpGet]
        [TransportationObjectiveManageFeature]
        public ContentResult CkEditorUploadFileResourceForTransportationObjective(TransportationObjectivePrimaryKey transportationObjectivePrimaryKey)
        {
            return Content(String.Empty);
        }

        [CrossAreaRoute]
        [HttpPost]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        [TransportationObjectiveManageFeature]
        public ContentResult CkEditorUploadFileResourceForTransportationObjective(TransportationObjectivePrimaryKey transportationObjectivePrimaryKey, CkEditorImageUploadViewModel viewModel)
        {
            var fileResource = FileResource.CreateNewFromHttpPostedFileAndSave(viewModel.upload, CurrentPerson);
            var transportationObjective = transportationObjectivePrimaryKey.EntityObject;
            var image = new TransportationObjectiveImage(transportationObjective, fileResource);
            HttpRequestStorage.DatabaseEntities.TransportationObjectiveImages.Add(image);
            return Content(viewModel.GetCkEditorJavascriptContentToReturn(fileResource));
        }

        /// <summary>
        /// Dummy fake HTTP "GET" for <see cref="CkEditorUploadFileResourceForTransportationStrategy(TransportationStrategyPrimaryKey, CkEditorImageUploadViewModel)"/>
        /// </summary>
        /// <returns></returns>
        [CrossAreaRoute]
        [HttpGet]
        [TransportationStrategyManageFeature]
        public ContentResult CkEditorUploadFileResourceForTransportationStrategy(TransportationStrategyPrimaryKey transportationStrategyPrimaryKey)
        {
            return Content(String.Empty);
        }

        [CrossAreaRoute]
        [HttpPost]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        [TransportationStrategyManageFeature]
        public ContentResult CkEditorUploadFileResourceForTransportationStrategy(TransportationStrategyPrimaryKey transportationStrategyPrimaryKey, CkEditorImageUploadViewModel viewModel)
        {
            var fileResource = FileResource.CreateNewFromHttpPostedFileAndSave(viewModel.upload, CurrentPerson);
            var transportationStrategy = transportationStrategyPrimaryKey.EntityObject;
            var image = new TransportationStrategyImage(transportationStrategy, fileResource);
            HttpRequestStorage.DatabaseEntities.TransportationStrategyImages.Add(image);
            return Content(viewModel.GetCkEditorJavascriptContentToReturn(fileResource));
        }

        /// <summary>
        /// Dummy fake HTTP "GET" for <see cref="CkEditorUploadFileResourceForFieldDefinition(FieldDefinitionPrimaryKey, CkEditorImageUploadViewModel)"/>
        /// </summary>
        /// <returns></returns>
        [CrossAreaRoute]
        [HttpGet]
        [FieldDefinitionManageFeature]
        public ContentResult CkEditorUploadFileResourceForFieldDefinition(FieldDefinitionPrimaryKey fieldDefinitionPrimaryKey)
        {
            return Content(String.Empty);
        }

        [CrossAreaRoute]
        [HttpPost]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        [FieldDefinitionManageFeature]
        public ContentResult CkEditorUploadFileResourceForFieldDefinition(FieldDefinitionPrimaryKey fieldDefinitionPrimaryKey, CkEditorImageUploadViewModel viewModel)
        {
            var fileResource = FileResource.CreateNewFromHttpPostedFileAndSave(viewModel.upload, CurrentPerson);
            var fieldDefinition = fieldDefinitionPrimaryKey.EntityObject;
            var image = new FieldDefinitionImage(fieldDefinition, fileResource);
            HttpRequestStorage.DatabaseEntities.FieldDefinitionImages.Add(image);
            return Content(viewModel.GetCkEditorJavascriptContentToReturn(fileResource));
        }

        public class CkEditorImageUploadViewModel
        {
            // ReSharper disable InconsistentNaming
            public string CKEditorFuncNum { get; set; }
            public HttpPostedFileBase upload { get; set; }
            // ReSharper restore InconsistentNaming

            public string GetCkEditorJavascriptContentToReturn(FileResource fileResource)
            {
                var ckEditorJavascriptContentToReturn = String.Format(@"
<script language=""javascript"" type=""text/javascript"">
    // <![CDATA[
    window.parent.CKEDITOR.tools.callFunction({0}, {1});
    // ]]>
</script>", CKEditorFuncNum, fileResource.FileResourceUrl.ToJS());
                return ckEditorJavascriptContentToReturn;
            }
        }
    }
}