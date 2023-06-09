﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingTest.Model
{
    public class CustomerMdl
    {
        public CustomerMdl() // default ctor
        {
        }
        public CustomerMdl(string name, int age, string postcode, double height)
        {
            Name = name;
            Age = age;
            PostCode = postcode;
            Height = height;
        }

        #region properties
        public string Name { get; set; } // Less than or equal to 50 characters
        public int Age { get; set; } // 0 to 110
        public string PostCode { get; set; } // Must contain numbers and characters
        public double Height { get; set; } // 0 to 2.50. Only 2 decimal places
        #endregion
    }
}
