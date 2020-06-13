namespace Online_Education.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Choices",
                c => new
                    {
                        QuestionID = c.Int(nullable: false),
                        Choice = c.String(),
                        IsTrue = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.MCQs", t => t.QuestionID)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.MCQs",
                c => new
                    {
                        QuestionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.Questions", t => t.QuestionID)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuestionContent = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StudentAnswerInExams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.String(maxLength: 128),
                        ExamID = c.Int(nullable: false),
                        QuestionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Exams", t => t.ExamID, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.StudentID)
                .Index(t => t.StudentID)
                .Index(t => t.ExamID)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        TotalDegree = c.Int(nullable: false),
                        CourseId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                        MaxDegree = c.Int(nullable: false),
                        MinDegree = c.Int(nullable: false),
                        StageID = c.Int(nullable: false),
                        Semester = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.Stages", t => t.StageID, cascadeDelete: true)
                .Index(t => t.StageID);
            
            CreateTable(
                "dbo.Enrolls",
                c => new
                    {
                        StudentID = c.String(nullable: false, maxLength: 128),
                        CourseCode = c.String(nullable: false, maxLength: 128),
                        EnrollDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentID, t.CourseCode })
                .ForeignKey("dbo.Courses", t => t.CourseCode, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.CourseCode);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Type = c.String(),
                        Name = c.String(),
                        Image = c.String(),
                        Level = c.String(),
                        Gender = c.String(),
                        Address = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Stages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Teaches",
                c => new
                    {
                        TeacherID = c.String(nullable: false, maxLength: 128),
                        CourseCode = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.TeacherID, t.CourseCode })
                .ForeignKey("dbo.Courses", t => t.CourseCode, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID)
                .Index(t => t.CourseCode);
            
            CreateTable(
                "dbo.ExamQuestions",
                c => new
                    {
                        ExamID = c.Int(nullable: false),
                        QuestionID = c.Int(nullable: false),
                        Degree = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExamID, t.QuestionID })
                .ForeignKey("dbo.Exams", t => t.ExamID, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.ExamID)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.TrueFalseQuestions",
                c => new
                    {
                        QuestionID = c.Int(nullable: false),
                        CorrectAnswer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.Questions", t => t.QuestionID)
                .Index(t => t.QuestionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TrueFalseQuestions", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.MCQs", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.StudentAnswerInExams", "StudentID", "dbo.AspNetUsers");
            DropForeignKey("dbo.StudentAnswerInExams", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.StudentAnswerInExams", "ExamID", "dbo.Exams");
            DropForeignKey("dbo.ExamQuestions", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.ExamQuestions", "ExamID", "dbo.Exams");
            DropForeignKey("dbo.Teaches", "TeacherID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Teaches", "CourseCode", "dbo.Courses");
            DropForeignKey("dbo.Courses", "StageID", "dbo.Stages");
            DropForeignKey("dbo.Exams", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Enrolls", "StudentID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Enrolls", "CourseCode", "dbo.Courses");
            DropForeignKey("dbo.Choices", "QuestionID", "dbo.MCQs");
            DropIndex("dbo.TrueFalseQuestions", new[] { "QuestionID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ExamQuestions", new[] { "QuestionID" });
            DropIndex("dbo.ExamQuestions", new[] { "ExamID" });
            DropIndex("dbo.Teaches", new[] { "CourseCode" });
            DropIndex("dbo.Teaches", new[] { "TeacherID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Enrolls", new[] { "CourseCode" });
            DropIndex("dbo.Enrolls", new[] { "StudentID" });
            DropIndex("dbo.Courses", new[] { "StageID" });
            DropIndex("dbo.Exams", new[] { "CourseId" });
            DropIndex("dbo.StudentAnswerInExams", new[] { "QuestionID" });
            DropIndex("dbo.StudentAnswerInExams", new[] { "ExamID" });
            DropIndex("dbo.StudentAnswerInExams", new[] { "StudentID" });
            DropIndex("dbo.MCQs", new[] { "QuestionID" });
            DropIndex("dbo.Choices", new[] { "QuestionID" });
            DropTable("dbo.TrueFalseQuestions");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ExamQuestions");
            DropTable("dbo.Teaches");
            DropTable("dbo.Stages");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Enrolls");
            DropTable("dbo.Courses");
            DropTable("dbo.Exams");
            DropTable("dbo.StudentAnswerInExams");
            DropTable("dbo.Questions");
            DropTable("dbo.MCQs");
            DropTable("dbo.Choices");
        }
    }
}
