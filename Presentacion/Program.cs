using PdfSharpCore.Fonts;


namespace Presentacion
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Configura el resolver de fuentes
            

            // Puedes agregar aqu� cualquier otra configuraci�n inicial que sea necesaria
            // ...

            // Resto del c�digo...

            // Inicializa la configuraci�n de la aplicaci�n (si es necesario)
            ApplicationConfiguration.Initialize();

            // Inicia el formulario principal de tu aplicaci�n (reemplaza "formIngreso" con el nombre correcto de tu formulario principal)
            Application.Run(new formIngreso());
        }
    }
}