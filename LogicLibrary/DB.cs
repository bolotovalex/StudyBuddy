using System.Drawing;
namespace LogicLibrary;

public class DB
{
    public DateTime Date { get; set; } //Дата
    public required string Name { get; set; } //Наименование
    public required string Description { get; set; } //Обозначение
    public required string Fio { get; set; } //Измерения произвел
    private decimal _minDeviation; //Наибольшее отклонение, мкм
    private decimal _maxDeviation; //Наименьшее отклонение, мкм
    private decimal _verticalDeflection; //Отклонение от прямолинейности в вертикальной плоскости, мкм - 
    private decimal _meterDeflection; //Отклонение от прямолинейности на 1 метр, мкм -
    public int FullTolerance { get; set; } //Допуск на всю длину, мкм -
    public int MeterTolerance { get; set; } //Допуск на 1 метр, мкм -
    private int _localAreaLength = 0; //Локальный участок, мм
    private int _bedAreaLength = 0; //Длина станины, мм
    public int Step { get; set; } //Шаг измерения (расстояние между опорами мостика), мм
    private decimal _programFactor1; //Программный коэффициент
    private decimal _programFactor2; //Программный коэффициент
    public List<DataRow> DataList { get; set; } //Таблица измерений
    private int _stepsPerMeter;
    public bool RevStrokeEnbled = false;


    public DB(List<DataRow> dataList, int step)
    {
        foreach(var row in dataList)
        {
            this.AddRow(row.FStroke, row.RevStroke);
        }
    }
    public void UpdateDateTime()
    {
        Date = DateTime.Now.Date;
    }

    public decimal GetMinDeviation()
    {
        return _minDeviation;
    }

    public decimal GetMaxDeviation()
    {
        return _maxDeviation;
    }

    public decimal GetVerticalDeflection()
    {
        return _verticalDeflection;
    }


    public decimal GetMeterDeflection()
    {
        return _meterDeflection;
    }

    public int GetFullTolerance()
    {
        return FullTolerance;
    }

    public int GetMeterTolerance()
    {
        return MeterTolerance;
    }

    public int GetLocalAreaLength()
    {
        return _localAreaLength;
    }

    public void SetLocalAreaLength(int length)
    {
        _localAreaLength = length;
    }

    public void SetMeasurementStep(int measurementStep)
    {
        Step = measurementStep;
    }

    public int GetMeasurementStep()
    {
        return Step;
    }

    public List<DataRow> GetDataList()
    {
        return DataList;
    }

    public DataRow GetLastDataRow()
    {
        return DataList[^1];
    }

    public DB()
    {
        _maxDeviation = 0;
        DataList = [];
        Date = DateTime.Now.Date;
        Step = 200;
        UpdateStepsPerMeter(Step);
        DataList.Add(new DataRow());
    }

    public void UpdateStepsPerMeter(int stepsLength)
    {
        if (stepsLength != 0)
        {
            _stepsPerMeter = 1000 % stepsLength >= 5 ? 1000 / stepsLength + 1 : 1000 / stepsLength;
            _localAreaLength = 1000 / stepsLength * stepsLength;
        }
    }

    private void UpdateProgramFactors()
    {
        if (DataList[^1].GetLength() != 0)
        {
            _programFactor1 = DataList[^1].GetFactProfileLength() /
                              DataList[^1].GetLength();
            _programFactor2 = 0; //TODO Доделать програмный коэфициент 2. В примере он всегда будет равен 0
        }
    }

    public void AddRow(decimal fStroke, decimal revStroke)
    {
        var row = new DataRow();
        var prevRow = DataList[^1];
        row.UpdateRow(fStroke, revStroke, Step, prevRow, RevStrokeEnbled);
        DataList.Add(row);
        UpdateProgramFactors();
        row.UpdateAdjStraight(_programFactor1, _programFactor2);
        row.UpdateDeviation();
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
            var factProfile = DataList[i].GetMidValue() * Step / 1000 + factProfileList[i - startIndex];
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
            var rowDeviationPerMeter = DataList[i].GetDeviationPerMeter();
            if (rowDeviationPerMeter > maxDeflection)
                maxDeflection = rowDeviationPerMeter;
            else if (rowDeviationPerMeter < minDeflection)
                minDeflection = rowDeviationPerMeter;
        }

