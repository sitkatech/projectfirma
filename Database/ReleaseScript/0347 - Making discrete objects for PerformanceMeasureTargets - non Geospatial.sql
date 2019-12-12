
--begin tran

-- New "Overall" Target object
------------------------------


CREATE TABLE dbo.PerformanceMeasureOverallTarget
(
    PerformanceMeasureOverallTargetID [int] IDENTITY(1,1) NOT NULL,
    [TenantID] [int] NOT NULL,
    [PerformanceMeasureID] [int] NOT NULL,
    [PerformanceMeasureTargetValue] [float] NULL,
    [PerformanceMeasureTargetValueLabel] [varchar](100) NULL,
 CONSTRAINT [PK_PerformanceMeasureOverallTarget_PerformanceMeasureOverallTargetID] PRIMARY KEY CLUSTERED 
(
    PerformanceMeasureOverallTargetID ASC
) ON [PRIMARY],



 CONSTRAINT [AK_PerformanceMeasureOverallTarget_PerformanceMeasureOverallTargetID_TenantID] UNIQUE NONCLUSTERED 
(
    PerformanceMeasureOverallTargetID ASC,
    [TenantID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO



ALTER TABLE [dbo].[PerformanceMeasureOverallTarget]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureOverallTarget_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO

ALTER TABLE [dbo].[PerformanceMeasureOverallTarget]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureOverallTarget_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID])
GO

ALTER TABLE [dbo].[PerformanceMeasureOverallTarget]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureOverallTarget_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO

-- Finally, rename the old object so it's clear this is the only one dealing with a specific reporting period.
----------------------------------------------------------------------------------------------------------------

exec sp_rename 'dbo.PerformanceMeasureTarget', 'PerformanceMeasureReportingPeriodTarget'
GO
exec sp_RENAME 'dbo.PerformanceMeasureReportingPeriodTarget.PerformanceMeasureTargetID', 'PerformanceMeasureReportingPeriodTargetID', 'COLUMN'
GO

exec sp_rename 'dbo.PerformanceMeasureReportingPeriodTarget.PK_PerformanceMeasureTarget_PerformanceMeasureTargetID', 'PK_PerformanceMeasureReportingPeriodTarget_PerformanceMeasureTargetID'
exec sp_rename 'dbo.FK_PerformanceMeasureTarget_PerformanceMeasure_PerformanceMeasureID', 'FK_PerformanceMeasureReportingPeriodTarget_PerformanceMeasure_PerformanceMeasureID'
exec sp_rename 'dbo.FK_PerformanceMeasureTarget_PerformanceMeasure_PerformanceMeasureID_TenantID', 'FK_PerformanceMeasureReportingPeriodTarget_PerformanceMeasure_PerformanceMeasureID_TenantID'
exec sp_rename 'dbo.FK_PerformanceMeasureTarget_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID', 'FK_PerformanceMeasureReportingPeriodTarget_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID'
exec sp_rename 'dbo.FK_PerformanceMeasureTarget_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID_TenantID', 'FK_PerformanceMeasureReportingPeriodTarget_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID_TenantID'
exec sp_rename 'dbo.FK_PerformanceMeasureTarget_Tenant_TenantID', 'FK_PerformanceMeasureReportingPeriodTarget_Tenant_TenantID'
exec sp_rename 'dbo.PerformanceMeasureReportingPeriodTarget.AK_PerformanceMeasureTarget_PerformanceMeasureReportingPeriodID_PerformanceMeasureID', 'AK_PerformanceMeasureReportingPeriodTarget_PerformanceMeasureReportingPeriodID_PerformanceMeasureID'
exec sp_rename 'dbo.PerformanceMeasureReportingPeriodTarget.AK_PerformanceMeasureTarget_PerformanceMeasureTargetID_TenantID', 'AK_PerformanceMeasureReportingPeriodTarget_PerformanceMeasureTargetID_TenantID'

--rollback tran