SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectFirmaPage](
	[ProjectFirmaPageID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectFirmaPageTypeID] [int] NOT NULL,
	[ProjectFirmaPageContent] [dbo].[html] NULL,
 CONSTRAINT [PK_ProjectFirmaPage_ProjectFirmaPageID] PRIMARY KEY CLUSTERED 
(
	[ProjectFirmaPageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectFirmaPage_ProjectFirmaPageTypeID] UNIQUE NONCLUSTERED 
(
	[ProjectFirmaPageTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectFirmaPage]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFirmaPage_ProjectFirmaPageType_ProjectFirmaPageTypeID] FOREIGN KEY([ProjectFirmaPageTypeID])
REFERENCES [dbo].[ProjectFirmaPageType] ([ProjectFirmaPageTypeID])
GO
ALTER TABLE [dbo].[ProjectFirmaPage] CHECK CONSTRAINT [FK_ProjectFirmaPage_ProjectFirmaPageType_ProjectFirmaPageTypeID]