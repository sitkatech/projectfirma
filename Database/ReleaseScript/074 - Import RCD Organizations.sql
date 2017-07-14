create table #RCDOrgs
(
	OrganizationName varchar(500) not null,
	OrganizationAbbreviation varchar(100) not null,
	OrganizationType varchar(100) not null,
	OrganizationID int null,
	KeystoneOrganizationGuid uniqueidentifier null
)
GO

insert into #RCDOrgs(OrganizationName, OrganizationAbbreviation, OrganizationType)
values
('Coarsegold Resource Conservation District', 'Coarsegold RCD', 'Resource Conservation District'),
('Honey Lake Valley Resource Conservation District', 'Honey Lake Valley RCD', 'Resource Conservation District'),
('Humboldt County Resource Conservation District', 'Humboldt County RCD', 'Resource Conservation District'),
('Yolo County Resource Conservation District', 'Yolo County RCD', 'Resource Conservation District'),
('Gold Ridge Resource Conservation District', 'Gold Ridge RCD', 'Resource Conservation District'),
('Mendocino County Resource Conservation District', 'Mendocino County RCD', 'Resource Conservation District'),
('Placer County Resource Conservation District', 'Placer County RCD', 'Resource Conservation District'),
('Sonoma Resource Conservation District', 'Sonoma RCD', 'Resource Conservation District'),
('Alameda County Resource Conservation District', 'Alameda County RCD', 'Resource Conservation District'),
('Cachuma Resource Conservation District', 'Cachuma RCD', 'Resource Conservation District'),
('Contra Costa Resource Conservation District', 'Contra Costa RCD', 'Resource Conservation District'),
('Inland Empire Resource Conservation District', 'Inland Empire RCD', 'Resource Conservation District'),
('Marin Resource Conservation District', 'Marin RCD', 'Resource Conservation District'),
('Napa County Resource Conservation District', 'Napa County RCD', 'Resource Conservation District'),
('San Mateo County Resource Conservation District', 'San Mateo County RCD', 'Resource Conservation District'),
('Santa Monica Mountains Resource Conservation District', 'Santa Monica Mountains RCD', 'Resource Conservation District'),
('Trinity County Resource Conservation District', 'Trinity County RCD', 'Resource Conservation District'),
('Upper Salinas - Las Tablas Resource Conservation District', 'Upper Salinas - Las Tablas RCD', 'Resource Conservation District'),
('Federal Emergency Management Agency', 'FEMA', 'Federal'),
('U.S. Army Corps of Engineers', 'USACOE', 'Federal'),
('U.S. Bureau of Land Management', 'BLM', 'Federal'),
('U.S. Bureau of Reclamation', 'USBOR', 'Federal'),
('U.S. Department of Agriculture - Agricultural Research Service', 'USDA ARS', 'Federal'),
('U.S. Department of Housing and Urban Development', 'HUD', 'Federal'),
('U.S. Environmental Protection Agency', 'USEPA', 'Federal'),
('U.S. Fish and Wildlife Service (USFWS)', 'USFWS', 'Federal'),
('U.S. Forest Service - Lake Tahoe Basin Management Unit', 'USFS - LTBMU', 'Federal'),
('U.S. Forest Service - Pacific Southwest Region', 'USFS - PSW', 'Federal'),
('NOAA Fisheries', 'NOAA', 'Federal'),
('U.S. Geological Survey', 'USGS', 'Federal'),
('U.S. Natural Resource Conservation Service', 'NRCS', 'Federal'),
('Sonoma County, CA', 'SONCO', 'Local'),
('Mendocino County, CA', 'MENCO', 'Local'),
('Marin County, CA', 'MARCO', 'Local'),
('Contra Costa County, CA', 'CONCO', 'Local'),
('San Mateo County, CA', 'SAMCO', 'Local'),
('Alameda County, CA', 'ALACO', 'Local'),
('Santa Barabara County, CA', 'SANBACO', 'Local'),
('Trinity County, CA', 'TRICO', 'Local'),
('Lassen County, CA', 'LASCO', 'Local'),
('Napa County', 'NAPCO', 'Local'),
('Humboldt County, CA', 'HUMCO', 'Local'),
('Los Angeles County, CA', 'LOSANCO', 'Local'),
('San Bernardino County, CA', 'SANBECO', 'Local'),
('San Luis Obispo County, CA', 'SALOCO', 'Local'),
('Yolo County, CA', 'YOLCO', 'Local'),
('Madera County, CA', 'MADCO', 'Local'),
('California Native Plant Society', 'CNPS', 'Local'),
('Nevada Tahoe Conservation District', 'NTCD', 'Local'),
('Placer County, CA', 'PLCO', 'Local'),
('Mendocino County Fire Safe Council', 'MCFSC', 'Local'),
('Sierra Fire Protection District', 'SFPD', 'Local'),
('Tahoe Resource Conservation District', 'TRCD', 'Resource Conservation District'),
('Sonoma County Agricultural Preservation and Open Space District', 'SCAPOSD', 'Local'),
('North Coast Resource Partnership', 'NCRP', 'Local'),
('California Association of Resource Conservation Districts', 'CARCD', 'Private'),
('Carbon Cycle Institute', 'CCI', 'Private'),
('Trout Unlimited', 'TU', 'Private'),
('Environmental Incentives', 'EI', 'Private'),
('Private party', 'Private', 'Private'),
('Sustainable Conservation ', 'SUCON', 'Private'),
('The Nature Conservancy', 'TNC', 'Private'),
('San Francisco Estuary Institute', 'SFEI', 'Private'),
('Sitka Technology Group', 'Sitka', 'Private'),
('Marin Agricultural Land Trust', 'MALT', 'Private'),
('California Farm Bureau Federation', 'CFBF', 'Private'),
('California Climate & Action Network', 'CalCAN', 'Private'),
('California Department of Food and Agriculture', 'CDFA', 'State of California'),
('California Air Resources Board', 'CARB', 'State of California'),
('California Conservation Corps', 'CCC', 'State of California'),
('California Department of Conservation', 'DOC', 'State of California'),
('California Department of Fish & Wildlife', 'CDFW', 'State of California'),
('California Department of Forestry and Fire Protection', 'Cal Fire', 'State of California'),
('California Department of Parks and Recreation', 'CDPR', 'State of California'),
('California Department of Transportation', 'Caltrans', 'State of California'),
('California Department of Water Resources', 'DWR', 'State of California'),
('California Division of Boating and Waterways', 'DBW', 'State of California'),
('California Environmental Protection Agency', 'Cal EPA', 'State of California'),
('California Fire Safe Council', 'CFSC', 'State of California'),
('Lahontan Regional Water Quality Control Board', 'LRWQCB', 'State of California'),
('North Coast Regional Water Quality Control Board', 'NCRWQCB', 'State of California'),
('San Francisco Regional Water Quality Control Board', 'SFRWQCB', 'State of California'),
('Central Coast Regional Water Quality Control Board', 'CCRWQCB', 'State of California'),
('Central Valley Regional Water Quality Control Board', 'CVRWQCB', 'State of California'),
('Colorado River Regional Water Quality Control Board', 'CRRWQCB', 'State of California'),
('California San Diego Regional Water Quality Control Board', 'SDRWQCB', 'State of California'),
('Los Angeles Regional Water Quality Control Board', 'LARWQCB', 'State of California'),
('California Natural Resources Agency', 'CNRA', 'State of California'),
('California State Lands Commission', 'California SLC', 'State of California'),
('State Water Resources Control Board', 'SWRCB', 'State of California'),
('Strategic Growth Council', 'SGC', 'State of California'),
('California Tahoe Conservancy', 'CTC', 'State of California'),
('Sierra Nevada Conservancy', 'SNC', 'State of California'),
('Santa Monica Mountains Conservancy', 'SMMC', 'State of California'),
('San Joaquin River Conservancy', 'SJRC', 'State of California'),
('Sacramento-San Joaquin Delta Conservancy', 'SSJDC', 'State of California'),
('State Coastal Conservancy', 'SCC', 'State of California'),
('Wildlife Conservation Board', 'WCB', 'State of California'),
('University of California, Davis', 'UC Davis', 'State of California'),
('Colorado State University', 'CSU', 'Other')

