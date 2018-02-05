using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReading.Reading
{
    public interface IRoleBasedFileReader
    {
        string Read(string path);
    }
}
