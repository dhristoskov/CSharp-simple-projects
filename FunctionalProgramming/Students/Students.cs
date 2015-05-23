using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{    
    public class Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int GroupNum { get; set; }
        public long FacultNum { get; set; }
        public string GroupName { get; set; }
        public List<int> Marks { get; set; }

        public Students(string firstName, string lastName, string phone, 
                        string email, int age, int group, long facult,string groupName,List<int> marks)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNum = phone;
            this.Email = email;
            this.Age = age;
            this.GroupNum = group;
            this.FacultNum = facult;
            this.GroupName = groupName;
            this.Marks = marks;
        }
    }
}
