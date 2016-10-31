
delete from dbo.SupportRequestType

insert dbo.SupportRequestType (SupportRequestTypeID, SupportRequestTypeName, SupportRequestTypeDisplayName, SupportRequestTypeSortOrder) values 
(1, 'QuestionAboutPolicies', 'Have question about Clackamas Partnership (policies, reporting process, etc.)', 3),
(2, 'ReportBug', 'Ran into a bug or problem with this system', 7),
(3, 'HelpWithProjectUpdate', 'Can''t figure out how to update my project', 1),
(4, 'ForgotLoginInfo', 'Can''t log in (forgot my username or password, account is locked, etc.)', 2),
(5, 'NewOrganizationOrFundingSource', 'Need an Organization or Funding Source added to the list', 4),
(6, 'Other', 'Other', 100),
(9, 'ProvideFeedback', 'Provide Feedback on the site', 6),
(10, 'RequestOrganizationNameChange', 'Request a change to an Organization''s name', 9)
