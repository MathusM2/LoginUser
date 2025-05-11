using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginUserWPF.Helper
{
    public static class PasswordStrengthEvaluator
    {
        public static int EvaluatePasswordStrength (string password)
        {
            return Zxcvbn.Core.EvaluatePassword(password).Score;
        }
    }
}
