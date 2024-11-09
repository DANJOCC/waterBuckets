using System.Collections;
using System.Numerics;

namespace waterBuckets.Models
{
    public class Solution
    {
        public int NumberSteps { get; set; } = 0;
        public List<Step> generateSolution(int x_capacity, int y_capacity, int z_gallons) {
            List<Step> stepList = new List<Step>();

            if (x_capacity % 2 == 0 && y_capacity % 2 == 0 && z_gallons % 2 != 0)
            {
                stepList.Add(new Step(0, 0, 0, "No Solution"));
            }
            else if(Math.Max(x_capacity, y_capacity) < z_gallons)
            {
                stepList.Add(new Step(0, 0, 0, "No Solution"));
            }
            else if(z_gallons < x_capacity && z_gallons < y_capacity && y_capacity % x_capacity != z_gallons)
            {
                stepList.Add(new Step(0, 0, 0, "No Solution"));
            }
            else if(z_gallons > x_capacity && z_gallons < y_capacity &&
                (z_gallons % x_capacity != 0 && (y_capacity - z_gallons) % x_capacity != 0))
            {
                stepList.Add(new Step(0, 0, 0, "No Solution"));
            }
            else
            {
                stepList.Add(new Step(0, 0, 0, "Solution"));
            }
            return stepList;
        }
    }
}
