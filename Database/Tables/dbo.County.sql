SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[County](
	[CountyID] [int] NOT NULL,
	[TenantID] [int] NOT NULL,
	[CountyName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[StateProvinceID] [int] NOT NULL,
	[CountyFeature] [geometry] NULL,
 CONSTRAINT [PK_County_CountyID] PRIMARY KEY CLUSTERED 
(
	[CountyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_County_CountyName_StateProvinceID] UNIQUE NONCLUSTERED 
(
	[CountyName] ASC,
	[StateProvinceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[County]  WITH CHECK ADD  CONSTRAINT [FK_County_StateProvince_StateProvinceID] FOREIGN KEY([StateProvinceID])
REFERENCES [dbo].[StateProvince] ([StateProvinceID])
GO
ALTER TABLE [dbo].[County] CHECK CONSTRAINT [FK_County_StateProvince_StateProvinceID]
GO
ALTER TABLE [dbo].[County]  WITH CHECK ADD  CONSTRAINT [FK_County_StateProvince_StateProvinceID_TenantID] FOREIGN KEY([StateProvinceID], [TenantID])
REFERENCES [dbo].[StateProvince] ([StateProvinceID], [TenantID])
GO
ALTER TABLE [dbo].[County] CHECK CONSTRAINT [FK_County_StateProvince_StateProvinceID_TenantID]
GO
ALTER TABLE [dbo].[County]  WITH CHECK ADD  CONSTRAINT [FK_County_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[County] CHECK CONSTRAINT [FK_County_Tenant_TenantID]
GO
ALTER TABLE [dbo].[County]  WITH CHECK ADD  CONSTRAINT [CK_County_CountyFeature_SpatialReferenceID_Must_Be_4326] CHECK  (([CountyFeature] IS NULL OR [CountyFeature].[STSrid]=(4326)))
GO
ALTER TABLE [dbo].[County] CHECK CONSTRAINT [CK_County_CountyFeature_SpatialReferenceID_Must_Be_4326]