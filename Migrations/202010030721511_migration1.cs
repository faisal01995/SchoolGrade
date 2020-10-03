namespace SchoolGrade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        className = c.String(nullable: false),
                        GradeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassId)
                .ForeignKey("dbo.Grades", t => t.GradeId, cascadeDelete: false)
                .Index(t => t.GradeId);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        Gradename = c.String(nullable: false),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GradeId);
            
            CreateTable(
                "dbo.GradeStudents",
                c => new
                    {
                        GradeId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GradeId, t.ClassId, t.StudentId })
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: false)
                .ForeignKey("dbo.Grades", t => t.GradeId, cascadeDelete: false)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: false)
                .Index(t => t.GradeId)
                .Index(t => t.ClassId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false),
                        City = c.String(),
                        NatianlId = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "GradeId", "dbo.Grades");
            DropForeignKey("dbo.GradeStudents", "StudentId", "dbo.Students");
            DropForeignKey("dbo.GradeStudents", "GradeId", "dbo.Grades");
            DropForeignKey("dbo.GradeStudents", "ClassId", "dbo.Classes");
            DropIndex("dbo.GradeStudents", new[] { "StudentId" });
            DropIndex("dbo.GradeStudents", new[] { "ClassId" });
            DropIndex("dbo.GradeStudents", new[] { "GradeId" });
            DropIndex("dbo.Classes", new[] { "GradeId" });
            DropTable("dbo.Students");
            DropTable("dbo.GradeStudents");
            DropTable("dbo.Grades");
            DropTable("dbo.Classes");
        }
    }
}
