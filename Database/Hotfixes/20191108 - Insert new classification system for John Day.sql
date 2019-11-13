
-- Delete existing Project Classifications
delete from ProjectClassification 
where TenantID = 7
go

delete from dbo.Classification
where TenantID = 7 and ClassificationSystemID = 16
go

GO
INSERT [dbo].[Classification] ([TenantID], [ClassificationDescription], [ThemeColor], [DisplayName], [GoalStatement], [KeyImageFileResourceID], [ClassificationSystemID], [ClassificationSortOrder]) VALUES (7, N'Restoration Action 1', N'#5b9bd5', N'Protect Land and Water', N'Protect land and water (i.e., ecological processes and high-quality habitats) by 2025. ', NULL, 16, 0)
GO
INSERT [dbo].[Classification] ([TenantID], [ClassificationDescription], [ThemeColor], [DisplayName], [GoalStatement], [KeyImageFileResourceID], [ClassificationSystemID], [ClassificationSortOrder]) VALUES (7, N'Restoration Actions 7, 8, 9, and 10', N'#5b9bd5', N'Reconnect Floodplain', N' Reconnect floodplain topography, vegetation, and function (lateral connectivity) by 2025.', NULL, 16, 10)
GO
INSERT [dbo].[Classification] ([TenantID], [ClassificationDescription], [ThemeColor], [DisplayName], [GoalStatement], [KeyImageFileResourceID], [ClassificationSystemID], [ClassificationSortOrder]) VALUES (7, N'Restoration Actions 17, 18, 19, 20, and 21', N'#5b9bd5', N'Increase Riparian Connection & Plant Communities', N'Increase riparian plant communities through fencing, planting, installing off-channel water, and/or invasive species control by 2025. ', NULL, 16, 20)
GO
INSERT [dbo].[Classification] ([TenantID], [ClassificationDescription], [ThemeColor], [DisplayName], [GoalStatement], [KeyImageFileResourceID], [ClassificationSystemID], [ClassificationSortOrder]) VALUES (7, N'Restoration Actions 3, 4, 5, 16, and 28', N'#5b9bd5', N'Improve Instream Channel Connectivity & Complexity', N'Improve channel connectivity and complexity through channel modification and side channel restoration, beaver restoration management, and large wood placement (vertical connectivity) by 2025. ', NULL, 16, 30)
GO
INSERT [dbo].[Classification] ([TenantID], [ClassificationDescription], [ThemeColor], [DisplayName], [GoalStatement], [KeyImageFileResourceID], [ClassificationSystemID], [ClassificationSortOrder]) VALUES (7, N'Restoration Actions 22, 23, 24, and 25', N'#5b9bd5', N'Increase Physical Connectivity to Habitat', N'Increase physical connectivity to high quality habitats by removing/ replacing fish passage barriers (longitudinal connectivity) by 2025. ', NULL, 16, 40)
GO
INSERT [dbo].[Classification] ([TenantID], [ClassificationDescription], [ThemeColor], [DisplayName], [GoalStatement], [KeyImageFileResourceID], [ClassificationSystemID], [ClassificationSortOrder]) VALUES (7, N'Restoration Action 31', N'#5b9bd5', N'Increase Water Quantity & Quality', N'Increase water quantity and quality by leasing or purchasing instream flow by 2025. ', NULL, 16, 50)
GO
INSERT [dbo].[Classification] ([TenantID], [ClassificationDescription], [ThemeColor], [DisplayName], [GoalStatement], [KeyImageFileResourceID], [ClassificationSystemID], [ClassificationSortOrder]) VALUES (7, N'Ecological Result', N'#533783', N'Streambank Shading Increased', N'Increase in woody species density and stream shade potential', NULL, 16, 60)
GO
INSERT [dbo].[Classification] ([TenantID], [ClassificationDescription], [ThemeColor], [DisplayName], [GoalStatement], [KeyImageFileResourceID], [ClassificationSystemID], [ClassificationSortOrder]) VALUES (7, N'Ecological Result', N'#533783', N'Spatial Distribution of Native Fish Increased', N'Increasing trend in linear miles of juvenile summer steelhead and spring Chinook summer rearing habitat by 2025', NULL, 16, 70)
GO
INSERT [dbo].[Classification] ([TenantID], [ClassificationDescription], [ThemeColor], [DisplayName], [GoalStatement], [KeyImageFileResourceID], [ClassificationSystemID], [ClassificationSortOrder]) VALUES (7, N'Ecological Result', N'#533783', N'Stream Temperature Restored to Desired Range', N'Decreasing trend in summer instream water temperature by 2025', NULL, 16, 80)
GO
INSERT [dbo].[Classification] ([TenantID], [ClassificationDescription], [ThemeColor], [DisplayName], [GoalStatement], [KeyImageFileResourceID], [ClassificationSystemID], [ClassificationSortOrder]) VALUES (7, N'Ecological Result', N'#533783', N'Habitat Diversity, Complexity & Structure Improved', N'Create an aquatic-riparian system sufficient to provide necessary stream shading, and organic material for in-stream structural and metabolic processes.', NULL, 16, 90)
GO
INSERT [dbo].[Classification] ([TenantID], [ClassificationDescription], [ThemeColor], [DisplayName], [GoalStatement], [KeyImageFileResourceID], [ClassificationSystemID], [ClassificationSortOrder]) VALUES (7, N'Ecological Result
', N'#533783', N'Flows Support Freshwater Native Fish Life Stages', N'Increasing trend in summer instream flow by 2025', NULL, 16, 100)
GO
SET IDENTITY_INSERT [dbo].[Classification] OFF
GO
