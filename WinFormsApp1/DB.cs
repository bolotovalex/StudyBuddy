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
        private string designation; //Обозначение
        private string fio; //Измерения произвел
        private float minDeviation; //Наибольшее отклонение, мкм
        private float maxDeviation; //Наименьшее отклонение, мкм
        private float verticalDeflection; //Отклонение от прямолинейности в вертикальной плоскости, мкм - 
        private float meterDeflection; //Отклонение от прямолинейности на 1 метр, мкм - 
        private int fullTolerance = 0; //Допуск на всю длину, мкм -
        private int meterTolerance = 0; //Допуск на 1 метр, мкм -
        private int localLength = 0; //Локальный участок, мм
        private int bedLength = 0; //Длина станины, мм
        private int measurementStep = 200; //Шаг измерения (расстояние между опорами мостика), мм
        private float programFactor1; //Программный коэффициент
        private float programFactor2; //Программный коэффициент
        private List<DataRow> dataList; //Таблица измерений

        public void SetDate(DateTime date) { this.dateTime = date; }
        public DateTime GetDate() => this.dateTime;
        public void UpdateDateTime() => this.dateTime = DateTime.Now;
        public void SetName(string name) { this.name = name; }
        public string GetName() => this.name;
        public void SetFIO(string fio) { this.fio = fio; }
        public string GetFio() => this.fio;
        public float GetMinDeviation() => this.minDeviation;
        public float GetMaxDeviation() => this.maxDeviation;
        public float GetVerticalDeflection() => this.verticalDeflection;
        public float GetMeterDeflection() => this.meterDeflection;
        public void SetFullTolerance(int fullTolerance) { this.fullTolerance = fullTolerance; }
        public int GetFullTolerance() => this.fullTolerance;
        public void SetMeterTolerance(int meterTolerance) { this.meterTolerance = meterTolerance; }
        public int GetMeterTolerance() => this.meterTolerance;
        public int GetLocalLength() => this.localLength;
        public int GetBedLength() => this.bedLength;
        public void SetMeasurementStep(int measurementStep) { this.measurementStep = measurementStep; }
        public int GetMeasurementStep() => this.measurementStep;
        public float GetProgramFactor1() => this.programFactor1;
        public float GetProgramFactor2() => this.programFactor2;
        public List<DataRow> GetDataList() => this.dataList;
        public DataRow GetDataRow(int index) => this.dataList[index];
        public int GetLength() => this.dataList.Count;

        public DB()
        {
            this.dataList = new List<DataRow>();
            this.dataList.Add(new DataRow());
        }

        public void UpdateProgramFactors()
        {
            this.programFactor1 = this.dataList[this.dataList.Count - 1].GetFactProfileLength() / this.dataList[this.dataList.Count - 1].GetLength();
            this.programFactor2 = 0; //TODO Доделать програмный коэфициент. В примере он всегда будет равен 0
        }

        public void AddRow(float fStroke, float revStroke)
        {
            DataRow row = new DataRow();
            DataRow prevRow = this.dataList[this.dataList.Count - 1];
            row.UpdateRow(fStroke, revStroke, this.measurementStep, prevRow);
            this.dataList.Add(row);
            this.UpdateProgramFactors();
            row.UpdateAdjStraight(this.programFactor1, this.programFactor2);
            row.UpdateDeviation();
            for (var i = 1; i < this.GetLength(); i++)
            {
                prevRow = this.dataList[i - 1];
                var selRow = this.dataList[i];
                selRow.UpdateRow(selRow.GetFStroke(), selRow.GetRevStroke(), this.measurementStep, prevRow);
                selRow.UpdateAdjStraight(this.programFactor1, this.programFactor2);
                selRow.UpdateDeviation();
            }
        }

        public void UpdateAllRows()
        {
            this.UpdateProgramFactors();
            for (var i = 1; i < this.GetLength(); i++)
            {
                var selRow = this.dataList[i];
                var prevRow = this.dataList[i - 1];
                this.dataList[i].UpdateRow(selRow.GetFStroke(), selRow.GetRevStroke(), selRow.GetLength(), prevRow);
                selRow.UpdateAdjStraight(this.programFactor1, this.programFactor2);
                selRow.UpdateDeviation();
            }
        }

        public void UpdateFStrokeRow(int index, int value)
        {
            if (index > 0)
            {
                var row = this.dataList[index];
                var prevRow = this.dataList[index - 1];
                row.UpdateRow(value, prevRow.GetLength() + this.measurementStep, row.GetLength(), prevRow);
                this.UpdateProgramFactors();
                row.UpdateAdjStraight(this.programFactor1, this.programFactor2);
                row.UpdateDeviation();
            }
            
        }
        public void UpdateRevStrokeRow(int index, int value)
        {
            if (index > 0)
            {
                var row = this.dataList[index];
                var prevRow = this.dataList[index - 1];
                row.UpdateRow(row.GetFStroke(), value, prevRow.GetLength() + this.measurementStep, prevRow);
                this.UpdateProgramFactors();
                row.UpdateAdjStraight(this.programFactor1, this.programFactor2);
                row.UpdateDeviation();
            }
        }
    }
}
