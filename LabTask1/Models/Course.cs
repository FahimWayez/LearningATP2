using System;
using System.Collections.Generic;

namespace LabTask1.Models
{
    public partial class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CourseCode { get; set; }
        public int? Credit { get; set; }
    }
}
