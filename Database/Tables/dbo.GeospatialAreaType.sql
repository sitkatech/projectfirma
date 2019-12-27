SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeospatialAreaType](
	[GeospatialAreaTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[GeospatialAreaTypeName] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[GeospatialAreaTypeNamePluralized] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[GeospatialAreaIntroContent] [dbo].[html] NULL,
	[GeospatialAreaTypeDefinition] [dbo].[html] NULL,
	[GeospatialAreaLayerName] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_GeospatialAreaType_GeospatialAreaTypeID] PRIMARY KEY CLUSTERED 
(
	[GeospatialAreaTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_GeospatialAreaType_GeospatialAreaTypeID_TenantID] UNIQUE NONCLUSTERED 
(
	[GeospatialAreaTypeID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_GeospatialAreaType_GeospatialAreaTypeName_TenantID] UNIQUE NONCLUSTERED 
(
	[GeospatialAreaTypeName] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_GeospatialAreaType_GeospatialAreaTypeNamePluralized_TenantID] UNIQUE NONCLUSTERED 
(
	[GeospatialAreaTypeNamePluralized] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[GeospatialAreaType]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaType_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[GeospatialAreaType] CHECK CONSTRAINT [FK_GeospatialAreaType_Tenant_TenantID]