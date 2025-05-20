using System.ComponentModel;

namespace ConsoleApp1
{

    public class Instructor
    {

        public int InstructorId;
        public string Name;
        public string Specialization;

        public Instructor(int instructorId, string name, string specialization)
        {
            this.InstructorId = instructorId;
            this.Name = name;
            this.Specialization = specialization;
        }

        public string Print_details()
        {
            string s = string.Empty;
            s = $" InstractorId is: {this.InstructorId}\n instractor Name is: {this.Name} \n instractor Specialization is: {this.Specialization}";

            return s;

        }
    }

    public class Courses
    {


        public int courseId;
        public string title;
        public Instructor nstructor;

        public Courses(int courseId, string title, Instructor nstructor)
        {
            this.courseId = courseId;
            this.title = title;
            this.nstructor = nstructor;
        }

        public string PrintDetails()
        {
            string s = string.Empty;
            s = $" courseId is: {this.courseId}\n instractor title is: {this.title}\n Insta name is:{this.nstructor.Name}\n insta Id is {this.nstructor.InstructorId}\n insta Specializationis: {this.nstructor.Specialization}";

            return s;
        }





    }

    public class Student // std1
    {
        public int studentID;
        public string name;
        public int age;
        public List<Courses> courses;

        public Student(int studentID, string name, int age)
        {
            this.studentID = studentID;
            this.name = name;
            this.age = age;
            courses = new();
        }


        public bool Enrolling(Courses crs)
        {
            if (crs != null)
            {
                Courses cr7 = new Courses(crs.courseId, crs.title, crs.nstructor);
                this.courses.Add(cr7);
                return true;

            }

            return false;

        }

        public string Print_Details()
        {
            string s = string.Empty;



            s = $"-StudentID is: {this.studentID}\n-Name is: {this.name}\n-Age is: {this.age}\n";


            return s;
        }



    }


    public class School
    {
        public List<Student> students;
        public List<Courses> courses;
        public List<Instructor> instructors;


        public School()
        {
            students = new List<Student>();
            courses = new List<Courses>();
            instructors = new List<Instructor>();
        }


        public bool AddStudent(Student student)
        {
            if (student != null)
            {
                Student std1 = student;
                this.students.Add(std1);

                return true;

            }
            else
                return false;

        }

        public bool AddSCourses(Courses cs)
        {
            if (cs != null)
            {
                Courses cs1 = cs;
                this.courses.Add(cs1);

                return true;
            }

            else
                return false;

        }

        public bool AddInstructor(Instructor instructor)
        {
            if (instructor != null)
            {
                Instructor inst = instructor;
                this.instructors.Add(inst);

                return true;

            }
            else
                return false;

        }


        public Student? FindStudentbyID(int studentId)
        {
            int i;

            for (i = 0; i < students.Count; i++)
            {
                if (students[i].studentID == studentId)
                    return students[i];
            }
            return null;

        }

        public string? FindCourseOfstudent(int studentId)
        {
            string s = string.Empty;
            Student? x = FindStudentbyID(studentId);
            if (x != null)
            {
                if (x.courses.Count == 0)
                {
                    s = $"The {x.name} Isn't enrrolled in any course";
                }
                else
                {

                    for (int i = 0; i < x.courses.Count; i++)
                    {
                        s = $"Student Enrolled in the Course name: {x.courses[i].title} and Course id is: {x.courses[i].courseId}";
                    }
                }

            }
            else
                s = "Student not found";

            return s;

        }




        public Student? FindStudentbyName(string studentname)
        {
            int i;

            for (i = 0; i < students.Count; i++)
            {
                if (students[i].name == studentname)
                    return students[i];

            }
            return null;

        }

        public string? FindInstbycoursename(string coursname)
        {
            string s = string.Empty;
            Courses? x = FindCoursebyName(coursname.ToLower());
            if (x is not null)
            {
                s = $"The instractor name for this course is: {x.nstructor.Name}";
            }
            else
            {
                s = "Course not found";
            }

            return s;


        }


        public Courses? FindCoursebyID(int crsId)
        {
            int i;

            for (i = 0; i < courses.Count; i++)
            {
                if (courses[i].courseId == crsId)
                    return courses[i];

            }

            return null;

        }

        public Courses? FindCoursebyName(string s)
        {
            int i;

            for (i = 0; i < courses.Count; i++)
            {
                if (courses[i].title == s)
                    return courses[i];
            }
            return null;

        }


