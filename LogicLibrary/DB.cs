using System.Drawing;
namespace LogicLibrary;

public class DB
{
    public DateTime Date { get; set; } //Дата
    public required string Name { get; set; } //Наименование
    public required string Description { get; set; } //Обозначение
    public required string Fio { get; set; } //Измерения произвел
    public decimal MinDeviation { get; set; } //Наибольшее отклонение, мкм
    public decimal MaxDeviation { get; set; } //Наименьшее отклонение, мкм
    public decimal VerticalDeflection { get; set; } //Отклонение от прямолинейности в вертикальной плоскости, мкм - 
    public decimal MeterDeflection { get; set; } //Отклонение от прямолинейности на 1 метр, мкм -
    public int FullTolerance { get; set; } //Допуск на всю длину, мкм -
    public int MeterTolerance { get; set; } //Допуск на 1 метр, мкм -
    public int LocalAreaLength { get; set; } = 0; //Локальный участок, мм
    public int BedAreaLength { get; set; } = 0; //Длина станины, мм
    public int Step { get; set; } //Шаг измерения (расстояние между опорами мостика), мм
    private decimal _programFactor1; //Программный коэффициент
    private decimal _programFactor2; //Программный коэффициент
    public List<DataRow> DataList { get; set; } //Таблица измерений
    private int _stepsPerMeter { get; set; }
    public bool RevStrokeEnbled = false;


    public DB(List<DataRow> dataList, int step)
    {
        foreach(var row in dataList)
        {
            this.AddRow(row.FStroke, row.RevStroke);
        }
    }

    public DB()
    {
        MaxDeviation = 0;
        DataList = [];
        Date = DateTime.Now.Date;
        Step = 200;
        UpdateStepsPerMeter(Step);
        DataList.Add(new DataRow(0,0,0,null,RevStrokeEnbled));
    }

    public void UpdateStepsPerMeter(int stepsLength)
    {
        if (stepsLength != 0)
        {
            _stepsPerMeter = 1000 % stepsLength >= 5 ? 1000 / stepsLength + 1 : 1000 / stepsLength;
            LocalAreaLength = 1000 / stepsLength * stepsLength;
        }
    }

    private void UpdateProgramFactors()
    {
        if (DataList[^1].Position != 0)
        {
            _programFactor1 = DataList[^1].FactCheckedProfileLength /
                              DataList[^1].Position;
            _programFactor2 = 0; //TODO Доделать програмный коэфициент 2. В примере он всегда будет равен 0
        }
    }

    public void AddRow(decimal fStroke, decimal revStroke)
    {
        var prevRow = DataList[^1];
        var row = new DataRow(fStroke, revStroke, Step, prevRow, RevStrokeEnbled);
        DataList.Add(row);
        UpdateProgramFactors();
        row.UpdateAdjStraight(_programFactor1, _programFactor2);
        row.CalculateDeviation();
        UpdateAllRows();
    }

    private decimal GetMaxDeviationPerMeterForStep(int maxIndex)
    {
        //Нужно для расчета при шаге более 500мм
        var delimeter = _stepsPerMeter >= 2 ? _stepsPerMeter : 2; 

        var startIndex = maxIndex - delimeter + 1;
        var lengthOnMeter = new List<decimal>() { };
        
        for (var length = 0; length <= 1000; length += 1000 / delimeter)
            lengthOnMeter.Add(length);

        var factProfileList = new List<decimal>() { 0 };

        for (var i = startIndex; i < DataList.Count && i <= maxIndex; i++)
        {
            var factProfile = DataList[i].MidValue * Step / 1000 + factProfileList[i - startIndex];
            factProfileList.Add(factProfile);
        }

        var coefficient = factProfileList[^1] / lengthOnMeter[^1];
        var listDeviations = new List<decimal>() { 0 };
        decimal maxDeviation = 0;
        decimal minDeviation = 0;

        for (var i = startIndex; i < DataList.Count && i <= maxIndex; i++)
        {
            var prilPryamaya =
                coefficient * lengthOnMeter[i - startIndex + 1] +
                0; //TODO в документе указано ссылка на T15, но она пустая всегда.

            var deviation = factProfileList[i - startIndex + 1] - prilPryamaya;
            listDeviations.Add(deviation);
            if (maxDeviation < deviation)
                maxDeviation = deviation;
            else if (minDeviation > deviation)
                minDeviation = deviation;
        }

        return maxDeviation - minDeviation;
    }

