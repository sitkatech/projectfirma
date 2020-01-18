insert into dbo.MeasurementUnitType(MeasurementUnitTypeID, MeasurementUnitTypeName, MeasurementUnitTypeDisplayName, LegendDisplayName, SingularDisplayName, NumberOfSignificantDigits) values 
(36, 'LinearStreamMiles', 'Linear Stream Miles', 'linear stream miles', 'Linear Stream Mile', 2),
(37, 'Celsius', 'Celsius (C)', 'C', 'Celsius', 2),
(38, 'PerSquareMeter', 'Per Square Meter (per sq m)', 'per sq m', 'Per Square Meter', 2) 


DECLARE @PMIDsToNames TABLE (pmID int, displayName varchar(200))

insert into dbo.PerformanceMeasure(TenantID, PerformanceMeasureDataSourceTypeID, PerformanceMeasureDisplayName, MeasurementUnitTypeID, PerformanceMeasureTypeID, IsSummable, PerformanceMeasureDefinition, CanBeChartedCumulatively)
output inserted.PerformanceMeasureID, inserted.PerformanceMeasureDisplayName into @PMIDsToNames
values
(7,1,'Number of easements or acquistions', 6, 1, 1, 'Number of land and/or water transactions', 0),
(7,1,'Habitat protected through easement/acquisition', 1, 1, 1, 'Number of acres of habitat protected through land and/or water transactions', 0),
(7,1,'Water flow protected through easement/acquistion', 30, 1, 1, 'Amount of water protected through land and/or water transactions', 0),
(7,1,'Stream protected through easement/acquistion', 36, 1, 1, 'Number of stream miles protected though land and/or water transactions', 0),
(7,1,'Number of structures installed', 6, 1, 1, 'Number of structures installed through aquatic habitat restoration', 0),
(7,1,'Floodplain habitat protected', 1, 1, 1, 'Number of acres of floodplain habitat protected through aquatic habitat restoration', 0),
(7,1,'Stream miles treated', 36, 1, 1, 'Number of stream miles treated though aquatic habitat restoration ', 0),
(7,1,'Number of streambanks treated', 6, 1, 1, 'Number of streambanks treated through aquatic habitat restotation; only required for riparian planting, fencing projects', 0),
(7,1,'Buffer width treated', 25, 1, 1, 'Area treated by planting/revegetation', 0),
(7,1,'Number of pools created', 6, 1, 1, 'Number of pools created through aquatic habitat restoration', 0),
(7,1,'Number of riffles created', 6, 1, 1, 'Number of riffles created through aquatic habitat restoration', 0),
(7,1,'Barriers improved for fish passage', 6, 1, 1, 'Fish passage barriers addressed through aquatic habitat restoration', 0),
(7,1,'Habitat made accessible to next upstream barrier or likely limit of habitatle range', 36, 1, 1, 'Amount of habitat opened up through aquatic habitat restoration projects, related to passage projects', 0),
(7,1,'New Fish Screens Installed on Diversions', 6, 1, 1, 'Total number of new fish screens installed on new or existng diversions', 0),
(7,1,'Water flow screened', 30, 1, 1, 'Total water flow (in cubic feet per second, cfs) screened.', 0),
(7,1,'Total road miles treated', 2, 1, 1, 'Total road miles treated or decommissioned.', 0),
(7,1,'Roads relocated outside riparian area or streambanks', 2, 1, 1, 'Total road miles relocated outside streambanks or the riparian area.', 0),
(7,1,'Water flow transferred/leased instream', 30, 1, 1, 'Total instream water flow (cfs) conserved and/or protected due to instream water acquisition (purchase or lease) and/or irrigation efficiency measures.', 0),
(7,1,'Stream miles improved/protected for adequate flows', 36, 1, 1, 'Total stream miles improved and/or protected for adequate flow due to instream water acquisiton (purchase or lease) and/or irrigation efficiency activities as measured from the point of diversion to next downstream diversion or confluence (whichever comes first).', 0),
(7,1,'Percent of riparian Vegetation over 6ft high within 60ft buffer of treatment areas (LiDAR/UAV Surveys)', 11, 2, 0, 'riparian vegetation over 6ft within 60ft buffer of treatment areas (lidar/uav surveys) through UAV monitoring', 0),
(7,1,'Percent of solar access at random transcects', 11, 2, 0, 'Effectiveness metric measuring ecological outcome to increase streambank shading   ', 0),
(7,1,'Density of woody stems between treamtment and control location', 38, 2, 1, 'Effectiveness metric measuring ecological outcome to increase streambank shading, measuring the difference between the treatment and control areas   ', 0),
(7,1,'Extent occupied by Chinook parr during August snorkle surveys', 36, 2, 1, 'Linear extent occupied by Chinook parr during August snorkel surveys.', 0),
(7,1,'Extent occupied by juvenile steelhead during end of summer surveys', 36, 2, 1, 'Linear extent occupied by juvenile steelhead during end of summer surveys', 0),
(7,1,'Extent occupied by Chinook fall spawning surveys', 36, 2, 1, 'Linear extent occupied by Chinook spawning surveys during the fall and steelhead spawning surveys in spring.', 0),
(7,1,'Extent occupied by steelhead spring spawning surveys', 36, 2, 1, 'Linear extent occupied by Chinook spawning surveys during the fall and steelhead spawning surveys in spring.', 0),
(7,1,'Seven day average daily maximum temperature', 37, 2, 0, 'C of seven day average daily maximum temperature', 0),
(7,1,'Discharge at Ritter USGS gauging station', 30, 2, 0, 'July-August mean and minimum discharge MFJDR effectiveness metric measuring ecologial outcome "Instream Flows Support Freshwater Life History Stages of Native Fish"', 0),
(7,1,'Percent of stream length downstream from Hwy 19 with surface water during July-August base flow', 11, 2, 0, 'July-August baseflow BTM effectiveness metric measuring ecological outcome "Instream Flows Support Freshwater Life History Stages of Native Fish"', 0),
(7,1,'Flow measured at the CTUIR installed gauging station near mouth of desolation', 30, 2, 0, 'July-August mean and minimum discharge for Desolation/HWNF efficetiveness metric measuring ecological outcome "Instream Flows Support Freshwater Life History Stages of Native Fish"', 0)


