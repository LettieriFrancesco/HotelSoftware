using HotelSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelSoftware.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public List<SelectListItem> DescrizioneCamera
        {
            get
            {
                List<Camera> camera = new List<Camera>();
                camera = DB.DettagliCamera();
                List<SelectListItem> selectListItems = new List<SelectListItem>();
                foreach (Camera c in camera)
                {
                    SelectListItem select = new SelectListItem { Text =$"{c.Descrizione}", Value = c.Id.ToString() };
                    selectListItems.Add(select);
                }
                return selectListItems;
            }
        }
        public List<SelectListItem> NCamere
        {
            get
            {
                List<Camera> camera = new List<Camera>();
                camera = DB.DettagliCamera();
                List<SelectListItem> selectListItems = new List<SelectListItem>();
                foreach (Camera c in camera)
                {
                    SelectListItem select = new SelectListItem { Text = $"{c.Numero}| {c.Descrizione}| {c.Tipologia}", Value = c.Id.ToString() };
                    selectListItems.Add(select);
                }
                return selectListItems;
            }
        }
        public List<SelectListItem> TCamere
        {
            get
            {
                List<Camera> camera = new List<Camera>();
                camera = DB.DettagliCamera();
                List<SelectListItem> selectListItems = new List<SelectListItem>();
                foreach (Camera c in camera)
                {
                    SelectListItem select = new SelectListItem { Text = $"{c.Tipologia}", Value = c.Id.ToString() };
                    selectListItems.Add(select);
                }
                return selectListItems;
            }
        }
        public List<SelectListItem> DescrizioneCliente
        {
            get
            {
                List<Cliente> cliente = new List<Cliente>();
                cliente = DB.AnagraficaClienti();
                List<SelectListItem> selectListItems = new List<SelectListItem>();
                foreach (Cliente c in cliente)
                {
                    SelectListItem select = new SelectListItem { Text = $"{c.Nome} {c.Cognome}", Value = c.Id.ToString() };
                    selectListItems.Add(select);
                }
                return selectListItems;
            }
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ClientiRegistrati()
        {
            List<Cliente> list = DB.AnagraficaClienti();
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Cliente cl)
        {
            if (ModelState.IsValid)
            {
                DB.CreaCliente(cl);
                TempData["MessaggioDiConfermaCrea"] = "Salvataggio nuovo cliente effettuato";
                return RedirectToAction("ClientiRegistrati","Admin");
            }
            else { return ViewBag.messaggioErrore = "Si e verificato un errore nella registrazione dei dati"; }
        }
        public ActionResult Edit(int id)
        {
            Cliente c = DB.getClienteById(id);
            return View(c);
        }
        [HttpPost]
        public ActionResult Edit(Cliente c)
        {
            if (ModelState.IsValid)
            {
                DB.UpdateCliente(c.Id,c.CodiceFiscale,c.Cognome,c.Nome,c.Citta,c.Provincia,c.Email,c.Telefono,c.Cellulare);
                TempData["MessaggioDiConfermaModifica"] = "Dati clienti aggiornati";
                return RedirectToAction("ClientiRegistrati", "Admin");
            }
            else return View(c);
        }
        public ActionResult PrenotazioniRegistrate()
        {
            List<Prenotazione> pr = DB.ListaPrenotazioni();
            return View(pr);
        }
        public ActionResult CreatePrenotazione()
        {
            ViewBag.dettagliCliente = DescrizioneCliente;
            ViewBag.numeroCamere = NCamere;
            ViewBag.dettagliCamere = DescrizioneCamera;
            ViewBag.tipologiaCamere = TCamere;
            return View();
        }
        [HttpPost]
        public ActionResult CreatePrenotazione(Prenotazione pr)
        {
            if (ModelState.IsValid)
            {
                DB.CreaPrenotazione(pr);
                return RedirectToAction("Index");
            }
            else { return ViewBag.messaggioErrore = "Caricamento dati fallito"; }
        }
    }

}
