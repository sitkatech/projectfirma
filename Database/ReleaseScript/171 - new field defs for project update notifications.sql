insert into dbo.FieldDefinition ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName], [DefaultDefinition], [CanCustomizeLabel])
values
(261, N'ProjectUpdateKickOffDate', N'Kick-off Date', N'The date to send the initial notification about Project Updates to Primary Contacts', 1),
(262, N'ProjectUpdateReminderInterval', N'Reminder Interval (days)', N'The number of days between repeated Project Update Reminders', 1),
(263, N'ProjectUpdateCloseOutDate', N'Close-out Date', N'The date on which to send the final Project Update Reminder', 1)

insert into dbo.FieldDefinitionData ([TenantID], [FieldDefinitionID], [FieldDefinitionDataValue], [FieldDefinitionLabel])
select 
TenantID as TenantID,
261 as FieldDefinitionID,
null as FieldDefinitionDataValue,
null as FieldDefinitionLabel
from Tenant

insert into dbo.FieldDefinitionData ([TenantID], [FieldDefinitionID], [FieldDefinitionDataValue], [FieldDefinitionLabel])
select 
TenantID as TenantID,
262 as FieldDefinitionID,
null as FieldDefinitionDataValue,
null as FieldDefinitionLabel
from Tenant

insert into dbo.FieldDefinitionData ([TenantID], [FieldDefinitionID], [FieldDefinitionDataValue], [FieldDefinitionLabel])
select 
TenantID as TenantID,
263 as FieldDefinitionID,
null as FieldDefinitionDataValue,
null as FieldDefinitionLabel
from Tenant