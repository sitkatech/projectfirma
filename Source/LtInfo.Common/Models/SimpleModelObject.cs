/*-----------------------------------------------------------------------
<copyright file="SimpleModelObject.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
