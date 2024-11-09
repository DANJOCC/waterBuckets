// See https://aka.ms/new-console-template for more information


using ShowElementInList;

List<Step> s = new Solution().generateSolution(6, 25, 6);


foreach(Step step in s)
{
    Console.WriteLine(step.ToString());
}

