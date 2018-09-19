delete from dbo.TrainingVideo where TenantID = 9

INSERT INTO dbo.TrainingVideo
           (TenantID ,VideoName ,VideoDescription ,VideoUploadDate, VideoURL)
     VALUES
           (9, 'Project Tracker Overview', 'Learn about the Conservation the Idaho Way Project Tracker and how it helps provide transparency and accountability to conservation projects throughout the state. ', GetDate(), 'https://www.youtube.com/embed/fXPOPG-6C1k'),
		   (9, 'User Account Management', 'Learn how to create an account, what to do if you forget your password, and how your account and organization are used in the system.', GetDate(), 'https://www.youtube.com/embed/XUh2rIcPp34'),
		   (9, 'Adding a New Project', 'Learn how to add a new project to the tracker, whether it is a proposal for a new project, or entering data for historic projects that are already complete.', GetDate(), 'https://www.youtube.com/embed/YODBulgfVCk'),
		   (9, 'Updating an Existing Project', 'Learn how to update your projects periodically to ensure the record of accomplishments and expenditures is accurate and complete.', GetDate(), 'https://www.youtube.com/embed/H4MEgOoUwyk')