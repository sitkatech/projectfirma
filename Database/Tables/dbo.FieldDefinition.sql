SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FieldDefinition](
	[FieldDefinitionID] [int] NOT NULL,
	[FieldDefinitionName] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FieldDefinitionDisplayName] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PrimaryLTInfoAreaID] [int] NOT NULL,
 CONSTRAINT [PK_FieldDefinition_FieldDefinitionID] PRIMARY KEY CLUSTERED 
(
	[FieldDefinitionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FieldDefinition_FieldDefinitionDisplayName] UNIQUE NONCLUSTERED 
(
	[FieldDefinitionDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FieldDefinition_FieldDefinitionName] UNIQUE NONCLUSTERED 
(
	[FieldDefinitionName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[FieldDefinition]  WITH CHECK ADD  CONSTRAINT [FK_FieldDefinition_LTInfoArea_PrimaryLTInfoAreaID_LTInfoAreaID] FOREIGN KEY([PrimaryLTInfoAreaID])
REFERENCES [dbo].[LTInfoArea] ([LTInfoAreaID])
GO
ALTER TABLE [dbo].[FieldDefinition] CHECK CONSTRAINT [FK_FieldDefinition_LTInfoArea_PrimaryLTInfoAreaID_LTInfoAreaID]