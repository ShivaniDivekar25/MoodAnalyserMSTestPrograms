using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserDay20;
using System;

namespace MoodAnalyserMSTest
{
    [TestClass]
    public class MoodAnalayserMSTest
    {
        [TestMethod]
        [DataRow("I am in happy mood","happy")]
        [DataRow("I am in sad mood","sad")]
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
                Assert.AreEqual(expected, ex.Message);
            }
        }
    }
}
