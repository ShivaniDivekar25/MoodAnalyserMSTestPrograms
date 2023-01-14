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
        //Created Analyse mood method
        public string AnalyseMood()
        {
            try
            {
                if (message.ToLower().Contains("happy"))
                {
                    return "happy";
                }
                else
                {
                    return "sad";
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Happy");
                return default;
            }
        }
    }
}