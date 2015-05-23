namespace _13.ExcelStudents
{
    class Student
    {
        public int ID;
        public string FirstName;
        public string LastName;
        public string Email;
        public string Gender;
        public string StudentType;
        public double ExamResult;
        public double HomeworkSent;
        public double HomeworkEvaluated;
        public double Teamwork;
        public double Attendance;
        public double Bonus;
        public double Result;

        public Student(string[] x)
        {
            ID = int.Parse(x[0]);
            FirstName = x[1];
            LastName = x[2];
            Email = x[3];
            Gender = x[4];
            StudentType = x[5];
            ExamResult = double.Parse(x[6]);
            HomeworkSent = double.Parse(x[7]);
            HomeworkEvaluated = double.Parse(x[8]);
            Teamwork = double.Parse(x[9]);
            Attendance = double.Parse(x[10]);
            Bonus = double.Parse(x[11]);
        }

        public void CalculateResult()
        {
            Result = (ExamResult + HomeworkSent + HomeworkEvaluated + Teamwork + Attendance + Bonus) / 5;
        }
    }
}
