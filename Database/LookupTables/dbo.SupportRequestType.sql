
delete from dbo.SupportRequestType

insert dbo.SupportRequestType (SupportRequestTypeID, SupportRequestTypeName, SupportRequestTypeDisplayName, SupportRequestTypeSortOrder) values 
(1, 'ReportBug', 'Ran into a bug or problem with this system', 7),
(2, 'HelpWithProjectUpdate', 'Can''t figure out how to update my project', 1),
(3, 'ForgotLoginInfo', 'Can''t log in (forgot my username or password, account is locked, etc.)', 2),
(4, 'NewOrganizationOrFundingSource', 'Need an Organization or Funding Source added to the list', 4),
(5, 'ProvideFeedback', 'Provide Feedback on the site', 6),
(6, 'RequestOrganizationNameChange', 'Request a change to an Organization''s name', 9),
(7, 'Other', 'Other', 100),
(8, 'RequestProjectPrimaryContactChange', 'Request a change to a Project''s primary contact', 10),
(9, 'RequestPermissionToAddProjects', 'Request permission to add projects', 11),
(10, 'AddOrganizationToKeystone', 'Request an Organization be added to Keystone', 5)