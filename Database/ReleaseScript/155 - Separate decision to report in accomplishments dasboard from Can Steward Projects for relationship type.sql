
alter table dbo.RelationshipType add ReportInAccomplishmentsDashboard bit null;
go
update rt
set
	ReportInAccomplishmentsDashboard = CanStewardProjects
from dbo.RelationshipType rt;
go
alter table dbo.RelationshipType alter column ReportInAccomplishmentsDashboard bit not null;
