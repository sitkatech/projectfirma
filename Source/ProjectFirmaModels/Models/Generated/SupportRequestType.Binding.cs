//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SupportRequestType]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public abstract partial class SupportRequestType : IHavePrimaryKey
    {
        public static readonly SupportRequestTypeReportBug ReportBug = SupportRequestTypeReportBug.Instance;
        public static readonly SupportRequestTypeHelpWithProjectUpdate HelpWithProjectUpdate = SupportRequestTypeHelpWithProjectUpdate.Instance;
        public static readonly SupportRequestTypeForgotLoginInfo ForgotLoginInfo = SupportRequestTypeForgotLoginInfo.Instance;
        public static readonly SupportRequestTypeNewOrganizationOrFundingSource NewOrganizationOrFundingSource = SupportRequestTypeNewOrganizationOrFundingSource.Instance;
        public static readonly SupportRequestTypeProvideFeedback ProvideFeedback = SupportRequestTypeProvideFeedback.Instance;
        public static readonly SupportRequestTypeRequestOrganizationNameChange RequestOrganizationNameChange = SupportRequestTypeRequestOrganizationNameChange.Instance;
        public static readonly SupportRequestTypeOther Other = SupportRequestTypeOther.Instance;
        public static readonly SupportRequestTypeRequestProjectPrimaryContactChange RequestProjectPrimaryContactChange = SupportRequestTypeRequestProjectPrimaryContactChange.Instance;
        public static readonly SupportRequestTypeRequestPermissionToAddProjects RequestPermissionToAddProjects = SupportRequestTypeRequestPermissionToAddProjects.Instance;

        public static readonly List<SupportRequestType> All;
        public static readonly ReadOnlyDictionary<int, SupportRequestType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static SupportRequestType()
        {
            All = new List<SupportRequestType> { ReportBug, HelpWithProjectUpdate, ForgotLoginInfo, NewOrganizationOrFundingSource, ProvideFeedback, RequestOrganizationNameChange, Other, RequestProjectPrimaryContactChange, RequestPermissionToAddProjects };
            AllLookupDictionary = new ReadOnlyDictionary<int, SupportRequestType>(All.ToDictionary(x => x.SupportRequestTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected SupportRequestType(int supportRequestTypeID, string supportRequestTypeName, string supportRequestTypeDisplayName, int supportRequestTypeSortOrder)
        {
            SupportRequestTypeID = supportRequestTypeID;
            SupportRequestTypeName = supportRequestTypeName;
            SupportRequestTypeDisplayName = supportRequestTypeDisplayName;
            SupportRequestTypeSortOrder = supportRequestTypeSortOrder;
        }

        [Key]
        public int SupportRequestTypeID { get; private set; }
        public string SupportRequestTypeName { get; private set; }
        public string SupportRequestTypeDisplayName { get; private set; }
        public int SupportRequestTypeSortOrder { get; private set; }
        [NotMapped]
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
                case SupportRequestTypeEnum.ReportBug:
                    return ReportBug;
                case SupportRequestTypeEnum.RequestOrganizationNameChange:
                    return RequestOrganizationNameChange;
                case SupportRequestTypeEnum.RequestPermissionToAddProjects:
                    return RequestPermissionToAddProjects;
                case SupportRequestTypeEnum.RequestProjectPrimaryContactChange:
                    return RequestProjectPrimaryContactChange;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum SupportRequestTypeEnum
    {
        ReportBug = 1,
        HelpWithProjectUpdate = 2,
        ForgotLoginInfo = 3,
        NewOrganizationOrFundingSource = 4,
        ProvideFeedback = 5,
        RequestOrganizationNameChange = 6,
        Other = 7,
        RequestProjectPrimaryContactChange = 8,
        RequestPermissionToAddProjects = 9
    }

    public partial class SupportRequestTypeReportBug : SupportRequestType
    {
        private SupportRequestTypeReportBug(int supportRequestTypeID, string supportRequestTypeName, string supportRequestTypeDisplayName, int supportRequestTypeSortOrder) : base(supportRequestTypeID, supportRequestTypeName, supportRequestTypeDisplayName, supportRequestTypeSortOrder) {}
        public static readonly SupportRequestTypeReportBug Instance = new SupportRequestTypeReportBug(1, @"ReportBug", @"Ran into a bug or problem with this system", 7);
    }

    public partial class SupportRequestTypeHelpWithProjectUpdate : SupportRequestType
    {
        private SupportRequestTypeHelpWithProjectUpdate(int supportRequestTypeID, string supportRequestTypeName, string supportRequestTypeDisplayName, int supportRequestTypeSortOrder) : base(supportRequestTypeID, supportRequestTypeName, supportRequestTypeDisplayName, supportRequestTypeSortOrder) {}
        public static readonly SupportRequestTypeHelpWithProjectUpdate Instance = new SupportRequestTypeHelpWithProjectUpdate(2, @"HelpWithProjectUpdate", @"Can't figure out how to update my project", 1);
    }

    public partial class SupportRequestTypeForgotLoginInfo : SupportRequestType
    {
        private SupportRequestTypeForgotLoginInfo(int supportRequestTypeID, string supportRequestTypeName, string supportRequestTypeDisplayName, int supportRequestTypeSortOrder) : base(supportRequestTypeID, supportRequestTypeName, supportRequestTypeDisplayName, supportRequestTypeSortOrder) {}
        public static readonly SupportRequestTypeForgotLoginInfo Instance = new SupportRequestTypeForgotLoginInfo(3, @"ForgotLoginInfo", @"Can't log in (forgot my username or password, account is locked, etc.)", 2);
    }

    public partial class SupportRequestTypeNewOrganizationOrFundingSource : SupportRequestType
    {
        private SupportRequestTypeNewOrganizationOrFundingSource(int supportRequestTypeID, string supportRequestTypeName, string supportRequestTypeDisplayName, int supportRequestTypeSortOrder) : base(supportRequestTypeID, supportRequestTypeName, supportRequestTypeDisplayName, supportRequestTypeSortOrder) {}
        public static readonly SupportRequestTypeNewOrganizationOrFundingSource Instance = new SupportRequestTypeNewOrganizationOrFundingSource(4, @"NewOrganizationOrFundingSource", @"Need an Organization or Funding Source added to the list", 4);
    }

    public partial class SupportRequestTypeProvideFeedback : SupportRequestType
    {
        private SupportRequestTypeProvideFeedback(int supportRequestTypeID, string supportRequestTypeName, string supportRequestTypeDisplayName, int supportRequestTypeSortOrder) : base(supportRequestTypeID, supportRequestTypeName, supportRequestTypeDisplayName, supportRequestTypeSortOrder) {}
        public static readonly SupportRequestTypeProvideFeedback Instance = new SupportRequestTypeProvideFeedback(5, @"ProvideFeedback", @"Provide Feedback on the site", 6);
    }

    public partial class SupportRequestTypeRequestOrganizationNameChange : SupportRequestType
    {
        private SupportRequestTypeRequestOrganizationNameChange(int supportRequestTypeID, string supportRequestTypeName, string supportRequestTypeDisplayName, int supportRequestTypeSortOrder) : base(supportRequestTypeID, supportRequestTypeName, supportRequestTypeDisplayName, supportRequestTypeSortOrder) {}
        public static readonly SupportRequestTypeRequestOrganizationNameChange Instance = new SupportRequestTypeRequestOrganizationNameChange(6, @"RequestOrganizationNameChange", @"Request a change to an Organization's name", 9);
    }

    public partial class SupportRequestTypeOther : SupportRequestType
    {
        private SupportRequestTypeOther(int supportRequestTypeID, string supportRequestTypeName, string supportRequestTypeDisplayName, int supportRequestTypeSortOrder) : base(supportRequestTypeID, supportRequestTypeName, supportRequestTypeDisplayName, supportRequestTypeSortOrder) {}
        public static readonly SupportRequestTypeOther Instance = new SupportRequestTypeOther(7, @"Other", @"Other", 100);
    }

    public partial class SupportRequestTypeRequestProjectPrimaryContactChange : SupportRequestType
    {
        private SupportRequestTypeRequestProjectPrimaryContactChange(int supportRequestTypeID, string supportRequestTypeName, string supportRequestTypeDisplayName, int supportRequestTypeSortOrder) : base(supportRequestTypeID, supportRequestTypeName, supportRequestTypeDisplayName, supportRequestTypeSortOrder) {}
        public static readonly SupportRequestTypeRequestProjectPrimaryContactChange Instance = new SupportRequestTypeRequestProjectPrimaryContactChange(8, @"RequestProjectPrimaryContactChange", @"Request a change to a Project's primary contact", 10);
    }

    public partial class SupportRequestTypeRequestPermissionToAddProjects : SupportRequestType
    {
        private SupportRequestTypeRequestPermissionToAddProjects(int supportRequestTypeID, string supportRequestTypeName, string supportRequestTypeDisplayName, int supportRequestTypeSortOrder) : base(supportRequestTypeID, supportRequestTypeName, supportRequestTypeDisplayName, supportRequestTypeSortOrder) {}
        public static readonly SupportRequestTypeRequestPermissionToAddProjects Instance = new SupportRequestTypeRequestPermissionToAddProjects(9, @"RequestPermissionToAddProjects", @"Request permission to add projects", 11);
    }
}