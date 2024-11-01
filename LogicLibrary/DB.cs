using System.Drawing;
namespace LogicLibrary;

public class DB
{
    public DateTime Date { get; set; } //Дата
    public required string Name { get; set; } //Наименование
    public required string Description { get; set; } //Обозначение
    public required string Fio { get; set; } //Измерения произвел
    private decimal _minDeviation { get; set; } //Наибольшее отклонение, мкм
    private decimal _maxDeviation { get; set; } //Наименьшее отклонение, мкм
    private decimal _verticalDeflection { get; set; } //Отклонение от прямолинейности в вертикальной плоскости, мкм - 
    private decimal _meterDeflection { get; set; } //Отклонение от прямолинейности на 1 метр, мкм -
    public int FullTolerance { get; set; } //Допуск на всю длину, мкм -
    public int MeterTolerance { get; set; } //Допуск на 1 метр, мкм -
    public int LocalAreaLength { get; set; } //Локальный участок, мм
    private int _bedAreaLength { get; set; } //Длина станины, мм
    public int Step { get; set; } //Шаг измерения (расстояние между опорами мостика), мм
    private decimal _programFactor1; //Программный коэффициент
    private decimal _programFactor2; //Программный коэффициент
    public List<DataRow> DataList { get; set; } //Таблица измерений
    private int _stepsPerMeter { get; set; }
    public bool RevStrokeEnbled = false;
    public DPoint[] CurvePoints { get; set; }
    public DPoint[] StraightPoints { get; set; }

    public AreaDeviation[] maxLocalAreaDeviations { get; set; }

    public DB(List<DataRow> dataList, int step)
    {
        foreach(var row in dataList)
        {
            this.AddRow(row.FStroke, row.RevStroke);
        }
    }

    public DB()
    {
        _maxDeviation = 0;
        DataList = [];
        Date = DateTime.Now.Date;
        Step = 200;
        UpdateStepsPerMeter(Step);
        DataList.Add(new DataRow(0,0,0,null,RevStrokeEnbled));
        LocalAreaLength = 1000;
    }

    public void SetVerticalDeflection(decimal deflection)
    {
        _verticalDeflection = deflection;
    }

    public decimal GetVerticalDeflection() => _verticalDeflection;
    public decimal GetMinDeviation() => _minDeviation;
    public  decimal GetMaxDeviation() => _maxDeviation;
    public decimal GetMeterDeflection() => _meterDeflection;
    public int GetBedAreaLength() => _bedAreaLength;
    

    public void UpdateStepsPerMeter(int stepsLength)
    {
        if (stepsLength != 0)
        {
            _stepsPerMeter = 1000 % stepsLength >= 5 ? 1000 / stepsLength + 1 : 1000 / stepsLength;
            //LocalAreaLength = 1000 / stepsLength * stepsLength;
        }
    }

