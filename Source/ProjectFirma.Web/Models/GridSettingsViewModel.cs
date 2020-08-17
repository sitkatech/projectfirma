using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class GridSettingsViewModel : FormViewModel, IValidatableObject
    {
        public GridTable GridTable { get; set; }

        /// <summary>
        /// This is a static dictionary of objects for serializing requests to <see cref="SaveGridColumnSettings"/>
        /// Theoretically we could lock at a lower level per PersonSetting per Grid, but PersonSetting is easier
        /// </summary>
        private static readonly Dictionary<int, object> SaveGridColumnSettingsLockDict = new Dictionary<int, object>();

        public GridSettingsViewModel()
        {

        }

        public GridSettingsViewModel(GridTable gridTable)
        {
            GridTable = gridTable;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }

        public void Save(FirmaSession currentFirmaSession)
        {
            if (currentFirmaSession.IsAnonymousOrUnassigned())
            {
                // todo: return something else?
                return;
            }

            int personID = currentFirmaSession.Person.PersonID;

            object saveGridColumnSettingsLock;

            // Quick global lock - Only access/update the dict serially
            lock (SaveGridColumnSettingsLockDict)
            {
                if (!SaveGridColumnSettingsLockDict.ContainsKey(personID))
                {
                    // Just a blank little lockable object, indexed by PersonSettingID
                    SaveGridColumnSettingsLockDict[personID] = new object();
                }
                saveGridColumnSettingsLock = SaveGridColumnSettingsLockDict[personID];
            }

            // Local lock for this Person updating a grid
            // Attempting to cut down on contention problems with simultaneous requests -- SLG
            lock (saveGridColumnSettingsLock)
            {

                if (!currentFirmaSession.IsAnonymousOrUnassigned())
                {
                    // This is the main function that can lead to exceptions from contention if simultaneous updates come through
                    currentFirmaSession.Person.UpdatePersonSettingGridColumns(GridTable);
                }
                
            }
            HttpRequestStorage.DatabaseEntities.SaveChanges();
        }

    }
}