using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pryamolineynost
{
    public class DataRow
    {
        public int Step { get; }
        public int Length { get; }
        public float FactCheckedProfileLength { get; }
        public float AdjStraight { get; }
        public float Deviation { get; }
        public float DevationPerMeter { get; }
        public float MidValue { get; }
        public float FStroke { get; }
        public float RevStroke { get; }
        public int Count { get; }


        public DataRow(float fStroke, float revStroke)
        {
            this.FStroke = fStroke;
            this.RevStroke = revStroke;
            this.Count = 9;
        }
    }
}