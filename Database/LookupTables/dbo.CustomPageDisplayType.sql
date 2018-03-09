delete from dbo.CustomPageDisplayType

insert into dbo.CustomPageDisplayType(CustomPageDisplayTypeID, CustomPageDisplayTypeName, CustomPageDisplayTypeDisplayName, CustomPageDisplayTypeDescription) values (1, 'Disabled', 'Disabled', 'Not visible to any users')
insert into dbo.CustomPageDisplayType(CustomPageDisplayTypeID, CustomPageDisplayTypeName, CustomPageDisplayTypeDisplayName, CustomPageDisplayTypeDescription) values (2, 'Public', 'Public', 'Visible to all users')
insert into dbo.CustomPageDisplayType(CustomPageDisplayTypeID, CustomPageDisplayTypeName, CustomPageDisplayTypeDisplayName, CustomPageDisplayTypeDescription) values (3, 'Protected', 'Protected', 'Visible to logged in users only')

