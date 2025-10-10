update PerformanceMeasureSubcategory set  
ChartConfigurationJson = 
'{"title":"Acres of Forest Fuels Reduction Treatment","titlePosition":null,"legend":{"position":"bottom"},"hAxis":{"title":null,"titleTextStyle":{"italic":false,"bold":false,"color":"#222","fontSize":12,"fontWidth":"normal"},"textStyle":{"italic":false,"bold":false,"color":"#222","fontSize":12,"fontWidth":"normal"},"useFormatFromData":false,"formatOptions":{"source":"inline"},"format":"0.##"},"vAxes":[{"title":null,"titleTextStyle":{"italic":false,"bold":false,"color":"#222","fontSize":12,"fontWidth":"normal"},"textStyle":null,"useFormatFromData":false,"formatOptions":{"source":"inline"},"viewWindow":{"min":0},"format":"0.##"},{"title":null,"titleTextStyle":{"italic":false,"bold":false,"color":"#222","fontSize":12,"fontWidth":"normal"},"textStyle":null,"useFormatFromData":false,"formatOptions":{"source":"inline"},"viewWindow":{"min":0},"format":"0.##"}],"series":[{"type":"bars","color":"#5b0f00","lineWidth":2},{"type":null,"color":"#85200c"},{"type":null,"color":"#cc0000"},{"type":null,"color":"#cc4125"},{"type":null,"color":"#dd7e6b"},{"type":null,"color":"#b45f06"},{"type":null,"color":"#f6b26b"},{"type":null,"color":"#ffd966"},{"type":null,"color":"#f6b26b"},{"type":null,"color":"#bf9000"},{"type":null,"color":"#741b47"}],"backgroundColor":{"fill":"#ffffff"},"domainAxis":{"direction":1},"legendTextStyle":null,"titleTextStyle":null,"isStacked":true,"focusTarget":"category","tooltip":{"isHtml":true,"showColorCode":false,"text":null},"curveType":null,"lineWidth":0,"annotations":{"style":"line"},"seriesType":null,"type":null,"connectSteps":false,"theme":null}'
where PerformanceMeasureSubcategoryID= 4056

  insert into dbo.AuditLog ([TenantID]
      ,[PersonID]
      ,[AuditLogDate]
      ,[AuditLogEventTypeID]
      ,[TableName]
      ,[RecordID]
      ,[ColumnName]
      ,[OriginalValue]
      ,[NewValue]
      ,[AuditDescription]
      ,[ProjectID])

	  values
	  (14,
	  8610,
	  CURRENT_TIMESTAMP,
	  3,
	  'PerformanceMeasureSubcategory',
	  4056,
	  'ChartConfigurationJson',
	  '{"title":"Acres of Forest Fuels Reduction Treatment","titlePosition":null,"legend":{"position":"right"},"hAxis":{"title":null,"titleTextStyle":{"italic":false,"bold":false,"color":"#222","fontSize":12,"fontWidth":"normal"},"textStyle":{"italic":true,"bold":false,"color":"#222","fontSize":12,"fontWidth":"normal"},"useFormatFromData":false,"formatOptions":{"source":"inline"},"format":"0.##"},"vAxes":[{"title":null,"titleTextStyle":{"italic":false,"bold":false,"color":"#222","fontSize":12,"fontWidth":"normal"},"textStyle":null,"useFormatFromData":false,"formatOptions":{"source":"inline"},"viewWindow":{"min":0},"format":"0.##"},{"title":null,"titleTextStyle":{"italic":false,"bold":false,"color":"#222","fontSize":12,"fontWidth":"normal"},"textStyle":null,"useFormatFromData":false,"formatOptions":{"source":"inline"},"viewWindow":{"min":0},"format":"0.##"}],"series":[{"type":"bars","color":"#5b0f00","lineWidth":2},{"type":null,"color":"#85200c"},{"type":null,"color":"#cc0000"},{"type":null,"color":"#cc4125"},{"type":null,"color":"#dd7e6b"},{"type":null,"color":"#b45f06"},{"type":null,"color":"#f6b26b"},{"type":null,"color":"#ffd966"},{"type":null,"color":"#f6b26b"},{"type":null,"color":"#bf9000"},{"type":null,"color":"#741b47"}],"backgroundColor":{"fill":"#ffffff"},"domainAxis":{"direction":-1},"legendTextStyle":null,"titleTextStyle":null,"height":371,"width":600,"isStacked":true,"focusTarget":"category","tooltip":{"isHtml":true,"showColorCode":false,"text":null},"curveType":null,"lineWidth":0,"annotations":{"style":"line"},"seriesType":null,"type":null,"connectSteps":false,"theme":null}',
      '{"title":"Acres of Forest Fuels Reduction Treatment","titlePosition":null,"legend":{"position":"bottom"},"hAxis":{"title":null,"titleTextStyle":{"italic":false,"bold":false,"color":"#222","fontSize":12,"fontWidth":"normal"},"textStyle":{"italic":false,"bold":false,"color":"#222","fontSize":12,"fontWidth":"normal"},"useFormatFromData":false,"formatOptions":{"source":"inline"},"format":"0.##"},"vAxes":[{"title":null,"titleTextStyle":{"italic":false,"bold":false,"color":"#222","fontSize":12,"fontWidth":"normal"},"textStyle":null,"useFormatFromData":false,"formatOptions":{"source":"inline"},"viewWindow":{"min":0},"format":"0.##"},{"title":null,"titleTextStyle":{"italic":false,"bold":false,"color":"#222","fontSize":12,"fontWidth":"normal"},"textStyle":null,"useFormatFromData":false,"formatOptions":{"source":"inline"},"viewWindow":{"min":0},"format":"0.##"}],"series":[{"type":"bars","color":"#5b0f00","lineWidth":2},{"type":null,"color":"#85200c"},{"type":null,"color":"#cc0000"},{"type":null,"color":"#cc4125"},{"type":null,"color":"#dd7e6b"},{"type":null,"color":"#b45f06"},{"type":null,"color":"#f6b26b"},{"type":null,"color":"#ffd966"},{"type":null,"color":"#f6b26b"},{"type":null,"color":"#bf9000"},{"type":null,"color":"#741b47"}],"backgroundColor":{"fill":"#ffffff"},"domainAxis":{"direction":1},"legendTextStyle":null,"titleTextStyle":null,"isStacked":true,"focusTarget":"category","tooltip":{"isHtml":true,"showColorCode":false,"text":null},"curveType":null,"lineWidth":0,"annotations":{"style":"line"},"seriesType":null,"type":null,"connectSteps":false,"theme":null}',
	  null,
	  null)