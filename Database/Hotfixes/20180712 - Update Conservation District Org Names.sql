UPDATE dbo.Organization SET OrganizationShortName = REPLACE (OrganizationShortName, ' SCD', ' CD')
where TenantID = 9

UPDATE dbo.Organization SET OrganizationShortName = REPLACE (OrganizationShortName, ' SWCD', ' CD')
where TenantID = 9

UPDATE dbo.Organization SET OrganizationShortName = 'Nez Perce CD', OrganizationName = 'Nez Perce Conservation District'
where TenantID = 9 and OrganizationGuid = 'F66DBAA2-3F8B-4592-805E-67BD79D3142A'


UPDATE  dbo.Organization SET OrganizationName = REPLACE (OrganizationName, 'Soil & Water Conservation District', 'Conservation District')
where TenantID = 9 AND OrganizationName LIKE '%Soil & Water Conservation District'; 

UPDATE  dbo.Organization SET OrganizationName = replace(OrganizationName, 'Soil and Water Conservation District', 'Conservation District')
where TenantID = 9 AND OrganizationName LIKE '%Soil and Water Conservation District'; 

UPDATE  dbo.Organization SET OrganizationName = replace(OrganizationName, 'Soil Conservation District', 'Conservation District')
where TenantID = 9 AND OrganizationName LIKE '%Soil Conservation District'; 
