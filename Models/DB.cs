using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace SchoolGrade.Models
{
    public class DB : DbContext
    {
        public DB() : base("con")
        {


        }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Classes> Calsess { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<GradeStudent> GradeStudent { get; set; }



    }
}