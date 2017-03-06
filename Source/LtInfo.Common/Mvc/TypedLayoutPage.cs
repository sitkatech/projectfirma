/*-----------------------------------------------------------------------
<copyright file="TypedLayoutPage.cs" company="Sitka Technology Group">
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
using System.Web.Mvc;
using JetBrains.Annotations;

namespace LtInfo.Common.Mvc {
	public abstract class TypedLayoutPage<TLayoutModel> : WebViewPage {
		private TLayoutModel _layoutModel;

		public override void InitHelpers() {
			base.InitHelpers();

            if (LayoutViaViewDataDictionary == null)
				throw new InvalidOperationException("You must specify LayoutModel when rendering a typed layout. Use the SetLayout() method from within your view.");
            if (!(LayoutViaViewDataDictionary is TLayoutModel))
                throw new InvalidOperationException(string.Format("The specified LayoutModel value is of type '{0}' and must be of type '{1}'.", LayoutViaViewDataDictionary.GetType(), typeof(TLayoutModel)));
            _layoutModel = (TLayoutModel) LayoutViaViewDataDictionary;
		}

	    private object LayoutViaViewDataDictionary
	    {
	        get { return ViewData[TypedWebViewPage.LayoutDictionaryKey]; }
            set { ViewData[TypedWebViewPage.LayoutDictionaryKey] = value; }
	    }

	    [NotNull]
		public TLayoutModel LayoutModel {
			get { return _layoutModel; }
		}

		public void SetLayout([PathReference] string layout, [NotNull] object layoutModel) {
			if (layoutModel == null)
				throw new ArgumentNullException("layoutModel");
            LayoutViaViewDataDictionary = layoutModel;
			base.Layout = layout;
		}

		[Obsolete("You cannot use the Layout property when rendering a typed layout. Use the SetLayout() method instead.", true)]
		public new string Layout {
			get { throw new InvalidOperationException("You cannot use the Layout property when rendering a typed layout. Use the SetLayout() method instead."); }
			set { throw new InvalidOperationException("You cannot use the Layout property when rendering a typed layout. Use the SetLayout() method instead."); }
		}
	}
}
