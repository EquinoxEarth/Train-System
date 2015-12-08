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

        private ASystem sys;

        /// <summary>
        /// Creates an instance of the File Manager
        /// </summary>
        public FileManager(ASystem sys)
        {
            this.sys = sys;
        }

        /// <summary>
        /// Loads a file's records into memory
        /// </summary>
        /// <param name="fileName">Name of file to be loaded</param>
        /// <returns>Whether or not the file loaded</returns>
        public bool Load()
        {
            // Create Empty Reader (For Scope reasons) //
            StreamReader sr = null;

            // Set Path to the Users MyDocuments folder //
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Try Catch to find any file errors
            try {
                // Create the Reader //
                sr = new StreamReader(path + "/trainSystem.csv");

                // Move cursor to first Record //
                string record = sr.ReadLine();

                // Loop through Records //
                while (record != null)
                {
                    // Split the Record into Fields //
                    //string[] fields = record.Split(',');

                    // Add Record to TrainSystem
                    if (!sys.AddRecord(record))
                    {
                        return false;
                    }

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
            catch (IOException ex)
            {
                Console.Write(ex.Message);

                return false;
            }
            finally
            {
                sr.Close();
            }
        }
        
        /// <summary>
        /// Saves all Records loaded in memory to the specified file
        /// </summary>
        /// <param name="fileName">Name of file for data to be saved to</param>
        /// <returns></returns>
        public bool Save(string fileName)
        {
            // Create Empty Writer (For Scope reasons) //
            StreamWriter sw = null;

            // Set Path to the Users MyDocuments folder //
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Try Catch to find any file errors //
            try
            {
                // Create the Writer (NON APPENDING, IS THIS AN ISSUE? //
                sw = new StreamWriter(path + "/trainSystem.csv");

                // Write all Records to file //
                List<Record> recordList = sys.GetAllRecords();
                foreach (Record record in recordList)
                {
                    // Grab string for writing (INCASE WE NEED THIS TO BE EDITED) //
                    string line = record.GetRecordToSave();

                    // Write the Record //
                    sw.WriteLine(line);
                }

                return true;
            }
            catch (IOException ex)
            {
                Console.Write(ex.Message);

                return false;
            }
            finally
            {
                sw.Close();
            }
        }
    }
}
