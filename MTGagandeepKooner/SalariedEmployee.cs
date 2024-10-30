using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGagandeepKooner
{
    internal class SalariedEmployee:Employee
    {
        // field
        private double _weeklySalary;


        // property
        public double WeeklySalary
        {
            get { return _weeklySalary; }
            set
            {
                if (value < 0)
                    throw new Exception("Weekly salary must be > 0");
                else
                    _weeklySalary = value;
            }
        }

        // constructor
        public SalariedEmployee(int employeeId, EmployeeType empType, string name, double weeklySalary) : base(employeeId, empType, name)
        {
            WeeklySalary = weeklySalary;
        }


        // calculate earnings; override abstract method Earnings in Employee
        public override double GrossEarnings
        {
            get
            {
                return WeeklySalary;
            }
        }


        // return string representation of SalariedEmployee object
        public override string ToString()
        {
            return $"Salaried Employee: {base.ToString()}" +
                $"\nWeekly Salary: {WeeklySalary:C}";
        }
    }
}
