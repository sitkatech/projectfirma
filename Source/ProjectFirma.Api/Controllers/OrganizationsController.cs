using System;
using System.Linq;
using System.Web.Http;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Api.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Controllers
{
    public class OrganizationsController : ApiController
    {
        private readonly DatabaseEntities _databaseEntities = new DatabaseEntities(Tenant.ActionAgendaForPugetSound.TenantID, "ProjectFirmaDB");

        [Route("api/Organizations/List/{apiKey}")]
        [HttpGet]
        public IHttpActionResult Get(string apiKey)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
            var organizations = _databaseEntities.Organizations.ToList();
            var result = organizations.Select(x => new OrganizationDto(x)).ToList();
            return Ok(result);
        }

        [Route("api/Organizations/PostOrganization/{apiKey}")]
        [HttpPost]
        public IHttpActionResult PostOrganization(string apiKey, [FromBody] OrganizationDto organizationDto)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
            var tenantID = Tenant.ActionAgendaForPugetSound.TenantID;
            // If Organization already exists because it was created by Keystone - do an Update instead of a create
            if (_databaseEntities.Organizations.Any(x => x.OrganizationName == organizationDto.OrganizationName))
            {
                var existingOrganization = _databaseEntities.Organizations.Single(x => x.OrganizationName == organizationDto.OrganizationName);
                // Give the Dto the correct Organization ID and OrganizationTypeID for ProjectFirma
                organizationDto.OrganizationID = existingOrganization.OrganizationID;
                organizationDto.OrganizationTypeID = _databaseEntities.OrganizationTypes.SingleOrDefault(x => x.OrganizationTypeName == organizationDto.OrganizationTypeName)?.OrganizationTypeID ?? _databaseEntities.OrganizationTypes.Single(x => x.IsDefaultOrganizationType).OrganizationTypeID;
                return UpdateOrganization(apiKey, organizationDto);
            }
            var organization = new Organization(organizationDto.OrganizationName, organizationDto.IsActive, organizationDto.OrganizationTypeID, true, false);
            organization.OrganizationGuid = organizationDto.OrganizationGuid;
            organization.OrganizationShortName = organizationDto.OrganizationShortName;
            organization.OrganizationUrl = organizationDto.OrganizationUrl;
            organization.Description = organizationDto.Description;
            if (organizationDto.LogoFileResource != null)
            {
                var fileResourceDto = organizationDto.LogoFileResource;
                var fileResourceMimeType = MapFileResourceMimeTypeNameToFileResourceMimeType(fileResourceDto.FileResourceMimeTypeName);
                if (fileResourceMimeType == null)
                {
                    var error =
                        $"Invalid File Resource Mime Type '{fileResourceDto.FileResourceMimeTypeName}' for '{fileResourceDto.FileResourceGUID}'";
                    return BadRequest(error);
                }

                var peopleDictionary = _databaseEntities.People.ToDictionary(x => x.Email);
                var fileResourceMimeTypeID = fileResourceMimeType.FileResourceMimeTypeID;
                var personID = peopleDictionary.ContainsKey(fileResourceDto.Email) ? peopleDictionary[fileResourceDto.Email].PersonID : 5278;
                var fileResourceInfo = new FileResourceInfo(fileResourceMimeTypeID, fileResourceDto.OriginalBaseFilename,
                    fileResourceDto.OriginalFileExtension, fileResourceDto.FileResourceGUID,
                    personID, fileResourceDto.CreateDate);
                fileResourceInfo.FileResourceDatas.Add(new FileResourceData(fileResourceInfo.FileResourceInfoID, fileResourceDto.FileResourceData));

                organization.LogoFileResourceInfo = fileResourceInfo;
            }
            _databaseEntities.AllOrganizations.Add(organization);
            _databaseEntities.SaveChangesWithNoAuditing(tenantID);
            var organizationReloaded = new OrganizationDto(organization);
            return Ok(organizationReloaded);
        }

        private static FileResourceMimeType MapFileResourceMimeTypeNameToFileResourceMimeType(string googleChartTypeName)
        {
            return FileResourceMimeType.All.SingleOrDefault(x => x.FileResourceMimeTypeDisplayName.Equals(googleChartTypeName, StringComparison.InvariantCultureIgnoreCase));
        }

        [Route("api/Organizations/UpdateOrganization/{apiKey}")]
        [HttpPut]
        public IHttpActionResult UpdateOrganization(string apiKey, [FromBody] OrganizationDto organizationDto)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
            var organization = _databaseEntities.Organizations.SingleOrDefault(x => x.OrganizationID == organizationDto.OrganizationID);
            if (organization == null)
            {
                var message = $"Organization with ID = {organizationDto.OrganizationID} not found";
                return NotFound();
            }

            organization.OrganizationName = organizationDto.OrganizationName;
            organization.OrganizationGuid = organizationDto.OrganizationGuid;
            organization.OrganizationShortName = organizationDto.OrganizationShortName;
            organization.OrganizationTypeID = organizationDto.OrganizationTypeID;
            organization.IsActive = organizationDto.IsActive;
            organization.OrganizationUrl = organizationDto.OrganizationUrl;
            organization.Description = organizationDto.Description;
            if (organizationDto.LogoFileResource != null)
            {
                var fileResourceDto = organizationDto.LogoFileResource;
                var fileResourceMimeType = MapFileResourceMimeTypeNameToFileResourceMimeType(fileResourceDto.FileResourceMimeTypeName);
                if (fileResourceMimeType == null)
                {
                    var error =
                        $"Invalid File Resource Mime Type '{fileResourceDto.FileResourceMimeTypeName}' for '{fileResourceDto.FileResourceGUID}'";
                    return BadRequest(error);
                }

                var peopleDictionary = _databaseEntities.People.ToDictionary(x => x.Email);
                var fileResourceMimeTypeID = fileResourceMimeType.FileResourceMimeTypeID;
                var personID = peopleDictionary.ContainsKey(fileResourceDto.Email) ? peopleDictionary[fileResourceDto.Email].PersonID : 5278;
                var fileResourceInfo = new FileResourceInfo(fileResourceMimeTypeID, fileResourceDto.OriginalBaseFilename,
                    fileResourceDto.OriginalFileExtension, fileResourceDto.FileResourceGUID,
                    personID, fileResourceDto.CreateDate);
                fileResourceInfo.FileResourceDatas.Add(new FileResourceData(fileResourceInfo.FileResourceInfoID, fileResourceDto.FileResourceData));

                var oldLogoFileResourceInfo = organization.LogoFileResourceInfo;
                organization.LogoFileResourceInfo = fileResourceInfo;
                oldLogoFileResourceInfo?.FileResourceData.Delete(_databaseEntities);
                oldLogoFileResourceInfo?.Delete(_databaseEntities);
            }

            _databaseEntities.SaveChangesWithNoAuditing(Tenant.ActionAgendaForPugetSound.TenantID);
            var fundingSourceReloaded = new OrganizationDto(organization);
            return Ok(fundingSourceReloaded);
        }

        [Route("api/Organizations/Delete/{apiKey}/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(string apiKey, int id)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
            var organization = _databaseEntities.Organizations.SingleOrDefault(x => x.OrganizationID == id);
            if (organization == null)
            {
                var message = $"Organization with ID = {id} not found";
                return NotFound();
            }
            organization.LogoFileResourceInfo?.FileResourceData.Delete(_databaseEntities);
            organization.LogoFileResourceInfo?.Delete(_databaseEntities);
            organization.DeleteFull(_databaseEntities);
            _databaseEntities.SaveChangesWithNoAuditing(Tenant.ActionAgendaForPugetSound.TenantID);
            return Ok();
        }

        [Route("api/Organizations/UpdateOrganizationDescription/{apiKey}")]
        [HttpPut]
        public IHttpActionResult UpdateOrganizationDescription(string apiKey, [FromBody] OrganizationDescriptionDto organizationDto)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
            var organization = _databaseEntities.Organizations.SingleOrDefault(x => x.OrganizationID == organizationDto.OrganizationID);
            if (organization == null)
            {
                var message = $"Performance Measure with ID = {organizationDto.OrganizationID} not found";
                return NotFound();
            }

            organization.Description = organizationDto.Description;

            var fileResourceDtos = organizationDto.FileResources;
            var fileResourceMimeTypes = fileResourceDtos.ToDictionary(x => new { x.FileResourceGUID, x.FileResourceMimeTypeName },
                x => MapFileResourceMimeTypeNameToFileResourceMimeType(x.FileResourceMimeTypeName));
            if (fileResourceMimeTypes.Values.Any(x => x == null))
            {
                var errors =
                fileResourceMimeTypes.Where(x => x.Value == null).Select(x =>
                    $"Invalid File Resource Mime Type '{x.Key.FileResourceMimeTypeName}' for '{x.Key.FileResourceGUID}'").ToList();
                return BadRequest(string.Join("\r\n", errors));
            }

            // Remove all of these, too hard to merge nicely
            _databaseEntities.AllFileResourceDatas.RemoveRange(organization.OrganizationImages.Select(x => x.FileResourceInfo.FileResourceData));
            _databaseEntities.AllFileResourceInfos.RemoveRange(organization.OrganizationImages.Select(x => x.FileResourceInfo));
            _databaseEntities.AllOrganizationImages.RemoveRange(organization.OrganizationImages);

            var peopleDictionary = _databaseEntities.People.ToDictionary(x => x.Email);
            var organizationImagesToUpdate = fileResourceDtos.Select(x =>
            {
                var fileResourceMimeTypeID = fileResourceMimeTypes.Single(y => y.Key.FileResourceGUID == x.FileResourceGUID).Value.FileResourceMimeTypeID;
                var personID = peopleDictionary.ContainsKey(x.Email) ? peopleDictionary[x.Email].PersonID : 5278;
                var fileResourceInfo = new FileResourceInfo(fileResourceMimeTypeID, x.OriginalBaseFilename, x.OriginalFileExtension, x.FileResourceGUID, personID, x.CreateDate);
                fileResourceInfo.FileResourceDatas.Add(new FileResourceData(fileResourceInfo.FileResourceInfoID, x.FileResourceData));
                var organizationImage = new OrganizationImage(organization, fileResourceInfo);
                return organizationImage;
            }).ToList();

            _databaseEntities.SaveChangesWithNoAuditing(Tenant.ActionAgendaForPugetSound.TenantID);
            var organizationReloaded = new OrganizationDto(organization);
            return Ok(organizationReloaded);
        }
    }
}