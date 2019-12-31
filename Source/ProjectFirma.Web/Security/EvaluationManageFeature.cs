/*-----------------------------------------------------------------------
<copyright file="EvaluationManageFeature.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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

using System;
using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Evaluation Content")]
    public class EvaluationManageFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Evaluation>
    {
        private readonly FirmaFeatureWithContextImpl<Evaluation> _firmaFeatureWithContextImpl;

        public EvaluationManageFeature(): base(new List<Role>{Role.Admin, Role.SitkaAdmin})
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<Evaluation>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(FirmaSession firmaSession, Evaluation contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }

        public static bool HasEvaluationManagePermission(FirmaSession currentFirmaSession, Evaluation evaluation)
        {
            var permissionCheckResult = new EvaluationManageFeature().HasPermission(currentFirmaSession, evaluation);
            return permissionCheckResult.HasPermission;
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, Evaluation contextModelObject)
        {
            if (firmaSession.IsAnonymousOrUnassigned())
            {
                return new PermissionCheckResult("Anonymous users can't manage evaluations");
            }

            var evaluationVisibility = (EvaluationVisibilityEnum)contextModelObject.EvaluationVisibilityID;
            switch (evaluationVisibility)
            {
                case EvaluationVisibilityEnum.AdminsFromMyOrganizationOnly:
                    if (contextModelObject.CreatePerson.OrganizationID == firmaSession.Person.OrganizationID && firmaSession.IsAdministrator())
                    {
                        // Positive result
                        return new PermissionCheckResult();
                    }
                    return new PermissionCheckResult($"You don't have permission to manage {FieldDefinitionEnum.Evaluation.ToType().GetFieldDefinitionLabel()} {contextModelObject.EvaluationName} because permissions are set to {evaluationVisibility}. The relevant organization is {contextModelObject.CreatePerson.Organization.GetDisplayName()}.");

                case EvaluationVisibilityEnum.OnlyMe:
                    if (contextModelObject.CreatePersonID == firmaSession.PersonID)
                    {
                        // Positive result
                        return new PermissionCheckResult();
                    }
                    else
                    {
                        return new PermissionCheckResult($"You don't have permission to manage {FieldDefinitionEnum.Evaluation.ToType().GetFieldDefinitionLabel()} {contextModelObject.EvaluationName} because because permissions are set to {evaluationVisibility} and you are not the creator");
                    }

                case EvaluationVisibilityEnum.AllAdmins:
                    if (firmaSession.IsAdministrator())
                    {
                        // Positive result
                        return new PermissionCheckResult();
                    }
                    else
                    {
                        return new PermissionCheckResult($"You don't have permission to manage {FieldDefinitionEnum.Evaluation.ToType().GetFieldDefinitionLabel()} {contextModelObject.EvaluationName} because permissions are set to {evaluationVisibility} and you are not an Admin");
                    }

                default:
                    throw new ArgumentOutOfRangeException($"Unhandled enum: {evaluationVisibility}");
            }

        }
    }
}
