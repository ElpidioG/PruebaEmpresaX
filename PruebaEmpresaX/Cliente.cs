using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaEmpresaX
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public List<Direccion> Direcciones { get; set; }
    }
}
