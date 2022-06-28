using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using wsesearchmatogrosso.Models.b3;

namespace wsesearchmatogrosso.Controllers
{
    public class B3Controller : Controller
    {
        HttpClient c = new HttpClient();
        public ActionResult Index()
        {
            try
            {
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                var reqCarteiraB3 = new HttpRequestMessage(HttpMethod.Get, "https://api-cotacao-b3.labdo.it/api/carteira");

                var respDataProduct = c.SendAsync(reqCarteiraB3).Result.Content.ReadAsStringAsync().Result;
                var lDataJson = JsonConvert.DeserializeObject<IEnumerable<CarteiraPregaoModel>>(respDataProduct);

                return View(lDataJson);
            }
            catch (ArgumentException ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public async Task<PartialViewResult> Empresas()
        {
            try
            {
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                var reqEmpresaB3 = new HttpRequestMessage(HttpMethod.Get, "https://api-cotacao-b3.labdo.it/api/empresa");

                var respDataProduct = c.SendAsync(reqEmpresaB3).Result.Content.ReadAsStringAsync().Result;
                var lDataJson = JsonConvert.DeserializeObject<IEnumerable<EmpresasPregaoModel>>(respDataProduct);

                return PartialView(lDataJson);
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<PartialViewResult> PizzaMaior()
        {
            try
            {
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                var reqEmpresaB3 = new HttpRequestMessage(HttpMethod.Get, "https://api-cotacao-b3.labdo.it/api/empresa");

                var respDataProduct = c.SendAsync(reqEmpresaB3).Result.Content.ReadAsStringAsync().Result;
                var lDataJson = JsonConvert.DeserializeObject<IEnumerable<EmpresasPregaoModel>>(respDataProduct);

                return PartialView("PizzaMaior", lDataJson);
            }
            catch (ArgumentException ex)
            {

                throw ex;

            }
        }

        [HttpPost]
        public async Task<ActionResult> SearchDataB3(string pesquisa, string tipo)
        {

            pesquisa.ToUpperInvariant();
            //switch (tipo)
            //{
            //    case "1":
            //        break;
            //    case "2":
            try
            {
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                //Lista Empresas
                var reqEmpresaB3List = new HttpRequestMessage(HttpMethod.Get, "https://api-cotacao-b3.labdo.it/api/empresa");

                var respDataProductList = c.SendAsync(reqEmpresaB3List).Result.Content.ReadAsStringAsync().Result;
                var lDataJsonList = JsonConvert.DeserializeObject<IEnumerable<EmpresasPregaoModel>>(respDataProductList);

                //Filtra Dados por Pesquisa
                var idEmpresaNm = lDataJsonList.Where(x => x.nm_empresa.Contains(pesquisa)).ToList();

                if (idEmpresaNm.Count() != 0)
                {

                    var reqEmpresaB3 = new HttpRequestMessage(HttpMethod.Get, "https://api-cotacao-b3.labdo.it/api/empresa/" + idEmpresaNm.FirstOrDefault().id);

                    var respDataProduct = c.SendAsync(reqEmpresaB3).Result.Content.ReadAsStringAsync().Result;
                    var lDataJson = JsonConvert.DeserializeObject<EmpresasPregaoModel>(respDataProduct);

                    return PartialView("EmpresaSingle_2", lDataJson);
                } else
                {
                    ViewBag.Pesquisa = pesquisa;
                    return PartialView("DefaultSearch");
                }

            }
            catch (ArgumentException ex)
            {

                throw;
            }
            //case "3":
            //    break;
            //default:
            //    break;
        }
    }


}
