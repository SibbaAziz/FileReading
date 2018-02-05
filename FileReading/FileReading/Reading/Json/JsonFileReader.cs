using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReading.Reading.Json
{
    public class JsonFileReader : IFileReader
    {
        public string Read(string path)
        {
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            if (!File.Exists(path))
                return string.Empty;

            return File.ReadAllText(path);
        }
    }
}
