// See https://aka.ms/new-console-template for more information
using System;

namespace myProject
{
    class Program
    {
        static void Main(string[] args)
        {
            printFaculties(MatricNoGenerator.getAllFaculties());

            Console.Write("Select facultyCode: ");

            int facultyCode = Convert.ToInt32(Console.ReadLine());

            printDepartments(MatricNoGenerator.filterDepartments(facultyCode));

            Console.Write("Select DeptCode: ");

            int deptCode = Convert.ToInt32(Console.ReadLine());


            string matricNumber = new MatricNoGenerator(facultyCode, deptCode).generateMatricNo();
        
            Console.WriteLine(matricNumber);  
            
        }
        static void printFaculties(List<Faculty> dialog)
        {
            Console.WriteLine("Faculty Name\t\t\tFaculty Code");
            foreach(Faculty element in dialog)
            {
                Console.WriteLine($"{element.getName()}\t\t\t\t{element.getCode()}");
            }
        }
        static void printDepartments(List<Department> dialog)
        {
            Console.WriteLine("Dept. Name\t\t\t\t\tDept. Code");
            foreach(Department element in dialog)
            {
                Console.WriteLine($"{element.getName()}\t\t\t\t{element.getCode()}");
            }
        }
    }


    class MatricNoGenerator
    {
        static int counter = 0;
        int year = 23;
        int facultyCode, departmentCode;

        public static List<Faculty> getAllFaculties()
        {
            List<Faculty> newFaculties = new List<Faculty>();
            foreach (Faculty faculty in faculties)
            {
                newFaculties.Add(faculty);

            } 
               
            return newFaculties;
        }

        public static Faculty [] faculties = {
            new Faculty("Science       ", 1),
            new Faculty("Engineering   ", 2),
            new Faculty("Social Science", 3),
            new Faculty("Arts          ", 4)
        };

        static Department [] departments = {
            new Department("Computer Science", 1, 1),
            new Department("fishery         ", 5, 1),
            new Department("metallurgy      ", 4, 2),
            new Department("physiology      ", 3, 3)
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="facultyCode"></param>
        /// <param name="departmentCode"></param>

        public MatricNoGenerator(int facultyCode, int departmentCode)
        {
          this.facultyCode = facultyCode;
          this.departmentCode = departmentCode;
        }

        public static List<Department> filterDepartments(int facultyCode){
            List<Department> newDepartments = new List<Department>();

            newDepartments = departments.Where(department => 
            department.getFacultyCode() == facultyCode).ToList();
            return newDepartments;
        }

        public string generateMatricNo()
        {
            counter++;
            return $"{year}--{facultyCode}--{departmentCode}--{counter}";
        }
        
    }


    public abstract class School
    {
        protected string name;
        protected int code;
        protected School(string name, int code)
        {
            this.name = name;
            this.code = code;
        }

        public abstract string getName();
        public abstract int getCode();

    }
    public class Faculty:School
    {
       
        public Faculty(string name, int code):base(name, code)
        {
        }
        public override string getName()
        {
            return name;
        }

        public override int getCode()
        {
            return code;
        }
    }

    public class Department: School
    {
        private int facultyCode;
        public Department(string name, int code, int facultyCode) : base(name, code)
        {
            this.facultyCode = facultyCode;
        }

        public override string getName()
        {
            return name;
        }

        public override int getCode()
        {
            return code;
        }

        public int getFacultyCode(){
            return facultyCode;
        }
    }


    
}
