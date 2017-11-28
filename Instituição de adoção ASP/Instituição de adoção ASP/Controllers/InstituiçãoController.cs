using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Instituição_de_adoção_ASP.Models;
using Instituição_de_adoção_ASP.DAL;

namespace Instituição_de_adoção_ASP.Controllers
{
    public class InstituiçãoController : Controller
    {
        private Entities entities = new Entities();

        // GET: Instituição
        public ActionResult Index()
        {
            if (Session["LoginAdministrador"] == null)
            {
                return RedirectToAction("Login", "Instituição");
            }
            else
            {
                return View(InstituiçãoDAO.ListarInstituições());
            }
        }
        // GET: Instituição/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["LoginAdministrador"] == null)
            {
                return RedirectToAction("Login", "Instituição");
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Instituição instituição = entities.Instituições.Find(id);
                if (instituição == null)
                {
                    return HttpNotFound();
                }
                return View(instituição);
            }
        }

        // GET: Instituição/Create
        public ActionResult Create()
        {

                return View();

        }

        // POST: Instituição/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstituiçãoId,InstituiçãoLogin,InstituiçãoSenha,InstituiçãoNome,InstituiçãoTelefone, InstituiçãoEmail,InstituiçãoEndereco")] Instituição instituição)
        {
            if (ModelState.IsValid)
            {
                InstituiçãoDAO.CadastrarInstituição(instituição);
                return RedirectToAction("Index");
            }

            return View(instituição);
        }
        // GET: Instituição/Create
        public ActionResult Edit(int? id)
        {
            if (Session["LoginAdministrador"] == null)
            {
                return RedirectToAction("Login", "Instituição");
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Instituição instituição = InstituiçãoDAO.BuscarInstituiçãoPorId(id);
                if (instituição == null)
                {
                    return HttpNotFound();
                }
                return View(instituição);
            }
        }
        // POST: Instituição/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstituiçãoId,InstituiçãoLogin,InstituiçãoSenha,InstituiçãoNome,InstituiçãoTelefone,InstituiçãoEmail,InstituiçãoEndereco")] Instituição instituição)
        {
            if (Session["LoginAdministrador"] == null)
            {
                return RedirectToAction("Login", "Instituição");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    Instituição instituiçãoAux = InstituiçãoDAO.BuscarInstituiçãoPorId(instituição.InstituiçãoId);
                    instituiçãoAux.InstituiçãoLogin = instituição.InstituiçãoLogin;
                    instituiçãoAux.InstituiçãoSenha = instituição.InstituiçãoSenha;
                    instituiçãoAux.InstituiçãoNome = instituição.InstituiçãoNome;
                    instituiçãoAux.InstituiçãoTelefone = instituição.InstituiçãoTelefone;
                    instituiçãoAux.InstituiçãoEndereco = instituição.InstituiçãoEndereco;


                    InstituiçãoDAO.EditarInstituição(instituiçãoAux);
                    return RedirectToAction("Index");
                }
                return View(instituição);
            }
        }

        // GET: Instituição/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["LoginAdministrador"] == null)
            {
                return RedirectToAction("Login", "Instituição");
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Instituição instituição = entities.Instituições.Find(id);
                if (instituição == null)
                {
                    return HttpNotFound();
                }
                return View(instituição);
            }
        }


        // POST: Instituição/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int ?id)
        {
            if (Session["LoginAdministrador"] == null)
            {
                return RedirectToAction("Login", "Instituição");
            }
            else
            {
                Instituição instituição = entities.Instituições.Find(id);
                entities.Instituições.Remove(instituição);
                entities.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Login([Bind(Include = "InstituiçãoLogin,InstituiçãoSenha")]Instituição instituição, bool chkConectado)
        {
            if (InstituiçãoDAO.BuscarInstituiçãoPorLoginSenha(instituição) != null && instituição.InstituiçãoLogin != "admin" && instituição.InstituiçãoSenha != "administrador")
            {
                Session["LoginInstituição"] = instituição.InstituiçãoLogin;
                return RedirectToAction("Index", "Instituição");
            }
            else if (InstituiçãoDAO.BuscarInstituiçãoPorLoginSenha(instituição) != null && instituição.InstituiçãoLogin == "admin" && instituição.InstituiçãoSenha == "administrador")
            {
                Session["LoginAdministrador"] = instituição.InstituiçãoLogin;
                Session["LoginInstituição"] = instituição.InstituiçãoLogin;
                return RedirectToAction("Index", "Instituição");
            }
            else
            {
                ModelState.AddModelError("", "Login ou senha não coincidem!");
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["LoginAdministrador"] = null;
            Session["LoginInstituição"] = null;
            return RedirectToAction("Index", "Instituição");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                entities.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}