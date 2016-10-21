SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThresholdReportingCategory](
	[ThresholdReportingCategoryID] [int] NOT NULL,
	[ThresholdCategoryID] [int] NOT NULL,
	[ThresholdReportingCategoryName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Narrative] [dbo].[html] NULL,
 CONSTRAINT [PK_ThresholdReportingCategory_ThresholdReportingCategoryID] PRIMARY KEY CLUSTERED 
(
	[ThresholdReportingCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ThresholdReportingCategory_DisplayOrder] UNIQUE NONCLUSTERED 
(
	[DisplayOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ThresholdReportingCategory_ThresholdReportingCategoryName] UNIQUE NONCLUSTERED 
(
	[ThresholdReportingCategoryName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ThresholdReportingCategory]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdReportingCategory_ThresholdCategory_ThresholdCategoryID] FOREIGN KEY([ThresholdCategoryID])
REFERENCES [dbo].[ThresholdCategory] ([ThresholdCategoryID])
GO
ALTER TABLE [dbo].[ThresholdReportingCategory] CHECK CONSTRAINT [FK_ThresholdReportingCategory_ThresholdCategory_ThresholdCategoryID]