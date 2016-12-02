SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureSubcategoryOption](
	[PerformanceMeasureSubcategoryOptionID] [int] IDENTITY(1,1) NOT NULL,
	[PerformanceMeasureSubcategoryID] [int] NOT NULL,
	[PerformanceMeasureSubcategoryOptionName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SortOrder] [int] NULL,
	[ShortName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureSubcategoryOptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryID_PerformanceMeasureSubcategoryOptionName] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureSubcategoryID] ASC,
	[PerformanceMeasureSubcategoryOptionName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID_PerformanceMeasureSubcategoryID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureSubcategoryOptionID] ASC,
	[PerformanceMeasureSubcategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasureSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID] FOREIGN KEY([PerformanceMeasureSubcategoryID])
REFERENCES [dbo].[PerformanceMeasureSubcategory] ([PerformanceMeasureSubcategoryID])
GO
ALTER TABLE [dbo].[PerformanceMeasureSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID]