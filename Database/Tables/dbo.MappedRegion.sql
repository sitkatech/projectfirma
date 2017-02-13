SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MappedRegion](
	[MappedRegionID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[RegionName] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[RegionDisplayName] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[RegionFeature] [geometry] NOT NULL,
 CONSTRAINT [PK_MappedRegion_MappedRegionID] PRIMARY KEY CLUSTERED 
(
	[MappedRegionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[MappedRegion]  WITH CHECK ADD  CONSTRAINT [FK_MappedRegion_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[MappedRegion] CHECK CONSTRAINT [FK_MappedRegion_Tenant_TenantID]