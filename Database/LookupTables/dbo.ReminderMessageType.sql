delete from dbo.ReminderMessageType

insert dbo.ReminderMessageType (ReminderMessageTypeID, ReminderMessageTypeName, ReminderMessageTypeDisplayName, ReminderMessageTypeSubject) 
values 
(1, 'KickoffReminder', 'Kickoff Reminder (Nov 1)', 'Time to update your EIP Projects (Nov 1 reminder)'),
(2, 'SecondReminder', 'Second Reminder (Dec 1)', 'Time to update your EIP Projects (Dec 1 reminder)'),
(3, 'ThirdReminder', 'Third Reminder  (Jan 5)', 'Time to update your EIP Projects (Jan 5 reminder)'),
(4, 'NearingDeadlineReminder', 'Nearing Deadline Reminder (Jan 10)', 'Time to update your EIP Projects (Jan 10 reminder)'),
(5, 'AtDeadlineReminder', 'At Deadline Reminder (Jan 15)', 'Time to update your EIP Projects (Jan 15 reminder)'),
(6, 'PastDeadlineReminder', 'Past Deadline Reminder (Every 5 days after Jan 15)', 'Time to update your EIP Projects (Past-due reminder)')
