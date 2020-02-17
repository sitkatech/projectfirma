SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FieldDefinitionDefault](
	[FieldDefinitionDefaultID] [int] IDENTITY(1,1) NOT NULL,
	[FieldDefinitionID] [int] NOT NULL,
	[DefaultDefinition] [dbo].[html] NOT NULL,
 CONSTRAINT [PK_FieldDefinitionDefault_FieldDefinitionDefaultID] PRIMARY KEY CLUSTERED 
(
	[FieldDefinitionDefaultID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FieldDefinitionDefault_FieldDefinitionID] UNIQUE NONCLUSTERED 
(
	[FieldDefinitionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[FieldDefinitionDefault]  WITH CHECK ADD  CONSTRAINT [FK_FieldDefinitionDefault_FieldDefinition_FieldDefinitionID] FOREIGN KEY([FieldDefinitionID])
REFERENCES [dbo].[FieldDefinition] ([FieldDefinitionID])
GO
ALTER TABLE [dbo].[FieldDefinitionDefault] CHECK CONSTRAINT [FK_FieldDefinitionDefault_FieldDefinition_FieldDefinitionID]