    private void UpdateProgramFactors()
    {
        if (DataList[^1].GetPosition() != 0)
        {
            _programFactor1 = DataList[^1].GetFactProfile() /
                              DataList[^1].GetPosition();
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
            var rowDeviationPerMeter = DataList[i].GetDevationPerMeter();
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
    
    private decimal GetY(int x1, decimal y1, int x2, decimal y2, int x3)
    {
        return Math.Round((x3 * y2 - x3 * y1 - x1 * y2 + x2 * y1) / (x2 - x1), 2);
    }

    private decimal GetYBetweenStepIndex(int index, int coord)
    {
        
        return GetY(x1: DataList[index - 1].GetPosition(),
                    y1: DataList[index - 1].GetFactProfile(),
                    x2: DataList[index].GetPosition(),
                    y2: DataList[index].GetFactProfile(),
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

        startY = DataList[interval.startIndex].GetPosition() > startX 
            ? GetYBetweenStepIndex(interval.startIndex, startX) 
            : DataList[interval.startIndex++].GetFactProfile();
        endY = DataList[interval.endIndex].GetPosition() > endX
            ? GetYBetweenStepIndex(interval.endIndex, endX)
            : DataList[interval.endIndex].GetFactProfile();

        adjStraightStepList.Add((startX, startY));

        for (var i = interval.startIndex; i < interval.endIndex; i++)
        {
            var x = DataList[i].GetPosition();
            var y = GetY(startX, startY, endX, endY, DataList[i].GetPosition());
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
            var value = DataList[startInteval + i - 1].GetFactProfile() - LocalAreaStraight[i].y;
            if (value < minDeviation)
                minDeviation = value;
            else if (value > maxDeviation)
                maxDeviation = value;
        }
            
        return (LocalAreaStraight[0].x, LocalAreaStraight[^1].x, maxDeviation - minDeviation);
    }

    public AreaDeviation[] GetMaxLocalAreaDeviation(int count = 10, decimal tolerance = 0)
    {
        var deviationList = new SortedQueueDeviation();
        for (var i = 0; i + LocalAreaLength <= _bedAreaLength; i += 50)
        {
            var areaDeviation = GetAreaDeviation(i);
            deviationList.AddArea(areaDeviation);
        }

        var maxDeviationAreaArr = deviationList.GetBigestElements(10);
        return maxDeviationAreaArr;
    }

    public (int startIndex, int endIndex) GetIntervalIndex(int startPos, int endPos)
    {
        var startIndexIsFind = false;
        var endIndexIsFind = false;
        var startIndex = 0;
        var endIndex = DataList.Count - 1;
        for (var i = 0; i < DataList.Count; i++)
        {
            if (!startIndexIsFind && DataList[i].GetPosition() >= startPos)
            {
                startIndex = i;
                startIndexIsFind = true;
                continue;
            }

            if (!endIndexIsFind &&  DataList[i].GetPosition() >= endPos)
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
        _bedAreaLength = DataList[^1].GetPosition();
        maxLocalAreaDeviations = GetMaxLocalAreaDeviation(10);
        UpdatePoints();
        
        
        //CalculateLocalAreaStepCount();
        //TODO Не работает если не посчитаны program factors
        //UpdateProgramFactors();
        //_maxDeviation = 0;
        //_minDeviation = 0;

        //for (var i = 1; i < DataList.Count; i++)
        //{
        //    var selRow = DataList[i];
        //    var prevRow = DataList[i - 1];

        //    selRow.UpdateRow(selRow.FStroke, selRow.RevStroke, Step, prevRow);
        //selRow.UpdateAdjStraight(_programFactor1, _programFactor2);
        //selRow.CalculateDeviation();

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
        _verticalDeflection = 0;
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
            ( "Наибольшее отклонение", _maxDeviation ),
            ( "Наименьшее отклонение", _minDeviation ),
            ( "Отклонение от прямолинейности в вертикальной плоскости, мкм",_verticalDeflection ),
            ( "Отклонение от прямолинейности на 1 метр, мкм",  _meterDeflection ),
            ( "Допуск на всю длину измерения, мкм",  FullTolerance ),
            ( "Допуск на 1 метр (или локальный), мкм",  MeterTolerance ),
            ( "Локальный участок, мм",  LocalAreaLength ),
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
            [ "Локальный участок, мм", LocalAreaLength.ToString() ],
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
            pos[i] = decimal.ToDouble(DataList[i].GetPosition());
            graph1[i] = decimal.ToDouble(DataList[i].GetFactProfile());
            graph2[i] = decimal.ToDouble(DataList[i].GetAdjStraight());
        }

        return new(pos, graph1, graph2);
    }
    public void UpdatePoints()
    {
        CurvePoints = new DPoint[DataList.Count];
        StraightPoints = new DPoint[DataList.Count];
        for (var i = 0; i < DataList.Count; ++i)
        {
            CurvePoints[i] = new DPoint(DataList[i].GetPosition(), DataList[i].GetFactProfile());
            StraightPoints[i] = new DPoint(DataList[i].GetPosition(), DataList[i].GetAdjStraight());
        }
    }
}