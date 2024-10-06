using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pryamolineynost
{
    public class DB
    {
        private DateTime dateTime = DateTime.Now; //Дата
        private string name; //Наименование
        private string description; //Обозначение
        private string fio; //Измерения произвел
        private decimal minDeviation; //Наибольшее отклонение, мкм
        private decimal maxDeviation; //Наименьшее отклонение, мкм
        private decimal verticalDeflection; //Отклонение от прямолинейности в вертикальной плоскости, мкм - 

        private decimal meterDeflection; //TODO Отклонение от прямолинейности на 1 метр, мкм - 
        
        private decimal maxMeterDeflection; //TODO Доделать
        private decimal minMeterDeflection; //TODO Доделать

        private int fullTolerance = 0; //Допуск на всю длину, мкм -
        private int meterTolerance = 0; //Допуск на 1 метр, мкм -
        private int localAreaLength = 0; //Локальный участок, мм
        private int bedAreaLength = 0; //Длина станины, мм
        private int measurementStep = 200; //Шаг измерения (расстояние между опорами мостика), мм
        private decimal programFactor1; //Программный коэффициент
        private decimal programFactor2; //Программный коэффициент
        private List<DataRow> dataList; //Таблица измерений
        private int stepsPerMeter;
        public bool dbChanged { get; set; }
        public void SetDate(DateTime date) { this.dateTime = date; }
        public DateTime GetDate() => this.dateTime;
        public void UpdateDateTime() => this.dateTime = DateTime.Now;
        public void SetName(string name) { this.name = name; }
        public string GetName() => this.name;
        public void SetFIO(string fio) { this.fio = fio; }
        public string GetFio() => this.fio;
        public void SetDescription(string description) { this.description = description; }
        public string GetDescription() => this.description;

        public decimal GetMinDeviation() => this.minDeviation;
        public decimal GetMaxDeviation() => this.maxDeviation;
        public decimal GetVerticalDeflection() => this.verticalDeflection;
        public decimal GetMeterDeflection() => this.meterDeflection;
        public void SetFullTolerance(int fullTolerance) { this.fullTolerance = fullTolerance; }
        public int GetFullTolerance() => this.fullTolerance;
        public void SetMeterTolerance(int meterTolerance) { this.meterTolerance = meterTolerance; }
        public int GetMeterTolerance() => this.meterTolerance;
        public int GetLocalAreaLength() => this.localAreaLength;
        public int GetBedLength() => this.bedAreaLength;
        public void SetMeasurementStep(int measurementStep) { this.measurementStep = measurementStep; }
        public int GetMeasurementStep() => this.measurementStep;
        public List<DataRow> GetDataList() => this.dataList;
        public DataRow GetDataRow(int index) => this.dataList[index];

        public DataRow GetLastDataRow() => this.dataList[this.dataList.Count - 1];

      

        public DB()
        {
            this.dataList = new List<DataRow>();
            this.UpdateStepsPerMeter(this.measurementStep);
            this.dataList.Add(new DataRow());
            this.UpdateStepsPerMeter(200);
        }

        public void UpdateStepsPerMeter(int stepsLength)
        {
            if (stepsLength != null && stepsLength != 0)
            {
                this.stepsPerMeter = 1000 % stepsLength >= 5 ? 1000 / stepsLength + 1 : 1000 / stepsLength;
                this.localAreaLength = 1000 / stepsLength * stepsLength;
            }        
        }


        public void UpdateProgramFactors()
        {
            if (this.dataList[this.dataList.Count - 1].GetLength() != 0)
            {
                this.programFactor1 = this.dataList[this.dataList.Count - 1].GetFactProfileLength() / this.dataList[this.dataList.Count - 1].GetLength();
                this.programFactor2 = 0; //TODO Доделать програмный коэфициент. В примере он всегда будет равен 0
            }
            
        }

        public void AddRow(decimal fStroke, decimal revStroke)
        {
            DataRow row = new DataRow();
            DataRow prevRow = this.dataList[this.dataList.Count - 1];
            row.UpdateRow(fStroke, revStroke, this.measurementStep, prevRow);
            this.dataList.Add(row);
            this.UpdateProgramFactors();
            row.UpdateAdjStraight(this.programFactor1, this.programFactor2);
            row.UpdateDeviation();
            this.UpdateAllRows();
        }

        public decimal GetMaxDeviationPerMeterForStep(int maxIndex)
        {
            //var maxIndex = startStep + this.stepsPerMeter - 1;
            //if (this.dataList.Count <= this.stepsPerMeter || maxIndex >= this.dataList.Count)
            //    return 0;
            var startIndex = maxIndex - this.stepsPerMeter + 1;
            var lengthOnMeter = new List<decimal>() {};
            for ( var length = 0; length <= 1000; length += 1000 / this.stepsPerMeter)
                lengthOnMeter.Add(length);


            var factProfileList = new List<decimal>() {0};

            for (var i = startIndex;  i < this.dataList.Count && i <= maxIndex; i++)
            {
                var factProfile = this.dataList[i].GetFStroke() * this.measurementStep / 1000 + factProfileList[i - startIndex];
                factProfileList.Add(factProfile);
            }


            var a = factProfileList[factProfileList.Count - 1];
            var b = this.dataList[maxIndex].GetLength();
            var lastProfileKoef = factProfileList[factProfileList.Count - 1] / lengthOnMeter[lengthOnMeter.Count - 1];
            var listDeviations = new List<decimal>() { 0 };
            decimal maxDeviation = 0;
            decimal minDeviation = 0;

            for(var i = startIndex; i < this.dataList.Count && i <= maxIndex; i++)
            {
                var prilPryamaya = lastProfileKoef * lengthOnMeter[i - startIndex + 1] + 0;//TODO в документе указано ссылка на T15, но она пустая.
                
                var deviation = factProfileList[i - startIndex + 1] - prilPryamaya;
                listDeviations.Add(deviation);
                if (maxDeviation < deviation)
                    maxDeviation = deviation;
                else if (minDeviation > deviation)
                    minDeviation = deviation;
            }
            return maxDeviation-minDeviation;
        }

        public void UpdateMeterDeflection()
        {
            decimal maxDeflection = 0;
            decimal minDeflection = 0;
            for (var i = 1; i <= this.dataList.Count - this.stepsPerMeter; i++)
            {
                var rowDeviationPerMeter = this.dataList[i].GetDeviationPerMeter();
                if (rowDeviationPerMeter > maxDeflection)
                    maxDeflection = rowDeviationPerMeter;
                else if ( rowDeviationPerMeter < minDeflection)
                    minDeflection = rowDeviationPerMeter;
            }
            this.meterDeflection = Math.Max(maxDeflection, -1 * minDeflection);
        }

        public void UpdateAllRows()
        {
            this.UpdateProgramFactors();
            this.maxDeviation = 0;
            this.minDeviation = 0;

            for (var i = 1; i < this.dataList.Count; i++)
            {
                var selRow = this.dataList[i];
                var prevRow = this.dataList[i - 1];

                selRow.UpdateRow(selRow.GetFStroke(), selRow.GetRevStroke(), this.measurementStep, prevRow);
                selRow.UpdateAdjStraight(this.programFactor1, this.programFactor2);
                selRow.UpdateDeviation();

                var deviationValue = selRow.GetDeviation();
                if (deviationValue > this.maxDeviation)
                    this.maxDeviation = deviationValue;
                else if (deviationValue < this.minDeviation)
                    this.minDeviation = deviationValue;
                this.verticalDeflection = (this.GetMaxDeviation() + (this.GetMinDeviation() * (-1)));

                if (this.dataList.Count - i == 1 && this.dataList.Count > this.stepsPerMeter)
                {
                    this.dataList[i - this.stepsPerMeter + 1].SetDeviationPerMeter(GetMaxDeviationPerMeterForStep(i));
                }
            }
            
            UpdateMeterDeflection();
            
        }

        public void UpdateFStrokeRow(int index, int value)
        {
            if (index > 0)
            {
                this.dataList[index].UpdateRow(value, this.dataList[index].GetRevStroke(), this.measurementStep, this.dataList[index - 1]);
                UpdateAllRows();
            }
            
        }
        public void UpdateRevStrokeRow(int index, int value)
        {
            if (index > 0)
            {
                this.dataList[index].UpdateRow(this.dataList[index].GetFStroke(), value, this.measurementStep, this.dataList[index - 1]);
                UpdateAllRows();
            }
        }

        public void CleanDB()
        {
            this.UpdateDateTime();
            this.dataList = new List<DataRow>();
            this.programFactor1 = 0;
            this.programFactor2 = 0;
            this.verticalDeflection = 0;
            this.UpdateStepsPerMeter(this.measurementStep);
            this.dataList.Add(new DataRow());
            UpdateAllRows();
            
        }
    }
}
