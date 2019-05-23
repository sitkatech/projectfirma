Select p.ProjectID, ProjectName, GeospatialAreaID, PerformanceMeasureActualID, PerformanceMeasureExpectedID, pub.ProjectUpdateBatchID, PerformanceMeasureActualUpdateID Into #projectsToDelete From dbo.Project p
Join dbo.ProjectGeospatialArea pga On p.ProjectID = pga.ProjectID
Left Join dbo.PerformanceMeasureActual pma On p.ProjectID = pma.ProjectID
Left Join dbo.PerformanceMeasureExpected pme On p.ProjectID = pme.ProjectID
Left Join dbo.ProjectUpdateBatch pub On p.ProjectID = pub.ProjectID
Left Join dbo.PerformanceMeasureActualUpdate pmau On pub.ProjectUpdateBatchID = pmau.ProjectUpdateBatchID
Where p.TenantID = 9 And ProjectName in (
'Badger Creek 33 (East Side CD)',
'Bancroft 65 (Caribou CD)',
'Big Canyon Creek 1009 (Nez Perce CD)',
'Bitch Creek North 1039 (Yellowstone CD)',
'Bitch Creek South 1022 (Teton CD)',
'Boulder Creek Sawqp 269 (Valley CD)',
'Boulder/Willow 319 1603 (Valley CD)',
'Boulder/Willow Wqpa 1462 (Valley CD)',
'Burley/Marsh Cr. Irrigation Conversion Project 1157 (West Cassia CD)',
'Burley/Marsh Creek Groundwater Improvement 483 (West Cassia CD)',
'Camas Creek 1008 (Camas CD)',
'Cascade Reservoir 1003 (Valley CD)',
'Challis Creek Water Quality Project 2157 (Custer CD)',
'Cow Creek Water Quality Improvement Project (Latah CD)',
'Crane Creek 1062 (Weiser River CD)',
'Crane Creek 719-2',
'Dairy Creek 38 (Oneida CD)',
'Daniels 1007 (Oneida CD)',
'Div. I Tmdl Implementation 1204 (Bonner CD)',
'Dixie Slough Wqpa 1002 (Canyon CD)',
'East Upper Deep Creek 105 (Balanced Rock CD)',
'Enterprise Canal Water Quality Project 1270 (Yellowstone CD)',
'Fifteenmile Creek Wqpa 1046 (Ada CD)',
'Fish Creek 1008 (Bonner CD)',
'Gem Group Project 134 (Gem CD)',
'George''s Test Project',
'Granite Creek 1014 (East Side CD)',
'Granite Creek 429-2',
'Grants 16010102 104 (Bear Lake CD)',
'Grants 16010201 105 (Bear Lake CD)',
'Grants 17010301 169 (Division 1)',
'Grants 17040201 221 (Jefferson CD)',
'Grants 17040203 107 (Yellowstone CD)',
'Grants 17040204 29 (Madison CD)',
'Grants 17040207 175 (Bear Lake CD)',
'Grants 17040208 10 (Caribou - Portneuf CD)',
'Grants 17040209 27 (West Cassia CD)',
'Grants 17040209 43 (Minidoka CD)',
'Grants 17040210 131 (East Cassia CD)',
'Grants 17040212 112 (Snake River Twin Falls CD)',
'Grants 17040212 7 (Balanced Rock CD)',
'Grants 17040213 116 (Balanced Rock CD)',
'Grants 17040214 123 (Clark CD)',
'Grants 17040219 38 (Gooding CD)',
'Grants 17040219 52 (Wood River CD)',
'Grants 17040220 64 (Balanced Rock CD)',
'Grants 17040221 11 (Wood River CD)',
'Grants 17050101 24 (Elmore CD)',
'Grants 17050102 50 (Bruneau River CD)',
'Grants 17050103 137 (Canyon CD)',
'Grants 17050114 1 (Canyon CD)',
'Grants 17050115 142 (Canyon CD)',
'Grants 17050115 62 (Payette CD)',
'Grants 17050122 122 (Squaw Creek CD)',
'Grants 17050123 13 (Valley CD)',
'Grants 17050124 12 (Weiser River CD)',
'Grants 17050124 208 (Adams CD)',
'Grants 17060101 (Idaho CD)',
'Grants 17060108 100 (Latah Nez Perce CD)',
'Grants 17060201 222 (Custer CD)',
'Grants 17060202 111 (Custer CD)',
'Grants 17060203 82 (Lemhi CD)',
'Grants 17060204 150 (Lemhi CD)',
'Grants 17060210 155 (Idaho CD)',
'Grants 17060210 161 (Adams CD)',
'Grants 17060306 106 (Nez Perce CD)',
'Grants 17060308 190 (Clearwater CD)',
'Henry''S Lake Wqpa 1096 (Yellowstone CD)',
'Henry''S Lake Wqpa 752-2',
'Jump Creek, Succor Creek Tmdl Impl.Project 1207 (Owyhee CD)',
'Lake Creek 1003 (Kootenai-Shoshone CD)',
'Lake Fork Creek Eqip 841 (Valley CD)',
'Lemhi Water Quality Project 1012 (Lemhi CD)',
'Lenville 153 (Latah CD)',
'Lone Pine 52 (Portneuf CD)',
'Lower Payette River 1068 (Payette CD)',
'Lower Payette River II 1011 (Payette CD)',
'Lower Payette River Project 1101 (Gem CD)',
'Lower Payette River Tmdl Impl. Watershed 1209 (Gem CD)',
'Lower West Branch Priest River 1876 (Bonner CD)',
'Ls/Lq 102 (Snake River CD)',
'Malad River W Drain Implementation Project 1224 (Gooding CD)',
'Marsh Creek Watershed Project 1404 (Portneuf CD)',
'Meadow Creek 34 (East Side CD)',
'Medicine Lodge Creek 1044 (Clark CD)',
'Mica Creek 1103 (Kootenai-Shoshone CD)',
'Middle Little Wood River 1000 (Wood River CD)',
'Middle Little Wood River 1084-2',
'Middle Little Wood River 1086-2',
'Middle Little Wood River 793-2',
'Middle Little Wood River 940-2',
'Middle Little Wood River 946-2',
'Mission/Sheep Creek 1 (Benewah CD)',
'Mud Creek 1047 (Valley CD)',
'Ne Worley 538 (Kootenai-Shoshone CD)',
'North Fork Coeur D''Alene River Habitat Improvement Project-Osc 1415 (Kootenai-Shoshone CD)',
'North Fork Payette Wqpa 1205 (Valley CD)',
'Pahsimeroi Water Quality Project 1175 (Custer CD)',
'Paradise Creek 1581 (Latah CD)',
'Pine Creek 542 (Nez Perce CD)',
'Plummer Creek 100 (Benewah CD)',
'Potlatch River Water Quality Improvement Project 610 (Latah CD)',
'PROGRAM??? 6 Private Landowners 1457',
'Raft River At The Narrows Restoration Project 1180 (East Cassia CD)',
'S. Fork Boise River 151 (Elmore CD)',
'Salmon Falls Watershed Tmdl Impl. Project 1252 (Balanced Rock CD)',
'Sand Hollow West 1058 (Canyon CD)',
'Santa Creek Tmdl Implementation Project 1127 (Benewah CD)',
'Scott''S Pond 1656 (North Side CD)',
'South Fork Of The Palouse River 29 (Latah CD)',
'Squirrel Creek 101 (Yellowstone CD)',
'Tensed/Lolo Creek 541 (Benewah CD)',
'Teton River 1072 (Teton CD)',
'Tex Creek 540 (East Side CD)',
'Twentyfourmile Creek 1163 (Caribou CD)',
'Upper Conant Creek 102 (Yellowstone CD)',
'Upper Hangman Creek 10 (Benewah CD)',
'Upper Portneuf River 210 (Caribou CD)',
'Upper Rapid Creek 100 (Portneuf CD)',
'Vinyard Creek 104 (North Side CD)',
'Water Quality Program for Agriculture',
'Weiser Water Quality Protection Project 1838 (Weiser River CD)',
'Weiser Wq Protection Project Phase Ii 2122 (Weiser River CD)',
'West Upper Deep Creek 10 (Balanced Rock CD)',
'West Upper Deep Creek 1001-2',
'West Upper Deep Creek 1028-2',
'West Upper Deep Creek 739-2',
'West Upper Deep Creek 801-2',
'West Upper Deep Creek 864-2',
'West Upper Deep Creek 865-2',
'Wide Hollow 11 (Oneida CD)')

