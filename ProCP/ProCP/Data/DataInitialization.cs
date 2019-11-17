using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProCP.Data
{
    class DataInitialization
    {
        private IData _dataReader;
        public DataInitialization(IData dataReader)
        {
            this._dataReader = dataReader;
        }
        public void InitializeData(string file)
        {
            _dataReader.ReadData(file);
        }
    }
}
