using HospitalCaseStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalCaseStudy.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<AppointmentModel> Appointments { get; set; }
        DbSet<DepartmentModel> Departments { get; set; }
        DbSet<MedicalRecordModel> MedicalRecords { get; set; }
        DbSet<DoctorModel> Doctors { get; set; }
        DbSet<PatientModel> Patients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentModel>().HasKey(k => k.Id);
            modelBuilder.Entity<DoctorModel>().HasKey(k => k.Id);
            modelBuilder.Entity<AppointmentModel>().HasKey(k => k.Id);
            modelBuilder.Entity<MedicalRecordModel>().HasKey(k => k.Id);
            modelBuilder.Entity<PatientModel>().HasKey(k => k.Id);
            modelBuilder.Entity<PatientModel>().HasMany(k => k.Appointments).WithOne(a=>a.Patient);
            modelBuilder.Entity<DoctorModel>().HasOne(l=>l.Department).WithMany(d=>d.Doctors).HasForeignKey(a=>a.DepartmentId);
            modelBuilder.Entity<DoctorModel>().HasMany(d => d.Appointments).WithOne(a => a.Doctor);
            modelBuilder.Entity<DoctorModel>().HasIndex(a=>a.Email).IsUnique();
            modelBuilder.Entity<DoctorModel>().Property(a=>a.Salary).HasPrecision(10,2);
            modelBuilder.Entity<AppointmentModel>().HasOne(a => a.MedicalRecord).WithOne(a => a.Appointment).HasForeignKey<MedicalRecordModel>(a => a.AppointmentId);
            modelBuilder.Entity<AppointmentModel>().Property(a => a.AppointmentDate).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<AppointmentModel>().Property(a => a.Status).HasDefaultValue("Scheduled");
            modelBuilder.Entity<DepartmentModel>().HasData(new DepartmentModel
            {
                Id = 1,
                Name = "Cardiology",
                Location="Cairo"

            },
            new DepartmentModel
            {
                Id = 2,
                Name = "Pediatrics",
                Location = "Giza"

            },
            new DepartmentModel
            {
                Id = 3,
                Name = "Orthopedics",
                Location = "Cairo"

            }, new DepartmentModel
            {
                Id = 4,
                Name = "Dermatology",
                Location = "Giza"

            });
            modelBuilder.Entity<DoctorModel>().HasData(
                new DoctorModel
                {
                    Id = 1,
                    Name = "Ahmed Hassan",
                    Specialization = "Cardiologist",
                    Email = "ahmed.hassan@hms.com"
                    ,
                    Phone = "01010000001",
                    Salary = 45000,
                    DepartmentId = 1

                },
                new DoctorModel
                {
                    Id = 2,
                    Name = "Mona Adel",
                    Specialization = "Cardiologist",
                    Email = "mona.adel@hms.com"
                    ,
                    Phone = "01010000002",
                    Salary = 42000,
                    DepartmentId = 1

                },
                new DoctorModel
                {
                    Id = 3,
                    Name = "Omar Khaled",
                    Specialization = "Pediatrician",
                    Email = "omar.khaled@hms.com"
                    ,
                    Phone = "01010000003",
                    Salary = 38000,
                    DepartmentId = 2

                }
                );
            modelBuilder.Entity<PatientModel>().HasData(
                new PatientModel{
                
                Id = 1,
                Name = "Omar Ali",
               Gender="Male",
               DateOfBirth= new DateTime(1995,3,12),
               Phone= "01120000001"
               ,
               Address="Nasr City, Cairo"

                },
                new PatientModel
                {

                    Id = 2,
                    Name = "Sara Ahmed",
                    Gender = "Female",
                    DateOfBirth = new DateTime(1998, 7, 24),
                    Phone = "01120000002",
                    Address = "Nasr City, Cairo"

                },
                new PatientModel
                {

                    Id = 3,
                    Name = "Mahmoud Samir",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1987,11, 5),
                    Phone = "01120000003",
                    Address = "Heliopolis, Cairo"

                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
