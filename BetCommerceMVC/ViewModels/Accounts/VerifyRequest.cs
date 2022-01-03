using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BetCommerceMVC.ViewModels.Accounts
{
    public class VerifyRequest
    {
        [Required]
        public string Token { get; set; }
    }
}