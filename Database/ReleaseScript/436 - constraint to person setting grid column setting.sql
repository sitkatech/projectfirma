/*select * from PersonSettingGridColumnSetting where PersonSettingGridColumnID in (select PersonSettingGridColumnID from PersonSettingGridColumn where PersonSettingGridTableID = 3)


select * from DatabaseMigration
*/

ALTER TABLE [dbo].[PersonSettingGridColumnSetting] ADD  CONSTRAINT [AK_PersonSettingGridColumnSetting_PersonID_PersonSettingGridColumnID] UNIQUE NONCLUSTERED 
(
	[PersonID] ASC,
	[PersonSettingGridColumnID] ASC
)
