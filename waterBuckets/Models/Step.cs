namespace waterBuckets.Models
{
    public class Step
    {
        public int id { get; set; }
        public int bucketX {  get; set; }

        public int bucketY { get; set; }

        public string action { get; set; } = string.Empty;

        public Step(int id, int bucketX, int bucketY, string action)
        {
            this.id = id;
            this.bucketX = bucketX;
            this.bucketY = bucketY;
            this.action = action;
        }
    }
}
