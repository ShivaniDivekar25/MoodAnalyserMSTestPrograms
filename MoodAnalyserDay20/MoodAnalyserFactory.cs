using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyserDay20
{
    //Created class
    public class MoodAnalyserFactory
    {
        public object CreateMoodAnalyser(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            bool result = Regex.IsMatch(className, pattern);
            if (result)
            {
                try
                {
                    Assembly excuting = Assembly.GetExecutingAssembly();
                    Type moodAnalayseType = excuting.GetType(className);
                    return Activator.CreateInstance(moodAnalayseType);
                }
                catch (ArgumentNullException ex)
                {
                    throw new CustomMoodAnalyserException("Class not found", CustomMoodAnalyserException.ExceptionTypes.CLASS_NOT_FOUND);
                }
            }
            else 
            {
                throw new CustomMoodAnalyserException("Constructor not found", CustomMoodAnalyserException.ExceptionTypes.NO_SUCH_METHOD);
            }
        }
    }
}
