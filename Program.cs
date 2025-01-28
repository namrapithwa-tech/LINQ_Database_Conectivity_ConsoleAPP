using LINQ_Database_Conectivity_ConsoleAPP;

using System.ComponentModel.DataAnnotations;

var context = new ApplicationDBContext();
Console.WriteLine("LINQ Queries on Projection operators start");
Console.WriteLine("---------------1----------------");
// 1. Display data of all employees.
var allEmployees = context.Employee.ToList();
foreach (var employee in allEmployees)
{
    Console.WriteLine($"AccountNo: {employee.AccountNo}, Name: {employee.FirstName} {employee.LastName}, Email: {employee.Email}, Department: {employee.Department}, Salary: {employee.Salary}, Joining Date: {employee.JoiningDate}");
}
Console.WriteLine("----------------2---------------");

// 2. Select ActNo, FirstName and salary of all employees to a new class and display it.
var employeeDetails = context.Employee.Select(e => new
{
    e.AccountNo,
    e.FirstName,
    e.Salary
}).ToList();
foreach (var detail in employeeDetails)
{
    Console.WriteLine($"AccountNo: {detail.AccountNo}, FirstName: {detail.FirstName}, Salary: {detail.Salary}");
}
Console.WriteLine("----------------3---------------");

// 3. Display data in following format => {Anil} works in {Admin} Department.
var employeeDepartments = context.Employee.Select(e => new
{
    e.FirstName,
    e.Department
}).ToList();
foreach (var ed in employeeDepartments)
{
    Console.WriteLine($"{ed.FirstName} works in {ed.Department} Department.");
}
Console.WriteLine("----------------4---------------");

// 4. Select Employee Full Name, Email and Department as anonymous and display it.
var employeeAnonymous = context.Employee.Select(e => new
{
    FullName = e.FirstName + " " + e.LastName,
    e.Email,
    e.Department
}).ToList();
foreach (var ea in employeeAnonymous)
{
    Console.WriteLine($"Full Name: {ea.FullName}, Email: {ea.Email}, Department: {ea.Department}");
}
Console.WriteLine("----------------5---------------");

// 5. Display employees with their joining date.
var employeeJoiningDates = context.Employee.Select(e => new
{
    e.FirstName,
    e.LastName,
    e.JoiningDate
}).ToList();
foreach (var ejd in employeeJoiningDates)
{
    Console.WriteLine($"{ejd.FirstName} {ejd.LastName} joined on {ejd.JoiningDate?.ToShortDateString()}");
}
Console.WriteLine("LINQ Queries on Projection operators end");
Console.WriteLine("  ");
Console.WriteLine("  ");
Console.WriteLine("LINQ Queries on Filtering operators start");
Console.WriteLine("-----------------6--------------");
// 6. Display employees between age 20 to 30.
var employeesAge20To30 = context.Employee.Where(e => e.Age >= 20 && e.Age <= 30).ToList();
foreach (var employee in employeesAge20To30)
{
    Console.WriteLine($"AccountNo: {employee.AccountNo}, Name: {employee.FirstName} {employee.LastName}, Age: {employee.Age}");
}
Console.WriteLine("-----------------7--------------");

// 7. Display female employees.
var femaleEmployees = context.Employee.Where(e => e.Gender == "Female").ToList();
foreach (var employee in femaleEmployees)
{
    Console.WriteLine($"AccountNo: {employee.AccountNo}, Name: {employee.FirstName} {employee.LastName}, Gender: {employee.Gender}");
}
Console.WriteLine("-----------------8--------------");

// 8. Display employees with salary more than 35000.
var employeesSalaryMoreThan35000 = context.Employee.Where(e => e.Salary > 35000).ToList();
foreach (var employee in employeesSalaryMoreThan35000)
{
    Console.WriteLine($"AccountNo: {employee.AccountNo}, Name: {employee.FirstName} {employee.LastName}, Salary: {employee.Salary}");
}
Console.WriteLine("-----------------9--------------");

// 9. Display employees whose account no is less than 110.
var employeesAccountNoLessThan110 = context.Employee.Where(e => e.AccountNo < 110).ToList();
foreach (var employee in employeesAccountNoLessThan110)
{
    Console.WriteLine($"AccountNo: {employee.AccountNo}, Name: {employee.FirstName} {employee.LastName}");
}
Console.WriteLine("-----------------10--------------");

// 10. Display employees who belong to either Rajkot or Morbi city.
var employeesRajkotOrMorbi = context.Employee.Where(e => e.City == "Rajkot" || e.City == "Morbi").ToList();
foreach (var employee in employeesRajkotOrMorbi)
{
    Console.WriteLine($"AccountNo: {employee.AccountNo}, Name: {employee.FirstName} {employee.LastName}, City: {employee.City}");
}
Console.WriteLine("-----------------11--------------");

