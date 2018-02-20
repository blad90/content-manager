using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContentManager.Models;

namespace ContentManager.Data
{
    public class DbInitializer
    {
        public static void Initialize(CMContext context)
        {
            context.Database.EnsureCreated();

            // Look for any universities.
            if (context.Universities.Any())
            {
                return;   // DB has been seeded
            }

            var universities = new University[]
            {
            new University{Name="APEC", Description="ABCDEFGH"},
            new University{Name="INTEC", Description="ABCDEFGH"},
            new University{Name="PUCMM", Description="ABCDEFGH"},
            };
            foreach (University s in universities)
            {
                context.Universities.Add(s);
            }
            context.SaveChanges();

            var professors = new Professor[]
            {
            new Professor{Name="Bobby Matos", DateOfBirth=new DateTime(1975, 10, 10)},
            new Professor{Name="Oshin Toyota", DateOfBirth=new DateTime(1968, 12, 12)},
            };
            foreach (Professor p in professors)
            {
                context.Professors.Add(p);
            }
            context.SaveChanges();

            var studyPlans = new StudyPlan[]
            {
            new StudyPlan{Name="Software Modeling", Content="ABCDFGHIJKLMNOP"},
            new StudyPlan{Name="Software Quality", Content="ABCDFGHIJKLMNOP"},
            };
            foreach (StudyPlan sp in studyPlans)
            {
                context.StudyPlans.Add(sp);
            }
            context.SaveChanges();

        }
    }
}
