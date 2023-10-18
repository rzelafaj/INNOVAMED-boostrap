using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//asemos referencia al modelo de la solucion
using INNOVAMED.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


namespace INNOVAMED.Controllers
{
    public class RegistroController : Controller
    {
        
        // GET: Registro
        public ActionResult RegistrarPaciente()
        {
            return View();
        }

        //utilizacion de metodo http post para llamado de medo y interacion con la base de datos 
        [HttpPost]
        public ActionResult CrearPaciente(Pacientes P)
        {

            
            if (ModelState.IsValid)
            {
                try
                {
                   // instancia a la cadena de conexion
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

                    //objeto de tipo command type para interactuar con sql
                    SqlCommand cmd = new SqlCommand("Insert into Pacientes (Nombre, Apellido, DUI, FechaNacimiento, Direccion, Telefono, Email, " +
                        "Password, Responsable, TelefonoResponsable, Estado) Values (@PNombre, @PApellido, @PDUI, @PFechaNacimiento, @PDireccion, @PTelefono, @PEmail," +
                        "@PPassword, @PResponsable, @PTelefonoResponsable, @PEstado)", con);
                    cmd.CommandType = CommandType.Text;
                    P.Estado = true;
                    cmd.Parameters.Add("@PNombre", SqlDbType.VarChar).Value = P.Nombre;
                    cmd.Parameters.Add("@PApellido", SqlDbType.VarChar).Value = P.Apellido;
                    cmd.Parameters.Add("@PDUI", SqlDbType.VarChar).Value = P.DUI;
                    cmd.Parameters.Add("@PFechaNacimiento", SqlDbType.Date).Value = P.FechaNacimiento;
                    cmd.Parameters.Add("@PDireccion", SqlDbType.VarChar).Value = P.Direccion;
                    cmd.Parameters.Add("@PTelefono", SqlDbType.VarChar).Value = P.Telefono;
                    cmd.Parameters.Add("@PEmail", SqlDbType.VarChar).Value = P.Email;
                    cmd.Parameters.Add("@PPassword", SqlDbType.VarChar).Value = P.Password;
                    cmd.Parameters.Add("@PResponsable", SqlDbType.VarChar).Value = P.Responsable;
                    cmd.Parameters.Add("@PTelefonoResponsable", SqlDbType.VarChar).Value = P.TelefonoResponsable;
                    cmd.Parameters.Add("@PEstado", SqlDbType.Bit).Value = P.Estado;
                    //abrimos la conexion
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    return View("RegistrarPaciente");
                    throw ex;
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
   
}