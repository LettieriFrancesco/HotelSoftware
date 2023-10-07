using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelSoftware.Models
{
    public class Prenotazione
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int NumeroCamera { get; set; }
        public DateTime DataPrenotazione { get; set; }
        public int Anno { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }
        public double Caparra { get; set; }
        public double Tariffa { get; set;}
        public string DettagliPrenotazione { get; set;}

        public Prenotazione() { }
        public Prenotazione(int _idPrenotazione,int _idCliente,int _numeroCamera,DateTime _dataPrenotazione,int _annoCorrente,DateTime _dataCheckIn, DateTime _dataCheckOut,double _caparra,double _tariffa,string _dettagliPrenotazione) 
        {
            Id = _idPrenotazione;
            IdCliente = _idCliente;
            NumeroCamera = _numeroCamera;
            DataPrenotazione = _dataPrenotazione;
            Anno = _annoCorrente;
            DataCheckIn = _dataCheckIn;
            DataCheckOut = _dataCheckOut;
            Caparra = _caparra;
            Tariffa = _tariffa;
            DettagliPrenotazione = _dettagliPrenotazione;
        }
        public Prenotazione(int _idCliente, int _numeroCamera, DateTime _dataPrenotazione, int _annoCorrente, DateTime _dataCheckIn, DateTime _dataCheckOut, double _caparra, double _tariffa, string _dettagliPrenotazione)
        {
            IdCliente = _idCliente;
            NumeroCamera = _numeroCamera;
            DataPrenotazione = _dataPrenotazione;
            Anno = _annoCorrente;
            DataCheckIn = _dataCheckIn;
            DataCheckOut = _dataCheckOut;
            Caparra = _caparra;
            Tariffa = _tariffa;
            DettagliPrenotazione = _dettagliPrenotazione;
        }

    }
}