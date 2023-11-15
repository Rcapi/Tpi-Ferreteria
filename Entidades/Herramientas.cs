using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Herramientas : Producto
    {
        [Key]
        public string Modelo
        {
            get => default;
            set
            {
            }
        }
    }
}