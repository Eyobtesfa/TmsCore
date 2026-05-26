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