    public void UpdateMeterDeflection()
    {
        decimal maxDeflection = 0;
        decimal minDeflection = 0;
        for (var i = 1; i <= DataList.Count - _stepsPerMeter; i++)
        {
            var rowDeviationPerMeter = DataList[i].DevationPerMeter;
            if (rowDeviationPerMeter > maxDeflection)
                maxDeflection = rowDeviationPerMeter;
            else if (rowDeviationPerMeter < minDeflection)
                minDeflection = rowDeviationPerMeter;
        }

        MeterDeflection = Math.Max(maxDeflection, -1 * minDeflection);
    }

    public void UpdateAllAdjStrokeDataList()
    {
        UpdateProgramFactors();
        for (var i = 1; i < DataList.Count; i++)
        {
            var selRow = DataList[i];
            selRow.UpdateAdjStraight(_programFactor1, _programFactor2);
        }
    }

    public void UpdateAllStroksDataList()
    {
        for (var i = 1; i < DataList.Count; i++)
        {
            var selRow = DataList[i];
            var prevRow = DataList[i - 1];

            selRow.UpdateRow(selRow.FStroke, selRow.RevStroke, Step, prevRow, RevStrokeEnbled);
        }
    }

    public void UpdateAllDeviationsDataList()
    {
        for (var i = 1; i < DataList.Count; i++)
        {
            var selRow = DataList[i];
            selRow.CalculateDeviation();
        }
    }

    public void UpdateMinMaxDeviations()
    {
        MaxDeviation = 0;
        MinDeviation = 0;

        for (var i = 1; i < DataList.Count; i++)
        {
            var selRow = DataList[i];
            var deviationValue = selRow.Deviation;
            if (deviationValue > MaxDeviation)
                MaxDeviation = deviationValue;
            else if (deviationValue < MinDeviation)
                MinDeviation = deviationValue;
        }
        VerticalDeflection = MaxDeviation + MinDeviation * -1;
    }

    public void UpdateMeterDeflectionAllDataList()
    {
        for (var i = 1; i < DataList.Count; i++)
        {
            var index = i - _stepsPerMeter + 1;
            if (DataList.Count - i >= 1 && DataList.Count > _stepsPerMeter && index >= 1)
            {
                DataList[index].DevationPerMeter = GetMaxDeviationPerMeterForStep(i);
            }
            if (DataList.Count - i < _stepsPerMeter)
            {
                DataList[i].DevationPerMeter = 0;
            }
        }
    }
    
    private decimal GetY(int x1, decimal y1, int x2, decimal y2, int x3)
    {
        return Math.Round((x3 * y2 - x3 * y1 - x1 * y2 + x2 * y1) / (x2 - x1), 2);
    }

    private decimal GetYBetweenStepIndex(int index, int coord)
    {
        
        return GetY(x1: DataList[index - 1].Position,
                    y1: DataList[index - 1].FactCheckedProfileLength,
                    x2: DataList[index].Position,
                    y2: DataList[index].FactCheckedProfileLength,
                    x3: coord);
    }

