using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Pryamolineynost
{
    public class DataRow
    {
        private int Length = 0; //Длина измерения, мм
        private float FactCheckedProfileLength = 0; //Фактический профиль проверяемой поверхности, мкм
        private float AdjStraight = 0; //Прилегающая прямая, мкм
        private float Deviation = 0; //Отклонение, мкм
        private float DevationPerMeter = 0; //Отклонение на метре, мкм
        private float MidValue = 0; //Среднее значение, мкм
        private float FStroke; //Прямой ход, мкм
        private float RevStroke = 0; //Обратный ход, мкм

        public DataRow() {
            this.Length = 0;
            this.FactCheckedProfileLength = 0;
            this.AdjStraight = 0;
            this.Deviation = 0;
            this.DevationPerMeter = 0;
            this.MidValue = 0;
            this.FStroke = 0;
            this.RevStroke = 0;
        }

               
        public void UpdateRow(float FStroke, float RevStroke, int step, DataRow prevDataRow)
        {
            this.FStroke = FStroke;
            this.RevStroke = RevStroke;
            this.Length = prevDataRow.GetLength() + step;
            this.MidValue = this.RevStroke == int.MinValue ? this.FStroke : (this.RevStroke + this.FStroke) / 2;
            this.FactCheckedProfileLength = ( this.MidValue * step / 1000 ) + prevDataRow.GetFactProfileLength();
        }

        public void UpdateAdjStraight(float programFactor1, float programFactor2)
        {
            this.AdjStraight = programFactor1 * this.Length + programFactor2;
        }

        public void UpdateDeviation()
        {
            this.Deviation = this.FactCheckedProfileLength - this.AdjStraight;
        }

        public int GetLength() => this.Length;
        public float GetFactProfileLength() => this.FactCheckedProfileLength;
        public float GetAdjStraight() => this.AdjStraight;
        public float GetDeviation() => this.Deviation;
        public float GetDeviationPerMeter() => this.DevationPerMeter;
        public float GetMidValue() => this.MidValue;
        public float GetFStroke() => this.FStroke;
        public float GetRevStroke() => this.RevStroke;
    }
}