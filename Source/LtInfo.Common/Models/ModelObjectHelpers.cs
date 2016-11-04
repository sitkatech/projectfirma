using System.Threading;

namespace LtInfo.Common.Models
{
    public static class ModelObjectHelpers
    {
        public const int NotYetAssignedID = -1;
        private static int _lastUnsavedPrimaryKeyValueIssued = NotYetAssignedID;

        public static bool IsRealPrimaryKeyValue(int? primaryKeyValueToCheck)
        {
            return primaryKeyValueToCheck.HasValue && primaryKeyValueToCheck.Value != NotYetAssignedID && primaryKeyValueToCheck.Value > 0;
        }

        /// <summary>
        /// Assigns new IDs to objects in a thread safe way, so that those IDs are considered not saved yet. <see cref="IsRealPrimaryKeyValue"/>
        /// </summary>
        public static int MakeNextUnsavedPrimaryKeyValue()
        {
            return Interlocked.Decrement(ref _lastUnsavedPrimaryKeyValueIssued);
        }
    }
}