using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelSoftware.Models
{
    public class Utente
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Il campo Username è obbligatorio")]
        public string UsernameUtente { get; set; }
        [Display(Name = "Password")]
        public string PasswordUtente { get; set; }
    }
}