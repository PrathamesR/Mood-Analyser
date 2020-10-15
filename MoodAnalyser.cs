﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserPackage
{

    class MoodAnalysisException : Exception
    {
        public enum InvalidInput
        {
            Empty = 1,
            Null = 2,
            ClassNotFound=3,
            ConstructorNameDoesntMatch=4
        }

        public MoodAnalysisException(InvalidInput invalidInput) : base(ExceptionMessage(invalidInput))
        {
        }

        private static string ExceptionMessage(InvalidInput invalidInput)
        {
            if (invalidInput == InvalidInput.Null)
                return "No Input Provided";
            else if (invalidInput == InvalidInput.Empty)
                return "Empty Input Provided";
            else if (invalidInput == InvalidInput.ClassNotFound)
                return "Class Not Found";
            else if (invalidInput == InvalidInput.ConstructorNameDoesntMatch)
                return "Constructor Name is different than the class";
            else
                return "Theres an error in my code lol";                //code doesnt reach here
        }

    }

    public class MoodAnalyser
    {
        string mood = null;

        public MoodAnalyser()
        {

        }

        public MoodAnalyser(string mood)
        {
            this.mood = mood;
        }

        public string CheckMood()
        {
            try
            {
                if (mood == null)
                    throw new MoodAnalysisException(MoodAnalysisException.InvalidInput.Null);
                else if (mood.Contains("sad"))
                    return "The mood is Sad";
                else if (mood == "")
                    throw new MoodAnalysisException(MoodAnalysisException.InvalidInput.Empty);
                else
                    return "The mood is Happy";
            }
            catch (MoodAnalysisException e)
            {
                return e.Message;
            }
        }
    }
}
