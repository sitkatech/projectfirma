SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FirmaPageType](
	[FirmaPageTypeID] [int] NOT NULL,
	[FirmaPageTypeName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FirmaPageTypeDisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FirmaPageRenderTypeID] [int] NOT NULL,
 CONSTRAINT [PK_FirmaPageType_FirmaPageTypeID] PRIMARY KEY CLUSTERED 
(
	[FirmaPageTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FirmaPageType_FirmaPageTypeDisplayName] UNIQUE NONCLUSTERED 
(
	[FirmaPageTypeDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FirmaPageType_FirmaPageTypeName] UNIQUE NONCLUSTERED 
(
	[FirmaPageTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[FirmaPageType]  WITH CHECK ADD  CONSTRAINT [FK_FirmaPageType_FirmaPageRenderType_FirmaPageRenderTypeID] FOREIGN KEY([FirmaPageRenderTypeID])
REFERENCES [dbo].[FirmaPageRenderType] ([FirmaPageRenderTypeID])
GO
ALTER TABLE [dbo].[FirmaPageType] CHECK CONSTRAINT [FK_FirmaPageType_FirmaPageRenderType_FirmaPageRenderTypeID]