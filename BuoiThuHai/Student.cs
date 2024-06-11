using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuoiThuHai
{
    public class Student
    {
        private int id;
        private string name;
        private double GPA;
        public Student(int id, string name, double gPA)
        {
            this.id = id;
            this.name = name;
            this.GPA = gPA;
        }

        public int Id { get => id; set => id = value; }

        public override string ToString()
        {
            return $"Id: {id}, Name: {name}, GPA: {GPA}";
        }
    }
}
