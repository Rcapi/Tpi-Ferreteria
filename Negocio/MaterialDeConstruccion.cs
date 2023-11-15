using System;
using System.Collections.Generic;
using Datos;
using Entidades; 

namespace Negocio
{
    public class MaterialDeConstruccion
    {
        public static List<Entidades.MaterialDeConstruccion> TraerTodos()
        {
            DatosMaterialesDeConstruccion datos = new DatosMaterialesDeConstruccion();
            return datos.TraerTodosMaterialesDeConstruccion();
        }

        public static bool ModificarMaterial(Entidades.MaterialDeConstruccion material)
        {
            DatosMaterialesDeConstruccion datos = new DatosMaterialesDeConstruccion();
            return datos.ModificarMaterialesDeConstruccion(material);
        }

        public static bool EliminarMaterial(string codigo)
        {
            DatosMaterialesDeConstruccion datos = new DatosMaterialesDeConstruccion();
            return datos.EliminarMaterialesDeConstruccion(codigo);
        }

        public static Entidades.MaterialDeConstruccion TraerMaterialPorCodigo(string codigo)
        {
            DatosMaterialesDeConstruccion datos = new DatosMaterialesDeConstruccion();
            return datos.TraerMaterialesDeConstruccionPorCodigo(codigo);
        }
        public static bool Agregar(Entidades.MaterialDeConstruccion material) 
        {
            DatosMaterialesDeConstruccion datos = new DatosMaterialesDeConstruccion(); 
            return datos.AgregarMaterialesDeConstruccion(material);   
        }
    }
}
