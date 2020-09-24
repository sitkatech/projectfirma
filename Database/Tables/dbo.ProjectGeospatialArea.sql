SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectGeospatialArea](
	[ProjectGeospatialAreaID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[GeospatialAreaID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectGeospatialArea_ProjectGeospatialAreaID] PRIMARY KEY CLUSTERED 
(
	[ProjectGeospatialAreaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectGeospatialArea_ProjectID_GeospatialAreaID] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
	[GeospatialAreaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE NONCLUSTERED INDEX [IDX_ProjectGeospatialArea_Project] ON [dbo].[ProjectGeospatialArea]
(
	[ProjectID] ASC
)
INCLUDE([TenantID]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_ProjectGeospatialArea_Tenant] ON [dbo].[ProjectGeospatialArea]
(
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProjectGeospatialArea]  WITH CHECK ADD  CONSTRAINT [FK_ProjectGeospatialArea_GeospatialArea_GeospatialAreaID] FOREIGN KEY([GeospatialAreaID])
REFERENCES [dbo].[GeospatialArea] ([GeospatialAreaID])
GO
ALTER TABLE [dbo].[ProjectGeospatialArea] CHECK CONSTRAINT [FK_ProjectGeospatialArea_GeospatialArea_GeospatialAreaID]
GO
ALTER TABLE [dbo].[ProjectGeospatialArea]  WITH CHECK ADD  CONSTRAINT [FK_ProjectGeospatialArea_GeospatialArea_GeospatialAreaID_TenantID] FOREIGN KEY([GeospatialAreaID], [TenantID])
REFERENCES [dbo].[GeospatialArea] ([GeospatialAreaID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectGeospatialArea] CHECK CONSTRAINT [FK_ProjectGeospatialArea_GeospatialArea_GeospatialAreaID_TenantID]
GO
ALTER TABLE [dbo].[ProjectGeospatialArea]  WITH CHECK ADD  CONSTRAINT [FK_ProjectGeospatialArea_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectGeospatialArea] CHECK CONSTRAINT [FK_ProjectGeospatialArea_Project_ProjectID]
GO
ALTER TABLE [dbo].[ProjectGeospatialArea]  WITH CHECK ADD  CONSTRAINT [FK_ProjectGeospatialArea_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectGeospatialArea] CHECK CONSTRAINT [FK_ProjectGeospatialArea_Project_ProjectID_TenantID]
GO
ALTER TABLE [dbo].[ProjectGeospatialArea]  WITH CHECK ADD  CONSTRAINT [FK_ProjectGeospatialArea_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectGeospatialArea] CHECK CONSTRAINT [FK_ProjectGeospatialArea_Tenant_TenantID]