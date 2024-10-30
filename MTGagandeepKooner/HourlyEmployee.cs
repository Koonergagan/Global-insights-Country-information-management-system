using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGagandeepKooner
{
    internal class HourlyEmployee: Employee
    {
        // fields
        private int _hours;     // hours worked for the week
        private double _wage;  // wage per hour


        // properties
        public int Hours
        {
            get { return _hours; }
            set
            {
                if (value < 0 || value > 168)
                    throw new Exception("Hours must be >= 0 or <= 168");
                else
                    _hours = value;
            }
        }

        public double Wage
        {
            get { return _wage; }
            set
            {
                // validate
                _wage = value;
            }
        }


        // constructor
        public HourlyEmployee(int employeeId, EmployeeType empType, string name, int hours, double wage) : base(employeeId, empType, name)
        {
            Hours = hours;
            Wage = wage;
        }


        // calculate earnings; override Employee's abstract method Earnings
        public override double GrossEarnings
        {
            get
            {
                if (Hours <= 40)
                    return Hours * Wage;
                else
                    return (40 * Wage) + ((Hours - 40) * Wage * 1.5);
            }
        }

    }
}
