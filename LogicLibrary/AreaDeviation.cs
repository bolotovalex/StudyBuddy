namespace LogicLibrary
{
    public class AreaDeviation
    {
        public (int startX, int endX) interval { get; init; }
        public decimal deviation { get; init; }
        public AreaDeviation? prevArea { get; set; }
        public AreaDeviation? nextArea { get; set; }

        public AreaDeviation((int startX, int endX) interval, decimal deviation, AreaDeviation? prevArea, AreaDeviation? nextArea)
        {
            this.interval = interval;
            this.deviation = deviation;
            this.prevArea = prevArea;
            this.nextArea = nextArea;
        }

        public AreaDeviation(int startX, int endX, decimal deviation, AreaDeviation prevArea, AreaDeviation nextArea) : this((startX, endX), deviation, prevArea, nextArea) { }
        public AreaDeviation((int startX, int endX) interval, decimal deviation) : this(interval, deviation, null, null) { }
        public AreaDeviation(int startX, int endX, decimal deviation) : this((startX, endX), deviation, null, null) { }
        public AreaDeviation(int startX, int endX, decimal deviation, AreaDeviation prevArea) : this((startX, endX), deviation, prevArea, null) { }

        public bool MoreThen(decimal value)
        {
            return value < deviation;
        }

        public bool MoreThen(AreaDeviation areaDeviation) 
        {
            return areaDeviation.deviation < deviation;
        }
    }
}
