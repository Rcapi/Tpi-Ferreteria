using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ElementoDeSujecion
    {
        public static bool Agregar(Entidades.ElementoDeSujecion elementoSujecion)
        {
            Datos.DatosElementoDeSujecion datos = new Datos.DatosElementoDeSujecion();
            return datos.AgregarElementoDeSujecion(elementoSujecion);
        }
        public static List<Entidades.ElementoDeSujecion> TraerTodos()
        {
            Datos.DatosElementoDeSujecion datos = new Datos.DatosElementoDeSujecion();
            return datos.TraerTodosElementosDeSujecion();
        }

        public static bool ModificarElemento(Entidades.ElementoDeSujecion elemento)
        {
            Datos.DatosElementoDeSujecion datos = new Datos.DatosElementoDeSujecion();
            return datos.ModificarElementoDeSujecion(elemento);
        }

        public static bool EliminarElemento(string codigo)
        {
            Datos.DatosElementoDeSujecion datos = new Datos.DatosElementoDeSujecion();
            return datos.EliminarElementoDeSujecion(codigo);
        }

        public static Entidades.ElementoDeSujecion TraerElementoPorCodigo(string codigo)
        {
            Datos.DatosElementoDeSujecion datos = new Datos.DatosElementoDeSujecion();
            return datos.TraerElementoDeSujecionPorCodigo(codigo);
        }

    }
}
