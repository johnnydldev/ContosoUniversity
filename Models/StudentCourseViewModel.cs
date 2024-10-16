using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StudentCourseViewModel
    {
        public List<Student> students { get; set; }
        public List<Course> courses { get; set;}
        public string idCourse { get; set; }
        public string nameStudent { get; set; }

    }
}
