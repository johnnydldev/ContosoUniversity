using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public enum Grade
    {
        A, B, C, D, E, F
    }
    public class Enrollment
    {
        public int idEnrollment {  get; set; }
        public Course course { get; set; }
        public Student student { get; set; }
        public Grade? grade { get; set; }

    }//End enrollment class
}//End namespace Models
