
CREATE TABLE [dbo].[AttachmentTypeRole](
	[AttachmentTypeRoleID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[AttachmentTypeID] [int] NOT NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [PK_AttachmentTypeRole_AttachmentTypeRoleID] PRIMARY KEY CLUSTERED 
(
	[AttachmentTypeRoleID] ASC
)
) 

ALTER TABLE [dbo].[AttachmentTypeRole] ADD  CONSTRAINT [FK_AttachmentTypeRole_AttachmentType_AttachmentTypeID] FOREIGN KEY([AttachmentTypeID])
REFERENCES [dbo].[AttachmentType] ([AttachmentTypeID])

ALTER TABLE [dbo].[AttachmentTypeRole] ADD  CONSTRAINT [FK_AttachmentTypeRole_AttachmentType_AttachmentTypeID_TenantID] FOREIGN KEY([AttachmentTypeID], [TenantID])
REFERENCES [dbo].[AttachmentType] ([AttachmentTypeID], [TenantID])

ALTER TABLE [dbo].[AttachmentTypeRole] ADD  CONSTRAINT [FK_AttachmentTypeRole_Role_RoleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])

ALTER TABLE [dbo].[AttachmentTypeRole] ADD  CONSTRAINT [FK_AttachmentTypeRole_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])

INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(389, N'AttachmentTypeViewableBy', N'Attachment Type Viewable By')

insert into dbo.FieldDefinitionDefault (FieldDefinitionID, DefaultDefinition)
values
(389, '<p>This setting controls which users (i.e., which user roles) can view files of a given attachment type. Administrators can set this property within the Attachment Type editor.</p>')



GO


-- add Normal role
insert into dbo.AttachmentTypeRole (AttachmentTypeID, TenantID, RoleID)
select AttachmentTypeID, TenantID, 2 from dbo.AttachmentType
-- add Unassigned role
insert into dbo.AttachmentTypeRole (AttachmentTypeID, TenantID, RoleID)
select AttachmentTypeID, TenantID, 7 from dbo.AttachmentType
-- add Project Steward role
insert into dbo.AttachmentTypeRole (AttachmentTypeID, TenantID, RoleID)
select AttachmentTypeID, TenantID, 9 from dbo.AttachmentType
-- add null for anonymous
insert into dbo.AttachmentTypeRole (AttachmentTypeID, TenantID, RoleID)
select AttachmentTypeID, TenantID, null from dbo.AttachmentType