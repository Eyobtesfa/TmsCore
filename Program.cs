string? region = null;

//Null-conditional operator '?.' skips calling ToUpper() if region is null, preventing a NullReferenceException.
string? upperRegion = region?.ToUpper();
Console.WriteLine($"Region (conditional):{upperRegion}");

//Null-coalescing operator '??' provides a default value ("Unassigned") if region is null, ensuring displayRegion is never null.
string displayRegion = region ?? "Unassigned";
Console.WriteLine($"Region (null-coalescing): {displayRegion}");

//Null-coalescing assignment operator '??=' assigns "Addis Ababa" to region only if it is currently null, ensuring region has a value for subsequent use.
region ??= "Addis Ababa";
Console.WriteLine($"Region (assigned): {region}");



string studentName = "Abeba";
string studentId = "STU-001";
int enrollmentCount = 3;
decimal grantAmount = 1999.99m;//m suffix indicates a decimal literal
DateTime enrolledAt = DateTime.UtcNow;
string? campusRegion = null;


Console.WriteLine("\n ----Declaring TMS Variables----");
Console.WriteLine($"Student:{studentName}({studentId})");
Console.WriteLine($"Courses:{enrollmentCount}");
Console.WriteLine($"Grant Amount: {grantAmount:F2}");//F2 formats the decimal to 2 decimal places
Console.WriteLine($"Enrolled At: {enrolledAt:yyyy-MM-dd HH:mm:ss}");//Custom date format
Console.WriteLine($"Campus Region: {campusRegion ?? "Not Assigned"}");//Using null



//==============================================
//EXERCISE 2: The Ministry Audit Failure
//==============================================

//The Bug

double grantPerStudent = 1999.99;
double totalAllocation = grantPerStudent * 100_000;

Console.WriteLine($"Total Allocation(double): {totalAllocation}");

decimal grantPerStudentDecimal = 1999.99m;
decimal totalAllocationDecimal = grantPerStudentDecimal * 100_000m;

Console.WriteLine($"Total Allocation(decimal): {totalAllocationDecimal}");
Console.WriteLine($"Total Allocation(formatted): {totalAllocationDecimal:F2}");//F2 formats the decimal to 2 decimal places


//===============================================
//EXERCISE 3: Pipeline Data Corruption and Validation
//===============================================

var enrollment = new EnrollmentRecord("STU-001", "CS101", DateTime.UtcNow);
var correctedEnrollment = enrollment with { CourseCode = "CS102" };//Using 'with' expression to create a new record with modified CourseCode
Console.WriteLine($"Enrollment Record: {enrollment}");
Console.WriteLine($"Corrected Enrollment Record: {correctedEnrollment}");
Console.WriteLine($"SameData?{enrollment == correctedEnrollment}");//Comparing the original and corrected records for equality

var course = new Course
{
    Code = "CS101",
    Title = "Introduction to Computer Science",
    Capacity = 30,
    EnrolledCount = 25
};

Console.WriteLine($"Course: {course.Code} - {course.Title}, Capacity: {course.Capacity}, Enrolled: {course.EnrolledCount}");

try
{
    course.Title = "";//This will throw an exception due to the validation logic in the setter
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error updating course title: {ex.Message}");
}

try
{
    course.Capacity = -5;//This will throw an exception due to the validation logic in the setter
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Error updating course capacity: {ex.Message}");
}

try
{
    var student2 = new Student
    {
        Id = "STU-002",
        Name = "Kebede",
        Age = 120,
        GPA = 3.5m
    };
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Error creating student: {ex.Message}");
}


//===============================================
//EXERCISE 3B: Interface Contact Wiring
//==============================================

void PrintGradeReport(IEnumerable<IGradable> assessments)
{
    Console.WriteLine("\nGrade Report:");
    foreach (var assessment in assessments)
    {
        Console.WriteLine($"{assessment.Title}: {assessment.CalculateGrade():F2}%");
    }
}

//Test Array if if can hold two different types
IGradable[] assess = [
    new Quiz { Title = "Quiz 1", CorrectAnswers = 85, TotalQuestions = 100 },
    new LabAssignment { Title = "Lab 1", FunctionalityScore = 90m, CodeQualityScore = 85m }
];
PrintGradeReport(assess);