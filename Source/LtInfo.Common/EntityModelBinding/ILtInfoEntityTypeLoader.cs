using System;

namespace LtInfo.Common.EntityModelBinding
{
    /// <summary>
    /// Interface to allow <see cref="LtInfoEntityPrimaryKeyModelBinder"/> to be able to load types in general from type factory
    /// </summary>
    public interface ILtInfoEntityTypeLoader
    {
        object LoadType(Type type, int entityPrimaryKey);
    }
}