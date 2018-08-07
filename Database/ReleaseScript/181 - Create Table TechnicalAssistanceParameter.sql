CREATE TABLE dbo.TechnicalAssistanceParameter(
TechnicalAssistanceParameterID int not null identity(1,1) constraint PK_TechnicalAssistanceParameter_TechnicalAssistanceParameterID primary key,
TenantID int not null constraint FK_TechnicalAssistanceParameter_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
[Year] int not null,
EngineeringHourlyCost money null,
OtherAssistanceHourlyCost money null,
constraint CK_OnlyIdahoUsesThisFeatureNoExceptionsOkay check (TenantID = 9)
)