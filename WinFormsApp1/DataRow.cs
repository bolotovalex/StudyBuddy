using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Pryamolineynost;

public class DataRow
{
    private int Length = 0; //Длина измерения, мм
    private decimal FactCheckedProfileLength = 0; //Фактический профиль проверяемой поверхности, мкм
    private decimal AdjStraight = 0; //Прилегающая прямая, мкм
    private decimal Deviation = 0; //Отклонение, мкм
    private decimal DevationPerMeter = 0; //Отклонение на метре, мкм
    private decimal MidValue = 0; //Среднее значение, мкм
    public decimal FStroke { get; set; } //Прямой ход, мкм
    public decimal RevStroke { get; set; } //Обратный ход, мкм

    public DataRow()
    {
        Length = 0;
        FactCheckedProfileLength = 0;
        AdjStraight = 0;
        Deviation = 0;
        DevationPerMeter = 0;
        MidValue = 0;
        FStroke = 0;
        RevStroke = 0;
    }


    public void UpdateRow(decimal FStroke, decimal RevStroke, int step, DataRow prevDataRow)
    {
        this.FStroke = FStroke;
        this.RevStroke = RevStroke;
        Length = prevDataRow.GetLength() + step;
        MidValue = this.RevStroke == int.MinValue ? this.FStroke : (this.RevStroke + this.FStroke) / 2;
        FactCheckedProfileLength = MidValue * step / 1000 + prevDataRow.GetFactProfileLength();
    }

    public void UpdateAdjStraight(decimal programFactor1, decimal programFactor2)
    {
        AdjStraight = programFactor1 * Length + programFactor2;
    }

    public void UpdateDeviation()
    {
        Deviation = FactCheckedProfileLength - AdjStraight;
    }


    public int GetLength()
    {
        return Length;
    }

    public decimal GetFactProfileLength()
    {
        return FactCheckedProfileLength;
    }

    public decimal GetAdjStraight()
    {
        return AdjStraight;
    }

    public decimal GetDeviation()
    {
        return Deviation;
    }

    public decimal GetDeviationPerMeter()
    {
        return DevationPerMeter;
    }

    public void SetDeviationPerMeter(decimal value)
    {
        DevationPerMeter = value;
    }

    public decimal GetMidValue()
    {
        return MidValue;
    }

    public decimal GetFStroke()
    {
        return FStroke;
    }

    public decimal GetRevStroke()
    {
        return RevStroke;
    }
}