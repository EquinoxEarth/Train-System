﻿using System;
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

            return true;
        }

        public bool Save(string fileName)
        {

            return true;
        }
    }
}