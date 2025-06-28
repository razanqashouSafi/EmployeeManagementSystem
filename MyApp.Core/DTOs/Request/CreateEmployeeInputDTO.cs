﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.DTOs.Request
{
    public class CreateEmployeeInputDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }


        public string PhoneNumber { get; set; }


        public string Email { get; set; }


        public decimal Salary { get; set; }


        public string Position { get; set; }


        public DateTime? HireDate { get; set; }


        public DateTime? DateOfBirth { get; set; }
    }
}
