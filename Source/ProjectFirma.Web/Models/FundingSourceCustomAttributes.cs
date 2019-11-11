using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirmaModels.Models
{
    public class FundingSourceCustomAttributes : PartialViewModel, IValidatableObject
    {
        public IList<FundingSourceCustomAttributeSimple> Attributes { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public FundingSourceCustomAttributes()
        {
        }

        public FundingSourceCustomAttributes(FundingSource fundingSource)
        {
            Attributes = fundingSource.FundingSourceCustomAttributes.Select(x => new FundingSourceCustomAttributeSimple(x)).ToList();
        }

        public void UpdateModel(FundingSource fundingSource, FirmaSession currentFirmaSession)
        {
            var allFundingSourceCustomAttributeTypes = HttpRequestStorage.DatabaseEntities.FundingSourceCustomAttributeTypes.ToList();
            var existingFundingSourceCustomAttributes = fundingSource.FundingSourceCustomAttributes.Where(x => x.FundingSourceCustomAttributeType.HasEditPermission(currentFirmaSession)).ToList();
            var customAttributesToUpdate = Attributes.Where(x =>
                    x.FundingSourceCustomAttributeValues != null &&
                    x.FundingSourceCustomAttributeValues.Any(y => !string.IsNullOrWhiteSpace(y)))
                .Select(x => new FundingSourceCustomAttribute(fundingSource.FundingSourceID, x.FundingSourceCustomAttributeTypeID))
                .ToList();
            var existingFundingSourceCustomAttributeValues = existingFundingSourceCustomAttributes.SelectMany(x => x.FundingSourceCustomAttributeValues).ToList();
            var customAttributeValuesToUpdate = customAttributesToUpdate.Join(Attributes,
                    x => x.FundingSourceCustomAttributeTypeID,
                    x => x.FundingSourceCustomAttributeTypeID,
                    (a, b) =>
                    {
                        // Use existing attribute ID if you can, otherwise use dummy entity ID
                        var fundingSourceCustomAttributeID =
                            existingFundingSourceCustomAttributes
                                .SingleOrDefault(x => x.FundingSourceCustomAttributeTypeID == a.FundingSourceCustomAttributeTypeID)
                                ?.FundingSourceCustomAttributeID ?? a.FundingSourceCustomAttributeID;
                        var fundingSourceCustomAttributeType = allFundingSourceCustomAttributeTypes.Single(x =>
                            x.FundingSourceCustomAttributeTypeID == a.FundingSourceCustomAttributeTypeID);
                        return b.FundingSourceCustomAttributeValues
                            .Select(x =>
                            {
                                var attributeValue = fundingSourceCustomAttributeType.FundingSourceCustomAttributeDataType
                                    .ValueParsedForDataType(x);
                                return new FundingSourceCustomAttributeValue(fundingSourceCustomAttributeID, attributeValue);
                            })
                            .ToList();
                    })
                .SelectMany(x => x)
                .ToList();

            UpdateFundingSourceCustomAttributesImpl(existingFundingSourceCustomAttributes,
                customAttributesToUpdate,
                HttpRequestStorage.DatabaseEntities.AllFundingSourceCustomAttributes.Local);
            UpdateFundingSourceCustomAttributeValuesImpl(
                existingFundingSourceCustomAttributeValues,
                customAttributeValuesToUpdate,
                HttpRequestStorage.DatabaseEntities.AllFundingSourceCustomAttributeValues.Local);
        }

        private static void UpdateFundingSourceCustomAttributesImpl<TFundingSourceCustomAttribute>(
            ICollection<TFundingSourceCustomAttribute> existingFundingSourceCustomAttributes,
            ICollection<TFundingSourceCustomAttribute> fundingSourceCustomAttributesToUpdate,
            ObservableCollection<TFundingSourceCustomAttribute> fundingSourceCustomAttributesInDatabase)
            where TFundingSourceCustomAttribute : FundingSourceCustomAttribute
        {
            existingFundingSourceCustomAttributes.Merge(fundingSourceCustomAttributesToUpdate,
                fundingSourceCustomAttributesInDatabase,
                (x, y) => x.FundingSourceCustomAttributeTypeID == y.FundingSourceCustomAttributeTypeID, HttpRequestStorage.DatabaseEntities);
        }

        private void UpdateFundingSourceCustomAttributeValuesImpl<TFundingSourceCustomAttributeValue>(
            ICollection<TFundingSourceCustomAttributeValue> existingFundingSourceCustomAttributeValues,
            ICollection<TFundingSourceCustomAttributeValue> fundingSourceCustomAttributeValuesToUpdate,
            ObservableCollection<TFundingSourceCustomAttributeValue> fundingSourceCustomAttributeValuesInDatabase)
            where TFundingSourceCustomAttributeValue : FundingSourceCustomAttributeValue
        {
            existingFundingSourceCustomAttributeValues.Merge(fundingSourceCustomAttributeValuesToUpdate,
                fundingSourceCustomAttributeValuesInDatabase,
                (x, y) => x.FundingSourceCustomAttributeID == y.FundingSourceCustomAttributeID &&
                          x.AttributeValue == y.AttributeValue, HttpRequestStorage.DatabaseEntities);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var customAttributeTypeIDs = Attributes.Select(x => x.FundingSourceCustomAttributeTypeID).ToList();
            var customAttributeTypes = HttpRequestStorage.DatabaseEntities.FundingSourceCustomAttributeTypes
                .Where(x => customAttributeTypeIDs.Contains(x.FundingSourceCustomAttributeTypeID))
                .ToList();

            var fundingSourceCustomAttributeSimples = Attributes
                .Where(x => x.FundingSourceCustomAttributeValues != null && x.FundingSourceCustomAttributeValues.Any());

            foreach (var attributeSimple in fundingSourceCustomAttributeSimples)
            {
                var type = customAttributeTypes.Single(x => x.FundingSourceCustomAttributeTypeID == attributeSimple.FundingSourceCustomAttributeTypeID);
                foreach (var value in attributeSimple.FundingSourceCustomAttributeValues)
                {
                    if (!string.IsNullOrWhiteSpace(value) && !type.FundingSourceCustomAttributeDataType.ValueIsCorrectDataType(value))
                    {
                        yield return new ValidationResult($"Entered value for {type.FundingSourceCustomAttributeTypeName} does not match expected type " +
                                                          $"({type.FundingSourceCustomAttributeDataType.FundingSourceCustomAttributeDataTypeDisplayName}).");
                    }
                }

                if (type.IsRequired && attributeSimple.FundingSourceCustomAttributeValues.All(string.IsNullOrWhiteSpace))
                {
                    yield return new ValidationResult($"Value is required for {type.FundingSourceCustomAttributeTypeName}.");
                }
            }
        }
    }
}
