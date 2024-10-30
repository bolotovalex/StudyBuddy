namespace LogicLibrary
{
    public class AreaDeviation
    {
        public (int startX, int endX) intervalX { get; init; }
        public (decimal startY, decimal endY) intervalY { get; init; }
        public decimal deviation { get; init; }
        public AreaDeviation? prevArea { get; set; }
        public AreaDeviation? nextArea { get; set; }

        public AreaDeviation((int startX, int endX) intervalX, (decimal startY, decimal startX) intervalY, decimal deviation, AreaDeviation? prevArea, AreaDeviation? nextArea)
        {
            this.intervalX = intervalX;
            this.intervalY = intervalY;
            this.deviation = deviation;
            this.prevArea = prevArea;
            this.nextArea = nextArea;
        }

        public AreaDeviation((int startX, int endX) intervalX, (decimal startX, decimal endX) intervalY, decimal deviation) : this(intervalX, intervalY, deviation, null, null) { }
        public AreaDeviation(int startX, int endX, decimal startY, decimal endY ,decimal deviation) : this((startX, endX), (startY, endY), deviation, null, null) { }

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
