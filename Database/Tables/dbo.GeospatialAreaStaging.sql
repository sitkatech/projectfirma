SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeospatialAreaStaging](
	[GeospatialAreaStagingID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[Name] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ExternalID] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Geometry] [geometry] NOT NULL,
 CONSTRAINT [PK_GeospatialAreaStaging_GeospatialAreaStagingID] PRIMARY KEY CLUSTERED 
(
	[GeospatialAreaStagingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_GeospatialAreaStaging_ExternalID_TenantID] UNIQUE NONCLUSTERED 
(
	[ExternalID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_GeospatialAreaStaging_Name_TenantID] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[GeospatialAreaStaging]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaStaging_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[GeospatialAreaStaging] CHECK CONSTRAINT [FK_GeospatialAreaStaging_Tenant_TenantID]