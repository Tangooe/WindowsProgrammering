using System.Collections.Generic;

namespace Exercise01.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Applicant> Applicants { get; set; }
    }
}
