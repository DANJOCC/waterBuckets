// See https://aka.ms/new-console-template for more information


using ShowElementInList;
using System.Text.Json;
using System.Text.Json.Serialization;

List<Step> s = Solution.generate(6, 25, 6);

var options = new JsonSerializerOptions {WriteIndented = true };

String p = JsonSerializer.Serialize(s, options);

Console.WriteLine(p);


foreach(Step step in s)
{
    Console.WriteLine(step.ToString());
}

