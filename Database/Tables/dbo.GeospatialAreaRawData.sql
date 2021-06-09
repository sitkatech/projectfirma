SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeospatialAreaRawData](
	[GeospatialAreaRawDataID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[GeospatialAreaTypeID] [int] NOT NULL,
	[ResultJson] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_GeospatialAreaRawData_GeospatialAreaRawDataID] PRIMARY KEY CLUSTERED 
(
	[GeospatialAreaRawDataID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_GeospatialAreaRawData_GeospatialAreaTypeID_TenantID] UNIQUE NONCLUSTERED 
(
	[GeospatialAreaTypeID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[GeospatialAreaRawData]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaRawData_GeospatialAreaType_GeospatialAreaTypeID] FOREIGN KEY([GeospatialAreaTypeID])
REFERENCES [dbo].[GeospatialAreaType] ([GeospatialAreaTypeID])
GO
ALTER TABLE [dbo].[GeospatialAreaRawData] CHECK CONSTRAINT [FK_GeospatialAreaRawData_GeospatialAreaType_GeospatialAreaTypeID]
GO
ALTER TABLE [dbo].[GeospatialAreaRawData]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaRawData_GeospatialAreaType_GeospatialAreaTypeID_TenantID] FOREIGN KEY([GeospatialAreaTypeID], [TenantID])
REFERENCES [dbo].[GeospatialAreaType] ([GeospatialAreaTypeID], [TenantID])
GO
ALTER TABLE [dbo].[GeospatialAreaRawData] CHECK CONSTRAINT [FK_GeospatialAreaRawData_GeospatialAreaType_GeospatialAreaTypeID_TenantID]
GO
ALTER TABLE [dbo].[GeospatialAreaRawData]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaRawData_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[GeospatialAreaRawData] CHECK CONSTRAINT [FK_GeospatialAreaRawData_Tenant_TenantID]