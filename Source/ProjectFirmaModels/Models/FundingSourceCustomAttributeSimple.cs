using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirmaModels.Models
{
    public class FundingSourceCustomAttributeSimple
    {
        public FundingSourceCustomAttributeSimple(FundingSourceCustomAttribute fundingSourceCustomAttribute)
        {
            FundingSourceCustomAttributeTypeID = fundingSourceCustomAttribute.FundingSourceCustomAttributeTypeID;
            FundingSourceCustomAttributeValues = fundingSourceCustomAttribute.GetCustomAttributeValues()
                .Select(y =>
                    y.FundingSourceCustomAttribute.FundingSourceCustomAttributeType.FundingSourceCustomAttributeDataType ==
                    FundingSourceCustomAttributeDataType.DateTime
                        ? DateTime.Parse(y.AttributeValue).ToShortDateString()
                        : y.AttributeValue)
                .ToList();
        }

        public FundingSourceCustomAttributeSimple()
        {
        }

        public int FundingSourceCustomAttributeTypeID { get; set; }
        public IList<string> FundingSourceCustomAttributeValues { get; set; }
    }
}