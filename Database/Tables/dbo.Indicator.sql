SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Indicator](
	[IndicatorID] [int] IDENTITY(1,1) NOT NULL,
	[IndicatorName] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[IndicatorDisplayName] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[MeasurementUnitTypeID] [int] NOT NULL,
	[IndicatorDefinition] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IndicatorPublicDescription] [dbo].[html] NULL,
	[DataSourceText] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ExternalDataSourceUrl] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DisplayOrder] [int] NOT NULL,
	[AssociatedPrograms] [dbo].[html] NULL,
	[IndicatorTypeID] [int] NOT NULL,
	[ChartTitle] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ChartCaption] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Indicator_IndicatorID] PRIMARY KEY CLUSTERED 
(
	[IndicatorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Indicator_IndicatorDisplayName] UNIQUE NONCLUSTERED 
(
	[IndicatorDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Indicator_IndicatorName] UNIQUE NONCLUSTERED 
(
	[IndicatorName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Indicator]  WITH CHECK ADD  CONSTRAINT [FK_Indicator_IndicatorType_IndicatorTypeID] FOREIGN KEY([IndicatorTypeID])
REFERENCES [dbo].[IndicatorType] ([IndicatorTypeID])
GO
ALTER TABLE [dbo].[Indicator] CHECK CONSTRAINT [FK_Indicator_IndicatorType_IndicatorTypeID]
GO
ALTER TABLE [dbo].[Indicator]  WITH CHECK ADD  CONSTRAINT [FK_Indicator_MeasurementUnitType_MeasurementUnitTypeID] FOREIGN KEY([MeasurementUnitTypeID])
REFERENCES [dbo].[MeasurementUnitType] ([MeasurementUnitTypeID])
GO
ALTER TABLE [dbo].[Indicator] CHECK CONSTRAINT [FK_Indicator_MeasurementUnitType_MeasurementUnitTypeID]