using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteFiap.Site.DAO;
using TesteFiap.Site.Models;

namespace TesteFiap.Site.Controllers
{
    public class ClienteController:Controller
    {
        [HttpPost]
        public ActionResult Cadastro(ClienteModel cliente)
        {
            
            ViewBag.ConfirmInserts = new ClienteDAO().Register(cliente);
            return View("~/Views/Home/Index.cshtml");
        }

       public ViewResult Delete(int id)
        {

            ViewBag.ConfirmDelete =  new ClienteDAO().Delete(id);
            List<ClienteModel> clientes = new ClienteDAO().ListAll();

            return View("~/Views/Adm/Index.cshtml", clientes);
        }


        public ActionResult Search(String search) {

            ViewBag.Busca = search;

            List<ClienteModel> clientes;
            if (search.Equals("")) clientes = new ClienteDAO().ListAll();
            else clientes = new ClienteDAO().ListBySearch(search);

            return View("~/Views/Adm/Index.cshtml", clientes);
        }
    }
}