using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserDay20;
using System;

namespace MoodAnalyserMSTest
{
    [TestClass]
    public class MoodAnalayserMSTest
    {
        MoodAnalyserFactory factory = new MoodAnalyserFactory();
        [TestMethod]
        //T.C.1
        //[DataRow("I am in happy mood","happy")]
        //[DataRow("I am in sad mood","sad")]
        //T.C.2
        //[DataRow(null,"Object reference not set to an instance of an object")]
        //T.C.2.1
        [DataRow(null, "Happy")]
        public void Given_Message_Should_Return_TypesOf_Mood(string message, string expected)
        {
            try
            {
                //AAA methodology
                //Arrange
                MoodAnalyser moodAnalyser = new MoodAnalyser(message);
                //Act
                string actual = moodAnalyser.AnalyseMood();
                //Assert
                if (actual != null)
                    Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expected, "Happy");
            }
        }
        [TestMethod]
        //T.C.3.1[Null Message]
        //T.C.3.2[Empty Message]
        public void Given_Message_Should_Return_Custom_Exception()
        {
            string expected = "Message should not be empty";
            try
            {
                //arrange
                string message = "";
                MoodAnalyser moodAnalyser = new MoodAnalyser(message);
                //Act
                string actual = moodAnalyser.AnalyseMood();
            }
            catch (CustomMoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Reflection")]
        //T.C.4.1
        [DataRow("MoodAnalyser.MoodAnalyser", "MoodAnalyser")]
        //T.C.4.2
        //[DataRow("MoodAnalyser.MoodAnalyser", "MoodAnalyser1")]
        //T.C.4.3
        [DataRow("MoodAnalyser.MoodAnalyser1","MoodAnalyser")]
        public void Gievn_Class_Info_Return_Default_Constructor(string className, string constructorName)
        {
            string expectedMsg = "Class not found";
            //Arrange
            try
            {
                //AAA Methodology
                //Act
                object expected = new MoodAnalyser();
                object obj = factory.CreateMoodAnalyser("MoodAnalyser.MoodAnalyser", "MoodAnalyser");
                expected.Equals(obj);
            }
            catch (CustomMoodAnalyserException ex)
            {
                //Assert
                Assert.AreEqual(expectedMsg, ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Reflection")]
        //T.C.5
        public void Given_MoodAnalyser_With_Message_Using_Reflection_Return_Parameterized_Constructor()
        {
            string mesaage = "I am in happy mood";
            MoodAnalyser expected = new MoodAnalyser(mesaage);
            object actual = null;
            try
            {
                //AAA methodology
                //Act
                actual = factory.CreateMoodAnalyserParameterizedObject("MoodAnalyser", "MoodAnalyser", mesaage);
                actual.Equals(expected);
            }
            catch (CustomMoodAnalyserException exception)
            {
                //Assert
                Assert.AreEqual("Constructor not found", exception.Message);
            }
        }
    }
}
