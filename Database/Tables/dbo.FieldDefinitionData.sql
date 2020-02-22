SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FieldDefinitionData](
	[FieldDefinitionDataID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[FieldDefinitionID] [int] NOT NULL,
	[FieldDefinitionDataValue] [dbo].[html] NULL,
	[FieldDefinitionLabel] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_FieldDefinitionData_FieldDefinitionDataID] PRIMARY KEY CLUSTERED 
(
	[FieldDefinitionDataID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FieldDefinitionData_FieldDefinitionDataID_TenantID] UNIQUE NONCLUSTERED 
(
	[FieldDefinitionDataID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FieldDefinitionData_FieldDefinitionID_TenantID] UNIQUE NONCLUSTERED 
(
	[FieldDefinitionID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[FieldDefinitionData]  WITH CHECK ADD  CONSTRAINT [FK_FieldDefinitionData_FieldDefinition_FieldDefinitionID] FOREIGN KEY([FieldDefinitionID])
REFERENCES [dbo].[FieldDefinition] ([FieldDefinitionID])
GO
ALTER TABLE [dbo].[FieldDefinitionData] CHECK CONSTRAINT [FK_FieldDefinitionData_FieldDefinition_FieldDefinitionID]
GO
ALTER TABLE [dbo].[FieldDefinitionData]  WITH CHECK ADD  CONSTRAINT [FK_FieldDefinitionData_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[FieldDefinitionData] CHECK CONSTRAINT [FK_FieldDefinitionData_Tenant_TenantID]
GO
ALTER TABLE [dbo].[FieldDefinitionData]  WITH CHECK ADD  CONSTRAINT [CK_FieldDefinitionData_FieldDefinitionDataValue_IsNotEmptyString] CHECK  (([FieldDefinitionDataValue]<>''))
GO
ALTER TABLE [dbo].[FieldDefinitionData] CHECK CONSTRAINT [CK_FieldDefinitionData_FieldDefinitionDataValue_IsNotEmptyString]
GO
ALTER TABLE [dbo].[FieldDefinitionData]  WITH CHECK ADD  CONSTRAINT [CK_FieldDefinitionData_FieldDefinitionLabel_IsNotEmptyString] CHECK  (([FieldDefinitionLabel]<>''))
GO
ALTER TABLE [dbo].[FieldDefinitionData] CHECK CONSTRAINT [CK_FieldDefinitionData_FieldDefinitionLabel_IsNotEmptyString]