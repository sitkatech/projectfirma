using System;

namespace LtInfo.Common.Models
{
    [Serializable]
    public abstract class SimpleModelObject : IStringIndexer
    {
        #region IStringIndexer Members

        /// <summary>
        /// this indexer will return/set the value of the public "name" property as an object.
        /// </summary>
        public object this[string name]
        {
            get { return GetProperty(name, this); }
            set { SetProperty(name, value, this); }
        }

        #endregion

        public static void SetProperty(string name, object value, object thing)
        {
            var type = thing.GetType();
            var pi = type.GetProperty(name);

            if (pi == null)
            {
                throw new IndexOutOfRangeException(String.Format("Property \"{0}\" is not visible on class \"{1}\"", name, type.Name));
            }

            pi.SetValue(thing, value, null);
        }

        public static object GetProperty(string name, object thing)
        {
            var type = thing.GetType();
            var pi = type.GetProperty(name);

            if (pi == null)
            {
                throw new IndexOutOfRangeException(String.Format("Property \"{0}\" is not visible on class \"{1}\"", name, type.Name));
            }

            return pi.GetValue(thing, null);
        }
    }
}