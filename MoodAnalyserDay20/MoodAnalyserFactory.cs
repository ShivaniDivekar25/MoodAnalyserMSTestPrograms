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
        //Created MoodAnalyser Method for default constructor
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
        //Created Moodanalyser method for parameterized constructor
        public object CreateMoodAnalyserParameterizedObject(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyser);
            try
            {
                if (type.Name.Equals(className) || type.FullName.Equals(className))
                {
                    try
                    {
                        if (type.Name.Equals(constructorName))
                        {
                            ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                            object instance = constructorInfo.Invoke(new object[] { message });
                            return instance;
                        }
                        else
                        {
                            throw new CustomMoodAnalyserException("Constructor is not found", CustomMoodAnalyserException.ExceptionTypes.CONSTRUCTOR_NOT_FOUND);
                        }
                    }
                    catch (NullReferenceException ex)
                    {
                        throw new CustomMoodAnalyserException("Constructor is not found", CustomMoodAnalyserException.ExceptionTypes.CONSTRUCTOR_NOT_FOUND);
                    }
                }
                else
                {
                    throw new CustomMoodAnalyserException("Class is not found", CustomMoodAnalyserException.ExceptionTypes.CLASS_NOT_FOUND);
                }
            }
            catch (CustomMoodAnalyserException ex)
            {
                throw new CustomMoodAnalyserException(ex.Message, ex.exceptionTypes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
