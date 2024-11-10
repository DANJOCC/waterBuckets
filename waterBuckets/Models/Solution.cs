using Microsoft.Extensions.Options;
using System.Collections;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace waterBuckets.Models
{
    #pragma warning disable CS1591
    public class Solution
    {
        private static void getSolution(ref List<Step> stepList, int x_capacity, int y_capacity, int z_gallons)
        {
            /*Step t = new Step(0, 0, 0, "solution");
               t.status = true;
               stepList.Add(t);*/

            List<Step> optionA = new List<Step>();
            List<Step> optionB = new List<Step>();

            bool solutionFound = false;
            int counterA = 0;
            int counterB = 0;
            int bucketAY = 0;
            int bucketBY = y_capacity;


            while (!solutionFound)
            {

                if (counterB == 0)
                {
                    optionA.Add(new Step(++counterA, x_capacity, bucketAY, "Fill bucket X"));
                    optionB.Add(new Step(++counterB, 0, y_capacity, "Fill bucket Y"));

                    if (optionB.Last().bucketY == z_gallons || optionB.Last().bucketX == z_gallons)
                    {
                        optionB.Last().status = "Solved";

                    }
                    if (optionA.Last().bucketY == z_gallons || optionA.Last().bucketX == z_gallons)
                    {
                        optionA.Last().status = "Solved";

                    }

                    if (optionA.Last().status == "Solved" || optionB.Last().status == "Solved")
                    {
                        solutionFound = true;
                        continue;
                    }

                    continue;
                }
                bucketAY += x_capacity;

                optionA.Add(new Step(++counterA, 0, bucketAY, "Transfer from bucket X to bucket Y "));

                bucketBY -= x_capacity;

                optionB.Add((new Step(++counterB, x_capacity, bucketBY, "Transfer from bucket Y to bucket X")));

                if (optionB.Last().bucketY == z_gallons || optionB.Last().bucketX == z_gallons)
                {
                    optionB.Last().status = "Solved";

                }
                if (optionA.Last().bucketY == z_gallons || optionA.Last().bucketX == z_gallons)
                {
                    optionA.Last().status = "Solved";

                }

                if (optionA.Last().status == "Solved" || optionB.Last().status == "Solved")
                {
                    solutionFound = true;
                    continue;
                }

                optionA.Add(new Step(++counterA, x_capacity, bucketAY, "Fill bucket X"));

                optionB.Add((new Step(++counterB, 0, bucketBY, "Empty bucket X")));



            }


            String statusA = optionA.Last().status;
            String statusB = optionB.Last().status;

            if (statusA == "Solved" && statusB == "Solved")
            {
                if (optionA.Count >= optionB.Count)
                {
                    stepList = optionA;
                }
                else
                {
                    stepList = optionB;
                }
            }
            else if (statusA == "Solved")
            {
                stepList = optionA;
            }
            else
            {
                stepList = optionB;
            }
        }
       static public List<Step> generate(int x_capacity, int y_capacity, int z_gallons) {

            List<Step> stepList = new List<Step>();

            if (x_capacity % 2 == 0 && y_capacity % 2 == 0 && z_gallons % 2 != 0)
            {
                stepList.Add(new Step(0, 0, 0, ""));
            }
            else if(x_capacity == 0 || y_capacity == 0)
            {
                getSolution(ref stepList,x_capacity,y_capacity,z_gallons);
            }
            else if (y_capacity < z_gallons)
            {
                stepList.Add(new Step(0, 0, 0, ""));
            }
            else if (z_gallons < x_capacity && z_gallons < y_capacity && y_capacity % x_capacity != z_gallons)
            {
                stepList.Add(new Step(0, 0, 0, ""));
            }
            else if (z_gallons > x_capacity && z_gallons < y_capacity &&
                (z_gallons % x_capacity != 0 && (y_capacity - z_gallons) % x_capacity != 0))
            {
                stepList.Add(new Step(0, 0, 0, ""));
            }
            else
            {
                getSolution(ref stepList, x_capacity, y_capacity, z_gallons);
                 
            }
            return stepList;
        }
    }
}
