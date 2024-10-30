
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using Binding = System.Windows.Data.Binding;
using ListView = System.Windows.Controls.ListView;
using MessageBox = System.Windows.MessageBox;

namespace exercise1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> students = new List<Student>();
        List<ImageSource> imagesSources = new List<ImageSource>();
        ImageSource defaultPhoto;
        private void PopulateData()
        {
            addImageSources();
            addInitStudents();
            addStudentStatus();
        }
        public void addStudentStatus()
        {
           statuses.Items.Add(Student.Statuses.PART_TIME.ToString());
            statuses.Items.Add(Student.Statuses.FULL_TIME.ToString());

        }
        private void addImageSources()
        {
            defaultPhoto = mainphoto.Source;
            imagesSources.Add(img2.Source);
            imagesSources.Add(img2.Source);
            imagesSources.Add(img2.Source);
            imagesSources.Add(img2.Source);
            imagesSources.Add(mainphoto.Source);

        }
        private void addInitStudents()
        {
            students.Add(new Student(123456789, "john", "smith", "jh@h.com", "male", "full-time", "img2.jpeg"));
            students.Add(new Student(123456781, "kkjjjj", "smith", "jh@h.com", "male", "full-time", "img2.jpeg"));
            students.Add(new Student(123456782, "harman", "smith", "jh@h.com", "male", "full-time", "img2.jpeg"));
            students.Add(new Student(123456789, "gagan", "smith", "jh@h.com", "female", "full-time", "img2.jpeg"));
            students.Add(new Student(898989898, "aman", "smith", "jh@h.com", "female", "full-time", "img2.jpeg"));
            students.Add(new Student(414411222, "arsh", "smith", "jh@h.com", "Male", "part-time", "img2.jpeg"));

        }
        private void initListingGride()
        {
            string template = @"
            <DataTemplate xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'>
                <Grid>
                    <Image Source='{Binding Photo}' Height='50' Width='50' />
                </Grid>
            </DataTemplate>";
            //DataTemplate dataTemplate = new DataTemplate();
            DataTemplate dataTemplate = XamlReader.Parse(template) as DataTemplate;
            ListingGrid.Columns.Add(
                new GridViewColumn
                {
                    Header = "Photo",
                    CellTemplate= dataTemplate
                }
               );
            ListingGrid.Columns.Add(
            new GridViewColumn
               {
                   Header = "Student ID",
                   DisplayMemberBinding = new Binding("Studentid")
               }
               );
            ListingGrid.Columns.Add(
                new GridViewColumn
                {
                    Header = "First Name",
                    DisplayMemberBinding = new Binding("FirstName")
                }
                );
            ListingGrid.Columns.Add(
                new GridViewColumn
                {
                    Header = "Last Name",
                    DisplayMemberBinding = new Binding("LastName")
                }
                );
            ListingGrid.Columns.Add(
                new GridViewColumn
                {
                    Header = "Email",
                    DisplayMemberBinding = new Binding("Email")
                }
                );
            foreach (var value in students)
            {
                Listing.Items.Add(value);
            }


        }

        public MainWindow()
        {
            InitializeComponent();
            PopulateData();
            initListingGride();
            blankChosenStudenView();
            blankStudentForm();
            
        }
        private void blankStudentForm()
        {
            StudentId.Text = string.Empty;
            firstName.Text = string.Empty;
            lastname.Text = string.Empty;

        }
        private void blankChosenStudenView()
        {
            l1.Visibility = Visibility.Hidden;
            l2.Visibility = Visibility.Hidden;
            l3.Visibility = Visibility.Hidden;
            l4.Visibility = Visibility.Hidden;
            l5.Visibility = Visibility.Hidden;
            l6.Visibility = Visibility.Hidden;
            chosenstudentID.Visibility = Visibility.Hidden;
            chosenstudentFN.Visibility = Visibility.Hidden;
            chosenstudentln.Visibility = Visibility.Hidden;
            chosenstudenten.Visibility = Visibility.Hidden;
            chosenstudentg.Visibility = Visibility.Hidden;
            chosenstudents.Visibility = Visibility.Hidden;
            chosenstudentphoto.Visibility = Visibility.Hidden;
            edit.Visibility = Visibility.Hidden;
        }
        private void unblankChosenStudenView()
        {
            l1.Visibility = Visibility.Visible;
            l2.Visibility = Visibility.Visible;
            l3.Visibility = Visibility.Visible;
            l4.Visibility = Visibility.Visible;
            l5.Visibility = Visibility.Visible;
            l6.Visibility = Visibility.Visible;
            chosenstudentID.Visibility = Visibility.Visible;
            chosenstudentFN.Visibility = Visibility.Visible;
            chosenstudentln.Visibility = Visibility.Visible;
            chosenstudenten.Visibility = Visibility.Visible;
            chosenstudentg.Visibility = Visibility.Visible;
            chosenstudents.Visibility = Visibility.Visible;
            chosenstudentphoto.Visibility = Visibility.Visible;
            edit.Visibility = Visibility.Visible;
        }
        private void Listing_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            if (listView != null)
            {
                Student selected = listView.SelectedItem as Student;
                if(selected != null)
                {
                    chosenstudentID.Text= selected.Studentid.ToString();
                    chosenstudentFN.Text= selected.FirstName.ToString();
                    chosenstudentln.Text= selected.LastName.ToString();
                    chosenstudenten.Text = selected.Email.ToString();
                    chosenstudentg.Text = selected.GetGender().ToString();
                    chosenstudents.Text = selected.GetStatus().ToString();
                 
                    foreach(var item in imagesSources)
                    {
                        if (item == null)
                        {
                            chosenstudentphoto.Source = defaultPhoto;
                        }
                            
                        //MessageBox.Show(item.ToString());
                        if(item.ToString().Contains(selected.Photo)){
                            chosenstudentphoto.Source = item;
                            break;
                        }
                    }
                    



                    unblankChosenStudenView();

                }
            }

        }

        

        private void edit_Click_1(object sender, RoutedEventArgs e)
        {
            Student selected = students[Listing.SelectedIndex];
            StudentId.Text = selected.Studentid.ToString();
            StudentId.IsEnabled = false;
            firstName.Text = selected.FirstName;
            lastname.Text = selected.LastName;
            email.Text = selected.Email;
            // StudentId.Text = selected.Studentid.ToString() ;

            switch (selected.GetGender())
            {
                case Student.Genders.MALE:
                    maleg.IsChecked = true;
                    break;
                case Student.Genders.FEMALE:
                    femaleg.IsChecked = true;
                    break;
                case Student.Genders.UNDECLARED:
                    undecalredg.IsChecked = true;
                    break;


            }
            switch (selected.GetStatus())
            {
                case Student.Statuses.FULL_TIME:
                    statuses.SelectedIndex = 0; break;
                default: statuses.SelectedIndex = 1; break;
            }
            foreach (var item in imagesSources)
            {
                if (item == null)
                    continue;
                //MessageBox.Show(item.ToString());
                if (item.ToString().Contains(selected.Photo))
                {
                    mainphoto.Source = item;
                    break;
                }
            }
            tabs.SelectedIndex = 0;
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            StudentId.Text = "";
            StudentId.IsEnabled = true;
            firstName.Text = "";
            lastname.Text = "";
            email.Text = "email";
            mainphoto.Source = defaultPhoto;
            maleg.IsChecked = false;
            femaleg.IsChecked= false;
            undecalredg.IsChecked = false;
            statuses.SelectedIndex = 0;


        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            
            try
            { 
                string[] pieces = mainphoto.Source.ToString().Split(@"/");
                string filePath = pieces[pieces.Length - 1];
                //MessageBox.Show(filePath);
                string gender = "";
                if(maleg.IsChecked == true)
                {
                    gender = "male";
                }
                else if (femaleg.IsChecked == true)
                {
                    gender = "female";
                }
               else  if (undecalredg.IsChecked == true)
                {
                    gender = "undeclared";
                }
                string status = statuses.SelectedIndex == 0 ? "full-time" : "part-time";

                Student student = new Student(
                    photo: filePath,
                    firstName: firstName.Text,
                    lastName : lastname.Text,
                    email: email.Text,
                    gender: gender,
                    status: status,
                    studentId: Convert.ToInt32(StudentId.Text)

                    );
                students.Add( student );
                Listing.Items.Add( student );
                tabs.SelectedIndex = 1;
               // MessageBox.Show("its clicke");



            }
            catch (Exception ex)
            {
                MessageBox.Show("error in Submitting"+ex.Message);
            }
        }
    }
}