-- insert subcategories

DECLARE @subCatIDsToPMs TABLE (subCatID int, pmID int, subCatName varchar(200))

/*****  Performance Measures without Subcategories. Insert Default so we can insert a dummy ChartConfigurationJson *****/
insert into dbo.PerformanceMeasureSubcategory(TenantID, PerformanceMeasureID, PerformanceMeasureSubcategoryDisplayName)
output inserted.PerformanceMeasureSubcategoryID, inserted.PerformanceMeasureID, inserted.PerformanceMeasureSubcategoryDisplayName into @subCatIDsToPMs
select 7, pmID, 'Default' from @PMIDsToNames where displayName in (
'Water flow protected through easement/acquistion',
'Stream protected through easement/acquistion',
'Number of pools created',
'Number of riffles created',
'Habitat made accessible to next upstream barrier or likely limit of habitatle range',
'Water flow screened',
'Roads relocated outside riparian area or streambanks',
'Stream miles improved/protected for adequate flows',
'Percent of riparian Vegetation over 6ft high within 60ft buffer of treatment areas (LiDAR/UAV Surveys)',
'Percent of solar access at random transcects',
'Extent occupied by Chinook parr during August snorkle surveys',
'Extent occupied by juvenile steelhead during end of summer surveys',
'Extent occupied by Chinook fall spawning surveys',
'Extent occupied by steelhead spring spawning surveys', 
'Seven day average daily maximum temperature'
)
insert into dbo.PerformanceMeasureSubcategoryOption(TenantID, PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryOptionName, ShowOnFactSheet)
select 7, subCatID, 'Default', 0 from @subCatIDsToPMs where subCatName = 'Default'


