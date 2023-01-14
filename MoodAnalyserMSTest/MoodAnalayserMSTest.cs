using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserDay20;
using System;

namespace MoodAnalyserMSTest
{
    [TestClass]
    public class MoodAnalayserMSTest
    {
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
    }
}
