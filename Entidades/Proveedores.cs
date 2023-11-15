using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Proveedores
    {
        public Producto Producto
        {
            get => default;
            set
            {
            }
        }

        [Key]
        public int ID
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

        public string Email
        {
            get => default;
            set
            {
            }
        }

        public string Telefono
        {
            get => default;
            set
            {
            }
        }

        public string Direccion
        {
            get => default;
            set
            {
            }
        }

        public string Ciudad
        {
            get => default;
            set
            {
            }
        }
    }
}