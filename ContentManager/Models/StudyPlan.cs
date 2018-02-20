using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentManager.Models
{
    public class StudyPlan
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }

        public University University { get; set; }
        public int UniversityID { get; set; }
    }
}
