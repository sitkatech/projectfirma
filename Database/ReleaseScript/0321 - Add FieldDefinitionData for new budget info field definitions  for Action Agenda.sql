Insert Into dbo.FieldDefinition (FieldDefinitionID, FieldDefinitionName, FieldDefinitionDisplayName, DefaultDefinition)
Values
(296, N'NumberOfProjectsWithExpendedFunds', N'# of Projects with Expended Funds', N'The number of projects that have expenditures funded by this funding source.'),
(297, N'TotalExpenditures', N'Total Expenditures', N'Total amount of reported expenditures funded by this funding source for all projects'),
(298, N'NumberOfProjectsWithSecuredFunds', N'# of Projects with Secured Funds', N'The number of projects that have secured funds from this funding source.'),
(299, N'TotalProjectSecuredFunds', N'Total Project Secured Funds', N'Total amount provided by this funding source as "Secured" for all projects.'),
(300, N'TotalProjectTargetedFunds', N'Total Project Targeted Funds', N'Total amount provided by this funding source as "Targeted" for all projects.')

Insert Into dbo.FieldDefinitionData(TenantID, FieldDefinitionID, FieldDefinitionLabel, FieldDefinitionDataValue)
Values 
(11, 296, N'# of NTAs with Expended Funds', N'The number of projects that have expenditures funded by this funding program.'),
(11, 297, N'Total Expenditures', N'Total amount of reported expenditures funded by this funding program for all NTAs'),
(11, 298, N'# of NTAs with Secured Funds', N'The number of NTAs that have secured funds from this funding program.'),
(11, 299, N'Total NTA Secured Funds', N'Total amount provided by this funding program as "Secured" for all NTAs.'),
(11, 300, N'Total NTA Targeted Funds', N'Total amount provided by this funding program as "Targeted" for all NTAs.')