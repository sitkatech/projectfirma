SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectLocationAreaGroup](
	[ProjectLocationAreaGroupID] [int] NOT NULL,
	[ProjectLocationAreaGroupTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectLocationAreaGroup_ProjectLocationAreaGroupID] PRIMARY KEY CLUSTERED 
(
	[ProjectLocationAreaGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectLocationAreaGroup_ProjectLocationAreaGroupTypeID] UNIQUE NONCLUSTERED 
(
	[ProjectLocationAreaGroupTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectLocationAreaGroup]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocationAreaGroup_ProjectLocationAreaGroupType_ProjectLocationAreaGroupTypeID] FOREIGN KEY([ProjectLocationAreaGroupTypeID])
REFERENCES [dbo].[ProjectLocationAreaGroupType] ([ProjectLocationAreaGroupTypeID])
GO
ALTER TABLE [dbo].[ProjectLocationAreaGroup] CHECK CONSTRAINT [FK_ProjectLocationAreaGroup_ProjectLocationAreaGroupType_ProjectLocationAreaGroupTypeID]