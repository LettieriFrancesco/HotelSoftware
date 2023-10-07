using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelSoftware.Models
{
    public class ServiziPrenotati
    {
        public int Id { get; set; }
        public int IdPrenotazione { get; set; }
        public int IdServizio { get; set; }

        public ServiziPrenotati() { }
        public ServiziPrenotati(int _idPrenotazioneServizio,int _idPrenotazionePrenotazioni,int _idServizioServizi) 
        {
            Id = _idPrenotazioneServizio;
            IdPrenotazione = _idPrenotazionePrenotazioni;
            IdServizio = _idServizioServizi;
        }
    }
}