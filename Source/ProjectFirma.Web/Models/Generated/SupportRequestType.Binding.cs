//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SupportRequestType]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public abstract partial class SupportRequestType : IHavePrimaryKey
    {
        public static readonly SupportRequestTypeQuestionAboutPolicies QuestionAboutPolicies = SupportRequestTypeQuestionAboutPolicies.Instance;
        public static readonly SupportRequestTypeReportBug ReportBug = SupportRequestTypeReportBug.Instance;
        public static readonly SupportRequestTypeHelpWithProjectUpdate HelpWithProjectUpdate = SupportRequestTypeHelpWithProjectUpdate.Instance;
        public static readonly SupportRequestTypeForgotLoginInfo ForgotLoginInfo = SupportRequestTypeForgotLoginInfo.Instance;
        public static readonly SupportRequestTypeNewOrganizationOrFundingSource NewOrganizationOrFundingSource = SupportRequestTypeNewOrganizationOrFundingSource.Instance;
        public static readonly SupportRequestTypeOther Other = SupportRequestTypeOther.Instance;
        public static readonly SupportRequestTypeRequestToBeAddedToFtipList RequestToBeAddedToFtipList = SupportRequestTypeRequestToBeAddedToFtipList.Instance;
        public static readonly SupportRequestTypeProvideFeedback ProvideFeedback = SupportRequestTypeProvideFeedback.Instance;
        public static readonly SupportRequestTypeRequestOrganizationNameChange RequestOrganizationNameChange = SupportRequestTypeRequestOrganizationNameChange.Instance;

        public static readonly List<SupportRequestType> All;
        public static readonly ReadOnlyDictionary<int, SupportRequestType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static SupportRequestType()
        {
            All = new List<SupportRequestType> { QuestionAboutPolicies, ReportBug, HelpWithProjectUpdate, ForgotLoginInfo, NewOrganizationOrFundingSource, Other, RequestToBeAddedToFtipList, ProvideFeedback, RequestOrganizationNameChange };
            AllLookupDictionary = new ReadOnlyDictionary<int, SupportRequestType>(All.ToDictionary(x => x.SupportRequestTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected SupportRequestType(int supportRequestTypeID, string supportRequestTypeName, string supportRequestTypeDisplayName, int supportRequestTypeSortOrder, int? lTInfoAreaID)
        {
            SupportRequestTypeID = supportRequestTypeID;
            SupportRequestTypeName = supportRequestTypeName;
            SupportRequestTypeDisplayName = supportRequestTypeDisplayName;
            SupportRequestTypeSortOrder = supportRequestTypeSortOrder;
            LTInfoAreaID = lTInfoAreaID;
        }
        public LTInfoArea LTInfoArea { get { return LTInfoAreaID.HasValue ? LTInfoArea.AllLookupDictionary[LTInfoAreaID.Value] : null; } }
        [Key]
        public int SupportRequestTypeID { get; private set; }
        public string SupportRequestTypeName { get; private set; }
        public string SupportRequestTypeDisplayName { get; private set; }
        public int SupportRequestTypeSortOrder { get; private set; }
        public int? LTInfoAreaID { get; private set; }
        public int PrimaryKey { get { return SupportRequestTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(SupportRequestType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.SupportRequestTypeID == SupportRequestTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as SupportRequestType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return SupportRequestTypeID;
        }

        public static bool operator ==(SupportRequestType left, SupportRequestType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SupportRequestType left, SupportRequestType right)
        {
            return !Equals(left, right);
        }

        public SupportRequestTypeEnum ToEnum { get { return (SupportRequestTypeEnum)GetHashCode(); } }

        public static SupportRequestType ToType(int enumValue)
        {
            return ToType((SupportRequestTypeEnum)enumValue);
        }

        public static SupportRequestType ToType(SupportRequestTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case SupportRequestTypeEnum.ForgotLoginInfo:
                    return ForgotLoginInfo;
                case SupportRequestTypeEnum.HelpWithProjectUpdate:
                    return HelpWithProjectUpdate;
                case SupportRequestTypeEnum.NewOrganizationOrFundingSource:
                    return NewOrganizationOrFundingSource;
                case SupportRequestTypeEnum.Other:
                    return Other;
                case SupportRequestTypeEnum.ProvideFeedback:
                    return ProvideFeedback;
                case SupportRequestTypeEnum.QuestionAboutPolicies:
                    return QuestionAboutPolicies;
                case SupportRequestTypeEnum.ReportBug:
                    return ReportBug;
                case SupportRequestTypeEnum.RequestOrganizationNameChange:
                    return RequestOrganizationNameChange;
                case SupportRequestTypeEnum.RequestToBeAddedToFtipList:
                    return RequestToBeAddedToFtipList;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum SupportRequestTypeEnum
    {
        QuestionAboutPolicies = 1,
        ReportBug = 2,
        HelpWithProjectUpdate = 3,
        ForgotLoginInfo = 4,
        NewOrganizationOrFundingSource = 5,
        Other = 6,
        RequestToBeAddedToFtipList = 7,
        ProvideFeedback = 9,
        RequestOrganizationNameChange = 10
    }

    public partial class SupportRequestTypeQuestionAboutPolicies : SupportRequestType
    {
        private SupportRequestTypeQuestionAboutPolicies(int supportRequestTypeID, string supportRequestTypeName, string supportRequestTypeDisplayName, int supportRequestTypeSortOrder, int? lTInfoAreaID) : base(supportRequestTypeID, supportRequestTypeName, supportRequestTypeDisplayName, supportRequestTypeSortOrder, lTInfoAreaID) {}
        public static readonly SupportRequestTypeQuestionAboutPolicies Instance = new SupportRequestTypeQuestionAboutPolicies(1, @"QuestionAboutPolicies", @"Have question about EIP (policies, reporting process, etc.)", 3, 1);
    }

    public partial class SupportRequestTypeReportBug : SupportRequestType
    {
        private SupportRequestTypeReportBug(int supportRequestTypeID, string supportRequestTypeName, string supportRequestTypeDisplayName, int supportRequestTypeSortOrder, int? lTInfoAreaID) : base(supportRequestTypeID, supportRequestTypeName, supportRequestTypeDisplayName, supportRequestTypeSortOrder, lTInfoAreaID) {}
        public static readonly SupportRequestTypeReportBug Instance = new SupportRequestTypeReportBug(2, @"ReportBug", @"Ran into a bug or problem with this system", 7, null);
    }

    public partial class SupportRequestTypeHelpWithProjectUpdate : SupportRequestType
    {
        private SupportRequestTypeHelpWithProjectUpdate(int supportRequestTypeID, string supportRequestTypeName, string supportRequestTypeDisplayName, int supportRequestTypeSortOrder, int? lTInfoAreaID) : base(supportRequestTypeID, supportRequestTypeName, supportRequestTypeDisplayName, supportRequestTypeSortOrder, lTInfoAreaID) {}
        public static readonly SupportRequestTypeHelpWithProjectUpdate Instance = new SupportRequestTypeHelpWithProjectUpdate(3, @"HelpWithProjectUpdate", @"Can't figure out how to update my project", 1, 1);
    }

    public partial class SupportRequestTypeForgotLoginInfo : SupportRequestType
    {
        private SupportRequestTypeForgotLoginInfo(int supportRequestTypeID, string supportRequestTypeName, string supportRequestTypeDisplayName, int supportRequestTypeSortOrder, int? lTInfoAreaID) : base(supportRequestTypeID, supportRequestTypeName, supportRequestTypeDisplayName, supportRequestTypeSortOrder, lTInfoAreaID) {}
        public static readonly SupportRequestTypeForgotLoginInfo Instance = new SupportRequestTypeForgotLoginInfo(4, @"ForgotLoginInfo", @"Can't log in (forgot my username or password, account is locked, etc.)", 2, null);
    }

    public partial class SupportRequestTypeNewOrganizationOrFundingSource : SupportRequestType
    {
        private SupportRequestTypeNewOrganizationOrFundingSource(int supportRequestTypeID, string supportRequestTypeName, string supportRequestTypeDisplayName, int supportRequestTypeSortOrder, int? lTInfoAreaID) : base(supportRequestTypeID, supportRequestTypeName, supportRequestTypeDisplayName, supportRequestTypeSortOrder, lTInfoAreaID) {}
        public static readonly SupportRequestTypeNewOrganizationOrFundingSource Instance = new SupportRequestTypeNewOrganizationOrFundingSource(5, @"NewOrganizationOrFundingSource", @"Need an Organization or Funding Source added to the list", 4, 1);
    }

    public partial class SupportRequestTypeOther : SupportRequestType
    {
        private SupportRequestTypeOther(int supportRequestTypeID, string supportRequestTypeName, string supportRequestTypeDisplayName, int supportRequestTypeSortOrder, int? lTInfoAreaID) : base(supportRequestTypeID, supportRequestTypeName, supportRequestTypeDisplayName, supportRequestTypeSortOrder, lTInfoAreaID) {}
        public static readonly SupportRequestTypeOther Instance = new SupportRequestTypeOther(6, @"Other", @"Other", 100, null);
    }

    public partial class SupportRequestTypeRequestToBeAddedToFtipList : SupportRequestType
    {
        private SupportRequestTypeRequestToBeAddedToFtipList(int supportRequestTypeID, string supportRequestTypeName, string supportRequestTypeDisplayName, int supportRequestTypeSortOrder, int? lTInfoAreaID) : base(supportRequestTypeID, supportRequestTypeName, supportRequestTypeDisplayName, supportRequestTypeSortOrder, lTInfoAreaID) {}
        public static readonly SupportRequestTypeRequestToBeAddedToFtipList Instance = new SupportRequestTypeRequestToBeAddedToFtipList(7, @"RequestToBeAddedToFtipList", @"Request to be Added to FTIP list", 8, 1);
    }

    public partial class SupportRequestTypeProvideFeedback : SupportRequestType
    {
        private SupportRequestTypeProvideFeedback(int supportRequestTypeID, string supportRequestTypeName, string supportRequestTypeDisplayName, int supportRequestTypeSortOrder, int? lTInfoAreaID) : base(supportRequestTypeID, supportRequestTypeName, supportRequestTypeDisplayName, supportRequestTypeSortOrder, lTInfoAreaID) {}
        public static readonly SupportRequestTypeProvideFeedback Instance = new SupportRequestTypeProvideFeedback(9, @"ProvideFeedback", @"Provide Feedback on the site", 6, null);
    }

    public partial class SupportRequestTypeRequestOrganizationNameChange : SupportRequestType
    {
        private SupportRequestTypeRequestOrganizationNameChange(int supportRequestTypeID, string supportRequestTypeName, string supportRequestTypeDisplayName, int supportRequestTypeSortOrder, int? lTInfoAreaID) : base(supportRequestTypeID, supportRequestTypeName, supportRequestTypeDisplayName, supportRequestTypeSortOrder, lTInfoAreaID) {}
        public static readonly SupportRequestTypeRequestOrganizationNameChange Instance = new SupportRequestTypeRequestOrganizationNameChange(10, @"RequestOrganizationNameChange", @"Request a change to an Organization's name", 9, 1);
    }
}