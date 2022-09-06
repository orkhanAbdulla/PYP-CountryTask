using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYP_CountryTask.Models
{
    internal class Country
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string ISO { get; set; }
        public string Capital { get; set; }
        public string Currency { get; set; }
        public string Continent { get; set; }
        public override string ToString()
        {
            return $"{Phone} {ISO} {Capital} {Currency} {Continent} {Code} {Name}";
        }
    }
}
