using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewProject.Models
{
    public class ProfileModel
    {
        private string _name;
        private string _dob;
        private string _email;
        private string _phone;
        private string _address;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string DOB
        {  
            get { return _dob; } 
            set { _dob = value; } 
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
    }
}