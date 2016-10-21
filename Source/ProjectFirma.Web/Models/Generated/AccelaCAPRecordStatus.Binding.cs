//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AccelaCAPRecordStatus]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public abstract partial class AccelaCAPRecordStatus : IHavePrimaryKey
    {
        public static readonly AccelaCAPRecordStatusAccepted Accepted = AccelaCAPRecordStatusAccepted.Instance;
        public static readonly AccelaCAPRecordStatusIssued Issued = AccelaCAPRecordStatusIssued.Instance;
        public static readonly AccelaCAPRecordStatusProjectCompleted ProjectCompleted = AccelaCAPRecordStatusProjectCompleted.Instance;
        public static readonly AccelaCAPRecordStatusReviewed Reviewed = AccelaCAPRecordStatusReviewed.Instance;
        public static readonly AccelaCAPRecordStatusWithdrawn Withdrawn = AccelaCAPRecordStatusWithdrawn.Instance;
        public static readonly AccelaCAPRecordStatusComplete Complete = AccelaCAPRecordStatusComplete.Instance;
        public static readonly AccelaCAPRecordStatusConcluded Concluded = AccelaCAPRecordStatusConcluded.Instance;
        public static readonly AccelaCAPRecordStatusWillCall WillCall = AccelaCAPRecordStatusWillCall.Instance;
        public static readonly AccelaCAPRecordStatusResultsIssued ResultsIssued = AccelaCAPRecordStatusResultsIssued.Instance;
        public static readonly AccelaCAPRecordStatusAssigned Assigned = AccelaCAPRecordStatusAssigned.Instance;
        public static readonly AccelaCAPRecordStatusIncomplete Incomplete = AccelaCAPRecordStatusIncomplete.Instance;
        public static readonly AccelaCAPRecordStatusInspectionRequired InspectionRequired = AccelaCAPRecordStatusInspectionRequired.Instance;
        public static readonly AccelaCAPRecordStatusNotes Notes = AccelaCAPRecordStatusNotes.Instance;
        public static readonly AccelaCAPRecordStatusDenied Denied = AccelaCAPRecordStatusDenied.Instance;
        public static readonly AccelaCAPRecordStatusApproved Approved = AccelaCAPRecordStatusApproved.Instance;
        public static readonly AccelaCAPRecordStatusExpired Expired = AccelaCAPRecordStatusExpired.Instance;
        public static readonly AccelaCAPRecordStatusRescinded Rescinded = AccelaCAPRecordStatusRescinded.Instance;
        public static readonly AccelaCAPRecordStatusInReview InReview = AccelaCAPRecordStatusInReview.Instance;
        public static readonly AccelaCAPRecordStatusIncompleteSubmittal IncompleteSubmittal = AccelaCAPRecordStatusIncompleteSubmittal.Instance;
        public static readonly AccelaCAPRecordStatusConditionalPermit ConditionalPermit = AccelaCAPRecordStatusConditionalPermit.Instance;
        public static readonly AccelaCAPRecordStatusHoldPerApplicant HoldPerApplicant = AccelaCAPRecordStatusHoldPerApplicant.Instance;
        public static readonly AccelaCAPRecordStatusSnowHold SnowHold = AccelaCAPRecordStatusSnowHold.Instance;
        public static readonly AccelaCAPRecordStatusLegalTolling LegalTolling = AccelaCAPRecordStatusLegalTolling.Instance;
        public static readonly AccelaCAPRecordStatusAcknowledged Acknowledged = AccelaCAPRecordStatusAcknowledged.Instance;
        public static readonly AccelaCAPRecordStatusMonitoringComplete MonitoringComplete = AccelaCAPRecordStatusMonitoringComplete.Instance;
        public static readonly AccelaCAPRecordStatusFinalInspectionComplete FinalInspectionComplete = AccelaCAPRecordStatusFinalInspectionComplete.Instance;
        public static readonly AccelaCAPRecordStatusConstructionExtension ConstructionExtension = AccelaCAPRecordStatusConstructionExtension.Instance;
        public static readonly AccelaCAPRecordStatusProjectSecurityReleased ProjectSecurityReleased = AccelaCAPRecordStatusProjectSecurityReleased.Instance;
        public static readonly AccelaCAPRecordStatusScenicSecurityReleased ScenicSecurityReleased = AccelaCAPRecordStatusScenicSecurityReleased.Instance;
        public static readonly AccelaCAPRecordStatusOtherSecurityReleased OtherSecurityReleased = AccelaCAPRecordStatusOtherSecurityReleased.Instance;
        public static readonly AccelaCAPRecordStatusAdditionalInformation AdditionalInformation = AccelaCAPRecordStatusAdditionalInformation.Instance;
        public static readonly AccelaCAPRecordStatusReviewFinished ReviewFinished = AccelaCAPRecordStatusReviewFinished.Instance;
        public static readonly AccelaCAPRecordStatusDeterminationIssued DeterminationIssued = AccelaCAPRecordStatusDeterminationIssued.Instance;
        public static readonly AccelaCAPRecordStatusOTCDeterminationIssued OTCDeterminationIssued = AccelaCAPRecordStatusOTCDeterminationIssued.Instance;
        public static readonly AccelaCAPRecordStatusTRPAReviewFinished TRPAReviewFinished = AccelaCAPRecordStatusTRPAReviewFinished.Instance;
        public static readonly AccelaCAPRecordStatusSHPOResponseReceived SHPOResponseReceived = AccelaCAPRecordStatusSHPOResponseReceived.Instance;
        public static readonly AccelaCAPRecordStatusRequestForCommentSubmitted RequestForCommentSubmitted = AccelaCAPRecordStatusRequestForCommentSubmitted.Instance;
        public static readonly AccelaCAPRecordStatusNotRequired NotRequired = AccelaCAPRecordStatusNotRequired.Instance;
        public static readonly AccelaCAPRecordStatusApplicationReceived ApplicationReceived = AccelaCAPRecordStatusApplicationReceived.Instance;
        public static readonly AccelaCAPRecordStatusReceived Received = AccelaCAPRecordStatusReceived.Instance;
        public static readonly AccelaCAPRecordStatusAcknowlefged Acknowlefged = AccelaCAPRecordStatusAcknowlefged.Instance;
        public static readonly AccelaCAPRecordStatusCertUpdated CertUpdated = AccelaCAPRecordStatusCertUpdated.Instance;
        public static readonly AccelaCAPRecordStatusCertified Certified = AccelaCAPRecordStatusCertified.Instance;
        public static readonly AccelaCAPRecordStatusClosed Closed = AccelaCAPRecordStatusClosed.Instance;
        public static readonly AccelaCAPRecordStatusDeterOpinionIssued DeterOpinionIssued = AccelaCAPRecordStatusDeterOpinionIssued.Instance;
        public static readonly AccelaCAPRecordStatusFinaled Finaled = AccelaCAPRecordStatusFinaled.Instance;
        public static readonly AccelaCAPRecordStatusGranted Granted = AccelaCAPRecordStatusGranted.Instance;
        public static readonly AccelaCAPRecordStatusInitiated Initiated = AccelaCAPRecordStatusInitiated.Instance;
        public static readonly AccelaCAPRecordStatusLossOfExemption LossOfExemption = AccelaCAPRecordStatusLossOfExemption.Instance;
        public static readonly AccelaCAPRecordStatusNegotiation Negotiation = AccelaCAPRecordStatusNegotiation.Instance;
        public static readonly AccelaCAPRecordStatusNonCompliance NonCompliance = AccelaCAPRecordStatusNonCompliance.Instance;
        public static readonly AccelaCAPRecordStatusNoticeIssued NoticeIssued = AccelaCAPRecordStatusNoticeIssued.Instance;
        public static readonly AccelaCAPRecordStatusOngoing Ongoing = AccelaCAPRecordStatusOngoing.Instance;
        public static readonly AccelaCAPRecordStatusQualified Qualified = AccelaCAPRecordStatusQualified.Instance;
        public static readonly AccelaCAPRecordStatusReferred Referred = AccelaCAPRecordStatusReferred.Instance;
        public static readonly AccelaCAPRecordStatusReferredToVRU ReferredToVRU = AccelaCAPRecordStatusReferredToVRU.Instance;
        public static readonly AccelaCAPRecordStatusRejected Rejected = AccelaCAPRecordStatusRejected.Instance;
        public static readonly AccelaCAPRecordStatusReleased Released = AccelaCAPRecordStatusReleased.Instance;
        public static readonly AccelaCAPRecordStatusResolved Resolved = AccelaCAPRecordStatusResolved.Instance;
        public static readonly AccelaCAPRecordStatusResponded Responded = AccelaCAPRecordStatusResponded.Instance;
        public static readonly AccelaCAPRecordStatusReviewedStaff ReviewedStaff = AccelaCAPRecordStatusReviewedStaff.Instance;
        public static readonly AccelaCAPRecordStatusRevised Revised = AccelaCAPRecordStatusRevised.Instance;
        public static readonly AccelaCAPRecordStatusSettlementAccepted SettlementAccepted = AccelaCAPRecordStatusSettlementAccepted.Instance;
        public static readonly AccelaCAPRecordStatusSettlementApproved SettlementApproved = AccelaCAPRecordStatusSettlementApproved.Instance;
        public static readonly AccelaCAPRecordStatusStayed Stayed = AccelaCAPRecordStatusStayed.Instance;
        public static readonly AccelaCAPRecordStatusAppealed Appealed = AccelaCAPRecordStatusAppealed.Instance;
        public static readonly AccelaCAPRecordStatusArchived Archived = AccelaCAPRecordStatusArchived.Instance;
        public static readonly AccelaCAPRecordStatusAwaitingAssignment AwaitingAssignment = AccelaCAPRecordStatusAwaitingAssignment.Instance;
        public static readonly AccelaCAPRecordStatusCertifiedAdopted CertifiedAdopted = AccelaCAPRecordStatusCertifiedAdopted.Instance;
        public static readonly AccelaCAPRecordStatusComplaintFiled ComplaintFiled = AccelaCAPRecordStatusComplaintFiled.Instance;
        public static readonly AccelaCAPRecordStatusConsulted Consulted = AccelaCAPRecordStatusConsulted.Instance;
        public static readonly AccelaCAPRecordStatusContinued Continued = AccelaCAPRecordStatusContinued.Instance;
        public static readonly AccelaCAPRecordStatusContinuing Continuing = AccelaCAPRecordStatusContinuing.Instance;
        public static readonly AccelaCAPRecordStatusDecision Decision = AccelaCAPRecordStatusDecision.Instance;
        public static readonly AccelaCAPRecordStatusDEISAdequate DEISAdequate = AccelaCAPRecordStatusDEISAdequate.Instance;
        public static readonly AccelaCAPRecordStatusDEISInRevision DEISInRevision = AccelaCAPRecordStatusDEISInRevision.Instance;
        public static readonly AccelaCAPRecordStatusDeterminationOpinionIssued DeterminationOpinionIssued = AccelaCAPRecordStatusDeterminationOpinionIssued.Instance;
        public static readonly AccelaCAPRecordStatusDone Done = AccelaCAPRecordStatusDone.Instance;
        public static readonly AccelaCAPRecordStatusDropped Dropped = AccelaCAPRecordStatusDropped.Instance;
        public static readonly AccelaCAPRecordStatusEAComplete EAComplete = AccelaCAPRecordStatusEAComplete.Instance;
        public static readonly AccelaCAPRecordStatusFederal Federal = AccelaCAPRecordStatusFederal.Instance;
        public static readonly AccelaCAPRecordStatusFinalInspection FinalInspection = AccelaCAPRecordStatusFinalInspection.Instance;
        public static readonly AccelaCAPRecordStatusFinalInspectionCompleted FinalInspectionCompleted = AccelaCAPRecordStatusFinalInspectionCompleted.Instance;
        public static readonly AccelaCAPRecordStatusHold Hold = AccelaCAPRecordStatusHold.Instance;
        public static readonly AccelaCAPRecordStatusHoldForApplicant HoldForApplicant = AccelaCAPRecordStatusHoldForApplicant.Instance;
        public static readonly AccelaCAPRecordStatusImplemented Implemented = AccelaCAPRecordStatusImplemented.Instance;
        public static readonly AccelaCAPRecordStatusInDraft InDraft = AccelaCAPRecordStatusInDraft.Instance;
        public static readonly AccelaCAPRecordStatusInspected Inspected = AccelaCAPRecordStatusInspected.Instance;
        public static readonly AccelaCAPRecordStatusInspectionInProcess InspectionInProcess = AccelaCAPRecordStatusInspectionInProcess.Instance;
        public static readonly AccelaCAPRecordStatusLitigate Litigate = AccelaCAPRecordStatusLitigate.Instance;
        public static readonly AccelaCAPRecordStatusNoResponse NoResponse = AccelaCAPRecordStatusNoResponse.Instance;
        public static readonly AccelaCAPRecordStatusNoViolation NoViolation = AccelaCAPRecordStatusNoViolation.Instance;
        public static readonly AccelaCAPRecordStatusNotQualified NotQualified = AccelaCAPRecordStatusNotQualified.Instance;
        public static readonly AccelaCAPRecordStatusNoticeSent NoticeSent = AccelaCAPRecordStatusNoticeSent.Instance;
        public static readonly AccelaCAPRecordStatusNoticed Noticed = AccelaCAPRecordStatusNoticed.Instance;
        public static readonly AccelaCAPRecordStatusOnHold OnHold = AccelaCAPRecordStatusOnHold.Instance;
        public static readonly AccelaCAPRecordStatusPassedEval PassedEval = AccelaCAPRecordStatusPassedEval.Instance;
        public static readonly AccelaCAPRecordStatusPermitFinaled PermitFinaled = AccelaCAPRecordStatusPermitFinaled.Instance;
        public static readonly AccelaCAPRecordStatusPermitRequired PermitRequired = AccelaCAPRecordStatusPermitRequired.Instance;
        public static readonly AccelaCAPRecordStatusPermitted Permitted = AccelaCAPRecordStatusPermitted.Instance;
        public static readonly AccelaCAPRecordStatusPlannerReviewFinished PlannerReviewFinished = AccelaCAPRecordStatusPlannerReviewFinished.Instance;
        public static readonly AccelaCAPRecordStatusReferredToERS ReferredToERS = AccelaCAPRecordStatusReferredToERS.Instance;
        public static readonly AccelaCAPRecordStatusReferredToMOU ReferredToMOU = AccelaCAPRecordStatusReferredToMOU.Instance;
        public static readonly AccelaCAPRecordStatusResolutionSettlement ResolutionSettlement = AccelaCAPRecordStatusResolutionSettlement.Instance;
        public static readonly AccelaCAPRecordStatusReviewedStaffWithComma ReviewedStaffWithComma = AccelaCAPRecordStatusReviewedStaffWithComma.Instance;
        public static readonly AccelaCAPRecordStatusRevisedAccepted RevisedAccepted = AccelaCAPRecordStatusRevisedAccepted.Instance;
        public static readonly AccelaCAPRecordStatusScopeCirculated ScopeCirculated = AccelaCAPRecordStatusScopeCirculated.Instance;
        public static readonly AccelaCAPRecordStatusScoped Scoped = AccelaCAPRecordStatusScoped.Instance;
        public static readonly AccelaCAPRecordStatusSettlementDeclined SettlementDeclined = AccelaCAPRecordStatusSettlementDeclined.Instance;
        public static readonly AccelaCAPRecordStatusUnderReview UnderReview = AccelaCAPRecordStatusUnderReview.Instance;
        public static readonly AccelaCAPRecordStatusUnpaidFees UnpaidFees = AccelaCAPRecordStatusUnpaidFees.Instance;
        public static readonly AccelaCAPRecordStatusViolation Violation = AccelaCAPRecordStatusViolation.Instance;
        public static readonly AccelaCAPRecordStatusVoid Void = AccelaCAPRecordStatusVoid.Instance;

        public static readonly List<AccelaCAPRecordStatus> All;
        public static readonly ReadOnlyDictionary<int, AccelaCAPRecordStatus> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static AccelaCAPRecordStatus()
        {
            All = new List<AccelaCAPRecordStatus> { Accepted, Issued, ProjectCompleted, Reviewed, Withdrawn, Complete, Concluded, WillCall, ResultsIssued, Assigned, Incomplete, InspectionRequired, Notes, Denied, Approved, Expired, Rescinded, InReview, IncompleteSubmittal, ConditionalPermit, HoldPerApplicant, SnowHold, LegalTolling, Acknowledged, MonitoringComplete, FinalInspectionComplete, ConstructionExtension, ProjectSecurityReleased, ScenicSecurityReleased, OtherSecurityReleased, AdditionalInformation, ReviewFinished, DeterminationIssued, OTCDeterminationIssued, TRPAReviewFinished, SHPOResponseReceived, RequestForCommentSubmitted, NotRequired, ApplicationReceived, Received, Acknowlefged, CertUpdated, Certified, Closed, DeterOpinionIssued, Finaled, Granted, Initiated, LossOfExemption, Negotiation, NonCompliance, NoticeIssued, Ongoing, Qualified, Referred, ReferredToVRU, Rejected, Released, Resolved, Responded, ReviewedStaff, Revised, SettlementAccepted, SettlementApproved, Stayed, Appealed, Archived, AwaitingAssignment, CertifiedAdopted, ComplaintFiled, Consulted, Continued, Continuing, Decision, DEISAdequate, DEISInRevision, DeterminationOpinionIssued, Done, Dropped, EAComplete, Federal, FinalInspection, FinalInspectionCompleted, Hold, HoldForApplicant, Implemented, InDraft, Inspected, InspectionInProcess, Litigate, NoResponse, NoViolation, NotQualified, NoticeSent, Noticed, OnHold, PassedEval, PermitFinaled, PermitRequired, Permitted, PlannerReviewFinished, ReferredToERS, ReferredToMOU, ResolutionSettlement, ReviewedStaffWithComma, RevisedAccepted, ScopeCirculated, Scoped, SettlementDeclined, UnderReview, UnpaidFees, Violation, Void };
            AllLookupDictionary = new ReadOnlyDictionary<int, AccelaCAPRecordStatus>(All.ToDictionary(x => x.AccelaCAPRecordStatusID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected AccelaCAPRecordStatus(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName)
        {
            AccelaCAPRecordStatusID = accelaCAPRecordStatusID;
            AccelaCAPRecordStatusName = accelaCAPRecordStatusName;
            AccelaCAPRecordStatusDisplayName = accelaCAPRecordStatusDisplayName;
        }

        [Key]
        public int AccelaCAPRecordStatusID { get; private set; }
        public string AccelaCAPRecordStatusName { get; private set; }
        public string AccelaCAPRecordStatusDisplayName { get; private set; }
        public int PrimaryKey { get { return AccelaCAPRecordStatusID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(AccelaCAPRecordStatus other)
        {
            if (other == null)
            {
                return false;
            }
            return other.AccelaCAPRecordStatusID == AccelaCAPRecordStatusID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as AccelaCAPRecordStatus);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return AccelaCAPRecordStatusID;
        }

        public static bool operator ==(AccelaCAPRecordStatus left, AccelaCAPRecordStatus right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AccelaCAPRecordStatus left, AccelaCAPRecordStatus right)
        {
            return !Equals(left, right);
        }

        public AccelaCAPRecordStatusEnum ToEnum { get { return (AccelaCAPRecordStatusEnum)GetHashCode(); } }

        public static AccelaCAPRecordStatus ToType(int enumValue)
        {
            return ToType((AccelaCAPRecordStatusEnum)enumValue);
        }

        public static AccelaCAPRecordStatus ToType(AccelaCAPRecordStatusEnum enumValue)
        {
            switch (enumValue)
            {
                case AccelaCAPRecordStatusEnum.Accepted:
                    return Accepted;
                case AccelaCAPRecordStatusEnum.Acknowledged:
                    return Acknowledged;
                case AccelaCAPRecordStatusEnum.Acknowlefged:
                    return Acknowlefged;
                case AccelaCAPRecordStatusEnum.AdditionalInformation:
                    return AdditionalInformation;
                case AccelaCAPRecordStatusEnum.Appealed:
                    return Appealed;
                case AccelaCAPRecordStatusEnum.ApplicationReceived:
                    return ApplicationReceived;
                case AccelaCAPRecordStatusEnum.Approved:
                    return Approved;
                case AccelaCAPRecordStatusEnum.Archived:
                    return Archived;
                case AccelaCAPRecordStatusEnum.Assigned:
                    return Assigned;
                case AccelaCAPRecordStatusEnum.AwaitingAssignment:
                    return AwaitingAssignment;
                case AccelaCAPRecordStatusEnum.Certified:
                    return Certified;
                case AccelaCAPRecordStatusEnum.CertifiedAdopted:
                    return CertifiedAdopted;
                case AccelaCAPRecordStatusEnum.CertUpdated:
                    return CertUpdated;
                case AccelaCAPRecordStatusEnum.Closed:
                    return Closed;
                case AccelaCAPRecordStatusEnum.ComplaintFiled:
                    return ComplaintFiled;
                case AccelaCAPRecordStatusEnum.Complete:
                    return Complete;
                case AccelaCAPRecordStatusEnum.Concluded:
                    return Concluded;
                case AccelaCAPRecordStatusEnum.ConditionalPermit:
                    return ConditionalPermit;
                case AccelaCAPRecordStatusEnum.ConstructionExtension:
                    return ConstructionExtension;
                case AccelaCAPRecordStatusEnum.Consulted:
                    return Consulted;
                case AccelaCAPRecordStatusEnum.Continued:
                    return Continued;
                case AccelaCAPRecordStatusEnum.Continuing:
                    return Continuing;
                case AccelaCAPRecordStatusEnum.Decision:
                    return Decision;
                case AccelaCAPRecordStatusEnum.DEISAdequate:
                    return DEISAdequate;
                case AccelaCAPRecordStatusEnum.DEISInRevision:
                    return DEISInRevision;
                case AccelaCAPRecordStatusEnum.Denied:
                    return Denied;
                case AccelaCAPRecordStatusEnum.DeterminationIssued:
                    return DeterminationIssued;
                case AccelaCAPRecordStatusEnum.DeterminationOpinionIssued:
                    return DeterminationOpinionIssued;
                case AccelaCAPRecordStatusEnum.DeterOpinionIssued:
                    return DeterOpinionIssued;
                case AccelaCAPRecordStatusEnum.Done:
                    return Done;
                case AccelaCAPRecordStatusEnum.Dropped:
                    return Dropped;
                case AccelaCAPRecordStatusEnum.EAComplete:
                    return EAComplete;
                case AccelaCAPRecordStatusEnum.Expired:
                    return Expired;
                case AccelaCAPRecordStatusEnum.Federal:
                    return Federal;
                case AccelaCAPRecordStatusEnum.Finaled:
                    return Finaled;
                case AccelaCAPRecordStatusEnum.FinalInspection:
                    return FinalInspection;
                case AccelaCAPRecordStatusEnum.FinalInspectionComplete:
                    return FinalInspectionComplete;
                case AccelaCAPRecordStatusEnum.FinalInspectionCompleted:
                    return FinalInspectionCompleted;
                case AccelaCAPRecordStatusEnum.Granted:
                    return Granted;
                case AccelaCAPRecordStatusEnum.Hold:
                    return Hold;
                case AccelaCAPRecordStatusEnum.HoldForApplicant:
                    return HoldForApplicant;
                case AccelaCAPRecordStatusEnum.HoldPerApplicant:
                    return HoldPerApplicant;
                case AccelaCAPRecordStatusEnum.Implemented:
                    return Implemented;
                case AccelaCAPRecordStatusEnum.Incomplete:
                    return Incomplete;
                case AccelaCAPRecordStatusEnum.IncompleteSubmittal:
                    return IncompleteSubmittal;
                case AccelaCAPRecordStatusEnum.InDraft:
                    return InDraft;
                case AccelaCAPRecordStatusEnum.Initiated:
                    return Initiated;
                case AccelaCAPRecordStatusEnum.InReview:
                    return InReview;
                case AccelaCAPRecordStatusEnum.Inspected:
                    return Inspected;
                case AccelaCAPRecordStatusEnum.InspectionInProcess:
                    return InspectionInProcess;
                case AccelaCAPRecordStatusEnum.InspectionRequired:
                    return InspectionRequired;
                case AccelaCAPRecordStatusEnum.Issued:
                    return Issued;
                case AccelaCAPRecordStatusEnum.LegalTolling:
                    return LegalTolling;
                case AccelaCAPRecordStatusEnum.Litigate:
                    return Litigate;
                case AccelaCAPRecordStatusEnum.LossOfExemption:
                    return LossOfExemption;
                case AccelaCAPRecordStatusEnum.MonitoringComplete:
                    return MonitoringComplete;
                case AccelaCAPRecordStatusEnum.Negotiation:
                    return Negotiation;
                case AccelaCAPRecordStatusEnum.NonCompliance:
                    return NonCompliance;
                case AccelaCAPRecordStatusEnum.NoResponse:
                    return NoResponse;
                case AccelaCAPRecordStatusEnum.Notes:
                    return Notes;
                case AccelaCAPRecordStatusEnum.Noticed:
                    return Noticed;
                case AccelaCAPRecordStatusEnum.NoticeIssued:
                    return NoticeIssued;
                case AccelaCAPRecordStatusEnum.NoticeSent:
                    return NoticeSent;
                case AccelaCAPRecordStatusEnum.NotQualified:
                    return NotQualified;
                case AccelaCAPRecordStatusEnum.NotRequired:
                    return NotRequired;
                case AccelaCAPRecordStatusEnum.NoViolation:
                    return NoViolation;
                case AccelaCAPRecordStatusEnum.Ongoing:
                    return Ongoing;
                case AccelaCAPRecordStatusEnum.OnHold:
                    return OnHold;
                case AccelaCAPRecordStatusEnum.OTCDeterminationIssued:
                    return OTCDeterminationIssued;
                case AccelaCAPRecordStatusEnum.OtherSecurityReleased:
                    return OtherSecurityReleased;
                case AccelaCAPRecordStatusEnum.PassedEval:
                    return PassedEval;
                case AccelaCAPRecordStatusEnum.PermitFinaled:
                    return PermitFinaled;
                case AccelaCAPRecordStatusEnum.PermitRequired:
                    return PermitRequired;
                case AccelaCAPRecordStatusEnum.Permitted:
                    return Permitted;
                case AccelaCAPRecordStatusEnum.PlannerReviewFinished:
                    return PlannerReviewFinished;
                case AccelaCAPRecordStatusEnum.ProjectCompleted:
                    return ProjectCompleted;
                case AccelaCAPRecordStatusEnum.ProjectSecurityReleased:
                    return ProjectSecurityReleased;
                case AccelaCAPRecordStatusEnum.Qualified:
                    return Qualified;
                case AccelaCAPRecordStatusEnum.Received:
                    return Received;
                case AccelaCAPRecordStatusEnum.Referred:
                    return Referred;
                case AccelaCAPRecordStatusEnum.ReferredToERS:
                    return ReferredToERS;
                case AccelaCAPRecordStatusEnum.ReferredToMOU:
                    return ReferredToMOU;
                case AccelaCAPRecordStatusEnum.ReferredToVRU:
                    return ReferredToVRU;
                case AccelaCAPRecordStatusEnum.Rejected:
                    return Rejected;
                case AccelaCAPRecordStatusEnum.Released:
                    return Released;
                case AccelaCAPRecordStatusEnum.RequestForCommentSubmitted:
                    return RequestForCommentSubmitted;
                case AccelaCAPRecordStatusEnum.Rescinded:
                    return Rescinded;
                case AccelaCAPRecordStatusEnum.ResolutionSettlement:
                    return ResolutionSettlement;
                case AccelaCAPRecordStatusEnum.Resolved:
                    return Resolved;
                case AccelaCAPRecordStatusEnum.Responded:
                    return Responded;
                case AccelaCAPRecordStatusEnum.ResultsIssued:
                    return ResultsIssued;
                case AccelaCAPRecordStatusEnum.Reviewed:
                    return Reviewed;
                case AccelaCAPRecordStatusEnum.ReviewedStaff:
                    return ReviewedStaff;
                case AccelaCAPRecordStatusEnum.ReviewedStaffWithComma:
                    return ReviewedStaffWithComma;
                case AccelaCAPRecordStatusEnum.ReviewFinished:
                    return ReviewFinished;
                case AccelaCAPRecordStatusEnum.Revised:
                    return Revised;
                case AccelaCAPRecordStatusEnum.RevisedAccepted:
                    return RevisedAccepted;
                case AccelaCAPRecordStatusEnum.ScenicSecurityReleased:
                    return ScenicSecurityReleased;
                case AccelaCAPRecordStatusEnum.ScopeCirculated:
                    return ScopeCirculated;
                case AccelaCAPRecordStatusEnum.Scoped:
                    return Scoped;
                case AccelaCAPRecordStatusEnum.SettlementAccepted:
                    return SettlementAccepted;
                case AccelaCAPRecordStatusEnum.SettlementApproved:
                    return SettlementApproved;
                case AccelaCAPRecordStatusEnum.SettlementDeclined:
                    return SettlementDeclined;
                case AccelaCAPRecordStatusEnum.SHPOResponseReceived:
                    return SHPOResponseReceived;
                case AccelaCAPRecordStatusEnum.SnowHold:
                    return SnowHold;
                case AccelaCAPRecordStatusEnum.Stayed:
                    return Stayed;
                case AccelaCAPRecordStatusEnum.TRPAReviewFinished:
                    return TRPAReviewFinished;
                case AccelaCAPRecordStatusEnum.UnderReview:
                    return UnderReview;
                case AccelaCAPRecordStatusEnum.UnpaidFees:
                    return UnpaidFees;
                case AccelaCAPRecordStatusEnum.Violation:
                    return Violation;
                case AccelaCAPRecordStatusEnum.Void:
                    return Void;
                case AccelaCAPRecordStatusEnum.WillCall:
                    return WillCall;
                case AccelaCAPRecordStatusEnum.Withdrawn:
                    return Withdrawn;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum AccelaCAPRecordStatusEnum
    {
        Accepted = 1,
        Issued = 2,
        ProjectCompleted = 3,
        Reviewed = 4,
        Withdrawn = 5,
        Complete = 6,
        Concluded = 7,
        WillCall = 8,
        ResultsIssued = 9,
        Assigned = 10,
        Incomplete = 11,
        InspectionRequired = 12,
        Notes = 13,
        Denied = 14,
        Approved = 15,
        Expired = 16,
        Rescinded = 17,
        InReview = 18,
        IncompleteSubmittal = 19,
        ConditionalPermit = 20,
        HoldPerApplicant = 21,
        SnowHold = 22,
        LegalTolling = 23,
        Acknowledged = 24,
        MonitoringComplete = 25,
        FinalInspectionComplete = 26,
        ConstructionExtension = 27,
        ProjectSecurityReleased = 28,
        ScenicSecurityReleased = 29,
        OtherSecurityReleased = 30,
        AdditionalInformation = 31,
        ReviewFinished = 32,
        DeterminationIssued = 33,
        OTCDeterminationIssued = 34,
        TRPAReviewFinished = 35,
        SHPOResponseReceived = 36,
        RequestForCommentSubmitted = 37,
        NotRequired = 38,
        ApplicationReceived = 39,
        Received = 40,
        Acknowlefged = 41,
        CertUpdated = 42,
        Certified = 43,
        Closed = 44,
        DeterOpinionIssued = 45,
        Finaled = 46,
        Granted = 47,
        Initiated = 48,
        LossOfExemption = 49,
        Negotiation = 50,
        NonCompliance = 51,
        NoticeIssued = 52,
        Ongoing = 53,
        Qualified = 54,
        Referred = 55,
        ReferredToVRU = 56,
        Rejected = 57,
        Released = 58,
        Resolved = 59,
        Responded = 60,
        ReviewedStaff = 61,
        Revised = 62,
        SettlementAccepted = 63,
        SettlementApproved = 64,
        Stayed = 65,
        Appealed = 66,
        Archived = 67,
        AwaitingAssignment = 68,
        CertifiedAdopted = 69,
        ComplaintFiled = 70,
        Consulted = 71,
        Continued = 72,
        Continuing = 73,
        Decision = 74,
        DEISAdequate = 75,
        DEISInRevision = 76,
        DeterminationOpinionIssued = 77,
        Done = 78,
        Dropped = 79,
        EAComplete = 80,
        Federal = 81,
        FinalInspection = 82,
        FinalInspectionCompleted = 83,
        Hold = 84,
        HoldForApplicant = 85,
        Implemented = 86,
        InDraft = 87,
        Inspected = 88,
        InspectionInProcess = 89,
        Litigate = 90,
        NoResponse = 91,
        NoViolation = 92,
        NotQualified = 93,
        NoticeSent = 94,
        Noticed = 95,
        OnHold = 96,
        PassedEval = 97,
        PermitFinaled = 98,
        PermitRequired = 99,
        Permitted = 100,
        PlannerReviewFinished = 101,
        ReferredToERS = 102,
        ReferredToMOU = 103,
        ResolutionSettlement = 104,
        ReviewedStaffWithComma = 105,
        RevisedAccepted = 106,
        ScopeCirculated = 107,
        Scoped = 108,
        SettlementDeclined = 109,
        UnderReview = 110,
        UnpaidFees = 111,
        Violation = 112,
        Void = 113
    }

    public partial class AccelaCAPRecordStatusAccepted : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusAccepted(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusAccepted Instance = new AccelaCAPRecordStatusAccepted(1, @"Accepted", @"Accepted");
    }

    public partial class AccelaCAPRecordStatusIssued : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusIssued(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusIssued Instance = new AccelaCAPRecordStatusIssued(2, @"Issued", @"Issued");
    }

    public partial class AccelaCAPRecordStatusProjectCompleted : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusProjectCompleted(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusProjectCompleted Instance = new AccelaCAPRecordStatusProjectCompleted(3, @"ProjectCompleted", @"Project Completed");
    }

    public partial class AccelaCAPRecordStatusReviewed : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusReviewed(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusReviewed Instance = new AccelaCAPRecordStatusReviewed(4, @"Reviewed", @"Reviewed");
    }

    public partial class AccelaCAPRecordStatusWithdrawn : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusWithdrawn(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusWithdrawn Instance = new AccelaCAPRecordStatusWithdrawn(5, @"Withdrawn", @"Withdrawn");
    }

    public partial class AccelaCAPRecordStatusComplete : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusComplete(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusComplete Instance = new AccelaCAPRecordStatusComplete(6, @"Complete", @"Complete");
    }

    public partial class AccelaCAPRecordStatusConcluded : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusConcluded(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusConcluded Instance = new AccelaCAPRecordStatusConcluded(7, @"Concluded", @"Concluded");
    }

    public partial class AccelaCAPRecordStatusWillCall : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusWillCall(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusWillCall Instance = new AccelaCAPRecordStatusWillCall(8, @"WillCall", @"Will Call");
    }

    public partial class AccelaCAPRecordStatusResultsIssued : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusResultsIssued(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusResultsIssued Instance = new AccelaCAPRecordStatusResultsIssued(9, @"ResultsIssued", @"Results Issued");
    }

    public partial class AccelaCAPRecordStatusAssigned : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusAssigned(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusAssigned Instance = new AccelaCAPRecordStatusAssigned(10, @"Assigned", @"Assigned");
    }

    public partial class AccelaCAPRecordStatusIncomplete : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusIncomplete(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusIncomplete Instance = new AccelaCAPRecordStatusIncomplete(11, @"Incomplete", @"Incomplete");
    }

    public partial class AccelaCAPRecordStatusInspectionRequired : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusInspectionRequired(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusInspectionRequired Instance = new AccelaCAPRecordStatusInspectionRequired(12, @"InspectionRequired", @"Inspection Required");
    }

    public partial class AccelaCAPRecordStatusNotes : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusNotes(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusNotes Instance = new AccelaCAPRecordStatusNotes(13, @"Notes", @"Notes");
    }

    public partial class AccelaCAPRecordStatusDenied : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusDenied(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusDenied Instance = new AccelaCAPRecordStatusDenied(14, @"Denied", @"Denied");
    }

    public partial class AccelaCAPRecordStatusApproved : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusApproved(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusApproved Instance = new AccelaCAPRecordStatusApproved(15, @"Approved", @"Approved");
    }

    public partial class AccelaCAPRecordStatusExpired : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusExpired(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusExpired Instance = new AccelaCAPRecordStatusExpired(16, @"Expired", @"Expired");
    }

    public partial class AccelaCAPRecordStatusRescinded : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusRescinded(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusRescinded Instance = new AccelaCAPRecordStatusRescinded(17, @"Rescinded", @"Rescinded");
    }

    public partial class AccelaCAPRecordStatusInReview : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusInReview(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusInReview Instance = new AccelaCAPRecordStatusInReview(18, @"InReview", @"In Review");
    }

    public partial class AccelaCAPRecordStatusIncompleteSubmittal : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusIncompleteSubmittal(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusIncompleteSubmittal Instance = new AccelaCAPRecordStatusIncompleteSubmittal(19, @"IncompleteSubmittal", @"Incomplete Submittal");
    }

    public partial class AccelaCAPRecordStatusConditionalPermit : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusConditionalPermit(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusConditionalPermit Instance = new AccelaCAPRecordStatusConditionalPermit(20, @"ConditionalPermit", @"Conditional Permit");
    }

    public partial class AccelaCAPRecordStatusHoldPerApplicant : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusHoldPerApplicant(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusHoldPerApplicant Instance = new AccelaCAPRecordStatusHoldPerApplicant(21, @"HoldPerApplicant", @"Hold Per Applicant");
    }

    public partial class AccelaCAPRecordStatusSnowHold : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusSnowHold(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusSnowHold Instance = new AccelaCAPRecordStatusSnowHold(22, @"SnowHold", @"Snow Hold");
    }

    public partial class AccelaCAPRecordStatusLegalTolling : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusLegalTolling(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusLegalTolling Instance = new AccelaCAPRecordStatusLegalTolling(23, @"LegalTolling", @"Legal Tolling");
    }

    public partial class AccelaCAPRecordStatusAcknowledged : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusAcknowledged(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusAcknowledged Instance = new AccelaCAPRecordStatusAcknowledged(24, @"Acknowledged", @"Acknowledged");
    }

    public partial class AccelaCAPRecordStatusMonitoringComplete : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusMonitoringComplete(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusMonitoringComplete Instance = new AccelaCAPRecordStatusMonitoringComplete(25, @"MonitoringComplete", @"Monitoring Complete");
    }

    public partial class AccelaCAPRecordStatusFinalInspectionComplete : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusFinalInspectionComplete(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusFinalInspectionComplete Instance = new AccelaCAPRecordStatusFinalInspectionComplete(26, @"FinalInspectionComplete", @"Final Inspection Complete");
    }

    public partial class AccelaCAPRecordStatusConstructionExtension : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusConstructionExtension(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusConstructionExtension Instance = new AccelaCAPRecordStatusConstructionExtension(27, @"ConstructionExtension", @"Construction Extension");
    }

    public partial class AccelaCAPRecordStatusProjectSecurityReleased : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusProjectSecurityReleased(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusProjectSecurityReleased Instance = new AccelaCAPRecordStatusProjectSecurityReleased(28, @"ProjectSecurityReleased", @"Project Security Released");
    }

    public partial class AccelaCAPRecordStatusScenicSecurityReleased : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusScenicSecurityReleased(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusScenicSecurityReleased Instance = new AccelaCAPRecordStatusScenicSecurityReleased(29, @"ScenicSecurityReleased", @"Scenic Security Released");
    }

    public partial class AccelaCAPRecordStatusOtherSecurityReleased : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusOtherSecurityReleased(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusOtherSecurityReleased Instance = new AccelaCAPRecordStatusOtherSecurityReleased(30, @"OtherSecurityReleased", @"Other Security Released");
    }

    public partial class AccelaCAPRecordStatusAdditionalInformation : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusAdditionalInformation(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusAdditionalInformation Instance = new AccelaCAPRecordStatusAdditionalInformation(31, @"AdditionalInformation", @"Additional Information");
    }

    public partial class AccelaCAPRecordStatusReviewFinished : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusReviewFinished(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusReviewFinished Instance = new AccelaCAPRecordStatusReviewFinished(32, @"ReviewFinished", @"Review Finished");
    }

    public partial class AccelaCAPRecordStatusDeterminationIssued : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusDeterminationIssued(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusDeterminationIssued Instance = new AccelaCAPRecordStatusDeterminationIssued(33, @"DeterminationIssued", @"Determination Issued");
    }

    public partial class AccelaCAPRecordStatusOTCDeterminationIssued : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusOTCDeterminationIssued(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusOTCDeterminationIssued Instance = new AccelaCAPRecordStatusOTCDeterminationIssued(34, @"OTCDeterminationIssued", @"OTC Determination Issued");
    }

    public partial class AccelaCAPRecordStatusTRPAReviewFinished : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusTRPAReviewFinished(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusTRPAReviewFinished Instance = new AccelaCAPRecordStatusTRPAReviewFinished(35, @"TRPAReviewFinished", @"TRPA Review Finished");
    }

    public partial class AccelaCAPRecordStatusSHPOResponseReceived : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusSHPOResponseReceived(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusSHPOResponseReceived Instance = new AccelaCAPRecordStatusSHPOResponseReceived(36, @"SHPOResponseReceived", @"SHPO Response Received");
    }

    public partial class AccelaCAPRecordStatusRequestForCommentSubmitted : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusRequestForCommentSubmitted(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusRequestForCommentSubmitted Instance = new AccelaCAPRecordStatusRequestForCommentSubmitted(37, @"RequestForCommentSubmitted", @"Request for Comment Submitted");
    }

    public partial class AccelaCAPRecordStatusNotRequired : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusNotRequired(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusNotRequired Instance = new AccelaCAPRecordStatusNotRequired(38, @"NotRequired", @"Not Required");
    }

    public partial class AccelaCAPRecordStatusApplicationReceived : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusApplicationReceived(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusApplicationReceived Instance = new AccelaCAPRecordStatusApplicationReceived(39, @"ApplicationReceived", @"Application Received");
    }

    public partial class AccelaCAPRecordStatusReceived : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusReceived(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusReceived Instance = new AccelaCAPRecordStatusReceived(40, @"Received", @"Received");
    }

    public partial class AccelaCAPRecordStatusAcknowlefged : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusAcknowlefged(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusAcknowlefged Instance = new AccelaCAPRecordStatusAcknowlefged(41, @"Acknowlefged", @"Acknowlefged");
    }

    public partial class AccelaCAPRecordStatusCertUpdated : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusCertUpdated(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusCertUpdated Instance = new AccelaCAPRecordStatusCertUpdated(42, @"CertUpdated", @"Cert Updated");
    }

    public partial class AccelaCAPRecordStatusCertified : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusCertified(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusCertified Instance = new AccelaCAPRecordStatusCertified(43, @"Certified", @"Certified");
    }

    public partial class AccelaCAPRecordStatusClosed : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusClosed(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusClosed Instance = new AccelaCAPRecordStatusClosed(44, @"Closed", @"Closed");
    }

    public partial class AccelaCAPRecordStatusDeterOpinionIssued : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusDeterOpinionIssued(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusDeterOpinionIssued Instance = new AccelaCAPRecordStatusDeterOpinionIssued(45, @"DeterOpinionIssued", @"Deter/Opinion Issued");
    }

    public partial class AccelaCAPRecordStatusFinaled : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusFinaled(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusFinaled Instance = new AccelaCAPRecordStatusFinaled(46, @"Finaled", @"Finaled");
    }

    public partial class AccelaCAPRecordStatusGranted : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusGranted(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusGranted Instance = new AccelaCAPRecordStatusGranted(47, @"Granted", @"Granted");
    }

    public partial class AccelaCAPRecordStatusInitiated : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusInitiated(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusInitiated Instance = new AccelaCAPRecordStatusInitiated(48, @"Initiated", @"Initiated");
    }

    public partial class AccelaCAPRecordStatusLossOfExemption : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusLossOfExemption(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusLossOfExemption Instance = new AccelaCAPRecordStatusLossOfExemption(49, @"LossOfExemption", @"Loss of Exemption");
    }

    public partial class AccelaCAPRecordStatusNegotiation : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusNegotiation(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusNegotiation Instance = new AccelaCAPRecordStatusNegotiation(50, @"Negotiation", @"Negotiation");
    }

    public partial class AccelaCAPRecordStatusNonCompliance : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusNonCompliance(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusNonCompliance Instance = new AccelaCAPRecordStatusNonCompliance(51, @"NonCompliance", @"Non-Compliance");
    }

    public partial class AccelaCAPRecordStatusNoticeIssued : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusNoticeIssued(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusNoticeIssued Instance = new AccelaCAPRecordStatusNoticeIssued(52, @"NoticeIssued", @"Notice Issued");
    }

    public partial class AccelaCAPRecordStatusOngoing : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusOngoing(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusOngoing Instance = new AccelaCAPRecordStatusOngoing(53, @"Ongoing", @"Ongoing");
    }

    public partial class AccelaCAPRecordStatusQualified : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusQualified(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusQualified Instance = new AccelaCAPRecordStatusQualified(54, @"Qualified", @"Qualified");
    }

    public partial class AccelaCAPRecordStatusReferred : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusReferred(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusReferred Instance = new AccelaCAPRecordStatusReferred(55, @"Referred", @"Referred");
    }

    public partial class AccelaCAPRecordStatusReferredToVRU : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusReferredToVRU(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusReferredToVRU Instance = new AccelaCAPRecordStatusReferredToVRU(56, @"ReferredToVRU", @"Referred to VRU");
    }

    public partial class AccelaCAPRecordStatusRejected : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusRejected(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusRejected Instance = new AccelaCAPRecordStatusRejected(57, @"Rejected", @"Rejected");
    }

    public partial class AccelaCAPRecordStatusReleased : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusReleased(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusReleased Instance = new AccelaCAPRecordStatusReleased(58, @"Released", @"Released");
    }

    public partial class AccelaCAPRecordStatusResolved : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusResolved(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusResolved Instance = new AccelaCAPRecordStatusResolved(59, @"Resolved", @"Resolved");
    }

    public partial class AccelaCAPRecordStatusResponded : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusResponded(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusResponded Instance = new AccelaCAPRecordStatusResponded(60, @"Responded", @"Responded");
    }

    public partial class AccelaCAPRecordStatusReviewedStaff : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusReviewedStaff(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusReviewedStaff Instance = new AccelaCAPRecordStatusReviewedStaff(61, @"ReviewedStaff", @"Reviewed-Staff");
    }

    public partial class AccelaCAPRecordStatusRevised : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusRevised(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusRevised Instance = new AccelaCAPRecordStatusRevised(62, @"Revised", @"Revised");
    }

    public partial class AccelaCAPRecordStatusSettlementAccepted : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusSettlementAccepted(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusSettlementAccepted Instance = new AccelaCAPRecordStatusSettlementAccepted(63, @"SettlementAccepted", @"Settlement Accepted");
    }

    public partial class AccelaCAPRecordStatusSettlementApproved : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusSettlementApproved(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusSettlementApproved Instance = new AccelaCAPRecordStatusSettlementApproved(64, @"SettlementApproved", @"Settlement Approved");
    }

    public partial class AccelaCAPRecordStatusStayed : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusStayed(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusStayed Instance = new AccelaCAPRecordStatusStayed(65, @"Stayed", @"Stayed");
    }

    public partial class AccelaCAPRecordStatusAppealed : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusAppealed(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusAppealed Instance = new AccelaCAPRecordStatusAppealed(66, @"Appealed", @"Appealed");
    }

    public partial class AccelaCAPRecordStatusArchived : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusArchived(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusArchived Instance = new AccelaCAPRecordStatusArchived(67, @"Archived", @"Archived");
    }

    public partial class AccelaCAPRecordStatusAwaitingAssignment : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusAwaitingAssignment(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusAwaitingAssignment Instance = new AccelaCAPRecordStatusAwaitingAssignment(68, @"AwaitingAssignment", @"Awaiting Assignment");
    }

    public partial class AccelaCAPRecordStatusCertifiedAdopted : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusCertifiedAdopted(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusCertifiedAdopted Instance = new AccelaCAPRecordStatusCertifiedAdopted(69, @"CertifiedAdopted", @"Certified/Adopted");
    }

    public partial class AccelaCAPRecordStatusComplaintFiled : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusComplaintFiled(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusComplaintFiled Instance = new AccelaCAPRecordStatusComplaintFiled(70, @"ComplaintFiled", @"Complaint Filed");
    }

    public partial class AccelaCAPRecordStatusConsulted : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusConsulted(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusConsulted Instance = new AccelaCAPRecordStatusConsulted(71, @"Consulted", @"Consulted");
    }

    public partial class AccelaCAPRecordStatusContinued : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusContinued(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusContinued Instance = new AccelaCAPRecordStatusContinued(72, @"Continued", @"Continued");
    }

    public partial class AccelaCAPRecordStatusContinuing : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusContinuing(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusContinuing Instance = new AccelaCAPRecordStatusContinuing(73, @"Continuing", @"Continuing");
    }

    public partial class AccelaCAPRecordStatusDecision : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusDecision(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusDecision Instance = new AccelaCAPRecordStatusDecision(74, @"Decision", @"Decision");
    }

    public partial class AccelaCAPRecordStatusDEISAdequate : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusDEISAdequate(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusDEISAdequate Instance = new AccelaCAPRecordStatusDEISAdequate(75, @"DEISAdequate", @"DEIS Adequate");
    }

    public partial class AccelaCAPRecordStatusDEISInRevision : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusDEISInRevision(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusDEISInRevision Instance = new AccelaCAPRecordStatusDEISInRevision(76, @"DEISInRevision", @"DEIS in Revision");
    }

    public partial class AccelaCAPRecordStatusDeterminationOpinionIssued : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusDeterminationOpinionIssued(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusDeterminationOpinionIssued Instance = new AccelaCAPRecordStatusDeterminationOpinionIssued(77, @"DeterminationOpinionIssued", @"Determination/Opinion Issued");
    }

    public partial class AccelaCAPRecordStatusDone : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusDone(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusDone Instance = new AccelaCAPRecordStatusDone(78, @"Done", @"Done");
    }

    public partial class AccelaCAPRecordStatusDropped : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusDropped(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusDropped Instance = new AccelaCAPRecordStatusDropped(79, @"Dropped", @"Dropped");
    }

    public partial class AccelaCAPRecordStatusEAComplete : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusEAComplete(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusEAComplete Instance = new AccelaCAPRecordStatusEAComplete(80, @"EAComplete", @"EA Complete");
    }

    public partial class AccelaCAPRecordStatusFederal : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusFederal(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusFederal Instance = new AccelaCAPRecordStatusFederal(81, @"Federal", @"Federal");
    }

    public partial class AccelaCAPRecordStatusFinalInspection : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusFinalInspection(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusFinalInspection Instance = new AccelaCAPRecordStatusFinalInspection(82, @"FinalInspection", @"Final Inspection");
    }

    public partial class AccelaCAPRecordStatusFinalInspectionCompleted : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusFinalInspectionCompleted(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusFinalInspectionCompleted Instance = new AccelaCAPRecordStatusFinalInspectionCompleted(83, @"FinalInspectionCompleted", @"Final Inspection Completed");
    }

    public partial class AccelaCAPRecordStatusHold : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusHold(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusHold Instance = new AccelaCAPRecordStatusHold(84, @"Hold", @"Hold");
    }

    public partial class AccelaCAPRecordStatusHoldForApplicant : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusHoldForApplicant(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusHoldForApplicant Instance = new AccelaCAPRecordStatusHoldForApplicant(85, @"HoldForApplicant", @"Hold For Applicant");
    }

    public partial class AccelaCAPRecordStatusImplemented : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusImplemented(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusImplemented Instance = new AccelaCAPRecordStatusImplemented(86, @"Implemented", @"Implemented");
    }

    public partial class AccelaCAPRecordStatusInDraft : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusInDraft(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusInDraft Instance = new AccelaCAPRecordStatusInDraft(87, @"InDraft", @"In Draft");
    }

    public partial class AccelaCAPRecordStatusInspected : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusInspected(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusInspected Instance = new AccelaCAPRecordStatusInspected(88, @"Inspected", @"Inspected");
    }

    public partial class AccelaCAPRecordStatusInspectionInProcess : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusInspectionInProcess(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusInspectionInProcess Instance = new AccelaCAPRecordStatusInspectionInProcess(89, @"InspectionInProcess", @"Inspection In Process");
    }

    public partial class AccelaCAPRecordStatusLitigate : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusLitigate(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusLitigate Instance = new AccelaCAPRecordStatusLitigate(90, @"Litigate", @"Litigate");
    }

    public partial class AccelaCAPRecordStatusNoResponse : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusNoResponse(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusNoResponse Instance = new AccelaCAPRecordStatusNoResponse(91, @"NoResponse", @"No Response");
    }

    public partial class AccelaCAPRecordStatusNoViolation : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusNoViolation(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusNoViolation Instance = new AccelaCAPRecordStatusNoViolation(92, @"NoViolation", @"No Violation");
    }

    public partial class AccelaCAPRecordStatusNotQualified : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusNotQualified(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusNotQualified Instance = new AccelaCAPRecordStatusNotQualified(93, @"NotQualified", @"Not Qualified");
    }

    public partial class AccelaCAPRecordStatusNoticeSent : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusNoticeSent(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusNoticeSent Instance = new AccelaCAPRecordStatusNoticeSent(94, @"NoticeSent", @"Notice Sent");
    }

    public partial class AccelaCAPRecordStatusNoticed : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusNoticed(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusNoticed Instance = new AccelaCAPRecordStatusNoticed(95, @"Noticed", @"Noticed");
    }

    public partial class AccelaCAPRecordStatusOnHold : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusOnHold(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusOnHold Instance = new AccelaCAPRecordStatusOnHold(96, @"OnHold", @"On Hold");
    }

    public partial class AccelaCAPRecordStatusPassedEval : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusPassedEval(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusPassedEval Instance = new AccelaCAPRecordStatusPassedEval(97, @"PassedEval", @"Passed Eval");
    }

    public partial class AccelaCAPRecordStatusPermitFinaled : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusPermitFinaled(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusPermitFinaled Instance = new AccelaCAPRecordStatusPermitFinaled(98, @"PermitFinaled", @"Permit Finaled");
    }

    public partial class AccelaCAPRecordStatusPermitRequired : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusPermitRequired(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusPermitRequired Instance = new AccelaCAPRecordStatusPermitRequired(99, @"PermitRequired", @"Permit Required");
    }

    public partial class AccelaCAPRecordStatusPermitted : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusPermitted(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusPermitted Instance = new AccelaCAPRecordStatusPermitted(100, @"Permitted", @"Permitted");
    }

    public partial class AccelaCAPRecordStatusPlannerReviewFinished : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusPlannerReviewFinished(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusPlannerReviewFinished Instance = new AccelaCAPRecordStatusPlannerReviewFinished(101, @"PlannerReviewFinished", @"Planner Review Finished");
    }

    public partial class AccelaCAPRecordStatusReferredToERS : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusReferredToERS(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusReferredToERS Instance = new AccelaCAPRecordStatusReferredToERS(102, @"ReferredToERS", @"Referred to ERS");
    }

    public partial class AccelaCAPRecordStatusReferredToMOU : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusReferredToMOU(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusReferredToMOU Instance = new AccelaCAPRecordStatusReferredToMOU(103, @"ReferredToMOU", @"Referred to MOU");
    }

    public partial class AccelaCAPRecordStatusResolutionSettlement : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusResolutionSettlement(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusResolutionSettlement Instance = new AccelaCAPRecordStatusResolutionSettlement(104, @"ResolutionSettlement", @"RESOLUTION/SETTLEMENT");
    }

    public partial class AccelaCAPRecordStatusReviewedStaffWithComma : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusReviewedStaffWithComma(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusReviewedStaffWithComma Instance = new AccelaCAPRecordStatusReviewedStaffWithComma(105, @"ReviewedStaffWithComma", @"Reviewed, Staff");
    }

    public partial class AccelaCAPRecordStatusRevisedAccepted : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusRevisedAccepted(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusRevisedAccepted Instance = new AccelaCAPRecordStatusRevisedAccepted(106, @"RevisedAccepted", @"Revised Accepted");
    }

    public partial class AccelaCAPRecordStatusScopeCirculated : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusScopeCirculated(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusScopeCirculated Instance = new AccelaCAPRecordStatusScopeCirculated(107, @"ScopeCirculated", @"Scope Circulated");
    }

    public partial class AccelaCAPRecordStatusScoped : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusScoped(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusScoped Instance = new AccelaCAPRecordStatusScoped(108, @"Scoped", @"Scoped");
    }

    public partial class AccelaCAPRecordStatusSettlementDeclined : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusSettlementDeclined(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusSettlementDeclined Instance = new AccelaCAPRecordStatusSettlementDeclined(109, @"SettlementDeclined", @"Settlement Declined");
    }

    public partial class AccelaCAPRecordStatusUnderReview : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusUnderReview(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusUnderReview Instance = new AccelaCAPRecordStatusUnderReview(110, @"UnderReview", @"Under Review");
    }

    public partial class AccelaCAPRecordStatusUnpaidFees : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusUnpaidFees(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusUnpaidFees Instance = new AccelaCAPRecordStatusUnpaidFees(111, @"UnpaidFees", @"Unpaid Fees");
    }

    public partial class AccelaCAPRecordStatusViolation : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusViolation(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusViolation Instance = new AccelaCAPRecordStatusViolation(112, @"Violation", @"Violation");
    }

    public partial class AccelaCAPRecordStatusVoid : AccelaCAPRecordStatus
    {
        private AccelaCAPRecordStatusVoid(int accelaCAPRecordStatusID, string accelaCAPRecordStatusName, string accelaCAPRecordStatusDisplayName) : base(accelaCAPRecordStatusID, accelaCAPRecordStatusName, accelaCAPRecordStatusDisplayName) {}
        public static readonly AccelaCAPRecordStatusVoid Instance = new AccelaCAPRecordStatusVoid(113, @"Void", @"Void");
    }
}