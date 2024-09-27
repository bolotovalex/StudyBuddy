using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pryamolineynost
{
    class DataList
    {
        public List<DataRow> data = new List<DataRow>();

        public DataList()
        {
            this.data.Add(new DataRow());
        }
    }
}
