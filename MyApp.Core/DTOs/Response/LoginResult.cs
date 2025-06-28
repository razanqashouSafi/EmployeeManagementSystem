using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.DTOs.Response
{
    public class LoginResult
    {
        public bool IsSuccess { get; set; }  // true if login OK
        public string Token { get; set; }    // JWT token if success
        public string ErrorMessage { get; set; }  // error message if failed
    }
}
