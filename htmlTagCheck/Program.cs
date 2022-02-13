using htmlTagCheck;
using System.Text.RegularExpressions;

Console.WriteLine("Input your line below");
string textRead = Console.ReadLine();
string result = Checker.TagChecker(textRead);
Console.WriteLine(result);
Console.Read();

