using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class StudentSpecialty
    {

        public string Name { get; set; }
        public long FacultyNum { get; set; }

        public StudentSpecialty(string name, long facultyNum)
        {
            this.Name = name;
            this.FacultyNum = facultyNum;
        }

        public static List<StudentSpecialty> GetSpecialtyList()
        {
            return new List<StudentSpecialty>
            {
                new StudentSpecialty("Web Developer",853514),
                new StudentSpecialty("Web Developer",205365),
                new StudentSpecialty("PHP Developer",1000523),
                new StudentSpecialty("PHP Developer",103214),
                new StudentSpecialty("QA Engineer",8596323),
                new StudentSpecialty("QA Engineer",859814),
            };
        }
    }
}

