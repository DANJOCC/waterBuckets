using System;
using System.Collections.Generic;
using System.Text;
namespace ShowElementInList
{
    internal class Solution
    {
        public List<Step> generateSolution(int x_capacity, int y_capacity, int z_gallons)
        {
            List<Step> stepList = new List<Step>();

            if (x_capacity % 2 == 0 && y_capacity % 2 == 0 && z_gallons % 2 != 0)
            {
                stepList.Add(new Step(0, 0, 0, "No Solution"));
            }
            else if (Math.Max(x_capacity, y_capacity) < z_gallons)
            {
                stepList.Add(new Step(0, 0, 0, "No Solution"));
            }
            else if (z_gallons < x_capacity && z_gallons < y_capacity && y_capacity % x_capacity != z_gallons)
            {
                stepList.Add(new Step(0, 0, 0, "No Solution"));
            }
            else if (z_gallons > x_capacity && z_gallons < y_capacity &&
                (z_gallons % x_capacity != 0 && (y_capacity - z_gallons) % x_capacity != 0))
            {
                stepList.Add(new Step(0, 0, 0, "No Solution"));
            }
            else
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
                   
                        continue;
                    }
                    bucketAY += x_capacity;

                    optionA.Add(new Step(++counterA, 0, bucketAY, "Transfer from bucket X to bucket Y "));

                    bucketBY -= x_capacity;

                    optionB.Add((new Step(++counterB, x_capacity, bucketBY, "Transfer from bucket Y to bucket X")));

                    if (optionB.Last().bucketY == z_gallons || optionB.Last().bucketX == z_gallons)
                    {
                        optionB.Last().status = true;

                    }
                    if (optionA.Last().bucketY == z_gallons || optionA.Last().bucketX == z_gallons)
                    {
                        optionA.Last().status = true;

                    }

                    if (optionA.Last().status || optionB.Last().status)
                    {
                        solutionFound = true;
                        continue;
                    }

                    optionA.Add(new Step(++counterA, x_capacity, bucketAY, "Fill bucket X"));

                    optionB.Add((new Step(++counterB, 0, bucketBY, "Empty bucket X")));



                }


                bool statusA = optionA.Last().status;
                bool statusB = optionB.Last().status;

                if (statusA && statusB)
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
                else if (statusA)
                {
                    stepList = optionA;
                }
                else
                {
                    stepList = optionB;
                }

            }
            return stepList;
        }
    }
}
