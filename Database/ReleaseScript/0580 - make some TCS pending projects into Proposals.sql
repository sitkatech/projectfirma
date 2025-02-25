select * from dbo.project where projectname in ('Union Mine Landfill Retention Ponds',
'Sly Park Portal Subdivision Flood Management Project',
'Regional Water System Reliability and Conservation Project -- Canal Lining',
'Foresthill Hardrock Lane Pressure Reducing Station Replacement',
'Fairgrounds Water Quality Improvements',
'Countywide Water Quality Awareness Campaign',
'County Water Quality Standards Improvement Project',
'Camino Heights Wastewater Treatment Plant Disposal Improvements',
'Countywide Park BMP Retrofit Improvements',
'County Wide Water Quality Monitoring',
'Best Management Practices for Agricultural Erosion and Sediment Control Manual',
'Weber Creek Restoration',
'New York Creek Restoration',
'East Weimar Cross Road Loop Water Supply Project',
'Carson Creek Restoration')

update dbo.Project set ProjectStageID = 1 
where TenantID = 14
and ProjectName in ('Union Mine Landfill Retention Ponds',
'Sly Park Portal Subdivision Flood Management Project',
'Regional Water System Reliability and Conservation Project -- Canal Lining',
'Foresthill Hardrock Lane Pressure Reducing Station Replacement',
'Fairgrounds Water Quality Improvements',
'Countywide Water Quality Awareness Campaign',
'County Water Quality Standards Improvement Project',
'Camino Heights Wastewater Treatment Plant Disposal Improvements',
'Countywide Park BMP Retrofit Improvements',
'County Wide Water Quality Monitoring',
'Best Management Practices for Agricultural Erosion and Sediment Control Manual',
'Weber Creek Restoration',
'New York Creek Restoration',
'East Weimar Cross Road Loop Water Supply Project',
'Carson Creek Restoration')