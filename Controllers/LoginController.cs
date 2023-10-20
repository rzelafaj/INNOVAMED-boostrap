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
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
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
                    SqlCommand cmd = new SqlCommand("Select Email, Password from Pacientes " + "where Email = @Email and Password = @Password", con);
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

                        con.Close();
                        return RedirectToAction("Index", "Home");
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

            return RedirectToAction("Index", "Home");
        }
    }
    
}