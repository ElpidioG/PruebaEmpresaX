using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaEmpresaX
{
    public class Direccion
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public int idCliente { get; set; }
    }
}
