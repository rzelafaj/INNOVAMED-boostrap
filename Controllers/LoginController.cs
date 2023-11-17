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
using System.Security.Principal;


namespace INNOVAMED.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        // GET: Login
        public ActionResult Login()
        { 
           return View();
        }

        public ActionResult CerrarSecion()
        {
            Session["UsuarioLogueado"] = false;
<<<<<<< HEAD
            return RedirectToAction("Index", "Home");
=======
            return RedirectToAction("Index", "Home"); 
>>>>>>> 5c1fc4a2da1ac5e2ad8100d5721f3e0b568aae17
        }
        //utilizacion de metodo http post para llamado de medo y interacion con la base de datos 
        [HttpPost]
        public ActionResult AccederSistema(Pacientes P)
        {
            if (ModelState.IsValid)
            {

                SqlDataReader Lector = null;

                try
                {
                    // instancia a la cadena de conexion
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

                    //objeto de tipo command type para interactuar con sql
<<<<<<< HEAD
                    SqlCommand cmd = new SqlCommand("Select IdUsuario, Email, Password from Usuarios where Email = @Email and Password = @Password", con);
=======
                    SqlCommand cmd = new SqlCommand("Select IdPaciente, Email, Password from Pacientes where Email = @Email and Password = @Password", con);
>>>>>>> 5c1fc4a2da1ac5e2ad8100d5721f3e0b568aae17
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = P.Email;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = P.Password;
                    //abrimos la conexion
                    con.Open();
                    Lector = cmd.ExecuteReader();

                    if (Lector.Read())
                    {

                        // Pasamos los datos obtenidos en el query
                        P.Email = Lector["Email"].ToString();
                        P.Password = Lector["Password"].ToString();
<<<<<<< HEAD

                        //guardamos la sesion en un variable de session
                        Session["UsuarioLogueado"] = true;

                        //guardamos el Id del Paciente en una varible de Session
                        Session["IdPaciente"] = Lector["IdUsuario"];
                        con.Close();

=======
                        //guardamos la sesion en un variable de session
                        Session["UsuarioLogueado"] = true;
                        //guardamos el Id del Paciente en una varible de Session
                        Session["IdPaciente"] = Lector["IdPaciente"];
                        con.Close();
                        
>>>>>>> 5c1fc4a2da1ac5e2ad8100d5721f3e0b568aae17
                    }
                    else
                    {
                        con.Close();
                        Response.Write("<script>alert('USUARIO O CONTRASEÑA INCORRECTO')</script>");
                        return View("Login");
                    }

                }
                catch (Exception ex)
                {
                    return View("Login");
                    throw ex;
                }
            }
            Response.Write("<script>alert('Bienvenido sesion iniciada')</script>");
            return RedirectToAction("Index", "Home");
        }
    }
    
}