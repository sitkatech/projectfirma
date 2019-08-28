delete from dbo.FileResourceMimeType

-- PDF (.pdf)
insert into dbo.FileResourceMimeType (FileResourceMimeTypeID, FileResourceMimeTypeContentTypeName, FileResourceMimeTypeName, FileResourceMimeTypeDisplayName, FileResourceMimeTypeIconSmallFilename, FileResourceMimeTypeIconNormalFilename) values (1, 'application/pdf', 'PDF', 'PDF', '/Content/img/MimeTypeIcons/pdf_20x20.png', '/Content/img/MimeTypeIcons/pdf_48x48.png')
-- Word document (.docx)																	  							                                  
insert into dbo.FileResourceMimeType (FileResourceMimeTypeID, FileResourceMimeTypeContentTypeName, FileResourceMimeTypeName, FileResourceMimeTypeDisplayName, FileResourceMimeTypeIconSmallFilename,  FileResourceMimeTypeIconNormalFilename) values (2, 'application/vnd.openxmlformats-officedocument.wordprocessingml.document', 'Word (DOCX)', 'Word (DOCX)', '/Content/img/MimeTypeIcons/word_20x20.png', '/Content/img/MimeTypeIcons/word_48x48.png')
-- Excel file (.xlsx) 																		  							                                 
insert into dbo.FileResourceMimeType (FileResourceMimeTypeID, FileResourceMimeTypeContentTypeName, FileResourceMimeTypeName, FileResourceMimeTypeDisplayName, FileResourceMimeTypeIconSmallFilename,  FileResourceMimeTypeIconNormalFilename) values (3, 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet', 'Excel (XLSX)', 'Excel (XLSX)', '/Content/img/MimeTypeIcons/excel_20x20.png', '/Content/img/MimeTypeIcons/excel_48x48.png')
insert into dbo.FileResourceMimeType (FileResourceMimeTypeID, FileResourceMimeTypeContentTypeName, FileResourceMimeTypeName, FileResourceMimeTypeDisplayName, FileResourceMimeTypeIconSmallFilename,  FileResourceMimeTypeIconNormalFilename) values (15, 'application/x-excel', 'x-Excel (XLSX)', 'x-Excel (XLSX)', '/Content/img/MimeTypeIcons/excel_20x20.png', '/Content/img/MimeTypeIcons/excel_48x48.png')

-- X-png																					  							                                 
insert into dbo.FileResourceMimeType (FileResourceMimeTypeID, FileResourceMimeTypeContentTypeName, FileResourceMimeTypeName, FileResourceMimeTypeDisplayName, FileResourceMimeTypeIconSmallFilename,  FileResourceMimeTypeIconNormalFilename) values (4, 'image/x-png', 'X-PNG', 'X-PNG', null, null)
insert into dbo.FileResourceMimeType (FileResourceMimeTypeID, FileResourceMimeTypeContentTypeName, FileResourceMimeTypeName, FileResourceMimeTypeDisplayName, FileResourceMimeTypeIconSmallFilename,  FileResourceMimeTypeIconNormalFilename) values (5, 'image/png', 'PNG', 'PNG', null, null)
insert into dbo.FileResourceMimeType (FileResourceMimeTypeID, FileResourceMimeTypeContentTypeName, FileResourceMimeTypeName, FileResourceMimeTypeDisplayName, FileResourceMimeTypeIconSmallFilename,  FileResourceMimeTypeIconNormalFilename) values (6, 'image/tiff', 'TIFF', 'TIFF', null, null)
insert into dbo.FileResourceMimeType (FileResourceMimeTypeID, FileResourceMimeTypeContentTypeName, FileResourceMimeTypeName, FileResourceMimeTypeDisplayName, FileResourceMimeTypeIconSmallFilename,  FileResourceMimeTypeIconNormalFilename) values (7, 'image/bmp', 'BMP', 'BMP', null, null)
insert into dbo.FileResourceMimeType (FileResourceMimeTypeID, FileResourceMimeTypeContentTypeName, FileResourceMimeTypeName, FileResourceMimeTypeDisplayName, FileResourceMimeTypeIconSmallFilename,  FileResourceMimeTypeIconNormalFilename) values (8, 'image/gif', 'GIF', 'GIF', null, null)
insert into dbo.FileResourceMimeType (FileResourceMimeTypeID, FileResourceMimeTypeContentTypeName, FileResourceMimeTypeName, FileResourceMimeTypeDisplayName, FileResourceMimeTypeIconSmallFilename,  FileResourceMimeTypeIconNormalFilename) values (9, 'image/jpeg', 'JPEG', 'JPEG', null, null)
insert into dbo.FileResourceMimeType (FileResourceMimeTypeID, FileResourceMimeTypeContentTypeName, FileResourceMimeTypeName, FileResourceMimeTypeDisplayName, FileResourceMimeTypeIconSmallFilename,  FileResourceMimeTypeIconNormalFilename) values (10, 'image/pjpeg', 'PJPEG', 'PJPEG', null, null)
-- ppt
insert into dbo.FileResourceMimeType (FileResourceMimeTypeID, FileResourceMimeTypeContentTypeName, FileResourceMimeTypeName, FileResourceMimeTypeDisplayName, FileResourceMimeTypeIconSmallFilename,  FileResourceMimeTypeIconNormalFilename) values (11, 'application/vnd.openxmlformats-officedocument.presentationml.presentation', 'Powerpoint (PPTX)', 'Powerpoint (PPTX)', '/Content/img/MimeTypeIcons/powerpoint_20x20.png', '/Content/img/MimeTypeIcons/powerpoint_48x48.png')
insert into dbo.FileResourceMimeType (FileResourceMimeTypeID, FileResourceMimeTypeContentTypeName, FileResourceMimeTypeName, FileResourceMimeTypeDisplayName, FileResourceMimeTypeIconSmallFilename,  FileResourceMimeTypeIconNormalFilename) values (12, 'application/vnd.ms-powerpoint', 'Powerpoint (PPT)', 'Powerpoint (PPT)', '/Content/img/MimeTypeIcons/powerpoint_20x20.png', '/Content/img/MimeTypeIcons/powerpoint_48x48.png')
insert into dbo.FileResourceMimeType (FileResourceMimeTypeID, FileResourceMimeTypeContentTypeName, FileResourceMimeTypeName, FileResourceMimeTypeDisplayName, FileResourceMimeTypeIconSmallFilename,  FileResourceMimeTypeIconNormalFilename) values (13, 'application/vnd.ms-excel', 'Excel (XLS)', 'Excel (XLS)', '/Content/img/MimeTypeIcons/excel_20x20.png', '/Content/img/MimeTypeIcons/excel_48x48.png')
insert into dbo.FileResourceMimeType (FileResourceMimeTypeID, FileResourceMimeTypeContentTypeName, FileResourceMimeTypeName, FileResourceMimeTypeDisplayName, FileResourceMimeTypeIconSmallFilename,  FileResourceMimeTypeIconNormalFilename) values (14, 'application/msword', 'Word (DOC)', 'Word (DOC)', '/Content/img/MimeTypeIcons/word_20x20.png', '/Content/img/MimeTypeIcons/word_48x48.png')
--
insert into dbo.FileResourceMimeType (FileResourceMimeTypeID, FileResourceMimeTypeContentTypeName, FileResourceMimeTypeName, FileResourceMimeTypeDisplayName, FileResourceMimeTypeIconSmallFilename,  FileResourceMimeTypeIconNormalFilename) values (16, 'text/css', 'CSS', 'CSS', null, null)

INSERT INTO dbo.FileResourceMimeType (FileResourceMimeTypeID, FileResourceMimeTypeContentTypeName, FileResourceMimeTypeName, FileResourceMimeTypeDisplayName, FileResourceMimeTypeIconSmallFilename, FileResourceMimeTypeIconNormalFilename) 
values

(22, 'application/zip', 'ZIP', 'ZIP', null, null),
(17, 'application/x-zip-compressed', 'X-ZIP', 'X-ZIP', null, null),
(18, 'application/gzip', 'GZIP', 'GZIP', null, null),
(19, 'application/x-gzip', 'X-GZIP', 'X-GZIP', null, null),
(20, 'application/x-compressed', 'TGZ', 'TGZ', null, null),
(21, 'application/x-tar', 'TAR', 'TAR', null, null)

insert into dbo.FileResourceMimeType (FileResourceMimeTypeID, FileResourceMimeTypeContentTypeName, FileResourceMimeTypeName, FileResourceMimeTypeDisplayName, FileResourceMimeTypeIconSmallFilename,  FileResourceMimeTypeIconNormalFilename) 
	values (23, 'application/vnd.google-earth.kmz', 'KMZ', 'KMZ', null, null)

insert into dbo.FileResourceMimeType (FileResourceMimeTypeID, FileResourceMimeTypeContentTypeName, FileResourceMimeTypeName, FileResourceMimeTypeDisplayName, FileResourceMimeTypeIconSmallFilename,  FileResourceMimeTypeIconNormalFilename) 
	values (24, 'application/vnd.google-earth.kml+xml', 'KML', 'KML', null, null)