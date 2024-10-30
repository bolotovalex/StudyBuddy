namespace LogicLibrary;

public class DataRow
{
    /// <summary>
    /// Класс для хранения точек измерения и расчета служебных параметров.
    /// </summary>
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

    public void UpdateRow(decimal FStroke, decimal RevStroke, int step, DataRow? prevDataRow, bool revStrokeEnabled)
    {
        ///<summary>
        ///Обновлнение полей при изменении значений
        ///</summary>
        this.FStroke = FStroke;
        this.RevStroke = RevStroke;
        Position = prevDataRow != null ? prevDataRow.Position + step : 0;
        MidValue = this.RevStroke != int.MinValue && revStrokeEnabled ? (this.RevStroke + this.FStroke) / 2 : this.FStroke;
        FactCheckedProfileLength = prevDataRow != null ? MidValue * step / 1000 + prevDataRow.FactCheckedProfileLength : MidValue * step / 1000 ;
    }

    public void UpdateAdjStraight(decimal programFactor1, decimal programFactor2)
    {
        ///<summary>
        ///Расчет коэффицинета для прилягающей прямой. С помощью этого коэфицента вычисляется Y координата на следующем шаге
        /// </summary>
        AdjStraight = programFactor1 * Position + programFactor2;
    }

    public void CalculateDeviation()
    {
        ///<summary>
        ///Считаем отклонение от фактической поверхности до прямой проведенной 
        ///из первой точки в самую последнюю(прилягающая прямая).
        ///</summary>
        Deviation = FactCheckedProfileLength - AdjStraight;
    }

    public string[] GetAllCellsStringArray()
    {
        ///<summary>
        ///Получение списка строк для графика
        /// </summary>
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