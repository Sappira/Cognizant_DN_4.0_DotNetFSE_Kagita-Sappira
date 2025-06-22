using System;

// Model
public class Student
{
    public string Name { get; set; }
    public string Id { get; set; }
    public string Grade { get; set; }
}

// View
public class StudentView
{
    public void DisplayStudentDetails(Student student)
    {
        Console.WriteLine("Student Details:");
        Console.WriteLine($"Name  : {student.Name}");
        Console.WriteLine($"ID    : {student.Id}");
        Console.WriteLine($"Grade : {student.Grade}");
    }
}

// Controller
public class StudentController
{
    private readonly Student _student;
    private readonly StudentView _view;

    public StudentController(Student student, StudentView view)
    {
        _student = student;
        _view = view;
    }

    public void SetStudentName(string name) => _student.Name = name;
    public void SetStudentId(string id) => _student.Id = id;
    public void SetStudentGrade(string grade) => _student.Grade = grade;

    public void UpdateView() => _view.DisplayStudentDetails(_student);
}

// Main
public class Program
{
    public static void Main(string[] args)
    {
        Student student = new Student { Name = "varsha", Id = "CSE123", Grade = "A" };
        StudentView view = new StudentView();
        StudentController controller = new StudentController(student, view);

        controller.UpdateView();

        // Updating model via controller
        controller.SetStudentName("Sappira");
        controller.SetStudentGrade("A+");

        Console.WriteLine("\nAfter updating student:");
        controller.UpdateView();
    }
} 
