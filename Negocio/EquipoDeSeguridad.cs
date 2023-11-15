using System;
using System.Collections.Generic;
using Datos; 

namespace Negocio
{
    public class ElementoDeSeguridad
    {
        public static bool Agregar(Entidades.ElementoDeSeguridad elemento)
        {
            DatosElementoDeSeguridad datos = new DatosElementoDeSeguridad();
            return datos.AgregarElementoDeSeguridad(elemento);
        }

        public static List<Entidades.ElementoDeSeguridad> TraerTodos()
        {
            DatosElementoDeSeguridad datos = new DatosElementoDeSeguridad();
            return datos.TraerTodos();
        }

        public static bool ModificarElemento(Entidades.ElementoDeSeguridad elemento)
        {
            DatosElementoDeSeguridad datos = new DatosElementoDeSeguridad();
            return datos.ModificarElemento(elemento);
        }

        public static bool EliminarElemento(string codigo)
        {
            DatosElementoDeSeguridad datos = new DatosElementoDeSeguridad();
            return datos.EliminarElemento(codigo);
        }

        public static Entidades.ElementoDeSeguridad TraerElemento(string codigo)
        {
            DatosElementoDeSeguridad datos = new DatosElementoDeSeguridad();
            return datos.TraerElementoPorCodigo(codigo);
        }
    }
}
