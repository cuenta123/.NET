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
    public class AdminController : Controller
    {
  
            Usuario u;
            UsuarioDao udao;
            Login lg;
            LoginDAO lgdao;
            CompraDAO cdao;
            Puja pj;
            PujaDAO pjdao;
         
        ArticuloDAO artdao;
        public ActionResult Index()
        {
           if (Session["Admin"] != null) {          
                udao = new UsuarioDao();
              
                return View();
              }
            else
                {
             return RedirectToAction ("Index","Home");
                }
            } 
        [HttpGet]
        public ActionResult ModificarArt(long IdArticulo)
            {
             if (Session["Admin"] != null) {   
            artdao = new ArticuloDAO();
          Articulo art =  artdao.Consulta(IdArticulo);
            return View(art);
                }
             else
                {
                return RedirectToAction("Index","Home");
                }
            }

        [HttpPost]
        public ActionResult ModificarArt(long IdArticulo,string Categoria, string Titulo, string Descripcion,DateTime FechaFinal, string FotoPrincipal,
           DateTime Fecha,decimal PrecioInicial, bool Activo)
            {
             if (Session["Admin"] != null) {   
          artdao = new ArticuloDAO();
            artdao.Modificacion(new Articulo(IdArticulo,Categoria,Titulo,Descripcion,1,Fecha,PrecioInicial,FechaFinal,Activo,FotoPrincipal,false));
            return RedirectToAction("Index");
                }
             else
                {
                 return RedirectToAction("Index","Home");
                }
            }    
        public ActionResult Compra()
            {
               cdao = new CompraDAO();
         if (Session["Admin"] != null) {    
                 StaticProduct.listadoCompraArticuloUsuario = cdao.ConsultaAllCompraArticuloUser();
                return View();
               
              }
            else
                {
                return RedirectToAction ("Index","Home");
                }
            }

         [HttpGet]
        public ActionResult Articulo()
            {
             if (Session["Admin"] != null) {   

            return View(new Articulo());
                }
             else
                {
                 return RedirectToAction ("Index","Home");
                }
            }
     [HttpPost]
     public ActionResult Articulo(string Categoria, string Titulo, string Descripcion,DateTime FechaFinal, string FotoPrincipal,
          decimal PrecioInicial, bool Activo)
            {
             if (Session["Admin"] != null) {   
            artdao = new ArticuloDAO();
            artdao.AltaSinFoto(new Articulo(Categoria,Titulo,Descripcion,1,DateTime.Now,PrecioInicial,FechaFinal,Activo,FotoPrincipal,false));
            return RedirectToAction("Foto");
                }
             else
                {
                 return RedirectToAction ("Index","Home");
                }
            }  

        [HttpGet]  
        public ActionResult Foto()
            {
            if (Session["Admin"] != null) { 
            artdao = new ArticuloDAO();
            Articulo art = artdao.ConsultaUltimoArticulo();
            StaticProduct.Producto = art.IdArticulo;
            return View();
                }
            else
                {
                return RedirectToAction ("Index","Home");
                }
            }

       [HttpPost]
        public ActionResult Foto(HttpPostedFileBase file) { 
        if (this.ModelState.IsValid && StaticProduct.Producto!=0)
                {
                //   La carpeta App_Data es una buena ubicación para almacenar
                //         los ficheros subidos

                String DestDirVPath = "~/Content/"+StaticProduct.Producto;

                //        Obtiene la ruta física absoluta de la carpeta App_Data de la
                //      aplicación

                string destDirPhysPath = this.Server.MapPath(DestDirVPath);
               
                // Crea la carpeta si es necesario
                System.IO.Directory.CreateDirectory(destDirPhysPath);
                
                string extension = Path.GetExtension(file.FileName);

                 //    Obtiene el nombre y extensión del fichero subido por el cliente
                //Parte de la comprobacion del fichero
                String fichero = Path.GetFileNameWithoutExtension(file.FileName);

                fichero = Path.GetFileName(file.FileName);
                // Construye la ruta física absoluta donde se va a guardar
                // el fichero. Esta ruta debe incluir el nombre del fichero.
                StringBuilder FileBuilder = new StringBuilder();
                FileBuilder.Append(destDirPhysPath);
                FileBuilder.Append(Path.DirectorySeparatorChar);
                FileBuilder.Append(Path.GetFileName(file.FileName));
                String rutafinal = FileBuilder.ToString();
                //   Guarda el fichero en disco.
                file.SaveAs(rutafinal);

                 ArticuloDAO artdao = new ArticuloDAO();
                Articulo art = artdao.ConsultaUltimoArticulo();
                artdao.ModificacionFoto(art.IdArticulo,DestDirVPath+"//"+file.FileName);
               
                return RedirectToAction("Foto");
                }
            else
                {
                return RedirectToAction("Index", "El modelo no ha sido valido");

                }
            }
            
         [HttpPost]
        public ActionResult FotoArticulo(HttpPostedFileBase file) { 
        if (this.ModelState.IsValid && StaticProduct.Producto!=0)
                {
                //   La carpeta App_Data es una buena ubicación para almacenar
                //         los ficheros subidos

                String DestDirVPath = "~/Content/"+StaticProduct.Producto;

                //        Obtiene la ruta física absoluta de la carpeta App_Data de la
                //      aplicación
                string destDirPhysPath = this.Server.MapPath(DestDirVPath);
               
                // Crea la carpeta si es necesario       
                string extension = Path.GetExtension(file.FileName);

                 //    Obtiene el nombre y extensión del fichero subido por el cliente
                //Parte de la comprobacion del fichero
                String fichero = Path.GetFileNameWithoutExtension(file.FileName);

                fichero = Path.GetFileName(file.FileName);
                // Construye la ruta física absoluta donde se va a guardar
                // el fichero. Esta ruta debe incluir el nombre del fichero.
                StringBuilder FileBuilder = new StringBuilder();
                FileBuilder.Append(destDirPhysPath);
                FileBuilder.Append(Path.DirectorySeparatorChar);
                FileBuilder.Append(Path.GetFileName(file.FileName));
                String rutafinal = FileBuilder.ToString();
                //   Guarda el fichero en disco.
                file.SaveAs(rutafinal);

                ArticuloDAO artdao = new ArticuloDAO();
                Articulo art = artdao.ConsultaUltimoArticulo();
                FotoDAO foto = new FotoDAO();
                foto.Alta(new Models.Foto(art.IdArticulo,DestDirVPath+"//"+file.FileName));
               
                return RedirectToAction("Foto");
                }
            else
                {
                return RedirectToAction("Index", "El modelo no ha sido valido");
                }
            }

        [HttpGet]
        public ActionResult ActivarArticulo()
            {
             if (Session["Admin"] != null) { 
            return View();
                }
             else
                {
                 return RedirectToAction ("Index","Home");
                }
            }
        
        public ActionResult AccionActivarArticulo(long IdArticulo)
            {
               if (Session["Admin"] != null) { 
           ArticuloDAO artdao = new ArticuloDAO();
            artdao.ActivarArticulo(IdArticulo);
            return View("ActivarArticulo");
                }
               else
                {
             return RedirectToAction ("Index","Home");
                }
            }
        public ActionResult ActivarUsuario()
            {
            return View();
            }

         public ActionResult AccionActivarUsuario(long IdUsuario)
            {
            if (Session["Admin"] != null) { 
            udao = new UsuarioDao();
            udao.ActivarUser(IdUsuario);
            return View("ActivarUsuario");
                }
             else
                {
                return RedirectToAction ("Index","Home");
                }
            }
        public ActionResult AccionEliminarUsuario(long IdUsuario)
            {
              if (Session["Admin"] != null) { 
            udao = new UsuarioDao();
            udao.Baja((int)IdUsuario);
            return View("ActivarUsuario");
                }
              else
                {
                 return RedirectToAction ("Index","Home");
                }
            }
        public ActionResult  RetornoPujadorAnterior(long IdCompra,long IdUsuario, long IdArticulo, DateTime Fecha)
            {
           if (Session["Admin"] != null) {   
            pjdao = new PujaDAO();
            cdao = new CompraDAO();

            //Borrar Pujas de ese Usuario
            pjdao.BajaPorUsuario(IdUsuario);
            //Conseguir idUsuario
            long NuevoUser = pjdao.ConsultaPujaIdUsuario(IdArticulo);
            decimal Precio = pjdao.ConsultaPrecio(IdArticulo);
            cdao.Modificacion(new Models.Compra(IdCompra,IdArticulo,Fecha,NuevoUser,Precio));
            return RedirectToAction("Compra");
                }
           else
                {
            return RedirectToAction("Index","Home");
                }
            }
        
        public ActionResult BusquedaCompraByFecha(int Anio, int mes,int AnioMax, int MesMax)
            {
             if (Session["Admin"] != null) {   
         cdao = new CompraDAO();
            DateTime fecha = new DateTime(Anio,mes,1);
            DateTime fechaMax = new DateTime (AnioMax,MesMax,DateTime.DaysInMonth(AnioMax,MesMax));
            StaticProduct.listadoCompraArticuloUsuario = cdao.ConsultaAllCompraArticuloUserByFecha(fecha,fechaMax);
            return View ("Compra");
                }
             else
                {
                return RedirectToAction("Index","Home");
                }
            }
        public ActionResult BusquedaCompraByNombre(String Nombre)
            {
            if (Session["Admin"] != null) {   
            cdao = new CompraDAO();
            StaticProduct.listadoCompraArticuloUsuario = cdao.ConsultaAllCompraArticuloUserByNombre("Nombre");
            return View("Compra");
                }
            else
                {
                 return RedirectToAction("Index","Home");
                }
                }
            }
    }
