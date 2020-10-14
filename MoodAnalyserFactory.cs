using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace MoodAnalyserPackage
{
    public class MoodAnalyserFactory
    {
        public static  object CreateMoodAnalyser(string className)
        {
            try
            {
                Assembly executing = Assembly.GetExecutingAssembly();
                Type moodAnalyseType = executing.GetType(className);
                return Activator.CreateInstance(moodAnalyseType);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
