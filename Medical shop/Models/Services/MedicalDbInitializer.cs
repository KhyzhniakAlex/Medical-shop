using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Medical_shop.Models.Services
{
    public class MedicalDbInitializer : DropCreateDatabaseAlways<MedicalContext>
    {
        protected override void Seed(MedicalContext context)
        {
            //Order order2 = new Order { Id = 2, Date = new DateTime.toString("dd-MM-yyyy"), Sum = 399 };
            //Order order3 = new Order { Id = 3, Name = "Олег", Surname = "Кузнецов" };

            //context.Students.Add(s1);
            //context.Students.Add(s2);
            //context.Students.Add(s3);
            //context.Students.Add(s4);

            //Course c1 = new Course
            //{
            //    Id = 1,
            //    Name = "Операционные системы",
            //    Students = new List<Student>() { s1, s2, s3 }
            //};
            //Course c2 = new Course
            //{
            //    Id = 2,
            //    Name = "Алгоритмы и структуры данных",
            //    Students = new List<Student>() { s2, s4 }
            //};
            //Course c3 = new Course
            //{
            //    Id = 3,
            //    Name = "Основы HTML и CSS",
            //    Students = new List<Student>() { s3, s4, s1 }
            //};

            //context.Courses.Add(c1);
            //context.Courses.Add(c2);
            //context.Courses.Add(c3);

            base.Seed(context);
        }
    }
}