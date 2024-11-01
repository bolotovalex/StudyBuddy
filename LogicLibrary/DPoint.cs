namespace LogicLibrary
{
    public class DPoint
    {
        public int X { get; init; }
        public double Y { get; init; }
        public DPoint(int x, decimal y)
        {
            this.X = x;
            this.Y = Math.Round(decimal.ToDouble(y),2);
        }

        public DPoint(int x, double y)
        {
            this.X = x;
            this.Y = Math.Round(y,2);
        }
    }

   
}
