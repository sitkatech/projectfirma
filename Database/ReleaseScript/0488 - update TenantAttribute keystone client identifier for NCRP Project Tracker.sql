update dbo.TenantAttribute set KeystoneOpenIDClientIdentifier = 'NCRPProjectTracker' where TenantID = 4
update dbo.TenantAttribute set ToolDisplayName = 'North Coast Resource Partnership Projects' where TenantID = 4
update dbo.TenantAttribute set TenantShortDisplayName = 'Projects' where TenantID = 4

update dbo.TenantAttribute set KeystoneOpenIDClientIdentifier = 'DemoProjectFirma' where TenantID = 5

-- add '(Unknown or Unspecified Organization)' Organization for NCRP
insert into dbo.Organization (TenantID, OrganizationName, OrganizationShortName, OrganizationTypeID, IsActive, UseOrganizationBoundaryForMatchmaker, IsUnknownOrUnspecified)
values (4, '(Unknown or Unspecified Organization)', 'N/A', 1095, 0, 1, 1)