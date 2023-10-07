using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelSoftware.Models
{
    public class Servizio
    {
        public int Id { get; set; }
        public string ServizioRichiesto { get; set; }
        public DateTime DataServizio { get; set; }
        public int Quantita { get; set; }
        public double Prezzo { get; set; }

        public Servizio() { }
        public Servizio(int _idServizio,string _servizioRichiesto,DateTime _dataServizio,int _quantita,double _prezzo) 
        {
            Id = _idServizio;
            ServizioRichiesto = _servizioRichiesto;
            DataServizio = _dataServizio;
            Quantita = _quantita;
            Prezzo = _prezzo;
        }
    }
}