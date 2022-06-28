using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using wsesearchmatogrosso.Models;

namespace wsesearchmatogrosso.Controllers
{
    public class HomeController : Controller
    {

        HttpClient c = new HttpClient();
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<PartialViewResult> SearchData(string pesquisa)
        {
            try
            {
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                var reqDuckDuckGo = new HttpRequestMessage(HttpMethod.Get, "http://api.duckduckgo.com/?q=" + pesquisa + "&format=json");

                var respDataProduct = c.SendAsync(reqDuckDuckGo).Result.Content.ReadAsStringAsync().Result;
                var lDataJson = JsonConvert.DeserializeObject<DuckDuckGoModel>(respDataProduct);

                return PartialView("_searchPartialModelResult", lDataJson);

            }
            catch (ArgumentException ex)
            {

                throw new Exception(ex.Message);
                
            }
        }

        [HttpPost]
        public async Task<PartialViewResult> SearchDataBrazil(string pesquisa)
        {
            try
            {
                ViewBag.Pesquisa = pesquisa;

                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                var reqSearch = new HttpRequestMessage(HttpMethod.Get, "https://pt.wikipedia.org/w/api.php?action=query&list=search&srsearch=" + pesquisa + "&utf8=&format=json");

                var respDataSearch = c.SendAsync(reqSearch).Result.Content.ReadAsStringAsync().Result;
                var lDataJson = JsonConvert.DeserializeObject<WikiModel>(respDataSearch);

                return PartialView("_searchPartialModelWikiResult", lDataJson); 
            }
            catch (ArgumentException ex)
            {
                throw new Exception(ex.Message);

            }
        }

       
    }
}