    public AreaDeviation GetAreaDeviation(int startPos)
    {
        int startX = startPos;
        decimal startY;
        int endX = startX + LocalAreaLength;
        decimal endY;

        var interval = GetIntervalIndex(startX, endX);
        var adjStraightStepList = new List<(int x, decimal y)>();

        startY = DataList[interval.startIndex].Position > startX 
            ? GetYBetweenStepIndex(interval.startIndex, startX) 
            : DataList[interval.startIndex++].FactCheckedProfileLength;
        endY = DataList[interval.endIndex].Position > endX
            ? GetYBetweenStepIndex(interval.endIndex, endX)
            : DataList[interval.endIndex].FactCheckedProfileLength;

        adjStraightStepList.Add((startX, startY));

        for (var i = interval.startIndex; i < interval.endIndex; i++)
        {
            var x = DataList[i].Position;
            var y = GetY(startX, startY, endX, endY, DataList[i].Position);
            adjStraightStepList.Add((x, y));
        }
        adjStraightStepList.Add((endX, endY));

        var delta = GetDeltaAreaDeviation(interval.startIndex, interval.endIndex, adjStraightStepList);

        return new AreaDeviation(delta.startX, startY, delta.endX, endY, delta.delta);
    }

    public (int startX, int endX, decimal delta) GetDeltaAreaDeviation(int startInteval, int endInterval, List<(int x, decimal y)> LocalAreaStraight)
    {
        var lst = new List<decimal>();
        decimal minDeviation = 0;
        decimal maxDeviation = 0;

        for (var i = 1; i < endInterval - startInteval + 1; i++)
        {
            var value = DataList[startInteval + i - 1].FactCheckedProfileLength - LocalAreaStraight[i].y;
            if (value < minDeviation)
                minDeviation = value;
            else if (value > maxDeviation)
                maxDeviation = value;
        }
            
        return (LocalAreaStraight[0].x, LocalAreaStraight[^1].x, maxDeviation - minDeviation);
    }

    public (int startIndex, int endIndex) GetIntervalIndex(int startPos, int endPos)
    {
        var startIndexIsFind = false;
        var endIndexIsFind = false;
        var startIndex = 0;
        var endIndex = DataList.Count - 1;
        for (var i = 0; i < DataList.Count; i++)
        {
            if (!startIndexIsFind && DataList[i].Position >= startPos)
            {
                startIndex = i;
                startIndexIsFind = true;
                continue;
            }

            if (!endIndexIsFind &&  DataList[i].Position >= endPos)
            {
                endIndex = i;
                endIndexIsFind = true;
            }
            if (startIndexIsFind && endIndexIsFind) break;
        }

        return (startIndex, endIndex);
    }

    public void UpdateAllRows()
    {
        //TODO Не оптимально. Множественные проходы. Нужно оптимизировать, но набор данных не большой. Пока сделано, чтобы считалось так-же как в excel
        UpdateAllStroksDataList();
        UpdateAllAdjStrokeDataList();
        UpdateAllDeviationsDataList();
        UpdateMinMaxDeviations();
        UpdateMeterDeflectionAllDataList();
        UpdateMeterDeflection();
        BedAreaLength = DataList[^1].Position;
        //CalculateLocalAreaStepCount();


        //TODO Не работает если не посчитаны program factors
        //UpdateProgramFactors();
        //MaxDeviation = 0;
        //MinDeviation = 0;

        //for (var i = 1; i < DataList.Count; i++)
        //{
        //    var selRow = DataList[i];
        //    var prevRow = DataList[i - 1];

        //    selRow.UpdateRow(selRow.FStroke, selRow.RevStroke, Step, prevRow);
        //selRow.UpdateAdjStraight(_programFactor1, _programFactor2);
        //selRow.CalculateDeviation();

        //var deviationValue = selRow.GetDeviation();
        //if (deviationValue > MaxDeviation)
        //    MaxDeviation = deviationValue;
        //else if (deviationValue < MinDeviation)
        //    MinDeviation = deviationValue;
        //_verticalDeflection = GetMaxDeviation() + GetMinDeviation() * -1;

        //if (DataList.Count - i == 1 && DataList.Count > _stepsPerMeter)
        //    DataList[i - _stepsPerMeter + 1].SetDeviationPerMeter(GetMaxDeviationPerMeterForStep(i));
        //}
    }

    public void UpdateFStrokeRow(int index, int value)
    {
        if (index > 0)
        {
            DataList[index].UpdateRow(value, DataList[index].RevStroke, Step, DataList[index - 1], RevStrokeEnbled);
            UpdateAllRows();
        }
    }

