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
        private double FactCheckedProfileLength = 0; //Фактический профиль проверяемой поверхности, мкм
        private double AdjStraight = 0; //Прилегающая прямая, мкм
        private double Deviation = 0; //Отклонение, мкм
        private double DevationPerMeter = 0; //Отклонение на метре, мкм
        private double MidValue = 0; //Среднее значение, мкм
        private double FStroke; //Прямой ход, мкм
        private double RevStroke = 0; //Обратный ход, мкм

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

               
        public void UpdateRow(double FStroke, double RevStroke, int step, DataRow prevDataRow)
        {
            this.FStroke = FStroke;
            this.RevStroke = RevStroke;
            this.Length = prevDataRow.GetLength() + step;
            this.MidValue = this.RevStroke == int.MinValue ? this.FStroke : (this.RevStroke + this.FStroke) / 2;
            this.FactCheckedProfileLength = ( this.MidValue * step / 1000 ) + prevDataRow.GetFactProfileLength();
        }

        public void UpdateAdjStraight(double programFactor1, double programFactor2)
        {
            this.AdjStraight = programFactor1 * this.Length + programFactor2;
        }

        public void UpdateDeviation()
        {
            this.Deviation = this.FactCheckedProfileLength - this.AdjStraight;
        }

        public int GetLength() => this.Length;
        public double GetFactProfileLength() => this.FactCheckedProfileLength;
        public double GetAdjStraight() => this.AdjStraight;
        public double GetDeviation() => this.Deviation;
        public double GetDeviationPerMeter() => this.DevationPerMeter;

        public void SetDeviationPerMeter(double value)
        {
            this.DevationPerMeter = value;
        }
        public double GetMidValue() => this.MidValue;
        public double GetFStroke() => this.FStroke;
        public double GetRevStroke() => this.RevStroke;
    }
}