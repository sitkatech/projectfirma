/*-----------------------------------------------------------------------
<copyright file="MergeListHelper.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirmaModels
{
    public static class MergeListHelper
    {
        public delegate bool Match<in T>(T o1, T o2);
        public delegate void UpdateFunction<in T>(T o1, T o2);

        #region TODO: Make all callers of these use the signature without allInDatabase; at the end we should kill these three functions
        public static void MergeNew<T>(this ICollection<T> existingList, IEnumerable<T> updatedList, Match<T> matchCriteria, ICollection<T> allInDatabase)
        {
            // Inserting new records
            foreach (var currentRecordFromForm in updatedList)
            {
                var existingRecord = existingList.MatchRecord(currentRecordFromForm, matchCriteria);
                if (Equals(existingRecord, default(T)))
                {
                    existingList.Add(currentRecordFromForm);
                    allInDatabase.Add(currentRecordFromForm);
                }
            }
        }

        public static void Merge<T>(this ICollection<T> existingList, ICollection<T> updatedList, ICollection<T> allInDatabase, Match<T> matchCriteria, DatabaseEntities dbContext) where T : ICanDeleteFull
        {
            existingList.Merge(updatedList, allInDatabase, matchCriteria, null, dbContext);
        }

        public static void Merge<T>(this ICollection<T> existingList, ICollection<T> updatedList, ICollection<T> allInDatabase, Match<T> matchCriteria, UpdateFunction<T> updateFunction, DatabaseEntities dbContext) where T : ICanDeleteFull
        {
            existingList.MergeNew(updatedList, matchCriteria, allInDatabase);
            if (updateFunction != null)
            {
                existingList.MergeUpdate(updatedList, matchCriteria, updateFunction);
            }
            existingList.MergeDelete(updatedList, matchCriteria, dbContext);
        }
        #endregion

        public static void Merge<T>(this ICollection<T> existingList, ICollection<T> updatedList, Match<T> matchCriteria, DatabaseEntities dbContext) where T : ICanDeleteFull
        {
            existingList.Merge(updatedList, matchCriteria, null, dbContext);
        }

        public static void Merge<T>(this ICollection<T> existingList, ICollection<T> updatedList, Match<T> matchCriteria, UpdateFunction<T> updateFunction, DatabaseEntities dbContext) where T : ICanDeleteFull
        {
            existingList.MergeNew(updatedList, matchCriteria, dbContext.Set(typeof(T)));
            if (updateFunction != null)
            {
                existingList.MergeUpdate(updatedList, matchCriteria, updateFunction);
            }
            existingList.MergeDelete(updatedList, matchCriteria, dbContext);
        }

        private static void MergeNew<T>(this ICollection<T> existingList, ICollection<T> updatedList, Match<T> matchCriteria, DbSet allInDatabase) where T : ICanDeleteFull
        {
            // Inserting new records
            foreach (var currentRecordFromForm in updatedList)
            {
                var existingRecord = existingList.MatchRecord(currentRecordFromForm, matchCriteria);
                if (Equals(existingRecord, default(T)))
                {
                    existingList.Add(currentRecordFromForm);
                    allInDatabase.Add(currentRecordFromForm);
                }
            }
        }

        public static void MergeUpdate<T>(this ICollection<T> existingList, IEnumerable<T> updatedList, Match<T> matchCriteria, UpdateFunction<T> updateFunction)
        {
            foreach (var currentRecordFromForm in updatedList)
            {
                var existingRecord = existingList.MatchRecord(currentRecordFromForm, matchCriteria);
                if (!Equals(existingRecord, default(T)))
                {
                    updateFunction(existingRecord, currentRecordFromForm);
                }
            }
        }

        private static void MergeDelete<T>(this ICollection<T> existingList, IEnumerable<T> updatedList, Match<T> matchCriteria, DatabaseEntities dbContext) where T : ICanDeleteFull
        {
            // Deleting records from existing that are no longer in fromForm
            var recordsToDelete = existingList.Where(existingRecord => Equals(updatedList.MatchRecord(existingRecord, matchCriteria), default(T))).ToList();
            recordsToDelete.ForEach(recordToDelete =>
            {
                recordToDelete.DeleteFull(dbContext);
                existingList.Remove(recordToDelete);
            });
        }

        private static T MatchRecord<T>(this IEnumerable<T> listToSearch, T itemToSearch, Match<T> matcher)
        {
            return listToSearch.SingleOrDefault(x => matcher(itemToSearch, x));
        }
    }
}
