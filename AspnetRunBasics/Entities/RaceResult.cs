using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RaceScore.Entities
{
    public class RaceResult
    {
        public int Id { get; set; }
        [ForeignKey("Race")]
        public int RaceRefId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TimeSpan ResultTime { get; set; }
        public bool Approved { get; set; }
        public Race Race { get; set; }
    }
}
