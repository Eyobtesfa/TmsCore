/*using System.ComponentModel.Design;

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


//==============================================
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


//===============================================
//EXERCISE 4: Enrollment Service Testing
//===============================================

var service = new EnrollmentService();
// Test 1: Valid enrollment
var validStudent = new Student
{
    Id = "S1",
    Name = "Alice",
    Age = 20,
    GPA = 3.5m
};
var validCourse = new Course
{
    Code = "CS-401",
    Title = "Advanced Programming",
    Capacity = 30,
};
var result = service.ProcessRegistration(validStudent, validCourse);
Console.WriteLine($"Enrolled: {result.StudentId} in {result.CourseCode} at {result.EnrolledAt:yyyy-MM-dd HH:mm:ss}");
//Test 2: Null student
try
{
    service.ProcessRegistration(null, validCourse);
}
catch (ArgumentNullException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
//Test 3: Full course
var fullCourse = new Course
{
    Code = "CS-402",
    Title = "Data Structures",
    Capacity = 30,
};
fullCourse.EnrolledCount = 30; // Simulate a full course
try
{
    service.ProcessRegistration(validStudent, fullCourse);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

//=============================================
//EXERCISE 5: The Analytics Dashboard
//=============================================

List<Student> students = [
    new Student { Id = "S1", Name = "Abeba", Age = 22, GPA = 3.8m },
    new Student { Id = "S2", Name = "Kidane", Age = 19, GPA = 2.4m },
    new Student { Id = "S3", Name = "Dawit", Age = 20, GPA = 3.1m },
    new Student { Id = "S4", Name = "Sara", Age = 23, GPA = 3.9m },
    new Student { Id = "S5", Name = "Mariam", Age = 21, GPA = 2.0m },
    new Student { Id = "S6", Name = "Yohannes", Age = 24, GPA = 3.2m },
    new Student { Id = "S7", Name = "Lily", Age = 18, GPA = 3.0m },
    new Student { Id = "S8", Name = "Elias", Age = 22, GPA = 2.8m },
];

var leaderBoard = students
    .Where(s => s.GPA >= 3.5m)
    .OrderByDescending(s => s.GPA)
    .Select(s => s.Name)
    .ToList();

Console.WriteLine($"fOUND {leaderBoard.Count} HONORS STUDENTS:");
foreach (var name in leaderBoard)
{
    Console.WriteLine(name);
}

decimal averageGPA = students.Average(s => s.GPA);
Console.WriteLine($"Average GPA: {averageGPA:F2}");

var standingGroup = students.GroupBy(s => s.GPA switch
{
    >= 3.5m => "Honors",
    >= 2.5m => "Good Standing",
    < 2.5m => "Academic Warning"
});

Console.WriteLine("\nStudent Standing Groups:");
foreach (var group in standingGroup)
{
    Console.WriteLine($"\n{group.Key}({group.Count()}):");
    foreach (var s in group)
    {
        Console.WriteLine($"  - {s.Name} GPA: {s.GPA}");
    }
}

string[] backendCourses = ["C#", "Java", "Python", "Go"];
string[] frontendCourses = ["JavaScript", "TypeScript", "React", "Angular"];
string[] fullstackCourses = [.. backendCourses, .. frontendCourses, "Capstone"];

Console.WriteLine($"\nFullstack Curriculum: {string.Join(", ", fullstackCourses)}");

*/

//===============================================
//EXERCISE 6: ASYNC/AWAIT
//===============================================

using System.Diagnostics;

var sw = Stopwatch.StartNew();
for (int i = 0; i < 5; i++)
{
    Thread.Sleep(300);
}
Console.WriteLine($"Blocking Sequential: {sw.ElapsedMilliseconds}ms");


sw.Restart();

for (int i = 0; i < 5; i++)
{
    await Task.Delay(300);
}
Console.WriteLine($"Async Sequential: {sw.ElapsedMilliseconds}ms");

sw.Restart();

var tasks = Enumerable.Range(0, 5).Select(_ => Task.Delay(300));
await Task.WhenAll(tasks);
Console.WriteLine($"Async Parallel: {sw.ElapsedMilliseconds}ms");

//Simulates Loading a Student from a database
async Task<Student> FetchStudentAsync(string id)
{
    Console.WriteLine($"Fetching student {id}..");
    await Task.Delay(300);
    return new Student
    {
        Id = id,
        Name = $"Student -{id}",
        Age = 20,
        GPA = id switch
        {
            "S1" => 3.8m,
            "S2" => 2.4m,
            "S3" => 3.5m,
            "S4" => 1.9m,
            "S5" => 3.2m,
            _ => 2.5m
        }
    };
}

//Simulates Fetching a course
async Task<Course> FetchCourseAsync(string code)
{
    Console.WriteLine($"Fetching course {code}..");
    await Task.Delay(300);
    return new Course
    {
        Code = code,
        Title = $"Course -{code}",
        Capacity = code switch
        {
            "CRS-101" => 2,
            "CRS-201" => 30,
            "CRS-301" => 15,
            _ => 25
        }
    };
}

sw.Restart();

string[] studentIds = ["S1", "S2", "S3", "S4", "S5"];
string[] courseCodes = ["CRS-101", "CRS-201", "CRS-301"];

var studentTasks = studentIds.Select(id => FetchStudentAsync(id));
var courseTasks = courseCodes.Select(code => FetchCourseAsync(code));

Student[] students = await Task.WhenAll(studentTasks);
Course[] courses = await Task.WhenAll(courseTasks);

Console.WriteLine($"\nLoaded {students.Length} students and {courses.Length} courses in {sw.ElapsedMilliseconds}ms");


foreach (var s in students)
{
    Console.WriteLine($"{s.Name} GPA:{s.GPA}");
}

//EXERCISE 6 PART B: Async Enrollment Processing

Console.WriteLine("Async Enrollment Processing");
var enrollCourse = new Course { Code = "CRS-101", Title = "Intro to Async", Capacity = 2 };
var enrollService = new EnrollmentService();
var enrollments = new List<EnrollmentRecord>();

var failures = new List<string>();

sw.Restart();

foreach (var student in students)
{
    try
    {
        var record = enrollService.ProcessRegistration(student, enrollCourse);
        enrollCourse.EnrolledCount++;
        enrollments.Add(record);
        Console.WriteLine($"Enrolled :{student.Name}");
    }
    catch (InvalidOperationException ex)
    {
        failures.Add($"Failed to enroll {student.Name}: {ex.Message}");
        Console.WriteLine($"Failed to enroll {student.Name}: {ex.Message}");
    }
}

/*async Task<SendConfirmationAsync>(Student student)
{
    try
    {
        await Task.Delay(100);
        Console.WriteLine($"Confirmation sent to {student.Name}");

    }catch (Exception ex)
    {
        Console.WriteLine($"Failed to send confirmation to {student.Name}: {ex.Message}");
    }
}*/

//EXERCISE 7: The Unhelpful Crash

