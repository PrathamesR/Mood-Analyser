using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserPackage
{
    public class MoodAnalyser
    {
        string mood;

        public MoodAnalyser(string mood)
        {
            this.mood = mood;
        }

        public string CheckMood()
        {
            try
            {

                if (mood.Contains("sad"))
                    return "The mood is Sad";
                else
                    return "The mood is Happy";
            }
            catch(Exception e)
            {
                return "The mood is Happy";
            }
        }
    }
}
