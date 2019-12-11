SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classification](
	[ClassificationID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ClassificationDescription] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ThemeColor] [varchar](7) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DisplayName] [varchar](75) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[GoalStatement] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[KeyImageFileResourceID] [int] NULL,
	[ClassificationSystemID] [int] NOT NULL,
	[ClassificationSortOrder] [int] NULL,
 CONSTRAINT [PK_Classification_ClassificationID] PRIMARY KEY CLUSTERED 
(
	[ClassificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Classification_ClassificationID_TenantID] UNIQUE NONCLUSTERED 
(
	[ClassificationID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Classification_DisplayName_ClassificationSystemID_TenantID] UNIQUE NONCLUSTERED 
(
	[DisplayName] ASC,
	[ClassificationSystemID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Classification]  WITH CHECK ADD  CONSTRAINT [FK_Classification_ClassificationSystem_ClassificationSystemID] FOREIGN KEY([ClassificationSystemID])
REFERENCES [dbo].[ClassificationSystem] ([ClassificationSystemID])
GO
ALTER TABLE [dbo].[Classification] CHECK CONSTRAINT [FK_Classification_ClassificationSystem_ClassificationSystemID]
GO
ALTER TABLE [dbo].[Classification]  WITH CHECK ADD  CONSTRAINT [FK_Classification_ClassificationSystem_ClassificationSystemID_TenantID] FOREIGN KEY([ClassificationSystemID], [TenantID])
REFERENCES [dbo].[ClassificationSystem] ([ClassificationSystemID], [TenantID])
GO
ALTER TABLE [dbo].[Classification] CHECK CONSTRAINT [FK_Classification_ClassificationSystem_ClassificationSystemID_TenantID]
GO
ALTER TABLE [dbo].[Classification]  WITH CHECK ADD  CONSTRAINT [FK_Classification_FileResource_KeyImageFileResourceID_FileResourceID] FOREIGN KEY([KeyImageFileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[Classification] CHECK CONSTRAINT [FK_Classification_FileResource_KeyImageFileResourceID_FileResourceID]
GO
ALTER TABLE [dbo].[Classification]  WITH CHECK ADD  CONSTRAINT [FK_Classification_FileResource_KeyImageFileResourceID_TenantID_FileResourceID_TenantID] FOREIGN KEY([KeyImageFileResourceID], [TenantID])
REFERENCES [dbo].[FileResource] ([FileResourceID], [TenantID])
GO
ALTER TABLE [dbo].[Classification] CHECK CONSTRAINT [FK_Classification_FileResource_KeyImageFileResourceID_TenantID_FileResourceID_TenantID]
GO
ALTER TABLE [dbo].[Classification]  WITH CHECK ADD  CONSTRAINT [FK_Classification_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[Classification] CHECK CONSTRAINT [FK_Classification_Tenant_TenantID]