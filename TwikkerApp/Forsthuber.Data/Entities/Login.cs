using System;
using System.Collections.Generic;
using System.Text;

namespace Forsthuber.Data.Entities
{
    public class Login
    {
        public Login()
        {
            this.Nickname = "";
            this.Password = "";
        }

        public int LoginID
        {
            get;
            set;
        }

        public int UserID
        {
            get;
            set;
        }

        public string Nickname
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }
    }
}
