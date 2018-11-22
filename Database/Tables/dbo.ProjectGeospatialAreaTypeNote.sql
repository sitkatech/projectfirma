SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectGeospatialAreaTypeNote](
	[ProjectGeospatialAreaTypeNoteID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[GeospatialAreaTypeID] [int] NOT NULL,
	[Notes] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_ProjectGeospatialAreaTypeNote_ProjectGeospatialAreaTypeNoteID] PRIMARY KEY CLUSTERED 
(
	[ProjectGeospatialAreaTypeNoteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectGeospatialAreaTypeNote_ProjectID_GeospatialAreaTypeID] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
	[GeospatialAreaTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectGeospatialAreaTypeNote]  WITH CHECK ADD  CONSTRAINT [FK_ProjectGeospatialAreaTypeNote_GeospatialAreaType_GeospatialAreaTypeID] FOREIGN KEY([GeospatialAreaTypeID])
REFERENCES [dbo].[GeospatialAreaType] ([GeospatialAreaTypeID])
GO
ALTER TABLE [dbo].[ProjectGeospatialAreaTypeNote] CHECK CONSTRAINT [FK_ProjectGeospatialAreaTypeNote_GeospatialAreaType_GeospatialAreaTypeID]
GO
ALTER TABLE [dbo].[ProjectGeospatialAreaTypeNote]  WITH CHECK ADD  CONSTRAINT [FK_ProjectGeospatialAreaTypeNote_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectGeospatialAreaTypeNote] CHECK CONSTRAINT [FK_ProjectGeospatialAreaTypeNote_Project_ProjectID]
GO
ALTER TABLE [dbo].[ProjectGeospatialAreaTypeNote]  WITH CHECK ADD  CONSTRAINT [FK_ProjectGeospatialAreaTypeNote_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectGeospatialAreaTypeNote] CHECK CONSTRAINT [FK_ProjectGeospatialAreaTypeNote_Tenant_TenantID]