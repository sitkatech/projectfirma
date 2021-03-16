
-- Is a given Tenant using Keystone, or the new self-auth method?
DROP TABLE IF EXISTS dbo.FirmaSystemAuthenticationType
GO

CREATE TABLE dbo.FirmaSystemAuthenticationType
(
    FirmaSystemAuthenticationTypeID [int] NOT NULL,
    FirmaSystemAuthenticationTypeName [varchar](100) NOT NULL,
    FirmaSystemAuthenticationTypeDisplayName [varchar](100) NOT NULL
)
GO

ALTER TABLE [dbo].FirmaSystemAuthenticationType ADD  CONSTRAINT [PK_FirmaSystemAuthenticationType_FirmaSystemAuthenticationTypeID] PRIMARY KEY CLUSTERED 
(
    FirmaSystemAuthenticationTypeID ASC
) ON [PRIMARY]
GO


ALTER TABLE [dbo].FirmaSystemAuthenticationType ADD  CONSTRAINT [AK_FirmaSystemAuthenticationType_FirmaSystemAuthenticationTypeDisplayName] UNIQUE NONCLUSTERED 
(
    FirmaSystemAuthenticationTypeDisplayName ASC
) ON [PRIMARY]
GO

delete from dbo.FirmaSystemAuthenticationType

insert into dbo.FirmaSystemAuthenticationType(FirmaSystemAuthenticationTypeID, FirmaSystemAuthenticationTypeName, FirmaSystemAuthenticationTypeDisplayName) values (1, 'Keystone', 'Keystone')
insert into dbo.FirmaSystemAuthenticationType(FirmaSystemAuthenticationTypeID, FirmaSystemAuthenticationTypeName, FirmaSystemAuthenticationTypeDisplayName) values (2, 'FirmaSelfAuth', 'Firma Self Authentication')


alter table dbo.TenantAttribute
add FirmaSystemAuthenticationTypeID int null
GO

ALTER TABLE [dbo].[TenantAttribute]  WITH CHECK ADD  CONSTRAINT [FK_TenantAttribute_FirmaSystemAuthenticationType_FirmaSystemAuthenticationTypeID] FOREIGN KEY(FirmaSystemAuthenticationTypeID)
REFERENCES [dbo].FirmaSystemAuthenticationType (FirmaSystemAuthenticationTypeID)
GO

-- Everyone except reclamation
update dbo.TenantAttribute 
set FirmaSystemAuthenticationTypeID = 1 
where TenantID not in (12)
GO

-- Reclamation
update dbo.TenantAttribute
set FirmaSystemAuthenticationTypeID = 2
where TenantID = 12 
GO

alter table dbo.TenantAttribute
alter column FirmaSystemAuthenticationTypeID int not null
GO






DROP TABLE IF EXISTS dbo.PersonLoginAccount
GO

CREATE TABLE dbo.PersonLoginAccount
(
    PersonLoginAccountID [int] IDENTITY(1,1) NOT NULL,
    PersonID int not null,
    [PersonLoginAccountName] [nvarchar](128) NOT NULL,
    [CreateDate] [datetime] NOT NULL,
    [UpdateDate] [datetime] NULL,
    [Password] [nvarchar](128) NOT NULL,
    [PasswordSalt] [nvarchar](128) NOT NULL,
    [LoginActive] bit NOT NULL,
    [LastLoginDate] [datetime] NULL,
    [LastLogoutDate] [datetime] NULL,
    [LoginCount] [int] NOT NULL,
    [FailedLoginCount] [int] NOT NULL
)
GO

/****** Object:  Index [PK_Person_PersonID]    Script Date: 3/16/2021 11:17:09 AM ******/
ALTER TABLE [dbo].PersonLoginAccount ADD  CONSTRAINT [PK_PersonLoginAccount_PersonLoginAccountID] PRIMARY KEY CLUSTERED 
(
    PersonLoginAccountID ASC
) ON [PRIMARY]
GO