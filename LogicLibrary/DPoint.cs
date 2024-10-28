namespace LogicLibrary
{
    public class DPoint
    {
        public int x { get; set; }
        public decimal y { get; set; }

        public DPoint()
        {
            this.x = 0;
            this.y = 0;
        }

        public DPoint(int x, decimal y)
        {
            this.x= x;
            this.y = y;
        }

        public DPoint((int x, decimal y) coords)
        {
            this.x = coords.x;
            this.y = coords.y;
        }

        public (int x, decimal y) GetPoint() => (this.x, this.y);
    }

    
}