    public void UpdateRevStrokeRow(int index, int value)
    {
        if (index > 0)
        {
            DataList[index].UpdateRow(DataList[index].FStroke, value, Step, DataList[index - 1], RevStrokeEnbled);
            UpdateAllRows();
        }
    }
    public void CleanDb()
    {
        Date = DateTime.Now.Date;
        DataList.Clear(); //= new List<DataRow>();
        _programFactor1 = 0;
        _programFactor2 = 0;
        VerticalDeflection = 0;
        UpdateStepsPerMeter(Step);
        DataList.Add(new DataRow(0, 0, 0, null, RevStrokeEnbled));
        UpdateAllRows();
    }

    public (string Name, object Value)[] GetDBFields()
    {
        return [
            ( "Дата", Date.Date),
            ( "Наименование", Name ),
            ( "Обозначение", Description ),
            ( "Измерения произвел", Fio ),
            ( "Наибольшее отклонение", MaxDeviation ),
            ( "Наименьшее отклонение", MinDeviation ),
            ( "Отклонение от прямолинейности в вертикальной плоскости, мкм",VerticalDeflection ),
            ( "Отклонение от прямолинейности на 1 метр, мкм",  MeterDeflection ),
            ( "Допуск на всю длину измерения, мкм",  FullTolerance ),
            ( "Допуск на 1 метр (или локальный), мкм",  MeterTolerance ),
            ( "Локальный участок, мм",  LocalAreaLength ),
            ( "Длина измерения, мм",  BedAreaLength ),
            ( "Шаг измерения (расстояние между опорами мостика), мм", Step)
        ];
    }

    public (string[][] dbValues, string[][] dataListValues) GetPrintStrings()
    {
        string[][] dbValues = [
            [ "Дата", Date.ToString().Split(" ")[0]],
            [ "Наименование", Name ],
            [ "Обозначение", Description ],
            [ "Измерения произвел",Fio ],
            [ "Наибольшее отклонение", Math.Round(MaxDeviation,2).ToString() ],
            [ "Наименьшее отклонение", Math.Round(MinDeviation, 2).ToString() ],
            [ "Отклонение от прямолинейности в вертикальной плоскости, мкм", Math.Round(VerticalDeflection, 2).ToString() ],
            [ "Отклонение от прямолинейности на 1 метр, мкм",  Math.Round(MeterDeflection, 2).ToString() ],
            [ "Допуск на всю длину измерения, мкм", FullTolerance.ToString() ],
            [ "Допуск на 1 метр (или локальный), мкм", MeterTolerance.ToString() ],
            [ "Локальный участок, мм", LocalAreaLength.ToString() ],
            [ "Длина измерения, мм", BedAreaLength.ToString() ],
            [ "Шаг измерения (расстояние между опорами мостика), мм", Step.ToString() ]];

        var dataListValues = new string[DataList.Count + 1][];
        
        dataListValues[0] = [
            "Длина измерения, мм",
            "Фактический профиль проверяемой поверхности, мкм",
            "Прилегающая прямая, мкм",
            "Отклонение, мкм",
            "Отклонение на метре, мкм",
            "Среднее значение, мкм",
            "Прямой ход, мкм",
            "Обратный ход, мкм" ];

        for (var i = 0; i < DataList.Count; i++)
        {
            dataListValues[i + 1] = DataList[i].GetAllCellsStringArray();
        }

        return (dbValues, dataListValues);

    }

    public (double[] positions, double[] graph1, double[] graph2) GetGraphicPoints()
    {
        var pos = new double[DataList.Count];
        var graph1 = new double[DataList.Count];
        var graph2 = new double[DataList.Count];
        for (int i = 0; i < DataList.Count; i++)
        {
            pos[i] = decimal.ToDouble(DataList[i].Position);
            graph1[i] = decimal.ToDouble(DataList[i].FactCheckedProfileLength);
            graph2[i] = decimal.ToDouble(DataList[i].AdjStraight);
        }

        return new(pos, graph1, graph2);
    }
}