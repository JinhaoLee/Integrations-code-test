using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace UnitTest {
    [TestClass]
    public class UnitTest {

        private static Integration.AthletesDTO athleles;
        private static string savePath, loadPath;
        private const string testCSVFilename = "athletes.csv";

        [ClassInitialize()]
        public static void SetUp(TestContext testContext) {
            // get the path of test files
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            loadPath = System.IO.Path.Combine(directory, testCSVFilename);
            savePath = System.IO.Path.Combine(directory, "athlete.json");

            // get athletes data
            athleles = Integration.Program.LoadCsvFile(loadPath);
        }

        [TestMethod]
        public void TestNumberOfRows() {
            Assert.AreEqual(typeof(List<Integration.AthleleDTO>), athleles.rows.GetType());
            Assert.AreEqual(2, athleles.rows.Count);
        }

        [TestMethod]
        public void TestFirstRow() {
            var firstRow = athleles.rows[0];

            // test the key/value pairs
            Assert.AreEqual(0, firstRow.row);
            Assert.AreEqual(7, firstRow.pairs.Count);

            Assert.AreEqual("firstName", firstRow.pairs[0].key);
            Assert.AreEqual("Bob", firstRow.pairs[0].value);

            Assert.AreEqual("lastName", firstRow.pairs[1].key);
            Assert.AreEqual("Smith", firstRow.pairs[1].value);

            Assert.AreEqual("middleName", firstRow.pairs[2].key);
            Assert.AreEqual("John", firstRow.pairs[2].value);

            Assert.AreEqual("dateOfBirth", firstRow.pairs[3].key);
            Assert.AreEqual("30/08/1990", firstRow.pairs[3].value);

            Assert.AreEqual("sex", firstRow.pairs[4].key);
            Assert.AreEqual("M", firstRow.pairs[4].value);


            Assert.AreEqual("height", firstRow.pairs[5].key);
            Assert.AreEqual("1.83", firstRow.pairs[5].value);

            Assert.AreEqual("sport", firstRow.pairs[6].key);
            Assert.AreEqual("basketball", firstRow.pairs[6].value);
        }

        [TestMethod]
        public void TestSecondRow() {
            var secondRow = athleles.rows[1];

            // test the key/value pairs
            Assert.AreEqual(1, secondRow.row);
            Assert.AreEqual(7, secondRow.pairs.Count);

            Assert.AreEqual("firstName", secondRow.pairs[0].key);
            Assert.AreEqual("Sam", secondRow.pairs[0].value);

            Assert.AreEqual("lastName", secondRow.pairs[1].key);
            Assert.AreEqual("Peters", secondRow.pairs[1].value);

            Assert.AreEqual("middleName", secondRow.pairs[2].key);
            Assert.AreEqual("", secondRow.pairs[2].value);

            Assert.AreEqual("dateOfBirth", secondRow.pairs[3].key);
            Assert.AreEqual("21/6/2000", secondRow.pairs[3].value);

            Assert.AreEqual("sex", secondRow.pairs[4].key);
            Assert.AreEqual("F", secondRow.pairs[4].value);


            Assert.AreEqual("height", secondRow.pairs[5].key);
            Assert.AreEqual("1.79", secondRow.pairs[5].value);

            Assert.AreEqual("sport", secondRow.pairs[6].key);
            Assert.AreEqual("rowing", secondRow.pairs[6].value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThirdRow() { 
            Assert.IsNull(athleles.rows[2]);
        }

        [TestMethod]
        public void TestSaveJsonFile() {
            string json = Integration.Program.SaveJsonFile(savePath, athleles);
            Integration.AthletesDTO athletesDto = JsonConvert.DeserializeObject<Integration.AthletesDTO>(json);

            Assert.AreEqual(2, athletesDto.rows.Count);

            var firstRow = athletesDto.rows[0];

            // test the key/value pairs
            Assert.AreEqual(0, firstRow.row);
            Assert.AreEqual(7, firstRow.pairs.Count);

            Assert.AreEqual("firstName", firstRow.pairs[0].key);
            Assert.AreEqual("Bob", firstRow.pairs[0].value);

            Assert.AreEqual("lastName", firstRow.pairs[1].key);
            Assert.AreEqual("Smith", firstRow.pairs[1].value);

            Assert.AreEqual("middleName", firstRow.pairs[2].key);
            Assert.AreEqual("John", firstRow.pairs[2].value);

            Assert.AreEqual("dateOfBirth", firstRow.pairs[3].key);
            Assert.AreEqual("30/08/1990", firstRow.pairs[3].value);

            Assert.AreEqual("sex", firstRow.pairs[4].key);
            Assert.AreEqual("M", firstRow.pairs[4].value);


            Assert.AreEqual("height", firstRow.pairs[5].key);
            Assert.AreEqual("1.83", firstRow.pairs[5].value);

            Assert.AreEqual("sport", firstRow.pairs[6].key);
            Assert.AreEqual("basketball", firstRow.pairs[6].value);
        }

    }
}
