SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProposedProjectNote](
	[ProposedProjectNoteID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProposedProjectID] [int] NOT NULL,
	[Note] [varchar](8000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CreatePersonID] [int] NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdatePersonID] [int] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_ProposedProjectNote_ProposedProjectNoteID] PRIMARY KEY CLUSTERED 
(
	[ProposedProjectNoteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProposedProjectNote]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectNote_Person_CreatePersonID_PersonID] FOREIGN KEY([CreatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[ProposedProjectNote] CHECK CONSTRAINT [FK_ProposedProjectNote_Person_CreatePersonID_PersonID]
GO
ALTER TABLE [dbo].[ProposedProjectNote]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectNote_Person_CreatePersonID_TenantID_PersonID_TenantID] FOREIGN KEY([CreatePersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO
ALTER TABLE [dbo].[ProposedProjectNote] CHECK CONSTRAINT [FK_ProposedProjectNote_Person_CreatePersonID_TenantID_PersonID_TenantID]
GO
ALTER TABLE [dbo].[ProposedProjectNote]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectNote_Person_UpdatePersonID_PersonID] FOREIGN KEY([UpdatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[ProposedProjectNote] CHECK CONSTRAINT [FK_ProposedProjectNote_Person_UpdatePersonID_PersonID]
GO
ALTER TABLE [dbo].[ProposedProjectNote]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectNote_Person_UpdatePersonID_TenantID_PersonID_TenantID] FOREIGN KEY([UpdatePersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO
ALTER TABLE [dbo].[ProposedProjectNote] CHECK CONSTRAINT [FK_ProposedProjectNote_Person_UpdatePersonID_TenantID_PersonID_TenantID]
GO
ALTER TABLE [dbo].[ProposedProjectNote]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectNote_ProposedProject_ProposedProjectID] FOREIGN KEY([ProposedProjectID])
REFERENCES [dbo].[ProposedProject] ([ProposedProjectID])
GO
ALTER TABLE [dbo].[ProposedProjectNote] CHECK CONSTRAINT [FK_ProposedProjectNote_ProposedProject_ProposedProjectID]
GO
ALTER TABLE [dbo].[ProposedProjectNote]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectNote_ProposedProject_ProposedProjectID_TenantID] FOREIGN KEY([ProposedProjectID], [TenantID])
REFERENCES [dbo].[ProposedProject] ([ProposedProjectID], [TenantID])
GO
ALTER TABLE [dbo].[ProposedProjectNote] CHECK CONSTRAINT [FK_ProposedProjectNote_ProposedProject_ProposedProjectID_TenantID]
GO
ALTER TABLE [dbo].[ProposedProjectNote]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectNote_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProposedProjectNote] CHECK CONSTRAINT [FK_ProposedProjectNote_Tenant_TenantID]