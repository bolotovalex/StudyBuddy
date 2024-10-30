namespace LogicLibrary;

public class DataRow
{
    public int Position { get; set; } //Длина измерения, мм
    public decimal FactCheckedProfileLength { get; set; } //Фактический профиль проверяемой поверхности, мкм
    public decimal AdjStraight { get; set; } //Прилегающая прямая, мкм
    public decimal Deviation { get; set; } //Отклонение, мкм
    public decimal DevationPerMeter { get; set; } //Отклонение на метре, мкм
    public decimal MidValue { get; set; } //Среднее значение, мкм
    public decimal FStroke { get; set; } //Прямой ход, мкм
    public decimal RevStroke { get; set; } //Обратный ход, мкм

    public DataRow(decimal FStroke, decimal RevStroke, int step, DataRow? prevDataRow, bool revStrokeEnabled)
    {
        UpdateRow(FStroke, RevStroke, step, prevDataRow, revStrokeEnabled);
    }

    public void UpdateRow(decimal FStroke, decimal RevStroke, int step, DataRow prevDataRow, bool revStrokeEnabled)
    {
        this.FStroke = FStroke;
        this.RevStroke = RevStroke;
        Position = prevDataRow.Position + step;
        MidValue = this.RevStroke != int.MinValue && revStrokeEnabled ? (this.RevStroke + this.FStroke) / 2 : this.FStroke;
        FactCheckedProfileLength = MidValue * step / 1000 + prevDataRow.FactCheckedProfileLength;
    }

    public void UpdateAdjStraight(decimal programFactor1, decimal programFactor2)
    {
        AdjStraight = programFactor1 * Position + programFactor2;
    }

    public void CalculateDeviation()
    {
        Deviation = FactCheckedProfileLength - AdjStraight;
    }

    public string[] GetAllCellsStringArray()
    {
        return [Position.ToString(),
                Math.Round(FactCheckedProfileLength,2).ToString(),
                Math.Round(AdjStraight,2).ToString(),
                Math.Round(Deviation,2).ToString(),
                Math.Round(DevationPerMeter,2).ToString(),
                Math.Round(MidValue,2).ToString(),
                FStroke == int.MinValue ? "0": FStroke.ToString(),
                RevStroke == int.MinValue ? "0" : RevStroke.ToString()];
            
    }
}