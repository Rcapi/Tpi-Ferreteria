using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Producto
    {
       
        [Key]
        public string Codigo
        {
            get => default;
            set
            {
            }
        }

        public string Nombre
        {
            get => default;
            set
            {
            }
        }

        public string Descripcion
        {
            get => default;
            set
            {
            }
        }

        public float Precio
        {
            get => default;
            set
            {
            }
        }

        public int Stock
        {
            get => default;
            set
            {
            }
        }

        public Ventas Ventas
        {
            get => default;
            set
            {
            }
        }
    }
}