
DROP TABLE IF EXISTS dbo.PersonLoginAccount
GO

CREATE TABLE dbo.PersonLoginAccount
(
    PersonLoginAccountID [int] IDENTITY(1,1) NOT NULL,
    PersonID int not null,
    TenantID int not null constraint FK_PersonLoginAccount_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
    [PersonLoginAccountName] [nvarchar](128) NOT NULL,
    [CreateDate] [datetime] NOT NULL,
    [UpdateDate] [datetime] NULL,
    [PasswordHash] [nvarchar](128) NOT NULL,
    [PasswordSalt] [nvarchar](128) NOT NULL,
    [LoginActive] bit NOT NULL,
    [LastLoginDate] [datetime] NULL,
    [LastLogoutDate] [datetime] NULL,
    [LoginCount] [int] NOT NULL,
    [FailedLoginCount] [int] NOT NULL
)
GO

-- Primary Key
ALTER TABLE [dbo].PersonLoginAccount ADD  CONSTRAINT [PK_PersonLoginAccount_PersonLoginAccountID] PRIMARY KEY CLUSTERED 
(
    PersonLoginAccountID ASC
) ON [PRIMARY]
GO



-- Person FK
ALTER TABLE [dbo].PersonLoginAccount  WITH CHECK ADD  CONSTRAINT [FK_PersonLoginAccount_Person_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO

ALTER TABLE [dbo].PersonLoginAccount  WITH CHECK ADD  CONSTRAINT [FK_PersonLoginAccount_Person_PersonID_TenantID] FOREIGN KEY([PersonID], TenantID)
REFERENCES [dbo].[Person] ([PersonID], TenantID)
GO



-- AK on PersonID
ALTER TABLE [dbo].PersonLoginAccount ADD  CONSTRAINT [AK_PersonLoginAccount_PersonID] UNIQUE NONCLUSTERED 
(
    [PersonID] ASC
) ON [PRIMARY]
GO





