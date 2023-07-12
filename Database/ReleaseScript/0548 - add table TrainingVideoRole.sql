
CREATE TABLE [dbo].[TrainingVideoRole](
	[TrainingVideoRoleID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[TrainingVideoID] [int] NOT NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [PK_TrainingVideoRole_TrainingVideoRoleID] PRIMARY KEY CLUSTERED 
(
	[TrainingVideoRoleID] ASC
)
) 

ALTER TABLE [dbo].[TrainingVideoRole] ADD  CONSTRAINT [FK_TrainingVideoRole_TrainingVideo_TrainingVideoID] FOREIGN KEY([TrainingVideoID])
REFERENCES [dbo].[TrainingVideo] ([TrainingVideoID])

ALTER TABLE [dbo].[TrainingVideoRole] ADD  CONSTRAINT [FK_TrainingVideoRole_TrainingVideo_TrainingVideoID_TenantID] FOREIGN KEY([TrainingVideoID], [TenantID])
REFERENCES [dbo].[TrainingVideo] ([TrainingVideoID], [TenantID])

ALTER TABLE [dbo].[TrainingVideoRole] ADD  CONSTRAINT [FK_TrainingVideoRole_Role_RoleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])

ALTER TABLE [dbo].[TrainingVideoRole] ADD  CONSTRAINT [FK_TrainingVideoRole_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])

INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(388, N'TrainingVideoViewableBy', N'Training Video Viewable By')

insert into dbo.FieldDefinitionDefault (FieldDefinitionID, DefaultDefinition)
values
(388, '<p>This setting controls which users (i.e., which user roles) can view a given training video. Administrators can set this property within the Training Video editor.</p>')



GO


-- add Normal role
insert into dbo.TrainingVideoRole (TrainingVideoID, TenantID, RoleID)
select TrainingVideoID, TenantID, 2 from dbo.TrainingVideo
-- add Unassigned role
insert into dbo.TrainingVideoRole (TrainingVideoID, TenantID, RoleID)
select TrainingVideoID, TenantID, 7 from dbo.TrainingVideo
-- add Project Steward role
insert into dbo.TrainingVideoRole (TrainingVideoID, TenantID, RoleID)
select TrainingVideoID, TenantID, 9 from dbo.TrainingVideo
-- add null for anonymous
insert into dbo.TrainingVideoRole (TrainingVideoID, TenantID, RoleID)
select TrainingVideoID, TenantID, null from dbo.TrainingVideo