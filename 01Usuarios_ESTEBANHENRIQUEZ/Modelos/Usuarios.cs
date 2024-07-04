﻿using System.Collections.Generic;

namespace _01Usuarios_ESTEBANHENRIQUEZ.Modelos
{
    public class Usuarios
    {
        public int id_usuario { get; set; }
        public string codigo { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string mail { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string contrasena { get; set; }
        public string estado { get; set; }
        public DateTime fecha_ultima_conexion { get; set; }
        public int usuario_creacion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public int usuario_modificacion { get; set; }
        public DateTime fecha_modificacion { get; set; }

    }


}
