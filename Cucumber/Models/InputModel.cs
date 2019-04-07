using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cucumber.Models
{
    public class InputModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Currency { get; set; }
    }
}