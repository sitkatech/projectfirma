using System;
using System.ComponentModel;
using ProjectFirma.Web.Models;
using LtInfo.Common.HtmlHelperExtensions;

namespace ProjectFirma.Web.Common
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class FieldDefinitionDisplayAttribute : DisplayNameAttribute, IFieldDefinitionDisplayAttribute
    {
        public IFieldDefinition FieldDefinition { get; private set; }

        public FieldDefinitionDisplayAttribute(FieldDefinitionEnum fieldDefinitionEnum) : base(Models.FieldDefinition.ToType(fieldDefinitionEnum).FieldDefinitionDisplayName)
        {
            FieldDefinition = Models.FieldDefinition.ToType(fieldDefinitionEnum);
        }
    }
}