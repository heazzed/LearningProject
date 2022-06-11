using System;

namespace LP_RefOutIsAs
{
    class Program
    {
        static void RefReturn(ref int value) // make something with that variable, reference-type
        {
            value++;
        }

        static void ValReturn(int value) // make something with copy of variable, value-type
        {
            value++;
        }

        static void InOutReturn(in int value, out int newValue) // in - readonly method, can't do something with arguments
        {                                                       // out - works like ref, but provide initialize variable in method
            newValue = value;
        }




        static void Main(string[] args)
        {
            Student student = new("Alex", "First School");
            Human human = student; // upcast, implicit


            Human _human = new Human("Tom");

            Console.WriteLine(student.Name + " from " + student.School);

            human.Display();
            Console.WriteLine(human.GetType().ToString());

            Console.WriteLine();

            if(human is Student _student) // test operatot 'is' to downcast
            {
                Console.WriteLine(_student.School);
            }


            Student student_1 = _human as Student; // test operator 'as' to downcast
            if(student_1 != null)
            {
                Console.WriteLine(student_1.School);
            }

            try
            {
                Student student_2 = (Student)_human; // explicit downcast
                Console.WriteLine(student_2.School);
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        
    }

    class Human
    {
        public string Name { get; set; }

    
        public Human(string name)
        {
            Name = name;
        }

        public void Display()
        {
            Console.WriteLine($"Human {Name}");
        }
    }

    class Student : Human
    {
        public string School { get; set; }

        public Student(string name, string school) : base(name)
        {
            School = school;
        }
    }
}
