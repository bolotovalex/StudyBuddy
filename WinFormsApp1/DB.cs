namespace Pryamolineynost;

public class Db
{
    public DateTime Date { get; set; } //Дата
    public required string Name { get; set; } //Наименование
    public required string Description { get; set; } //Обозначение
    public required string Fio { get; set; } //Измерения произвел
    private decimal _minDeviation; //Наибольшее отклонение, мкм
    private decimal _maxDeviation; //Наименьшее отклонение, мкм
    private decimal _verticalDeflection; //Отклонение от прямолинейности в вертикальной плоскости, мкм - //TODO Нет индикации выхода за пределы
    private decimal _meterDeflection; //TODO Отклонение от прямолинейности на 1 метр, мкм - //TODO Нет индикации выхода за пределы
    public int FullTolerance { get; set; } //Допуск на всю длину, мкм -
    public int MeterTolerance { get; set; } //Допуск на 1 метр, мкм -
    private int _localAreaLength = 0; //Локальный участок, мм
    private int _bedAreaLength = 0; //Длина станины, мм
    public int Step { get; set; } //Шаг измерения (расстояние между опорами мостика), мм
    private decimal _programFactor1; //Программный коэффициент
    private decimal _programFactor2; //Программный коэффициент
    public List<DataRow> DataList { get; set; } //Таблица измерений
    private int _stepsPerMeter;

    public enum Column
    {
        Position = 0,
        FactProfilePosition = 1,
        AdjStraight = 2,
        Deviation = 3,
        DeviationPerMeter = 4,
        MidValue = 5,
        FStroke = 6,
        RevStroke = 7
    }

    public void SetDate(DateTime date)
    {
        this.Date = date;
    }

    public DateTime GetDate()
    {
        return Date;
    }

    public void UpdateDateTime()
    {
        Date = DateTime.Now;
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public string GetName()
    {
        return Name;
    }

    public void SetFio(string fio)
    {
        Fio = fio;
    }

    public string GetFio()
    {
        return Fio;
    }

    public void SetDescription(string description)
    {
        Description = description;
    }

    public string GetDescription()
    {
        return Description;
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

    public void SetFullTolerance(int fullTolerance)
    {
        FullTolerance = fullTolerance;
    }

    public int GetFullTolerance()
    {
        return FullTolerance;
    }

    public void SetMeterTolerance(int meterTolerance)
    {
        MeterTolerance = meterTolerance;
    }

    public int GetMeterTolerance()
    {
        return MeterTolerance;
    }

    public int GetLocalAreaLength()
    {
        return _localAreaLength;
    }

    public int GetBedLength()
    {
        return _bedAreaLength;
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

    public DataRow GetDataRow(int index)
    {
        return DataList[index];
    }

    public DataRow GetLastDataRow()
    {
        return DataList[^1];
    }


    public Db()
    {
        _maxDeviation = 0;
        DataList = [];
        Date = DateTime.Now;
        Step = 200;
        UpdateStepsPerMeter(Step);
        DataList.Add(new DataRow());
    }

    public Db(DateTime datetime, string name, string description, string fio, int fullTolearance, int meterTolerance,
        int step, List<DataRow> dataList, decimal maxDeviation)
    {
        Date = datetime;
        Name = name;
        Description = description;
        Fio = fio;
        FullTolerance = fullTolearance;
        MeterTolerance = meterTolerance;
        Step = step;
        DataList = dataList;
        _maxDeviation = maxDeviation;
        UpdateStepsPerMeter(Step);
        UpdateAllRows();
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
        row.UpdateRow(fStroke, revStroke, Step, prevRow);
        DataList.Add(row);
        UpdateProgramFactors();
        row.UpdateAdjStraight(_programFactor1, _programFactor2);
        row.UpdateDeviation();
        UpdateAllRows();
    }

    private decimal GetMaxDeviationPerMeterForStep(int maxIndex)
    {
        var startIndex = maxIndex - _stepsPerMeter + 1;
        var lengthOnMeter = new List<decimal>() { };
        for (var length = 0; length <= 1000; length += 1000 / _stepsPerMeter)
            lengthOnMeter.Add(length);


        var factProfileList = new List<decimal>() { 0 };

        for (var i = startIndex; i < DataList.Count && i <= maxIndex; i++)
        {
            var factProfile = DataList[i].GetFStroke() * Step / 1000 + factProfileList[i - startIndex];
            factProfileList.Add(factProfile);
        }


        var lastProfileKoef = factProfileList[^1] / lengthOnMeter[^1];
        var listDeviations = new List<decimal>() { 0 };
        decimal maxDeviation = 0;
        decimal minDeviation = 0;

        for (var i = startIndex; i < DataList.Count && i <= maxIndex; i++)
        {
            var prilPryamaya =
                lastProfileKoef * lengthOnMeter[i - startIndex + 1] +
                0; //TODO в документе указано ссылка на T15, но она пустая.

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

            selRow.UpdateRow(selRow.GetFStroke(), selRow.GetRevStroke(), Step, prevRow);
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
                DataList[index].SetDeviationPerMeter(GetMaxDeviationPerMeterForStep(i));
        }
    }

    public void UpdateBedLenth()
    {
        _bedAreaLength = GetLastDataRow().GetLength();
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

        // TODO Не работает если не посчитаны program factors
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
            DataList[index].UpdateRow(value, DataList[index].GetRevStroke(), Step, DataList[index - 1]);
            UpdateAllRows();
        }
    }

    public void UpdateRevStrokeRow(int index, int value)
    {
        if (index > 0)
        {
            DataList[index].UpdateRow(DataList[index].GetFStroke(), value, Step, DataList[index - 1]);
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

    public (string[][] dbValues, string[][] dataListValues) GetPrintStrings()
    {
        string[][] dbValues = [
            [ "Дата", GetDate().ToString() ],
            [ "Наименование", GetName() ],
            [ "Обозначение", GetDescription() ],
            [ "Измерения произвел",GetFio() ],
            [ "Наибольшее отклонение",Math.Round(GetMaxDeviation(), 2).ToString() ],
            [ "Наименьшее отклонение",Math.Round(GetMinDeviation(), 2).ToString() ],
            [ "Отклонение от прямолинейности в вертикальной плоскости, мкм", Math.Round(GetVerticalDeflection(), 2).ToString() ], //TODO нужно добавить добавление надписи не в допуске
            [ "Отклонение от прямолинейности на 1 метр, мкм",  Math.Round(GetMeterDeflection(), 2).ToString() ], //TODO нужно добавить добавление надписи не в допуске
            [ "Допуск на всю длину, мкм",  GetFullTolerance().ToString() ],
            [ "Допуск на 1 метр (или локальный), мкм",  GetMeterTolerance().ToString() ],
            [ "Локальный участок, мм",  GetLocalAreaLength().ToString() ],
            [ "Длина станины, мм",  GetBedLength().ToString() ],
            [ "Шаг измерения (расстояние между опорами мостика), мм", GetMeasurementStep().ToString() ]];

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
            dataListValues[i + 1] = DataList[i].GetAllCellsStringArray(); //Todo нужно добавить окраску ячейки при нахождении не в допуске
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