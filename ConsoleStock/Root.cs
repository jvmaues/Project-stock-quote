using ConsoleStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleStock
{
    class Root
    {
        public string by { get; set; }
        public bool valid_key { get; set; }
        public Results results { get; set; }
        public double execution_time { get; set; }
        public bool from_cache { get; set; }
    }
}

