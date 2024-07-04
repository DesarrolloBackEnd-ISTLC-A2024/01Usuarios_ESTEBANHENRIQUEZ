using _01Usuarios_ESTEBANHENRIQUEZ.Modelos;
using System.Data;
using System.Data.SqlClient;

namespace _01Usuarios_ESTEBANHENRIQUEZ.Comunes
{
    public static class ConexionBD
    {
        public static SqlConnection conexion;

        public static SqlConnection abrirConexion()
        {
            conexion = new SqlConnection("Server=ACER\\MSSQLSERVER01;Database=ProyectoLogin;Trusted_Connection=True;");
            conexion.Open();
            return conexion;
        }

        public static List<Usuarios> GetUsuarios()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_GET_USUARIOS";
            //cmd.Parameters.AddWithValue("PI_ID_USIARIO")
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return fillUsuarios(ds);

        }

        public static Usuarios GetUsuarios(int id)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_GET_USUARIOS";
            cmd.Parameters.AddWithValue("PI_ID_USUARIOS",id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return fillUsuarios(ds)[0];
        }

        public static void PutUsuario(int usuarioModificacion, Usuarios objUsuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_UPD_USUARIO";
            cmd.Parameters.AddWithValue("PI_ID_USUARIO", objUsuario.id_usuario);
            cmd.Parameters.AddWithValue("PV_CODIGO", objUsuario.codigo);
            cmd.Parameters.AddWithValue("PV_NOMBRES", objUsuario.nombres);
            cmd.Parameters.AddWithValue("PV_APELLIDOS", objUsuario.apellidos);
            cmd.Parameters.AddWithValue("PV_MAIL", objUsuario.mail);
            cmd.Parameters.AddWithValue("PD_FECHA_NACIMIENTO", objUsuario.fecha_nacimiento);
            cmd.Parameters.AddWithValue("PV_CONTRASENA", objUsuario.contrasena);
            cmd.Parameters.AddWithValue("PI_USUARIO_MODIFICACION", usuarioModificacion);

            cmd.ExecuteNonQuery();
        }

        public static void DeleteUsuario(int idUsuario, int idUsuarioModificacion)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_DEL_USUARIO";
            cmd.Parameters.AddWithValue("PI_ID_USUARIO", idUsuario);
            cmd.Parameters.AddWithValue("PI_USUARIO_MODIFICACION", idUsuarioModificacion);

            cmd.ExecuteNonQuery();
        }
        internal static void PostUsuarios(Usuarios objUsuario)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_GET_USUARIOS";
            cmd.Parameters.AddWithValue("PV_CODIGO", objUsuario.codigo);
            cmd.Parameters.AddWithValue("PV_NOMBRES", objUsuario.nombres);
            cmd.Parameters.AddWithValue("PV_APELLIDOS", objUsuario.apellidos);
            cmd.Parameters.AddWithValue("@PV_MAIL", objUsuario.mail);
            cmd.Parameters.AddWithValue("@PD_FECHA_NACIMIENTO", objUsuario.fecha_nacimiento);
            cmd.Parameters.AddWithValue("@PV_CONTRASENA", objUsuario.contrasena);
            cmd.Parameters.AddWithValue("@PI_USUARIO_CREACION", objUsuario.usuario_creacion);

            cmd.ExecuteNonQuery();
        }

        private static List<Usuarios> fillUsuarios(DataSet ds)
        {
            List<Usuarios> lrespuesta = new List<Usuarios>();
            Usuarios objUsuario = new Usuarios();
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                objUsuario = new Usuarios();
                objUsuario.id_usuario = Convert.ToInt32(ds.Tables[0].Rows[i]["ID_USUARIO"].ToString());
                objUsuario.codigo = ds.Tables[0].Rows[i]["CODIGO"].ToString();
                objUsuario.nombres = ds.Tables[0].Rows[i]["NOMBRES"].ToString();
                objUsuario.apellidos = ds.Tables[0].Rows[i]["APELLIDOS"].ToString();
                objUsuario.mail = ds.Tables[0].Rows[i]["MAIL"].ToString();
                objUsuario.fecha_nacimiento = Convert.ToDateTime(ds.Tables[0].Rows[i]["FECHA_NACIMIENTO"].ToString());
                objUsuario.contrasena = ds.Tables[0].Rows[i]["CONTRASENA"].ToString();
                objUsuario.estado = ds.Tables[0].Rows[i]["ESTADO"].ToString();
                objUsuario.fecha_ultima_conexion = Convert.ToDateTime(ds.Tables[0].Rows[i]["FECHA_ULTIMA_CONEXION"].ToString());
                objUsuario.usuario_creacion = Convert.ToInt32(ds.Tables[0].Rows[i]["USUARIO_CREACION"].ToString());
                objUsuario.fecha_creacion = Convert.ToDateTime(ds.Tables[0].Rows[i]["FECHA_CREACION"].ToString());
                objUsuario.usuario_modificacion = Convert.ToInt32(ds.Tables[0].Rows[i]["USUARIO_MODIFICACION"].ToString());
                objUsuario.fecha_modificacion = Convert.ToDateTime(ds.Tables[0].Rows[i]["FECHA_MODIFICACION"].ToString());
                lrespuesta.Add(objUsuario);
            }
            return lrespuesta;
        }
    }
}
