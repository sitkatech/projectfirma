SELECT TOP (1000) [AuditLogID]
      ,[TenantID]
      ,[PersonID]
      ,[AuditLogDate]
      ,[AuditLogEventTypeID]
      ,[TableName]
      ,[RecordID]
      ,[ColumnName]
      ,[OriginalValue]
      ,[NewValue]
      ,[AuditDescription]
      ,[ProjectID]
  FROM [ProjectFirma].[dbo].[AuditLog]
  where tenantid = 14
order by [AuditLogDate] desc

select * from dbo.PerformanceMeasureSubcategory where PerformanceMeasureSubcategoryID = 4056


update dbo.PerformanceMeasureSubcategory  set ChartConfigurationJson
=
'{"title":"Acres of Forest Fuels Reduction Treatment","titlePosition":"none","legend":{"position":"right"},"hAxis":{"title":"Year","titleTextStyle":{"italic":true,"bold":false,"color":"#222","fontSize":12,"fontWidth":"normal"},"textStyle":null,"useFormatFromData":false,"formatOptions":{"source":"inline"},"format":"0.##","gridlines":{"count":-1,"color":"transparent"}},"vAxes":[{"title":null,"titleTextStyle":{"italic":false,"bold":false,"fontSize":12,"fontWidth":"normal"},"textStyle":null,"useFormatFromData":true,"formatOptions":{"source":"inline"},"viewWindow":{"min":0},"format":""},{"title":null,"titleTextStyle":{"italic":false,"bold":false,"fontSize":12,"fontWidth":"normal"},"textStyle":null,"useFormatFromData":true,"formatOptions":{"source":"inline"},"viewWindow":{"min":0},"format":""}],"backgroundColor":{"fill":"#ffffff"},"legendTextStyle":null,"titleTextStyle":null,"height":371,"width":600,"isStacked":true,"focusTarget":"category","tooltip":{"isHtml":true,"showColorCode":false,"text":null},"curveType":null,"lineWidth":2,"annotations":{"style":"line"},"seriesType":null,"type":null,"connectSteps":false,"theme":null}'
where PerformanceMeasureSubcategoryID = 4056

