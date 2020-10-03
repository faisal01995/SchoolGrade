using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolGrade.Models
{
    public class Classes
    {
        [Key]
        public int ClassId { get; set; }
        [Required]
        public string className { get; set; }

        public Grades Grades { get; set; }
        [ForeignKey("Grades")]
        public int GradeId { get; set; }
        public virtual ICollection<GradeStudent> GradeStudent { get; set; }

    }
}