declare @subCatID int

/***** Number of easements or acquistions *****/
insert into dbo.PerformanceMeasureSubcategory(TenantID, PerformanceMeasureID, PerformanceMeasureSubcategoryDisplayName) 
output inserted.PerformanceMeasureSubcategoryID, inserted.PerformanceMeasureID, inserted.PerformanceMeasureSubcategoryDisplayName into @subCatIDsToPMs
select 7, pmID, 'Habitat Type' from @PMIDsToNames where displayName = 'Number of easements or acquistions'
-- insert options
set @subCatID = SCOPE_IDENTITY()
insert into dbo.PerformanceMeasureSubcategoryOption(TenantID, PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryOptionName, ShowOnFactSheet)
values 
(7, @subCatID, 'Aquatic', 0),
(7, @subCatID, 'Terrestrial', 0)

/***** Habitat protected through easement/acquisition *****/
insert into dbo.PerformanceMeasureSubcategory(TenantID, PerformanceMeasureID, PerformanceMeasureSubcategoryDisplayName) 
output inserted.PerformanceMeasureSubcategoryID, inserted.PerformanceMeasureID, inserted.PerformanceMeasureSubcategoryDisplayName into @subCatIDsToPMs
select 7, pmID, 'Habitat Type' from @PMIDsToNames where displayName = 'Habitat protected through easement/acquisition'
-- insert options
set @subCatID = SCOPE_IDENTITY()
insert into dbo.PerformanceMeasureSubcategoryOption(TenantID, PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryOptionName, ShowOnFactSheet)
values 
(7, @subCatID, 'Aquatic', 0),
(7, @subCatID, 'Terrestrial', 0)

/***** Number of structures installed *****/
insert into dbo.PerformanceMeasureSubcategory(TenantID, PerformanceMeasureID, PerformanceMeasureSubcategoryDisplayName) 
output inserted.PerformanceMeasureSubcategoryID, inserted.PerformanceMeasureID, inserted.PerformanceMeasureSubcategoryDisplayName into @subCatIDsToPMs
select 7, pmID, 'Type of Structure' from @PMIDsToNames where displayName = 'Number of structures installed'
-- insert options
set @subCatID = SCOPE_IDENTITY()
insert into dbo.PerformanceMeasureSubcategoryOption(TenantID, PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryOptionName, ShowOnFactSheet)
values 
(7, @subCatID, 'LWD', 0),
(7, @subCatID, 'Boulder', 0),
(7, @subCatID, 'BDA', 0)

-- subcategory 2
insert into dbo.PerformanceMeasureSubcategory(TenantID, PerformanceMeasureID, PerformanceMeasureSubcategoryDisplayName) 
output inserted.PerformanceMeasureSubcategoryID, inserted.PerformanceMeasureID, inserted.PerformanceMeasureSubcategoryDisplayName into @subCatIDsToPMs
select 7, pmID, 'Location' from @PMIDsToNames where displayName = 'Number of structures installed'
-- insert options
set @subCatID = SCOPE_IDENTITY()
insert into dbo.PerformanceMeasureSubcategoryOption(TenantID, PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryOptionName, ShowOnFactSheet)
values 
(7, @subCatID, 'Instream', 0),
(7, @subCatID, 'Floodplain', 0)

-- subcategory 3
insert into dbo.PerformanceMeasureSubcategory(TenantID, PerformanceMeasureID, PerformanceMeasureSubcategoryDisplayName) 
output inserted.PerformanceMeasureSubcategoryID, inserted.PerformanceMeasureID, inserted.PerformanceMeasureSubcategoryDisplayName into @subCatIDsToPMs
select 7, pmID, 'Anchored' from @PMIDsToNames where displayName = 'Number of structures installed'
-- insert options
set @subCatID = SCOPE_IDENTITY()
insert into dbo.PerformanceMeasureSubcategoryOption(TenantID, PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryOptionName, ShowOnFactSheet)
values 
(7, @subCatID, 'Anchored', 0),
(7, @subCatID, 'Unanchored', 0)

