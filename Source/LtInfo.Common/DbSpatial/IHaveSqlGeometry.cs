using System.Data.Entity.Spatial;
using Microsoft.SqlServer.Types;

namespace LtInfo.Common.DbSpatial
{
    public interface IHaveSqlGeometry
    {
        DbGeometry DbGeometry { get; set; }
        SqlGeometry SqlGeometry { get; }
    }
}