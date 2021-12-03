-- delete project/classification records
delete from dbo.MatchmakerOrganizationClassification where TenantID = 4
delete from dbo.ProjectClassificationUpdate where TenantID = 4
delete from dbo.ProjectClassification where TenantID = 4

-- delete all classifications
delete from dbo.Classification where ClassificationSystemID = 3
delete from dbo.Classification where ClassificationSystemID = 17

-- delete classification system
delete from dbo.ClassificationSystem where ClassificationSystemID = 3

-- add new classifications
insert into dbo.Classification (TenantID,ClassificationDescription,ThemeColor,DisplayName,GoalStatement,KeyImageFileResourceInfoID,ClassificationSystemID,ClassificationSortOrder)
values
(4, 'None', '#b6430f', 'Climate Action: Adaptation', null, null, 17, 1),
(4, 'None', '#91350c', 'Climate Action: Emissions reduction, avoidance and carbon sequestration', null, null, 17, 2),
(4, 'None', '#6d2809', 'Climate Action: Other', null, null, 17, 3),
(4, 'None', '#2e6580', 'Community Engagement: Capacity Development, Trainings & Technical Support', null, null, 17, 4),
(4, 'None', '#578399', 'Community Engagement: Education and Outreach', null, null, 17, 5),
(4, 'None', '#81a2b2', 'Community Engagement: Workforce Development', null, null, 17, 6),
(4, 'None', '#abc1cc', 'Community Engagement: Other', null, null, 17, 7),
(4, 'None', '#ffe293', 'Economic Development: Woody Feedstock Utilization ', null, null, 17, 8),
(4, 'None', '#ccb475', 'Economic Development: Other', null, null, 17, 9),
(4, 'None', '#e0871a', 'Fire Prevention: Fuel reduction', null, null, 17, 10),
(4, 'None', '#b36c14', 'Fire Prevention: Planning', null, null, 17, 11),
(4, 'None', '#86510f', 'Fire Prevention: Education', null, null, 17, 12),
(4, 'None', '#59360a', 'Fire Prevention: Other', null, null, 17, 13),
(4, 'None', '#ffbb00', 'Fire Preparedness: Home hardening', null, null, 17, 14),
(4, 'None', '#cc9500', 'Fire Preparedness: Infrastructure improvements', null, null, 17, 15),
(4, 'None', '#997000', 'Fire Preparedness: Other', null, null, 17, 16),
(4, 'None', '#738c1f', 'Forest Health: Fuel reduction', null, null, 17, 17),
(4, 'None', '#5c7018', 'Forest Health: Pest management', null, null, 17, 18),
(4, 'None', '#455412', 'Forest Health: Prescribed fire', null, null, 17, 19),
(4, 'None', '#39460f', 'Forest Health: Other', null, null, 17, 20),
(4, 'None', '#7d3951', 'Infrastructure Improvements: Wastewater ', null, null, 17, 21),
(4, 'None', '#642d40', 'Infrastructure Improvements: Water Quality & Supply Improvement', null, null, 17, 22),
(4, 'None', '#4b2230', 'Infrastructure Improvements: Other', null, null, 17, 23),
(4, 'None', '#94c5e3', 'Regional and Local Planning: Planning and Design', null, null, 17, 24),
(4, 'None', '#85b1cc', 'Regional and Local Planning: Technical Assistance', null, null, 17, 25),
(4, 'None', '#769db5', 'Regional and Local Planning: Policy/Regulatory/Funding/Permitting', null, null, 17, 26),
(4, 'None', '#587688', 'Regional and Local Planning: Research & Data Development', null, null, 17, 27),
(4, 'None', '#3b4e5a', 'Regional and Local Planning: Other', null, null, 17, 28),
(4, 'None', '#4b5c14', 'Watershed Enhancement: Habitat restoration', null, null, 17, 29),
(4, 'None', '#6e7c42', 'Watershed Enhancement: Invasive species removal', null, null, 17, 30),
(4, 'None', '#939d72', 'Watershed Enhancement: Land conservation', null, null, 17, 31),
(4, 'None', '#b7bda1', 'Watershed Enhancement: Other', null, null, 17, 32),
(4, 'None', '#8d8d8d', 'Monitoring', null, null, 17, 33),
(4, 'None', '#424142', 'Unspecified', null, null, 17, 34)
