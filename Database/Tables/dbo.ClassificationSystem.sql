SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassificationSystem](
	[ClassificationSystemID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ClassificationSystemName] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ClassificationSystemDefinition] [dbo].[html] NULL,
	[ClassificationSystemListPageContent] [dbo].[html] NULL,
 CONSTRAINT [PK_ClassificationSystem_ClassificationSystemID] PRIMARY KEY CLUSTERED 
(
	[ClassificationSystemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ClassificationSystem_ClassificationSystemID_TenantID] UNIQUE NONCLUSTERED 
(
	[ClassificationSystemID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ClassificationSystem_ClassificationSystemName_TenantID] UNIQUE NONCLUSTERED 
(
	[ClassificationSystemName] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[ClassificationSystem]  WITH CHECK ADD  CONSTRAINT [FK_ClassificationSystem_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ClassificationSystem] CHECK CONSTRAINT [FK_ClassificationSystem_Tenant_TenantID]