        public Instructor? FindInstructor(int instId)
        {
            int i;

            for (i = 0; i < instructors.Count; i++)
            {
                if (instructors[i].InstructorId == instId)
                    return instructors[i];

            }
            return null;

        }


        public bool? EnrollStudentInCourse(int studentId, int courseId)
        {

            Student? n = FindStudentbyID(studentId);
            Courses? j = FindCoursebyID(courseId);
            if (FindStudentbyID(studentId) != null && j is not null)
            {
                n.Enrolling(j);
                return true;
            }
            else
            {
                return false;
            }





        }

    }












    internal class Program
    {


        static void Main(string[] args)
        {
            int i;
            School managment = new School();







            string answer;

            do
            {
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("\n1. Add Student ");
                Console.WriteLine("2. Add Instructor ");
                Console.WriteLine("3. Add Course ");
                Console.WriteLine("4. Enroll Student in Course ");
                Console.WriteLine("5. Show All Students ");
                Console.WriteLine("6. Show All Courses ");
                Console.WriteLine("7. Show All Instructors ");
                Console.WriteLine("8. Find the student by id or name");
                Console.WriteLine("9. Fine the course by id or name ");
                Console.WriteLine("10. Check if the student Enrolled in Courses");
                Console.WriteLine("11. Find the Instractor by course Name");
                Console.WriteLine("12. Exit");


                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("Please Chose from the menue ===> ");
                answer = Console.ReadLine();


                if (answer == "1")
                {


                    Console.WriteLine("Enter the name of the student:");
                    string s = Console.ReadLine().ToLower();
                    Console.WriteLine("Enter the age of the student: ");
                    int age = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the student ID: ");
                    int Id = Convert.ToInt32(Console.ReadLine());

                    Student x = new Student(Id, s, age);
                    managment.AddStudent(x);
                    Console.WriteLine("***Student Added Successfuly!!!");

                }
                else if (answer == "2")
                {


                    Console.WriteLine("Enter the name of the Instractor: ");
                    string s = Console.ReadLine();
                    Console.WriteLine("Enter the ID of the Instractor: ");
                    int ID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the Specialization of the Instractor: ");
                    string specializ = Console.ReadLine();

                    Instructor inst = new Instructor(ID, s, specializ);

                    managment.AddInstructor(inst);
                    Console.WriteLine("***Instructor Added Successfuly!!!");


                }

                else if (answer == "3")
                {

                    int q = 0;
                    Console.WriteLine("Enter the ID of the Course: ");
                    int ID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the title of the Course:  ");
                    string s = Console.ReadLine().ToLower();
                    Console.WriteLine("you wants to add Instractor? (yes/No)");
                    string w = Console.ReadLine().ToLower();
                    if (w == "yes")
                    {
                        Console.WriteLine("Enter the name of the Instractor: ");
                        string? l = Console.ReadLine();
                        Console.WriteLine("Enter the ID of the Instractor: ");
                        int Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Specialization of the Instractor: ");
                        string? specializ = Console.ReadLine();

                        if (l is not null && specializ is not null)
                        {
                            Instructor inst = new Instructor(Id, l, specializ);
                            managment.AddInstructor(inst);
                            Courses Cr9 = new Courses(ID, s, inst);
                            managment.AddSCourses(Cr9);
                            Console.WriteLine("****Course addedd Successfully!!");
                        }
                        else
                            Console.WriteLine("invalid answer");
                    }
                    else if (w == "no")
                    {
                        Console.WriteLine("Enter the instractor ID");
                        q = Convert.ToInt32(Console.ReadLine());
                        Instructor? inst1 = managment.FindInstructor(q);
                        if (inst1 != null)
                        {
                            Courses cr8 = new Courses(ID, s, inst1);
                            managment.AddSCourses(cr8);
                            Console.WriteLine("Course addedd Successfully!!");
                        }
                        else
                            Console.WriteLine("Instractor invalid");
                    }











                }

                else if (answer == "4")
                {

                    bool? y;
                    Console.WriteLine("Enter the Student ID: ");
                    int stID = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter the Course ID: ");
                    int crID = Convert.ToInt32(Console.ReadLine());

                    y = managment.EnrollStudentInCourse(stID, crID);
                    if (y == true)
                    {
                        Console.WriteLine("Student Enrolled successfully!!!");
                    }
                    else if (y == false)
                        Console.WriteLine("Invalid add");

                }

                else if (answer == "5")
                {

                    if (managment.students.Count != 0)
                    {

                        Console.WriteLine("the Students in the List is: ");
                        for (i = 0; i < managment.students.Count; i++)
                        {
                            Console.WriteLine($"the student Name is: {managment.students[i].name}");
                            Console.WriteLine($"the student ID is: {managment.students[i].studentID} ");
                            Console.WriteLine($"the student age is: {managment.students[i].age} ");
                            Console.WriteLine("=============================================================");
                        }
                    }
                    else
                        Console.WriteLine("The List is Empty");
                }


                else if (answer == "6")
                {
                    if (managment.courses.Count != 0)

                    {
                        Console.WriteLine("the courses in the List is: ");
                        for (i = 0; i < managment.courses.Count; i++)
                        {
                            Console.WriteLine($"The title of the Course: {i + 1} is: {managment.courses[i].title}");
                            Console.WriteLine($"ThE Course: {i + 1} ID is: {managment.courses[i].courseId}");
                            Console.WriteLine($"The instractor: {i + 1} name is: {managment.courses[i].nstructor.Name}");
                            Console.WriteLine($"The instractor: {i + 1} sepciallization is: {managment.courses[i].nstructor.Specialization}");
                            Console.WriteLine($"The instractor: {i + 1} ID is: {managment.courses[i].nstructor.InstructorId}");


                            Console.WriteLine("=============================================================");
                        }
                    }
                    else
                        Console.WriteLine("The List is Empty");
                }

                else if (answer == "7")
                {
                    if (managment.instructors.Count != 0)
                    {
                        Console.WriteLine("the Instractors in the List is: ");
                        for (i = 0; i < managment.instructors.Count; i++)
                        {
                            Console.WriteLine($"the Instractor: {i + 1} Name is: {managment.instructors[i].Name}");
                            Console.WriteLine($"the Instractor: {i + 1} ID is: {managment.instructors[i].InstructorId}");
                            Console.WriteLine($"the Instractor: {i + 1} Specialization is: {managment.instructors[i].Specialization}");

                            Console.WriteLine("=============================================================");
                        }
                    }
                    else
                        Console.WriteLine("The List is Empty");
                }

                else if (answer == "8")
                {

                    int x;
                    string s;
                    Console.WriteLine("Would u like to search with the: ID or the Name ?");
                    string Index = (Console.ReadLine().ToLower());


                    if (managment.students.Count != 0)
                    {
                        if (Index == "id")
                        {
                            Console.WriteLine("Enter  the ID of the student.");
                            x = Convert.ToInt32(Console.ReadLine());
                            Student? N = managment.FindStudentbyID(x);
                            if (N is not null)
                            {
                                Console.WriteLine(N.Print_Details());
                            }
                            else
                                Console.WriteLine("Invalid Search");
                        }
                        else if (Index == "name")
                        {
                            Console.WriteLine("Enter  the Name of the student.");
                            s = Console.ReadLine().ToLower();
                            Student? N = managment.FindStudentbyName(s);
                            if (N is not null)
                            {
                                Console.WriteLine(N.Print_Details());
                            }
                            else
                                Console.WriteLine("Invalid Search");
                        }



                    }
                    else
                        Console.WriteLine("list is Empty");


                }


                else if (answer == "9")
                {
                    int x;
                    string s;
                    Console.WriteLine("Would u like to search with the: ID or the Name ?");
                    string Index = (Console.ReadLine());


                    if (managment.courses.Count != 0)
                    {
                        if (Index == "ID" || Index == "id")
                        {
                            Console.WriteLine("Enter  the ID of the Course.");
                            x = Convert.ToInt32(Console.ReadLine());
                            Courses N = managment.FindCoursebyID(x);
                            Console.WriteLine(N.PrintDetails());
                        }
                        else if (Index == "Name" || Index == "name")
                        {
                            Console.WriteLine("Enter  the Name of the Course.");
                            s = Console.ReadLine().ToLower();
                            Courses N = managment.FindCoursebyName(s);
                            Console.WriteLine(N.PrintDetails());

                        }



                    }
                    else
                        Console.WriteLine("list is Empty");


                }
                else if (answer == "10")
                {
                    Console.WriteLine("Enter the Student ID");
                    int z = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(managment.FindCourseOfstudent(z));
                }

                else if (answer == "11")
                {
                    Console.WriteLine("Enter the Course Name");
                    string? z = Console.ReadLine().ToLower();

                    Console.WriteLine(managment.FindInstbycoursename(z));
                }





            } while (answer != "12");

            Console.WriteLine("thanks for your time !!");



        }
    }
}

