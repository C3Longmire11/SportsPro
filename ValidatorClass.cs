using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsProUserInterface
{
    public static class ValidatorClass
    {
        public static bool IsPresent(string txtInput)
        {
            if (txtInput == string.Empty)
            { return false; }
            else
            { return true; }
        }
        public static bool IsNumeric(string txtInput)
        {
            Int32 number;
            try
            {
                number = Convert.ToInt32(txtInput);
                return true;
            }
            catch
            { return false; }
        }
    }
}
