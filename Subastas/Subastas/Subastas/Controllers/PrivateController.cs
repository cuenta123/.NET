using Subastas.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Subastas.Controllers
{
    public class PrivateController : Controller
    {
            Usuario u;
            UsuarioDao udao;
            Login lg;
            LoginDAO lgdao;
            CompraDAO cdao;
        public ActionResult Index()
        {          
           if (Request.Cookies["User"] != null) {
                udao = new UsuarioDao();
              string user = Request.Cookies["User"]["Nick"];
              long iduser = udao.ConsultaSacaIdByNick(user);
               udao = new UsuarioDao();
               u = udao.Consulta(iduser);

                return View(u);
              }
            else
                {
             return RedirectToAction ("Index","Home");
                }            
        }
        public ActionResult Puja()
            {
            return View();
            }

         public ActionResult Compra()
            {

             if (Request.Cookies["User"] != null) {
               
              string user = Request.Cookies["User"]["Nick"];
              return View();
              }
            else
                {
             return RedirectToAction ("Index","Home");
                }

            }
        
       
    }
}