/*-----------------------------------------------------------------------
<copyright file="IWebServices.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System.Collections.Generic;
using System.ServiceModel;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Service.ServiceModels;
using LtInfo.Common;

namespace ProjectFirma.Web.Service
{
    [ServiceContract]
    [WebServicesErrorHandler]
    public interface IWebServices
    {
        [OperationContract]
        [WebServiceDocumentationAttribute("Provides detailed information for the specified project.")]
        List<WebServiceProject> GetProject(string returnType, string webServiceToken, int projectID);

        [OperationContract]
        [WebServiceDocumentationAttribute("Provides the list of all projects regardless of stage or year completed.")]
        List<WebServiceProject> GetProjects(string returnType, string webServiceToken);

        [OperationContract]
        [WebServiceDocumentationAttribute("Provides the list of projects where the specified organization is a funder or an implementer of the project.")]
        List<WebServiceProject> GetProjectsByOrganization(string returnType, string webServiceToken, int organizationID);
        
        [OperationContract]
        [WebServiceDocumentationAttribute("Provides the list of performance measure accomplishments for the specified Project.")]
        List<WebServiceProjectAccomplishments> GetProjectAccomplishments(string returnType, string webServiceToken, int projectID);

        [OperationContract]
        [WebServiceDocumentationAttribute("Provides the description of the specified Project.")]
        List<WebServiceProjectDescription> GetProjectDescription(string returnType, string webServiceToken, int projectID);

        [OperationContract]
        [WebServiceDocumentationAttribute("Provides the URL to the key photo for the specified Project.")]
        List<WebServiceProjectKeyPhoto> GetProjectKeyPhoto(string returnType, string webServiceToken, int projectID);

        [OperationContract]
        [WebServiceDocumentationAttribute("Provides the list of all Performance Measures (aka PerformanceMeasures), including their subcategories (aka dimensions) and the number of options in each performanceMeasureSubcategory.")]
        List<WebServicePerformanceMeasure> GetPerformanceMeasures(string returnType, string webServiceToken);

        [OperationContract]
        [WebServiceDocumentationAttribute("Provides the list of all Organizations within the LT Info platform. Most organizations in this list are local jurisdictions, agencies, associations, or private firms within the Lake Tahoe area, however this list will also include organizations of any person who as requested an account.")]
        List<WebServiceOrganization> GetOrganizations(string returnType, string webServiceToken);
    }
}
