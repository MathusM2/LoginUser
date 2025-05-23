using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginUserWPF.Interfaces
{
    public interface IUserValidationService
    {
        (bool, string?) ValidateName(string name);
        (bool, string?) ValidatePassword(string password);
        (bool, string?) ValidateEmail(string email);
        (bool, string?) ValidateGender(string gender);
        (bool, string?) ValidateAge(string age);
    }
}
