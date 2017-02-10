SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FirmaPage](
	[FirmaPageID] [int] IDENTITY(1,1) NOT NULL,
	[FirmaPageTypeID] [int] NOT NULL,
	[FirmaPageContent] [dbo].[html] NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_FirmaPage_FirmaPageID] PRIMARY KEY CLUSTERED 
(
	[FirmaPageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FirmaPage_FirmaPageTypeID] UNIQUE NONCLUSTERED 
(
	[FirmaPageTypeID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[FirmaPage]  WITH CHECK ADD  CONSTRAINT [FK_FirmaPage_FirmaPageType_FirmaPageTypeID] FOREIGN KEY([FirmaPageTypeID])
REFERENCES [dbo].[FirmaPageType] ([FirmaPageTypeID])
GO
ALTER TABLE [dbo].[FirmaPage] CHECK CONSTRAINT [FK_FirmaPage_FirmaPageType_FirmaPageTypeID]
GO
ALTER TABLE [dbo].[FirmaPage]  WITH CHECK ADD  CONSTRAINT [FK_FirmaPage_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[FirmaPage] CHECK CONSTRAINT [FK_FirmaPage_Tenant_TenantID]