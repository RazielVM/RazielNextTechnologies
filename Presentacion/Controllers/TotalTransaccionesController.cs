using Microsoft.AspNetCore.Mvc;

namespace Presentacion.Controllers
{
    public class TotalTransaccionesController : Controller
    {
        public IActionResult GetTransacciones()
        {
            Modelo.Transaccion transaccion = new Modelo.Transaccion();
            Dictionary<string, object> resultado = Negocio.Transaccion.GetTransacciones();
            bool result = (bool)resultado["Resultado"];

            if (result)
            {
                transaccion = (Modelo.Transaccion)resultado["Transaccion"];
                return View(transaccion);
            }
            else
            {
                string excepcion = (string)resultado["Excepcion"];
                return View();
            }
        }
    }
}
