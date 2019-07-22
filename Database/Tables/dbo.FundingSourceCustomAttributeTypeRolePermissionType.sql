SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FundingSourceCustomAttributeTypeRolePermissionType](
	[FundingSourceCustomAttributeTypeRolePermissionTypeID] [int] NOT NULL,
	[FundingSourceCustomAttributeTypeRolePermissionTypeName] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_FundingSourceCustomAttributeTypeRolePermissionType_FundingSourceCustomAttributeTypeRolePermissionTypeID] PRIMARY KEY CLUSTERED 
(
	[FundingSourceCustomAttributeTypeRolePermissionTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
