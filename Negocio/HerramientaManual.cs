using System;
using System.Collections.Generic;
using Datos; 
using Entidades; 

namespace Negocio
{
    public  class HerramientaManual
    {
        public static bool Agregar(Entidades.HerramientaDeMano herramientaManual)
        {
            DatosHerramientaDeMano datos = new DatosHerramientaDeMano();
            return datos.AgregarHerramientaManual(herramientaManual);
        }
        public static List<HerramientaDeMano> TraerTodos()
        {
            DatosHerramientaDeMano datos = new DatosHerramientaDeMano();
            return datos.TraerTodosHerramientaDeMano();
        }

        public static bool ModificarHerramienta(HerramientaDeMano herramienta)
        {
            DatosHerramientaDeMano datos = new DatosHerramientaDeMano();
            return datos.ModificarHerramientaDeMano(herramienta);
        }

        public static bool EliminarHerramienta(string codigo)
        {
            DatosHerramientaDeMano datos = new DatosHerramientaDeMano();
            return datos.EliminarHerramientaDeMano(codigo);
        }

        public static HerramientaDeMano TraerHerramientaPorCodigo(string codigo)
        {
            DatosHerramientaDeMano datos = new DatosHerramientaDeMano();
            return datos.TraerHerramientaDeManoPorCodigo(codigo);
        }
    }
}

