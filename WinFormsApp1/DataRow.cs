using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private float FStroke = 0; //Прямой ход, мкм
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
        
        public DataRow(int step, float FStroke, float RevStroke, DataRow prevDataRow)
        { 
            this.FStroke = FStroke;
            this.RevStroke = RevStroke;
        }

        public void UpdateRow(int step, DataRow prevRow)
        {
            this.Length = step + prevRow.GetLength();
            this.MidValue = this.FStroke == 0 ? this.RevStroke : (this.RevStroke + this.FStroke) / 2;
            this.FactCheckedProfileLength = this.MidValue * step /1000 + prevRow.GetFactProfileLength();
        }

        public int GetLength() => this.Length;

        public float GetFactProfileLength() => this.FactCheckedProfileLength;


        //private void CalculateFields()
        //{

        //}

        //public DataRow(float fStroke, float revStroke)
        //{
        //    this.FStroke = fStroke;
        //    this.RevStroke = revStroke;
        //    //this.prevRow = prevRow;
        //}

        //public void UpdateRow(float fStroke, float revStroke)
        //{
        //    this.FStroke = fStroke;
        //    this.RevStroke = revStroke;
        //    CalculateFields();
        //}
    }
}