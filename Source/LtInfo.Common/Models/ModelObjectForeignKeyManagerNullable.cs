/*-----------------------------------------------------------------------
<copyright file="ModelObjectForeignKeyManagerNullable.cs" company="Sitka Technology Group">
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
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common.Models
{
    /// <summary>
    /// Handles the intracacies for a <see cref="ModelObject"/> between a foreign key integer ID and the foreign key object
    /// Idea is to coordinate so that the foreign key ID and the foreign key object's primary key are always aligned.
    /// Defer to the object for the integer ID if at all possible
    /// 
    /// Must have same signatures as <see cref="ModelObjectForeignKeyManagerNonNullable{T}"/>
    /// </summary>
    [Serializable]
    public class ModelObjectForeignKeyManagerNullable<T> where T : class, IHavePrimaryKey
    {
        private readonly Func<int, T> _funcLoadModelObjectById;

        [NonSerialized]
        private bool _hasLoadedObject;

        [NonSerialized]
        private T _modelObject;

        private int? _modelObjectID;

        public ModelObjectForeignKeyManagerNullable(Func<int, T> funcLoadModelObjectById)
        {
            Check.RequireNotNull(funcLoadModelObjectById, "The loader function can't be null");
            _funcLoadModelObjectById = funcLoadModelObjectById;
        }

        /// <summary>
        /// Get the foreign key ID. Prefer <see cref="ModelObject.PrimaryKey"/> if available.
        /// </summary>
        public int? GetForeignKeyID()
        {
            if (_modelObject != null)
            {
                // Keep consistency between the stored ID and the object
                _modelObjectID = _modelObject.PrimaryKey;
            }
            return _modelObjectID;
        }

        /// <summary>
        /// Set the foreign key ID
        /// If the foreign key ID disagrees with <see cref="ModelObject.PrimaryKey"/> the object will be nulled out and reset to try to load from database
        /// </summary>
        public void SetForeignKeyID(int? value)
        {
            // if in "object" mode...
            if (_modelObject != null)
            {
                // Use the object to decide
                if (value != _modelObject.PrimaryKey)
                {
                    _modelObject = null;
                    _hasLoadedObject = false;
                }
                // Don't merge the IFs above, this implicit else clause does nothing on purpose - we don't consider the ID if the object is set
            }
                // Otherwise use the ID
            else if (value != _modelObjectID)
            {
                _modelObject = null;
                _hasLoadedObject = false;
            }
            _modelObjectID = value;
        }

        /// <summary>
        /// Sets the foreign key object
        /// Aligns the foreign key ID with the object
        /// </summary>
        /// <param name="value"></param>
        public void SetForeignKeyObject(T value)
        {
            if (value == null)
            {
                _modelObjectID = null;
            }
            else
            {
                _modelObjectID = value.PrimaryKey;
            }
            _modelObject = value;
            _hasLoadedObject = true;
        }

        /// <summary>
        /// Returns or loads the object referred to by the ID
        /// </summary>
        public T GetForeignKeyObject()
        {
            if (!_hasLoadedObject)
            {
                if (_modelObjectID.HasValue)
                {
                    _modelObject = _funcLoadModelObjectById(_modelObjectID.Value);
                }
                _hasLoadedObject = true;
            }
            return _modelObject;
        }
    }
}
