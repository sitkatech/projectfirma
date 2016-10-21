SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IndicatorSubcategoryOption](
	[IndicatorSubcategoryOptionID] [int] IDENTITY(1,1) NOT NULL,
	[IndicatorSubcategoryID] [int] NOT NULL,
	[IndicatorSubcategoryOptionName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SortOrder] [int] NULL,
	[ShortName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID] PRIMARY KEY CLUSTERED 
(
	[IndicatorSubcategoryOptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_IndicatorSubcategoryOption_IndicatorSubcategoryID_IndicatorSubcategoryOptionName] UNIQUE NONCLUSTERED 
(
	[IndicatorSubcategoryID] ASC,
	[IndicatorSubcategoryOptionName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID_IndicatorSubcategoryID] UNIQUE NONCLUSTERED 
(
	[IndicatorSubcategoryOptionID] ASC,
	[IndicatorSubcategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[IndicatorSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_IndicatorSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID] FOREIGN KEY([IndicatorSubcategoryID])
REFERENCES [dbo].[IndicatorSubcategory] ([IndicatorSubcategoryID])
GO
ALTER TABLE [dbo].[IndicatorSubcategoryOption] CHECK CONSTRAINT [FK_IndicatorSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID]