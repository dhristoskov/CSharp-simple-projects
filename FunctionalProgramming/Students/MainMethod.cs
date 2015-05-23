using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{

    class MainMethod
    {
        public static List<Students> studentsList = new List<Students>()
        {
            new Students("Petar","Riadkov","+3592875654","mymail@abv.bg",18,1,853514,"Chereshka",new List<int>(){2,3,5,6,5}),
            new Students("Sylvester","Stallone","+1555557565","sstallone@gmail.com",60,2,205365,"Praskovka",new List<int>(){2,2,5,3,5}),
            new Students("Yanko","Tyankov","065454785","batyanko@abv.bg",32,2,1000523,"Chereshka",new List<int>(){3,3,6,6,4,5}),
            new Students("Dimitar","Dimitrov","029454785","supermitko@mail.bg",21,1,103214,"Chereshka",new List<int>(){3,3,3,2,2,4}),
            new Students("Kiril","Stefanov","0035929875785","kircho@abv.bg",23,2,8596323,"Praskovka",new List<int>(){3,5,6,5,6}),
            new Students("Stoian","Trifonov","0355895861","number1@yahoo.com",19,1,859814,"Chereshka",new List<int>(){3,3,5,5,4}),
        };
        #region Methods
        public static void StudentsGroup()
        {
            var results = (from student in studentsList
                          where student.GroupNum == 2
                          select student).ToList();
            results.ForEach(a => Console.WriteLine(a.FirstName));            
        }
        public static void StudentsFirstLasName()
        {
            var results = (from student in studentsList
                          where student.FirstName[0] < student.LastName[0]
                          orderby student.FirstName
                          select student).ToList();
            results.ForEach(a => Console.WriteLine("{0} {1}",a.FirstName,a.LastName));        
        }
        public static void StudentsAge()
        {
            var results = from student in studentsList
                          where student.Age >= 18 && student.Age <= 24
                          select new { student.FirstName, student.LastName, student.Age };
            foreach (var result in results)
            {
                Console.WriteLine("{0} {1} - Age:{2}", result.FirstName, result.LastName, result.Age);
            }
        }
        public static void SortStudents()
        {
            var results = (from student in studentsList
                          orderby student.LastName
                          orderby student.FirstName
                          select student).ToList();
            results.ForEach(a => Console.WriteLine(a.FirstName + " " + a.LastName));           
        }
        public static void SortStudentsLambda()
        {
            foreach (var student in studentsList.OrderBy(s => s.FirstName).ThenBy(s => s.LastName))
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
        }
        public static void FilterStudentsEmail()
        {
            var results = (from student in studentsList
                          where student.Email.Contains("@abv.bg")
                          select student).ToList();
            results.ForEach(a => Console.WriteLine("{0} {1} - {2}", a.FirstName, a.LastName, a.Email)); 
        }
        public static void FilterByPhone()
        {
            var results = (from student in studentsList
                          where student.PhoneNum.StartsWith("02") ||
                                student.PhoneNum.StartsWith("+3592") ||
                                student.PhoneNum.StartsWith("003592")
                          select student).ToList();
            results.ForEach(a => Console.WriteLine("{0} : {1}", a.FirstName, a.PhoneNum));         
        }
        public static void ExcellentStudents()
        {
            var results = from student in studentsList
                          where student.Marks.Contains(6)
                          select new { student.FirstName, student.Marks };
            foreach (var result in results)
            {
                Console.WriteLine("{0}: {1}", result.FirstName, result.Marks.Select(s => s.ToString()).Aggregate((a, b) => a + ", " + b));
            }
        }
        public static void WeakStudents()
        {
            var results = studentsList.Where(s => s.Marks.Count(m => m.Equals(2)).Equals(2)).ToList();
            results.ForEach(x => Console.WriteLine("{0}: {1}", x.FirstName, 
                x.Marks.Select(s => s.ToString()).Aggregate((a, b) => a + ", " + b)));           
        }
        public static void StudentEnrolled()
        {
            var results = studentsList.Where(x => x.FacultNum % 100 == 14).ToList();
            results.ForEach(a => Console.WriteLine("{0} {1} - {2}", a.FirstName, a.LastName,
                a.Marks.Select(s => s.ToString()).Aggregate((x, y) => x + " " + y)));
        }
        public static void StudentsByGroups()
        {
            var results = from student in studentsList
                         group student.FirstName by student.GroupName into newGroup
                         orderby newGroup.Key
                         select newGroup;
            foreach (var result in results)
            {
                Console.WriteLine(result.Key+":");
                foreach (var val in result)
                {
                    Console.WriteLine(val);
                }
           }
        }
        public static void StudentsJoined()
        {
            var results = from student in studentsList
                         join s in StudentSpecialty.GetSpecialtyList() on student.FacultNum equals s.FacultyNum
                         select new {FullName = student.FirstName + " " + student.LastName, FactNum = s.FacultyNum, Speciality = s.Name};
            foreach (var result in results)
            {
                Console.WriteLine("{0} {1} {2}",result.FullName,result.FactNum,result.Speciality);
            }
        }    
        #endregion 
        static void Main(string[] args)
        {
            Console.WriteLine("Problem 2.Students by Group");
            StudentsGroup();
            Console.WriteLine("Press any key for next method");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Problem 3.Students by First and Last Name");
            StudentsFirstLasName();
            Console.WriteLine("Press any key for next method");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Problem 4.Students by Age");
            StudentsAge();
            Console.WriteLine("Press any key for next method");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Problem 5.Sort Students");
            SortStudents();
            Console.WriteLine("Press any key for next method");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Problem 5.Sort Students/Lambda");
            SortStudentsLambda();
            Console.WriteLine("Press any key for next method");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Problem 6.Filter Students by Email Domain");
            FilterStudentsEmail();
            Console.WriteLine("Press any key for next method");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Problem 7.Filter Students by Phone");
            FilterByPhone();
            Console.WriteLine("Press any key for next method");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Problem 8.Excellent Students");
            ExcellentStudents();
            Console.WriteLine("Press any key for next method");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Problem 9.Weak Students");
            WeakStudents();
            Console.WriteLine("Press any key for next method");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Problem 10.Students Enrolled in 2014");
            StudentEnrolled();
            Console.WriteLine("Press any key for next method");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Problem 11.Students by Groups");
            StudentsByGroups();
            Console.WriteLine("Press any key for next method");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Problem 12.* Students Joined to Specialties");
            StudentsJoined();
            Console.WriteLine("Press any key for next method");
            Console.ReadKey();
            Console.Clear();                   
        }
    }
}
