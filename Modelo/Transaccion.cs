using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Transaccion
    {
        public string Id_Company { get; set; }
        public string Company_Name { get; set; }
        public DateTime Transaction_Date { get; set; }
        public decimal Total_Amount { get; set; }
        public List<object>? Transacciones { get; set; }
    }
}