/***** Floodplain habitat protected *****/
insert into dbo.PerformanceMeasureSubcategory(TenantID, PerformanceMeasureID, PerformanceMeasureSubcategoryDisplayName) 
output inserted.PerformanceMeasureSubcategoryID, inserted.PerformanceMeasureID, inserted.PerformanceMeasureSubcategoryDisplayName into @subCatIDsToPMs
select 7, pmID, 'Location' from @PMIDsToNames where displayName = 'Floodplain habitat protected'
-- insert options
set @subCatID = SCOPE_IDENTITY()
insert into dbo.PerformanceMeasureSubcategoryOption(TenantID, PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryOptionName, ShowOnFactSheet)
values 
(7, @subCatID, 'Default', 0)

/***** Stream miles treated *****/
insert into dbo.PerformanceMeasureSubcategory(TenantID, PerformanceMeasureID, PerformanceMeasureSubcategoryDisplayName) 
output inserted.PerformanceMeasureSubcategoryID, inserted.PerformanceMeasureID, inserted.PerformanceMeasureSubcategoryDisplayName into @subCatIDsToPMs
select 7, pmID, 'Treatment Type' from @PMIDsToNames where displayName = 'Stream miles treated'
-- insert options
set @subCatID = SCOPE_IDENTITY()
insert into dbo.PerformanceMeasureSubcategoryOption(TenantID, PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryOptionName, ShowOnFactSheet)
values 
(7, @subCatID, 'fencing', 0),
(7, @subCatID, 'instream restoration', 0),
(7, @subCatID, 'invasive weed treatment', 0),
(7, @subCatID, 'riparian planting', 0),
(7, @subCatID, 'off/side channel habitat created', 0)

/***** Number of streambanks treated *****/
insert into dbo.PerformanceMeasureSubcategory(TenantID, PerformanceMeasureID, PerformanceMeasureSubcategoryDisplayName) 
output inserted.PerformanceMeasureSubcategoryID, inserted.PerformanceMeasureID, inserted.PerformanceMeasureSubcategoryDisplayName into @subCatIDsToPMs
select 7, pmID, 'Treatment Type' from @PMIDsToNames where displayName = 'Number of streambanks treated'
-- insert options
set @subCatID = SCOPE_IDENTITY()
insert into dbo.PerformanceMeasureSubcategoryOption(TenantID, PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryOptionName, ShowOnFactSheet)
values 
(7, @subCatID, 'Planting', 0),
(7, @subCatID, 'Riparian fencing', 0)

-- subcategory 2
insert into dbo.PerformanceMeasureSubcategory(TenantID, PerformanceMeasureID, PerformanceMeasureSubcategoryDisplayName) 
output inserted.PerformanceMeasureSubcategoryID, inserted.PerformanceMeasureID, inserted.PerformanceMeasureSubcategoryDisplayName into @subCatIDsToPMs
select 7, pmID, 'Side of Stream' from @PMIDsToNames where displayName = 'Number of streambanks treated'
-- insert options
set @subCatID = SCOPE_IDENTITY()
insert into dbo.PerformanceMeasureSubcategoryOption(TenantID, PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryOptionName, ShowOnFactSheet)
values 
(7, @subCatID, 'Left', 0),
(7, @subCatID, 'Right', 0)

