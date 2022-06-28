using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wsesearchmatogrosso.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: Portfolio
        public ActionResult Index() => View();

        [HttpPost]
        public PartialViewResult Trabalhos() => PartialView();

        [HttpPost]
        public PartialViewResult Apis() => PartialView();

        [HttpPost]
        public PartialViewResult Projetos() => PartialView();

        [HttpPost]
        public ActionResult Curriculo() => View();
    }
}