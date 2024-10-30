using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGagandeepKooner
{
    public enum EmployeeType
    {
        HourlyEmployee,
        CommissionEmployee,
        SalariedEmployee,
        SalaryPlusCommissionEmployee
    }
    public abstract class Employee
    {
        private int _employeeId;
        private EmployeeType _empType;
        private string _name;
        public int EmployeeId
        {
            get { return _employeeId; }
            private set { _employeeId = value; }
        }
        public EmployeeType TypeofEmployee
        {
            get { return _empType; }
            set { _empType = value; }
        }
        public string Name1
        {
            get { return _name; }
            set { _name = value; }
        }

        public Employee(int employeeId, EmployeeType empType, string name)
        {
            EmployeeId = employeeId;
            _empType = empType;
            _name = name;

        }
        public abstract double GrossEarnings { get; }
        public double Tax => GrossEarnings * .2;

        public double NetEarnings => GrossEarnings - Tax;
        public override string ToString()
        {
            return $"{_name}  \nEmployee Id: {EmployeeId}" +
                $"\nEmployee Type: {_empType}";
        }

    }
}
