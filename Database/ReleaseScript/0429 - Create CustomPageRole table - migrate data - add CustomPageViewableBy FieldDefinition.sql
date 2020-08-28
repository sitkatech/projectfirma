INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(357, N'CustomPageViewableBy', N'Custom Page Viewable By')

insert into dbo.FieldDefinitionDefault (FieldDefinitionID, DefaultDefinition)
values (357, 'Which roles can view a specific custom page. If no roles are selected, the page will be disabled.')


create table dbo.CustomPageRole (
	CustomPageRoleID int identity(1,1) not null constraint PK_CustomPageRole_CustomPageRoleID primary key,
	TenantID int not null constraint FK_CustomPageRole_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	CustomPageID int not null constraint FK_CustomPageRole_CustomPage_CustomPageID foreign key references dbo.CustomPage(CustomPageID),
	RoleID int null constraint FK_CustomPageRole_Role_RoleID foreign key references dbo.Role(RoleID)
)
go

DECLARE @adminRoleID int;         
SELECT @adminRoleID = (select RoleID from dbo.[Role] where RoleName = 'Admin');

DECLARE @normalRoleID int;         
SELECT @normalRoleID = (select RoleID from dbo.[Role] where RoleName = 'Normal');  

DECLARE @unassignedRoleID int;         
SELECT @unassignedRoleID = (select RoleID from dbo.[Role] where RoleName = 'Unassigned');  

DECLARE @sitkaAdminRoleID int;         
SELECT @sitkaAdminRoleID = (select RoleID from dbo.[Role] where RoleName = 'SitkaAdmin');  

DECLARE @projectStewardID int;         
SELECT @projectStewardID = (select RoleID from dbo.[Role] where RoleName = 'ProjectSteward'); 

-- CustomPageDisplayTypeID = 2 is public => Admin, Normal, Unassigned, ProjectSteward and no role (null RoleID) can view
insert into dbo.CustomPageRole (TenantID, CustomPageID, RoleID)
select TenantID, CustomPageID, @adminRoleID from dbo.CustomPage cp where cp.CustomPageDisplayTypeID = 2

insert into dbo.CustomPageRole (TenantID, CustomPageID, RoleID)
select TenantID, CustomPageID, @normalRoleID from dbo.CustomPage cp where cp.CustomPageDisplayTypeID = 2

insert into dbo.CustomPageRole (TenantID, CustomPageID, RoleID)
select TenantID, CustomPageID, @unassignedRoleID from dbo.CustomPage cp where cp.CustomPageDisplayTypeID = 2

insert into dbo.CustomPageRole (TenantID, CustomPageID, RoleID)
select TenantID, CustomPageID, @projectStewardID from dbo.CustomPage cp where cp.CustomPageDisplayTypeID = 2

insert into dbo.CustomPageRole (TenantID, CustomPageID, RoleID)
select TenantID, CustomPageID, null from dbo.CustomPage cp where cp.CustomPageDisplayTypeID = 2

-- CustomPageDisplayTypeID = 3 is protected => Admin, Normal and ProjectSteward can view
insert into dbo.CustomPageRole (TenantID, CustomPageID, RoleID)
select TenantID, CustomPageID, @adminRoleID from dbo.CustomPage cp where cp.CustomPageDisplayTypeID = 3

insert into dbo.CustomPageRole (TenantID, CustomPageID, RoleID)
select TenantID, CustomPageID, @normalRoleID from dbo.CustomPage cp where cp.CustomPageDisplayTypeID = 3

insert into dbo.CustomPageRole (TenantID, CustomPageID, RoleID)
select TenantID, CustomPageID, @projectStewardID from dbo.CustomPage cp where cp.CustomPageDisplayTypeID = 3


-- drop CustomPageDisplayTypeID from CustomPage and drop CustomPageDisplayType table
alter table dbo.CustomPage drop FK_CustomPage_CustomPageDisplayType_CustomPageDisplayTypeID
alter table dbo.CustomPage drop column CustomPageDisplayTypeID
drop table dbo.CustomPageDisplayType

-- drop field definition
delete from dbo.FieldDefinitionData where FieldDefinitionID = 253
delete from dbo.FieldDefinitionDefault  where FieldDefinitionID = 253
delete from dbo.FieldDefinition  where FieldDefinitionID = 253