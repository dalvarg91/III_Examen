using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace III_EXAMEN.Clase
{
    public class encuesta
    {
        public int numeroencuesta {  get; set; }
        public string nombre { get; set; }
        public int edad {  get; set; }
        public string correo { get; set; }
        public string partidopolitico { get; set; }

        public encuesta(string nombre, int edad, string correo, string partidopolitico)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.correo = correo;
            this.partidopolitico = partidopolitico;
        }

        public static int Agregar(string nombre, int edad, string correo, string partidopolitico)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = conectar.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("agregarparticipante", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@edad", edad));
                    cmd.Parameters.Add(new SqlParameter("@correo", correo));
                    cmd.Parameters.Add(new SqlParameter("@partidopolitico", partidopolitico));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }
    }
}