/*-----------------------------------------------------------------------
<copyright file="ColumnBindingAttribute.cs" company="Sitka Technology Group">
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
using System.Data;

namespace LtInfo.Common.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnBinding : Attribute
    {
        private readonly string _name;
        private readonly SqlDbType _type;
        private readonly string _format;
        private readonly bool _isOptional;

        public ColumnBinding()
        {
            _type = SqlDbType.Variant;
            _isOptional = false;
        }

        public ColumnBinding(string name)
        {
            _name = name;
            _type = SqlDbType.Variant;
            _isOptional = false;
        }

        public ColumnBinding(string name, bool isOptional)
        {
            _name = name;
            _type = SqlDbType.Variant;
            _isOptional = isOptional;
        }

        public ColumnBinding(string name, bool isOptional, SqlDbType type)
        {
            _name = name;
            _type = type;
            _isOptional = isOptional;
        }

        public ColumnBinding(string name, bool isOptional, SqlDbType type, string format)
        {
            _name = name;
            _type = type;
            _isOptional = isOptional;
            _format = format;
        }

        public string Name
        {
            get { return _name; }
        }

        public SqlDbType SourceDataType
        {
            get { return _type; }
        }

        public string Format
        {
            get { return _format; }
        }

        public bool IsOptional
        {
            get { return _isOptional; }
        }
    }
}
