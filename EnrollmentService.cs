public class EnrollmentService
{
    public EnrollmentRecord ProcessRegistration(Student? student, Course? course)
    {
        //Guard clauses to validate input parameters and ensure business rules are met before processing the enrollment
        if (student == null)
        {
            throw new ArgumentNullException(nameof(student), "Student cannot be null.");
        }
        if (course == null)
        {
            throw new ArgumentNullException(nameof(course), "Course cannot be null.");
        }
        if (course.EnrolledCount >= course.Capacity)
        {
            throw new InvalidOperationException("Course is at full capacity.");
        }

        //Switch expression to classify students academic standing
        string standing = student.GPA switch
        {
            >= 3.5m => "Honors",
            >= 2.5m => "Good Standing",
            < 2.5m => "Academic Warning"
        };
        Console.WriteLine($"Student {student.Name} is classified as: {standing}");

        //Return a new enrollment record using a record type to ensure immutability and value-based equality
        return new EnrollmentRecord(student.Id, course.Code, DateTime.UtcNow);
    }
}