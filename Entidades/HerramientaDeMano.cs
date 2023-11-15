using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class HerramientaDeMano : Herramientas
    {
        [Key]
        public string TipoHerramienta
        {
            get => default;
            set
            {
            }
        }
    }
}