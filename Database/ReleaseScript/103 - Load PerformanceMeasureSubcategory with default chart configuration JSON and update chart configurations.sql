  alter table dbo.performancemeasuresubcategory add ChartYAxis varchar(100) null
  go
  update dbo.PerformanceMeasureSubcategory set dbo.PerformanceMeasureSubcategory.ChartYAxis = 
  (
  select UPPER(LEFT(MeasurementUnitTypeDisplayName,1))+LOWER(SUBSTRING(MeasurementUnitTypeDisplayName,2,LEN(MeasurementUnitTypeDisplayName)))
  from dbo.MeasurementUnitType mut where mut.MeasurementUnitTypeID = 
   (select pm.MeasurementUnitTypeID from dbo.PerformanceMeasure pm where pm.PerformanceMeasureID = dbo.PerformanceMeasureSubcategory.PerformanceMeasureID )
  )
  Update dbo.PerformanceMeasureSubcategory
  set ChartConfigurationJson = '{"title":"'+ PerformanceMeasureSubcategoryDisplayName +
  '","titlePosition":"none","legend":{"position":"top"},"hAxis":{"title":"Year","titleTextStyle":{"italic":false,"fontSize":12,"fontWidth":"normal"},"useFormatFromData":true,"formatOptions":{},"viewWindow":{"min":0}},"vAxes":[{"title":"' + 
  ChartYAxis + 
  '","titleTextStyle":{"italic":false,"fontSize":12,"fontWidth":"normal"},"useFormatFromData":false,"formatOptions":{"source":"inline"},"viewWindow":{"min":0}},{"title":null,"titleTextStyle":{"italic":false,"fontSize":12,"fontWidth":"normal"},"useFormatFromData":true,"formatOptions":{},"viewWindow":{"min":0}}],"series":null,"backgroundColor":{"fill":"white"},"legendTextStyle":{"italic":false,"fontSize":11,"fontWidth":"normal"},"titleTextStyle":{"italic":false,"fontSize":16,"fontWidth":"normal"},"isStacked":true,"focusTarget":"category","curveType":null,"lineWidth":0}',
	  GoogleChartTypeID = 1
  Where ChartConfigurationJson is null
  alter table dbo.PerformanceMeasureSubcategory drop column ChartYAxis

 Update dbo.PerformanceMeasureSubcategory
 set ChartConfigurationJson = replace(ChartConfigurationJson,'"titlePosition":null','"titlePosition":"none"')
 Where ChartConfigurationJson is not null
 
 Update dbo.PerformanceMeasureSubcategory
 set ChartConfigurationJson = replace(ChartConfigurationJson,'"formatOptions":{"','"format":"short","formatOptions":{"')
 Where ChartConfigurationJson is not null

  Update dbo.PerformanceMeasureSubcategory
 set ChartConfigurationJson = replace(ChartConfigurationJson,'"suffix":"K",','')
 Where ChartConfigurationJson is not null