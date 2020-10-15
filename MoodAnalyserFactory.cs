using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MoodAnalyserPackage
{
    public class MoodAnalyserFactory
    {
        public static void CheckConstructorNClassName(string className,string constructor)
        {
            if (!Regex.IsMatch(className, constructor))
                throw new MoodAnalysisException(MoodAnalysisException.InvalidInput.ConstructorNameDoesntMatch);
        }

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

        public static string AnalyserMethod(string className, string methodName, string message)
        {
            try
            {
                Assembly executing = Assembly.GetExecutingAssembly();
                Type moodAnalyseType = executing.GetType(className);
                MethodInfo method = moodAnalyseType.GetMethod(methodName);
                MoodAnalyser moodAnalyser = (MoodAnalyser)CreateMoodAnalyser(className, message);
                return method.Invoke(moodAnalyser,null).ToString();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static bool SetMood(string className,string methodName,string message)
        {
            try
            {
                Assembly executing = Assembly.GetExecutingAssembly();
                Type moodAnalyseType = executing.GetType(className);
                PropertyInfo propertyInfo = moodAnalyseType.GetProperty(methodName);
                propertyInfo.SetValue(moodAnalyseType, message);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
