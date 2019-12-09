using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Vindeed
{
    public class Login
    {
        static string Usermail;
        static string Organizationmail;
        static string UserPassword;
        static string Type;
        static string Position;
        static string ZipCode;
        static string City;
        static string JobDescription;
        static string StartDate;
        static string EndDate;
        static string UserRole;
        static string REferenceNumber;


        public string Type_
        {
            get { return Type;  }
            set { Type = value; }
        }
        public string Position_
        {
            get { return Position;  }
            set { Position = value; }
        }
        public string Zip_Code
        {
            get { return ZipCode;  }
            set { ZipCode = value; }
        }
        public string City_
        {
            get { return City;  }
            set { City = value; }
        }
        public string Job_Description
        {
            get { return JobDescription;  }
            set { JobDescription = value; }
        }
        public string Start_Date
        {
            get { return StartDate;  }
            set { StartDate = value; }

        }
        public string End_Date
        {
            get { return EndDate;  }
            set { EndDate = value; }
        }
        public string User_Role
        {
            get { return UserRole;  }
            set { UserRole = value; }
        }
        public string User_Email
        {
            get { return Usermail;  }
            set { Usermail = value; }
        }
        public string Organization_mail
        {
            get { return Organizationmail;  }
            set { Organizationmail = value; }
        }
        public string REference_Number
        {
            get { return REferenceNumber;  }
            set { REferenceNumber = value; }
        }
        public string User_Password
        {
            get { return UserPassword;  }
            set { UserPassword = value; }
        }
    }
}