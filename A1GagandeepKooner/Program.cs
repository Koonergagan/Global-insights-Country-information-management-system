using ConsoleTables;

namespace A1GagandeepKooner
{
    internal class Program
    {
        static LinkedList<Employee> employees = new LinkedList<Employee>();
        static int nextEmployeeId = 1;
        static void Main(string[] args)
        {
            PopulatingList();
            while (true)
            {
                DisplayFirstMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        EditEmployee();
                        break;
                    case "3":
                        DeleteEmployee();
                        break;
                    case "4":
                        ViewEmployee();
                        break;
                    case "5":
                        SearchEmployee();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid Entry. Please select options only from above menu");
                        break;



                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(); // Wait for user input to continue
                Console.Clear();
            }
        }

        static void DisplayFirstMenu()
        {
            Console.WriteLine("1. Add an Employee");
            Console.WriteLine("2. Edit Employee");
            Console.WriteLine("3. Delete Employee");
            Console.WriteLine("4. View Employee");
            Console.WriteLine("5. Search Employee");
            Console.WriteLine("6. Exit");
         
        }
        static void PopulatingList()
        {
            EmployeeType empType;
            employees.AddLast(new HourlyEmployee(nextEmployeeId++, EmployeeType.HourlyEmployee, "Gagandeep", 20, 24));
            employees.AddLast(new SalariedEmployee(nextEmployeeId++, EmployeeType.SalariedEmployee, "Jashan", 1000));
            employees.AddLast(new CommissionEmployee(nextEmployeeId++, EmployeeType.CommissionEmployee, "Bhullar", 10000, .3));
            employees.AddLast(new SalaryPlusCommissionEmployee(nextEmployeeId++, EmployeeType.SalaryPlusCommissionEmployee, "Arshdeep", 20000, .1, 1000));        }
        static void AddEmployee()
        {
            Console.WriteLine("1.Add Hourly Employee");
            Console.WriteLine("2.Add Commission Employee");
            Console.WriteLine("3.Add Salaried Emloyee");
            Console.WriteLine("4.Add Salary plus Commission Employee: ");
            Console.WriteLine("5.Back to Main Menu");
            String choice = Console.ReadLine();
            if(int.Parse(choice) <1 || int.Parse(choice) > 5) { Console.WriteLine("please enter a number between 1 to 5");
            }
            Employee employee = null;
            EmployeeType empType;
            switch(choice)
            {
                case "1":

                   empType = EmployeeType.HourlyEmployee;
                   // employee = new HourlyEmployee(nextEmployeeId++, " ", 0, 0) { empType = EmployeeType.HourlyEmployee };
                    Console.WriteLine("Enter name of the employee: ");
                    string empName = Console.ReadLine();
                    Console.WriteLine("Enter Hourly Wage :");
                    double wageRate = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Number of Hours:");
                    int numOfHours = int.Parse(Console.ReadLine());
                    employee = new HourlyEmployee(nextEmployeeId++, empType, empName, numOfHours, wageRate);
                    employees.AddLast(employee);
                    Console.WriteLine("Employee Addedd Successfully");
                    break;
                case "2":
                    empType = EmployeeType.CommissionEmployee;
                    Console.WriteLine("Enter name of the employee: ");
                    string empName1 = Console.ReadLine();
                    Console.WriteLine("Enter Gross Sales: ");
                    double grossSales = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Commission rate: ");
                    double comRate = double.Parse(Console.ReadLine());
                    employee = new CommissionEmployee(nextEmployeeId++, empType,empName1,grossSales, comRate);
                    employees.AddLast(employee);
                    Console.WriteLine("Employee Addedd Successfully");
                    break;
                case "3":
                    empType = EmployeeType.SalariedEmployee;
                    Console.WriteLine("Enter name of the employee: ");
                    string empName2 = Console.ReadLine();
                    Console.WriteLine("Enter weekly Salary: ");
                    double weeklySalary = double.Parse(Console.ReadLine());
                    
                    employee = new SalariedEmployee(nextEmployeeId++, empType, empName2,weeklySalary);
                    employees.AddLast(employee);
                    Console.WriteLine("Employee Addedd Successfully");
                    break;
                case "4":
                    empType = EmployeeType.SalaryPlusCommissionEmployee;
                    Console.WriteLine("Enter name of the employee: ");
                    string empName3 = Console.ReadLine();
                    Console.WriteLine("Enter Gross Sales: ");
                    double grossales1 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Salary:");
                    double salary = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Commission rate: ");
                    double comRate1 = double.Parse(Console.ReadLine());
                    employee = new SalaryPlusCommissionEmployee(nextEmployeeId++, empType, empName3,grossales1, salary, comRate1);
                    employees.AddLast(employee);
                    Console.WriteLine("Employee Addedd Successfully");
                    break;
                    case "5":
                    return;
                    default:
                    Console.WriteLine("invalid input");
                    break;



            }
            ViewEmployee();
        }
        static void EditEmployee()
        {
            Console.WriteLine("Select the type to edit:");
            Console.WriteLine("1. Hourly Employee");
            Console.WriteLine("2. Commission Employee");
            Console.WriteLine("3. Salaried Employee");
            Console.WriteLine("4. Salary Plus Commission Employee");
            String choice = Console.ReadLine();
            EmployeeType empType;
            switch (choice)
            {
                case "1":
                    empType = EmployeeType.HourlyEmployee;
                    ViewEmployeeByType(empType);
                    break;
                case "2":
                    empType = EmployeeType.CommissionEmployee;
                    ViewEmployeeByType(empType);
                    break;
                    case "3":
                    empType = EmployeeType.SalariedEmployee;
                        ViewEmployeeByType(empType);
                    break;
                    case "4":
                    empType = EmployeeType.SalaryPlusCommissionEmployee;
                    ViewEmployeeByType(empType);
                    break;
                default:
                    Console.WriteLine("invalid coice.");
                    return;
            
            }
            
            Console.WriteLine($"Employees of type: {empType}");
            var employeesOfType = employees.Where(e => e.TypeofEmployee == empType).ToList();

            if (!employeesOfType.Any())
            {
                Console.WriteLine("No employees found for the specified type.");
                return;
            }

            foreach (var emp in employeesOfType)
            {
                Console.WriteLine(emp);
            }

            // Ask for the Employee ID to edit
            Console.WriteLine("Enter the Employee ID to edit:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID format. Returning to main menu.");
                return;
            }

