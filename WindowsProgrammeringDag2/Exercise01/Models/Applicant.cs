using System;
using System.Collections.Generic;

namespace Exercise01.Models
{
    public class Applicant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobType { get; set; }
        public ICollection<Language> Languages { get; set; }
        public string DesiredProfession { get; set; }
        public DateTime EarliestStartDate { get; set; }
    }
}
