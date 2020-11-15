using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteFiap.Site.DAO;
using TesteFiap.Site.Models;

namespace TesteFiap.Site.Controllers
{
    public class AdmController:Controller
    {
        public ViewResult Index()
        {

            List<ClienteModel> clientes = new ClienteDAO().ListAll();

            return View(clientes);
        }

    }
}