            var employeeToEdit = employeesOfType.FirstOrDefault(e => e.EmployeeId == id);
            if (employeeToEdit == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            // Ask for new information
            Console.WriteLine("Enter new name of the employee:");
            employeeToEdit.Name1 = Console.ReadLine();

            switch (empType)
            {
                case EmployeeType.HourlyEmployee:
                    var hourly = employeeToEdit as HourlyEmployee;
                    if (hourly != null)
                    {
                        Console.WriteLine("Enter new hourly wage:");
                        if (!double.TryParse(Console.ReadLine(), out double hourlyWage))
                        {
                            Console.WriteLine("Invalid wage format. Returning to main menu.");
                            return;
                        }
                        hourly.Wage = hourlyWage;

                        Console.WriteLine("Enter new number of hours:");
                        if (!int.TryParse(Console.ReadLine(), out int hours))
                        {
                            Console.WriteLine("Invalid hours format. Returning to main menu.");
                            return;
                        }
                        hourly.Hours = hours;
                    }
                    break;

                case EmployeeType.CommissionEmployee:
                    var commission = employeeToEdit as CommissionEmployee;
                    if (commission != null)
                    {
                        Console.WriteLine("Enter new gross sales:");
                        if (!double.TryParse(Console.ReadLine(), out double grossSales))
                        {
                            Console.WriteLine("Invalid gross sales format. Returning to main menu.");
                            return;
                        }
                        commission.GrossSales = grossSales;

                        Console.WriteLine("Enter new commission rate:");
                        if (!double.TryParse(Console.ReadLine(), out double commissionRate))
                        {
                            Console.WriteLine("Invalid commission rate format. Returning to main menu.");
                            return;
                        }
                        commission.CommissionRate = commissionRate;
                    }
                    break;

                case EmployeeType.SalariedEmployee:
                    var salaried = employeeToEdit as SalariedEmployee;
                    if (salaried != null)
                    {
                        Console.WriteLine("Enter new weekly salary:");
                        if (!double.TryParse(Console.ReadLine(), out double weeklySalary))
                        {
                            Console.WriteLine("Invalid salary format. Returning to main menu.");
                            return;
                        }
                        salaried.WeeklySalary = weeklySalary;
                    }
                    break;

                case EmployeeType.SalaryPlusCommissionEmployee:
                    var salaryPlusCommission = employeeToEdit as SalaryPlusCommissionEmployee;
                    if (salaryPlusCommission != null)
                    {
                        Console.WriteLine("Enter new gross sales:");
                        if (!double.TryParse(Console.ReadLine(), out double grossSales))
                        {
                            Console.WriteLine("Invalid gross sales format. Returning to main menu.");
                            return;
                        }
                        salaryPlusCommission.GrossSales = grossSales;

                        Console.WriteLine("Enter new salary:");
                        if (!double.TryParse(Console.ReadLine(), out double salary))
                        {
                            Console.WriteLine("Invalid salary format. Returning to main menu.");
                            return;
                        }
                        salaryPlusCommission.Salary = salary;

                        Console.WriteLine("Enter new commission rate:");
                        if (!double.TryParse(Console.ReadLine(), out double commissionRate))
                        {
                            Console.WriteLine("Invalid commission rate format. Returning to main menu.");
                            return;
                        }
                        salaryPlusCommission.CommissionRate = commissionRate;
                    }
                    break;
            }

            // Display success message
            Console.WriteLine("Employee information updated successfully.");

            // Display all employees of the selected type to verify the changes
            Console.WriteLine($"Employees of type: {empType}");
            foreach (var emp in employeesOfType)
            {
                Console.WriteLine(emp);
            }
        

    }
        static void DeleteEmployee() {
            Console.WriteLine("1 - Delete Hourly Employee");
            Console.WriteLine("2 - Delete Commission Employee");
            Console.WriteLine("3 - Delete Salaried Employee");
            Console.WriteLine("4 - Delete Salary Plus Commission Employee");
            Console.WriteLine("5 - Back to Main Menu");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            EmployeeType emp;
            switch(choice)
            {
                case "1":
                    emp = EmployeeType.HourlyEmployee;
                    ViewEmployeeByType(emp);
                    break;
                case "2":
                    emp = EmployeeType.CommissionEmployee;
                    ViewEmployeeByType(emp);
                    break;
                case "3":
                    emp = EmployeeType.SalariedEmployee;
                    ViewEmployeeByType(emp);
                    break;
                case "4":
                    emp = EmployeeType.SalaryPlusCommissionEmployee;
                    ViewEmployeeByType(emp);
                    break;
                case "5":
                    return;
                 default: Console.WriteLine("Wrong choice");
                    break;
                    
                    
            }
            Console.WriteLine("Enter Employee Id :");
            int empId = int.Parse(Console.ReadLine());
            LinkedListNode<Employee> employeeToRemove = null;
            for (var i = employees.First; i != null; i= i.Next)
            {
                if(i.Value.EmployeeId == empId)
                {
                    employeeToRemove = i;
                    break;
                }
            }
            if (employeeToRemove != null)
            {
                employees.Remove(employeeToRemove);
                Console.WriteLine($"the employee with ID {empId} is deleteed successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found");
            }
            
        }
       
