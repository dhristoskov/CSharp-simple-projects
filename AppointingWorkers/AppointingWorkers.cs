using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointingWorkers
{
    class Worker
    {
        public string name;
        public string[] jobExpertise;

        public string Name
        {
            get {return this.name;}
        }
        public string[] JobExpertise
        {
            get { return this.jobExpertise; }
        }
        public Worker(string name, string []jobExpertise)
        {
            this.name = name;
            this.jobExpertise = jobExpertise;
        }
        public int JobsCanDo()
        {
            int jobsCanDo = jobExpertise.Length;
            return jobsCanDo;
        }
    }
    class AppointingWorkers
    {
        static List<string> jobsToDo = new List<string>();
        static List<Worker> workersGroup = new List<Worker>();

        static void SortWorker()
        {
            for (int a = workersGroup.Count - 2; a >= 0; a--)
            {
                for (int b = 0; b <= a; b++)
                {
                    if (workersGroup[b + 1].JobsCanDo() < workersGroup[b].JobsCanDo())
                    {
                        Worker w = workersGroup[b + 1];
                        workersGroup[b + 1] = workersGroup[b];
                        workersGroup[b] = w;
                    }
                }
            }
        }
        static void GiveJobs()
        {
            for (int a = 0; a < jobsToDo.Count; a++)
            {
                for (int b = 0; b < workersGroup.Count; b++)
                {
                    string[] jobs = workersGroup[b].JobExpertise;
                    if (jobs.Contains(jobsToDo[a]))
                    {
                        Console.WriteLine("{0} ---> {1}", workersGroup[b].Name, jobsToDo[a]);
                        workersGroup.RemoveAt(b);
                        jobsToDo.RemoveAt(a);
                        break;
                    }
                }              
            }
        }
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                jobsToDo.Add(Console.ReadLine());
            }
            for (int j = 0; j < number; j++)
            {
                string worker = Console.ReadLine();
                string name = worker.Split()[0].Trim();
                string[] expertise = worker.Split()[1].Trim().Split(',');
                workersGroup.Add(new Worker(name, expertise));
            }
            SortWorker();
            while (workersGroup.Count > 0)
            {
                GiveJobs();
            }
        }
    }
}
