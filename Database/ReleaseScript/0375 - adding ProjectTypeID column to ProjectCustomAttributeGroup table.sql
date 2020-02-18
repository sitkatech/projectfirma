--begin tran

create table dbo.ProjectCustomAttributeGroupProjectCategory(
	ProjectCustomAttributeGroupProjectCategoryID int identity(1,1) not null constraint PK_ProjectCustomAttributeGroupProjectCategory_ProjectCustomAttributeGroupProjectCategoryID primary key,
	TenantID int not null constraint FK_ProjectCustomAttributeGroupProjectCategory_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	ProjectCustomAttributeGroupID int not null constraint FK_ProjectCustomAttributeGroupProjectCategory_ProjectCustomAttributeGroup_ProjectCustomAttributeGroupID foreign key references dbo.ProjectCustomAttributeGroup(ProjectCustomAttributeGroupID),
	ProjectCategoryID int not null constraint FK_ProjectCustomAttributeGroupProjectCategory_ProjectCategory_ProjectCategoryID foreign key references dbo.ProjectCategory(ProjectCategoryID)
)


alter table dbo.ProjectCustomAttributeGroupProjectCategory add constraint FK_ProjectCustomAttributeGroupProjectCategory_ProjectCustomAttributeGroup_ProjectCustomAttributeGroupID_TenantID foreign key (ProjectCustomAttributeGroupID, TenantID) references dbo.ProjectCustomAttributeGroup(ProjectCustomAttributeGroupID, TenantID)



insert into dbo.ProjectCustomAttributeGroupProjectCategory (TenantID, ProjectCustomAttributeGroupID, ProjectCategoryID)
	select 
			 pcag.TenantID as TenantID,
			 pcag.ProjectCustomAttributeGroupID as ProjectCustomAttributeGroupID,
			 1 as ProjectCategoryID
	from 
		dbo.ProjectCustomAttributeGroup as pcag



--rollback tran

