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