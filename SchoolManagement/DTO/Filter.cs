using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.DTO
{
    public class Filter
    {
        public string Class { get; set; }
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public string FullName { get; set; }
        public string Subject { get; set; }
    }
}
