using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Student
    {
        public int idStudent {  get; set; }
        
        [Display(Name ="Apellidos:"), Required]
        public string lastName { get; set; }

        [Display(Name = "Nombre:"), Required]
        public string firstMidName { get; set; }

        [Display(Name = "Genero:"), Required]
        public string genre { get; set; }

        [Display(Name = "Imagen")]
        public byte[] img { get; set; }

        [Display(Name = "Fecha de creación")]
        public DateTime enrollmentDate { get; set; }

        public List<Enrollment> enrollments { get; set; }

    }//End student class
}//End namespace Models
