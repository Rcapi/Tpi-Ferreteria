using PdfSharpCore.Fonts;


namespace Presentacion
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Configura el resolver de fuentes
            

            // Puedes agregar aquí cualquier otra configuración inicial que sea necesaria
            // ...

            // Resto del código...

            // Inicializa la configuración de la aplicación (si es necesario)
            ApplicationConfiguration.Initialize();

            // Inicia el formulario principal de tu aplicación (reemplaza "formIngreso" con el nombre correcto de tu formulario principal)
            Application.Run(new formIngreso());
        }
    }
}