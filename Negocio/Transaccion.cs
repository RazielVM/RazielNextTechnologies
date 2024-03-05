using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Transaccion
    {
        public static Dictionary<string, object> GetTransacciones()
        {
            Modelo.Transaccion transaccion = new Modelo.Transaccion();
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Transaccion", transaccion }, { "Resultado", false }, { "Excepcion", "" } };
            try
            {
                using (Data.RazielNextTechContext context = new Data.RazielNextTechContext())
                {
                    var registros = (from transac in context.MontoTotalTransaccionados
                                     select new
                                     {
                                         IdCompany = transac.IdCompany,
                                         CompanyName = transac.CompanyName,
                                         TransactionDate = transac.TransactionDate,
                                         TotalAmount = transac.TotalAmount
                                     }).ToList();

                    if (registros.Count > 0)
                    {
                        transaccion.Transacciones = new List<object>();

                        foreach (var registro in registros)
                        {
                            Modelo.Transaccion objtransaccion = new Modelo.Transaccion();

                            objtransaccion.Id_Company = registro.IdCompany;
                            objtransaccion.Company_Name = registro.CompanyName;
                            objtransaccion.Transaction_Date = registro.TransactionDate;
                            objtransaccion.Total_Amount = registro.TotalAmount.Value;

                            transaccion.Transacciones.Add(objtransaccion);
                        }

                        diccionario["Resultado"] = true;
                        diccionario["Transaccion"] = transaccion;
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
            return diccionario;
        }
    }
}
