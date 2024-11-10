namespace waterBuckets.Models
{
#pragma warning disable CS1591
    public class Step
    {
       
        public int step { get; set; }
        public int bucketX {  get; set; }

        public int bucketY { get; set; }

        public string action { get; set; } = string.Empty;

        public String status { get; set; } = "Unsolved";
        public Step(int step, int bucketX, int bucketY, string action)
        {
            this.step = step;
            this.bucketX = bucketX;
            this.bucketY = bucketY;
            this.action = action;
        }
    }
}
