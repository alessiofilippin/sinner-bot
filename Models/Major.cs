using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinnerBot.Models
{
    public class Major
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Effects { get; set; }

        public Major(string _Name, string _Description, string _Effects)
        {
            Name = _Name;
            Description = _Description;
            Effects = _Effects;
        }
    }
}
