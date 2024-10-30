using System.Reflection.Emit;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MTGagandeepKooner
{
   
    public partial class MainWindow : Window
    {
        List<Employee> employees = new List<Employee>();
        static int nextEmployeeID = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HourlyEmployee_Checked(object sender, RoutedEventArgs e)
        {

            label1.Text = "Hours Worked:";
            label2.Visibility = Visibility.Visible; // Ensure label2 is visible
            textBox1.Visibility = Visibility.Visible;

            label2.Text = "Hourly Wage:";
           
           
        }

        private void SalariedEmployee_Checked(object sender, RoutedEventArgs e)
        {
            label1.Text = "Weekly Salary";
            label2.Visibility = Visibility.Hidden;
            textBox1.Visibility = Visibility.Hidden;
        }

        private void CommissionEmployee_Checked(object sender, RoutedEventArgs e)
        {
            label1.Text = "Gross Sales:";
            label2.Visibility = Visibility.Visible; // Ensure label2 is visible
            textBox1.Visibility = Visibility.Visible;

            label2.Text = "Commision Rate:";
        }
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = EmployeeName.Text;
                double value1, value2 = 0;

                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Please enter a name.");
                    return;
                }

                if (!double.TryParse(textBox2.Text, out value1))
                {
                    MessageBox.Show("Please enter a valid value for the first field.");
                    return;
                }

                if (textBox1.Visibility == Visibility.Visible && !double.TryParse(textBox1.Text, out value2))
                {
                    MessageBox.Show("Please enter a valid value for the second field.");
                    return;
                }

                Employee emp = null;
                if (HourlyEmployee.IsChecked == true)
                {
                    emp = new HourlyEmployee(nextEmployeeID++, EmployeeType.HourlyEmployee, name, (int)value1, value2);
                }
                else if (CommissionEmployee.IsChecked == true)
                {
                    emp = new CommissionEmployee(nextEmployeeID++, EmployeeType.CommissionEmployee, name, value1, value2 / 100);
                }
                else if (SalariedEmployee.IsChecked == true)
                {
                    emp = new SalariedEmployee(nextEmployeeID++, EmployeeType.SalariedEmployee, name, value1);
                }

                if (emp != null)
                {
                    employees.Add(emp);
                    EmployeeListView.Items.Add(emp.Name1);

                    GrossEarnings.Text = emp.GrossEarnings.ToString("C");
                    tax.Text = emp.Tax.ToString("C");
                    netearnings.Text = emp.NetEarnings.ToString("C");
                    //MessageBox.Show("hi");

                   // EmployeeName.Clear();
                    //textBox1.Clear();
                   //textBox2.Clear();
                }
            }catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void EmployeeListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeeListView.SelectedItem is string selectedName)
            {
                var selectedEmployee = employees.FirstOrDefault(emp => emp.Name1 == selectedName);
                if (selectedEmployee != null)
                {
                    EmployeeName.Text = selectedEmployee.Name1;
                    GrossEarnings.Text = selectedEmployee.GrossEarnings.ToString("C");
                    tax.Text = selectedEmployee.Tax.ToString("C");
                    netearnings.Text = selectedEmployee.NetEarnings.ToString("C");

                    if (selectedEmployee is HourlyEmployee hourly)
                    {
                        HourlyEmployee.IsChecked = true;
                        textBox2.Text = hourly.Hours.ToString();
                        textBox1.Text = hourly.Wage.ToString();
                    }
                    else if (selectedEmployee is CommissionEmployee commission)
                    {
                        CommissionEmployee.IsChecked = true;
                        textBox2.Text = commission.GrossSales.ToString();
                        textBox1.Text = (commission.CommissionRate * 100).ToString();
                    }
                    else if (selectedEmployee is SalariedEmployee salaried)
                    {
                        SalariedEmployee.IsChecked = true;
                        textBox2.Text = salaried.WeeklySalary.ToString();
                    }
                }
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            EmployeeName.Clear();
            textBox1.Clear();
            textBox2.Clear();
            GrossEarnings.Clear();
            tax.Clear();
            netearnings.Clear();
        }

        private void Calculate_Click_1(object sender, RoutedEventArgs e)
        {
           
                string name = EmployeeName.Text;
                double value1, value2 = 0;

                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Please enter a name.");
                    return;
                }

                if (!double.TryParse(textBox2.Text, out value1))
                {
                    MessageBox.Show("Please enter a valid value for the first field.");
                    return;
                }

                if (textBox1.Visibility == Visibility.Visible && !double.TryParse(textBox1.Text, out value2))
                {
                    MessageBox.Show("Please enter a valid value for the second field.");
                    return;
                }

                Employee emp = null;
                if (HourlyEmployee.IsChecked == true)
                {
                    emp = new HourlyEmployee(nextEmployeeID++, EmployeeType.HourlyEmployee, name, (int)value1, value2);
                }
                else if (CommissionEmployee.IsChecked == true)
                {
                    emp = new CommissionEmployee(nextEmployeeID++, EmployeeType.CommissionEmployee, name, value1, value2 / 100);
                }
                else if (SalariedEmployee.IsChecked == true)
                {
                    emp = new SalariedEmployee(nextEmployeeID++, EmployeeType.SalariedEmployee, name, value1);
                }

                if (emp != null)
                {
                    employees.Add(emp);
                EmployeeListView.Items.Refresh();
                    EmployeeListView.Items.Add(emp.Name1); 

                    GrossEarnings.Text = emp.GrossEarnings.ToString("C");
                    tax.Text = emp.Tax.ToString("C");
                    netearnings.Text = emp.NetEarnings.ToString("C");

                    EmployeeName.Clear();
                    textBox1.Clear();
                    textBox2.Clear();
                
            }
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            
                try
                {
                    string name = EmployeeName.Text;
                    double value1, value2 = 0;

                    if (string.IsNullOrEmpty(name))
                    {
                        MessageBox.Show("Please enter a name.");
                        return;
                    }

                    
                    EmployeeType selectedType;
                    if (HourlyEmployee.IsChecked == true)
                    {
                        selectedType = EmployeeType.HourlyEmployee;
                        if (!double.TryParse(textBox2.Text, out value1))
                        {
                            MessageBox.Show("Please enter a valid value for Hours Worked.");
                            return;
                        }
                        if (!double.TryParse(textBox1.Text, out value2))
                        {
                            MessageBox.Show("Please enter a valid value for Hourly Wage.");
                            return;
                        }
                    }
                    else if (CommissionEmployee.IsChecked == true)
                    {
                        selectedType = EmployeeType.CommissionEmployee;
                        if (!double.TryParse(textBox2.Text, out value1))
                        {
                            MessageBox.Show("Please enter a valid value for Gross Sales.");
                            return;
                        }
                        if (!double.TryParse(textBox1.Text, out value2))
                        {
                            MessageBox.Show("Please enter a valid value for Commission Rate.");
                            return;
                        }
                        value2 /= 100;
                    }
                    else if (SalariedEmployee.IsChecked == true)
                    {
                        selectedType = EmployeeType.SalariedEmployee;
                        if (!double.TryParse(textBox2.Text, out value1))
                        {
                            MessageBox.Show("Please enter a valid value for Weekly Salary.");
                            return;
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Please select an Employee Type.");
                        return;
                    }

                  
                    Employee emp = null;
                    switch (selectedType)
                    {
                        case EmployeeType.HourlyEmployee:
                            emp = new HourlyEmployee(nextEmployeeID++, selectedType, name, (int)value1, value2);
                            break;
                        case EmployeeType.CommissionEmployee:
                            emp = new CommissionEmployee(nextEmployeeID++, selectedType, name, value1, value2);
                            break;
                        case EmployeeType.SalariedEmployee:
                            emp = new SalariedEmployee(nextEmployeeID++, selectedType, name, value1);
                            break;
                    }

                    if (emp != null)
                    {
                        employees.Add(emp);
                   
                    AddEmployeeToView(emp);
                      
                        EmployeeName.Clear();
                        textBox1.Clear();
                        textBox2.Clear();

                        
                        GrossEarnings.Text = emp.GrossEarnings.ToString("C");
                        tax.Text = emp.Tax.ToString("C");
                        netearnings.Text = emp.NetEarnings.ToString("C");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        private void AddEmployeeToView(Employee emp)
        {
            EmployeeListView.Items.Add(emp.Name1); 
        }

    }
    }
