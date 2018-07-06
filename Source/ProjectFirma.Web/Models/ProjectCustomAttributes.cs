using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProjectCustomAttributes : PartialViewModel, IValidatableObject
    {
        public IList<ProjectCustomAttributeSimple> Attributes { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public ProjectCustomAttributes()
        {
        }

        public ProjectCustomAttributes(IProject project)
        {
            Attributes = project.ProjectCustomAttributes
                .Select(x => new ProjectCustomAttributeSimple
                {
                    ProjectCustomAttributeTypeID = x.ProjectCustomAttributeTypeID,
                    ProjectCustomAttributeValues = x.Values
                        .Select(y =>
                            y.IProjectCustomAttribute.ProjectCustomAttributeType.ProjectCustomAttributeDataType ==
                            ProjectCustomAttributeDataType.DateTime
                                ? DateTime.Parse(y.AttributeValue).ToShortDateString()
                                : y.AttributeValue)
                        .ToList()
                })
                .ToList();
        }

        public void UpdateModel(Project project, Person currentPerson)
        {
            var allProjectCustomAttributeTypes = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes.ToList();
            var customAttributesToUpdate = Attributes.Where(x =>
                    x.ProjectCustomAttributeValues != null &&
                    x.ProjectCustomAttributeValues.Any(y => !string.IsNullOrWhiteSpace(y)))
                .Select(x => new ProjectCustomAttribute(project.ProjectID, x.ProjectCustomAttributeTypeID))
                .ToList();
            var customAttributeValuesToUpdate = customAttributesToUpdate.Join(Attributes,
                    x => x.ProjectCustomAttributeTypeID,
                    x => x.ProjectCustomAttributeTypeID,
                    (a, b) =>
                    {
                        // Use existing attribute ID if you can, otherwise use dummy entity ID
                        var projectCustomAttributeID =
                            project.ProjectCustomAttributes
                                .SingleOrDefault(x => x.ProjectCustomAttributeTypeID == a.ProjectCustomAttributeTypeID)
                                ?.ProjectCustomAttributeID ?? a.ProjectCustomAttributeID;
                        var projectCustomAttributeType = allProjectCustomAttributeTypes.Single(x =>
                            x.ProjectCustomAttributeTypeID == a.ProjectCustomAttributeTypeID);
                        return b.ProjectCustomAttributeValues
                            .Select(x =>
                            {
                                var attributeValue = projectCustomAttributeType.ProjectCustomAttributeDataType
                                    .ValueParsedForDataType(x);
                                return new ProjectCustomAttributeValue(projectCustomAttributeID, attributeValue);
                            })
                            .ToList();
                    })
                .SelectMany(x => x)
                .ToList();

            UpdateProjectCustomAttributesImpl(project.ProjectCustomAttributes,
                customAttributesToUpdate,
                HttpRequestStorage.DatabaseEntities.AllProjectCustomAttributes.Local);
            UpdateProjectCustomAttributeValuesImpl(
                project.ProjectCustomAttributes.SelectMany(x => x.ProjectCustomAttributeValues).ToList(),
                customAttributeValuesToUpdate,
                HttpRequestStorage.DatabaseEntities.AllProjectCustomAttributeValues.Local);
        }

        public void UpdateModel(ProjectUpdate projectUpdate, Person currentPerson)
        {
            var allProjectCustomAttributeTypes = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes.ToList();
            var customAttributesToUpdate = Attributes.Where(x =>
                    x.ProjectCustomAttributeValues != null &&
                    x.ProjectCustomAttributeValues.Any(y => !string.IsNullOrWhiteSpace(y)))
                .Select(x => new ProjectCustomAttributeUpdate(projectUpdate.ProjectUpdateBatchID, x.ProjectCustomAttributeTypeID))
                .ToList();
            var customAttributeValuesToUpdate = customAttributesToUpdate.Join(Attributes,
                    x => x.ProjectCustomAttributeTypeID,
                    x => x.ProjectCustomAttributeTypeID,
                    (a, b) =>
                    {
                        // Use existing attribute ID if you can, otherwise use dummy entity ID
                        var projectCustomAttributeUpdateID =
                            projectUpdate.ProjectUpdateBatch.ProjectCustomAttributeUpdates
                                .SingleOrDefault(x => x.ProjectCustomAttributeTypeID == a.ProjectCustomAttributeTypeID)
                                ?.ProjectCustomAttributeUpdateID ?? a.ProjectCustomAttributeUpdateID;
                        var projectCustomAttributeType = allProjectCustomAttributeTypes.Single(x =>
                            x.ProjectCustomAttributeTypeID == a.ProjectCustomAttributeTypeID);
                        return b.ProjectCustomAttributeValues
                            .Select(x =>
                            {
                                var attributeValue = projectCustomAttributeType.ProjectCustomAttributeDataType
                                    .ValueParsedForDataType(x);
                                return new ProjectCustomAttributeUpdateValue(projectCustomAttributeUpdateID, attributeValue);
                            })
                            .ToList();
                    })
                .SelectMany(x => x)
                .ToList();

            UpdateProjectCustomAttributesImpl(projectUpdate.ProjectUpdateBatch.ProjectCustomAttributeUpdates,
                customAttributesToUpdate,
                HttpRequestStorage.DatabaseEntities.AllProjectCustomAttributeUpdates.Local);
            UpdateProjectCustomAttributeValuesImpl(
                projectUpdate.ProjectUpdateBatch.ProjectCustomAttributeUpdates.SelectMany(x => x.ProjectCustomAttributeUpdateValues).ToList(),
                customAttributeValuesToUpdate,
                HttpRequestStorage.DatabaseEntities.AllProjectCustomAttributeUpdateValues.Local);
        }

        private static void UpdateProjectCustomAttributesImpl<TProjectCustomAttribute>(
            ICollection<TProjectCustomAttribute> existingProjectCustomAttributes,
            ICollection<TProjectCustomAttribute> projectCustomAttributesToUpdate,
            ObservableCollection<TProjectCustomAttribute> projectCustomAttributesInDatabase)
            where TProjectCustomAttribute : IProjectCustomAttribute
        {
            existingProjectCustomAttributes.Merge(projectCustomAttributesToUpdate,
                projectCustomAttributesInDatabase,
                (x, y) => x.ProjectCustomAttributeTypeID == y.ProjectCustomAttributeTypeID);
        }

        private void UpdateProjectCustomAttributeValuesImpl<TProjectCustomAttributeValue>(
            ICollection<TProjectCustomAttributeValue> existingProjectCustomAttributeValues,
            ICollection<TProjectCustomAttributeValue> projectCustomAttributeValuesToUpdate,
            ObservableCollection<TProjectCustomAttributeValue> projectCustomAttributeValuesInDatabase)
            where TProjectCustomAttributeValue : IProjectCustomAttributeValue
        {
            existingProjectCustomAttributeValues.Merge(projectCustomAttributeValuesToUpdate,
                projectCustomAttributeValuesInDatabase,
                (x, y) => x.IProjectCustomAttributeID == y.IProjectCustomAttributeID &&
                          x.AttributeValue == y.AttributeValue);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var customAttributeTypeIDs = Attributes.Select(x => x.ProjectCustomAttributeTypeID).ToList();
            var customAttributeTypes = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes
                .Where(x => customAttributeTypeIDs.Contains(x.ProjectCustomAttributeTypeID))
                .ToList();

            var projectCustomAttributeSimples = Attributes
                .Where(x => x.ProjectCustomAttributeValues != null && x.ProjectCustomAttributeValues.Any());

            foreach (var attributeSimple in projectCustomAttributeSimples)
            {
                var type = customAttributeTypes.Single(x => x.ProjectCustomAttributeTypeID == attributeSimple.ProjectCustomAttributeTypeID);
                foreach (var value in attributeSimple.ProjectCustomAttributeValues)
                {
                    if (!string.IsNullOrWhiteSpace(value) && !type.ProjectCustomAttributeDataType.ValueIsCorrectDataType(value))
                    {
                        yield return new ValidationResult($"Entered value for {type.ProjectCustomAttributeTypeName} does not match expected type " +
                                                          $"({type.ProjectCustomAttributeDataType.ProjectCustomAttributeDataTypeDisplayName}).");
                    }
                }

                if (type.IsRequired && attributeSimple.ProjectCustomAttributeValues.All(string.IsNullOrWhiteSpace))
                {
                    yield return new ValidationResult($"Value is required for {type.ProjectCustomAttributeTypeName}.");
                }
            }
        }
    }
}
