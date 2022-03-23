alter table dbo.Project add OtherPartners varchar(500) null
alter table dbo.ProjectUpdate add OtherPartners varchar(500) null

INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(376, N'OtherPartners', N'Other Partners')

insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
values (376, 'Other Partners')

insert into dbo.FieldDefinitionData(FieldDefinitionID, TenantID, FieldDefinitionLabel)
values (376, 4, 'Local and/or Political Support')

go

update dbo.Project set OtherPartners = 'Sonoma Water, Sonoma RCD, Sonoma-Marin Saving Water Partnership, Daily Acts' where ProjectID = 14079
update dbo.Project set OtherPartners = 'City of Arcata, City of Eureka, City of Blue Lake, McKinleyville CSD, Manila CSD' where ProjectID = 14080
update dbo.Project set OtherPartners = 'USDA Rural Development' where ProjectID = 14085
update dbo.Project set OtherPartners = 'Shasta Valley RCD, CDFW, USFWS, NRCS, National Fish & Wildlife Foundation' where ProjectID = 14150
update dbo.Project set OtherPartners = 'Siskiyou County RCD, DFW' where ProjectID = 14004
update dbo.Project set OtherPartners = 'Green Pastures Vineyards, Circuit Rider, Hurst Firewood LLC, King Ranch, Chavalier Vineyard Management Co., Summerhome Park Association, Dutton Property Management, Shelterbelt Builders, Inc.' where ProjectID = 14154
update dbo.Project set OtherPartners = 'Humboldt Community Services District' where ProjectID = 14157
update dbo.Project set OtherPartners = 'Yager/ Van Duzen Environmental Stewards' where ProjectID = 14159
update dbo.Project set OtherPartners = 'Land owners' where ProjectID = 14160
update dbo.Project set OtherPartners = 'Redwood State and National Parks, DFW, USFWS, NCRWQCB, Redwood Creek Landowners'' Association' where ProjectID = 14163
update dbo.Project set OtherPartners = 'County of Humboldt, NRCS, SHN, Inc., NOAA, Landowner, WCB, DFW, US ACOE Ducks Unlimited' where ProjectID = 14164
update dbo.Project set OtherPartners = 'landowners, Gualala Redwoods, Inc., Preservation Ranch, Redwood Coast Land Conservancy, Kashia Band of Pomo Indians Stewarts Point Rancheria, USGS, Mendocino Redwoods Company' where ProjectID = 14165
update dbo.Project set OtherPartners = 'City of Rohnert Park, Sonoma Water Agency' where ProjectID = 14168
update dbo.Project set OtherPartners = 'Five Counties Salmonid Conservation Program' where ProjectID = 14169
update dbo.Project set OtherPartners = 'Crescent City and Elk Valley Rancheria' where ProjectID = 14078
update dbo.Project set OtherPartners = 'CDFW' where ProjectID = 14076
update dbo.Project set OtherPartners = 'Cal Fire & Whitethorn VFD, SWRCB, Southern Humboldt FSC, Trout Unlimited, Salmonid Restoration Federation' where ProjectID = 14074
update dbo.Project set OtherPartners = 'Mattole Salmon Group, BL, CDFW, USFWS, SCC, Humboldt County, SWRCB, NMFS' where ProjectID = 14077
update dbo.Project set OtherPartners = 'Albion Little River FPD, Mendocino County' where ProjectID = 14090
update dbo.Project set OtherPartners = 'District 5 County Supervisor, City of Etna, Quartz Valley Indian Tribe, Scott River Watershed Council, Northern California Resource Center, EFM' where ProjectID = 14081
update dbo.Project set OtherPartners = 'Smith River Fire Protection District' where ProjectID = 14088
update dbo.Project set OtherPartners = 'Yurok Tribe, CDFW, Salmon River Restoration Council' where ProjectID = 14083
update dbo.Project set OtherPartners = 'CDFW, USFWS, Redwood State and National Parks, SCC, Cal Fire, Wildlife Conservation Board, NRCS, USDA Forest Service' where ProjectID = 14084
update dbo.Project set OtherPartners = 'Bear River Band of the Rohnerville Rancheria, Indian Health Services' where ProjectID = 13995
update dbo.Project set OtherPartners = 'Crescent City, Elk Valley Rancheria, Crescent City Harbor District' where ProjectID = 14012
update dbo.Project set OtherPartners = 'NOAA, SCC, CDFW, DWR, USDA NRCS' where ProjectID = 14017
update dbo.Project set OtherPartners = 'North Gualala Water Company, South Coast Fire Department, Cal FIRE, Stewarts Point Rancheria' where ProjectID = 14022
update dbo.Project set OtherPartners = 'Karuk Tribe, IHS' where ProjectID = 14023
update dbo.Project set OtherPartners = 'CDFW, NRCS' where ProjectID = 14027
update dbo.Project set OtherPartners = 'Hopland Water District, LACO' where ProjectID = 14029
update dbo.Project set OtherPartners = 'landowners, NRCS, CDFW, SCC, USFWS, NOAA, USACOE, City of Ferndale, County of Humboldt' where ProjectID = 14033
update dbo.Project set OtherPartners = 'Lewiston Community Services District, California Rural Water Association, Rural Community Assistance Corporation, SWRCB' where ProjectID = 14036
update dbo.Project set OtherPartners = 'Mattole Salmon Group, BLM, CDFW, USFWS, SCC, TNC, USFWS, NFWF' where ProjectID = 14038
update dbo.Project set OtherPartners = 'The Apple Farm, Blue Meadow Farm, Gowan Apple Orchards, TNC, NRCS' where ProjectID = 14040
update dbo.Project set OtherPartners = 'Sherwood Valley Rancheria, Potter Valley Tribe, Hopland Band of Pomo Indians, Coyote Valley Band, Redwood VAlley Rancheria, Yokayo Rancheria, Pinoleville Pomo Nation, Guidiville Rancheria, Round Valley Reservation, Rural Community Assistance Corporation' where ProjectID = 14043
update dbo.Project set OtherPartners = 'Siskiyou County, City of Montague, CalTrout, Shasta Valley RCD, Shasta Watershed Conservation Group, BOR, NOAA, CDFW, SWRCB, NCRWQCB, ACOE' where ProjectID = 14045
update dbo.Project set OtherPartners = 'The Watershed Center, Trinity County RCD, CDFW, Sanctuary Forest, Salmonid Restoration Federation, Weaverville Sanitary District' where ProjectID = 14046
update dbo.Project set OtherPartners = 'Trout Unlimited, Mattole Salmon Group, CDFW, NOAA, Mattole Restoration Council, Salmonid Restoration Federation, SWRCB, CDFW' where ProjectID = 14050
update dbo.Project set OtherPartners = 'NRCS, Shasta River Water Association, Montague Water Conservation District, Huseman Irrigation Group and other independent landowners, NCRWQCB' where ProjectID = 14054
