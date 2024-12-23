-- #1
select * from dbo.project p
join dbo.ProjectOrganization po on p.projectid = po.ProjectID
join dbo.OrganizationRelationshipType ort on po.OrganizationRelationshipTypeID = ort.OrganizationRelationshipTypeID
join dbo.Organization o on po.OrganizationID = o.OrganizationID
join dbo.OrganizationType ot on o.OrganizationTypeID = ot.OrganizationTypeID
where p.TenantID = 4 
and ort.OrganizationRelationshipTypeName = 'Project Sponsor' 
and ot.OrganizationTypeName in ( 'CA State Indian Tribe', 'Federally Recognized Indian Tribe')
and p.ImplementationStartYear >= 2024
and p.projectid not in (select pp.projectid from dbo.project pp join dbo.ProjectOrganization pso on pp.projectid = pso.ProjectID where pso.OrganizationID = 7125  and OrganizationRelationshipTypeID = 58)


--#2
select * from dbo.project p
join dbo.Solicitation s on p.SolicitationID = s.SolicitationID
where p.tenantid = 4
and (SolicitationName like '%IRWM%' or SolicitationName like '%RFFC Demonstration%')
and p.ProjectID not in (select pp.ProjectID from dbo.project pp
join dbo.ProjectOrganization po on p.projectid = po.ProjectID
join dbo.OrganizationRelationshipType ort on po.OrganizationRelationshipTypeID = ort.OrganizationRelationshipTypeID
join dbo.Organization o on po.OrganizationID = o.OrganizationID
join dbo.OrganizationType ot on o.OrganizationTypeID = ot.OrganizationTypeID
where p.TenantID = 4 
and ort.OrganizationRelationshipTypeName = 'Project Sponsor' 
and ot.OrganizationTypeName in ( 'CA State Indian Tribe', 'Federally Recognized Indian Tribe')
and pp.ImplementationStartYear >= 2024 )
and p.projectid not in (select pp.projectid from dbo.project pp join dbo.ProjectOrganization pso on pp.projectid = pso.ProjectID where pso.OrganizationID = 6605  and OrganizationRelationshipTypeID = 58)


--#3
select * from dbo.project p 
join dbo.Solicitation s on p.SolicitationID = s.SolicitationID
where p.tenantid = 4
and SolicitationName like '%Technical Assistance%'
and p.ImplementationStartYear <= 2023
and p.projectid not in (select pp.projectid from dbo.project pp join dbo.ProjectOrganization pso on pp.projectid = pso.ProjectID where pso.OrganizationID = 6601  and OrganizationRelationshipTypeID = 58)



--#1 California Indian Environmental Alliance = 7125
insert into dbo.ProjectOrganization (TenantID, ProjectID, OrganizationID, OrganizationRelationshipTypeID)
select 4, p.ProjectID, 7125, 58 
from dbo.project p
join dbo.ProjectOrganization po on p.projectid = po.ProjectID
join dbo.OrganizationRelationshipType ort on po.OrganizationRelationshipTypeID = ort.OrganizationRelationshipTypeID
join dbo.Organization o on po.OrganizationID = o.OrganizationID
join dbo.OrganizationType ot on o.OrganizationTypeID = ot.OrganizationTypeID
where p.TenantID = 4 
and ort.OrganizationRelationshipTypeName = 'Project Sponsor' 
and ot.OrganizationTypeName in ( 'CA State Indian Tribe', 'Federally Recognized Indian Tribe')
and p.ImplementationStartYear >= 2024 
and p.projectid not in (select pp.projectid from dbo.project pp join dbo.ProjectOrganization pso on pp.projectid = pso.ProjectID where pso.OrganizationID = 7125  and OrganizationRelationshipTypeID = 58)

-- County of Humboldt = 6808
insert into dbo.ProjectOrganization (TenantID, ProjectID, OrganizationID, OrganizationRelationshipTypeID)
select 4, p.ProjectID, 6808, 58 
from dbo.project p
join dbo.Solicitation s on p.SolicitationID = s.SolicitationID
where p.tenantid = 4
and (SolicitationName like '%IRWM%' or SolicitationName like '%RFFC Demonstration%')
and p.ProjectID not in (select pp.ProjectID from dbo.project pp
join dbo.ProjectOrganization po on p.projectid = po.ProjectID
join dbo.OrganizationRelationshipType ort on po.OrganizationRelationshipTypeID = ort.OrganizationRelationshipTypeID
join dbo.Organization o on po.OrganizationID = o.OrganizationID
join dbo.OrganizationType ot on o.OrganizationTypeID = ot.OrganizationTypeID
where p.TenantID = 4 
and ort.OrganizationRelationshipTypeName = 'Project Sponsor' 
and ot.OrganizationTypeName in ( 'CA State Indian Tribe', 'Federally Recognized Indian Tribe')
and pp.ImplementationStartYear >= 2024 )
and p.projectid not in (select pp.projectid from dbo.project pp join dbo.ProjectOrganization pso on pp.projectid = pso.ProjectID where pso.OrganizationID = 6605  and OrganizationRelationshipTypeID = 58)



-- #3 NCRP = 6601
insert into dbo.ProjectOrganization (TenantID, ProjectID, OrganizationID, OrganizationRelationshipTypeID)
select 4, p.ProjectID, 6601, 58
from dbo.project p 
join dbo.Solicitation s on p.SolicitationID = s.SolicitationID
where p.tenantid = 4
and SolicitationName like '%Technical Assistance%'
and p.ImplementationStartYear <= 2023
and p.projectid not in (select pp.projectid from dbo.project pp join dbo.ProjectOrganization pso on pp.projectid = pso.ProjectID where pso.OrganizationID = 7125  and OrganizationRelationshipTypeID = 58)
