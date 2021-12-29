-- delete any taxonomy leaf performance measures
delete from dbo.TaxonomyLeafPerformanceMeasure where TenantID = 4


-- delete any PM expected subcategoy options updates
delete from dbo.PerformanceMeasureExpectedSubcategoryOptionUpdate where TenantID = 4

-- delete any PM expected subcategories updates
delete from dbo.PerformanceMeasureExpectedUpdate where TenantID = 4


-- delete any PM actual subcategoy options updates
delete from dbo.PerformanceMeasureActualSubcategoryOptionUpdate where TenantID = 4

-- delete any PM actual subcategories updates
delete from dbo.PerformanceMeasureActualUpdate where TenantID = 4
 

-- delete any PM expected subcategoy options
delete from dbo.PerformanceMeasureExpectedSubcategoryOption where TenantID = 4

-- delete any PM expected subcategories
delete from dbo.PerformanceMeasureExpected where TenantID = 4


-- delete any PM actual subcategoy options
delete from dbo.PerformanceMeasureActualSubcategoryOption where TenantID = 4

-- delete any PM actual subcategories
delete from dbo.PerformanceMeasureActual where TenantID = 4

-- delete any matchmaker PMs
delete from dbo.MatchmakerOrganizationPerformanceMeasure where TenantID = 4


-- delete subcategory options
delete from dbo.PerformanceMeasureSubcategoryOption where TenantID = 4

-- delete subcategories
delete from dbo.PerformanceMeasureSubcategory where TenantID = 4

-- delete PMs
delete from dbo.PerformanceMeasure where TenantID = 4

-- add measurement unit
insert into dbo.MeasurementUnitType (MeasurementUnitTypeID, MeasurementUnitTypeName, MeasurementUnitTypeDisplayName, LegendDisplayName, SingularDisplayName, NumberOfSignificantDigits)
values
(39, 'KilowattHour', 'Kilowatt-hours', 'kWh', 'Kilowatt-hour', 2)

-- make table variable to store new IDs in
declare @insertedPMs table(pmID int);


