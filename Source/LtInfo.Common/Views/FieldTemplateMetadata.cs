/*-----------------------------------------------------------------------
<copyright file="FieldTemplateMetadata.cs" company="Sitka Technology Group">
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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LtInfo.Common.Views
{
    public class FieldTemplateMetadata : DataAnnotationsModelMetadata
    {
        private bool? _isComplexTypeOverride;

        public FieldTemplateMetadata(DataAnnotationsModelMetadataProvider provider, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName, DisplayColumnAttribute displayColumnAttribute, IEnumerable<Attribute> attributes, bool? isComplexTypeOverride = null)
            : base(provider, containerType, modelAccessor, modelType, propertyName, displayColumnAttribute)
        {
            Attributes = new List<Attribute>(attributes);
            _isComplexTypeOverride = isComplexTypeOverride;
        }

        public override bool IsComplexType
        {
            get { return _isComplexTypeOverride != null ? _isComplexTypeOverride.Value : base.IsComplexType; }
        }

        public IList<Attribute> Attributes
        {
            get;
            private set;
        }
    }
}
