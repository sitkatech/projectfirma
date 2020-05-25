SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileResourceData](
	[FileResourceDataID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[FileResourceID] [int] NOT NULL,
	[Data] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_FileResourceData_FileResourceDataID] PRIMARY KEY CLUSTERED 
(
	[FileResourceDataID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FileResourceData_FileResourceDataID_FileResourceID] UNIQUE NONCLUSTERED 
(
	[FileResourceDataID] ASC,
	[FileResourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FileResourceData_FileResourceDataID_TenantID] UNIQUE NONCLUSTERED 
(
	[FileResourceDataID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[FileResourceData]  WITH CHECK ADD  CONSTRAINT [FK_FileResourceData_FileResource_FileResourceID] FOREIGN KEY([FileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[FileResourceData] CHECK CONSTRAINT [FK_FileResourceData_FileResource_FileResourceID]
GO
ALTER TABLE [dbo].[FileResourceData]  WITH CHECK ADD  CONSTRAINT [FK_FileResourceData_FileResource_FileResourceID_TenantID] FOREIGN KEY([FileResourceID], [TenantID])
REFERENCES [dbo].[FileResource] ([FileResourceID], [TenantID])
GO
ALTER TABLE [dbo].[FileResourceData] CHECK CONSTRAINT [FK_FileResourceData_FileResource_FileResourceID_TenantID]
GO
ALTER TABLE [dbo].[FileResourceData]  WITH CHECK ADD  CONSTRAINT [FK_FileResourceData_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[FileResourceData] CHECK CONSTRAINT [FK_FileResourceData_Tenant_TenantID]