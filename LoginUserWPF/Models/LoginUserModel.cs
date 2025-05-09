using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginUserWPF.Models
{
    class LoginUserModel
    {
        private string Name;
        private string Email;

        public string Username
        {
            get { return Name; }
            set { Name = value; }
        }

        public string Useremail
        {
            get { return Email; }
            set { Email = value; }
        }
    }
}
