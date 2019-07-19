USE [ProjectFirma]


BEGIN TRANSACTION

/****** Object:  Table [dbo].[FundingSourceCustomAttributeDataType]    Script Date: 7/10/2019 3:15:08 PM ******/
SET ANSI_NULLS ON


SET QUOTED_IDENTIFIER ON


CREATE TABLE [dbo].[FundingSourceCustomAttributeDataType](
	[FundingSourceCustomAttributeDataTypeID] [int] NOT NULL constraint [PK_FundingSourceCustomAttributeDataType_FundingSourceCustomAttributeDataTypeID] primary key,
	[FundingSourceCustomAttributeDataTypeName] [varchar](100) NOT NULL constraint [AK_FundingSourceCustomAttributeDataType_FundingSourceCustomAttributeDataTypeName] unique,
	[FundingSourceCustomAttributeDataTypeDisplayName] [varchar](100) NOT NULL constraint [AK_FundingSourceCustomAttributeDataType_FundingSourceCustomAttributeDataTypeDisplayName] unique,
);


/****** Object:  Table [dbo].[FundingSourceCustomAttributeType]    Script Date: 7/10/2019 3:08:10 PM ******/
CREATE TABLE [dbo].[FundingSourceCustomAttributeType](
	[FundingSourceCustomAttributeTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[FundingSourceCustomAttributeTypeName] [varchar](100) NOT NULL,
	[FundingSourceCustomAttributeDataTypeID] [int] NOT NULL,
	[MeasurementUnitTypeID] [int] NULL,
	[IsRequired] [bit] NOT NULL,
	[FundingSourceCustomAttributeTypeDescription] [varchar](200) NULL,
	[FundingSourceCustomAttributeTypeOptionsSchema] [varchar](max) NULL,
	[IncludeInFundingSourceGrid] [bit] NOT NULL,
 CONSTRAINT [PK_FundingSourceCustomAttributeType_FundingSourceCustomAttributeTypeID] PRIMARY KEY CLUSTERED 
(
	[FundingSourceCustomAttributeTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FundingSourceCustomAttributeType_FundingSourceCustomAttributeTypeID_TenantID] UNIQUE NONCLUSTERED 
(
	[FundingSourceCustomAttributeTypeID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FundingSourceAttributeType_FundingSourceCustomAttributeTypeName] UNIQUE NONCLUSTERED 
(
	[FundingSourceCustomAttributeTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


ALTER TABLE [dbo].[FundingSourceCustomAttributeType]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttributeType_MeasurementUnitType_MeasurementUnitTypeID] FOREIGN KEY([MeasurementUnitTypeID])
REFERENCES [dbo].[MeasurementUnitType] ([MeasurementUnitTypeID])


ALTER TABLE [dbo].[FundingSourceCustomAttributeType] CHECK CONSTRAINT [FK_FundingSourceCustomAttributeType_MeasurementUnitType_MeasurementUnitTypeID]


ALTER TABLE [dbo].[FundingSourceCustomAttributeType]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttributeType_FundingSourceCustomAttributeDataType_FundingSourceCustomAttributeDataTypeID] FOREIGN KEY([FundingSourceCustomAttributeDataTypeID])
REFERENCES [dbo].[FundingSourceCustomAttributeDataType] ([FundingSourceCustomAttributeDataTypeID])


ALTER TABLE [dbo].[FundingSourceCustomAttributeType] CHECK CONSTRAINT [FK_FundingSourceCustomAttributeType_FundingSourceCustomAttributeDataType_FundingSourceCustomAttributeDataTypeID]


ALTER TABLE [dbo].[FundingSourceCustomAttributeType]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttributeType_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])


ALTER TABLE [dbo].[FundingSourceCustomAttributeType] CHECK CONSTRAINT [FK_FundingSourceCustomAttributeType_Tenant_TenantID]


ALTER TABLE [dbo].[FundingSourceCustomAttributeType]  WITH CHECK ADD  CONSTRAINT [CK_FundingSourceCustomAttributeType_PickListTypeOptionSchemaNotNull] CHECK  ((NOT ([FundingSourceCustomAttributeDataTypeID]=(6) OR [FundingSourceCustomAttributeDataTypeID]=(5)) AND [FundingSourceCustomAttributeTypeOptionsSchema] IS NULL OR ([FundingSourceCustomAttributeDataTypeID]=(6) OR [FundingSourceCustomAttributeDataTypeID]=(5)) AND [FundingSourceCustomAttributeTypeOptionsSchema] IS NOT NULL))


ALTER TABLE [dbo].[FundingSourceCustomAttributeType] CHECK CONSTRAINT [CK_FundingSourceCustomAttributeType_PickListTypeOptionSchemaNotNull]



/****** Object:  Table [dbo].[FundingSourceCustomAttributeTypeRolePermissionType]    Script Date: 7/10/2019 3:19:09 PM ******/
CREATE TABLE [dbo].[FundingSourceCustomAttributeTypeRolePermissionType](
	[FundingSourceCustomAttributeTypeRolePermissionTypeID] [int] NOT NULL,
	[FundingSourceCustomAttributeTypeRolePermissionTypeName] [varchar](20) NOT NULL,
 CONSTRAINT [PK_FundingSourceCustomAttributeTypeRolePermissionType_FundingSourceCustomAttributeTypeRolePermissionTypeID] PRIMARY KEY CLUSTERED 
(
	[FundingSourceCustomAttributeTypeRolePermissionTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[[FundingSourceCustomAttributeTypeRole]]    Script Date: 7/10/2019 3:20:17 PM ******/
CREATE TABLE [dbo].[FundingSourceCustomAttributeTypeRole](
	[FundingSourceCustomAttributeTypeRoleID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[FundingSourceCustomAttributeTypeID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
	[FundingSourceCustomAttributeTypeRolePermissionTypeID] [int] NOT NULL,
 CONSTRAINT [PK_FundingSourceCustomAttributeTypeRole_FundingSourceCustomAttributeTypeRoleID] PRIMARY KEY CLUSTERED 
(
	[FundingSourceCustomAttributeTypeRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[FundingSourceCustomAttributeTypeRole]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttributeTypeRole_FundingSourceCustomAttributeType_FundingSourceCustomAttributeTypeID] FOREIGN KEY([FundingSourceCustomAttributeTypeID])
REFERENCES [dbo].[FundingSourceCustomAttributeType] ([FundingSourceCustomAttributeTypeID])


ALTER TABLE [dbo].[FundingSourceCustomAttributeTypeRole] CHECK CONSTRAINT [FK_FundingSourceCustomAttributeTypeRole_FundingSourceCustomAttributeType_FundingSourceCustomAttributeTypeID]


ALTER TABLE [dbo].[FundingSourceCustomAttributeTypeRole]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttributeTypeRole_FundingSourceCustomAttributeType_FundingSourceCustomAttributeTypeID_TenantID] FOREIGN KEY([FundingSourceCustomAttributeTypeID], [TenantID])
REFERENCES [dbo].[FundingSourceCustomAttributeType] ([FundingSourceCustomAttributeTypeID], [TenantID])


ALTER TABLE [dbo].[FundingSourceCustomAttributeTypeRole] CHECK CONSTRAINT [FK_FundingSourceCustomAttributeTypeRole_FundingSourceCustomAttributeType_FundingSourceCustomAttributeTypeID_TenantID]


ALTER TABLE [dbo].[FundingSourceCustomAttributeTypeRole]  WITH CHECK ADD  CONSTRAINT [FK_FSCustomAttributeTypeRole_FSCustomAttributeTypeRolePermissionType_FSCustomAttributeTypeRolePermissionTypeID] FOREIGN KEY([FundingSourceCustomAttributeTypeRolePermissionTypeID])
REFERENCES [dbo].[FundingSourceCustomAttributeTypeRolePermissionType] ([FundingSourceCustomAttributeTypeRolePermissionTypeID])


ALTER TABLE [dbo].[FundingSourceCustomAttributeTypeRole] CHECK CONSTRAINT [FK_FSCustomAttributeTypeRole_FSCustomAttributeTypeRolePermissionType_FSCustomAttributeTypeRolePermissionTypeID]


ALTER TABLE [dbo].[FundingSourceCustomAttributeTypeRole]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttributeTypeRole_Role_RoleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])


ALTER TABLE [dbo].[FundingSourceCustomAttributeTypeRole] CHECK CONSTRAINT [FK_FundingSourceCustomAttributeTypeRole_Role_RoleID]


ALTER TABLE [dbo].[FundingSourceCustomAttributeTypeRole]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttributeTypeRole_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])


ALTER TABLE [dbo].[FundingSourceCustomAttributeTypeRole] CHECK CONSTRAINT [FK_FundingSourceCustomAttributeTypeRole_Tenant_TenantID]




/****** Object:  Table [dbo].[FundingSourceCustomAttribute]    Script Date: 7/10/2019 3:25:22 PM ******/
CREATE TABLE [dbo].[FundingSourceCustomAttribute](
	[FundingSourceCustomAttributeID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[FundingSourceID] [int] NOT NULL,
	[FundingSourceCustomAttributeTypeID] [int] NOT NULL,
 CONSTRAINT [PK_FundingSourceCustomAttribute_FundingSourceCustomAttributeID] PRIMARY KEY CLUSTERED 
(
	[FundingSourceCustomAttributeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FundingSourceCustomAttribute_FundingSourceCustomAttributeID_TenantID] UNIQUE NONCLUSTERED 
(
	[FundingSourceCustomAttributeID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[FundingSourceCustomAttribute]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttribute_FundingSource_FundingSourceID] FOREIGN KEY([FundingSourceID])
REFERENCES [dbo].[FundingSource] ([FundingSourceID])


ALTER TABLE [dbo].[FundingSourceCustomAttribute] CHECK CONSTRAINT [FK_FundingSourceCustomAttribute_FundingSource_FundingSourceID]


ALTER TABLE [dbo].[FundingSourceCustomAttribute]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttribute_FundingSource_FundingSourceID_TenantID] FOREIGN KEY([FundingSourceID], [TenantID])
REFERENCES [dbo].[FundingSource] ([FundingSourceID], [TenantID])


ALTER TABLE [dbo].[FundingSourceCustomAttribute] CHECK CONSTRAINT [FK_FundingSourceCustomAttribute_FundingSource_FundingSourceID_TenantID]


ALTER TABLE [dbo].[FundingSourceCustomAttribute]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttribute_FundingSourceCustomAttributeType_FundingSourceCustomAttributeTypeID] FOREIGN KEY([FundingSourceCustomAttributeTypeID])
REFERENCES [dbo].[FundingSourceCustomAttributeType] ([FundingSourceCustomAttributeTypeID])


ALTER TABLE [dbo].[FundingSourceCustomAttribute] CHECK CONSTRAINT [FK_FundingSourceCustomAttribute_FundingSourceCustomAttributeType_FundingSourceCustomAttributeTypeID]


ALTER TABLE [dbo].[FundingSourceCustomAttribute]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttribute_FundingSourceCustomAttributeType_FundingSourceCustomAttributeTypeID_TenantID] FOREIGN KEY([FundingSourceCustomAttributeTypeID], [TenantID])
REFERENCES [dbo].[FundingSourceCustomAttributeType] ([FundingSourceCustomAttributeTypeID], [TenantID])


ALTER TABLE [dbo].[FundingSourceCustomAttribute] CHECK CONSTRAINT [FK_FundingSourceCustomAttribute_FundingSourceCustomAttributeType_FundingSourceCustomAttributeTypeID_TenantID]


ALTER TABLE [dbo].[FundingSourceCustomAttribute]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttribute_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])


ALTER TABLE [dbo].[FundingSourceCustomAttribute] CHECK CONSTRAINT [FK_FundingSourceCustomAttribute_Tenant_TenantID]



/****** Object:  Table [dbo].[ProjectCustomAttributeValue]    Script Date: 7/10/2019 3:33:34 PM ******/
CREATE TABLE [dbo].[FundingSourceCustomAttributeValue](
	[FundingSourceCustomAttributeValueID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[FundingSourceCustomAttributeID] [int] NOT NULL,
	[AttributeValue] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_FundingSourceCustomAttributeValue_FundingSourceCustomAttributeValueID] PRIMARY KEY CLUSTERED 
(
	[FundingSourceCustomAttributeValueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[FundingSourceCustomAttributeValue]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttributeValue_FundingSourceCustomAttribute_FundingSourceCustomAttributeID] FOREIGN KEY([FundingSourceCustomAttributeID])
REFERENCES [dbo].[FundingSourceCustomAttribute] ([FundingSourceCustomAttributeID])


ALTER TABLE [dbo].[FundingSourceCustomAttributeValue] CHECK CONSTRAINT [FK_FundingSourceCustomAttributeValue_FundingSourceCustomAttribute_FundingSourceCustomAttributeID]


ALTER TABLE [dbo].[FundingSourceCustomAttributeValue]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttributeValue_FundingSourceCustomAttribute_FundingSourceCustomAttributeID_TenantID] FOREIGN KEY([FundingSourceCustomAttributeID], [TenantID])
REFERENCES [dbo].[FundingSourceCustomAttribute] ([FundingSourceCustomAttributeID], [TenantID])


ALTER TABLE [dbo].[FundingSourceCustomAttributeValue] CHECK CONSTRAINT [FK_FundingSourceCustomAttributeValue_FundingSourceCustomAttribute_FundingSourceCustomAttributeID_TenantID]


ALTER TABLE [dbo].[FundingSourceCustomAttributeValue]  WITH CHECK ADD  CONSTRAINT [FK_FundingSourceCustomAttributeValue_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])


ALTER TABLE [dbo].[FundingSourceCustomAttributeValue] CHECK CONSTRAINT [FK_FundingSourceCustomAttributeValue_Tenant_TenantID]

insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(60, 'ManageFundingSourceCustomAttributeTypeInstructions', 'Manage Funding Source Custom Attribute Type Instructions', 2),
(61, 'ManageFundingSourceCustomAttributeTypesList', 'Manage Funding Source Custom Attribute Types List', 2)

commit 