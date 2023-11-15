using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    public class Base
    {
        private const string Cadena = "Data Source=LAPTOP-L95UJSKH\\SQLEXPRESS;Initial Catalog=Ferreteria;Integrated Security=True";

        public SqlConnection connection = new SqlConnection(Cadena);  

        public void AbriConexion() 
        { 
           if (connection.State != System.Data.ConnectionState.Open )
            {
                connection.Open();
            }
        }
        public void CerrarConexion() 
        { 
             if (connection.State != System.Data.ConnectionState.Closed) 
            { 
               connection.Close();  
            }        
        }
    }
}