        _meterDeflection = Math.Max(maxDeflection, -1 * minDeflection);
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

            selRow.UpdateRow(selRow.GetFStroke(), selRow.GetRevStroke(), Step, prevRow, RevStrokeEnbled);
        }
    }

    public void UpdateAllDeviationsDataList()
    {
        for (var i = 1; i < DataList.Count; i++)
        {
            var selRow = DataList[i];
            selRow.UpdateDeviation();
        }
    }

    public void UpdateMinMaxDeviations()
    {
        _maxDeviation = 0;
        _minDeviation = 0;

        for (var i = 1; i < DataList.Count; i++)
        {
            var selRow = DataList[i];
            var deviationValue = selRow.GetDeviation();
            if (deviationValue > _maxDeviation)
                _maxDeviation = deviationValue;
            else if (deviationValue < _minDeviation)
                _minDeviation = deviationValue;
        }
        _verticalDeflection = _maxDeviation + _minDeviation * -1;
    }

    public void UpdateMeterDeflectionAllDataList()
    {
        for (var i = 1; i < DataList.Count; i++)
        {
            var index = i - _stepsPerMeter + 1;
            if (DataList.Count - i >= 1 && DataList.Count > _stepsPerMeter && index >= 1)
            {
                DataList[index].SetDeviationPerMeter(GetMaxDeviationPerMeterForStep(i));
            }
            if (DataList.Count - i < _stepsPerMeter)
            {
                DataList[i].SetDeviationPerMeter(0);
            }
        }
    }

    public void UpdateBedLenth()
    {
        _bedAreaLength = GetLastDataRow().GetLength();
    }

    public int GetBedLength()
    {
        return _bedAreaLength;
    }

    private decimal GetY(int x1, decimal y1, int x2, decimal y2, int x3)
    {
        return Math.Round((x3 * y2 - x3 * y1 - x1 * y2 + x2 * y1) / (x2 - x1), 2);
    }

    private decimal GetYBetweenStepIndex(int index, int coord)
    {
        
        return GetY(x1: DataList[index - 1].GetLength(),
                    y1: DataList[index - 1].GetFactProfileLength(),
                    x2: DataList[index].GetLength(),
                    y2: DataList[index].GetFactProfileLength(),
                    x3: coord);
    }




    public AreaDeviation GetAreaDeviation(int startPos)
    {
        int startX = startPos;
        decimal startY;
        int endX = startX + _localAreaLength;
        decimal endY;

        var interval = GetIntervalIndex(startX, endX);
        var adjStraightStepList = new List<(int x, decimal y)>();

        startY = DataList[interval.startIndex].GetLength() > startX 
            ? GetYBetweenStepIndex(interval.startIndex, startX) 
            : DataList[interval.startIndex++].GetFactProfileLength();
        endY = DataList[interval.endIndex].GetLength() > endX
            ? GetYBetweenStepIndex(interval.endIndex, endX)
            : DataList[interval.endIndex].GetFactProfileLength();

        adjStraightStepList.Add((startX, startY));

        for (var i = interval.startIndex; i < interval.endIndex; i++)
        {
            var x = DataList[i].GetLength();
            var y = GetY(startX, startY, endX, endY, DataList[i].GetLength());
            adjStraightStepList.Add((x, y));
        }
        adjStraightStepList.Add((endX, endY));

        var delta = GetDeltaAreaDeviation(interval.startIndex, interval.endIndex, adjStraightStepList);

        return new AreaDeviation(delta.startX, delta.endX, delta.delta);
    }

    public (int startX, int endX, decimal delta) GetDeltaAreaDeviation(int startInteval, int endInterval, List<(int x, decimal y)> LocalAreaStraight)
    {
        var lst = new List<decimal>();
        decimal minDeviation = 0;
        decimal maxDeviation = 0;

        for (var i = 1; i < endInterval - startInteval + 1; i++)
        {
            var value = DataList[startInteval + i - 1].GetFactProfileLength() - LocalAreaStraight[i].y;
            if (value < minDeviation)
                minDeviation = value;
            else if (value > maxDeviation)
                maxDeviation = value;
        }
            
        //Console.WriteLine("-----------");
        //Console.WriteLine($"{LocalAreaStraight[0].x} - {LocalAreaStraight[^1].x} : {maxDeviation - minDeviation}");

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
            if (!startIndexIsFind && DataList[i].GetLength() >= startPos)
            {
                startIndex = i;
                startIndexIsFind = true;
                continue;
            }

            if (!endIndexIsFind &&  DataList[i].GetLength() >= endPos)
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
        UpdateBedLenth();
        //CalculateLocalAreaStepCount();
        

        //TODO Не работает если не посчитаны program factors
        //UpdateProgramFactors();
        //_maxDeviation = 0;
        //_minDeviation = 0;

        //for (var i = 1; i < DataList.Count; i++)
        //{
        //    var selRow = DataList[i];
        //    var prevRow = DataList[i - 1];

        //    selRow.UpdateRow(selRow.GetFStroke(), selRow.GetRevStroke(), Step, prevRow);
        //selRow.UpdateAdjStraight(_programFactor1, _programFactor2);
        //selRow.UpdateDeviation();

        //var deviationValue = selRow.GetDeviation();
        //if (deviationValue > _maxDeviation)
        //    _maxDeviation = deviationValue;
        //else if (deviationValue < _minDeviation)
        //    _minDeviation = deviationValue;
        //_verticalDeflection = GetMaxDeviation() + GetMinDeviation() * -1;

        //if (DataList.Count - i == 1 && DataList.Count > _stepsPerMeter)
        //    DataList[i - _stepsPerMeter + 1].SetDeviationPerMeter(GetMaxDeviationPerMeterForStep(i));
        //}
    }

    public void UpdateFStrokeRow(int index, int value)
    {
        if (index > 0)
        {
            DataList[index].UpdateRow(value, DataList[index].GetRevStroke(), Step, DataList[index - 1], RevStrokeEnbled);
            UpdateAllRows();
        }
    }

    public void UpdateRevStrokeRow(int index, int value)
    {
        if (index > 0)
        {
            DataList[index].UpdateRow(DataList[index].GetFStroke(), value, Step, DataList[index - 1], RevStrokeEnbled);
            UpdateAllRows();
        }
    }
    public void CleanDb()
    {
        UpdateDateTime();
        DataList.Clear(); //= new List<DataRow>();
        _programFactor1 = 0;
        _programFactor2 = 0;
        _verticalDeflection = 0;
        UpdateStepsPerMeter(Step);
        DataList.Add(new DataRow());
        UpdateAllRows();
    }

    public (string Name, object Value)[] GetDBFields()
    {
        return [
            ( "Дата", Date.Date),
            ( "Наименование", Name ),
            ( "Обозначение", Description ),
            ( "Измерения произвел", Fio ),
            ( "Наибольшее отклонение", _maxDeviation ),
            ( "Наименьшее отклонение", _minDeviation ),
            ( "Отклонение от прямолинейности в вертикальной плоскости, мкм", _verticalDeflection ),
            ( "Отклонение от прямолинейности на 1 метр, мкм",  _meterDeflection ),
            ( "Допуск на всю длину измерения, мкм",  FullTolerance ),
            ( "Допуск на 1 метр (или локальный), мкм",  MeterTolerance ),
            ( "Локальный участок, мм",  _localAreaLength ),
            ( "Длина измерения, мм",  _bedAreaLength ),
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
            [ "Наибольшее отклонение", Math.Round(_maxDeviation,2).ToString() ],
            [ "Наименьшее отклонение", Math.Round(_minDeviation, 2).ToString() ],
            [ "Отклонение от прямолинейности в вертикальной плоскости, мкм", Math.Round(_verticalDeflection, 2).ToString() ],
            [ "Отклонение от прямолинейности на 1 метр, мкм",  Math.Round(_meterDeflection, 2).ToString() ],
            [ "Допуск на всю длину измерения, мкм", FullTolerance.ToString() ],
            [ "Допуск на 1 метр (или локальный), мкм", MeterTolerance.ToString() ],
            [ "Локальный участок, мм", _localAreaLength.ToString() ],
            [ "Длина измерения, мм", _bedAreaLength.ToString() ],
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
            pos[i] = decimal.ToDouble(DataList[i].GetLength());
            graph1[i] = decimal.ToDouble(DataList[i].GetFactProfileLength());
            graph2[i] = decimal.ToDouble(DataList[i].GetAdjStraight());
        }

        return new(pos, graph1, graph2);
    }
}