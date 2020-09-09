SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MatchMakerAreaOfInterestLocation](
	[MatchMakerAreaOfInterestLocationID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[OrganizationID] [int] NOT NULL,
	[MatchMakerAreaOfInterestLocationGeometry] [geometry] NOT NULL,
	[Annotation] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_MatchMakerAreaOfInterestLocation_MatchMakerAreaOfInterestLocationID] PRIMARY KEY CLUSTERED 
(
	[MatchMakerAreaOfInterestLocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[MatchMakerAreaOfInterestLocation]  WITH CHECK ADD  CONSTRAINT [FK_MatchMakerAreaOfInterestLocation_Organization_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [dbo].[MatchMakerAreaOfInterestLocation] CHECK CONSTRAINT [FK_MatchMakerAreaOfInterestLocation_Organization_OrganizationID]
GO
ALTER TABLE [dbo].[MatchMakerAreaOfInterestLocation]  WITH CHECK ADD  CONSTRAINT [FK_MatchMakerAreaOfInterestLocation_Organization_OrganizationID_TenantID] FOREIGN KEY([OrganizationID], [TenantID])
REFERENCES [dbo].[Organization] ([OrganizationID], [TenantID])
GO
ALTER TABLE [dbo].[MatchMakerAreaOfInterestLocation] CHECK CONSTRAINT [FK_MatchMakerAreaOfInterestLocation_Organization_OrganizationID_TenantID]
GO
ALTER TABLE [dbo].[MatchMakerAreaOfInterestLocation]  WITH CHECK ADD  CONSTRAINT [FK_MatchMakerAreaOfInterestLocation_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[MatchMakerAreaOfInterestLocation] CHECK CONSTRAINT [FK_MatchMakerAreaOfInterestLocation_Tenant_TenantID]