namespace ProjectFirma.Web.Common
{
    public static class ToadsValidationMessages  
    {
// ReSharper disable InconsistentNaming
        public const string IPESScoreRange = "IPES Score needs to be between 0 and 1150";
        public const string IPESScoreBaileyRatingXOr = "Enter an IPES Score or Bailey Rating but not both";
        public const string APNInvalid = "APN {0} must be a valid APN";
        public const string AccelaIDInvalid = "File or Case Number '{0}' not found in Accela!";
        public const string SendingApnNotEqualToReceivingApn = "Receiving APN should not equal Sending APN";
        // ReSharper restore InconsistentNaming
        public const string DateLessThanEqualTo = "The date should be on or before {0}";
        public const string QuantityGreaterThanZero = "{0} needs to be greater than zero";
        public const string RangeBetween1And10 = "Valid range is between 1 and 10";
        public const string RangeBetween1And2500 = "Valid range is between 1 and 2,500";
        public const string CommodityConvertedToRequired = "The Commodity (converted to) field is required";
        public const string ResidentialAllocationNumberRequired = "The Residential Allocation Number field is required";
        public const string ResidentialAllocationFeeReceivedRequired = "The Residential Allocation Fee Received is required";
        public const string ApprovalDateRequired = "The Approval Date is required for approved transactions";
        public const string ProjectNumberMaximum30Characters = "Project Number cannot exceed 30 characters";
        public const string SendingQuantityGreaterThanEqualToReceivingQuantityWhenInSameUnits = "Receiving Quantity needs to be less than or equal to Sending Quantity when units are the same";
        public const string ValidateSendingReceivingAndRetiredQuantitiesAreConsistenent = "The Sending Quantity must equal the Retired Quantity plus the Receiving Quantity";
        public const string TransferPriceRequiredWhenLandBankSelected = "Transfer Price is required for Land Banks";
        public const string TransferPriceValidCurrencyGreaterThanZero = "Transfer Price needs to be a valid currency format and greater than zero";
        public const string AllocatedQuantityExceedsRemainingPoolBalance = "Allocated quantity ({0}) exceeds the Allocation Pool's remaining balance ({1})";
    }
}