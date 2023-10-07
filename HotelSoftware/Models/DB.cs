using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelSoftware.Models
{
    public class DB
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
        public static SqlConnection conn = new SqlConnection(connectionString);

        public static List<Cliente> AnagraficaClienti()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM CLIENTI", conn);
            SqlDataReader sqlDataReader;
            conn.Open();
            List<Cliente>ClientiList = new List<Cliente>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Cliente client = new Cliente(
                    Convert.ToInt32(sqlDataReader["IdCliente"]),
                    sqlDataReader["CodiceFiscale"].ToString(),
                    sqlDataReader["Cognome"].ToString(),
                    sqlDataReader["Nome"].ToString(),
                    sqlDataReader["Citta"].ToString(),
                    sqlDataReader["Provincia"].ToString(),
                    sqlDataReader["Email"].ToString(),
                    sqlDataReader["Telefono"].ToString(),
                    sqlDataReader["Cellulare"].ToString()
                    );
                ClientiList.Add( client );
            }
            conn.Close();
            return ClientiList;
        }
        public static void CreaCliente(Cliente cliente)
        {
            try 
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO CLIENTI(CodiceFiscale, Cognome, Nome, Citta, Provincia, Email, Telefono, Cellulare)" +
                                    "VALUES(@CodiceFiscale, @Cognome, @Nome, @Citta, @Provincia, @Email, @Telefono, @Cellulare)";
                cmd.Parameters.AddWithValue("@CodiceFiscale", cliente.CodiceFiscale);
                cmd.Parameters.AddWithValue("@Cognome", cliente.Cognome);
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@Citta", cliente.Citta);
                cmd.Parameters.AddWithValue("@Provincia", cliente.Provincia);
                cmd.Parameters.AddWithValue("@Email", cliente.Email);
                cmd.Parameters.AddWithValue("@Telefono",(object)cliente.Telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Cellulare", (object)cliente.Cellulare ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex) 
            {

            }
            finally { conn.Close(); }
        }
        public static Cliente getClienteById(int id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM CLIENTI WHERE IdCliente = @Id", conn);
            cmd.Parameters.AddWithValue("Id", id);
            SqlDataReader sqlDataReader;
            conn.Open();

            Cliente cliente = new Cliente();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                cliente.Id = Convert.ToInt32(sqlDataReader["IdCliente"]);
                cliente.CodiceFiscale = sqlDataReader["CodiceFiscale"].ToString();
                cliente.Cognome = sqlDataReader["Cognome"].ToString();
                cliente.Nome = sqlDataReader["Nome"].ToString();
                cliente.Citta = sqlDataReader["Citta"].ToString();
                cliente.Provincia = sqlDataReader["Provincia"].ToString();
                cliente.Email = sqlDataReader["Email"].ToString();
                cliente.Telefono = sqlDataReader["Telefono"].ToString();
                cliente.Cellulare = sqlDataReader["Cellulare"].ToString();
            }
            conn.Close();
            return cliente;
        }
        public static void UpdateCliente(int id, string codiceFiscale, string cognome, string nome, string citta, string provincia, string email,string telefono, string cellulare)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE CLIENTI SET CodiceFiscale=@codicefiscale, Cognome=@cognome, Nome=@nome, Citta=@citta, Provincia=@provincia, Email=@email, Telefono=@telefono, Cellulare=@cellulare WHERE IdCliente=@id";
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("codiceFiscale", (object)codiceFiscale ?? DBNull.Value);
                cmd.Parameters.AddWithValue("cognome", cognome);
                cmd.Parameters.AddWithValue("nome", nome);
                cmd.Parameters.AddWithValue("citta", citta);
                cmd.Parameters.AddWithValue("provincia", provincia);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("telefono", (object)telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("cellulare", (object)cellulare ?? DBNull.Value);
                int completato = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally { conn.Close(); }
        }
        public static List<Prenotazione> ListaPrenotazioni()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PRENOTAZIONI", conn);
            SqlDataReader sqlDataReader;
            conn.Open();
            List<Prenotazione> prenotazioniList = new List<Prenotazione>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Prenotazione prenotazione = new Prenotazione(
                    Convert.ToInt32(sqlDataReader["IdPrenotazione"]),
                    Convert.ToInt32(sqlDataReader["IdCliente"]),
                    Convert.ToInt32(sqlDataReader["NumeroCamera"]),
                    DateTime.Parse(sqlDataReader["DataPrenotazione"].ToString()),
                    Convert.ToInt32(sqlDataReader["Anno"]),
                    DateTime.Parse(sqlDataReader["DataCheckIn"].ToString()),
                    DateTime.Parse(sqlDataReader["DataCheckOut"].ToString()),
                    Convert.ToInt32(sqlDataReader["Caparra"]),
                    Convert.ToInt32(sqlDataReader["Tariffa"]),
                    sqlDataReader["DettagliPrenotazione"].ToString()
                    );
                prenotazioniList.Add( prenotazione );
            }
            conn.Close();
            return prenotazioniList;
        }
        public static void CreaPrenotazione(Prenotazione prenotazione) 
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO PRENOTAZIONI (IdCliente, NumeroCamera, DataPrenotazione, Anno, DataCheckIn, DataCheckOut, Caparra, Tariffa, DettagliPrenotazione)" +
                                   "VALUES (@IdCliente, @NumeroCamera, @DataPrenotazione, @Anno, @DataCheckIn, @DataCheckOut, @Caparra, @Tariffa, @DettagliPrenotazione)";
                cmd.Parameters.AddWithValue("@IdCliente", prenotazione.IdCliente);
                cmd.Parameters.AddWithValue("@NumeroCamera", prenotazione.NumeroCamera);
                cmd.Parameters.AddWithValue("@DataPrenotazione", prenotazione.DataPrenotazione);
                cmd.Parameters.AddWithValue("@Anno", prenotazione.Anno);
                cmd.Parameters.AddWithValue("@DataCheckIn", prenotazione.DataCheckIn);
                cmd.Parameters.AddWithValue("@DataCheckOut", prenotazione.DataCheckOut);
                cmd.Parameters.AddWithValue("@Caparra", prenotazione.Caparra);
                cmd.Parameters.AddWithValue("@Tariffa", prenotazione.Tariffa);
                cmd.Parameters.AddWithValue("@DettagliPrenotazione", prenotazione.DettagliPrenotazione);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally { conn.Close(); }
        }
        public static List<Camera> DettagliCamera()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM CAMERE", conn);
            SqlDataReader sqlDataReader;
            conn.Open();
            List<Camera> cameraDescr = new List<Camera>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Camera cam = new Camera(
                    Convert.ToInt32(sqlDataReader["IdCamera"]),
                    Convert.ToInt32(sqlDataReader["Numero"]),
                    sqlDataReader["Descrizione"].ToString(),
                    sqlDataReader["Tipologia"].ToString()
                    );
                cameraDescr.Add( cam );
            }
            conn.Close();
            return cameraDescr;
        }
        public static Camera getCameraById(int id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM CAMERE WHERE IdCamera=@id", conn);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader sqlDataReader;
            conn.Open();
            Camera camera = new Camera();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                camera.Id = Convert.ToInt32(sqlDataReader["IdCamera"]);
                camera.Numero = Convert.ToInt32(sqlDataReader["Numero"]);
                camera.Descrizione = sqlDataReader["Descrizione"].ToString();
                camera.Tipologia = sqlDataReader["Tipologia"].ToString();
            }
            conn.Close();
            return camera;
        }
        public static List<ServiziPrenotati> DettagliServizi()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PRENOTAZIONE_SERVIZI", conn);
            SqlDataReader sqlDataReader;
            conn.Open();
            List<ServiziPrenotati> cameraDescr = new List<ServiziPrenotati>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                ServiziPrenotati cam = new ServiziPrenotati(
                    Convert.ToInt32(sqlDataReader["IdPrenotazioneServizio"]),
                    Convert.ToInt32(sqlDataReader["IdPrenotazione"]),
                    Convert.ToInt32(sqlDataReader["IdServizio"])
                    );
                cameraDescr.Add(cam);
            }
            conn.Close();
            return cameraDescr;
        }

    }
}