update dbo.OrganizationType
set OrganizationTypeName = 'State of California', OrganizationTypeAbbreviation = 'CA'
where TenantID = 3 and OrganizationTypeName = 'State'

insert into dbo.OrganizationType(OrganizationTypeName, OrganizationTypeAbbreviation, LegendColor, TenantID)
values
('Resource Conservation District', 'RCD', '#2ca02c', 3),
('Federal', 'FED', '#1f77b4', 3),
('Other', 'Other', '#dc143c', 3)

alter table dbo.Organization alter column OrganizationAbbreviation varchar(50) null

insert into dbo.Organization(OrganizationName, OrganizationAbbreviation, IsActive, OrganizationTypeID, TenantID)
select ro.OrganizationName, ro.OrganizationAbbreviation, 1 as IsActive, ot.OrganizationTypeID, 3 as TenantID
from #RCDOrgs ro
join dbo.OrganizationType ot on ro.OrganizationType = ot.OrganizationTypeName and ot.TenantID = 3
left join dbo.Organization o on ro.OrganizationName = o.OrganizationName and o.TenantID = 3
where o.OrganizationID is null

update o
set o.OrganizationTypeID = ot.OrganizationTypeID
from #RCDOrgs ro
join dbo.OrganizationType ot on ro.OrganizationType = ot.OrganizationTypeName and ot.TenantID = 3
join dbo.Organization o on ro.OrganizationName = o.OrganizationName

update o
set o.OrganizationGuid = ko.OrganizationGuid
from dbo.Organization o
join Keystone.dbo.Organization ko on o.OrganizationName = ko.FullName
where o.TenantID = 3
