
--begin tran

-- New, "No Target" object. YES THIS ISN'T STRICTLY NEEDED BUT WE WANT IT.
---------------------------------------------------------------------------

CREATE TABLE dbo.GeospatialAreaPerformanceMeasureNoTarget
(
    GeospatialAreaPerformanceMeasureNoTargetID [int] IDENTITY(1,1) NOT NULL,
    [TenantID] [int] NOT NULL,
    [GeospatialAreaID] [int] NOT NULL,
    [PerformanceMeasureID] [int] NOT NULL

CONSTRAINT [PK_GeospatialAreaPerformanceMeasureNoTarget_GeospatialAreaPerformanceMeasureNoTargetID] PRIMARY KEY CLUSTERED 
(
    GeospatialAreaPerformanceMeasureNoTargetID ASC
)ON [PRIMARY],

 CONSTRAINT [AK_GeospatialAreaPerformanceMeasureNoTarget_GeospatialAreaID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
    [GeospatialAreaID] ASC,
    [PerformanceMeasureID] ASC
)ON [PRIMARY],


 CONSTRAINT [AK_GeospatialAreaPerformanceMeasureNoTarget_GeospatialAreaPerformanceMeasureTargetID_TenantID] UNIQUE NONCLUSTERED 
(
    GeospatialAreaPerformanceMeasureNoTargetID ASC,
    [TenantID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE dbo.GeospatialAreaPerformanceMeasureNoTarget  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureNoTarget_GeospatialArea_GeospatialAreaID] FOREIGN KEY([GeospatialAreaID])
REFERENCES [dbo].[GeospatialArea] ([GeospatialAreaID])
GO

ALTER TABLE dbo.GeospatialAreaPerformanceMeasureNoTarget  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureNoTarget_GeospatialArea_GeospatialAreaID_TenantID] FOREIGN KEY([GeospatialAreaID], [TenantID])
REFERENCES [dbo].[GeospatialArea] ([GeospatialAreaID], [TenantID])
GO

ALTER TABLE dbo.GeospatialAreaPerformanceMeasureNoTarget  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureNoTarget_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO

ALTER TABLE dbo.GeospatialAreaPerformanceMeasureNoTarget  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureNoTarget_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID])
GO

ALTER TABLE dbo.GeospatialAreaPerformanceMeasureNoTarget  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureNoTarget_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO

-- New "Overall" Target object
------------------------------


CREATE TABLE dbo.GeospatialAreaPerformanceMeasureOverallTarget
(
    GeospatialAreaPerformanceMeasureOverallTargetID [int] IDENTITY(1,1) NOT NULL,
    [TenantID] [int] NOT NULL,
    [GeospatialAreaID] [int] NOT NULL,
    [PerformanceMeasureID] [int] NOT NULL,
    [GeospatialAreaPerformanceMeasureTargetValue] [float] NULL,
    [GeospatialAreaPerformanceMeasureTargetValueLabel] [varchar](100) NULL,
 CONSTRAINT [PK_GeospatialAreaPerformanceMeasureOverallTarget_GeospatialAreaPerformanceMeasureOverallTargetID] PRIMARY KEY CLUSTERED 
(
    GeospatialAreaPerformanceMeasureOverallTargetID ASC
) ON [PRIMARY],


CONSTRAINT [AK_GeospatialAreaPerformanceMeasureOverallTarget_GeospatialAreaID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
    [GeospatialAreaID] ASC,
    [PerformanceMeasureID] ASC
) ON [PRIMARY],


 CONSTRAINT [AK_GeospatialAreaPerformanceMeasureOverallTarget_GeospatialAreaPerformanceMeasureOverallTargetID_TenantID] UNIQUE NONCLUSTERED 
(
    GeospatialAreaPerformanceMeasureOverallTargetID ASC,
    [TenantID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureOverallTarget]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureOverallTarget_GeospatialArea_GeospatialAreaID] FOREIGN KEY([GeospatialAreaID])
REFERENCES [dbo].[GeospatialArea] ([GeospatialAreaID])
GO

ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureOverallTarget]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureOverallTarget_GeospatialArea_GeospatialAreaID_TenantID] FOREIGN KEY([GeospatialAreaID], [TenantID])
REFERENCES [dbo].[GeospatialArea] ([GeospatialAreaID], [TenantID])
GO

ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureOverallTarget]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureOverallTarget_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO

ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureOverallTarget]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureOverallTarget_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID])
GO

ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureOverallTarget]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureOverallTarget_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO

-- Finally, rename the old object so it's clear this is the only one dealing with a specific reporting period.
----------------------------------------------------------------------------------------------------------------

exec sp_rename 'dbo.GeospatialAreaPerformanceMeasureTarget', 'GeospatialAreaPerformanceMeasureReportingPeriodTarget'
GO
exec sp_RENAME 'dbo.GeospatialAreaPerformanceMeasureReportingPeriodTarget.GeospatialAreaPerformanceMeasureTargetID', 'GeospatialAreaPerformanceMeasureReportingPeriodTargetID', 'COLUMN'
GO

--rollback tran