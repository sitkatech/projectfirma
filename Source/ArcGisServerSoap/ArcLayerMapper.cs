using System;
using System.Linq;
using TrpaArcGisServerSoap;

namespace ArcGisServerSoap
{
    internal abstract class ArcLayerMapper<T>
    {
        protected static int FindIndexByFieldName(string nameFieldName, Fields fields)
        {
            var nameFieldIndex = fields.FieldArray.ToList().FindIndex(x => x.Name == nameFieldName);
            if (nameFieldIndex < 0)
            {
                throw new ApplicationException(string.Format("Could not find field \"{0}\"", nameFieldName));
            }
            return nameFieldIndex;
        }
        public abstract void SetFields(Fields fields);
        public abstract T Convert(Record arcRecord);
        public abstract string LayerName { get; }
    }
}