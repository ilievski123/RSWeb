
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace RSWeb2022.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RSWeb2022Context(
            serviceProvider.GetRequiredService<
            DbContextOptions<RSWeb2022Context>>()))
            {
                // Look for any movies.
                if (context.Course.Any() || context.Teacher.Any() || context.Student.Any())
                {
                    return; // DB has been seeded
                }
                context.Teacher.AddRange(
                new Teacher { Id = 1, FirstName = "Stole", LastName = "Stolev", Degree = "Masters", AcademicRank = "Professor", OfficeNumber = "221", HireDate = DateTime.Parse("1990-3-6") },
                new Teacher { Id = 2, FirstName = "Kris", LastName = "Kristov", Degree = "PhD", AcademicRank = "Proffesor", OfficeNumber = "222", HireDate = DateTime.Parse("1992-7-6") },
                new Teacher { Id = 3, FirstName = "Kire", LastName = "Kirov", Degree = "Masters", AcademicRank = "Assistant", OfficeNumber = "223", HireDate = DateTime.Parse("2000-3-10") }
                );
                context.SaveChanges();
                context.Student.AddRange(
                new Student { Id = 1, StudentId = "100", FirstName = "Filip", LastName = "Filipov", EnrollmentDate = DateTime.Parse("2019-3-14"), AcquiredCredits = 150, CurrentSemestar = 6, EducationLevel = "Under graduate" },
                new Student { Id = 2, StudentId = "101", FirstName = "Kiril", LastName = "Kirilov", EnrollmentDate = DateTime.Parse("2018-2-14"), AcquiredCredits = 200, CurrentSemestar = 8, EducationLevel = "Under graduate" },
                new Student { Id = 3, StudentId = "102", FirstName = "Cvele", LastName = "Cvetanov", EnrollmentDate = DateTime.Parse("2019-3-20"), AcquiredCredits = 160, CurrentSemestar = 6, EducationLevel = "Under graduate" },
                new Student { Id = 4, StudentId = "103", FirstName = "Jole", LastName = "Jolev", EnrollmentDate = DateTime.Parse("2016-3-14"), AcquiredCredits = 250, CurrentSemestar = 10, EducationLevel = "Masters" },
                new Student { Id = 5, StudentId = "104", FirstName = "Vlade", LastName = "Vladov", EnrollmentDate = DateTime.Parse("2015-3-14"), AcquiredCredits = 300, CurrentSemestar = 12, EducationLevel = "PhD" },
                new Student { Id = 6, StudentId = "105", FirstName = "Nikola", LastName = "Nikolov", EnrollmentDate = DateTime.Parse("2020-3-14"), AcquiredCredits = 100, CurrentSemestar = 4, EducationLevel = "Under graduate" }
                );
                context.SaveChanges();
                context.Course.AddRange(
                new Course
                {
                    Id = 1,
                    Title = "RSWeb",
                    Credits = 6,
                    Semester = 6,
                    Programme = "KTI",
                    EducationLevel = "Under graduate",
                    FirstTeacherId = context.Teacher.Single(d => d.FirstName == "Stole" && d.LastName == "Stolev").Id,
                    SecondTeacherId = context.Teacher.Single(d => d.FirstName == "Kire" && d.LastName == "Kirov").Id
                },
                new Course
                {
                    Id = 2,
                    Title = "OWEB",
                    Credits = 6,
                    Semester = 5,
                    Programme = "KTI&TKII",
                    EducationLevel = "Under graduate",
                    FirstTeacherId = context.Teacher.Single(d => d.FirstName == "Kris" && d.LastName == "Kristov").Id,
                    SecondTeacherId = context.Teacher.Single(d => d.FirstName == "Stole" && d.LastName == "Stolev").Id
                },
                new Course
                {
                    Id = 3,
                    Title = "OE",
                    Credits = 8,
                    Semester = 1,
                    Programme = "All",
                    EducationLevel = "Under graduate",
                    FirstTeacherId = context.Teacher.Single(d => d.FirstName == "Kire" && d.LastName == "Kirov").Id,
                    SecondTeacherId = context.Teacher.Single(d => d.FirstName == "Kris" && d.LastName == "Kristov").Id
                },
                new Course
                {
                    Id = 4,
                    Title = "Fizika3",
                    Credits = 6,
                    Semester = 1,
                    Programme = "KSIAR",
                    EducationLevel = "Masters",
                    FirstTeacherId = context.Teacher.Single(d => d.FirstName == "Stole" && d.LastName == "Stolev").Id,
                    SecondTeacherId = context.Teacher.Single(d => d.FirstName == "Kire" && d.LastName == "Kirov").Id
                }
                );
                context.SaveChanges();

                context.Enrollment.AddRange
                (
                new Enrollment { Semester = "1", Year = 2019, Grade = 6, SeminalUrl = "asdf", ProjectUrl = "fdsa", ExamPoints = 30, SeminalPoints = 0, ProjectPoints = 10, AdditionalPoints = 0, FinishDate = DateTime.Parse("2020-3-14"), StudentId = 1, CourseId = 2 },
                new Enrollment { Semester = "2", Year = 2020, Grade = 8, SeminalUrl = "lkjh", ProjectUrl = "hjkl", ExamPoints = 70, SeminalPoints = 10, ProjectPoints = 10, AdditionalPoints = 0, FinishDate = DateTime.Parse("2021-3-14"), StudentId = 2, CourseId = 1 },
                new Enrollment { Semester = "3", Year = 2020, Grade = 7, SeminalUrl = "qwer", ProjectUrl = "reqw", ExamPoints = 60, SeminalPoints = 10, ProjectPoints = 10, AdditionalPoints = 0, FinishDate = DateTime.Parse("2019-3-14"), StudentId = 4, CourseId = 1 },
                new Enrollment { Semester = "4", Year = 2021, Grade = 7, SeminalUrl = "qasw", ProjectUrl = "wasq", ExamPoints = 60, SeminalPoints = 10, ProjectPoints = 10, AdditionalPoints = 0, FinishDate = DateTime.Parse("2021-3-14"), StudentId = 1, CourseId = 4 },
                new Enrollment { Semester = "7", Year = 2022, Grade = 9, SeminalUrl = "htyu", ProjectUrl = "ytht", ExamPoints = 85, SeminalPoints = 5, ProjectPoints = 10, AdditionalPoints = 0, FinishDate = DateTime.Parse("2022-3-14"), StudentId = 5, CourseId = 4 },
                new Enrollment { Semester = "6", Year = 2022, Grade = 10, SeminalUrl = "kuiy", ProjectUrl = "yiuk", ExamPoints = 92, SeminalPoints = 10, ProjectPoints = 10, AdditionalPoints = 0, FinishDate = DateTime.Parse("2020-3-14"), StudentId = 6, CourseId = 2 },
                new Enrollment { Semester = "1", Year = 2019, Grade = 10, SeminalUrl = "liuk", ProjectUrl = "uikl", ExamPoints = 98, SeminalPoints = 10, ProjectPoints = 10, AdditionalPoints = 0, FinishDate = DateTime.Parse("2021-3-14"), StudentId = 4, CourseId = 3 },
                new Enrollment { Semester = "2", Year = 2020, Grade = 6, SeminalUrl = "brtq", ProjectUrl = "wrqv", ExamPoints = 54, SeminalPoints = 5, ProjectPoints = 10, AdditionalPoints = 0, FinishDate = DateTime.Parse("2022-3-14"), StudentId = 3, CourseId = 3 },
                new Enrollment { Semester = "8", Year = 2023, Grade = 8, SeminalUrl = "agag", ProjectUrl = "safs", ExamPoints = 77, SeminalPoints = 10, ProjectPoints = 10, AdditionalPoints = 0, FinishDate = DateTime.Parse("2021-3-14"), StudentId = 6, CourseId = 3 },
                new Enrollment { Semester = "2", Year = 2020, Grade = 9, SeminalUrl = "beqw", ProjectUrl = "jyui", ExamPoints = 87, SeminalPoints = 5, ProjectPoints = 10, AdditionalPoints = 0, FinishDate = DateTime.Parse("2020-3-14"), StudentId = 7, CourseId = 2 },
                new Enrollment { Semester = "4", Year = 2021, Grade = 10, SeminalUrl = "muik", ProjectUrl = "kium", ExamPoints = 95, SeminalPoints = 10, ProjectPoints = 10, AdditionalPoints = 0, FinishDate = DateTime.Parse("2022-3-14"), StudentId = 8, CourseId = 1 }
                );
                context.SaveChanges();

            }
        }
    }
}