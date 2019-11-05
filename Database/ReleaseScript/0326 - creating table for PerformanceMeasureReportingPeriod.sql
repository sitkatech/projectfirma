
CREATE TABLE [dbo].[PerformanceMeasureReportingPeriod](
	[PerformanceMeasureReportingPeriodID] [int] IDENTITY(1,1) NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[TenantID] [int] NOT NULL,
	[PerformanceMeasureReportingPeriodBeginDate] [datetime] NOT NULL,
	[PerformanceMeasureReportingPeriodEndDate] [datetime] NULL,
	[PerformanceMeasureReportingPeriodLabel] [varchar](100) NOT NULL,
	[TargetValue] [float] NULL,
	[TargetValueDescription] [varchar](100) NULL,
 CONSTRAINT [PK_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureReportingPeriodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodLabel_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureReportingPeriodLabel] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
CONSTRAINT [AK_PerformanceMeasureReportingPeriod_Tenant_PerformanceMeasureReportingPeriodID_TenantID] UNIQUE NONCLUSTERED 
(
	PerformanceMeasureReportingPeriodID ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PerformanceMeasureReportingPeriod]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportingPeriod_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO

ALTER TABLE [dbo].[PerformanceMeasureReportingPeriod] CHECK CONSTRAINT [FK_PerformanceMeasureReportingPeriod_PerformanceMeasure_PerformanceMeasureID]
GO

ALTER TABLE [dbo].[PerformanceMeasureReportingPeriod]  WITH CHECK ADD  CONSTRAINT [CK_PerformanceMeasureReportingPeriod_BeginDateBeforeEndDate] CHECK  (([PerformanceMeasureReportingPeriodBeginDate]<=[PerformanceMeasureReportingPeriodEndDate]))
GO

ALTER TABLE [dbo].[PerformanceMeasureReportingPeriod] CHECK CONSTRAINT [CK_PerformanceMeasureReportingPeriod_BeginDateBeforeEndDate]
GO
ALTER TABLE [dbo].[PerformanceMeasureReportingPeriod]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportingPeriod_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO





CREATE TABLE [dbo].[PerformanceMeasureReportedValue](
	[PerformanceMeasureReportedValueID] [int] IDENTITY(1,1) NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[PerformanceMeasureReportingPeriodID] [int] NOT NULL,
	[TenantID] [int] NOT NULL,
	[ReportedValue] [float] NOT NULL,
 CONSTRAINT [PK_PerformanceMeasureReportedValue_PerformanceMeasureReportedValueID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureReportedValueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureReportedValue_PerformanceMeasureReportedValueID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureReportedValueID] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
CONSTRAINT [AK_PerformanceMeasureReportedValue_Tenant_PerformanceMeasureReportedValueID_TenantID] UNIQUE NONCLUSTERED 
(
	PerformanceMeasureReportedValueID ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PerformanceMeasureReportedValue]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportedValue_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO

ALTER TABLE [dbo].[PerformanceMeasureReportedValue] CHECK CONSTRAINT [FK_PerformanceMeasureReportedValue_PerformanceMeasure_PerformanceMeasureID]
GO

ALTER TABLE [dbo].[PerformanceMeasureReportedValue]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportedValue_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID] FOREIGN KEY([PerformanceMeasureReportingPeriodID])
REFERENCES [dbo].[PerformanceMeasureReportingPeriod] ([PerformanceMeasureReportingPeriodID])
GO

ALTER TABLE [dbo].[PerformanceMeasureReportedValue] CHECK CONSTRAINT [FK_PerformanceMeasureReportedValue_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID]
GO
ALTER TABLE [dbo].[PerformanceMeasureReportedValue]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportedValue_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO





CREATE TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption](
	[PerformanceMeasureReportedValueSubcategoryOptionID] [int] IDENTITY(1,1) NOT NULL,
	[PerformanceMeasureReportedValueID] [int] NOT NULL,
	[PerformanceMeasureSubcategoryOptionID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[PerformanceMeasureSubcategoryID] [int] NOT NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureReportedValueSubcategoryOptionID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureReportedValueSubcategoryOptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
CONSTRAINT [AK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureReportedValueSubcategoryOptionID_TenantID] UNIQUE NONCLUSTERED 
(
	PerformanceMeasureReportedValueSubcategoryOptionID ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO

ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasure_PerformanceMeasureID]
GO

ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureReportedValue_PerformanceMeasureReportedValueID] FOREIGN KEY([PerformanceMeasureReportedValueID])
REFERENCES [dbo].[PerformanceMeasureReportedValue] ([PerformanceMeasureReportedValueID])
GO

ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureReportedValue_PerformanceMeasureReportedValueID]
GO

ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureReportedValueID_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureReportedValueID], [PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasureReportedValue] ([PerformanceMeasureReportedValueID], [PerformanceMeasureID])
GO

ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureReportedValueID_PerformanceMeasureID]
GO

ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID] FOREIGN KEY([PerformanceMeasureSubcategoryID])
REFERENCES [dbo].[PerformanceMeasureSubcategory] ([PerformanceMeasureSubcategoryID])
GO

ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID]
GO

ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureSubcategoryID_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureSubcategoryID], [PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasureSubcategory] ([PerformanceMeasureSubcategoryID], [PerformanceMeasureID])
GO

ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureSubcategoryID_PerformanceMeasureID]
GO

ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID] FOREIGN KEY([PerformanceMeasureSubcategoryOptionID])
REFERENCES [dbo].[PerformanceMeasureSubcategoryOption] ([PerformanceMeasureSubcategoryOptionID])
GO

ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID]
GO

ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureSubcategoryOptionID_PerformanceMeasureSubcategoryID] FOREIGN KEY([PerformanceMeasureSubcategoryOptionID], [PerformanceMeasureSubcategoryID])
REFERENCES [dbo].[PerformanceMeasureSubcategoryOption] ([PerformanceMeasureSubcategoryOptionID], [PerformanceMeasureSubcategoryID])
GO

ALTER TABLE [dbo].[PerformanceMeasureReportedValueSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_PerformanceMeasureSubcategoryOptionID_PerformanceMeasureSubcategoryID]
GO
ALTER TABLE [dbo].PerformanceMeasureReportedValueSubcategoryOption  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportedValueSubcategoryOption_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO

