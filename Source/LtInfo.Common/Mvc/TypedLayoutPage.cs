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