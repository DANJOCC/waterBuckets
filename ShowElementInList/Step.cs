using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowElementInList
{
    internal class Step
    {

        public int id { get; set; }
        public int bucketX { get; set; }

        public int bucketY { get; set; }

        public string action { get; set; } = string.Empty;

        public bool status { get; set; } = false;
        public Step(int id, int bucketX, int bucketY, string action)
        {
            this.id = id;
            this.bucketX = bucketX;
            this.bucketY = bucketY;
            this.action = action;
        }

        public override string ToString()
        {
            return $"id:{id},bucketX:{bucketX},bucketY:{bucketY},action:{action},status:{status}";
        }
    }
}
