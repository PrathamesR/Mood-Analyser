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

        public static object CreateMoodAnalyser(string className, string message)
        {
            try
            {
                Assembly executing = Assembly.GetExecutingAssembly();
                Type moodAnalyseType = executing.GetType(className);
                ConstructorInfo constructor = moodAnalyseType.GetConstructor(new[] { typeof(string) });
                
                object obj = constructor.Invoke(new object[] { message });
                return obj;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static string AnalyserMethod(string className, string message)
        {
            try
            {
                Assembly executing = Assembly.GetExecutingAssembly();
                Type moodAnalyseType = executing.GetType(className);
                MethodInfo method = moodAnalyseType.GetMethod("CheckMood");
                MoodAnalyser moodAnalyser = (MoodAnalyser)CreateMoodAnalyser(className, message);
                return method.Invoke(moodAnalyser,null).ToString();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
