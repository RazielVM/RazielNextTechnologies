using Microsoft.AspNetCore.Mvc;
using Negocio;
using Newtonsoft.Json;

namespace Presentacion.Controllers
{
    public class NumeroFaltanteController : Controller
    {
        [HttpGet]
        public IActionResult CalcularNumero()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalcularNumero(int numero)
        {
            Dictionary<string, object> resultado;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5212/");
                var responseTask = client.GetAsync($"api/NumeroExtraido/Extract/{numero}");
                responseTask.Wait();
                var respuesta = responseTask.Result;
                var readTask = respuesta.Content.ReadAsAsync<Dictionary<string, object>>();
                readTask.Wait();
                resultado = readTask.Result;
            }

            return View(resultado);
        }
    }
}
