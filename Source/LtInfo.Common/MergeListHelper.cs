using System.Collections.Generic;
using System.Linq;

namespace LtInfo.Common
{
    public static class MergeListHelper
    {
        public delegate bool Match<in T>(T o1, T o2);
        public delegate void UpdateFunction<in T>(T o1, T o2);

        public static void Merge<T>(this ICollection<T> existingList, ICollection<T> updatedList, ICollection<T> allInDatabase, Match<T> matchCriteria)
        {
            existingList.Merge(updatedList, allInDatabase, matchCriteria, null);
        }

        public static void Merge<T>(this ICollection<T> existingList, ICollection<T> updatedList, ICollection<T> allInDatabase, Match<T> matchCriteria, UpdateFunction<T> updateFunction)
        {
            existingList.MergeNew(updatedList, matchCriteria, allInDatabase);
            if (updateFunction != null)
            {
                existingList.MergeUpdate(updatedList, matchCriteria, updateFunction);
            }
            existingList.MergeDelete(updatedList, matchCriteria, allInDatabase);
        }

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

        private static void MergeDelete<T>(this ICollection<T> existingList, IEnumerable<T> updatedList, Match<T> matchCriteria, ICollection<T> allInDatabase)
        {
            // Deleting records from existing that are no longer in fromForm
            var recordsToDelete = existingList.Where(existingRecord => Equals(updatedList.MatchRecord(existingRecord, matchCriteria), default(T))).ToList();
            recordsToDelete.ForEach(recordToDelete =>
            {
                allInDatabase.Remove(recordToDelete);
                existingList.Remove(recordToDelete);
            });
        }

        private static T MatchRecord<T>(this IEnumerable<T> listToSearch, T itemToSearch, Match<T> matcher)
        {
            return listToSearch.SingleOrDefault(x => matcher(itemToSearch, x));
        }
    }
}