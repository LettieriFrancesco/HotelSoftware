using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelSoftware.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Display(Name = "Cod.Fiscale")]
        [Required(ErrorMessage = "Il campo Cod.Fiscale è obbligatorio")]
        public string CodiceFiscale { get; set; }
        [Required(ErrorMessage = "Il campo Cognome è obbligatorio")]
        public string Cognome { get; set; }
        [Required(ErrorMessage = "Il campo Nome è obbligatorio")]
        public string Nome { get; set; }
        [Display(Name = "Città")]
        [Required(ErrorMessage = "Il campo Città è obbligatorio")]
        public string Citta { get; set; }
        public string Provincia { get; set; }
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Il campo E-mail è obbligatorio")]
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Cellulare { get; set; }

        public Cliente() { }
        public Cliente(int _id,string _codiceFiscale,string _cognome,string _nome,string _citta, string _provincia,string _email,string _telefono,string _cellulare) 
        {
            Id = _id;
            CodiceFiscale = _codiceFiscale;
            Cognome = _cognome;
            Nome = _nome;
            Citta = _citta;
            Provincia = _provincia;
            Email = _email;
            Telefono = _telefono;
            Cellulare = _cellulare;
        }
        public Cliente(string _codiceFiscale, string _cognome, string _nome, string _citta, string _provincia, string _email, string _telefono, string _cellulare) 
        {
            CodiceFiscale = _codiceFiscale;
            Cognome = _cognome;
            Nome = _nome;
            Citta = _citta;
            Provincia = _provincia;
            Email = _email;
            Telefono = _telefono;
            Cellulare = _cellulare;
        }

    }
}