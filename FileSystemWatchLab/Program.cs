using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemWatchLab
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcherExample.Init();
            Console.Read();
        }
    }
}
