SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasure](
	[PerformanceMeasureID] [int] IDENTITY(1,1) NOT NULL,
	[CriticalDefinitions] [dbo].[html] NULL,
	[ProjectReporting] [dbo].[html] NULL,
	[PerformanceMeasureDisplayName] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[MeasurementUnitTypeID] [int] NOT NULL,
	[PerformanceMeasureTypeID] [int] NOT NULL,
	[PerformanceMeasureDefinition] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DataSourceText] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ExternalDataSourceUrl] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ChartTitle] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ChartCaption] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_PerformanceMeasure_PerformanceMeasureID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasure_MeasurementUnitType_MeasurementUnitTypeID] FOREIGN KEY([MeasurementUnitTypeID])
REFERENCES [dbo].[MeasurementUnitType] ([MeasurementUnitTypeID])
GO
ALTER TABLE [dbo].[PerformanceMeasure] CHECK CONSTRAINT [FK_PerformanceMeasure_MeasurementUnitType_MeasurementUnitTypeID]
GO
ALTER TABLE [dbo].[PerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasure_PerformanceMeasureType_PerformanceMeasureTypeID] FOREIGN KEY([PerformanceMeasureTypeID])
REFERENCES [dbo].[PerformanceMeasureType] ([PerformanceMeasureTypeID])
GO
ALTER TABLE [dbo].[PerformanceMeasure] CHECK CONSTRAINT [FK_PerformanceMeasure_PerformanceMeasureType_PerformanceMeasureTypeID]