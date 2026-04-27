using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManager
{
    public class Log
    {
        public DateTime Ido { get; set; }
        public string Szint { get; set; }
        public string Uzenet { get; set; }

        public Log(string sor)
        {
            string[] temp = sor.Split(" - ");
            Ido = DateTime.Parse(temp[0]);
            Szint = temp[1];
            Uzenet = temp[2];
        }
    }
}
