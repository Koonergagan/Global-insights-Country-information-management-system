using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise1
{
     class Student
    {
        private int _studentid;
        private string _firstName, _lastName, _email;
        public enum Genders { MALE, FEMALE, UNDECLARED };
        public enum Statuses { FULL_TIME, PART_TIME };
        private Genders _gender;
        private Statuses _status;
        public string Photo {  get; set; }
        public Genders GetGender()
        {
            return _gender;

        }
        public Statuses GetStatus()
        {
            return _status;
        }
        public int Studentid {
            get => _studentid;
            set
            {
                string sid = value.ToString();
                if(sid.Length<9)
                {
                    throw new Exception("is too short");
                }
                _studentid = value;
            }
        }
        public string FirstName
        {
            get => _firstName; set
            {
                if (value.Length < 3)
                    throw new ArgumentException("too short");
                _firstName = value;
            }
        }
      

        public string LastName
        {
            get => _lastName; set
            {
                if (value.Length < 3)
                    throw new ArgumentException("too short");
                _lastName = value;
            }
        }

        public string Email
        {
            get => _email; set
            {
                if (value.Length < 3)
                    throw new ArgumentException("too short");
                _email = value;
            }
        }
        
        public void setGender(string gender) 
        {
            switch (gender.ToLower())
            {
                case "female":
                 _gender= Genders.FEMALE; 
                 break;
                case "male":
                    _gender = Genders.MALE;
                    break;
                case "undeclared":
                    _gender = Genders.UNDECLARED;
                    break;
                default:
                    throw new ArgumentException("unknown gender");
                break;

            }
       
        }
        public void setStatus(string status)
        {
           // if (status == null) throw new ArgumentNullException(nameof(status));
            switch (status.ToLower()) 
            {
                case "full-time":
                case "full_time":
                case "full time":
                    _status = Statuses.FULL_TIME;
                    break;
                case "part time":
                case "part-time":
                case "part_time":
                    _status = Statuses.PART_TIME; break;
                default:
                    throw new ArgumentException("invalid");
                    break;
            }

        }

        public Student(int studentId,string firstName, string lastName, string email, string gender, string status, string photo)
        {
            Studentid = studentId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            setGender(gender);
            setStatus(status);
            Photo = photo;
        }


    }
}
