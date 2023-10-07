using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelSoftware.Models
{
    public class Camera
    {
        public int Id { get; set; }
        public int Numero {  get; set; }
        public string Descrizione { get; set; }
        public string Tipologia { get; set; }

        public Camera() { }
        public Camera(int _id,int _numeroCamera,string _descrizioneCamera,string _tipolgiaCamera) 
        {
            Id = _id;
            Numero = _numeroCamera;
            Descrizione = _descrizioneCamera;
            Tipologia = _tipolgiaCamera;
        }
    }
}