GO

/*Delete Geospatial Related with list of Projects to delete */
Delete From dbo.ProjectGeospatialArea Where ProjectID In (Select ProjectID From #projectsToDelete) And TenantID = 9

GO

/*Delete Reported Performance Measures Connected with list of Projects to delete */
Delete From dbo.PerformanceMeasureActualSubcategoryOption Where PerformanceMeasureActualID In (Select PerformanceMeasureActualID From #projectsToDelete) And TenantID = 9

GO

Delete From dbo.PerformanceMeasureActual Where ProjectID In (Select ProjectId From #projectsToDelete) And TenantID = 9

GO

/*Delete Expected Performance Measures Connected with list of Projects to delete */
Delete From dbo.PerformanceMeasureExpectedSubcategoryOption Where PerformanceMeasureExpectedID In (Select PerformanceMeasureExpectedID From #projectsToDelete) And TenantID = 9

GO

Delete From dbo.PerformanceMeasureExpected Where ProjectID In (Select ProjectID From #projectsToDelete) And TenantID = 9

GO

/*Delete Expected Performance Measures Connected with list of Projects to delete */
Delete From dbo.ProjectFundingSourceExpenditure Where ProjectID In (Select ProjectID From #projectsToDelete) And TenantID = 9

GO

/*Delete Expected Performance Measures Connected with list of Projects to delete */
Delete From dbo.ProjectFundingSourceRequest Where ProjectID In (Select ProjectID From #projectsToDelete) And TenantID = 9

GO

/*Delete Audit Logs Connected with list of Projects to delete */
Delete From dbo.AuditLog Where ProjectID In (Select ProjectID From #projectsToDelete) And TenantID = 9

GO

/*Delete Project Organizations Connected with list of Projects to delete */
Delete From dbo.ProjectOrganization Where ProjectID In (Select ProjectID From #projectsToDelete) And TenantID = 9

Go

/*Delete Project Classifications connected with list of Projects to delete */
Delete From dbo.ProjectClassification Where ProjectID In (Select ProjectID From #projectsToDelete) And TenantID = 9

Go

/*Delete Project Classifications connected with list of Projects to delete */
Delete From dbo.ProjectLocationStaging Where ProjectID In (Select ProjectID From #projectsToDelete) And TenantID = 9

Go

/*Delete Project Updates connected with list of Projects to delete */
Delete From dbo.ProjectUpdate Where ProjectUpdateBatchID In (Select ProjectUpdateBatchID From #projectsToDelete) And TenantID = 9

Go

Delete From dbo.ProjectOrganizationUpdate Where ProjectUpdateBatchID In (Select ProjectUpdateBatchID From #projectsToDelete) And TenantID = 9

Go

Delete From dbo.ProjectDocumentUpdate Where ProjectUpdateBatchID In (Select ProjectUpdateBatchID From #projectsToDelete) And TenantID = 9

Go

Delete From dbo.ProjectUpdateHistory Where ProjectUpdateBatchID In (Select ProjectUpdateBatchID From #projectsToDelete) And TenantID = 9

Go

Delete From dbo.ProjectImageUpdate Where ProjectUpdateBatchID In (Select ProjectUpdateBatchID From #projectsToDelete) And TenantID = 9

Go

Delete From dbo.ProjectFundingSourceExpenditureUpdate Where ProjectUpdateBatchID In (Select ProjectUpdateBatchID From #projectsToDelete) And TenantID = 9

Go

Delete From dbo.ProjectExemptReportingYearUpdate Where ProjectUpdateBatchID In (Select ProjectUpdateBatchID From #projectsToDelete) And TenantID = 9

Go

Delete From dbo.PerformanceMeasureActualSubcategoryOptionUpdate Where PerformanceMeasureActualUpdateID In (Select PerformanceMeasureActualUpdateID From #projectsToDelete) And TenantID = 9

Go

Delete From dbo.PerformanceMeasureActualUpdate Where ProjectUpdateBatchID In (Select ProjectUpdateBatchID From #projectsToDelete) And TenantID = 9

Go

Delete From dbo.ProjectFundingSourceRequestUpdate Where ProjectUpdateBatchID In (Select ProjectUpdateBatchID From #projectsToDelete) And TenantID = 9

Go

Delete From dbo.ProjectGeospatialAreaUpdate Where ProjectUpdateBatchID In (Select ProjectUpdateBatchID From #projectsToDelete) And TenantID = 9

Go

Delete From dbo.ProjectGeospatialAreaTypeNoteUpdate Where ProjectUpdateBatchID In (Select ProjectUpdateBatchID From #projectsToDelete) And TenantID = 9

Go

Delete From dbo.ProjectNoteUpdate Where ProjectUpdateBatchID In (Select ProjectUpdateBatchID From #projectsToDelete) And TenantID = 9

Go

Delete From dbo.ProjectLocationUpdate Where ProjectUpdateBatchID In (Select ProjectUpdateBatchID From #projectsToDelete) And TenantID = 9

Go

Delete From dbo.ProjectUpdateBatch Where ProjectID In (Select ProjectID From #projectsToDelete) And TenantID = 9

Go

/* Delete Project Notification connected with list of projects to delete */
Delete From dbo.NotificationProject Where ProjectID In (Select ProjectID From #projectsToDelete) And TenantID = 9

Go

/* Delete Project Image connected with list of projects to delete */
Delete From dbo.ProjectImage Where ProjectID In (Select ProjectID From #projectsToDelete) And TenantID = 9

Go


/* Delete Project Location connected with list of projects to delete */
Delete From dbo.ProjectLocation Where ProjectID In (Select ProjectID From #projectsToDelete) And TenantID = 9

Go

/* Delete Project Document connected with list of projects to delete */
Delete From dbo.ProjectDocument Where ProjectID In (Select ProjectID From #projectsToDelete) And TenantID = 9

Go

/* Delete Project Tag connected with list of projects to delete */
Delete From dbo.ProjectTag Where ProjectID In (Select ProjectID From #projectsToDelete) And TenantID = 9

Go

/* Delete Project Exempt Reporting Year connected with list of projects to delete */
Delete From dbo.ProjectExemptReportingYear Where ProjectID In (Select ProjectID From #projectsToDelete) And TenantID = 9

Go

/* Delete Project Internal Note connected with list of projects to delete */
Delete From dbo.ProjectInternalNote Where ProjectID In (Select ProjectID From #projectsToDelete) And TenantID = 9

Go

/* Delete Project Geospatial Area Type Note connected with list of projects to delete */
Delete From dbo.ProjectGeospatialAreaTypeNote Where ProjectID In (Select ProjectID From #projectsToDelete) And TenantID = 9

Go

/* Delete Project Geospatial Area Type Note connected with list of projects to delete */
Delete From dbo.ProjectNote Where ProjectID In (Select ProjectID From #projectsToDelete) And TenantID = 9

Go

/*Finally Delete from Project */
Delete From dbo.Project Where ProjectID In (Select ProjectID From #projectsToDelete) And TenantID = 9

Go

Drop Table #projectsToDelete