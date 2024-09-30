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
        public float FStroke { get; set; }
        public float RevStroke { get; set; }
        public int Count { get; }


        private void CalculateFields()
        {

        }
        
        public DataRow(float fStroke, float revStroke)
        {
            this.FStroke = fStroke;
            this.RevStroke = revStroke;
            this.Count = 9;
        }

        public void UpdateRow(float fStroke, float revStroke)
        {
            this.FStroke = fStroke;
            this.RevStroke = revStroke;
            CalculateFields();
        }
    }
}