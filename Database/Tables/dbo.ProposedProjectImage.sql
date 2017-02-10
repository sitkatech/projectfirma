SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProposedProjectImage](
	[ProposedProjectImageID] [int] IDENTITY(1,1) NOT NULL,
	[FileResourceID] [int] NOT NULL,
	[ProposedProjectID] [int] NOT NULL,
	[Caption] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Credit] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_ProposedProjectImage_ProposedProjectImageID] PRIMARY KEY CLUSTERED 
(
	[ProposedProjectImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProposedProjectImage]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectImage_FileResource_FileResourceID] FOREIGN KEY([FileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[ProposedProjectImage] CHECK CONSTRAINT [FK_ProposedProjectImage_FileResource_FileResourceID]
GO
ALTER TABLE [dbo].[ProposedProjectImage]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectImage_ProposedProject_ProposedProjectID] FOREIGN KEY([ProposedProjectID])
REFERENCES [dbo].[ProposedProject] ([ProposedProjectID])
GO
ALTER TABLE [dbo].[ProposedProjectImage] CHECK CONSTRAINT [FK_ProposedProjectImage_ProposedProject_ProposedProjectID]
GO
ALTER TABLE [dbo].[ProposedProjectImage]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectImage_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProposedProjectImage] CHECK CONSTRAINT [FK_ProposedProjectImage_Tenant_TenantID]