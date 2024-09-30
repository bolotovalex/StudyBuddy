using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pryamolineynost
{
    public class DataList
    {
        public List<DataRow> dataList { get; }

        public DataList()

        {
            this.dataList = new List<DataRow>();
            this.dataList.Add(new DataRow(0,0));
        }

        public DataRow GetRow (int index) => dataList[index];

       
        public void AddRow(float fStroke, float revStroke)
        {
            this.dataList.Add(new DataRow(fStroke, revStroke));
        }

        public int RowsCount() => dataList.Count;
        public int ColsCount() => dataList[0].Count;
    }
}
