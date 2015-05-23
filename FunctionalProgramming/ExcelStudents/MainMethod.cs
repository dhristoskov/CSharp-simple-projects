using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.IO;
using OfficeOpenXml;
using System.Xml;
using System.Drawing;
using OfficeOpenXml.Style;
using System.Threading;
using System.Globalization;
using System.Linq;

namespace _13.ExcelStudents
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            List<Student> students = GetStudents();

            var result = (from student in students
                          where student.StudentType.Equals("Online")
                          orderby student.Result descending
                          select student).ToList();

            ListToExcel(result);
        }

        static List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            using (StreamReader reader = new StreamReader("data.txt"))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    Student currentStudent = new Student(reader.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries));
                    currentStudent.CalculateResult();
                    students.Add(currentStudent);
                }
            }
            return students;
        }

        static void ListToExcel(List<Student> students)
        {

            FileInfo file = new FileInfo("excel.xlsx");
            if (file.Exists)
            {
                file.Delete();
                file = new FileInfo("excel.xlsx");
            }
            using (ExcelPackage package = new ExcelPackage(file))
            {

                ExcelWorksheet ws = package.Workbook.Worksheets.Add("Content");
                using (ExcelRange xr = ws.Cells["A1:M2"])
                {
                    xr.Merge = true;
                    xr.Style.Font.Size = 25;
                    xr.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    xr.Value = "SoftUni OOP Course Results";
                }
                using (ExcelRange xr = ws.Cells["A3:M3"])
                {
                    xr.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    xr.Style.Fill.BackgroundColor.SetColor(Color.Green);
                    xr.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
                ws.Column(1).Width = 4;
                ws.Column(2).Width = 12;
                ws.Column(3).Width = 12;
                ws.Column(4).Width = 20;
                ws.Column(5).Width = 9;
                ws.Column(6).Width = 13;
                ws.Column(7).Width = 13;
                ws.Column(8).Width = 15;
                ws.Column(9).Width = 16;
                ws.Column(10).Width = 10;
                ws.Column(11).Width = 12;
                ws.Column(12).Width = 7;
                ws.Column(13).Width = 9;


                ws.Cells["A3"].Value = "ID";
                ws.Cells["B3"].Value = "First Name";
                ws.Cells["C3"].Value = "Last Name";
                ws.Cells["D3"].Value = "Email";
                ws.Cells["E3"].Value = "Gender";
                ws.Cells["F3"].Value = "Student Type";
                ws.Cells["G3"].Value = "Exam Results";
                ws.Cells["H3"].Value = "Homework sent";
                ws.Cells["I3"].Value = "Homework eval.";
                ws.Cells["J3"].Value = "Teamwork";
                ws.Cells["K3"].Value = "Attendence";
                ws.Cells["L3"].Value = "Bonus";
                ws.Cells["M3"].Value = "Results";

                for (int i = 0; i < students.Count; i++)
                {
                    ws.Cells[4 + i, 1].Value = students[i].ID;
                    ws.Cells[4 + i, 2].Value = students[i].FirstName;
                    ws.Cells[4 + i, 3].Value = students[i].LastName;
                    ws.Cells[4 + i, 4].Value = students[i].Email;
                    ws.Cells[4 + i, 5].Value = students[i].Gender;
                    ws.Cells[4 + i, 6].Value = students[i].StudentType;
                    ws.Cells[4 + i, 7].Value = students[i].ExamResult;
                    ws.Cells[4 + i, 8].Value = students[i].HomeworkSent;
                    ws.Cells[4 + i, 9].Value = students[i].HomeworkEvaluated;
                    ws.Cells[4 + i, 10].Value = students[i].Teamwork;
                    ws.Cells[4 + i, 11].Value = students[i].Attendance;
                    ws.Cells[4 + i, 12].Value = students[i].Bonus;
                    ws.Cells[4 + i, 13].Value = students[i].Result;
                }
                package.Save();
            }


            Process.Start("excel.xlsx");
        }
    }
}
