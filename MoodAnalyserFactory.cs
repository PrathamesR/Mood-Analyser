using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MoodAnalyserPackage
{
    public class MoodAnalyserFactory
    {

        /// <summary>
        /// Checks the name of the constructor with class' name.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constructor">The constructor.</param>
        /// <exception cref="MoodAnalysisException"></exception>
        public static void CheckConstructorNClassName(string className, string constructor)
        {
            if (!Regex.IsMatch(className, @"." + constructor + "$"))
                throw new MoodAnalysisException(MoodAnalysisException.InvalidInput.ConstructorNameDoesntMatch);
        }


        /// <summary>
        /// Creates the MoodAnalyser object with default contructor.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constructor">The constructor.</param>
        /// <returns></returns>
        public static object CreateMoodAnalyser(string className, string constructor)
        {

            try
            {
                Assembly executing = Assembly.GetExecutingAssembly();
                Type moodAnalyseType = executing.GetType(className);
                CheckConstructorNClassName(className, constructor);
                return Activator.CreateInstance(moodAnalyseType);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Creates the MoodAnalyser object with parameterised contructor.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="message">The message.</param>
        /// <param name="constr">The constructor.</param>
        /// <returns></returns>
        public static object CreateMoodAnalyser(string className, string message, string constr)
        {
            try
            {
                Assembly executing = Assembly.GetExecutingAssembly();
                Type moodAnalyseType = executing.GetType(className);

                ConstructorInfo constructor = moodAnalyseType.GetConstructor(new[] { typeof(string) });

                CheckConstructorNClassName(className, constr);

                object obj = constructor.Invoke(new object[] { message });
                return obj;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Executes method in class.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="message">The message.</param>
        /// <param name="constuctor">The constuctor.</param>
        /// <returns></returns>
        public static string AnalyserMethod(string className, string methodName, string message, string constuctor)
        {
            try
            {
                Assembly executing = Assembly.GetExecutingAssembly();
                Type moodAnalyseType = executing.GetType(className);
                MethodInfo method = moodAnalyseType.GetMethod(methodName);
                MoodAnalyser moodAnalyser = (MoodAnalyser)CreateMoodAnalyser(className, message, constuctor);
                return method.Invoke(moodAnalyser, null).ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Sets the field.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalysisException">
        /// </exception>
        public static string SetMood(string propertyName, string message)
        {

            if (message == null)
                throw new MoodAnalysisException(MoodAnalysisException.InvalidInput.NullMessage);

            MoodAnalyser moodAnalyseType = new MoodAnalyser();
            Type type = typeof(MoodAnalyser);
            FieldInfo fieldInfo = type.GetField(propertyName);

            if (fieldInfo == null)
                throw new MoodAnalysisException(MoodAnalysisException.InvalidInput.NoSuchField);

            fieldInfo.SetValue(moodAnalyseType, message);
            MethodInfo method = type.GetMethod("CheckMood");
            return method.Invoke(moodAnalyseType, null).ToString();
        }
    }
}
