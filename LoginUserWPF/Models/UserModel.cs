using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginUserWPF.Models
{
    /// <summary>
    /// Represents a user's data in the application, including name and email
    /// </summary>
    /// <remarks>This method is used to represent the user's data during login and user registration</remarks>
    public class UserModel
    {
        private int Id;
        private string Name;
        private string Email;
        private string Gender;
        private string Age;

        public int UserId
        {
            get { return Id; }
            set { Id = value; }
        }

        public string UserName
        {
            get { return Name; }
            set { Name = value; }
        }

        public string UserEmail
        {
            get { return Email; }
            set { Email = value; }
        }

        public string UserGender
        {
            get { return Gender; }
            set { Gender = value; }
        }

        public string UserAge
        {
            get { return Age; }
            set
            {
                if (value != Age)
                {
                    Age = value;
                }
            }
        }
    }
}
