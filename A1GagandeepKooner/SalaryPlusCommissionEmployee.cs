using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1GagandeepKooner
{
    internal class SalaryPlusCommissionEmployee : CommissionEmployee
    {
        // private field
        private double _salary;    // base salary per week


        // property
        public double Salary
        {
            get { return _salary; }
            set
            {
                if (value < 0)
                    throw new Exception("Base salary cannot be < 0");
                else
                    _salary = value;
            }
        }


        // constructors
        public SalaryPlusCommissionEmployee(int employeeId, EmployeeType empType, string name, double grossSales, double commissionRate, double salary) : base(employeeId, empType,name, grossSales, commissionRate)
        {
            Salary = salary;
        }


        // calculate earnings; override method Earnings in CommissionEmployee
        public override double GrossEarnings
        {
            get
            {

                return Salary + base.GrossEarnings;
            }
        }

        // return string representation of SalaryPlusCommissionEmployee object
        public override string ToString()
        {
            return $"Salary Plus {base.ToString()}" +
                $"\nSalary {Salary:C}";
        }
    }
}