// 11. Display employees whose salary is less than 20000.
var employeesSalaryLessThan20000 = context.Employee.Where(e => e.Salary < 20000).ToList();
foreach (var employee in employeesSalaryLessThan20000)
{
    Console.WriteLine($"AccountNo: {employee.AccountNo}, Name: {employee.FirstName} {employee.LastName}, Salary: {employee.Salary}");
}
Console.WriteLine("----------------12---------------");

// 12. Display employees whose salary is more than equal to 30000 and less than equal to 60000.
var employeesSalaryBetween30000And60000 = context.Employee.Where(e => e.Salary >= 30000 && e.Salary <= 60000).ToList();
foreach (var employee in employeesSalaryBetween30000And60000)
{
    Console.WriteLine($"AccountNo: {employee.AccountNo}, Name: {employee.FirstName} {employee.LastName}, Salary: {employee.Salary}");
}
Console.WriteLine("----------------13---------------");

// 13. Display ActNo, FirstName and Amount of employees who belong to Morbi or Ahmedabad or Surat city and Account No greater than 120.
var employeesSpecificCitiesAndAccountNo = context.Employee
    .Where(e => (e.City == "Morbi" || e.City == "Ahmedabad" || e.City == "Surat") && e.AccountNo > 120)
    .Select(e => new { e.AccountNo, e.FirstName, e.Salary })
    .ToList();
foreach (var employee in employeesSpecificCitiesAndAccountNo)
{
    Console.WriteLine($"AccountNo: {employee.AccountNo}, FirstName: {employee.FirstName}, Salary: {employee.Salary}");
}
Console.WriteLine("----------------14---------------");

// 14. Display male employees of age between 30 to 35 and belongs to Rajkot city.
var maleEmployeesAge30To35Rajkot = context.Employee.Where(e => e.Gender == "Male" && e.Age >= 30 && e.Age <= 35 && e.City == "Rajkot").ToList();
foreach (var employee in maleEmployeesAge30To35Rajkot)
{
    Console.WriteLine($"AccountNo: {employee.AccountNo}, Name: {employee.FirstName} {employee.LastName}, Age: {employee.Age}, City: {employee.City}");
}
Console.WriteLine("-----------------15--------------");

// 15. Display Unique Cities. (use Distinct())
var uniqueCities = context.Employee.Select(e => e.City).Distinct().ToList();
foreach (var city in uniqueCities)
{
    Console.WriteLine($"City: {city}");
}
Console.WriteLine("----------------16---------------");

// 16. Display employees whose joining is between 15/07/2018 to 16/09/2019.
DateTime startDate = new DateTime(2018, 7, 15);
DateTime endDate = new DateTime(2019, 9, 16);

var filteredEmployees = context.Employee.Where(e => e.JoiningDate >= startDate && e.JoiningDate <= endDate);

foreach (var employee in filteredEmployees)
{
    Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}, Joining Date: {employee.JoiningDate}");
}

Console.WriteLine("----------------17---------------");

// 17. Display female employees who work in Sales department.
var femaleEmployeesSales = context.Employee.Where(e => e.Gender == "Female" && e.Department == "Sales").ToList();
foreach (var employee in femaleEmployeesSales)
{
    Console.WriteLine($"AccountNo: {employee.AccountNo}, Name: {employee.FirstName} {employee.LastName}, Department: {employee.Department}");
}
Console.WriteLine("---------------18----------------");

// 18. Display employees with their Age who belong to Rajkot city and more than 35 years old.
var employeesRajkotMoreThan35 = context.Employee.Where(e => e.City == "Rajkot" && e.Age > 35).ToList();
foreach (var employee in employeesRajkotMoreThan35)
{
    Console.WriteLine($"AccountNo: {employee.AccountNo}, Name: {employee.FirstName} {employee.LastName}, Age: {employee.Age}, City: {employee.City}");
}
Console.WriteLine("LINQ Queries on Filtering operators end");
Console.WriteLine("  ");
Console.WriteLine("  ");

Console.WriteLine("LINQ Queries on Aggregate start");
// 19. Find total salary and display it.
Console.WriteLine("---------------19----------------");
var totalSalary = context.Employee.Sum(e => e.Salary);
Console.WriteLine($"Total Salary: {totalSalary}");
Console.WriteLine("---------------20----------------");

// 20. Find total number of employees of Admin department who belongs to Rajkot city.
var adminRajkotCount = context.Employee
    .Count(e => e.Department == "Admin" && e.City == "Rajkot");
Console.WriteLine($"Total Admin Employees in Rajkot: {adminRajkotCount}");
Console.WriteLine("---------------21----------------");

// 21. Find total salary of Distribution department.
var totalDistributionSalary = context.Employee
    .Where(e => e.Department == "Distribution")
    .Sum(e => e.Salary);
Console.WriteLine($"Total Salary of Distribution Department: {totalDistributionSalary}");
Console.WriteLine("---------------22----------------");

