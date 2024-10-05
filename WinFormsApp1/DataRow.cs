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
        private decimal FactCheckedProfileLength = 0; //Фактический профиль проверяемой поверхности, мкм
        private decimal AdjStraight = 0; //Прилегающая прямая, мкм
        private decimal Deviation = 0; //Отклонение, мкм
        private decimal DevationPerMeter = 0; //Отклонение на метре, мкм
        private decimal MidValue = 0; //Среднее значение, мкм
        private decimal FStroke; //Прямой ход, мкм
        private decimal RevStroke = 0; //Обратный ход, мкм

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

               
        public void UpdateRow(decimal FStroke, decimal RevStroke, int step, DataRow prevDataRow)
        {
            this.FStroke = FStroke;
            this.RevStroke = RevStroke;
            this.Length = prevDataRow.GetLength() + step;
            this.MidValue = this.RevStroke == int.MinValue ? this.FStroke : (this.RevStroke + this.FStroke) / 2;
            this.FactCheckedProfileLength = ( this.MidValue * step / 1000 ) + prevDataRow.GetFactProfileLength();
        }

        public void UpdateAdjStraight(decimal programFactor1, decimal programFactor2)
        {
            this.AdjStraight = programFactor1 * this.Length + programFactor2;
        }

        public void UpdateDeviation()
        {
            this.Deviation = this.FactCheckedProfileLength - this.AdjStraight;
        }

        public int GetLength() => this.Length;
        public decimal GetFactProfileLength() => this.FactCheckedProfileLength;
        public decimal GetAdjStraight() => this.AdjStraight;
        public decimal GetDeviation() => this.Deviation;
        public decimal GetDeviationPerMeter() => this.DevationPerMeter;

        public void SetDeviationPerMeter(decimal value)
        {
            this.DevationPerMeter = value;
        }
        public decimal GetMidValue() => this.MidValue;
        public decimal GetFStroke() => this.FStroke;
        public decimal GetRevStroke() => this.RevStroke;
    }
}