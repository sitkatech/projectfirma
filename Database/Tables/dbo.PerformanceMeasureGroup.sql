SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureGroup](
	[PerformanceMeasureGroupID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[PerformanceMeasureGroupName] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[IconFileResourceInfoID] [int] NULL,
 CONSTRAINT [PK_PerformanceMeasureGroup_PerformanceMeasureGroupID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureGroup_PerformanceMeasureGroupID_TenantID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureGroupID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureGroup_PerformanceMeasureGroupName_TenantID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureGroupName] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasureGroup]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureGroup_FileResourceInfo_IconFileResourceInfoID_FileResourceInfoID] FOREIGN KEY([IconFileResourceInfoID])
REFERENCES [dbo].[FileResourceInfo] ([FileResourceInfoID])
GO
ALTER TABLE [dbo].[PerformanceMeasureGroup] CHECK CONSTRAINT [FK_PerformanceMeasureGroup_FileResourceInfo_IconFileResourceInfoID_FileResourceInfoID]
GO
ALTER TABLE [dbo].[PerformanceMeasureGroup]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureGroup_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureGroup] CHECK CONSTRAINT [FK_PerformanceMeasureGroup_Tenant_TenantID]