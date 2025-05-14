using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginUserWPF.Helper
{
    /// <summary>
    /// Check the strength of the password
    /// </summary>
    public static class PasswordStrengthEvaluator
    {
        /// <summary>
        /// Password entered by the user to be evaluated
        /// </summary>
        /// <returns>Returns a strength score from 0 to 4</returns>
        public static int Evaluate(string password)
        {
            return Zxcvbn.Core.EvaluatePassword(password).Score;
        }
    }
}
