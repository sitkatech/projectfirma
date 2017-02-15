SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureSubcategory](
	[PerformanceMeasureSubcategoryID] [int] IDENTITY(1,1) NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[PerformanceMeasureSubcategoryDisplayName] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ChartConfigurationJson] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ChartType] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SwapChartAxes] [bit] NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureSubcategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureSubcategoryID] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID_TenantID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureSubcategoryID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasureSubcategory]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureSubcategory_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureSubcategory] CHECK CONSTRAINT [FK_PerformanceMeasureSubcategory_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureSubcategory]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureSubcategory_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureSubcategory] CHECK CONSTRAINT [FK_PerformanceMeasureSubcategory_PerformanceMeasure_PerformanceMeasureID_TenantID]
GO
ALTER TABLE [dbo].[PerformanceMeasureSubcategory]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureSubcategory_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureSubcategory] CHECK CONSTRAINT [FK_PerformanceMeasureSubcategory_Tenant_TenantID]