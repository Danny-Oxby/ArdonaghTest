using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingTest.Services
{
    public static class ValidationService
    {

        /*
        public string Name { get; set; } // Less than or equal to 50 characters
        public int Age { get; set; } // 0 to 110
        public string PostCode { get; set; } // Must contain numbers and characters
        public double Height { get; set; } // 0 to 2.50. Only 2 decimal places
         */

        public static bool NameValidation(string nameinput)
        {
            if(string.IsNullOrEmpty(nameinput)) return false; // input has value
            else if (nameinput.Length > 50) return false; //input meets criteria
            else return true; //return condition
        }

        public static bool AgeValidation(int ageinput)
        {
            if (ageinput < 0 || ageinput > 110) return false; //input meets criteria
            else return true; //return condition
        }

        public static bool PostCodeValidation(string postcodeinput)
        {
            try
            {
                if (string.IsNullOrEmpty(postcodeinput)) return false; // input has value
                else
                {
                    if (postcodeinput.Any(Char.IsLetter)) //is there any letter
                        if (postcodeinput.Any(Char.IsDigit)) return true; //is there any number
                        else return false;
                    else return false;
                }
            } catch (Exception ex) 
            { 
                string debugmsg = ex.Message;
                return false; 
            }
        }
    }
}
