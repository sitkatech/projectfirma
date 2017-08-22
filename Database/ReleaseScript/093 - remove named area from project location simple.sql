alter table dbo.Project drop constraint FK_Project_ProjectLocationArea_ProjectLocationAreaID
alter table dbo.Project drop constraint FK_Project_ProjectLocationArea_ProjectLocationAreaID_TenantID
alter table dbo.Project drop constraint CK_Project_ProjectLocationPointXorProjectLocationArea
alter table dbo.ProposedProject drop constraint FK_ProposedProject_ProjectLocationArea_ProjectLocationAreaID
alter table dbo.ProposedProject drop constraint FK_ProposedProject_ProjectLocationArea_ProjectLocationAreaID_TenantID
alter table dbo.ProposedProject drop constraint CK_ProposedProject_ProjectLocationPointXorProposedProjectLocationArea
alter table dbo.ProjectUpdate drop constraint FK_ProjectUpdate_ProjectLocationArea_ProjectLocationAreaID
alter table dbo.ProjectUpdate drop constraint FK_ProjectUpdate_ProjectLocationArea_ProjectLocationAreaID_TenantID
alter table dbo.ProjectUpdate drop constraint CK_ProjectUpdate_ProjectUpdateLocationPointXorProjectUpdateLocationArea

go

-- Update project, proposed project, and project update and set instances where the project area is used for simple to have
-- a point with the centroid of the project area
update dbo.Project
set
	ProjectLocationSimpleTypeID = 1,
	ProjectLocationPoint = w.WatershedFeature.STCentroid()
from
	dbo.Project p
	join dbo.ProjectLocationArea pla on p.ProjectLocationAreaID = pla.ProjectLocationAreaID
	join dbo.Watershed w on w.WatershedID = pla.WatershedID
where p.ProjectLocationSimpleTypeID = 2

update dbo.ProposedProject
set
	ProjectLocationSimpleTypeID = 1,
	ProjectLocationPoint = w.WatershedFeature.STCentroid()
from
	dbo.ProposedProject p
	join dbo.ProjectLocationArea pla on p.ProjectLocationAreaID = pla.ProjectLocationAreaID
	join dbo.Watershed w on w.WatershedID = pla.WatershedID
where p.ProjectLocationSimpleTypeID = 2

update dbo.ProjectUpdate
set
	ProjectLocationSimpleTypeID = 1,
	ProjectLocationPoint = w.WatershedFeature.STCentroid()
from
	dbo.ProjectUpdate p
	join dbo.ProjectLocationArea pla on p.ProjectLocationAreaID = pla.ProjectLocationAreaID
	join dbo.Watershed w on w.WatershedID = pla.WatershedID
where p.ProjectLocationSimpleTypeID = 2

go

alter table dbo.Project drop column ProjectLocationAreaID
alter table dbo.ProposedProject drop column ProjectLocationAreaID
alter table dbo.ProjectUpdate drop column ProjectLocationAreaID

drop table dbo.ProjectLocationAreaStateProvince
drop table dbo.ProjectLocationAreaWatershed
drop table dbo.ProjectLocationArea
drop table dbo.ProjectLocationAreaGroup
drop table dbo.ProjectLocationAreaGroupType
