ALTER TABLE [dbo].[Tenant] DROP CONSTRAINT [CK_OnlyIdahoUsesTechnicalAssistanceParameters]
alter table dbo.Tenant drop column UsesTechnicalAssistanceParameters

drop table dbo.TechnicalAssistanceRequestUpdate
drop table dbo.TechnicalAssistanceRequest
drop table dbo.TechnicalAssistanceParameter
drop table dbo.TechnicalAssistanceType

