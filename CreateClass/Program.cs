using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateClass
{
    class Person
    {
        private string name;
        private DateTime birthDate;

        public Person() { }

        public Person(string name, DateTime birthDate)
        {
            this.name = name;
            this.birthDate = birthDate;
        }

        public string Name
        {
            get{return name;}
            set{name = value;}
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public enum Genders:int { FEMALE, MALE };
        public Genders gender;

        public override string ToString()
        {
            return (String.Format("Name: {0}, birth date: {1}", this.name, this.birthDate));
        }

    }

    class Employee : Person, ICloneable
    {
        private int salary;
        private string profession;

        public Room Room;

        public Employee()
        {
            Room = null;
        }

        public Employee(string name, DateTime birthDate, int salary, string profession):base(name, birthDate)
        {
            this.salary = salary;
            this.profession = profession;
            Room = null;
        }

        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public string Profession
        {
            get { return profession; }
            set { profession = value; }
        }

        public override string ToString()
        {
            return base.ToString() + String.Format("salary: {0}, profession: {1}, room: {2}", salary, profession, Room.Number);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        //public object Clone()
        //{
        //    Employee newEmployee = (Employee)this.MemberwiseClone();
        //    newEmployee.Room = new Room(Room.Number);
        //    return newEmployee;
        //}
    }

    class Room
    {
        private int number;

        public Room(int number)
        {
            this.number = number;
        }
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee Kovacs = new Employee("Géza", DateTime.Now, 1000, "léhűtő");
            Kovacs.Room = new Room(111);
            Employee Kovacs2 = (Employee)Kovacs.Clone();
            Kovacs2.Room.Number = 112;

            Console.WriteLine(Kovacs.ToString());
            Console.WriteLine(Kovacs2.ToString());
            Console.ReadKey();
        }
    }
}
