namespace student_grade_calculator
{
    class Subjects
    {
        public double mark { set; get; }
        public string subject { set; get; }
    }
    class Student
    {
        public char grade { set; get; }
        public string name { set; get; }
        public Subjects[] subjects_marks { set; get; }

        public double total { set; get; }
        
        public double percentage { set; get; }

        public Student(string name)
            { this.name = name; }
        public void Info()
        {
            Console.WriteLine($"Student {name}, has {subjects_marks.Length} subjects");
            Console.WriteLine($"Their subjects are:");
            for (int i = 0; i < subjects_marks.Length; i++)
            {
                Console.WriteLine($" {subjects_marks[i].subject}: {subjects_marks[i].mark}");
            }
            Console.WriteLine($"A total of {total}, percantage {percentage}% \n Their grade is: '{grade}'");
        }
        public void set_marks()
        {
            Console.WriteLine("Please enter the number of subjects");
            int num = int.Parse(Console.ReadLine());
            subjects_marks = new Subjects[num];
            for (int i = 0; i < num; i++)
            {
                subjects_marks[i] = new Subjects();
                Console.WriteLine("Please enter your subject");
                string s = Console.ReadLine();
                if (string.IsNullOrEmpty(s))
                {
                    Console.WriteLine("Invalid, please try again!");
                    return;
                }
                else
                {
                    subjects_marks[i].subject = s;
                }
                Console.WriteLine("Please enter your mark");
                double m = double.Parse(Console.ReadLine());
                if (m>100 || m<0)
                {
                    Console.WriteLine("Invalid mark, please try again!");
                    return;
                }
                subjects_marks[i].mark = m;

            }
        }
        public void Total()
        {
            total = 0;
            foreach (var r in subjects_marks)
            {
                total += r.mark;
            }

        }
        
        public void Percentage()
        {
            percentage = (total / (subjects_marks.Length * 100))*100;
        }

        public void Grade()
        {
            if (percentage <=100 && percentage >=90 )
            {
                grade = 'A';
            }
            else
            {
                if (percentage <= 89 && percentage >= 80)
                { grade = 'B'; }
                else
                {
                    if (percentage <= 79 && percentage >= 70)
                    { grade = 'C'; }
                    else if (percentage <= 69 && percentage >= 60)
                    {
                        grade = 'D';
                    }
                    else grade = 'F';
                }

            }
        }
    }
    internal class Program
    {
       
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            bool run = true;
            void View_Students()
            {
                if (students.Count != 0)
                {
                    Console.WriteLine($"You have {students.Count} student/s");
                    for (int i = 0; i < students.Count; i++)
                    {
                        Console.WriteLine($"student number {i + 1}");
                        students[i].Info();
                    }
                }
                else Console.WriteLine("No students available!");
            }
            do
            {
                Console.WriteLine("Please choose an option!");
                Console.WriteLine("1- View students and grades");
                Console.WriteLine("2- Add students");
                Console.WriteLine("3- Remove student");
                Console.WriteLine("4- Exit");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        View_Students();
                        break;

                    case 2:
                        Console.WriteLine("Please enter the number of students you'd like to add");
                        int number = int.Parse(Console.ReadLine());
                        if (number != 0 && number > 0)
                        {
                            for (int i = 0; i < number; i++)
                            {
                                Console.WriteLine("Please enter the name of the student");
                                string s_name = Console.ReadLine();
                                Student student = new Student(s_name);

                                student.set_marks();
                                student.Total();
                                student.Percentage();
                                student.Grade();
                                students.Add(student);
                            }
                        }
                        else Console.WriteLine("Invalid number, please try again!");
                        break;
                    case 3:
                        View_Students();
                        Console.WriteLine("Please enter the number of the student you'd like to remove");
                        int num = int.Parse(Console.ReadLine());
                        if (num != 0 && num > 0)
                        {
                            students.Remove(students[num]);
                        }
                        else Console.WriteLine("Invalid number, please try again!");
                        break;

                    case 4:
                        run = false;
                        break;
                }
            }
            while (run == true);
        }
    }
}
