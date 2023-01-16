using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserDay20
{
    //Refactor class form MoodAnalyser to MoodAnalyserReflector
    public class MoodAnalyserReflector
    {
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
        public string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = typeof(MoodAnalyser);
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                object moodAnalyserObject = factory.CreateMoodAnalyserParameterizedObject("MoodAnalyserDay20.MoodAnalyser", "MoodAnalyser", message);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object info = methodInfo.Invoke(moodAnalyserObject, null);
                return info.ToString();
            }
            catch (CustomMoodAnalyserException ex)
            {
                if (ex.Message.Equals("Class not found"))
                {
                    throw new CustomMoodAnalyserException("Class not found", CustomMoodAnalyserException.ExceptionTypes.CLASS_NOT_FOUND);
                }
                else
                {
                    throw new CustomMoodAnalyserException("Constructor not found", CustomMoodAnalyserException.ExceptionTypes.CONSTRUCTOR_NOT_FOUND);
                }
            }
            catch (Exception ex)
            {
                throw new CustomMoodAnalyserException("Method not found", CustomMoodAnalyserException.ExceptionTypes.NO_SUCH_METHOD);
            }
        }
    }
}
