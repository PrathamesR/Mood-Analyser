using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserPackage
{

    class MoodAnalysisException : Exception
    {
        public MoodAnalysisException(string message) : base(message)
        {
        }
    }

    public class MoodAnalyser
    {
        string mood;
        enum InvalidInput
        {
            Empty = 1,
            Null = 2
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
                    throw new MoodAnalysisException("No Input Provided");
                else if (mood.Contains("sad"))
                    return "The mood is Sad";
                else if (mood == "")
                    throw new MoodAnalysisException("Empty Input Provided");
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
