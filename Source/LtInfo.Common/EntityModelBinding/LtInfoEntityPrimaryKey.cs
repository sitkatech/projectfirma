/*-----------------------------------------------------------------------
<copyright file="LtInfoEntityPrimaryKey.cs" company="Sitka Technology Group">
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
using System.Globalization;
using System.Web.Mvc;
using LtInfo.Common.Models;

namespace LtInfo.Common.EntityModelBinding
{
    /// <summary>
    /// Provides a way to have the MVC controller action context bind and load the object from the database
    /// </summary>
    [ModelBinder(typeof(LtInfoEntityPrimaryKeyModelBinder))]
    public class LtInfoEntityPrimaryKey<T> where T : IHavePrimaryKey
    {
        private readonly int _primaryKeyValue;
        public LtInfoEntityPrimaryKey(int primaryKeyValue)
        {
            _primaryKeyValue = primaryKeyValue;
            _entityObject = new Lazy<T>(() => (T)SitkaHttpRequestStorage.LtInfoEntityTypeLoader.LoadType(typeof(T), primaryKeyValue));
        }
        public LtInfoEntityPrimaryKey(T theObject)
        {
            _primaryKeyValue = theObject.PrimaryKey;
            _entityObject = new Lazy<T>(() => theObject);
        }
        private readonly Lazy<T> _entityObject;
        public T EntityObject
        {
            get { return _entityObject.Value; }
        }
        public int PrimaryKeyValue
        {
            get
            {
                return _entityObject.IsValueCreated ? _entityObject.Value.PrimaryKey : _primaryKeyValue;
            }
        }
        public override string ToString()
        {
            return PrimaryKeyValue.ToString(CultureInfo.InvariantCulture);
        }
    }
}
