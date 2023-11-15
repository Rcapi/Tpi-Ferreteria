using System;
using System.Collections.Generic;
using Datos; 
using Entidades; 

namespace Negocio
{
    public class HerramientaElectrica
    {
        public static bool Agregar(Entidades.HerramientaElectrica herramientaElectrica)
        {
            DatosHerramientaElectrica datos = new DatosHerramientaElectrica();
            return datos.AgregarHerramientaElectrica(herramientaElectrica);
        }
        public static List<Entidades.HerramientaElectrica> TraerTodos()
        {
            DatosHerramientaElectrica datos = new DatosHerramientaElectrica();
            return datos.TraerTodos();
        }

        public static bool ModificarHerramienta(Entidades.HerramientaElectrica herramienta)
        {
            DatosHerramientaElectrica datos = new DatosHerramientaElectrica();
            return datos.ModificarHerramientaElectrica(herramienta);
        }

        public static bool EliminarHerramienta(string codigo)
        {
            DatosHerramientaElectrica datos = new DatosHerramientaElectrica();
            return datos.EliminarHerramienta(codigo);
        }

        public static Entidades.HerramientaElectrica TraerHerramientaPorCodigo(string codigo)
        {
            DatosHerramientaElectrica datos = new DatosHerramientaElectrica();
            return datos.TraerHerramientaPorCodigo(codigo);
        }
    }
}

