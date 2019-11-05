
CREATE TABLE [dbo].[PerformanceMeasureReportingPeriod](
	[PerformanceMeasureReportingPeriodID] [int] IDENTITY(1,1) NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[TenantID] [int] NOT NULL,
	[PerformanceMeasureReportingPeriodCalendarYear] [int] NOT NULL,
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

ALTER TABLE [dbo].[PerformanceMeasureReportingPeriod]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportingPeriod_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO




alter table dbo.PerformanceMeasureActual
add [PerformanceMeasureReportingPeriodID] [int] NULL;
go

ALTER TABLE [dbo].PerformanceMeasureActual  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActual_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID] FOREIGN KEY([PerformanceMeasureReportingPeriodID])
REFERENCES [dbo].[PerformanceMeasureReportingPeriod] ([PerformanceMeasureReportingPeriodID])

go





--CREATE TABLE [dbo].[PerformanceMeasureActualSubcategoryOption](
--	[PerformanceMeasureActualSubcategoryOptionID] [int] IDENTITY(1,1) NOT NULL,
--	[PerformanceMeasureActualID] [int] NOT NULL,
--	[PerformanceMeasureSubcategoryOptionID] [int] NOT NULL,
--	[PerformanceMeasureID] [int] NOT NULL,
--	[PerformanceMeasureSubcategoryID] [int] NOT NULL,
--	[TenantID] [int] NOT NULL,
-- CONSTRAINT [PK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasureActualSubcategoryOptionID] PRIMARY KEY CLUSTERED 
--(
--	[PerformanceMeasureActualSubcategoryOptionID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
--CONSTRAINT [AK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasureActualSubcategoryOptionID_TenantID] UNIQUE NONCLUSTERED 
--(
--	PerformanceMeasureActualSubcategoryOptionID ASC,
--	[TenantID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]
--GO

--ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
--REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
--GO

--ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasure_PerformanceMeasureID]
--GO

--ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasureActual_PerformanceMeasureActualID] FOREIGN KEY([PerformanceMeasureActualID])
--REFERENCES [dbo].[PerformanceMeasureActual] ([PerformanceMeasureActualID])
--GO

--ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasureActual_PerformanceMeasureActualID]
--GO

--ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasureActualID_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureActualID], [PerformanceMeasureID])
--REFERENCES [dbo].[PerformanceMeasureActual] ([PerformanceMeasureActualID], [PerformanceMeasureID])
--GO

--ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasureActualID_PerformanceMeasureID]
--GO

--ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID] FOREIGN KEY([PerformanceMeasureSubcategoryID])
--REFERENCES [dbo].[PerformanceMeasureSubcategory] ([PerformanceMeasureSubcategoryID])
--GO

--ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID]
--GO

--ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategoryID_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureSubcategoryID], [PerformanceMeasureID])
--REFERENCES [dbo].[PerformanceMeasureSubcategory] ([PerformanceMeasureSubcategoryID], [PerformanceMeasureID])
--GO

--ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategoryID_PerformanceMeasureID]
--GO

--ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID] FOREIGN KEY([PerformanceMeasureSubcategoryOptionID])
--REFERENCES [dbo].[PerformanceMeasureSubcategoryOption] ([PerformanceMeasureSubcategoryOptionID])
--GO

--ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID]
--GO

--ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategoryOptionID_PerformanceMeasureSubcategoryID] FOREIGN KEY([PerformanceMeasureSubcategoryOptionID], [PerformanceMeasureSubcategoryID])
--REFERENCES [dbo].[PerformanceMeasureSubcategoryOption] ([PerformanceMeasureSubcategoryOptionID], [PerformanceMeasureSubcategoryID])
--GO

--ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategoryOptionID_PerformanceMeasureSubcategoryID]
--GO
--ALTER TABLE [dbo].PerformanceMeasureActualSubcategoryOption  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_Tenant_TenantID] FOREIGN KEY([TenantID])
--REFERENCES [dbo].[Tenant] ([TenantID])
--GO