// 22. Find average salary of IT department.
var averageITSalary = context.Employee
    .Where(e => e.Department == "IT")
    .Average(e => e.Salary);
Console.WriteLine($"Average Salary of IT Department: {averageITSalary}");
Console.WriteLine("---------------23----------------");

// 23. Find minimum salary of Customer Relationship department.
var minCustomerRelationshipSalary = context.Employee
    .Where(e => e.Department == "Customer Relationship")
    .Min(e => e.Salary);
Console.WriteLine($"Minimum Salary of Customer Relationship Department: {minCustomerRelationshipSalary}");
Console.WriteLine("-----------------24--------------");

// 24. Find maximum salary of Distribution department who belongs to Baroda city.
var maxDistributionBarodaSalary = context.Employee
    .Where(e => e.Department == "Distribution" && e.City == "Baroda")
    .Max(e => e.Salary);
Console.WriteLine($"Maximum Salary of Distribution Department in Baroda: {maxDistributionBarodaSalary}");
Console.WriteLine("-----------------25--------------");

// 25. Find number of employees whose Age is more than 40.
var employeesOver40Count = context.Employee
    .Count(e => e.Age > 40);
Console.WriteLine($"Number of Employees over 40: {employeesOver40Count}");
Console.WriteLine("-----------------26--------------");

// 26. Find total female employees working in Ahmedabad city.
var femaleAhmedabadCount = context.Employee
    .Count(e => e.Gender == "Female" && e.City == "Ahmedabad");
Console.WriteLine($"Total Female Employees in Ahmedabad: {femaleAhmedabadCount}");
Console.WriteLine("------------------27-------------");

// 27. Find total salary of male employees who belongs to Gandhinagar city and works in IT department.
var totalMaleITGandhinagarSalary = context.Employee
    .Where(e => e.Gender == "Male" && e.City == "Gandhinagar" && e.Department == "IT")
    .Sum(e => e.Salary);
Console.WriteLine($"Total Salary of Male IT Employees in Gandhinagar: {totalMaleITGandhinagarSalary}");
Console.WriteLine("------------------28-------------");

// 28. Find average salary of male employees whose age is between 21 to 35.
var averageMaleSalary21to35 = context.Employee
    .Where(e => e.Gender == "Male" && e.Age >= 21 && e.Age <= 35)
    .Average(e => e.Salary);
Console.WriteLine($"Average Salary of Male Employees aged 21 to 35: {averageMaleSalary21to35}");
Console.WriteLine("LINQ Queries on Aggregate end");
Console.WriteLine("  ");
Console.WriteLine("  ");

Console.WriteLine("LINQ Queries on Sorting start");
// 29. Display employees by their first name in ascending order.
Console.WriteLine("---------------29----------------");
var employeesByFirstNameAsc = context.Employee
    .OrderBy(e => e.FirstName)
    .ToList();
Console.WriteLine("Employees by First Name (Ascending):");
employeesByFirstNameAsc.ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName}"));
Console.WriteLine("----------------30---------------");

// 30. Display employees by department name in descending order.
var employeesByDepartmentDesc = context.Employee
    .OrderByDescending(e => e.Department)
    .ToList();
Console.WriteLine("Employees by Department Name (Descending):");
employeesByDepartmentDesc.ForEach(e => Console.WriteLine($"{e.Department}: {e.FirstName} {e.LastName}"));
Console.WriteLine("-----------------31--------------");

// 31. Display employees by department name descending and first name in ascending order.
var employeesByDeptDescFirstNameAsc = context.Employee
    .OrderByDescending(e => e.Department)
    .ThenBy(e => e.FirstName)
    .ToList();
Console.WriteLine("Employees by Department Name (Descending) and First Name (Ascending):");
employeesByDeptDescFirstNameAsc.ForEach(e => Console.WriteLine($"{e.Department}: {e.FirstName} {e.LastName}"));
Console.WriteLine("------------------32-------------");

// 32. Display employees by their first name in ascending order and last name in descending order.
var employeesByFirstNameAscLastNameDesc = context.Employee
    .OrderBy(e => e.FirstName)
    .ThenByDescending(e => e.LastName)
    .ToList();
Console.WriteLine("Employees by First Name (Ascending) and Last Name (Descending):");
employeesByFirstNameAscLastNameDesc.ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName}"));
Console.WriteLine("------------------33-------------");

// 33. Display employees by their Joining Date using Reverse() operator.
var employeesByJoiningDate = context.Employee
    .OrderBy(e => e.JoiningDate)
    .Reverse()
    .ToList();
Console.WriteLine("Employees by Joining Date (Reversed):");
employeesByJoiningDate.ForEach(e => Console.WriteLine($"{e.JoiningDate}: {e.FirstName} {e.LastName}"));
Console.WriteLine("-------------------------------");

Console.WriteLine("LINQ Queries on Sorting end");