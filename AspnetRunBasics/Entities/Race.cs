using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceScore.Entities
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