            static void SearchEmployee()
            {
                Console.WriteLine("Enter employee name to search:");
                string searchName = Console.ReadLine();

                var searchResults = employees.Where(emp => emp.Name1.IndexOf(searchName, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

                if (searchResults.Any())
                {
                    Console.WriteLine("Search Results:");
                    DisplayEmployeesInTable(searchResults);
                }
                else
                {
                    Console.WriteLine("No employees found matching the search criteria.");
                }
            }

        
        static void ViewEmployee() {
            Console.WriteLine("The employee list is:");
            foreach (EmployeeType emp in Enum.GetValues(typeof(EmployeeType)))
            {
                ViewEmployeeByType(emp);
            }
        
        }
        static void ViewEmployeeByType(EmployeeType empType)
        {
            //Console.WriteLine("Employees of type:" + empType);
            bool found = false;
            
            var employeesOfType = employees.Where(e => e.TypeofEmployee == empType).ToList();

            if (employeesOfType.Count > 0)
            {
                DisplayEmployeesInTable(employeesOfType);
                found = true;
            }

            if (!found)
            {
                Console.WriteLine("No employees found for the specified type.");
            }
        }
       
        static void DisplayEmployeesInTable(List<Employee> employees)
        {
            foreach (EmployeeType empType in Enum.GetValues(typeof(EmployeeType)))
            {
                var employeesOfType = employees.Where(e => e.TypeofEmployee == empType).ToList();

                if (employeesOfType.Any())
                {
                    Console.WriteLine($"Employees of type: {empType}");

                    switch (empType)
                    {
                        case EmployeeType.HourlyEmployee:
                            var hourlyTable = new ConsoleTable("ID", "Name", "Hourly Wage", "Hours", "Tax", "Net Earnings");
                            foreach (var emp in employeesOfType)
                            {
                                var hourlyEmp = emp as HourlyEmployee;
                                double earnings = hourlyEmp.Wage * hourlyEmp.Hours;
                                double tax = emp.Tax;
                                double netEarnings = earnings - tax;
                                hourlyTable.AddRow(hourlyEmp.EmployeeId, hourlyEmp.Name1, hourlyEmp.Wage, hourlyEmp.Hours, tax, netEarnings);
                            }
                            hourlyTable.Write(Format.Minimal);
                            break;

                        case EmployeeType.CommissionEmployee:
                            var commissionTable = new ConsoleTable("ID", "Name", "Gross Sales", "Commission Rate", "Tax", "Net Earnings");
                            foreach (var emp in employeesOfType)
                            {
                                var commissionEmp = emp as CommissionEmployee;
                                double commissionEarnings = commissionEmp.GrossSales * commissionEmp.CommissionRate;
                                double commissionTax = emp.Tax;
                                double commissionNetEarnings = commissionEarnings - commissionTax;
                                commissionTable.AddRow(commissionEmp.EmployeeId, commissionEmp.Name1, commissionEmp.GrossSales, commissionEmp.CommissionRate, commissionTax, commissionNetEarnings);
                            }
                            commissionTable.Write(Format.Minimal);
                            break;

                        case EmployeeType.SalariedEmployee:
                            var salariedTable = new ConsoleTable("ID", "Name", "Weekly Salary", "Tax", "Net Earnings");
                            foreach (var emp in employeesOfType)
                            {
                                var salariedEmp = emp as SalariedEmployee;
                                double salariedNetEarnings = salariedEmp.WeeklySalary;
                                salariedTable.AddRow(salariedEmp.EmployeeId, salariedEmp.Name1, salariedEmp.WeeklySalary, emp.Tax, salariedNetEarnings);
                            }
                            salariedTable.Write(Format.Minimal);
                            break;

                        case EmployeeType.SalaryPlusCommissionEmployee:
                            var salaryPlusCommissionTable = new ConsoleTable("ID", "Name", "Salary", "Gross Sales", "Commission Rate", "Tax", "Net Earnings");
                            foreach (var emp in employeesOfType)
                            {
                                var salaryPlusCommissionEmp = emp as SalaryPlusCommissionEmployee;
                                double totalEarnings = salaryPlusCommissionEmp.Salary + (salaryPlusCommissionEmp.GrossSales * salaryPlusCommissionEmp.CommissionRate);
                                double totalTax = emp.Tax;
                                double totalNetEarnings = totalEarnings - totalTax;
                                salaryPlusCommissionTable.AddRow(salaryPlusCommissionEmp.EmployeeId, salaryPlusCommissionEmp.Name1, salaryPlusCommissionEmp.Salary, salaryPlusCommissionEmp.GrossSales, salaryPlusCommissionEmp.CommissionRate, totalTax, totalNetEarnings);
                            }
                            salaryPlusCommissionTable.Write(Format.Minimal);
                            break;
                    }

                    Console.WriteLine(); // Add an empty line between different employee type tables
                }
            }
        }




    }



}

