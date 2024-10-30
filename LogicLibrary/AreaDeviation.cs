namespace LogicLibrary
{
    public class AreaDeviation
    {
        public (int x, decimal y) firstCoord { get; init; }
        public (int x, decimal y) secondCoord { get; init; }
        public decimal deviation { get; init; }
        public AreaDeviation? prevArea { get; set; }
        public AreaDeviation? nextArea { get; set; }

        public AreaDeviation((int x, decimal y) firstCoord, (int x, decimal y) secondCoord, decimal deviation, AreaDeviation? prevArea, AreaDeviation? nextArea)
        {
            this.firstCoord = firstCoord;
            this.secondCoord = secondCoord;
            this.deviation = deviation;
            this.prevArea = prevArea;
            this.nextArea = nextArea;
        }
        public AreaDeviation((int x, decimal y) firstCoord, (int x, decimal y) secondCoord, decimal deviation) : this(firstCoord, secondCoord, deviation, null, null) { }
        
        public AreaDeviation(int x1, decimal y1, int x2, decimal y2 ,decimal deviation) : this((x1, y1), (x2, y2), deviation, null, null) { }

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
