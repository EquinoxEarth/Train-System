using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace TrainSystem.Classes
{
    class FileManager
    {
        // SCHEMA FOR FILE: Schedule, Station, Train, Direction, Time //

        private TSystem trainSystem;

        /// <summary>
        /// Creates an instance of the File Manager
        /// </summary>
        public FileManager()
        {
            
        }

        /// <summary>
        /// Loads a file's records into memory
        /// </summary>
        /// <param name="fileName">Name of file to be loaded</param>
        /// <returns>Whether or not the file loaded</returns>
        public bool Load(string fileName)
        {
            // Create Empty Reader (For Scope reasons) //
            StreamReader sr = null;

            // Try Catch to find any file errors
            try {
                // Create the Reader //
                sr = new StreamReader("./" + fileName + ".csv");

                // Move cursor to first Record //
                string record = sr.ReadLine();

                // Loop through Records //
                while (record != null)
                {
                    // Split the Record into Fields //
                    string[] fields = record.Split(',');

                    // Add Record to TrainSystem
                    trainSystem.AddRecord(fields[0], fields[1], fields[2], fields[3], Convert.ToInt32(fields[4]));

                    // Grab the next Record //
                    record = sr.ReadLine();
                }

                return true;
            }
            catch (FileNotFoundException ex)
            {
                Console.Write(ex.Message);

                return false;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);

                return false;
            }
            finally
            {
                sr.Close();
            }
        }

        public bool Save(string fileName)
        {

            return true;
        }
    }
}
