using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademiaAPI.Models.db.MyModels
{
    public class MiEstudiante
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public Nullable<System.DateTime> fechanacimiento { get; set; }
        public Nullable<double> promedionotas { get; set; }
        public String eshombre { get; set; }
        public String tipoSangre { get; set; }
        public string direccion { get; set; }
        public string celular { get; set; }
    }
}