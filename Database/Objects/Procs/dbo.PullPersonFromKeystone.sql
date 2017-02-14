-- Call like this:
-- exec dbo.PullPersonFromKeystone @UserName = 'nima', @RoleID = 7, @TenantID = 2

CREATE PROCEDURE dbo.PullPersonFromKeystone
	-- Add the parameters for the stored procedure here
	@UserName varchar(128), @RoleID int, @TenantID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @KeystoneUserID int;
	declare @FirmaPersonID int;

	select @KeystoneUserID = keystoneUser.UserID
	from Keystone.dbo.[User] keystoneUser
	where keystoneUser.LoginName = @UserName

	select @FirmaPersonID = keystoneUser.UserID
	from Keystone.dbo.[User] keystoneUser
	join ProjectFirma.dbo.Person firmaPerson
	on keystoneUser.UserGuid = firmaPerson.PersonGuid
	where keystoneUser.LoginName = @UserName and firmaPerson.TenantID = @TenantID

	
	if @FirmaPersonID is null and @KeystoneUserID is not null
	begin

		declare @KeystoneOrganizationID int;
		declare @FirmaOrganizationID int;
		
		select @KeystoneOrganizationID = keystoneOrganization.OrganizationID
		from Keystone.dbo.[User] keystoneUser
		join Keystone.dbo.Organization keystoneOrganization
		on keystoneUser.OrganizationID = keystoneOrganization.OrganizationID
		where keystoneUser.UserID = @KeystoneUserID

		select @FirmaOrganizationID = firmaOrganization.OrganizationID
		from Keystone.dbo.[User] keystoneUser
		join Keystone.dbo.Organization keystoneOrganization
		on keystoneUser.OrganizationID = keystoneOrganization.OrganizationID
		join ProjectFirma.dbo.Organization firmaOrganization
		on keystoneOrganization.OrganizationGuid = firmaOrganization.OrganizationGuid
		where keystoneUser.UserID = @KeystoneUserID and firmaOrganization.TenantID = @TenantID
		
		if @FirmaOrganizationID is null
		begin			
			insert into ProjectFirma.dbo.Organization (OrganizationGuid, OrganizationName, OrganizationAbbreviation, SectorID, IsActive, OrganizationUrl, TenantID)
			select keystoneOrganization.OrganizationGuid, keystoneOrganization.FullName, keystoneOrganization.ShortName, 1, 1, keystoneOrganization.URL, @TenantID
			from Keystone.dbo.Organization keystoneOrganization
			where keystoneOrganization.OrganizationID = @KeystoneOrganizationID
		end
	
		insert into ProjectFirma.dbo.Person (PersonGuid, FirstName, LastName, Email, Phone,  RoleID, CreateDate, UpdateDate, IsActive, OrganizationID, ReceiveSupportEmails, LoginName, TenantID)
		select keystoneUser.UserGuid, keystoneUser.FirstName, keystoneUser.LastName, keystoneUser.Email, keystoneUser.PrimaryPhone, @RoleID, GetDate(), GetDate(), 1, firmaOrganization.OrganizationID, 0, keystoneUser.LoginName, @TenantID
		from Keystone.dbo.[User] keystoneUser 
		join Keystone.dbo.Organization keystoneOrganization
		on keystoneUser.OrganizationID = keystoneOrganization.OrganizationID
		left join ProjectFirma.dbo.Organization firmaOrganization
		on keystoneOrganization.OrganizationGuid = firmaOrganization.OrganizationGuid
		where keystoneUser.LoginName = @userName and firmaOrganization.TenantID = @TenantID
	end
END
GO
