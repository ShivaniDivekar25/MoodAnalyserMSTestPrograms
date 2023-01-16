using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserDay20
{
    //Created class
    public class MoodAnalyser
    {
        public string message;
        //Created constructor
        public MoodAnalyser(string message)
        {
            this.message = message;
        }
        public MoodAnalyser()
        {
            Console.WriteLine("Default constructor");
        }
        //Created Analyse mood method
        public string AnalyseMood()
        {
            try
            {
                if (message.ToLower().Contains("happy"))
                {
                    return "happy";
                }
                else if (message.ToLower().Equals(string.Empty))
                {
                    Console.WriteLine(message);
                    throw new CustomMoodAnalyserException("Message should not be empty", CustomMoodAnalyserException.ExceptionTypes.EMPTY_MESSAGE);
                }
                else
                {
                    return "sad";
                }
            }
            catch (NullReferenceException ex)
            {
                throw new CustomMoodAnalyserException("Message should not be empty", CustomMoodAnalyserException.ExceptionTypes.EMPTY_MESSAGE);
            }
        }
    }
}