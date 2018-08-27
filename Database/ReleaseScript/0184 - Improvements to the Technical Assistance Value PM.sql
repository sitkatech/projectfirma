Insert Into MeasurementUnitType ([MeasurementUnitTypeID], [MeasurementUnitTypeName], [MeasurementUnitTypeDisplayName], [LegendDisplayName], [SingularDisplayName], [NumberOfSignificantDigits])
values
(23, 'Hours', 'hours ', 'hours', 'Hour', 0)

Update dbo.PerformanceMeasure
set MeasurementUnitTypeID = 23,
PerformanceMeasureDisplayName = 'Engineering and Technical Assistance'
Where PerformanceMeasureID = 2147

Insert Into PerformanceMeasureSubcategory([TenantID], [PerformanceMeasureID], [PerformanceMeasureSubcategoryDisplayName], [ChartConfigurationJson], [GoogleChartTypeID])
values (9,
2147,
'Provided To',
'{    "title": "Engineering & Technical Assistance to Conservation Districts",    "titlePosition": "none",    "legend": {      "position": "top",      "maxLines": 3    },    "hAxis": {      "title": "Reporting Year",      "titleTextStyle": {        "italic": false,        "bold": false,        "fontSize": 12,        "fontWidth": "normal"      },      "textStyle": null,      "useFormatFromData": true,      "formatOptions": {        "source": "inline"      },      "format": "",      "gridlines": {        "count": -1,        "color": "transparent"      }    },    "vAxes": [],    "series": null,    "backgroundColor": {      "fill": "white"    },    "legendTextStyle": null,    "titleTextStyle": null,    "isStacked": true,    "focusTarget": "category",    "tooltip": null,    "curveType": null,    "lineWidth": 2,    "annotations": {      "style": "line"    },    "seriesType": null,    "type": null,    "connectSteps": false,    "theme": null  }',
1)

declare @newSubcatID int = Scope_Identity()

Insert into PerformanceMeasureSubcategoryOption ([TenantID], [PerformanceMeasureSubcategoryID], [PerformanceMeasureSubcategoryOptionName], [SortOrder], [ShowOnFactSheet])
values
(9,
@newSubcatID,
'Conservation District',
1,
0),
(9,
@newSubcatID,
'Other Agency',
1,
0)