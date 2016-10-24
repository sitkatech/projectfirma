SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectFirmaPageType](
	[ProjectFirmaPageTypeID] [int] NOT NULL,
	[ProjectFirmaPageTypeName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProjectFirmaPageTypeDisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PrimaryLTInfoAreaID] [int] NOT NULL,
	[ProjectFirmaPageRenderTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectFirmaPageType_ProjectFirmaPageTypeID] PRIMARY KEY CLUSTERED 
(
	[ProjectFirmaPageTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectFirmaPageType_ProjectFirmaPageTypeDisplayName] UNIQUE NONCLUSTERED 
(
	[ProjectFirmaPageTypeDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectFirmaPageType_ProjectFirmaPageTypeName] UNIQUE NONCLUSTERED 
(
	[ProjectFirmaPageTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectFirmaPageType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFirmaPageType_LTInfoArea_PrimaryLTInfoAreaID_LTInfoAreaID] FOREIGN KEY([PrimaryLTInfoAreaID])
REFERENCES [dbo].[LTInfoArea] ([LTInfoAreaID])
GO
ALTER TABLE [dbo].[ProjectFirmaPageType] CHECK CONSTRAINT [FK_ProjectFirmaPageType_LTInfoArea_PrimaryLTInfoAreaID_LTInfoAreaID]
GO
ALTER TABLE [dbo].[ProjectFirmaPageType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFirmaPageType_ProjectFirmaPageRenderType_ProjectFirmaPageRenderTypeID] FOREIGN KEY([ProjectFirmaPageRenderTypeID])
REFERENCES [dbo].[ProjectFirmaPageRenderType] ([ProjectFirmaPageRenderTypeID])
GO
ALTER TABLE [dbo].[ProjectFirmaPageType] CHECK CONSTRAINT [FK_ProjectFirmaPageType_ProjectFirmaPageRenderType_ProjectFirmaPageRenderTypeID]