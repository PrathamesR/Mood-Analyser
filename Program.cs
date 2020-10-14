using System;

namespace MoodAnalyserPackage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MoodAnalyser obj  = (MoodAnalyser)MoodAnalyserFactory.CreateMoodAnalyser("MoodAnalyserPackage.MoodAnalyser");
        }
    }
}
