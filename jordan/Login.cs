using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Vindeed
{
    public class Login
    {
         static string Usermail;
        static string UserPassword;
        // private string clients;
        //public string Clients { get { return clients; } set { clients = value; } }

       /*
        private string first;
        private string last;

        public Login( string firstName, string lastName)
        {
            last = lastName;
            first = firstName;
        }
        */

        public string User_Email
        {
            get
            {
                return Usermail;
            }
            set
            {
                Usermail = value; 
            }
        
        }
        public string User_Password
        {
            get
            {
                return UserPassword;
            }
            set
            {
                UserPassword = value;
            }

        }
    }
}