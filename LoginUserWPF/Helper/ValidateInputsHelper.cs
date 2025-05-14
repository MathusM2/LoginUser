using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginUserWPF.Services;

namespace LoginUserWPF.Helper
{
    /// <summary>
    /// Check the field name and call the corresponding service method
    /// </summary>
    public static class ValidateInputsHelper
    {
        /// <summary>
        /// Look for the corresponding validation service method, make the call.
        /// </summary>
        /// <returns>Returns a tuple of the service validation result, containing a boolean and an error message string.</returns>
        public static (bool, string?) Validate(string fieldName, string fieldText)
        {
            if(fieldName == "InputName")
            {
                return ValidateUserInput.ValidateName(fieldText);
            }
            else
            if (fieldName == "InputEmail")
            {
                return ValidateUserInput.ValidateEmail(fieldText);
            }
            else
            if (fieldName == "InputGender")
            {
                return ValidateUserInput.ValidateGender(fieldText);
            }
            else
            if (fieldName == "InputAge")
            {
                return ValidateUserInput.ValidateAge(int.Parse(fieldText));
            }
            else
            if(fieldName == "InputPassword")
            {
                return ValidateUserInput.ValidatePassword(fieldText);
            }
            else
            {
                return (false, "Invalid field");
            }
        }
    }
}
