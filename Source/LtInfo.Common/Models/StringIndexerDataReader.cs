using System.Data;

namespace LtInfo.Common.Models
{
    public class StringIndexerDataReader : IStringIndexer
    {
        private readonly DataTableReader _dataReader;

        public StringIndexerDataReader(DataTableReader reader)
        {
            _dataReader = reader;
        }

        #region IStringIndexer Members

        public object this[string index]
        {
            get { return _dataReader[index]; }
        }

        #endregion
    }
}