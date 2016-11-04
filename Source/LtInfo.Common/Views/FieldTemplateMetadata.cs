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