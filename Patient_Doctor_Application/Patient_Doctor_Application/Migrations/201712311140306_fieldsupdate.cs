namespace Patient_Doctor_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fieldsupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DoctorID = c.Int(nullable: false),
                        PatientID = c.Int(nullable: false),
                        AppointmentDate = c.DateTime(nullable: false),
                        AppointmentTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Doctors", t => t.DoctorID, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientID, cascadeDelete: true)
                .Index(t => t.DoctorID)
                .Index(t => t.PatientID);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        eMail = c.String(),
                        mobileNumber = c.String(),
                        city = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        mobileNumber = c.String(),
                        E_mail = c.String(),
                        address = c.String(),
                        city = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "DoctorID", "dbo.Doctors");
            DropIndex("dbo.Appointments", new[] { "PatientID" });
            DropIndex("dbo.Appointments", new[] { "DoctorID" });
            DropTable("dbo.Patients");
            DropTable("dbo.Doctors");
            DropTable("dbo.Appointments");
        }
    }
}
