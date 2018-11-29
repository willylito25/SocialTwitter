using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SocialTwitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialTwitter.Controllers
{
    [Authorize]
    public class SocialTwitterController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult CreateComentario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateComentario([Bind(Include = "ComentarioID, Comentario, ApplicationUserId")] Comentarios comentarios)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var id = User.Identity.GetUserId();
                    comentarios.ApplicationUserId = id;

                    db.Comentarios.Add(comentarios);
                    db.SaveChanges();

                    
                }
                catch (Exception)
                {
                    return new HttpStatusCodeResult(403);
                }

            }
            return View();
        }

        public ActionResult Comentarios()
        {
            return View(db.Comentarios.ToList());
        }

        public ActionResult SubComentarios(int idComentario)
        {
            var subcomentario = new SubComentario();
            subcomentario.ComentarioID = idComentario;
            return View(subcomentario);
        }

        [HttpPost]
        public ActionResult SubComentarios([Bind(Include = "subComentarioID, subcomentario, ComentarioID")] SubComentario subcomentarios)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.SubComentarios.Add(subcomentarios);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return new HttpStatusCodeResult(403);
                }

            }
            return RedirectToAction("Index");
        }

        public ActionResult ListaSubComentarios()
        {
            return View(db.SubComentarios.ToList());
        }
    }
}