using System;
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common.Models
{
    /// <summary>
    /// See <see cref="ModelObjectForeignKeyManagerNullable{T}"/> for details, nearly the same except that it doesn't allow setting things to null
    /// </summary>
    [Serializable]
    public class ModelObjectForeignKeyManagerNonNullable<T> where T : class, IHavePrimaryKey
    {
        private readonly ModelObjectForeignKeyManagerNullable<T> _impl;
        public ModelObjectForeignKeyManagerNonNullable(Func<int, T> funcLoadModelObjectById)
        {
            _impl = new ModelObjectForeignKeyManagerNullable<T>(funcLoadModelObjectById);
            _impl.SetForeignKeyID(default(int));
        }

        public int GetForeignKeyID()
        {
            // ReSharper disable PossibleInvalidOperationException
            return _impl.GetForeignKeyID().Value;
            // ReSharper restore PossibleInvalidOperationException
        }

        public void SetForeignKeyID(int value)
        {
            _impl.SetForeignKeyID(value);
        }

        public void SetForeignKeyObject(T value)
        {
            Check.RequireNotNull(value, "Can't set this non-nullable property object to null.");
            _impl.SetForeignKeyObject(value);
        }

        public T GetForeignKeyObject()
        {
            return _impl.GetForeignKeyObject();
        }
    }
}