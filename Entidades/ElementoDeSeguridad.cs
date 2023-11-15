using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class ElementoDeSeguridad : Producto
    {
        [Key]
        public string Talle
        {
            get => default;
            set
            {
            }
        }

        public float Peso
        {
            get => default;
            set
            {
            }
        }

        public string TipoEquipo
        {
            get => default;
            set
            {
            }
        }

        public string Normativa
        {
            get => default;
            set
            {
            }
        }

        public ElementoDeSeguridad(string talle, float peso, string tipoEquipo, string normativa)
        {
            Talle = talle;
            Peso = peso;
            TipoEquipo = tipoEquipo;
            Normativa = normativa;
        }

        public ElementoDeSeguridad() { } 
    }
}