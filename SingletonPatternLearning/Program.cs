using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPatternLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            School school = new School();
            school.SetDirector("Nurlan", "Sabaev", 25);
            Console.WriteLine($"Director's name: {school.Director.Name} \nDirector's last name: {school.Director.LastName},\nDirector's years of working: {school.Director.YearsOfWorking}");

            Console.WriteLine(new string('-', 25));
            school.SetDirector("Ivan", "Alexeeyev", 15); //
            Console.WriteLine($"Director's name: {school.Director.Name} \nDirector's last name: {school.Director.LastName},\nDirector's years of working: {school.Director.YearsOfWorking}");
        }
    }
    //class that's use singleton
    class School
    {
        public Director Director { get; set; }
        public void SetDirector(string name, string lastName, int yearsOfWorking)
        {
            Director = Director.getInstance(name, lastName, yearsOfWorking);
        }
    }

    //class with singleton
    class Director
    {
        //singleton pattern
        private static Director instance;

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public int YearsOfWorking { get; private set; }

        protected Director(string name, string lastName, int yearsOfWorking)
        {
            this.Name = name;
            this.LastName = lastName;
            this.YearsOfWorking = yearsOfWorking;
        }

        //instantiate singleton
        public static Director getInstance(string name, string lastName, int yearsOfWorking)
        {
            if (instance == null)
                instance = new Director(name, lastName, yearsOfWorking);
            return instance;
        }
    }
}
