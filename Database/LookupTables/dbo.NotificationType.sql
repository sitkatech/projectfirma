delete from dbo.NotificationType

insert dbo.NotificationType (NotificationTypeID, NotificationTypeName, NotificationTypeDisplayName) 
values 
(1, 'ProjectUpdateReminder', 'Project Update Reminder'),
(2, 'ProjectUpdateSubmitted', 'Project Update Submitted'),
(3, 'ProjectUpdateReturned', 'Project Update Returned'),
(4, 'ProjectUpdateApproved', 'Project Update Approved'),
(5, 'Custom', 'Custom Notification'),
(6, 'ProposedProjectSubmitted', 'Proposed Project Submitted'),
(7, 'ProposedProjectApproved', 'Proposed Project Approved'),
(8, 'ProposedProjectReturned', 'Proposed Project Returned')