/***** Buffer width treated *****/
insert into dbo.PerformanceMeasureSubcategory(TenantID, PerformanceMeasureID, PerformanceMeasureSubcategoryDisplayName) 
output inserted.PerformanceMeasureSubcategoryID, inserted.PerformanceMeasureID, inserted.PerformanceMeasureSubcategoryDisplayName into @subCatIDsToPMs
select 7, pmID, 'Treatment Type' from @PMIDsToNames where displayName = 'Buffer width treated'
-- insert options
set @subCatID = SCOPE_IDENTITY()
insert into dbo.PerformanceMeasureSubcategoryOption(TenantID, PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryOptionName, ShowOnFactSheet)
values 
(7, @subCatID, 'Planting', 0),
(7, @subCatID, 'Invasive weed control', 0)

/***** Barriers improved for fish passage *****/
insert into dbo.PerformanceMeasureSubcategory(TenantID, PerformanceMeasureID, PerformanceMeasureSubcategoryDisplayName) 
output inserted.PerformanceMeasureSubcategoryID, inserted.PerformanceMeasureID, inserted.PerformanceMeasureSubcategoryDisplayName into @subCatIDsToPMs
select 7, pmID, 'Alteration Type' from @PMIDsToNames where displayName = 'Barriers improved for fish passage'
-- insert options
set @subCatID = SCOPE_IDENTITY()
insert into dbo.PerformanceMeasureSubcategoryOption(TenantID, PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryOptionName, ShowOnFactSheet)
values 
(7, @subCatID, 'dam removal/breach', 0),
(7, @subCatID, 'culvert removal', 0),
(7, @subCatID, 'culvert replacement', 0)

-- subcategory 2
insert into dbo.PerformanceMeasureSubcategory(TenantID, PerformanceMeasureID, PerformanceMeasureSubcategoryDisplayName) 
output inserted.PerformanceMeasureSubcategoryID, inserted.PerformanceMeasureID, inserted.PerformanceMeasureSubcategoryDisplayName into @subCatIDsToPMs
select 7, pmID, 'Type of passage barrier' from @PMIDsToNames where displayName = 'Barriers improved for fish passage'
-- insert options
set @subCatID = SCOPE_IDENTITY()
insert into dbo.PerformanceMeasureSubcategoryOption(TenantID, PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryOptionName, ShowOnFactSheet)
values 
(7, @subCatID, 'juvenile', 0),
(7, @subCatID, 'adult', 0)

/***** New Fish Screens Installed on Diversions *****/
insert into dbo.PerformanceMeasureSubcategory(TenantID, PerformanceMeasureID, PerformanceMeasureSubcategoryDisplayName) 
output inserted.PerformanceMeasureSubcategoryID, inserted.PerformanceMeasureID, inserted.PerformanceMeasureSubcategoryDisplayName into @subCatIDsToPMs
select 7, pmID, 'Type of Passage' from @PMIDsToNames where displayName = 'New Fish Screens Installed on Diversions'
-- insert options
set @subCatID = SCOPE_IDENTITY()
insert into dbo.PerformanceMeasureSubcategoryOption(TenantID, PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryOptionName, ShowOnFactSheet)
values 
(7, @subCatID, 'juvenile', 0),
(7, @subCatID, 'adult', 0)

/***** Total road miles treated *****/
insert into dbo.PerformanceMeasureSubcategory(TenantID, PerformanceMeasureID, PerformanceMeasureSubcategoryDisplayName) 
output inserted.PerformanceMeasureSubcategoryID, inserted.PerformanceMeasureID, inserted.PerformanceMeasureSubcategoryDisplayName into @subCatIDsToPMs
select 7, pmID, 'Treatment Type' from @PMIDsToNames where displayName = 'Total road miles treated'
-- insert options
set @subCatID = SCOPE_IDENTITY()
insert into dbo.PerformanceMeasureSubcategoryOption(TenantID, PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryOptionName, ShowOnFactSheet)
values 
(7, @subCatID, 'decomissioned', 0),
(7, @subCatID, 'improved', 0)

