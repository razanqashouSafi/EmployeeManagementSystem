using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyApp.Core.Helpers
{
    public class Position
    {
        public static List<SelectListItem> Positions = new List<SelectListItem>
    {
        new SelectListItem { Text = "Front-End Developer", Value = "Front-End Developer" },
        new SelectListItem { Text = "Back-End Developer", Value = "Back-End Developer" },
        new SelectListItem { Text = "Full-Stack Developer", Value = "Full-Stack Developer" },
        new SelectListItem { Text = "Human Resources", Value = "HR" },
        new SelectListItem { Text = "Business Analyst", Value = "Business Analyst" },
        new SelectListItem { Text = "Quality Assurance", Value = "Quality Assurance" }
    };
    }
}
