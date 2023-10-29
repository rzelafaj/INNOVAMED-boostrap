using INNOVAMED.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.SqlServer.Server;
using System.Drawing;

namespace INNOVAMED.Controllers
{
    public class MedicinaGeneralController : Controller
    {
        // GET: MedicinaGeneral
        public ActionResult MedicinaGeneral()
        {

            // listamos los los medicos para mostrarlos en el dorwdoplist

            List<SelectListItem> list = new List<SelectListItem>();

            //definimos la cadena de conexion 
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

            //realizamos la consulta a sql 
            SqlCommand cmd = new SqlCommand("Select IdMedico,Nombre, Apellido from Medicos ", con);

            //abrimos conexion 
            con.Open();
            
            SqlDataReader rd= cmd.ExecuteReader();
            //recoremos la tabla y almacenamos la informacion en variables locales para agragarlas a la lista 
            while (rd.Read())
            { 
                int IdMedico = Convert.ToInt32(rd["IdMedico"]);
                string Nombre = rd["Nombre"].ToString();
                string Apellido = rd["Apellido"].ToString();

                list.Add(new SelectListItem { Value = IdMedico.ToString(), Text = Nombre +" "+ Apellido }) ;
            }
            ViewBag.Medicos = list;
            con.Close();

            // creamos una nueva lista para el drowdoplist de Especialidades 
            List<SelectListItem> list2 = new List<SelectListItem>();
            
            //hacemos la consulta a sql 
            cmd = new SqlCommand("Select IdEspecialidad,Especialidad from Especialidades", con);

            //abirmos la conexion
            con.Open();

            SqlDataReader rd2 = cmd.ExecuteReader();

            //recoremos la tabla y almacenamos la informacion en variables locales para agragarlas a la lista 
            while (rd2.Read())
            {
                int IdEspecialidad = Convert.ToInt32(rd2["IdEspecialidad"]);
                string Nomb = rd2["Especialidad"].ToString();
                

                list2.Add(new SelectListItem { Value = IdEspecialidad.ToString(), Text = Nomb});
            }
            ViewBag.Especialidades = list2;
            con.Close();

            // creamos una nueva lista para el drowdoplist de Especialidades 
            List<SelectListItem> list3 = new List<SelectListItem>();

            //hacemos la consulta a sql 
            cmd = new SqlCommand("Select IdHorario, Horario from Horarios", con);

            //abirmos la conexion
            con.Open();

            SqlDataReader rd3 = cmd.ExecuteReader();

            //recoremos la tabla y almacenamos la informacion en variables locales para agragarlas a la lista 
            while (rd3.Read())
            {
                int IdHorario = Convert.ToInt32(rd3["IdHorario"]);
                string Nom = rd3["Horario"].ToString();


                list3.Add(new SelectListItem { Value = IdHorario.ToString(), Text = Nom });
            }
            ViewBag.Horarios = list3;
            con.Close(); 
            return View();
        }
       


    [HttpPost]
        public ActionResult CrearCita(Citas c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // instancia a la cadena de conexion
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
                   
                    //objeto de tipo command type para interactuar con sql
                    SqlCommand cmd = new SqlCommand("Insert into Citas (IdPaciente, IdMedico, Fecha, Hora, Estado, IdEspecialidad)" +
                        " Values (@PIdPaciente, @PIdMedico, @PFecha, @PHora, @PEstado, @PIdEspecialidad)", con);
                    cmd.CommandType = CommandType.Text;
                    c.Estado = true;
                    int IdPaciente = (int)Session["IdPaciente"]; 
                    cmd.Parameters.Add("@PIdPaciente", SqlDbType.Int).Value = IdPaciente;
                    cmd.Parameters.Add("@PIdMedico", SqlDbType.Int).Value = c.IdMedico;
                    cmd.Parameters.Add("@PFecha", SqlDbType.Date).Value = c.Fecha;
                    cmd.Parameters.Add("@PHora", SqlDbType. VarChar).Value = c.Hora;
                    cmd.Parameters.Add("@PEstado", SqlDbType.Bit).Value = c.Estado;
                    cmd.Parameters.Add("@PIdEspecialidad", SqlDbType.Int).Value = c.IdEspecialidad;
                    //abrimos la conexion
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Write("<script>alert('Su cita Fue Agendada con exito')</script>");
                }
                catch (Exception ex)
                {

                    return View("MedicinaGeneral");
                    throw ex;
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
//// instancia a la cadena de conexion
//SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
////verificamos si el paciente esta dentro de la base de datos 
//SqlCommand cmd = new SqlCommand("select IdPaciente,Nombre from Pacientes where Nombre like'%'+ @PNombre +'%'", con);
//cmd.Parameters.AddWithValue("@PNombre", P.Nombre);
//            con.Open();

//            SqlDataReader reader = cmd.ExecuteReader();
//            if (reader.HasRows)
//            {
//                IdPaciente = Convert.ToInt32(reader["IdPaciente"]);
//            }