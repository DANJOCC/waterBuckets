namespace waterBuckets.Models
{
    public class Step
    {
       
        public int step { get; set; }
        public int bucketX {  get; set; }

        public int bucketY { get; set; }

        public string action { get; set; } = string.Empty;

        public bool status { get; set; } = false;
        public Step(int step, int bucketX, int bucketY, string action)
        {
            this.step = step;
            this.bucketX = bucketX;
            this.bucketY = bucketY;
            this.action = action;
        }
    }
}
