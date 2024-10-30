using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1GagandeepKooner
{
    public class CommissionEmployee : Employee
    {
        // private fields
        private double _grossSales;        // gross weekly sales
        private double _commissionRate;    // commission percentage


        // properties
        public double GrossSales
        {
            get { return _grossSales; }

            set
            {
                if (value < 0)
                    throw new Exception("Gross sales cannot be less than 0");
                else
                    _grossSales = value;
            }
        }

        public double CommissionRate
        {
            get { return _commissionRate; }

             set
            {
                if (value < 0 || value > 1)
                    throw new Exception("Commission rate cannot be < 0 or > 1");
                else
                    _commissionRate = value;
            }
        }


        // constructor
        public CommissionEmployee(int employeeId, EmployeeType empType, string name, double grossSales, double commissionRate) : base(employeeId, empType, name)
        {
            GrossSales = grossSales;
            CommissionRate = commissionRate;
        }


        // calculate earnings; override abstract method Earnings in Employee
        public override double GrossEarnings
        {
            get { return GrossSales * CommissionRate; }
        }


        // return string representation of CommissionEmployee object
        public override string ToString()
        {
            return $"Commission Employee: {base.ToString()}" +
                $"\nGross Sales: {GrossSales:C}" +
                $"\nCommission Rate: {CommissionRate:P}";
        }
    }
}