/***** Water flow transferred/leased instream *****/
insert into dbo.PerformanceMeasureSubcategory(TenantID, PerformanceMeasureID, PerformanceMeasureSubcategoryDisplayName) 
output inserted.PerformanceMeasureSubcategoryID, inserted.PerformanceMeasureID, inserted.PerformanceMeasureSubcategoryDisplayName into @subCatIDsToPMs
select 7, pmID, 'Habitat Type' from @PMIDsToNames where displayName = 'Water flow transferred/leased instream'
-- insert options
set @subCatID = SCOPE_IDENTITY()
insert into dbo.PerformanceMeasureSubcategoryOption(TenantID, PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryOptionName, ShowOnFactSheet)
values 
(7, @subCatID, 'Aquatic', 0),
(7, @subCatID, 'Terrestrial', 0)

-- subcategory 2
insert into dbo.PerformanceMeasureSubcategory(TenantID, PerformanceMeasureID, PerformanceMeasureSubcategoryDisplayName) 
output inserted.PerformanceMeasureSubcategoryID, inserted.PerformanceMeasureID, inserted.PerformanceMeasureSubcategoryDisplayName into @subCatIDsToPMs
select 7, pmID, 'Transaction Type' from @PMIDsToNames where displayName = 'Water flow transferred/leased instream'
-- insert options
set @subCatID = SCOPE_IDENTITY()
insert into dbo.PerformanceMeasureSubcategoryOption(TenantID, PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryOptionName, ShowOnFactSheet)
values 
(7, @subCatID, 'Transferred', 0),
(7, @subCatID, 'Leased', 0)

/***** Density of woody stems between treamtment and control location *****/
insert into dbo.PerformanceMeasureSubcategory(TenantID, PerformanceMeasureID, PerformanceMeasureSubcategoryDisplayName) 
output inserted.PerformanceMeasureSubcategoryID, inserted.PerformanceMeasureID, inserted.PerformanceMeasureSubcategoryDisplayName into @subCatIDsToPMs
select 7, pmID, 'Stem Height' from @PMIDsToNames where displayName = 'Density of woody stems between treamtment and control location'
-- insert options
set @subCatID = SCOPE_IDENTITY()
insert into dbo.PerformanceMeasureSubcategoryOption(TenantID, PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryOptionName, ShowOnFactSheet)
values 
(7, @subCatID, '<1m', 0),
(7, @subCatID, '>1m', 0)

-- subcategory 2
insert into dbo.PerformanceMeasureSubcategory(TenantID, PerformanceMeasureID, PerformanceMeasureSubcategoryDisplayName) 
output inserted.PerformanceMeasureSubcategoryID, inserted.PerformanceMeasureID, inserted.PerformanceMeasureSubcategoryDisplayName into @subCatIDsToPMs
select 7, pmID, 'Location Type' from @PMIDsToNames where displayName = 'Density of woody stems between treamtment and control location'
-- insert options
set @subCatID = SCOPE_IDENTITY()
insert into dbo.PerformanceMeasureSubcategoryOption(TenantID, PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryOptionName, ShowOnFactSheet)
values 
(7, @subCatID, 'Treatment', 0),
(7, @subCatID, 'Control', 0)

/***** Density of woody stems between treamtment and control location *****/
insert into dbo.PerformanceMeasureSubcategory(TenantID, PerformanceMeasureID, PerformanceMeasureSubcategoryDisplayName) 
output inserted.PerformanceMeasureSubcategoryID, inserted.PerformanceMeasureID, inserted.PerformanceMeasureSubcategoryDisplayName into @subCatIDsToPMs
select 7, pmID, 'Measurement Type' from @PMIDsToNames where displayName = 'Discharge at Ritter USGS gauging station'
-- insert options
set @subCatID = SCOPE_IDENTITY()
insert into dbo.PerformanceMeasureSubcategoryOption(TenantID, PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryOptionName, ShowOnFactSheet)
values 
(7, @subCatID, 'Mean Flow Rate', 0),
(7, @subCatID, 'Minimum Flow Rate', 0)

