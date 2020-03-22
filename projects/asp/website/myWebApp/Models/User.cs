using System;
using System.ComponentModel.DataAnnotations;

namespace myWebApp.Models
{
    public class User
    {
        public int Id { get ;set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }
}