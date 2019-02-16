
-- Create table of ProjectFirma release notes
create table dbo.ReleaseNote (
	ReleaseNoteID int not null identity(1,1) constraint PK_ReleaseNote_ReleaseNoteID primary key,
	Note dbo.Html not null,
	CreatePersonID int not null constraint FK_ReleaseNote_Person_CreatePersonID_PersonID foreign key references dbo.Person(PersonID),
	CreateDate datetime not null,
	UpdatePersonID int null constraint FK_ReleaseNote_Person_UpdatePersonID_PersonID foreign key references dbo.Person(PersonID),
	UpdateDate datetime null,
);
