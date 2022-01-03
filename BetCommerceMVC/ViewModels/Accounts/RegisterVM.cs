using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetCommerceMVC.ViewModels.Accounts
{
    public class RegisterVM
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool acceptTerms { get; set; }
    }
}