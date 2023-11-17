using INNOVAMED.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
<<<<<<< HEAD
using System.Data;
using System.Data.SqlClient;
=======
using System.Data.SqlClient;
using System.Data;
>>>>>>> 5c1fc4a2da1ac5e2ad8100d5721f3e0b568aae17
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
<<<<<<< HEAD
            SqlCommand cmd = new SqlCommand("Select IdMedico, Nombre, Apellido, IdEspecialidad " +
                                            "from Medicos where IdEspecialidad = 1", con);

            //abrimos conexion 
            con.Open();

            SqlDataReader rd = cmd.ExecuteReader();
            //recoremos la tabla y almacenamos la informacion en variables locales para agragarlas a la lista 
            while (rd.Read())
            {
                //Creamos un objeto de la clase Medicos 
                Medicos oMedicos = new Medicos();

                oMedicos.IdMedico = Convert.ToInt32(rd["IdMedico"]);
                oMedicos.Nombre = rd["Nombre"].ToString();
                oMedicos.Apellido = rd["Apellido"].ToString();
                oMedicos.IdEspecialidad = Convert.ToInt32(rd["IdEspecialidad"]);

                Models.MedicinaGeneral.LstMedicos.Add(oMedicos);
            }
=======
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
>>>>>>> 5c1fc4a2da1ac5e2ad8100d5721f3e0b568aae17
            con.Close();

            // creamos una nueva lista para el drowdoplist de Especialidades 
            List<SelectListItem> list2 = new List<SelectListItem>();
<<<<<<< HEAD

=======
            
>>>>>>> 5c1fc4a2da1ac5e2ad8100d5721f3e0b568aae17
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
<<<<<<< HEAD


                list2.Add(new SelectListItem { Value = IdEspecialidad.ToString(), Text = Nomb });
=======
                

                list2.Add(new SelectListItem { Value = IdEspecialidad.ToString(), Text = Nomb});
>>>>>>> 5c1fc4a2da1ac5e2ad8100d5721f3e0b568aae17
            }
            ViewBag.Especialidades = list2;
            con.Close();

<<<<<<< HEAD

            List<SelectListItem> list3 = new List<SelectListItem>();

            //hacemos la consulta a sql 
            cmd = new SqlCommand("Select IdHorario, Horario from Horarios order by IdHorario", con);
=======
            // creamos una nueva lista para el drowdoplist de Especialidades 
            List<SelectListItem> list3 = new List<SelectListItem>();

            //hacemos la consulta a sql 
            cmd = new SqlCommand("Select IdHorario, Horario from Horarios", con);
>>>>>>> 5c1fc4a2da1ac5e2ad8100d5721f3e0b568aae17

            //abirmos la conexion
            con.Open();

            SqlDataReader rd3 = cmd.ExecuteReader();

            //recoremos la tabla y almacenamos la informacion en variables locales para agragarlas a la lista 
            while (rd3.Read())
            {
                int IdHorario = Convert.ToInt32(rd3["IdHorario"]);
                string Nom = rd3["Horario"].ToString();


<<<<<<< HEAD
                list3.Add(new SelectListItem { Value = Nom.ToString(), Text = Nom });
            }
            ViewBag.Horarios = list3;
            con.Close();
            return View();
        }

        [HttpPost]
        public ActionResult CrearCita(MedicinaGeneral c)
=======
                list3.Add(new SelectListItem { Value = IdHorario.ToString(), Text = Nom });
            }
            ViewBag.Horarios = list3;
            con.Close(); 
            return View();
        }
       


    [HttpPost]
        public ActionResult CrearCita(Citas c)
>>>>>>> 5c1fc4a2da1ac5e2ad8100d5721f3e0b568aae17
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // instancia a la cadena de conexion
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
<<<<<<< HEAD

                    //objeto de tipo command type para interactuar con sql
                    SqlCommand cmd = new SqlCommand("Insert into Citas (IdPaciente, IdMedico, Fecha, Hora, Especialidad, Estado)" +
                        " Values (@PIdPaciente, @PIdMedico, @PFecha, @PHora, @PEspecialidad, @PEstado)", con);
                    cmd.CommandType = CommandType.Text;

                    c.Estado = true;

                    int IdPaciente = (int)Session["IdPaciente"];

                    cmd.Parameters.Add("@PIdPaciente", SqlDbType.Int).Value = IdPaciente;
                    cmd.Parameters.Add("@PIdMedico", SqlDbType.Int).Value = c.IdMedico;
                    cmd.Parameters.Add("@PFecha", SqlDbType.Date).Value = c.Fecha;
                    cmd.Parameters.Add("@PHora", SqlDbType.VarChar).Value = c.Hora;
                    cmd.Parameters.Add("@PIdEspecialidad", SqlDbType.Int).Value = c.IdEspecialidad;
                    cmd.Parameters.Add("@PEstado", SqlDbType.Bit).Value = c.Estado;

                    //abrimos la conexion
                    con.Open();
                    cmd.ExecuteNonQuery();


                    con.Close();


                }
                catch (Exception ex)
                {
=======
                   
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

>>>>>>> 5c1fc4a2da1ac5e2ad8100d5721f3e0b568aae17
                    return View("MedicinaGeneral");
                    throw ex;
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
