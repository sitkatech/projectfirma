delete
from dbo.TrainingVideo
where TenantID = 7

insert into dbo.TrainingVideo(TenantID, VideoName, VideoDescription, VideoUploadDate, VideoURL)
values
(7, 'Complete Training', 'This is the John Day Basin Partnership Project Tracker user training presented on January 21, 2020.', '20200203', 'https://www.youtube.com/embed/wIBj78w4z_Y'),
(7, 'Account Management and User Detail', 'This is the Account Management and User Detail section of the John Day Basin Partnership Project Tracker user training presented on 1/21/20.', '20200203', 'https://www.youtube.com/embed/WkIBwiWKZUk'),
(7, 'Requesting Support', 'This is the Requesting Support section of the John Day Basin Partnership Project Tracker user training presented on 1/21/20.', '20200203', 'https://www.youtube.com/embed/zlt6R4L27xc'),
(7, 'Adding a Project', 'This is the Adding a Project section of the John Day Basin Partnership Project Tracker user training presented on 1/21/20.', '20200203', 'https://www.youtube.com/embed/OmKny5hD2GE'),
(7, 'Updating a Project', 'This is the Updating a Project section of the John Day Basin Partnership Project Tracker user training presented on 1/21/20.', '20200203', 'https://www.youtube.com/embed/9leVOsHMlTo'),
(7, 'Summary Pages Overview', 'This is the Summary Pages Overview section of the John Day Basin Partnership Project Tracker user training presented on 1/21/20.', '20200203', 'https://www.youtube.com/embed/qe5vK0igUuk'),
(7, 'ProjectFirma Google Analytics', 'This video is a high level overview of the ProjectFirma Google Analytics integration. The video covers basics on how to use it, and what ProjectFirma users might gain from using it.', '20200203', 'https://www.youtube.com/embed/J4Cp_7sizAo')