using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class Usuario
    {
        public static void Actualizar(Entidades.Usuario usuario)
        {
            Datos.DatosUsuario datosUsuario = new Datos.DatosUsuario();
            datosUsuario.ActualizarUsuario(usuario);
        }
        public static List<Entidades.Usuario> BuscarPorNombre(string nombre) 
        {
            Datos.DatosUsuario usuario = new Datos.DatosUsuario();
            return usuario.BuscarUsuariosPorNombre(nombre);
        }
        public static List<Entidades.Usuario> RecuperarClientes()
        {
            Datos.DatosUsuario usuario = new Datos.DatosUsuario();
            return usuario.BuscarTodosClientes();
        }

        public static List<Entidades.Usuario> RecuperarEmpleados()
        {
            Datos.DatosUsuario usuario = new Datos.DatosUsuario();
            return usuario.BuscarTodosEmpleados();
        }

        public static Entidades.Usuario BuscarPorDni(string dni)
        {
            Datos.DatosUsuario usuario = new DatosUsuario();
            return usuario.BuscarUsuarioPorDni(dni);
        }
        public static void EliminarPorDni(string dni)
        {
            Datos.DatosUsuario usuario = new DatosUsuario();
            usuario.EliminarUsuarioPorDni(dni);
        }

        public static void AgregarUno(Entidades.Usuario usuario)

        {
            Datos.DatosUsuario datosusuario = new Datos.DatosUsuario();

            datosusuario.AgregarUsuario(usuario);
        }


    }
}
