using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolGrade.Models
{
    public class Grades
    {
        [Key]
        public int GradeId { get; set; }
        [Required]
        public string Gradename { get; set; }
        [Required]
        public bool isActive { get; set; }
        public virtual ICollection<GradeStudent> GradeStudent { get; set; }

    }
}