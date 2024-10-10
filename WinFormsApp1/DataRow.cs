﻿namespace Pryamolineynost;

public class DataRow
{
    private int Position = 0; //Длина измерения, мм
    private decimal FactCheckedProfileLength = 0; //Фактический профиль проверяемой поверхности, мкм
    private decimal AdjStraight = 0; //Прилегающая прямая, мкм
    private decimal Deviation = 0; //Отклонение, мкм
    private decimal DevationPerMeter = 0; //Отклонение на метре, мкм
    private decimal MidValue = 0; //Среднее значение, мкм
    public decimal FStroke { get; set; } //Прямой ход, мкм
    public decimal RevStroke { get; set; } //Обратный ход, мкм
    public const int CellsCount = 8;

    public DataRow()
    {
        Position = 0;
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
        Position = prevDataRow.GetLength() + step;
        MidValue = this.RevStroke == int.MinValue ? this.FStroke : (this.RevStroke + this.FStroke) / 2;
        FactCheckedProfileLength = MidValue * step / 1000 + prevDataRow.GetFactProfileLength();
    }

    public void UpdateAdjStraight(decimal programFactor1, decimal programFactor2)
    {
        AdjStraight = programFactor1 * Position + programFactor2;
    }

    public void UpdateDeviation()
    {
        Deviation = FactCheckedProfileLength - AdjStraight;
    }


    public int GetLength()
    {
        return Position;
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

    public string[] GetAllCellsStringArray()
    {
        return new string[] {
            Position.ToString(),
            Math.Round(FactCheckedProfileLength,2).ToString(),
            Math.Round(AdjStraight,2).ToString(),
            Math.Round(Deviation,2).ToString(),
            Math.Round(DevationPerMeter,2).ToString(),
            Math.Round(MidValue,2).ToString(),
            FStroke == int.MinValue ? "0": FStroke.ToString(),
            RevStroke == int.MinValue ? "0" : RevStroke.ToString()
        };
    }
}