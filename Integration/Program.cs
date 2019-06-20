using ChoETL;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Integration {
    public class Program {
        // defualt csv and json filename
        private static string CSV_FILENAME = "athletes.csv";
        private static string JSON_FILENAME = "athlete.json";

        static void Main(string[] args) {
            Console.WriteLine("Loading data....");
            Integration.AthletesDTO athleles = LoadCsvFile(CSV_FILENAME);
            Console.WriteLine("Data loaded....\n");

            Console.WriteLine("Saving Data....");
            SaveJsonFile(JSON_FILENAME, athleles);
            Console.WriteLine("Data Saved....\n");

            Console.WriteLine("Go to bin/Debug/netcoreapp2.1/athlete.json to look at result...");
            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();
        }

        /// <summary>
        /// load athlete csv file and convert it to List
        /// </summary>
        /// <param name="filename">the name of csv file </param>
        /// <returns></returns>
        public static AthletesDTO LoadCsvFile(string filename) {
            try {
                // read csv file with no column headers
                using (var athleles = new ChoCSVReader<Athlele>(filename)) {
                    var mapper = AltheteMapper.getMapper();
                    return new AthletesDTO { rows = athleles.Select(athlete => mapper.Map<AthleleDTO>(athlete)).ToList() };
                }
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Save the tranfered althete data as json 
        /// </summary>
        /// <param name="filename"> the name of file </param>
        /// <param name="athleles"> the data of althletes </param>
        public static string SaveJsonFile(string filename, AthletesDTO athleles) {
            var json = JsonConvert.SerializeObject(athleles);
            System.IO.File.WriteAllText(filename, json);
            return json;
        }
    }
}
