/**
Somehow, there got to be a few Custom Pages with html that points to a File Resource (via the GUID), but we do not have a row in the CustomPageImage table linking the Custom Page to the FileResourceInfo.
Add these rows to the many-to-many reference table before deleting the File Resources that are no longer referenced by a Foreign Key in any table
**/
insert into CustomPageImage (TenantID, CustomPageID, FileResourceInfoID) values (9, 9, 3963) -- for missing reference to GUID 18DF6432-0951-4187-B437-46E166467C41
insert into CustomPageImage (TenantID, CustomPageID, FileResourceInfoID) values (4, 2, 198) -- for missing reference to GUID 291562B9-D7DD-4FC5-A57A-5A3DEC2FD6CD
insert into CustomPageImage (TenantID, CustomPageID, FileResourceInfoID) values (4, 2, 199) -- for missing reference to GUID 5E22654C-8A09-4DFA-9D0E-69FE1D2989B5
insert into CustomPageImage (TenantID, CustomPageID, FileResourceInfoID) values (3, 3, 247) -- for missing reference to GUID F55136A5-36F7-49BB-B353-7428E17AEF70


delete from FileResourceData
where FileResourceInfoID in (
	select fri.FileResourceInfoID
	from FileResourceInfo fri
	left join Classification c on c.KeyImageFileResourceInfoID = fri.FileResourceInfoID
	left join CustomPageImage cpi on cpi.FileResourceInfoID = fri.FileResourceInfoID
	left join DocumentLibraryDocument dld on dld.FileResourceInfoID = fri.FileResourceInfoID
	left join FieldDefinitionDataImage fddi on fddi.FileResourceInfoID = fri.FileResourceInfoID
	left join FirmaHomePageImage fhpi on fhpi.FileResourceInfoID = fri.FileResourceInfoID
	left join FirmaPageImage fpi on fpi.FileResourceInfoID = fri.FileResourceInfoID
	left join GeospatialAreaImage gai on gai.FileResourceInfoID = fri.FileResourceInfoID
	left join Organization o on o.LogoFileResourceInfoID = fri.FileResourceInfoID
	left join PerformanceMeasureImage pmi on pmi.FileResourceInfoID = fri.FileResourceInfoID
	left join ProjectAttachment pa on pa.AttachmentID = fri.FileResourceInfoID
	left join ProjectAttachmentUpdate pau on pau.AttachmentID = fri.FileResourceInfoID
	left join ProjectImage projectImage on projectImage.FileResourceInfoID = fri.FileResourceInfoID
	left join ProjectImageUpdate piu on  piu.FileResourceInfoID = fri.FileResourceInfoID
	left join ReportTemplate rt on  rt.FileResourceInfoID = fri.FileResourceInfoID
	left join TenantAttribute ta1 on  ta1.TenantBannerLogoFileResourceInfoID = fri.FileResourceInfoID
	left join TenantAttribute ta2 on  ta2.TenantFactSheetLogoFileResourceInfoID = fri.FileResourceInfoID
	left join TenantAttribute ta3 on  ta3.TenantSquareLogoFileResourceInfoID = fri.FileResourceInfoID
	left join TenantAttribute ta4 on  ta4.TenantStyleSheetFileResourceInfoID = fri.FileResourceInfoID

	where c.KeyImageFileResourceInfoID is null
	and cpi.FileResourceInfoID is null
	and dld.FileResourceInfoID is null
	and fddi.FileResourceInfoID is null
	and fhpi.FileResourceInfoID is null
	and fpi.FileResourceInfoID is null
	and gai.FileResourceInfoID is null
	and o.LogoFileResourceInfoID is null
	and pmi.FileResourceInfoID is null
	and pa.AttachmentID is null
	and pau.AttachmentID is null
	and projectImage.FileResourceInfoID is null
	and piu.FileResourceInfoID is null
	and rt.FileResourceInfoID is null
	and ta1.TenantBannerLogoFileResourceInfoID is null
	and ta2.TenantFactSheetLogoFileResourceInfoID is null
	and ta3.TenantSquareLogoFileResourceInfoID is null
	and ta4.TenantStyleSheetFileResourceInfoID is null
)


delete from FileResourceInfo
where FileResourceInfoID in (
	select fri.FileResourceInfoID
	from FileResourceInfo fri
	left join Classification c on c.KeyImageFileResourceInfoID = fri.FileResourceInfoID
	left join CustomPageImage cpi on cpi.FileResourceInfoID = fri.FileResourceInfoID
	left join DocumentLibraryDocument dld on dld.FileResourceInfoID = fri.FileResourceInfoID
	left join FieldDefinitionDataImage fddi on fddi.FileResourceInfoID = fri.FileResourceInfoID
	left join FirmaHomePageImage fhpi on fhpi.FileResourceInfoID = fri.FileResourceInfoID
	left join FirmaPageImage fpi on fpi.FileResourceInfoID = fri.FileResourceInfoID
	left join GeospatialAreaImage gai on gai.FileResourceInfoID = fri.FileResourceInfoID
	left join Organization o on o.LogoFileResourceInfoID = fri.FileResourceInfoID
	left join PerformanceMeasureImage pmi on pmi.FileResourceInfoID = fri.FileResourceInfoID
	left join ProjectAttachment pa on pa.AttachmentID = fri.FileResourceInfoID
	left join ProjectAttachmentUpdate pau on pau.AttachmentID = fri.FileResourceInfoID
	left join ProjectImage projectImage on projectImage.FileResourceInfoID = fri.FileResourceInfoID
	left join ProjectImageUpdate piu on  piu.FileResourceInfoID = fri.FileResourceInfoID
	left join ReportTemplate rt on  rt.FileResourceInfoID = fri.FileResourceInfoID
	left join TenantAttribute ta1 on  ta1.TenantBannerLogoFileResourceInfoID = fri.FileResourceInfoID
	left join TenantAttribute ta2 on  ta2.TenantFactSheetLogoFileResourceInfoID = fri.FileResourceInfoID
	left join TenantAttribute ta3 on  ta3.TenantSquareLogoFileResourceInfoID = fri.FileResourceInfoID
	left join TenantAttribute ta4 on  ta4.TenantStyleSheetFileResourceInfoID = fri.FileResourceInfoID

	where c.KeyImageFileResourceInfoID is null
	and cpi.FileResourceInfoID is null
	and dld.FileResourceInfoID is null
	and fddi.FileResourceInfoID is null
	and fhpi.FileResourceInfoID is null
	and fpi.FileResourceInfoID is null
	and gai.FileResourceInfoID is null
	and o.LogoFileResourceInfoID is null
	and pmi.FileResourceInfoID is null
	and pa.AttachmentID is null
	and pau.AttachmentID is null
	and projectImage.FileResourceInfoID is null
	and piu.FileResourceInfoID is null
	and rt.FileResourceInfoID is null
	and ta1.TenantBannerLogoFileResourceInfoID is null
	and ta2.TenantFactSheetLogoFileResourceInfoID is null
	and ta3.TenantSquareLogoFileResourceInfoID is null
	and ta4.TenantStyleSheetFileResourceInfoID is null
)