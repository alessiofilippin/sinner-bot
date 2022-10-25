using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinnerBot.Models
{
    public class Minor
    {
        public string name { get; set; }
        public string effects { get; set; }

        public Minor(string _name, string _effects)
        {
            name = _name;
            effects = _effects;
        }
    }
}
