CREATE TABLE dbo.TechnicalAssistanceParamter(
TechnicalAssistanceParamter int not null identity(1,1) constraint PK_TechnicalAssistanceParamter_TechnicalAssistanceParamterID primary key,
TenantID int not null constraint FK_TechnicalAssistanceParamter_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
[Year] int not null,
EngineeringHourlyCost money not null,
OtherAssistanceHourlyCost money not null,
constraint CK_OnlyIdahoUsesThisFeatureNoExceptionsOkay check (TenantID = 9)
)