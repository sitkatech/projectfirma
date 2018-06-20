Create Table dbo.ProjectUpdateConfiguration(
ProjectUpdateConfigurationID int not null identity(1,1) constraint PK_ProjectUpdateConfiguration_ProjectUpdateConfigurationID primary key,
TenantID int not null constraint FK_ProjectUpdateConfiguration_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
ProjectUpdateKickOffDate datetime null,
ProjectUpdateCloseOutDate datetime null,
ProjectUpdateReminderInterval int null,
EnableProjectUpdateReminders bit not null,
SendPeriodicReminders bit not null,
SendCloseOutNotification bit not null,
ProjectUpdateKickOffIntroContent varchar(max) null,
ProjectUpdateReminderIntroContent varchar(max) null,
ProjectUpdateCloseOutIntroContent varchar(max) null,

constraint AK_ProjectUpdateConfiguration_Tenant unique(TenantID)
)
go

Insert into dbo.ProjectUpdateConfiguration (TenantID, ProjectUpdateKickOffDate, ProjectUpdateCloseOutDate, ProjectUpdateReminderInterval, EnableProjectUpdateReminders, SendPeriodicReminders,
SendCloseOutNotification, ProjectUpdateKickOffIntroContent, ProjectUpdateReminderIntroContent, ProjectUpdateCloseOutIntroContent)
select 
TenantID as TenantID,
null as ProjectUpdateKickOffDate,
null as ProjectUpdateCloseOutDate,
null as ProjectUpdateReminderInterval,
0 as EnableProjectUpdateReminders,
0 as SendPeriodReminders,
0 as SendCloseOutNotification,
null as ProjectUpdateKickOffIntroContent,
null as ProjectUpdateReminderIntroContent,
null as ProjectUpdateCloseOutIntroContent
from dbo.Tenant