/***** Percent of stream length downstream from Hwy 19 with surface water during July-August base flow *****/
insert into dbo.PerformanceMeasureSubcategory(TenantID, PerformanceMeasureID, PerformanceMeasureSubcategoryDisplayName) 
output inserted.PerformanceMeasureSubcategoryID, inserted.PerformanceMeasureID, inserted.PerformanceMeasureSubcategoryDisplayName into @subCatIDsToPMs
select 7, pmID, 'Measurement Type' from @PMIDsToNames where displayName = 'Percent of stream length downstream from Hwy 19 with surface water during July-August base flow'
-- insert options
set @subCatID = SCOPE_IDENTITY()
insert into dbo.PerformanceMeasureSubcategoryOption(TenantID, PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryOptionName, ShowOnFactSheet)
values 
(7, @subCatID, 'Mean Flow Rate', 0),
(7, @subCatID, 'Minimum Flow Rate', 0)

/***** Flow measured at the CTUIR installed gauging station near mouth of desolation *****/
insert into dbo.PerformanceMeasureSubcategory(TenantID, PerformanceMeasureID, PerformanceMeasureSubcategoryDisplayName) 
output inserted.PerformanceMeasureSubcategoryID, inserted.PerformanceMeasureID, inserted.PerformanceMeasureSubcategoryDisplayName into @subCatIDsToPMs
select 7, pmID, 'Measurement Type' from @PMIDsToNames where displayName = 'Flow measured at the CTUIR installed gauging station near mouth of desolation'
-- insert options
set @subCatID = SCOPE_IDENTITY()
insert into dbo.PerformanceMeasureSubcategoryOption(TenantID, PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryOptionName, ShowOnFactSheet)
values 
(7, @subCatID, 'Mean Flow Rate', 0),
(7, @subCatID, 'Minimum Flow Rate', 0)


/***** Update all Subcategories with a Chart Config*****/
declare @PMsAndSubCats table (subCatID int, pmDisplayName varchar(200), chartConfig varchar(1200))

insert into @PMsAndSubCats(subCatID, pmDisplayName)
select subCatID, displayName from @subCatIDsToPMs sc join @PMIDsToNames pms on pms.pmID = sc.pmID

update @PMsAndSubCats set chartConfig = 
REPLACE(
'{
  "title": "PERFORMANCE_MEASURE_NAME",
  "titlePosition": "none",
  "legend": {
    "position": "top",
    "maxLines": 3
  },
  "hAxis": {
    "title": "Year",
    "titleTextStyle": {
      "italic": false,
      "bold": false,
      "fontSize": 12,
      "fontWidth": "normal"
    },
    "textStyle": null,
    "useFormatFromData": true,
    "formatOptions": {
      "source": "inline"
    },
    "format": "",
    "gridlines": {
      "count": -1,
      "color": "transparent"
    }
  },
  "vAxes": [],
  "series": null,
  "backgroundColor": {
    "fill": "white"
  },
  "legendTextStyle": null,
  "titleTextStyle": null,
  "isStacked": true,
  "focusTarget": "category",
  "tooltip": null,
  "curveType": null,
  "lineWidth": 2,
  "annotations": {
    "style": "line"
  },
  "seriesType": null,
  "type": null,
  "connectSteps": false,
  "theme": null
}', 'PERFORMANCE_MEASURE_NAME', pmDisplayName)

select * from @PMsAndSubCats

select top 10 * from dbo.PerformanceMeasureSubcategory

update dbo.PerformanceMeasureSubcategory set ChartConfigurationJson = (select chartConfig from @PMsAndSubCats where subCatID = PerformanceMeasureSubcategoryID) where PerformanceMeasureSubcategoryID in (select subCatID from @PMsAndSubCats)
update dbo.PerformanceMeasureSubcategory set GoogleChartTypeID = 1 where PerformanceMeasureSubcategoryID in (select subCatID from @PMsAndSubCats)