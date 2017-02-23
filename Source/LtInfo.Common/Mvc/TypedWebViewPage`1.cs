/*-----------------------------------------------------------------------
<copyright file="TypedWebViewPage`1.cs" company="Sitka Technology Group">
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

namespace LtInfo.Common.Mvc
{
    public abstract class TypedWebViewPage<TViewData> : TypedWebViewPage<TViewData, object>
    {
        [Obsolete("You must explicitly specify both TViewData and TViewModel to use the Model property. Use an @model declaration to specify both the view-model and model types.", true)]
        public new object Model
        {
            get { throw new InvalidOperationException("You must explicitly specify both TViewData and TViewModel to use the Model property. Use an @model declaration to specify both the view-model and model types."); }
            set { throw new InvalidOperationException("You must explicitly specify both TViewData and TViewModel to use the Model property. Use an @model declaration to specify both the view-model and model types."); }
        }
    }

    public abstract class TypedWebPartialViewPage<TViewData> : TypedWebViewPage<TViewData, object>
    {
        [Obsolete("You must explicitly specify both TViewData and TViewModel to use the Model property. Use an @model declaration to specify both the view-model and model types.", true)]
        public new object Model
        {
            get { throw new InvalidOperationException("You must explicitly specify both TViewData and TViewModel to use the Model property. Use an @model declaration to specify both the view-model and model types."); }
            set { throw new InvalidOperationException("You must explicitly specify both TViewData and TViewModel to use the Model property. Use an @model declaration to specify both the view-model and model types."); }
        }
    }

}
