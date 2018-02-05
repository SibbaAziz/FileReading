using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReading.Security
{
    public interface ISecurity
    {
        bool CanRead(string path);
        bool CanWrite(string path);
    }
}
