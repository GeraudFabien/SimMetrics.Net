using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit;
using SimMetrics.Net.Metric;

namespace SimMetrics.Net.Tests.SimilarityClasses.EditDistance
{
    // [TestFixture]
    public sealed class LevensteinUnitTests
    {
        #region Test Data Setup
        struct TestRecord
        {
            public string nameOne;
            public string nameTwo;
            public double levensteinMatchLevel;
        }

        Settings addressSettings = Settings.Default;
        List<TestRecord> testNames = new List<TestRecord>(26);

        void AddNames(string addChars)
        {
            if (addChars != null)
            {
                string[] letters = addChars.Split(',');
                TestRecord testName;
                testName.nameOne = letters[0];
                testName.nameTwo = letters[1];
                testName.levensteinMatchLevel = Convert.ToDouble(letters[10], CultureInfo.InvariantCulture);
                testNames.Add(testName);
            }
        }

        void LoadData()
        {
            AddNames(addressSettings.blockDistance1);
            AddNames(addressSettings.blockDistance2);
            AddNames(addressSettings.blockDistance3);
            AddNames(addressSettings.jaroName1);
            AddNames(addressSettings.jaroName2);
            AddNames(addressSettings.jaroName3);
            AddNames(addressSettings.jaroName4);
            AddNames(addressSettings.jaroName5);
            AddNames(addressSettings.jaroName6);
            AddNames(addressSettings.jaroName7);
        }
        #endregion

        #region Levenstein Tests
        [Fact]
        // [Category("Levenstein Test")]
        public void Levenstein_ShortDescription()
        {
            AssertUtil.Equal("Levenstein", myLevenstein.ShortDescriptionString, "Problem with Levenstein test short description.");
        }

        [Fact]
        // [Category("Levenstein Test")]
        public void Levenstein_TestData()
        {
            foreach (TestRecord testRecord in testNames)
            {
                AssertUtil.Equal(testRecord.levensteinMatchLevel.ToString("F3"),
                                myLevenstein.GetSimilarity(testRecord.nameOne, testRecord.nameTwo).ToString("F3"),
                                "Problem with Levenstein test - " + testRecord.nameOne + ' ' + testRecord.nameTwo);
            }
        }
        #endregion

        Levenstein myLevenstein;

        // [SetUp]
        public LevensteinUnitTests()
        {
            LoadData();
            myLevenstein = new Levenstein();
        }
    }
}