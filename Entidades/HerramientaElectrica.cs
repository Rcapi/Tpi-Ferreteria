using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class HerramientaElectrica : Herramientas
    {
        [Key]
        public string Potencia
        {
            get => default;
            set
            {
            }
        }
    }
}