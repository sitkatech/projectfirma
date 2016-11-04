using System;
using System.Globalization;
using System.Web.Mvc;
using LtInfo.Common.Models;

namespace LtInfo.Common.EntityModelBinding
{
    /// <summary>
    /// Provides a way to have the MVC controller action context bind and load the object from the database
    /// </summary>
    [ModelBinder(typeof(LtInfoEntityPrimaryKeyModelBinder))]
    public class LtInfoEntityPrimaryKey<T> where T : IHavePrimaryKey
    {
        private readonly int _primaryKeyValue;
        public LtInfoEntityPrimaryKey(int primaryKeyValue)
        {
            _primaryKeyValue = primaryKeyValue;
            _entityObject = new Lazy<T>(() => (T)SitkaHttpRequestStorage.LtInfoEntityTypeLoader.LoadType(typeof(T), primaryKeyValue));
        }
        public LtInfoEntityPrimaryKey(T theObject)
        {
            _primaryKeyValue = theObject.PrimaryKey;
            _entityObject = new Lazy<T>(() => theObject);
        }
        private readonly Lazy<T> _entityObject;
        public T EntityObject
        {
            get { return _entityObject.Value; }
        }
        public int PrimaryKeyValue
        {
            get
            {
                return _entityObject.IsValueCreated ? _entityObject.Value.PrimaryKey : _primaryKeyValue;
            }
        }
        public override string ToString()
        {
            return PrimaryKeyValue.ToString(CultureInfo.InvariantCulture);
        }
    }
}