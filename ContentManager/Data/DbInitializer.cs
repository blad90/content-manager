using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ContentManager.Models;
using Newtonsoft.Json;

namespace ContentManager.Data
{
    public class DbInitializer
    {
        public static void Initialize(CMContext context)
        {
            context.Database.EnsureCreated();

            var json = @"[
	            { 	'ID'	 		: 250,
		            'Name'	 		: 'APEC',
		            'Description' 	: 'ABCDE FGHIJ KLMNOP QRST' 
	            },{
  		            'ID' 			: 350,
		            'Name'	 		: 'ITLA',
		            'Description' 	: 'ABCDE FGHIJ KLMNOP QRST' 
	            },{
 		            'ID' 			: 450,
		            'Name'	 		: 'PUCMM',
		            'Description' 	: 'ABCDE FGHIJ KLMNOP QRST' 
 	            },{
 		            'ID' 			: 550,
		            'Name'	 		: 'INTEC',
		            'Description'	: 'ABCDE FGHIJ KLMNOP QRST' 
 	            },{
 		            'ID'			: 650,
		            'Name'	 		: 'O&M',
		            'Description' 	: 'ABCDE FGHIJ KLMNOP QRST'
	            }
            ]";

            dynamic parsedArray = JsonConvert.DeserializeObject(json);
            foreach (dynamic item in parsedArray)
                Debug.WriteLine($"University ID: {item.ID} Name: {item.Name} Description: {item.Description}");

            //For testing ===>
            var tests = new University[3];
            foreach (dynamic it in parsedArray)
            {
                tests = new University[]
                {
                    new University{ID=it.ID, Name=it.Name, Description=it.Description}
                };
            }
            
            foreach (University s in tests)
            {
                context.Universities.Add(s);
            }
            context.SaveChanges();
            //<==== For testing.

            // Look for any universities.
            if (context.Universities.Any())
            {
                return;   // DB has been seeded
            }

            var universities = new University[]
            {
                
            new University{ID=200, Name="APEC", Description="ABCDEFGH"},
            new University{ID=300, Name="INTEC", Description="ABCDEFGH"},
            new University{ID=450, Name="PUCMM", Description="ABCDEFGH"},
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
            new StudyPlan{Name="Software Modeling", Content="ABCDFGHIJKLMNOP", UniversityID=200},
            new StudyPlan{Name="Software Quality", Content="ABCDFGHIJKLMNOP", UniversityID=300},
            };
            foreach (StudyPlan sp in studyPlans)
            {
                context.StudyPlans.Add(sp);
            }
            context.SaveChanges();
        }
    }
}
