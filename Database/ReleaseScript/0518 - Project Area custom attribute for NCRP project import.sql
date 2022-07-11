DECLARE @projectCustomAttributeTypeID int
SELECT @projectCustomAttributeTypeID = ProjectCustomAttributeTypeID from dbo.ProjectCustomAttributeType where TenantID = 4 and ProjectCustomAttributeTypeName = 'Project Area'

declare @projectCustomAttributeID int


-- previously broken projects
insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Bauer Subdivision'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '288.6000061')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Dangle Lane Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '70')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Elderly & Disabled Landowner Defensible Space'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '60')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Four Corners Community Safety Fuel Break Phase 6'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '151')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Four Corners Community Safety Fuel Break Phases 3-4-5'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '96')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'French Creek Fuel Break Segment 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '44')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'French Creek Fuel Break Segments B, C & E'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '86')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Lower Scott River Escape Route'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '170')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Lower Scott River Ridgetop Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '170')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Lower Scott River Road Fuel Break Maintenance'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '70')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Muniz Ranches Property Owners Association Fire Prevention Project - Phase 4'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2459.05004883')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Old Edgewood Road'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '12')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Old English Road Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '51')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Orleans Private Property Fuels Treatment Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '203')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Pieta (RX North-080MEU)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1941.94995117')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Rancho Hills'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '14')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Rattlesnake Creek Road Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '52')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Scott River Watershed Elderly & Disabled'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '60')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Scott Valley Multiple Municipality Wildland Fire Protection Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '120')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Shasta O Ranch VMP'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '496')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Silva Ranch Conservation Easement 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4344;
4209.04003906')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Silva Ranch Conservation Easement 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1332')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Sniktaw Road Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '40')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Soap Creek Ridge North Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '42.91999817')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Thamar Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '46')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Tyler Gulch Road Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '57')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Wagner Forest Conservation Easement'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3348;
575.8359883')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'West Community Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '69')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Western Siskiyou Sustainable Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '59')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Willow Creek Town Corridor Road Clearance'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '16.9996811803615;
7.21999979')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Yreka Area FSC Elderly & Disabled Def. Space'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '30')



