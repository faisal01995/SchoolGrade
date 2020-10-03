using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolGrade.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }
        public string City { get; set; }

        public string NatianlId { get; set; }
        public virtual ICollection<GradeStudent> GradeStudent { get; set; }

    }
}