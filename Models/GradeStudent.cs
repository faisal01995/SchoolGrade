using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolGrade.Models
{
    public class GradeStudent
    {
        [Key]
        [Column(Order = 1)]
        public int GradeId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ClassId { get; set; }
        [Key]
        [Column(Order = 3)]
        public int StudentId { get; set; }

        public virtual Grades Grade { get; set; }

        public virtual Classes Classes { get; set; }
        public virtual Student Student { get; set; }


    }
}