-- not previously broken projects

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = '05N09 Fuels Reduction Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '25.4899867731773')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = '05N09B Fuels Reduction Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '12.4972281490613')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = '05N21 Fuels Reduction Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '47.8737236304286')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Access to Trinity Village Subdivision'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '21.2264362223291')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Alderpoint/Blocksberg Road shaded fuel break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '28.2709618670083')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Applied Innovative Forest Health Strategies on Post-Fire Landscapes'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2500')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Arcata Community Forest (Jacoby Creek Tract) Expansion – Swaner '))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '114')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Arcata Community Forest Expansion - Forsyth Tract'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '49')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Atwood Property Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '44.5879843819118')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Badger Mountain Road thinning'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '50')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Bald Hills Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '182.850161039028')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Baldwin Creek road fuel reduction - WC'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.29242040644471')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Bar W Rd. Fuels Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6.79994859617538')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Barnum Timber Subdivision Fuels Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.91927468309385')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Baseball Thinning & Progeny Site'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '350')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Bear Country Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '40000')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Bear Creek Rd. Complex (Project Area 104.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '104.06130430648')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Bear Creek Rd. Complex (Project Area 7.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.9164533521291')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'beginning of McClellan Mtn Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.44404403014281')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Bennett Ridge Community Hazardous Fuels Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '24.1599985')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Big Meadows Recreation Area Hazardous Fuels Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '255')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Big Creek Rx (Ewing Reservoir in Hayfork)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '350')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Bigfoot Protection (Forest Service land)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.15741537156909')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Bigfoot Subdivision East Fuel Break (Project Area 332.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '332.120601107527')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Bigfoot Subdivision East Fuel Break (Project Area 7.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.71713994353867')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Bigfoot Subdivision West Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.99105660225532')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Black Mountain, Phase II '))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '50')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Black Mountain, Phase III'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '50')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Blocksburg Larrabee Buttes Fuels Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '32.7137324993496')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Blue Rock Fuels Understory Burn FY20-FH-1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '121')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Bluff Creek - Bluff Creek Resort Thinning'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '24.6452069892842')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Bluff Creek - Cooper Ranch Thinning'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '148.287656507724')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Bolam Timber Stand Improvement and Fuelbreak Construction Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '25960')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Brannon Mt Neighborhood Defensible Space'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1099.75011436385')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Bray Fuel Reduction 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8.3')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Bridgeville Emergency Fuel Reduction Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '18;
23.43302416')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Bridgeville Fuel Hazard Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '122.34552011845')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Bridgeville Shaded Fuelbreak Demo'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '132.345450482605')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Bridgeville Slide'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '15.8332533892708')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Briggs Private Property'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.29235534983469')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Brooktrails'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8328.41992188')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Brushing north of structures adjacent to BLM Lands'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '25')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Brushy Mountain'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '13020')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Buck Mountain Vegetation and Fuel Management Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3450')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Bull Pine Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '97.3750986920848')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Burnt Ranch Fire Resilient Community'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8800')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Burr Valley Rd. Complex Fuels Reduction (Project Area 29.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '29.3886733768089')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Burr Valley Rd. Complex Fuels Reduction (Project Area 7.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.47974594541108')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Butler Creek LLC Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '89.3432014292819')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Butler Flat Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '17.4855653156719')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Calabazas Creek Open Space Preserve Fuels Management & Ecosystem Health Improvements'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1290')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Callahan Complex Fuels Treatment on Private Land'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '200')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Camp Creek2-Crawford Hill/Downs Ranch Fuel Tx'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '688.823242872685')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Camp Meeker CWPP'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2461.93024887')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Campbell Ridge Road Roadside Fuels Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '91.3777577165207')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Canal Gulch Road'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '25')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Carley (RX North-086 MEU)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1623.09997559')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Carlotta Pump Site'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.09447225593504')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Carr/Delta Fire Road Maintenance and Safety Project CE'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '15000')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Cedar Camp Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '516.186005581573')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Chimakenee Flat Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '77.5388039353755')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'China Mine Rd. Fuels Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '23.1702254764506')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Church Lane Fuels Reduction - Carlotta'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6.99500402518975')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Clear Eucaliptus on Chambers Road'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.40721912403883')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'clearance around repeater- WC'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '31.8685531931833')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Collins Modoc Reforestation Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '10143')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Conrad Ranch Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.85360668283953')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Conrad/Thom Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '26.3889494856517')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Coon Crk Road Roadside Fuels Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.48698834235335')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Cooskie Ridge Rd Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '38.8027120274142')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Cornwell Property Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '41.961302383725')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Cougar Landing'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '120')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Countywide CWPP update'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '>500,000')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Countywide fine scale fuel model mapping'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '>500,000')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Craggy Vegetation Management Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '11310')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Crawford Vegetation Management Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1600')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'CRCF Community Grazing and Fuel Reduction Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7500')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Cultural Fire Climate Project Hwy 169'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '300;
2490.00881931')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Cummings Creek Rd (Project Area 269.1) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '269.066621570219')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Cummings Creek Rd (Project Area 269.1) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '269.066621570219')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Davis Estate Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8.11759090061424')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Davis Property Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '20.9243685054436')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Deadwood Salvage Negotiated Sale'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '11')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Dogwood Lane Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.0429505479278')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Donahue Flat Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '56.3101090762417')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Donahue Property Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8.11424516546654')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Doreen DriveShaded Fuel Break '))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '39.30653542')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Dose Road Roadside Fuels reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.66885148217982')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Dose Road Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.95918098615011')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Down River Community Protection Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4456')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Downriver Communities Defensible Space and Infrastructure Protection'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '150')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Downs Ranch Upper Meadow Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '34.1011175448108')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Downtown Petrolia Fuel break / scotchbroom removal'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '27.4475999204385')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Downtown Willow Creek (South Side) Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '10.3303377629928')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Dry Creek Rancheria Wildfire Resilience Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '150')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'East Fork Scott '))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9678')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'East Side Salyer'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '170.086296702743')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'East Weed Fuel Break Phase III Maintenance'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '14
53.59000015')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Eastside Salvage'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '50')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Englert Property Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.69312886372396')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Etna Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '60')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Etsel Ridge Fuelbreak'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '400')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Ettersburg Neighborhood Safety Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '399.855244363519')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Ettersburg Neighborhood Safety Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '399.855244363519')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Ettersburg Neighborhood Safety Project 3'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '399.855244363519')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Ettersburg Neighborhood Safety Project 4'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '399.855244363519')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Eucaliptus Grove Forest Cleanup Chambers Road'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '27.2368640260784')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Evergreen defensible Space'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '130.665883167705')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'F 05N15 Road Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.38723422423433')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Fern Field Pilot Project [Thin, Burn, Graze]'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Fire Hall Road Roadside Fuels Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '13.5512274060214')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Fire Safe Council of Siskiyou County Multi-Communities Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2000')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FireSmart Lake Sonoma Watershed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '83223;
68278.7679663')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Fisher Roadside Roadside Fuels Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '15.2764031027971')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Fitch Mountain CWPP'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1968.72')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2007 - Project 001 (Proejct Area 3.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.27923232638')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2007 - Project 001 (Project Area 1.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.05910619892')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2007 - Project 009'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.9262175451')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2007 - Project 016'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.965114047742')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2007 - Project 025'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.14201479775')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2007 - Project 028'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.35097840045')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2007 - Project 038'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.631211964899')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2007 - Project 045'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.324808469085')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2007 - Project 064'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.14955423228')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2007 - Project 071'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.30847816932')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2007 - Project 080'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.376948909903')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2007 - Project 081'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.375019471117')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2007 - Project 102'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '10.4164059093')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2007 - Project 104 (Project Area 0.2) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.150510007254')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2007 - Project 104 (Project Area 0.2) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.209565450819')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2007 - Project 104 (Project Area 0.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.468634070059')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2007 - Project 122'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.50905196236')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2007 - Project 130'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.776258526275')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2007 - Project 135'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.201310574164')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2007 - Project 136'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.31785922933')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2007 - Project 149'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.2087643353')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2007 - Project 159'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.901860844496')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2007 - Project 166'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.62546214436')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2007 - Project 175'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.67389677469')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2007 - Project 176'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.777043853017')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2007 - Project 195'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.591336693777')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 002'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.648432066917')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 004'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.25326495596')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 005'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.557458072368')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 012'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.446071378379')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 016'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.616318109482')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 026'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.366150281573')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 039'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.26357681556')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 042'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.416272821644')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 053'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.349491915139')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 060'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.52211785579')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 069'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.666388904417')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 074'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.24159132662')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 082'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.90182580168')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 095'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.692184653547')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 096'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.75663143176')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 097'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.334669462412')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 104'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.875564988158')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 113'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.522075606782')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 117'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.405031930077')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 120'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.38332494184')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 127'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.87866692026')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 129'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.20560716795')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 130'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.769513714768')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 135'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.51192864632')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 137'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.738347242552')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 138'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.315819330006')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 139'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.27149962518')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 147'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.692402868183')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 151'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.47191299637')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 160'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.666155261538')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 162'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.12260787192')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 169'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.76311070243')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 171'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.861132057116')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 183'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.26446758633')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 186'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.930542707049')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 187'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.642351899442')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 188'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.493048260989')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 191'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.20531311357')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 193'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.11033423237')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 194'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.60696353007')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2008 - Project 231'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.185332564755')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2009 - Project 013'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.411886172766')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2009 - Project 032'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.823228849915')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2009 - Project 066'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.596421818049')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2009 - Project 075'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.34905762073')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2009 - Project 076'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.80005785266')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2009 - Project 083'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.452428227693')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2009 - Project 085'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.205912832613')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2009 - Project 087'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.489023864064')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2009 - Project 097'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.411427073802')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2009 - Project 110'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.487509198041')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2009 - Project 117'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.67404865326')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2009 - Project 119'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.338032950836')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2009 - Project 144'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.576339598939')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2009 - Project 152'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.507564072968')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2009 - Project 153'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.338009995346')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2009 - Project 164'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.59463079061')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2009 - Project 187'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.972697631969')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2009 - Project 188'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.441650075897')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2009 - Project 191'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.05902086988')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2009 - Project 220'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.272122975219')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.527342272852')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 027'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.755073731935')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 036'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.491648842071')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 043'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.01735471859')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.17864901423368')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 10'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.304303378872248')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 11'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.0876407659339')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 110'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.77278666154')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 12'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.11140737054162')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 127'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.41502505212')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 13'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.993662323759044')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 14'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.869080212531315')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 15'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.382735783711')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 159'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.0752224459')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 16'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.19800895961714')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 164'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.39886970513')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 17'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.485668898605303')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 18'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.76543540460899')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 188'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.493059110522')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 19'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.726146809479103')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.69266601566335')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 20'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.39180881897862')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 21'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.271070769502087')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 22'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.85806605059049')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 23'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.36913186760099')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 237'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.485408217185')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 24'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.269991920264071')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 25'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.421059812900922')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 26'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.898221554576886')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 27'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.03282410874384')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 28'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.04771670731974')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 29'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.776154910962776')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 3'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.28827970442914')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 30'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.29449680100414')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 31'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.33229780732784')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 32'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.717740958766431')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 33'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.166862499071796')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 34'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.17407680752034')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 35'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.17407680752034')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 36'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.31988286912911')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 4'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.415957930162186')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 5'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.561663760654208')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 6'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.69294473730264')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 7'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.44777739658366')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 8'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.82938037020814')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2010 - Project 9'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.33906134329655')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2011 - Project 009'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.9434818635')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2011 - Project 028'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.154013590994')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2011 - Project 065'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.150101512675')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2011 - Project 093'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.636034191429')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2011 - Project 120'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.11055899975')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2011 - Project 162'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.17692157849')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2011 - Project 232'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.26857476756')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2011 - Project 235'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.345256565519')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2011 - Project 238'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.22568382389')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2011 (Project Area 0.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.334018180851')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2011 (Project Area 0.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.521815529659')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2011 (Project Area 0.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.629265032707')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2011 (Project Area 0.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.719297959861')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2011 (Project Area 0.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.846597219282')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2011 (Project Area 0.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.876596334121')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2011 (Project Area 1.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.37299806979')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2011 (Project Area 2.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.1957872993')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2011 (Project Area 5.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.3063078846')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 004'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.588641673588')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 1 (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.449358581823815')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 1 (Project Area 0.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.762815012919446')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 1 (Project Area 1.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.50377735204672')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 10 (Project Area 1.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.40045336783932')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 10 (Project Area 3.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.08811374231066')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 11'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.471405416974109')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 12'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.541596625063472')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 13'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.962525623809523')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 14 (Project Area 2.0)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.00365105166156')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 14 (Project Area 2.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.94574225498207')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 15'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.567641414998316')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 16  (Project Area 0.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.337903505722106')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 16 (Project Area 0.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.758379679243481')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 17  (Project Area 0.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.23639943141065')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 17 (Project Area 0.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.539473857578809')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 17 (Project Area 0.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.6888166951167')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 18'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.18994931196176')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 2 (Project Area 0.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.61403704416697')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 2 (Project Area 0.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.79283077513696')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 2 (Project Area 1.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.69266601566335')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 3'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.993463775491657')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 4'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.15482483283062')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 5'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.863888118283102')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 6 (Project Area 0.0)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.0497184231089051')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 6 (Project Area 0.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.0995825394692132')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 7 (Project Area 0.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.88358261295885')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 7 (Project Area 1.0)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.96231529486213')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 8'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.98494913866154')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 9 (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.444573712257049')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 9 (Project Area 1.0)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.00668823369991')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 - Project 9 (Project Area 1.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.12013307452656')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 (Project Area 0.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.290822212858')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.399245439427')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 (Project Area 0.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.612533041336')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 (Project Area 1.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.09467335699')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 (Project Area 1.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.33389201279')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 (Project Area 2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.99299017982')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2012 (Project Area 4.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.17018667639')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2013 - Project 001'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.34590216742')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2013 - Project 003'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.99913291264')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2013 - Project 007'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.931458481083')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2013 - Project 046'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '14.3804443163')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2013 - Project 211'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.73510907316')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2013 (Project Area 0.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.149730465682')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2013 (Project Area 0.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.176717444368')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2013 (Project Area 0.3) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.32490618072')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2013 (Project Area 0.3) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.332819885849')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2013 (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.42585155308')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2013 (Project Area 0.5) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.501110851825')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2013 (Project Area 0.5) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.489227376252')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2013 (Project Area 8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.99146836154')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 046'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '11.3884703825')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 055'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.97517361223')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.46497106777651')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 10'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.30981758407008')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 11 (Project Area 0.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.513139068051326')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 11 (Project Area 1.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.71986661774418')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 12 (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.376750758138852')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 12 (Project Area 1.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.36059129655994')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 13 (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.421734328658679')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 13 (Project Area 0.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.459174536901195')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 135'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.111721706573')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 14 (Project Area 0.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.0509517258886364')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 14 (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.401417878057862')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 15'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.29869249055887')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 16'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.85322603301659')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 17 (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.405062247702695')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 17 (Project Area 1.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.18036088878051')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 18'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.21985755626393')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 19'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.847566268353802')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 191'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.331553944896')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.338797947374639')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 3'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.530030032856485')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 4'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.739386090575293')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 5'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.536541476811226')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 6'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.18178683301749')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 7'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.22406277159249')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 8'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.993942207181534')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 9 (Project Area 1.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.11970804664506')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 9 (Project Area 1.4) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.40773637811001')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 9 (Project Area 1.4) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.36435119902924')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2014 - Project 9 (Project Area 1.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.64376646601156')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2015 (Project Area 0.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.828620390046')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2015 (Project Area 3.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.2715916304')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2015 (Project Area 3.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.60226475107')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2016 - Project 001'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.629171401819')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2016 (Project Area 0.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.257177139727')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2016 (Project Area 0.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.471499776338')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2016 (Project Area 1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.04184336942')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2016 (Project Area 1.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.38440318162')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2016 (Project Area 1.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.73377768656')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2016 (Project Area 2.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.61341893914')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2016 (Project Area 2.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.83528806769')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2016 (Project Area 7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.02263241146')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2017 (Project Area 0.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.332800396741')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2017 (Project Area 1.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.33845472745')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2017 (Project Area 2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.95538027159')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2017 (Project Area 2.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.73942446104')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2017 (Project Area 2.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.82384925861')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2018 (Project Area 0.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.221818506446')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2018 (Project Area 0.3) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.282251543951')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2018 (Project Area 0.3) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.333175983744')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2018 (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.396170923397')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2018 (Project Area 0.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.581183496648')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2018 (Project Area 0.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.653506909862')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2018 (Project Area 1.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.20318739412')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2018 (Project Area 1.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.4427122649')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2018 (Project Area 1.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.86567165006')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2018 (Project Area 2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.95244700383')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FLASH 2018 (Project Area 4.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.90829625797')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Foot trail clearnace'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '31.8204057659835')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Forest Service Roads 05N09B & 05N17'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8.78829515445218')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Fort Ross CWPP'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '34905.21')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Fox Camp Prairie Restoration'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '35')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Fox Creek Rd. Fuels Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '22.5623469721981')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Fox Creek Road'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '305.951524435879')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Friday Ridge Road Clearance'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '63.8399729950746')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Friedrich Road Fuels Reduction Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '34.7879359438065')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'FSCSC Fuel Reduction 2009'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '50')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Fuel break behind properties on Schoolhouse Gap'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '53.09999847')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Fuels Management on Regional Parks'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '~12,000')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Fuels Reduction & Burn Area Restoration for Wiildfire Resilience on Private Lands Across Sonoma County'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1850')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'George Geary Private Property Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.00361457435929')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Golden Gate Subdivision Roadside Demo Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.85143885763564')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Grass Valley Area Rx'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '150')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Grassland Fuels Reduction on Sonoma Mtn'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1271')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Greater Hodgson Hill Neighborhood Fuel Reduction C'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '228.157229782783')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Green Pony Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6525')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Greenhorn Community Hazardous Fuels Reduction Roads and Driveways Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '40')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Greenhorn Road and Driveways Fuels Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '70')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Grizzly Creek Campgrounds/CA State Park'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '427.088804737216')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Grizzly Creek Forest CE'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '762')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'hairpin turn at bottom of grade'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.08137416867922')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Hammond Ranch Community Hazardous Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '50;
6551.26731597')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Hang Down Hotel Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '19.7671037394628')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Hansen Homestead Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.87090687990198')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Happy Camp Community Fire Hazard Reduction Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '878')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Happy Camp Fire Safe Council Priority Hazard Fuel Reduction Projects'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1800')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Happy Camp WKRP Pilot Project Area boundary'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '11000')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Hatton/Palmer and Ratihn Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '49.2711127928762')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Hayfork and Hyampom Community Protection'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '400')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Hayfork Area Fuel Break Maintenance'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2750')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Hazel'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '765')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Headwaters Reserve:'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '>1,000 ')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Hennesy Road Roadside Brushing'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '133.014345073873')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Hidden Valley Ranch Rd. Fuels Reduction - Trinity'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '42.1315278126215')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Highway 299 Fuels Reduction Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '169.075978632519')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'H-Line (old PL haul road)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '28.0183014404098')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Hoadley Peaks Salvage'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '140')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Hoadley Rx'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '790')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Hodgson Hill Neighborhood Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '93.0311996013102')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Horn Ranch Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '98.9041529590336')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 0.2) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.229341051797551')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 0.2) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.249807019406076')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 0.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.256021208908998')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 0.4) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.372913345061469')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 0.4) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.422122822623257')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 0.4) Project 3'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.449223817958169')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 0.4) Project 4'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.380000592331523')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 0.4) Project 5'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.414941372559431')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 0.4) Project 6'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.438526035456498')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 0.5) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.465883829631001')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 0.5) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.48565817603573')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 0.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.584817847833793')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 0.7) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.686827998451525')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 0.7) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.650806688230681')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 0.8) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.788403350269728')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 0.8) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.798892293903524')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 0.8) Project 3'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.782092304716972')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 0.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.863786700313154')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 1) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.999326771898328')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 1) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.03443666472602')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 1) Project 3'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.993230978481147')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 1.1) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.09429816520162')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 1.1) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.11919881244476')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 1.2) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.18186980540714')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 1.2) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.16879741932886')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 1.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.29281749667666')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 1.4) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.39186588313645')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 1.4) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.36911459141056')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 1.4) Project 3'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.37197650515517')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 1.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.52480968281753')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 1.6) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.63613968837083')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 1.6) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.63613968837083')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 1.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.73175677541213')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 1.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.80960489511305')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.03531435638902')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 2.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.32399573206618')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 2.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.43238235941552')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 2.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.48946397482187')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 2.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.58829986597437')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 2.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.77158631456722')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 2.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.89992350407522')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 22.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '22.9184090973281')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 3.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.20393789021191')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 3.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.34456814565615')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 3.4) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.44507510680908')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 3.4) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.41083394039264')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 39.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '39.7247492647288')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 4.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.37443565886859')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 5.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.72494363349631')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 6.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6.30053429014899')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  (Project Area 8.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8.52291688025765')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Bailey (Project Area 0.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.13446983701986')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Bailey (Project Area 0.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.176798364186161')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Bailey (Project Area 1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.960471573623687')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Ball (Project Area 0.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.545480294368538')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Beaver (Project Area 6.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6.08573056565318')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Bettinger (Project Area 1.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.13085305277355')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Biggs (Project Area 0.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.256874301745736')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Bishop (Project Area 0.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.063103204487888')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Bishop (Project Area 0.5) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.474247303227731')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Bishop (Project Area 0.5) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.506285557469003')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Borque (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.447951053064712')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Borque (Project Area 1.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.74221995892539')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Bouse (Project Area 0.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.58285722591942')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Bruce (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.366281587651026')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Burdick (Project Area 0.5) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.518026258712041')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Burdick (Project Area 0.5) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.517428637823917')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Burroughs (Project Area 0.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.880021000021339')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Burroughs (Project Area 7.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.48328773808129')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Butler_ _Beinf (Project Area 0)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.0461981597853487')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Butler__ Neum (Project Area 0)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.0241885991053363')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Butler__ Neum (Project Area 0.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.0588832213827286')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Butler__Assoc (Project Area 11.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '11.0885144570152')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Butler__Assoc (Project Area 7.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.87587704205455')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Butler__Carls (Project Area 0)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.0425505193903781')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Butler__Teren (Project Area 0.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.0900438381103075')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Bywater (Project Area 1.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.47198788711135')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Bywater (Project Area 5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.03674922541754')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Carlson (Project Area 10.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '10.4480385634922')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Carlyle (Project Area 9.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.37728222750633')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Carroll (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.351890564595186')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Carson-Hansen (Project Area 1.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.28113806113077')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Cole (Project Area 2.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.15696259332667')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Conrad (Project Area 1.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.46472353251')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Conrad (Project Area 2.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.48815045517864')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Creasy (Project Area 19.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '19.479213948186')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Creasy (Project Area 9.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.35444336524905')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Davidson T. (Project Area 0.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.319256534691523')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Davidson T. (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.444449270521422')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Davis (Project Area 1.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.43417879239025')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Decker (Project Area 0.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.224792477996196')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Dederick (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.385753258534271')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Delaney (Project Area 0.3) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.345105874824709')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Delaney (Project Area 0.3) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.327058340706672')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Delaney (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.400258517625188')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Delaney (Project Area 0.8) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.798859004476246')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Delaney (Project Area 0.8) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.824842834489499')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Delaney (Project Area 0.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.865544587347809')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Delaney (Project Area 1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.95928710351573')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Delaney (Project Area 1.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.39156425517748')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Delaney (Project Area 4.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.09204341986488')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Delaney (Project Area 4.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.27060740068863')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Delaney (Project Area 4.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.82631295320017')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Donahue (Project Area 0.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.561909887665664')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Dondero (Project Area 0.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.154623532372677')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Dondero (Project Area 0.3) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.283458717107583')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Dondero (Project Area 0.3) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.283458717107583')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Dondero (Project Area 0.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.69169748376107')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Downs (Project Area 0.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.247965861755392')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Downs (Project Area 2.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.23528336532652')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Downs (Project Area 3.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.78498304830904')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Dummer (Project Area 0.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.164225961413952')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Eckert (Project Area 1.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.34334780328484')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Edwards (Project Area 0.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.90518664723931')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Edwards (Project Area 1.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.65944904663333')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Fischl (Project Area 1.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.44893482679336')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Fisher (Project Area 0.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.301941871078446')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Fisher (Project Area 0.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.860321236381722')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Fisher (Project Area 5.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.91071376721411')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Flattley (Project Area 0.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.786580287526433')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Gale (Project Area 2.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.16699089042858')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Gault (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.381038870944484')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Glaessner (Project Area 0.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.791232560793049')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Hamilton (Project Area 0.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.734324484048916')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Harding (Project Area 0.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.603987364299918')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Harding (Project Area 1.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.17432303716301')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Harding (Project Area 1.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.46184945513206')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Henderson (Project Area 0.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.51583118349782')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Henderson (Project Area 1.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.74742523128806')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Henderson (Project Area 2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.95292782401865')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Hill (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.422122822644443')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Hill (Project Area 1.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.08657143633258')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Hill (Project Area 1.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.3873160533578')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Hill (Project Area 2.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.4894639748153')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Holzinger (Project Area 0.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.0570035231155116')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Holzinger (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.444538195710259')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Holzinger (Project Area 0.5) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.48916107330584')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Holzinger (Project Area 0.5) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.489161073305826')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Holzinger (Project Area 0.5) Project 3'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.48916107330584')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Holzinger (Project Area 0.5) Project 4'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.466547156586846')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Holzinger (Project Area 1.4) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.44386706587042')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Holzinger (Project Area 1.4) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.40798068434733')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Holzinger (Project Area 1.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.63135147540296')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Holzinger (Project Area 2.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.08491088619634')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Horn (Project Area 0.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.567417555862712')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Horn J. (Project Area 0.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.567417555862712')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Horn T. (Project Area 2.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.31328437474518')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Houston (Project Area 2.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.29790324373301')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Houston (Project Area 3.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.9402577559931')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Hussain_McLaughlin (Project Area 1.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.15636274113996')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Jordan (Project Area 0.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.305042554632358')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Karuk Senior Center (Project Area 0.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.70652793489929')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Karuk Tribe (Project Area 4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.96619647427257')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Karuk Tribe (Supahan) (Project Area 3.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.14898566463985')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Kastel (Project Area 1.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.39929552409715')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Kastel (Project Area 2.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.59408466836128')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Kastel (Project Area 3.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.33702494525175')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Kehrig (Project Area 0.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.572623793068476')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Kehrig (Project Area 1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.01307472170056')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Kehrig (Project Area 1.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.51950592618382')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Kehrig (Project Area 1.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.73283476776058')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Kehrig (Project Area 2.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.23305916920411')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Kehrig (Project Area 3.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.21385996917282')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Kehrig (Project Area 3.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.74527473033335')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  King Delbert (Project Area 1.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.4067143213598')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  King Greg (Project Area 4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.99339781929057')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Kirste (Project Area 1.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.44595809236186')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Knudsen (Project Area 1.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.9118673668015')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Lake (Project Area 0.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.851397748577288')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Lammon (Project Area 4.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.21201709931762')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Lammon (Project Area 5.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.49747791723048')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Latt (Project Area 0.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.134041511500717')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Latt (Project Area 0.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.288505896330377')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Latt (Project Area 0.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.79084636089517')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Mace D. (Project Area 0.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.80913230305992')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Mace D. (Project Area 1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.996992282024642')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Mace L. (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.365110413479668')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Mace L. (Project Area 0.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.84829004819644')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Manor (Project Area 1.2) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.22590385589336')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Manor (Project Area 1.2) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.22590385589336')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Manor (Project Area 2.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.38011720188772')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Manor (Project Area 5.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.58383775626441')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Manor (Project Area 8.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8.37005563306779')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Marier (Project Area 0.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.546523506451563')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Marier (Project Area 4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.9764659424675')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Mason (Project Area 1.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.19112354298743')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Mason (Project Area 1.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.39800598140921')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Mason (Project Area 1.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.66908767776836')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Mason (Project Area 1.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.80475244442849')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Mason (Project Area 2.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.77612644275709')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Mason (Project Area 4.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.25349596464235')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Mason (Project Area 9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.03833210341164')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  McCovey (Project Area 2.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.74475983403732')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  McLane (Project Area 0.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.2045051313652')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  McLane (Project Area 0.3) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.285408299332605')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  McLane (Project Area 0.3) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.324252356183116')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  McLane (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.43240410798278')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  McLaughlin (Project Area 0.2) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.222346418220531')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  McLaughlin (Project Area 0.2) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.182959071934824')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  McLaughlin (Project Area 2.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.28651535789638')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  McLaughlin (Project Area 2.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.39269264700253')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  McLaughlin (Project Area 2.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.50619044872693')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  McLaughlin M. (Project Area 13.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '13.3082878562731')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  McLaughlin, Clifford (Project Area 1.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.11768987955105')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Meade (Project Area 0.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.890091914280715')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Neihart (Project Area 0.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.227809277633322')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Neihart (Project Area 0.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.267301046980562')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Palmateer (Project Area 4.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.63908042569998')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Palmer (Project Area 0.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.68251974597466')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Patterson Ranch (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.360412334922187')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Patterson Ranch (Project Area 1.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.08787292224836')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Patterson Ranch (Project Area 1.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.77315119370002')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Patterson Ranch (Project Area 1.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.92866107533102')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Patterson Ranch (Project Area 16.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '16.1424580740765')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Patterson Ranch (Project Area 2.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.48412097202944')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Patterson Ranch (Project Area 2.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.60174476144411')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Patterson Ranch (Project Area 3.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.44968866421548')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Patterson Ranch (Project Area 37.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '37.4195195078576')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Paulsrud (Project Area 0.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.174688138865087')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Paulsrud (Project Area 0.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.602078416860203')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Pearson (Project Area 5.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.80730522893772')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Pearson Bill (Project Area 0.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.133558899300512')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Pearson, Barbara (Project Area 0.2) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.197201064718638')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Pearson, Barbara (Project Area 0.2) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.183456763502287')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Pearson, Bill (Project Area 1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.962924088233764')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Pearson, Bill (Project Area 1.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.19545723196962')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Peaugh (Project Area 0.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.328593026166366')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Peters G. (Project Area 1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.03674264576126')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Pierce (Project Area 1.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.94233448417014')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Pierce (Project Area 2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.98295007358327')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Pierce (Project Area 3.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.14810766673387')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Purcell (Project Area 0.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.492989427001861')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Purcell (Project Area 1.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.41256765895493')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Ramsland_McLane (Project Area 5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.96591168082597')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Ratihn (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.362603840242999')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Ratihn (Project Area 0.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.795982073606829')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Reis (Project Area 2.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.45805932708934')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Reis (Project Area 2.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.63417097937996')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Riggan (Project Area 0.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.604801286968364')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Riggan (Project Area 0.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.80214238977516')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Riggan (Project Area 12.3) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '12.3454980281425')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Riggan (Project Area 12.3) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '12.3454980281425')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Riggan (Project Area 4.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.4993062980328')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Riggan (Project Area 4.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.59544746992996')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Rivera (Project Area 10.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '10.5516311521591')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Robbi (Project Area 1.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.76543540462215')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Robinson (Project Area 0.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.819229632253229')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Robinson (Project Area 3.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.18065834838767')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Robinson J. (Project Area 0.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.52655539843248')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Rogier (Project Area 1.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.13733160481919')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Rogiers (Project Area 1.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.30235601842482')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Rutt (Project Area 0.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.20767760449128')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Rutt (Project Area 1.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.6027518164996')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Rutt V. (Project Area 2.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.60571154305228')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Sanders (Downs Ranch) (Project Area 0.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.840687644759574')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Sanders (Downs Ranch) (Project Area 1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.03443666474062')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Sanders (Downs Ranch) (Project Area 36.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '36.8640378068391')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Sanders (Downs) (Project Area 0.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.278073863293713')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Sanders (Downs) (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.44014782518854')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Sanders (Downs) (Project Area 2.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.6066194942895')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Sanders (Downs) (Project Area 5.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.39433265610512')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Sandy Bar (Glaze) (Project Area 0.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.764046041076144')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Schmidt (Project Area 0.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.0878497063053207')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Schmidt (Project Area 0.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.213952749805602')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Shea (Project Area 1.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.37829642894508')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Simmons (Project Area 0.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.229341051773187')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Soto (Project Area 1.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.33384922646203')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Soto (Project Area 7.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.15751862983715')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Spinks Ranch (Project Area 2.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.25392814508093')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Staats et al (Pierce) (Project Area 2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.98295007358327')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Starritt (Project Area 0.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.699557220906053')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Starritt (Project Area 1.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.55510748590735')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Stearns (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.413132052201452')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Stearns (Project Area 0.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.692053812941213')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Stearns (Project Area 2.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.05681498796111')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Stearns (Project Area 2.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.74529647344832')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Strouss (Project Area 9.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.35348439382259')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Supahan (Project Area 11.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '11.7757184093773')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Supahan (Project Area 3.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.12853413567354')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Supahan (Project Area 3.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.22365471773491')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Supahan (Project Area 4.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.16353650652411')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Super (Project Area 3.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.87182070333208')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Torres (Project Area 1.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.55974298522284')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Turner (Project Area 9.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.5933816570711')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Van Epps (Project Area 0.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.825502226545915')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Van Epps (Project Area 3.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.05679737467092')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Van Epps (Project Area 7.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.47001905286111')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Van Epps (Project Area 9.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.83025005081421')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Van Epps (Project Area 9.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.90603936016791')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Ward (Project Area 20.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '20.7895296796056')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Ward (Project Area 5.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.24553132879371')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Watson (Project Area 0.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.268924293640089')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Watson (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.381811612463827')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Watson (Project Area 0.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.482128847481092')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Watson (Project Area 0.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.755289573492539')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Watson (Project Area 1.1) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.13519712964476')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Watson (Project Area 1.1) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.06350354872677')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Watson (Project Area 2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.99854374513577')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Watson (Project Area 3.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.72305425054004')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Webb (Project Area 0.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.175725897583319')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Webb (Project Area 0.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.466770084579271')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Weeks (Project Area 2.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.31912267916007')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Wild (Project Area 1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.956452864052477')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Wilder (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.364784967317367')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Wilder (Project Area 1.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.59557843694383')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Williams (Project Area 0.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.670824140395573')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Williams (Project Area 1.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.18737894989047')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Williams, Barbara (Project Area 0.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.215740652633003')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database:  Woodman (Project Area 1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.01440707978604')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: 1 million gallon water tank for greater Trinidad'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.00717553231281524')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: 2015 fuel reduction project, 3 acres'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.48764795884249')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: 2017 Waterman Ridge Project (FS 2017)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '799.924783253519')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: 3.3 miles shaded fuel break 40 ft either side of Chemise Mountain Rd.'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '19.173151161145')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: 4th Avenue: Needs grading and rocking'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.8649547282794')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Additional Hydrants in the Blocks'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.00717553437989231')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Additional Water Tanks  - Palo Verde Bulletin Board / Entrance (Project Area 0.0)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.00717567852892949')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Additional Water Tanks - Harris Store (Project Area 0.0)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.00717567686390722')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Additional Water Tanks - Lauffer Ranch Gate Area (Project Area 0.0)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.00717566927301036')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Additional Water Tanks - Palo Verde Fire Station (Project Area 0.0)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.00717566132167036')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Address sign grant for community and water source identification'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.00717551913112513')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Alameda Road shaded fuel reduction, 50ft buffer.'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '15.9447561988711')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Alderpoint defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5269.69961688441')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Alternate Access from Fox Farm Rd to Stumptown Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.53696997976637')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Arcata Community Forest shaded fuel break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '75.3597663605719')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Arcata east of Hwy 101, ALL: encourage defensible space'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1003.19511440045')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Are between Panamnik and Gold Dredge Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.14021031111464')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Around some houses - Jewett Road'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '259.426291963797')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Assist landowner with fuels reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.00717560519969816')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Bacon Flat Road Shaded Fuelbreak'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '23.8272792205665')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Bair Rd Bridge to Hwy 299 Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '46.2599537770393')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Bald Hill brush removal- Hoopa'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '52.8822417154428')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Bald Hill tractor pilingfuel reduction - Hoopa'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '71.9149121291208')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Bear Creek Road defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1779.69871491088')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Bear River Band of Rohnerville Rancheria: Defensible space, outreach, roadside clearance'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '304.654948010892')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Bear Wallow fuel break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '32.3597222590528')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Beaver Creek Rd fuel break- Hoopa'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.33847529692356')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Beaver Flat brush clearing & helicopter landing zone'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '15.4527043771884')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Bell Springs Rd (Alderpoint to 101in Mendocino County) Shaded fuel break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '118.61111260288')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Benbow defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2004.89002521843')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Big Lagoon Park Road: Roadside clearance'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '32.6029675578816')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Black Forest (East Fork) fuel break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '10.7920281299698')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: BLM Landscape Ridgetop'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '32.0517614066707')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Blue Lake Boulevard defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '131.252854351377')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Blue Lake Rancheria defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '46.0415399085169')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Blueslide/Miller Creek Fuelbreak Connection (mainly a stream crossing)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '15.729951451915')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Boots Canyon Road to Chambers Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '20.7981010193403')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Boots Canyon Road to Conklin Creek Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '25.3223995936852')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Break up continuity of hazardous fuel buildup'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '106.452640258983')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Break up continuity, Thin Understory Fuels reduction, Buffer behind high concentration of houses'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '188.652906737466')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Briceland defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '14777.4738471331')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Broken Wagon Ln: roadside clearance'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6.33067841395884')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Brush and fuels reduction around campground'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '49.9013686162753')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: brush clearance on private property; Roadside Chipping, Pony Road area'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.02022917968637')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Brush clearing beneath PG&E powerline (Project Area 10.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '10.812069738378')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Brush clearing beneath PG&E powerline (Project Area 11.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '11.8007178830467')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: brush removal on State fee lands- Hoopa'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '369.268597990125')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Brushing Around Historic Buildings in Blocksburg'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '121.021312701138')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Buck Gulch fuel reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '68.5467303480583')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Buckman Tr Ln - understory clearance'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.08582677946912')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Buffer zone, west side of Sunset Place/Moccasin Dr. neighborhood'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.5552151345182')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Bull Creek Fuel Beak (Project Area 20.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '20.4961388760853')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Bull Creek Fuel Beak (Project Area 36.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '36.4062185709038')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Bull Creek Fuel Beak (Project Area 38.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '38.6351816603267')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Burr Valley Rd - SR36 to Sway Back'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '110.682693908727')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Buzz - Defensible Space around House'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.41834894501088')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Camp Creek neighbordhood ignition hazards (Project Area 15.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '15.4243676354771')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Camp Creek neighbordhood ignition hazards (Project Area 4.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.54257723413886')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Campbell Creek brush removal-Hoopa'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '806.080816314045')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Candidate site for 0.5 million gal. community water tank'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6.30738378633806')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Cathey Rd Access Fuel Reduction (100 yards either side)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '35.1563349509271')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Cathey Rd defensible space/Rd. access'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '751.155413757164')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Cathey Rd Fuel Hazzard'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '22.7880793195322')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Cathey Rd Fuel Reduction. Yes, needed. M. Rogers. Add new Rd length'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8.85885828969327')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Catheys Peak Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '14.9020312515942')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Chambers Road bridge for PVFD repeater'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.469256274552946')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Chezem Neighborhood Defensible Space - Encourage '))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1425.69219896677')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: China CreekRoad/Blueslide Road Fuelbreak - Ties in with top segment of'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '32.2107503516599')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Christensen Property Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '15.9775801050021')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Clean up dumped vegetation behind homes on Diamon Drive (Project Area 1.0)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.02312460741524')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Clean up dumped vegetation behind homes on Diamon Drive (Project Area 2.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.40315960544487')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Clear around Briceland CSD Water'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.58893891834126')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Clear evacuation route for Fox Farm Rd to connect to CR1000'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '11.4974643777915')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Clearance along public recreation fire access trail'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.54349514215137')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Clearance along road to protect access'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.73979057022748')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Clearing Above freeway below Green Hill Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.35806869864549')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Clearing around Fieldbrook Elem. School'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8.83853492618959')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Clearing of Walking paths'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '36.109297386173')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Cloudwood Rd - understory clearance'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '10.5030213651542')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Cobb Road defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '178.170949637495')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Community Service Rd brushing- Hoopa'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '114.887710651219')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Controlled Burns at Lauffer Ranch'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '14.3938029453227')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Cookson Ranch defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '61.175776158761')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: County Clearance along Fieldbrook Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '54.2981030558635')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: County Swap Project #5, Trinity Valley School/Bussell Cemetery'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.950322726489')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: County swap Project #6, Community Service District/Hwy 96'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.93507537221368')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Cranell/Dows Prairie Community defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '961.30173520803')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: CSD Road Mowing Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '10.1924937186849')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Cypress tree fuel reduction along roadside on Mattole Road (Crane Hill); hazardous fuel level'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '11.2049185386699')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Defensible space and fuel reduction around the Weitchepec Tribal Center'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.935574994926517')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Defensible space and fuel reduction in and around the area'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '10.9048250987614')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Defensible space and fuel reduction in and around the Wo-tekw Village area.'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '68.6154064283682')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Defensible space around Bigfoot Subdivision'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '17.5865384552768')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Defensible space around Jack Norton School (tall tree hazard)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.71941154993318')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Defensible space around Notchko Flat Rd RAWS (weather station)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '35.9489086226604')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Delaney Hill Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '199.469302551513')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Demonstration / Pilot Project - Fuel reduction demonstration at dump'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '20.9587336806898')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: develop safe zone at old quarry site'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6.6919817239092')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Develop Stover Road as an evacuation route'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.653521844888183')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: develop water source & tank Telescope Peak Rd- needs hardware- Hoopa'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.00717553994043334')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Doreen Drive fuel break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '85.0848748533007')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Dows Prairie Community defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '788.997937233412')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Duggan Mill Fuel Reduction (3/4 mile of road 150'' 2000)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8.04070585759308')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Dyerville Loop Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '73.1456164271812')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Dyerville Loop Rd - roadside clearance as needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '226.479336326765')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Educ outreach re defens space, rdside fuel brk, impr signage, water avail.'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '515.691428772208')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Eel Roack Rd shaded understory roadside clearance as needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '37.8675326669969')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Eel Rock Community defensible space and roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '469.097493930335')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Elk Creek Rd Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '32.9163951173165')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Elk Ridge/Road Z Shaded Fuel Break Starts at Bricland Thorn Rd.'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '34.2183183690787')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Elk River Court bridge - fix/ engineer'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '24.6615431902361')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Essex Gulch - improve access, roadside clearing, turnouts. Not thru rd.'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '200.186747607539')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Ettersburg defensible space; outreach; roadside clearance where needed (Project Area 462.0)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8159.71113055433')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: existing fuelbreak on Horse Mtn Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '57.155862149547')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Felt Rd understory clearance'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '12.7270991591036')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Ferrin / Elk Ridge Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '79.7406571124553')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Ferrin Road fuel break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '18.4015320452112')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fickle Hill shaded fuelbreak'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '77.4977869029909')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fieldbrook Van Eck unit - thinned Stand / Understory thinning'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '162.407641007543')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fire house on Panther Gap'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.0071756019386563')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fire Sign, Message Boards at the beginning of the Road (Identify locations and funds for signs)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.00717551975303157')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fire Suppression Ridges; some natural break; targeted for add''t treatment (Project Area 129.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '129.390452273272')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fire Suppression Ridges; some natural break; targeted for add''t treatment (Project Area 190.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '190.5303766833')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fire Suppression Ridges; some natural break; targeted for add''t treatment (Project Area 71.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '71.3329922012026')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fire Suppression Ridges; some natural break; targeted for add''t treatment (Project Area 79.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '79.1881404104458')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fire Suppression Ridges; some natural break; targeted for add''t treatment (Project Area 87.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '87.7865993736593')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fisher Rd (Project Area 1.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.13154051874168')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fisher Rd (Project Area 11.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '11.1485779837734')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fix eroding evacuation route: Chezem Rd.'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.41149954007677')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fix Headwaters access haul bridge'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.96893376964958')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fix McKay Tract Bridge'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.28765925353406')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fix Riverview Road Access - Pvt drive, mitigate stream diversion issues'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6.89308894238876')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Foothill neighborhoods brushing (w/ chipper days) - Viewcrest/Foothill'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '23.839135659798')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fox Farm Rd - fire safe Rd options for pilot project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '28.7105828187393')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fox Springs Road Shaded Fuel Break - Ridgetop Rd.'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '37.8595605219876')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Frank on "E" Road - Road Clearance / Defensible Space'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '13.2388411494477')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Freshwater Park summer dam'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.89739601304262')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Friday Ridge Community defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '733.767295022439')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fritland Ridge defensible space/Rd. access'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2620.12971677846')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel Break Along Alderpoint Drive in Brushy areas - mostly lower side'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '13.4411711260985')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel Break along China Creek and Blueslide Rds. From Bricland Thorn Rd.'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '37.3426982053383')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel Break along East Branch Rd from 101 to rodeo grounds'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '22.263300073701')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel Break along Hwy 101'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '14.7868556491868')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel break along Old Briceland Road'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '86.7387253185132')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel Break along Redrock Rd from 101 to end'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '33.9001310798762')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel Break along Reed Mtn Rd from 101 to end'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '47.0666926976087')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel break around Boynton Prairie Rd neighborhood'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.36993190154502')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel Break around Casterlin School'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '13.5662400750031')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel break around Kimtu'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.30729331701406')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel break around Lucchest Rd/Hilton Rd neighborhood'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '29.9646896743494')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel break around Sunshine Way neighborhood'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '32.7966304363643')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel break behind Big Lagoon neighborhood'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.0557082284206401')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel break behind Humboldt Hill community'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.1192709983305')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel break between wildland and Fieldbrook Road neighborhood'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '15.4211632705739')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel break coordinated by WCFSC and CAL FIRE'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.09520895940464')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel Break from Dean Creek to Garberville on 101'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '35.1645811879187')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel Break Oak Rock Rd - Sprowel Creek'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.66060530807945')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel Break on Alderpoint Road in brushy or forested sections'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '397.549173451265')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel Break on East Side of Garberville (Project Area 5.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.90646467936835')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel Break on East Side of Garberville (Project Area 6.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6.52188500019169')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel Break on East Side of Redway'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '852.202468481768')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel Break on Larabee Creek Ranch / Homestead Road (Project Area 3.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.30367407130339')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel Break on Larabee Creek Ranch / Homestead Road (Project Area 39.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '39.181954391158')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel Break on Larabee Creek Ranch / Sunset Ridge Road (Project Area 17.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '17.4494011767009')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel Break on Larabee Creek Ranch / Sunset Ridge Road (Project Area 37.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '37.8536364441108')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel Break on Old Harris Road'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '49.9286468242971')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel Break on Rancho Sequoia Drive'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '34.6796865816522')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel Break on Redwood Drive'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '13.6179606301763')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel Break West Moody Rd - Sprowel Creek'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '11.1827787249323')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel break, along homes and road on Spring Hill Ln'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.79704802851249')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel break, Pecwan Ridge north of Halagow Creek'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '20.867928959985')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel Breakon Homestead Rd, Browning Rd, Sylvan Glade Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '78.5327939162914')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '172.939763167807')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel reduction - Clear Road, Blue Ridge'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '15.9099574268156')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel reduction - Clear Road, Shaller Rd Area'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '27.3016342268416')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel reduction - Clear Roads,  In Telegraph Creek "The Zoo"'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '58.461311863236')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel reduction - Clear Shelter Cove Subd. Greenbelts - Thinning, Chipping'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '76.5040675217861')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel reduction - Island Mountain at Chemise Creek (Proud & Mana''s) 40/80'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '10.3642809423288')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel Reduction - Lower Brannan Mtn. Rd. and Fuel Break - Hwy 96 North Fuel Break for Evacuation'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '18.5380589683056')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel reduction ahead of annual fireworks show (Project Area 1.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.58200415246778')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel reduction ahead of annual fireworks show (Project Area 1.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.89346403697161')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel reduction ahead of annual fireworks show (Project Area 2.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.81383991021733')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel Reduction along Dyerville Loop Rd. From where it begins off'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '73.1456164271812')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel Reduction and Defensible Space; Behind DreamQuest and around post office'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.50882257581639')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel reduction around water tanks'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.57190467236487')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel reduction at intersection'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.610599398189707')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel reduction behind radio tower'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.76903966845807')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel reduction for the Old Village Area'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '16.7566245361404')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel reduction long Freeway South of Garberville to Benbow'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '10.5263717084076')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel reduction New Village Area incl. devensible space, access clearance'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '45.924083866602')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuel reduction on State Park Boundary Nielsen Ranch'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.77321283456775')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuelbreak along Briceland Thorn Rd. from Redway to Whitethorn Junction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '127.277038851351')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuelbreak along Ettersburg Rd. from Dutyville Rd. intersection'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '18.5499726492509')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuelbreak around Miranda community'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '15.9666561376929')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuelbreak around Old Hindley Ranch/Applewood Rd neighborhood'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '262.93004604855')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuelbreak from Hwy 96 to Weitchpec Elementary School'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '12.6843885938458')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuelbreak from Whitethorn Junction on Briceland Thorn Rd. to Shelter Cove'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '110.599453859986')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuelbreak northwest to southeast, south end of Alderpoint town'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '11.8025859718173')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuelbreak on Seeley Creek Road from Briceland Thorne to where clearing'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '89.406526928251')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuelbreak on Sierra Pacific land befind subdivision'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.34433838074444')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuelbreak, east side of Cartwright Rd.'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8.68060983977607')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Behind Businesses'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '14.4243091285465')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 0.2) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.243825389389186')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 0.2) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.223185671567362')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 0.2) Project 3'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.242029623764709')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 0.3) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.275293687490408')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 0.3) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.277455981380869')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 0.3) Project 3'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.301006540558896')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 0.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.439743297317119')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 0.5) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.502979406991927')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 0.5) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.51756557731365')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 0.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.562210311642136')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 0.7) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.709229567855795')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 0.7) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.733056210818314')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.964757183104099')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 1.2) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.1658070454373')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 1.2) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.16494325280624')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 1.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.26139508531074')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 1.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.41956836008256')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 1.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.53560901938639')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 1.7) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.70878907887024')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 1.7) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.72486290853738')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 1.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.94884363421062')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 107.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '107.325790912412')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 12.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '12.3911581077308')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 132.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '132.108960110999')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 16.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '16.0595378991705')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 17.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '17.132872806161')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 19.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '19.182814217581')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 2.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.55541561070952')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 2.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.74047639684066')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 20.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '20.5847494185546')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 23.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '23.6021450800489')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.04535066983703')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 3.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.2721634693501')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 3.7) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.69463345876977')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 3.7) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.74584019505974')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 3.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.75025965609229')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 33.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '33.4876404150508')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 4.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.16789774296842')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 4.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.53098292739372')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 4.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.86939910960087')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 407.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '407.734505017948')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 5.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.39669662111813')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Down River Plan (Project Area 9.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.41111693146902')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - HWY 299 corridor (USFS land)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.04632082787793')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction - Private land, roadside/home clearance'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.83345970682093')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels reduction - Tim Mullen, Barry, Foss Roads neighborhood'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1350.76847698061')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction (Project Area 3.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.23745492708014')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction (Project Area 4.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.71973776450452')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction (Project Area 5.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.2251633014663')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction (Project Area 8.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8.73907711839142')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels reduction above home between Hwys 101 and 254'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.07751633576744')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels reduction along Old Dolly Varden Road (Green Diamond), first 0.5 mile from Hwy 299'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '15.486304083127')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction -home and road clearance (Proejct Area 13.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '13.5379679975146')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction -home and road clearance (Project Area 42.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '42.4740767642459')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction on either side of road for ingress and egress safety (Project Area 0.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.24687715654424')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction on either side of road for ingress and egress safety (Project Area 0.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.793140256484031')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction on either side of road for ingress and egress safety (Project Area 2.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.3908833596836')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction on either side of road for ingress and egress safety (Project Area 3.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.71881711630964')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction on either side of road for ingress and egress safety (Project Area 38.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '38.2220790809975')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction on either side of road for ingress and egress safety (Project Area 4.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.51352331543015')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction on either side of road for ingress and egress safety (Project Area 5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.0071122378529')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction on either side of road for ingress and egress safety (Project Area 5.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.29242040635045')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction on either side of road for ingress and egress safety (Project Area 6.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6.56575228723265')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction on either side of road for ingress and egress safety (Project Area 6.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6.69910636032787')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction on either side of road for ingress and egress safety (Project Area 68.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '68.8090232828133')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction on either side of road for ingress and egress safety (Project Area 8.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8.90317730880285')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction on either side of road for ingress and egress safety (Project Area 9.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.0788506380678')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction on either side of road for ingress and egress safety (Project Area 9.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.43829259691896')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction on sides of road for ingress and egress safety (Project Area 0.5) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.488188345252587')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels Reduction on sides of road for ingress and egress safety (Project Area 0.5) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.487708165206297')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Fuels reduction, Buffer behind high concentration of houses, Break up fuel continuity'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '29.8980522768872')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Garberville and greater area defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8588.34804546099')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Glass - Lateral Fuel Breaks (3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '96.4536808532399')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Golden Gate Subdivision defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '190.312064663235')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Good site for the water id blue dot program'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '38.5589966435318')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Green Diamond brush road 1047 Emergency evacuation/access (Moonstone cross to CR1000)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '23.96748085236')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Green Diamond shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '109.422248595678')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Green Fir / Squaw Creek Broom Clearance'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '10.7845260266247')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Green Gate Rd Emergency Access Project roadside thin and limb as needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '24.448042241965')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Green Point School defensible space'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6.46285266693727')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Greenwood Hts Dr./Freshwater Rd: defensible space, road buffers, access clearance'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1887.3681777788')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Grenz Lane Shaded fuel break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8.4528522093574')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Gunst Rd - brush road for access'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '12.844169630985')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Gunst Rd neighborhood brushing (in conjunction w/ chipper days)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '14.0004894304479')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Hanson Property/Bigfoot Area Subdivision Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '18.5831010268175')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Hazardous vegetation clearance around campground'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '132.484237659014')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Hazardous vegetation clearance around campground north'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '142.665382770669')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Head Start School shaded fuel break and watersupply.'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.34903442538423')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Heartwood Defensible Space'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '90.7523208333934')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: High winds and fuel buildup. Highest fire occurrence in last 10 yrs'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '154.40661694686')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Hilton brushing (in conjunction w/ chipper days)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '332.871038940158')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Historically Cleared empty lots next to houses in Fairhaven'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.79927010536541')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Holmes Community defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '934.646046922757')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Homes need defensible space, Homes at the top of the hill needing defensible space'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '270.810823695828')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Honeydew community defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7769.36411545607')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Hostler Ridge - Piles need to be burned, retreated as shaded fuel brk'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '14.5903896650938')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Hufford brushing (in conjunction w/ chipper days)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '18.3611303425473')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Hughes Way - fuel reduction, 3 hydrants, pump sta, 15000gal tank'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.31324284991474')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Humboldt Hill Community defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '101.160613232238')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Humboldt Redwood Company buffer with WUI; possible shaded fuel break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '402.674084434047')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Hwy 299 fuel Reduction - WC'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '278.013767009557')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: ID shaded fuelbreak in upper Freshwater area + fuel reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '729.277321758511')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Improve Access to Bear Pen Water Site - Benbow'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6.38872533714538')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Improve Access to Benbow day use water drafting site'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.24820551607535')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Improve defensible space where needed (evacuation planning)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '114.958941217548')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Improve Pepper Tree Lane area Water Source (poss BlueDot pgm)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '513.54416480174')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Improve Price Creek Community Water Source (poss BlueDot pgm)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '268.796252415746')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Increase defensible space in The Blocks neighborhood'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '106.590073576308')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Increase Fire Fighting Equipment'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.0071755176587077')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Install addresss and Rd signs. Public education and outreach (Project Area 306.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '306.841545220642')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Install addresss and Rd signs. Public education and outreach (Project Area 448.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '448.521116883524')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Install addresss and Rd signs. Public education and outreach (Project Area 778.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '778.108877062075')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Install water tank available for fire protection'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.0071755563794537')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Inter-tie between Westhaven & Trinidad H2O Systems'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '10.2744835355402')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Island Mountain Rd (upper) fuel break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '31.3144359505688')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Johnson Road Roadside Clearance and Defensible Space'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '32.4894422546858')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Jones Point Road; shaded fuel break- Hoopa'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '12.2950004092797')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: King Range Rd fuel break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '60.2879903360443')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Kiscomb Hill Neighborhood - defensible space, improve access'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '797.793581459301')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Landscape clearing at bottleneck on Hwy 299 W of WCK'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '48.1535225651116')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Landscape end of Doreen Drive to Mattole River'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.07802102597618')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Larabee Subdivision defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3575.94495051001')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Levee vegetation - brushing / burning as needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '40.833470787066')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Liscomb Hill Rd. - 2.5K gal. water source/tank for all area residents'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '25.8887323203139')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Logging re-hab (slash removal, burn piles) in Weitchpec'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '244.511576296602')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Lost Flat Ranch - Lateral Fuel Breaks (3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '40.1029657850695')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Lost Flat Ranch, ridgetop (Project Area 126.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '126.202164114528')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Lost Flat Ranch, ridgetop (Project Area 20.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '20.6836758926582')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Lost Flat Ranch, ridgetop (Project Area 41.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '41.5337822731152')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Lower Cathey Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '14.453449084161')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: lower part of Rd. is started, some road maintenance is needed; Ridgetop Rd/Skid Rd fuels break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '15.0419347982768')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Lower Thomas Road Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '33.5895739787932')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Lower Trinity Plantation Thin, thinning young plantations and prev(FS 2017)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1179.90458071315')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Luffenholtz shaded Fuelbreak'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '27.6192678518304')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Lyman/Stolpe/Sunny Acres Community defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '210.544291704322')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Madrone Road (Weott) Shaded Fuel Break. 4-5mi, 50ft shade undrsty clear'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.86956247961486')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Maintenance, fuels reduction - Understory burn (Project Area 125.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '125.054092722539')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Maintenance, fuels reduction - Understory burn (Project Area 71.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '71.4753850313186')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Manila Community defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '427.378579538441')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Maple Creek defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3213.57071641724')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: marking of houses and roads (street names and numbers)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8.4402080900156')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Mattole Road at Dump Ridgetop'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '45.4088835299732')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Mattole Road/A.W. Way Park area defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '702.998192621683')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: McCaulley land prescribed burn; NRCS prj ongoing'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '30.3871936142863')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: McKay Tract - 60% Complete fuel hazard reduction around Redwood Acres'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1135.01813498941')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: McKinnon Hill Rd (slash removal)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '23.6008152582654')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Meadow/Hidden Valley defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '341.977389637061')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Mill Creek Rd shaded fuel break- Hoopa'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '17.1259157768856')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Miller Ranch Road Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '14.2489990395301')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Miranda defensible space/Rd. access'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1509.52915252016')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Miranda State Park Fuel Break Buffer'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '22.4387185297914')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Mitigate Sudden Oak Death'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '66.4547867909141')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Mouth Of Camp Creek including Gold Dredge Rd.'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '182.95532919276')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Muddy Creek neighborhood defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '185.329808827816')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Myers Flat clearance around water tank'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.259401121460915')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Myers Flat defensible space/Rd ad'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '216.789196935756')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Myers Flat West Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.1682557658333')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Nancy Noll Fuel Reduction Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6.12705179984545')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Need vegetation clearance around existing water tanks (protect H2O source)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.64735069913364')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Needs clearing, brush around water tanks'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.0071755146976396')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: New homes w/ no municipal water, need defensible space, address signage'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.83907810327319')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: North Catheys Pk - Windy Nip tie, south end of PAC005 (in areas as needed)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '23.287629211535')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: North Fork Rd/Mattole Rd intersection, heavily eroded'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.4077256149443')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: North Line of Fieldbrook / Van Eck unit; clearing, Shaded fuelbreak'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.31336342367318')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: NRCS fuels reduction project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '17.6596686720225')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Old 3 Creeks - roadside clearance along Old 3 Creeks'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '30.1481707707703')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Old Hodges Rd Fuel Reduction - Western access 20ft each side'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '11.9033755999411')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Old Hodges Rd Fuel Reduction. Yes'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '19.5495622703212')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Old Railroad Grade North - roadside clearing for access, defens. space'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '405.003900755751')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Old Railroad Grade North Clearance'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '25.8104418600381')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: or_west Fuels Reduction Project (Project Area 131.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '131.763317756223')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: or_west Fuels Reduction Project (Project Area 1753.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1753.12468442846')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: or_west Fuels Reduction Project (Project Area 197.0)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '197.044916665789')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: or_west Fuels Reduction Project (Project Area 20.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '20.5046000432842')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: or_west Fuels Reduction Project (Project Area 46.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '46.3370070939427')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: or_west Fuels Reduction Project (Project Area 61.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '61.1589149984082')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: or_west Fuels Reduction Project (Project Area 95.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '95.5733084112045')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Orlando fuel break - an estimated 1 acre'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.14099675050102')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Otter Lane fuel clearance'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.64186921516672')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Outreach and education to young and old - Sign Board'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.00717560572589461')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Owl Gulch brushing (in conjunction w/ chipper days)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '17.9449151769025')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Palo Verde defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7019.32360337052')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Panther Gap Rd. Bottom fuel break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '37.295932654203')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Paradise Ridge/Queenmine Rd. (BLM) proposed fuelbreak'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '93.2211225334433')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Pather Gap community defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3619.71497576489')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Patterson Community defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '149.563509065923')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Pending - ridgetop fuel break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.58730063156192')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Pepperwood Community defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '699.356010095811')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Pepperwood Springs Fuel Break - Sprowel Creek'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '13.1223137862481')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Petrolia and greater area defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3959.04323760983')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: PG&E roadside fuels reduction on Liscomb Hill Road'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.41427002586133')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Phillipsville Defensible Space'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '421.317866182576')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Phillipsville Loop Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.70586610968756')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Pine Creek Rd brushing to Bloody Camp Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.90791673350053')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Pine Creek Rd brushing to French Camp Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '13.5983163257865')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Pine Hill Ave drafting location @ Martin Slough'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.00717550143462552')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: PL Broadcast burning and piling around Shively'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '160.459808871894')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Poff ''s - Clearing'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.54888400980434')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Pool could be developed as a water site'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.198313627280913')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Poor Water System'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '143.978768461598')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Post address & St signs. Reduce fuels on roads. Improve access, avail H2O (Project Area 1221.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1221.14508301581')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Post address and St signs. Reduce fuels on roads. Improve access, avail H2O (Project Area 246.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '246.449924315047')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Post address signs/encourage defensible space, provide water for fire'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1471.79515001518')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Post address/St signs, reduce fuels, improve acc, avail'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1135.47063333302')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Post address/St signs, reduce fuels. Improve acc, avail water, paint hydrts'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '690.635686157117')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Post more address signs to facilitate emergency response'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.00411578988047')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Post more address signs to faclitate emergency response'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '31.3344078246299')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Power pole (PG&E) fuel reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.17358039610885')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Prescribed fire project (Project Area 231.0)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '231.004351586256')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Prescribed fire project (Project Area 354.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '354.253785151107')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Prescribed fire project (Project Area 90.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '90.3620643019337')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Priority. Defensible Space in/around Weott'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '38.1610601479639')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Private road(s), NE of Westhaven: roadside clearance'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6.80832417619506')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Proposed roundabout for evacuation safety (Project Area 0.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.589971332196355')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Proposed roundabout for evacuation safety (Project Area 2.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.23217373615147')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Proposed water tanks at Honeydew School'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.0287022929358486')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Prosper Ridge community defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2536.2681995964')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Prosper Ridge fuel break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '12.6948261343641')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Public Education - Address Sign Grant for Community and Water Source'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.00717551913076979')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Public Education - Fire Sign, Message Boards'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.00717551975183951')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Public outreach re defensible space and address signage'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '156.703340103436')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Public outreach re defensible space and evac plan (Project Area 172.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '172.49303017807')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Public Outreach re defensible space and evac plan (Project Area 439.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '439.366336949685')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Public outreach re defensible space and fire safety (Project Area 386.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '386.217950005748')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Public outreach re defensible space and fire safety (Project Area 462.0)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '461.955110242572')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Public outreach re defensible space, fire safety, evac planning'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '144.330397196281')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Rainbow Ridge shaded fuel break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '64.829130000218')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Rancheria fuel reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '21.8166221615117')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Rancheria fuel reduction - Scenic Drive'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.26727297814656')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Rdside veg mgmt, Public outreach re defensible space, evac plan'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '796.95139164231')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Redcrest Community defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '500.915966528103')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Redwood Grove brush removal fuel break- Hoopa'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '26.7932910431654')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Regularly clear fuels in empty lots'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '25.6814436796505')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Remove fence at Haygoods & Elkhorn - Wrk w/Property Owner'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.00717553442159284')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Revisit fuel break around Golden Gate Subdivision (10+ years since treatment)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '17.9858486508777')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Ridge Road Fuel Break  - Sprowel Creek'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.24715619088662')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: ridgetop fuel break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '85.2767184906355')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Ridgewood Heights Community: Defensible space, outreach, roadside clearance'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1183.64252689627')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Riverside community defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '177.918453067686')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Riverview neighborhoods brushing (in conjunction w/ chipper days)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '17.8007071060136')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside brushing for i- and e-gress (Project Area 0.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.259401916378661')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside brushing for i- and e-gress (Project Area 3.0)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.97911973585776')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside brushing, Access to structure/parcel Shaded Fuel Break '))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '36.7471690433469')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance Alex Lane'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.09331603853565')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance along Kneeland Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.33632536524026')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance along Murray Road, partner with County Roads & Green Diamond'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '44.1836589706196')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance along Upper Fickle Hill Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '17.0081713588642')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance Greenwood Heights Dr'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '21.0678001879896')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance on Blue Lake Blvd (CAL FIRE exemption 1038(j))'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.19192217748131')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance on Lucchest/Aldergrove Rds, Abbott Ln'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '17.8041614872783')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance Prairie Ln/Green Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '15.9458396929969')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside Clearance: Acorn Lane neighborhood'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '28.4167868487562')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside Clearance: Baker Creek Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '21.3081426481213')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside Clearance: Baker Creek Rd to Four Corners, Mendo Cnty'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '54.4612930984839')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside Clearance: Baker Creek Rd to Thorn Junction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '49.9462900137887')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: Barley Hill Dr'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.98080171317602')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: Barnum Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.80123302425787')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside Clearance: Catheys Peak Rd.'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8.05069632275157')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: Diana Rd. , Alton'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6.44982452225144')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: Dick Smith Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.22938641661787')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: Fisher Road (pending project with California Conservation Corps)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '22.5858863233913')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: Frost Lane'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.38693850340176')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: Hill Lane (2017, 10-15 ft either side)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8.42692254828136')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside Clearance: Hilton Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '21.1070171623059')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: Home Ave'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.79826535085227')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: intersection of Dinsmore Ranch Rd. and Monument Rd.'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.42061215986185')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: James Creek Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '27.5197549646214')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: Loop Rd, E of Fortuna'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.25964447664915')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: Lower Shop Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.11010659223066')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: Mattole Road near AW Way Park'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '16.6561150713309')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: McClellan Mtn Rd (dense canopy)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8.57392515384372')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: Mill St/Country Club Est Rd, Rohnerville'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '18.2103763322137')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside Clearance: Moonlight Meadow to Shelter Cove Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '12.2056140452472')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: Nelson Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '13.7509819920506')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: Palmer Blvd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.79826535085227')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: Private Road (Project Area 19.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '19.3924402338484')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: Private Road (Project Area 6.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6.65672109572472')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: Quail Hill Rd. (2015)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.50449853379776')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: Quail Lane'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.43386367918563')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside Clearance: Road A Rd/Briceland Thorne Rd (Project Area 1.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.75009520420424')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside Clearance: Road A Rd/Briceland Thorne Rd (Project Area 2.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.22825635812605')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: S Loop Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.11902936166055')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: Sequoia Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '19.4331606105959')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: Shady Lane'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '10.4708086308007')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: side road of Perry Meadow Lane (Project Area 1.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.82510185417642')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: side road of Perry Meadow Lane (Project Area 8.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8.93505777171864')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside Clearance: Sprowel Creek Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '14.8076257969106')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: Sunny Heights Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.06068710366058')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: Tawndale Lane (2016)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.39559274206046')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: Tompkins Hill Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.37662835465185')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearance: Vance Estates Road'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.24079038991771')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearing, Patricia Lane'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.0726555331363')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside clearning, either side of Quinby Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '13.3830528670545')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside shaded canopy 150 ft each side (mile ___ [get from J.L.])'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '40.078363364884')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Roadside, maintenance, high, section 27'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '49.7761501943234')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Rock Pit Quarry - roadside clearing for access/hazard reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '180.592921700679')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Rubicon Project - thin and limb for emergency access'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.65011285227731')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Rural (northern) Trinidad: neighborhood fuels reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '152.11897401898')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Saddle Mountain fuel break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '57.9997149627227')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Salmon Creek Community defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '22017.1565706226')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Salmon Creek Rd to Thomas Rd Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '20.7861124397064')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Salyer/Hawkins Bar Community Protection Fuels Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '59.3063789298567')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Salyer/Hawkins Bar Community Protection Fuels Project (CPFP) (FS 2012) (Project Area 115.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '115.744345942818')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Salyer/Hawkins Bar Community Protection Fuels Project (CPFP) (FS 2012) (Project Area 146)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '145.967310713537')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Salyer/Hawkins Bar Community Protection Fuels Project (CPFP) (FS 2012) (Project Area 162.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '162.575538190742')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Salyer/Hawkins Bar Community Protection Fuels Project (CPFP) (FS 2012) (Project Area 26.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '26.50446871274')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Salyer/Hawkins Bar Community Protection Fuels Project (CPFP) (FS 2012) (Project Area 57.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '57.5423209175003')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Salyer/Hawkins Bar Community Protection Fuels Project (CPFP) (FS 2012) (Project Area 7.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.86418428105304')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Salyer/Hawkins Bar Community Protection Fuels Project (CPFP) (FS 2012) (Project Area 84.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '84.8340965051658')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Salyer/Hawkins Bar Community Protection Fuels Project (CPFP)-FS 2004 (Project Area 46.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '46.5032738830829')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Salyer/Hawkins Bar Community Protection Fuels Project (CPFP)-FS 2004 (Project Area 92.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '92.0698950346391')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Salyer/Hawkins Bar Community Protection Fuels Project (CPFP)-FS2006'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '109.400859580559')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Samoa Community defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '986.520388915635')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Sawdust Trail - Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '11.9357802986634')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Seely/McIntosh Community defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '186.693041395194')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Severe snow down, Ishi Pishi just north of central Orleans'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '44.5340190432424')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Shaded fuel break along Crooked Prairie Road'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '44.6000408032148')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Shaded fuel break along Crooked Prairie Road, completed 2016'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.08776667430735')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Shaded fuel break along Crooked Prairie Road, completed 2017'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.36019346862124')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Shaded fuel break along Ettersburg Rd.  (Ettersburg Junction down to the'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '67.2066967366086')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Shaded fuel break along forest edge in park (fire hazard reduction, forest)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '33.8474014890605')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Shaded fuel break along Huckleberry Lane/Goodman Ranch Rd.'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '122.63469255503')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Shaded fuel break as a buffer between residents and wildlands'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '19.2476561015063')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Shaded fuel break Jacoby Creek Forest (buffer btwm resid. and forest land)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.95241110577824')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Shaded Fuel Break on E.B. Ranch / East Blue Rock Rd - Benbow'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '16.3022322710328')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Shaded fuel break on Harlander Rd. and spur along with defensible space'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '14.8520821763108')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Shaded fuel break on Seely / Leggett Ridge'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '35.1805014352262')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Shaded fuel breaks East of town in interface zones - Buffer between'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '73.0690944069962')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Shaded fuelbreak between Van Eck / Lindsey Crk & Mather Estates'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.83973683034229')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Shaded understory, clearing as needed (Project Area 0.0)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Shaded understory, clearing as needed (Project Area 3.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.58006435655771')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Shelter Cove defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2154.91885538956')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Single Access, mimal address - rd sign posting - water supply - high fuels'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1421.31212883037')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Slash Treatment/Vegetation Management along timber roads'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '84.1022040793561')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Smith Gulch area fuel reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '241.944083241108')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Smith-Etter Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '124.696600393528')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: South Boundary Humboldt redwoods  State Park / Salmon Creek'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '82.2656457936688')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Spring Canyon Lane (State Park) Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.452390619571')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Sprowel Creek Road Fuel Break at entrance'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.07513742784215')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Sprowell Creek defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1490.21164094945')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Squires Housing Complex defensible space'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.19709582468259')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Stagecoach Road: roadside clearance'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.33154004685289')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Standpipe on Benbow Campground Bridge (State Park)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.00717568097608116')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Stansberry Road Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '39.637322883095')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: State Park across from South Fork High School'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.28655892235441')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Stop burning at Redwood National Park at Bald Hills in Summer'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '155.86741663931')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Stover Rd. (from school to end) Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '89.9535466304107')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Strawberry Rock / BLM mastication'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6.66417378532284')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Summer Dam; Redwood Creek before Lacks Creek'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.83892681982072')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Sungnomes pilot fuel reduction project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.76612908030662')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Sunnybrae shaded fuel break & protection zone'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '630.522179390196')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Sunset2  Fuels Reduction Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '109.862151427468')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Sunset2 Fuels Reduction Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '839.699798436033')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Supply Road shaded fuel break- Hoopa'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '12.2548498769561')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Support fire protection with mechanical treatment of YUR001'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '58.1487121830147')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Sutter Road neighborhood defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '292.763548214373')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Suzie Q Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '55.3608459991216')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Table Bluff Reservation defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '701.324302147062')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Telescope fuels reduction- Hoopa'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '120.121579509313')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Tim Mullen Rd/Foss Rd shaded fuel break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '16.2900945585429')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Tine fuel break. Pine plantation, add to Elk Creek Rd Project 046'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '14.7895871675417')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Tish Tang Road; shaded fuel break- Hoopa'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6.88766712490112')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Treated FLASH and 2011; Rd G treated'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.88437563027381')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trimming Brush by Danco around Samoa & behind Cookhouse'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.4200924448593')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinidad Rancheria defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '63.7701880347143')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity Acres neighborhood defensible space'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '20.7755406936798')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection - fuel reduction - Broadcast, piles, chi Project Area 1.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.92691366349102')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection - fuel reduction - Broadcast, piles, chi Project Area 12.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '12.4383828300612')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection - fuel reduction - Broadcast, piles, chi Project Area 14)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '13.9725767037452')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection - fuel reduction - Broadcast, piles, chi Project Area 42.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '42.129765551137')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection - fuel reduction - Broadcast, piles, chi Project Area 48.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '48.2384654386706')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection - fuel reduction - Broadcast, piles, chi Project Area 52.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '52.1385953460841')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 10.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '10.6939998635958')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 11.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '11.6783278433033')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 12.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '12.6168186317076')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 13.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '13.3380360223925')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 147.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '147.572981218564')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 15.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '15.3674203644757')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 151.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '151.063193895276')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 19.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '19.659200072671')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 2.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.19391192110764')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 2.4) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.41620382685386')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 2.4) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.3561220193412')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 2.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.68985399521207')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 2.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.78856849950327')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 20.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '20.3667394083069')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 20.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '20.6527448168036')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 25)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '25.0468179908327')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 26)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '26.0131311693411')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 26.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '26.3664210324623')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 27.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '27.5852490819607')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 3.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.16054639214964')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 3.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.76961235594334')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 31.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '31.2715156166911')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 31.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '31.75449649951')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 4.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.12635585899925')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 4.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.74754330477218')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 44.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '44.1064441908108')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 49.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '49.2737444816986')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 49.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '49.7267866286804')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 6.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6.14642311041633')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 6.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6.31409445042481')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 6.4)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6.37818923507985')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 7.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.66737084320615')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 8.1)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8.1213846352841')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 8.3) Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8.2633663809411')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 8.3) Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8.33091742453144')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Trinity River Community Protection (Project Area 9.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.20037666755754')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Triple Junction fire training center'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '94.8005068091274')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Tsarnas Rd - shaded understory'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '21.1723474693049')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Tully Creek Subdivision'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '86.3428508156789')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Twin Trees Rd Fuel Break - Benbow'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '29.1005514271725')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Understory Burn Maintenance  - Down River Plan (Project Area 261.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '261.552837915337')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Understory Burn Maintenance  - Down River Plan (Project Area 73.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '73.8012232912513')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Understory burning and/or fuel break to support fire protection'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '40.0892275929308')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Understory burning between highway 169, Klamath River for fire protection'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1382.61440922445')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Understory clearing along Abbey Lane'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.36856930975699')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Understory clearing along Garden Lane (Project Area 2.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.94384119125056')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Understory clearing along Garden Lane (Project Area 20.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '20.9274825456996')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Understory clearing along Upper Creek Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.82284965645729')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Upper Cappell Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '20.4204991616417')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Upper FIckle Hill Road Community defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '313.746414657762')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Upper Fox Farm Road Community defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '181.039041646363')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Upper Half Twin Trees Rd Fuel Break - Benbow'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '25.1666065455001')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Upper Jacoby Creek water tank network'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '189.779977953034')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Upper Little Larabee defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '184.822010692191')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Upper Miller Creek Rd fuel break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '59.7537330543197')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Upper Prairie Lake Rd. Fuelbreak'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '15.9004843459937')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Upper Thomas Road Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '69.9989798695089')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Uppler Blue Lake Blvd - roadside clearance, WT develop, defen. space'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '237.771464930775')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: USFS 1N10 Rd'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '38.7937723451688')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Van Eck Squaw Creek Tract - understory thinning'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '363.553904004491')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Veg Mgmt along road, prioritize County roadside clearing'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '14.4321978158708')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Wallen Ranch Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '29.3486064081269')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Water Storage @ Beaver Flat'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.00717558131040359')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: water tank on Dowd Road - Hoopa Rd Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.00717557755506127')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: water tank on Dowd Road - Hoopa Rd Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.00717558159983222')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: water tank on Dowd Road - Hoopa Rd Project 3'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.00717558566522763')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: water tank on Dowd Road - Hoopa Rd Project 4'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.00717558834617482')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: water tank on Dowd Road - Hoopa Rd Project 5'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.00717558922341769')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: water tanks @ Kneeland Rd & Butler Valley Rd; 20-30k gal'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '0.00717567363959868')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Waterman East Integrated Vegetation Management Project (IVMP)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1521.25976805358')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Waterman West Integrated Vegetation Management Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2655.49625423421')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Weott defensible space/Rd access'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '343.241603705734')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: West End Rd. - roadside brush clearing'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '34.6811805693078')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: West End/Warren Creek - connect Elizabeth to Cedar Hill, turnouts, planning'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '688.776525585262')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: West Fork Road - fuel break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '10.2365070374831')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Westhaven Community defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1309.67088778217')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Whitethorn defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5345.46478149174')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: widen Redwood Avenue & improve bridge crossing for fire truck access'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.47310248536399')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Wilder Ridge defensible space; outreach; roadside clearance where needed'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2232.81770054365')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Williford Road (Weott) Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '10.4067614130726')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Windy Ridge Road Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '12.9999408877535')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Woodland Heights shaded fuelbreak'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '21.1118561968969')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: Work with Barnum timber to create a shaded fuel break along Gibson Ridge'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '220.00392190067')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Humboldt County CWPP Projects GIS database: WUI; fuel treatment buffer between residence and wildland'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '49.8747268648384')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Hwy 36 fuelbreak'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '91.5947074657082')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Hyampom Fire Resilient Community'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '21013')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Impact Assessment of Fuels Management: Pilot.'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '110000')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Jenner Headlands Fuels Management'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5630;
245.65177206')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Jenner Headlands Preserve Fuelds Reduction and Fire Prevention Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '266')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Jenner Headlands Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '73.16999817')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Juanita Restoration'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2900')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Junction School Fuel Reduction (Project Area 1.7)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.67054573675584')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Junction School Fuel Reduction (Project Area 1.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.84981554155219')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Juniper Flat Comprehensive Fuel Reduction Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2811.33237711')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Juniper Flat FSC Hazardous Fuels Reduction, Phase 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '100')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Juniper Flat Hazardous Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '50')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Karuk Watershed Center Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.36057938008302')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Kaut Road Brushing Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8.90804917290636')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Kergisen Lake Rd. Fuels Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '14.4459059007099')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Kimtu Area Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '67.7945228603666')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Kimtu Park Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '20.1582079547258')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'King Peak Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '55')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'King Range and Shelter Cove Forest Restoration and Shaded Fuel Break Enhancement'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1800')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'King Range Forest Health & Community Protection'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1200')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Klamath River Phase II'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '40')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Klamath River Prescribed Fire Training Exchange (TREX) Burn Units'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6019.90886725')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'KNF Prescribed Fire Units (Eddy LSR Unit 3, Jackson Peak Underburn, Happy Camp Underburn A, Petersburg Pines Unit 1, Ben Grider Underburn)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5577')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Knudsen Ranch Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '126.158824486669')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Lacks Creek Management Area Landscape Restoration Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '188')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Lake Mendocino Watershed Protection'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '67200')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Lake Shastina Community Protection Fuel break Phase 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '326;
392.76054838')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Lake Sonoma Watershed Fuels Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '15454.7377912')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Lammon Property Fuel Reduction Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '32.0660262456726')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Lammon Property Fuel Reduction Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '32.0660262459872')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Larabee Valley Rd. Complex'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '15.4332022384103')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Le Perron Flat Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '76.0141382196183')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Leary Creek'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1911')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Little Brown''s Creek Stream Enhancement'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '150')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Little Grass Valley Rx'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '326')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Lower Bark Shanty Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '79.7719568647757')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Lower Brannon Mountain Road/Hwy 96 North (Project Area 19.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '19.5586458310881')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Lower Brannon Mountain Road/Hwy 96 North (Project Area 24.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '24.7920907079913')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Lower Offield Mtn Ranch Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '80.4736643044205')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Lower Sandy Bar Creek Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '63.2031208441941')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Lower Scott River Access Road II'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '50')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Lower Scott River Access Roads SFB'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '100')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Lucky Penny'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1500')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Lunardi'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5150.1980154')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Marier Property Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '57.1430675002686')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Mattole Headwaters Forest Conservation Easement'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1222')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'McClellan Mountain Rd- shaded fuel break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '74.1008423573078')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'McGains Pond Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '97.1348713791372')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'McKay Community Forest Phase 2 and Adjacent Ryan Creek Legacy Easement'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6164')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'McLaughlin Ranch Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '71.8780603731968')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Mill Creek'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2386.45996094')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Mill Creek / Mathews Ranch Road (Project Area 27.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '27.5438592437512')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Mill Creek / Mathews Ranch Road (Project Area 53.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '53.3008533325858')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Mill Creek / Mathews Ranch Road (Project Area 7.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.48719194469334')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Miller Mountain-Little Shasta Valley Hazardous Fuels Reduction and Meadow enhancement'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6000')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'MT120, Fuelbreak around Rocky Rd and Quail Dr'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '51')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Muniz Ranches Shaded Fuel Break Project '))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '~100
46.37083923')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Neihardt Property Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.32369991812066')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'NL035, Lake Forest Dr'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '150')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'North Burnt Ranch'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.33153523045694')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'North Lake Communities Defensible Space and Infrastructure Protection'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '280')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Northern Mendocino County Forest Health Collaborative'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1358')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Northern Mendocino Regional Forest Resilience project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4000')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Northwest Roadway Safety, Fuels Reduction, and Community Chipper and Engagement Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '419;
47286.3817847')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'NW Sonoma County/Hwy 1 Corridor'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '242.7624594')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Oak Bottom Compound Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '39.7116626779949')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Offield Mtn Ranch Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '110.136598540562')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Old High California Conservation Corps Road Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '177')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Old Three Creeks Rd. Clearance'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '40.2879929871684')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Oregon Fire Salvage and Reforestation'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6000')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL006 (Project Area 13.58)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '13.58')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL011'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '31.5')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL019 (Project Area 32.05)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '32.05')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL019 (Project Area 41.9)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '41.9')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL019 (Project Area 42.2)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '42.2')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL073 (Project Area 39.71)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '39.71')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL073 (Project Area 4.71)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4.71')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL073 (Project Area 60.45)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '60.45')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL084'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '59.75')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL085'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '18.78')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL089'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '24.63')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL091'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '46.27')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL092'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '41.93')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL093'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '57.11')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL094'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '36.01')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL097'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '17.47')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL102'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '34.08')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL103'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.87')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL105'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '64.48')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL106'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '49.24')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL107'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.79')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL108'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '19.75')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL109'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '28.06')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL110'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '26.37')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL112'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '33.5')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL115'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.67')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL116'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '15.09')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL117'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.36')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL118'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.07')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL119'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '20.91')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL120'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '44.56')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL121'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.32')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL122'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL123'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '20.18')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL124'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6.46')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL125'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '39.69')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL126'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.85')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL127'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.85')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL129'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '63.16')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL130'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8.11')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL131'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '309.47')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL132'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '23.39')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL133'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '30.98')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL134'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8.11')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'ORL135'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '13.58')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Orleans Community Fuels Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2700')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Orleans East / Cedar Veg'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '~18,000')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Orleans Neighborhood Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '897.397378242778')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Orleans School Road Shaded Fuelbreak'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '85.1751313861129')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Orleans Somes Bar Fire Safe Council Priority Hazard Fuels Reduction Projects'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1500')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Paradise Ridge Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '85;
96.25412249')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Patterson Ranch Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '64.5212103160688')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Patterson Rd / Oak Lane Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '15.7586558293822')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Patterson Road North'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9.23797678255278')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Pearch Creek Neighborhood Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '332.830650785424')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Pierce Ranch Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '39.6186337681415')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Pine Mountain'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1536.46321769')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Pony Express Way Roadside Brushing'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '25.3086814904004')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Pony Project Roadside Fuels Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '17.1795037873772')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Priority 1a Karuk, Fuels Reduction Treatments'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '70')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Priority 1a Private, Fuels Reduction Treatments'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '900')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Priority 1a Public, Fuels Reduction Treatments'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '220')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Priority 1b - Plantations under 40 years along Primary Access '))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1220')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Priority 1b, Private - Primary Access 300ft Fuelbreak'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '880')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Priority 1b, Public - Primary Access 300ft Fuelbreak'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2810')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Priority 2 - Karuk lands, fuel reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '90')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Priority 2 - Private lands, fuel reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '910')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Priority 2 - Public lands, fuel reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '570')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Priority 3 - Public lands - 500 foot Greenline Fuelbreak'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3360')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Priority 4 - Dozerlines - 300 foot fuelbreak'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3530')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Priority 5 - Plantations under 40 years along Burn Control Roads'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2590')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Priority 5 - Private - Burn Control Roads 300 ft fuelbreak'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '20')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Priority 5 - Public - Burn Control Roads 300 ft fuelbreak'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3520')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Priority 6 - Prescribed fire/ underburning'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '20360')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Prirority 3 - Public - HCFSC Around Town "Greenline" Treatments'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1550')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Private road Upper Little Larrabee Rd, shaded fuel (Project Area 21.8)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '21.8103900001039')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Private road Upper Little Larrabee Rd, shaded fuel (Project Area 7.5)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '7.48420340109519')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Prosper Ridge Road Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '68.1074292748847')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Pumice Vegetation Management Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6240')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'R Ranch Shaded Fuel Break Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '30')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Rattlesnake Fuel Reduction and Forest Health Project '))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '70')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Re-active CFIP for Sonoma County'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '300,000 acres would be eligible')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Reading / Indian Creek'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '500')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Red Cap Creek North Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '41.9248392617892')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Red Cap Creek South Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '42.2227922654307')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Red Cap North Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '235.081266065916')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Red Cap South Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '145.900126792277')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Redding-Indian Creek Oak Woodland Restoration '))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1656')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Redway Fuel Reduction Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '926.129698880231')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Redwood House Road'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '147.168477698369')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Redwoods Rising'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '586')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Redwoods Rising Phase I Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4944')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Redwoods to the Sea Corridor Forest Resilience Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '484')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Reef to Ridge Coastal Forest Protection: Ten Mile River Watershed Easement Acquisition'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '23201')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Ricke Homestead Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '31.4957483310794')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Rio Nido Fire Mitigation and Habitat Restoration'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '20')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Rolling River Farm Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3.79578598113638')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Ruth Lake/Mad River Watershed Reforestation Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2950')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Saddle Mountain Open Space Preserve Fuels Management & Ecosystem Health Improvements'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '960;
971.43956627')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Salmon River Outpost Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1.07058278598873')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Sandy Bar Creek LLC Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '164.949559815125')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Sandy Bar Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '90.6407123023914')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Santa Rosa Junior College Wildfire Resilience Workforce Development'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '82')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Scheinman / Lost Coast Camp fuels reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '49.6820715571658')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Scott River Ranch VMP'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1000;
1392.53110086')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Scott River Road Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '70;
103.01308679')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Seely McIntosh Road Clearance'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '36.4407159092829')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Seiad Valley/Horse Creek Communities Protection & Restoration Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6585')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Series of Shaded Fuel Breaks  (Project Area 44.6)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '44.5502717785703')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Series of Shaded Fuel Breaks (Project Area 60.3)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '60.3141749419895')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Shackleford Working Forest Conservation Easement - Scott River Headwaters'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '12214')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Shaded Fuel Break Boots Canyon Rd - bottom'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '16.5121791207363')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Shaded Fuel Break Project 6'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '40')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Shaded fuel break Project 7'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '100')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Shamrock'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '18363.1601563;
18104.5880577')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Shelter Cove Community Protection and Landscape Resiliency Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3747.80004883
897.679926800')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Sherwood Corridor Ingress and Egress Roadside Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '107.4 acres;
851.3794715')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Short Ranch Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '33.5249556464577')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Siskiyou Carbon Reforestation Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2977')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Six Rivers Hazardous Fuels and Fire Management Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '8000')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Six Rivers Initiative Restoration Phase I'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '877')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Slate Creek Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '179.914916306117')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'SLT Preserve Fuels Management/Forest Health Improvements'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '3800')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Soap Creek Fuel Break Maintenance'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '43.93000031')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Soldier Forest Health'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '300')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Somes Bar Integrated Fire Management Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5600')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Sonoma County Fuels Reduction Project (4 Target Areas)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '~4,000')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Sonoma Developmental Center forest management'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '700')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Sonoma Land Trust Wildfire Resiliency'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '100')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'South Creek Ridge South Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '24')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'South End'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '100000')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'South Fork Road Roadside Fuels Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '36.746376286533')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'South Scott Watershed Vegetation Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '55000')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Spinks Ranch Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '28.0756691241187')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Stafford Fire Salvage and Reforestation'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9935')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Stanshaw/Irving Neighborhood Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '243.950261514861')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'State Highway 36'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '551.283802919001')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Sterling Ranch Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '36.0305836305592')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Swains Flat Community'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '240.291683961573')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'SWAP project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2.17502668046066')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Swimmer''s Delight/ Van Duzen Park'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '71.0682340692688')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Ten Eyck Residential Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '56.1469292244622')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Tennant Fuel Reduction Phase I'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '138.58820511')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Tennant Fuel Reduction Phase II'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '86')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Tennant Fuel Reduction Phase III'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '65')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Three Dollar Bar Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '20.1881460821579')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Ti Bar II Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '309.68117136825')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Ti Bar III - Vogt/Magarian Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '23.4065184445633')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Titlow Hill Neighborhood Defensible Space'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6267.52426852143')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Triangle Parcel (Lee Anderson) up Portagee Crk P10'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '629.08511227')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Trinity County Community Protection and Hazardous Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '10000')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Trinity Landscape Resilience and Restoration – Phase III'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '10000')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Trinity Landscape Resilience and Restoration – Phases II'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '12090')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Trinity Timberlands Conservation Easement'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4800')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Tripp Ranch Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '6.46729282304288')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Ukiah Emergency Fuels Reduction Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '700;
30429.5027503')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Ukonom RD Facilities Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '15.0978744824778')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Ullathorne Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '30.9984800355659')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Underwood Mountain'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '45.884560944378')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Upper  Brannon Mt. Road Clearance'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '39.1772953896282')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Upper Bark Shanty Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '104.235551033593')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Upper Ferris Ranch Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '221.809283161742')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Upper Ishi Pishi Fuel Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '237.960460419906')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Upper Mark West Creek CWPP'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '11634.34')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Upper North Fork Salmon Fuels Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '120')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Upper Redwood Valley Ranch Road Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '64.6958965665914')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'USFS/LDS Church Fuel Reduction Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '13.5910981373568')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'USFS/LDS Church Fuel Reduction Project 2'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '13.5910981374405')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Vegetation Management along Primary and Secondary Roads'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '547.71002197')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Veterens Road Brushing Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '17.5374534206683')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Wallen Ranch Road Roadside Fuels Reduction'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '5.34570937225618')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'WCF Roadside and Boundary Fuels Treatment FY20-FH-10; FY20-FH-P3 (Planning & Implementation)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2000')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Weaverville Community Forest Fuel Treatment Maintenance FY20-FH-P1 (Planning)'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '4813')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Weaverville Community Forest Fuels and Recreation Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '83')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Weekender'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '19.7232143937685')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Western Klamath Landscape Fuels Reduction and Forest Health Project 1'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2500')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Western Scott Valley Shaded FuelBreak'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '270')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Western Sonoma Co. Fire Prevention Planning and Community Engagement'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '84020')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Westside Plantation Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1400')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Whiskey Working Forest Conservation Easement - Scott River Headwaters Phase 3 '))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '18683')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'White Rock Shooting Range'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '26')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Whitehawk Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '1500')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Wild Hog Vineyard Forest Forest Improvement Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '15-20')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Wilder Ridge fuel break - Phase I'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '45.8993862102954')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Wildfire Adapted SoCo-Home Hardening (13 communities) '))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '~2,000')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Willits Emergency Fuels Reduction - Shaded Fuel Break and Prescribed Burn Project'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '720;
13632.8601541')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Willow Creek Buffer Zone'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '470.251715956865')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Willow Creek East Buffer'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '344.354156471754')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'WKRP Offield Mountain'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '9000')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Yellow Jacket Ridge'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '2600')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Yreka Area Critical Ingress/Egress Shaded Fuel Break'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '168')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Yreka Area FSC CWPP Development'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '49834.743052')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Yreka WUI Hazardous Fuels Reduction on Private Land'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '250')

insert into dbo.ProjectCustomAttribute (TenantID, ProjectCustomAttributeTypeID, ProjectID) values (4, @projectCustomAttributeTypeID, (select ProjectID from dbo.Project where TenantID = 4 and ProjectName = 'Yurok Prescribed Burns for Forest Health and Wildfire Resiliency'))
set @projectCustomAttributeID = SCOPE_IDENTITY()
insert into dbo.ProjectCustomAttributeValue (TenantID, ProjectCustomAttributeID, AttributeValue) values (4, @projectCustomAttributeID, '100')