-- add new PMs
insert into dbo.PerformanceMeasure (TenantID,CriticalDefinitions,ProjectReporting,PerformanceMeasureDisplayName,MeasurementUnitTypeID,PerformanceMeasureTypeID,PerformanceMeasureDefinition,DataSourceText,ExternalDataSourceUrl,ChartCaption,PerformanceMeasureSortOrder,IsSummable,PerformanceMeasureDataSourceTypeID,Importance,AdditionalInformation,CanBeChartedCumulatively)
output INSERTED.PerformanceMeasureID into @insertedPMs(pmID)
values
(4, null, null, 'Agricultural and resource dependent heritage preservation', 24, 1, 'Number of agricultural and resource dependent heritage preservation activities preserved in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Avoided Costs - Emergency repairs and service disruptions', 9, 2, 'Costs of emergency repairs and service disruptions avoided in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Avoided Costs - Injury and/ or property damage', 9, 2, 'Injury and/ or property damage avoided in any given year, including flood damage.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Avoided Costs - Wastewater treatment costs', 9, 2, 'Wastewater treatment costs avoided in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Avoided Costs - Wastewater violations/ fines', 9, 2, 'Wastewater violations/ fines avoided in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Avoided Costs - Water supply and/or treatment costs ', 9, 2, 'Water supply and/or treatment costs avoided in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Avoided Costs - Water supply purchases', 9, 2, 'Water supply purchases avoided in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Avoided Costs - Road maintenance costs', 9, 2, 'Road maintenance costs decreased or avoided in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Avoided Costs - Other', 9, 2, 'Other savings due to project implementation, such as avoided shellfish industry closures, TMDL enforcement costs, lost revenue, costs of culvert failures, etc.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Avoided Costs - Project costs', 9, 2, 'Project costs avoided, averaged over the expected span of the project life.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'GHG reduction - Reduced emissions', 8, 2, 'Metric tons of greenhouse gase emissions reduced in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'GHG reduction - Sustainable energy', 39, 2, 'Kilowatt-hours of energy generated from sustainable sources in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Carbon sequestration', 8, 2, 'Metric tons of carbon sequestered in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Conflict reduction', 24, 2, 'Number of conflicts reduced in any given year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Education & outreach - Number of events', 24, 1, 'Number of education and outreach events held in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Education & outreach - Number of participants', 24, 1, 'Number of people participating in education and outreach events held in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Enhanced firefighting capabilities - Additional funding', 9, 2, 'Additional funding realized for enhanced firefighting capabilities in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Enhanced firefighting capabilities - Hydrants installed', 24, 1, 'Number of fire hydrants installed in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Enhanced firefighting capabilities - Human lives protected', 24, 2, 'Human lives protected by enhanced firefighting capabilitites in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Enhanced firefighting capabilities - Households protected', 24, 2, 'Households protected by enhanced firefighting capabilitites in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Enhanced firefighting capabilities - Fire-safe and emergency roads', 2, 1, 'Miles of fire-safe and emergency roads created in any year', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Enhanced firefighting capabilities - Improved infrastructure', 24, 1, 'Count of infrastructure improvements for enhanced firefighting capabilitites in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Enhanced firefighting capabilities - Equipment and supplies', 24, 1, 'Count of equipment and supplies acquired for enhanced firefighting capabilities in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Environmental justice and social equity', 24, 1, 'Number of environmental justice and social equity activites performed in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Fishery improvement - Instream fish habitat', 2, 1, 'Miles of instream fish habitat created in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Fishery improvement - Increased salmonid population', 24, 2, 'Number of increased fish populations in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Fishery improvement - Fishery improvement ', 24, 1, 'Number of fishery improvement activities performed in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Forest Health Improvement', 1, 1, 'Acres of forest health improved in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Habitat Restoration - Area of habitat restored', 1, 1, 'Acres of habitat restored in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Habitat Restoration - Stream channel improved', 4, 1, 'Linear feet of stream channel improved or restored in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Habitat Restoration - Plantings', 24, 1, 'Number of plantings in habitat restoration projects in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Habitat Restoration - Survival of native plantings', 11, 2, 'Survival rate of native plantings in restoration projects in any year.', null, null, null, null, 0, 1, null, null, 0),
(4, null, null, 'Hazardous fuels reduction', 1, 1, 'Acres of hazardous fuels reduced in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Honoring & incorporating Tribal cultural priorities and protocols', 24, 1, 'Number of tribal cultural priorities and protocols honored & incorporated in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Improved groundwater quality', 19, 2, 'Acre-feet of groundwater improved in any year', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Improved soil health', 1, 2, 'Acres of soil health improved in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Improved water management or supply reliability - Water volume improved', 19, 1, 'Acre-feet of improved water management or supply reliability in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Improved water management or supply reliability - Households impacted', 24, 2, 'Number of households impacted by improving water management or supply reliability in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Increased instream flow - Water volume increased (acre-feet)', 19, 2, 'Acre-Feet of instream flow increased in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Increased instream flow - Water volume increased (cfs)', 30, 2, 'Cubic Feet/second of of instream flow increased in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Increased instream flow - Activities performed', 24, 1, 'Number of activities performed to increase instream flow in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Job/ workforce training for resilience/green economy - Trainings ', 24, 1, 'Number of trainings for resilience/green economy held in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Job/ workforce training for resilience/green economy - Jobs created (FTE)', 24, 2, 'Number of FTE jobs created/maintained in local economy in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Protect or increase recreation and access (days per year)', 24, 2, 'Days of recreation and access protected or increased in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Sediment reduction - Roads treated', 2, 1, 'Miles of road treated for sediment reduction in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Sediment reduction - Streambank stabilized', 4, 1, 'Linear feet of streambank stabilized to prevent sediment reduction in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Sediment reduction - Total sediment reduced', 8, 2, 'Tons of sediment reduced by stabilization or removal in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Sediment reduction - Culvert failures avoided', 24, 2, 'Number of culvert failures avoided in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Social health and safety', 24, 1, 'Number of social health and safety activities performed in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Special status species protected', 24, 2, 'Number of special status species protected in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Drinking water saved', 19, 2, 'Acre-feet of drinking water saved in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Water supply produced', 19, 2, 'Acre-feet of water supply protected in any year.', null, null, null, null, 1, 1, null, null, 1),
(4, null, null, 'Water quality improvement - Activities performed', 24, 1, 'Number of water quality improvement activities performed in any year.', null, null, null, null, 1, 1, null, null, 1)

-- add default subcateogies for each PM
declare @pmID int;
declare @pmSubCatID int;
WHILE EXISTS(SELECT * FROM @insertedPMs)
begin
	select top 1 @pmID = pmID from @insertedPMs
	insert into dbo.PerformanceMeasureSubcategory (TenantID,PerformanceMeasureID,PerformanceMeasureSubcategoryDisplayName,ChartConfigurationJson,GoogleChartTypeID,CumulativeChartConfigurationJson,CumulativeGoogleChartTypeID,GeospatialAreaTargetChartConfigurationJson,GeospatialAreaTargetGoogleChartTypeID)
	values
	(4, @pmID, 'Default', '{"title": "Default", "titlePosition": "none","legend": {  "position": "top",  "maxLines": 3},"hAxis": {  "title": "Year",  "titleTextStyle": {"italic": false,"fontSize": 12,"fontWidth": "normal"  },  "useFormatFromData": true,  "formatOptions": {"source": "inline"  },  "format": "",  "gridlines": {"count": -1,"color": "transparent"  }},"vAxes": [],"series": null,"backgroundColor": {  "fill": "white"},"legendTextStyle": null,"titleTextStyle": null,"isStacked": true,"focusTarget": "category","tooltip": null,"curveType": null,"lineWidth": 2,"annotations": {  "style": "line"},"seriesType": null,"type": null,"connectSteps": false,"theme": null}', 1, NULL, NULL, NULL, NULL)

	set @pmSubCatID = SCOPE_IDENTITY();
	insert into dbo.PerformanceMeasureSubcategoryOption(TenantID, PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryOptionName, SortOrder, ShowOnFactSheet)
	values
	(4, @pmSubCatID, 'Default', 1, 0)

	delete from @insertedPMs where pmID = @pmID
end
