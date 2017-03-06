/*-----------------------------------------------------------------------
<copyright file="ModelObjectForeignKeyManagerNonNullable.cs" company="Sitka Technology Group">
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
using System;
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common.Models
{
    /// <summary>
    /// See <see cref="ModelObjectForeignKeyManagerNullable{T}"/> for details, nearly the same except that it doesn't allow setting things to null
    /// </summary>
    [Serializable]
    public class ModelObjectForeignKeyManagerNonNullable<T> where T : class, IHavePrimaryKey
    {
        private readonly ModelObjectForeignKeyManagerNullable<T> _impl;
        public ModelObjectForeignKeyManagerNonNullable(Func<int, T> funcLoadModelObjectById)
        {
            _impl = new ModelObjectForeignKeyManagerNullable<T>(funcLoadModelObjectById);
            _impl.SetForeignKeyID(default(int));
        }

        public int GetForeignKeyID()
        {
            // ReSharper disable PossibleInvalidOperationException
            return _impl.GetForeignKeyID().Value;
            // ReSharper restore PossibleInvalidOperationException
        }

        public void SetForeignKeyID(int value)
        {
            _impl.SetForeignKeyID(value);
        }

        public void SetForeignKeyObject(T value)
        {
            Check.RequireNotNull(value, "Can't set this non-nullable property object to null.");
            _impl.SetForeignKeyObject(value);
        }

        public T GetForeignKeyObject()
        {
            return _impl.GetForeignKeyObject();
        }
    }
}
