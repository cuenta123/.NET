using Subastas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;

namespace Subastas.Controllers
    {
    public class HomeController : Controller
        {
     

        
        [HttpGet]
        public ActionResult SingleProduct(int IdArticulo)
            {
          
           ArticuloDAO artdao = new ArticuloDAO();
           Articulo art = artdao.Consulta(IdArticulo);
         Page page = new Page();
            try { 
            String pagina= page.PreviousPage.Request.UrlReferrer.ToString();
                }
            catch
                {
                return View(art);
                }
            return View(art);
            }
       
        public ActionResult Login()
            {
                        
            return View(new Usuario(""," ",false));
            }
         public ActionResult AccionLogin(string Nick, string Contrasenia)
            {
             
            Login lg = new Login(Nick,Contrasenia);
            LoginDAO lgdao = new LoginDAO();
            UsuarioDao udao = new UsuarioDao();
          

           bool existe = lgdao.ConsultaSiExisteNick(Nick);
           bool autenticado = lgdao.Login(lg);
           
          if(existe!=false && autenticado!=false ) { 
                long iduser = udao.ConsultaSacaIdByNick(Nick);
               
                if(Nick=="Cipriano@gmail.com")
                    {
                    Session["Admin"] = "Cipriano@gmail.com";
                    return RedirectToAction("Index","Admin");
                    }
            if (Request.Cookies["User"] == null) {

              
               HttpCookie myCookie = new HttpCookie("User");
               myCookie["Nick"] = Nick;
               myCookie.Expires = DateTime.Now.AddDays(1d);
               Response.Cookies.Add(myCookie);

               return RedirectToAction("Index","Home");
              }
            else
                {
               //Borrar cookie
               HttpCookie myCookie2 = new HttpCookie("User");
               myCookie2.Expires = DateTime.Now.AddDays(-1d);
               Response.Cookies.Add(myCookie2);

                //Volver a crear de nuevo la cokiee
               HttpCookie myCookie = new HttpCookie("User");
               myCookie["Nick"] = Nick;
               myCookie.Expires = DateTime.Now.AddDays(1d);
               Response.Cookies.Add(myCookie);
               return RedirectToAction("Index","Home");
                }
                }
          else {               
              return View("Login",
                  new Usuario("NoExiste","El usuario o la contraseña introducidas no son correctas",true));
                }     
            }

        [HttpGet]
        public ActionResult Registro (string Nick, string Contrasenia)
            {
        
            LoginDAO ldao = new LoginDAO();
           bool existe = ldao.ConsultaSiExisteNick(Nick);
           if(existe!=true && this.ModelState.IsValid) { 
            if ( Request.Cookies["Register"] == null  ) {

                HttpCookie Register = new HttpCookie("Register");
                Register["Nick"] = Nick;
                Register["Contrasenia"] = Contrasenia;
                Register.Expires = DateTime.Now.AddHours(3);
                Response.Cookies.Add(Register);
                return View("Registro");
                }
            else
                {
               //Borrar cookie
               HttpCookie Register2 = new HttpCookie("Register");
               Register2["Nick"] = Nick;
               Register2["Contrasenia"] = Contrasenia;
               Register2.Expires = DateTime.Now.AddDays(-1d);
               Response.Cookies.Add(Register2);

                //Volver a crear de nuevo la cokiee
               HttpCookie myCookie = new HttpCookie("Register");
               myCookie["Nick"] = Nick;
               myCookie["Contrasenia"] = Contrasenia;
               myCookie.Expires = DateTime.Now.AddDays(1d);
               Response.Cookies.Add(myCookie);
               return View("Registro");
                }
                }
            else { 
            
                return View("Login",new Login("Register","Este usuario ya existe por favor elige otro",true));
                }
            }

        [HttpPost]
         public ActionResult Registro (Usuario u)
            {          
             LoginDAO ldao = new LoginDAO();
              String contrasenia =  Request.Params["Contrasenia"];
              contrasenia.Trim();
            
           bool existe = ldao.ConsultaSiExisteNick(u.CorreoElectronico.Trim());
           if(existe!=true && contrasenia!=null ) { 
           
             //  return View("Registro"); Poner aqui el código;
             LoginDAO lgdao = new LoginDAO();
              Login login = new Login();
           
          
            lgdao.Alta(new Login(u.CorreoElectronico.Trim(), contrasenia.Trim()));
            UsuarioDao udao = new UsuarioDao();
            udao.Alta(new Usuario(u.Nombre,u.CorreoElectronico.Trim(),u.Movil,u.CorreoElectronico.Trim(),true,u.CodPostal,u.Direccion," "," ",true));
            return View("Confirm");

                }
                else
                {
                 return View("Login", new Usuario(u.Nombre,u.CorreoElectronico,u.Movil,u.CorreoElectronico,true,-1," ","Register"," ",true));
                }           
            }
            

          public ActionResult Index ()
            {
                return View("Index",new Articulo());   
            }

         public ActionResult Paginacion (int Pag)
            {
            ArticuloDAO artdao = new ArticuloDAO();
            List<Articulo> ListadoArticulo = new List<Articulo>();
            ListadoArticulo = artdao.ConsultaAllPaginado(Pag);
            Articulo art = new Articulo(ListadoArticulo);
            ViewData["Pag"] = Pag;
            return View("Index",art);
                }
      //Añade una puja y sube el precio un 10%, cada uno de los tres metodos product tiene una salida 
      //distinta
          [HttpPost]  
    public ActionResult Product(int articulo)
        {
            string user;
            try { 
             user = Request.Cookies["User"]["Nick"];
                }
            catch
                {
            return View("Login",new Usuario("NoLogin","mensaje",true));
                }
            if(user!=null)
                {
                
                long IdUser;
                long userpuja;

                ArticuloDAO artdao = new ArticuloDAO();
                PujaDAO pdao = new PujaDAO();
                UsuarioDao udao = new UsuarioDao();

                IdUser = udao.ConsultaSacaIdByNick(user);  
                userpuja = pdao.ConsultaPujaIdUsuario(articulo);
        
              
       if(IdUser == userpuja)
                    {
              
               return View("SingleProduct",new Articulo(articulo,"Ganador"," ",true));
                    }
           decimal Precio =(decimal) pdao.ConsultaPrecio(articulo);
           Precio = Precio+(Precio/10);
           pdao.Alta(new Puja(IdUser,articulo,Precio));
                if(Precio==0)
                {
                 Articulo art = artdao.Consulta(articulo);
                 Precio = art.PrecioInicial+(art.PrecioInicial/10);
                 pdao.Alta(new Puja(IdUser,articulo,Precio));
                }
            else { 
                 Precio = Precio+(Precio/10);
                 pdao.Alta(new Puja(IdUser,articulo,Precio));
                }

                
                 return View("SingleProduct",new Articulo(articulo,"PujaAceptada"," ",true));
                }
        
             return RedirectToAction("SingleProduct", new {IdArticulo =articulo});
              
                
      
        }
      /** [HttpPost]
        public ActionResult ProductIndex (int articulo)
        {
          try
                {
                 string user = Request.Cookies["User"]["Nick"];
                }
            catch
                {
            return View("Login",new Usuario("NoLogin","mensaje",true));
                }
           if(Request.Cookies["User"]["Nick"]!=null) { 
          
           LoginDAO lgdao = new LoginDAO();
           string user = Request.Cookies["User"]["Nick"];
           ArticuloDAO artdao = new ArticuloDAO();
           PujaDAO pdao = new PujaDAO();
           UsuarioDao udao = new UsuarioDao();
           long IdUser = udao.ConsultaSacaIdByNick(user);
           //Devuelve el id Usuario de la ultima puja
           long userpuja = pdao.ConsultaPujaIdUsuario(articulo);
        //   if(IdUser == userpuja)
          //          {
                 
               return View("Index",new Articulo("Ganador","mensaje",true));
            //        }
           decimal Precio =(decimal) pdao.ConsultaPrecio(articulo);
            if(Precio==0)
                {
                 Articulo art = artdao.Consulta(articulo);
                 Precio = art.PrecioInicial+(art.PrecioInicial/10);
                 pdao.Alta(new Puja(IdUser,articulo,Precio));
                }
            else { 
                 Precio = Precio+(Precio/10);
                 pdao.Alta(new Puja(IdUser,articulo,Precio));
                }
                }
          
       return View("Index",new Articulo("PujaAceptada","mensaje",true));
        }
        **/
        [HttpPost]
        public ActionResult ProductTodos (int articulo)
        {        
            String user;
            try
                {
                  user = Request.Cookies["User"]["Nick"];
                }
            catch
                {
            return View("Login",new Usuario("NoLogin","mensaje",true));
                }
               
           if(user!=null)
                {
               
                long IdUser;

                UsuarioDao udao = new UsuarioDao();
                IdUser = udao.ConsultaSacaIdByNick(user);  
               
           
                ArticuloDAO artdao = new ArticuloDAO();
                PujaDAO pdao = new PujaDAO();
                long userpuja = pdao.ConsultaPujaIdUsuario(articulo);
              if(IdUser == userpuja)
                    {  
               return View("Index",new Articulo("Ganador","mensaje",true));
                    }
           decimal Precio =(decimal) pdao.ConsultaPrecio(articulo);
         
                if(Precio==0)
                {
                 Articulo art = artdao.Consulta(articulo);
                 Precio = art.PrecioInicial+(art.PrecioInicial/10);
                 pdao.Alta(new Puja(IdUser,articulo,Precio));
                }
            else { 
                 Precio = Precio+(Precio/10);
                 pdao.Alta(new Puja(IdUser,articulo,Precio));
                }

               
                return View("Index",new Articulo("PujaAceptada","mensaje",true));
                }
          else
                {
                return RedirectToAction("Login",new Usuario("NoLogin","",true));
                }
      
        }
       
        
        public ActionResult TimeOut( )
            {
           
            if(StaticBloqueoMetodo.TimeOut==true) { 
            StaticBloqueoMetodo.TimeOut=false;
            List<Articulo> articulos = StaticProduct.listado1;
            List<int> posiciones = StaticProduct.Posicion; 
         
            PujaDAO pdao = new PujaDAO(); 
            ArticuloDAO artdao = new ArticuloDAO();
            CompraDAO cdao = new CompraDAO();
            UsuarioDao udao = new UsuarioDao();
            
            for(int i=0; i<StaticProduct.Posicion.Count; i++) { 
            int  posicion2 =posiciones[i];
            Articulo art = articulos[posicion2-1];
            long IdUser = pdao.ConsultaPujaIdUsuario(art.IdArticulo);

            decimal PrecioPuja =(decimal) pdao.ConsultaPrecio(art.IdArticulo);

            if(PrecioPuja==0)
                {
                artdao.DesactivarArticulo(art.IdArticulo);
                }
            else
                {
                 artdao.ModificacionActivarComprado(art.IdArticulo);                 
                cdao.Alta(new Compra(art.IdArticulo, DateTime.Today,IdUser,pdao.ConsultaPrecio(art.IdArticulo)));
                artdao.DesactivarArticulo(art.IdArticulo);
                }        
              }
                    }   
                 StaticProduct.listado1.Clear();
                 StaticProduct.Posicion.Clear();
                 return RedirectToAction("Index");
                }
            
               
        public ActionResult TimeOutP()
            {
        
            List<Articulo> articulos = StaticProduct.listadoTodos;
            List<int> posiciones = StaticProduct.PosicionTodos; 
          
            PujaDAO pdao = new PujaDAO(); 
            ArticuloDAO artdao = new ArticuloDAO();
            CompraDAO cdao = new CompraDAO();
            UsuarioDao udao = new UsuarioDao();
            
            for(int i=0; i<posiciones.Count; i++) { 
            int  posicion2 =posiciones[i];
            Articulo art = articulos[posicion2-1];
            //long IdUser = pdao.ConsultaPujaIdUsuario(art.IdArticulo);
            decimal PrecioPuja =(decimal) pdao.ConsultaPrecio(art.IdArticulo);

            if(PrecioPuja==0)
                {
                artdao.DesactivarArticulo(art.IdArticulo);
                }
            else
                {
                 artdao.ModificacionActivarComprado(art.IdArticulo);                    
               // cdao.Alta(new Compra(art.IdArticulo, DateTime.Today,1,pdao.ConsultaPrecio(art.IdArticulo)));
                artdao.DesactivarArticulo(art.IdArticulo);
                }        
              }
           
                
            return RedirectToAction("Index");
            }
        public ActionResult Tarifas()
            {
            return View();
            }

        public ActionResult Contacto()
            {
            return View();
            }

            }
            }
     
    

    
            
        
    