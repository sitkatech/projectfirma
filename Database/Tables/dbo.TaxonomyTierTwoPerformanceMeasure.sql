SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxonomyTierTwoPerformanceMeasure](
	[TaxonomyTierTwoPerformanceMeasureID] [int] IDENTITY(1,1) NOT NULL,
	[TaxonomyTierTwoID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[IsPrimaryTaxonomyTierTwo] [bit] NOT NULL,
 CONSTRAINT [PK_TaxonomyTierTwoPerformanceMeasure_TaxonomyTierTwoPerformanceMeasureID] PRIMARY KEY CLUSTERED 
(
	[TaxonomyTierTwoPerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TaxonomyTierTwoPerformanceMeasure_TaxonomyTierTwoID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[TaxonomyTierTwoID] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TaxonomyTierTwoPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyTierTwoPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[TaxonomyTierTwoPerformanceMeasure] CHECK CONSTRAINT [FK_TaxonomyTierTwoPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[TaxonomyTierTwoPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyTierTwoPerformanceMeasure_TaxonomyTierTwo_TaxonomyTierTwoID] FOREIGN KEY([TaxonomyTierTwoID])
REFERENCES [dbo].[TaxonomyTierTwo] ([TaxonomyTierTwoID])
GO
ALTER TABLE [dbo].[TaxonomyTierTwoPerformanceMeasure] CHECK CONSTRAINT [FK_TaxonomyTierTwoPerformanceMeasure_TaxonomyTierTwo_TaxonomyTierTwoID]