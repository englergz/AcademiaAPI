using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AcademiaAPI.Models.db;
using AcademiaAPI.Models.db.MyModels;

namespace AcademiaAPI.Controllers
{
    public class EstudiantesController : ApiController
    {
        private AcademiaEntities db = new AcademiaEntities();

        // GET: api/Estudiantes
        public List<MiEstudiante> GetEstudiante()
        {
            List<MiEstudiante> misEstudiantes = new List<MiEstudiante>();

            foreach (var estudiante in db.Estudiante )
            {
                MiEstudiante miEstudiante = new MiEstudiante()
                {
                    id = estudiante.id,
                    nombre = estudiante.nombre,
                    fechanacimiento = estudiante.fechanacimiento.Value,
                    promedionotas = estudiante.promedionotas.Value,
                    eshombre = estudiante.eshombre.Value?"Hombre":"Mujer",
                    tipoSangre = estudiante.TipoSangre.nombre,
                    direccion = estudiante.direccion

                };
                misEstudiantes.Add(miEstudiante);
            }

            return misEstudiantes;
        }

        // GET: api/Estudiantes/5
        [ResponseType(typeof(MiEstudiante))]
        public IHttpActionResult GetEstudiante(int id)
        {
            Estudiante estudiante = db.Estudiante.Find(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            MiEstudiante miEstudiante = new MiEstudiante()
            {
                id = estudiante.id,
                nombre = estudiante.nombre,
                fechanacimiento = estudiante.fechanacimiento.Value,
                promedionotas = estudiante.promedionotas.Value,
                eshombre = estudiante.eshombre.Value ? "Hombre" : "Mujer",
                tipoSangre = estudiante.TipoSangre.nombre,
                direccion = estudiante.direccion

            };

            return Ok(miEstudiante);
        }

        // PUT: api/Estudiantes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstudiante(int id, Estudiante estudiante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estudiante.id)
            {
                return BadRequest();
            }

            db.Entry(estudiante).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Estudiantes
        [ResponseType(typeof(Estudiante))]
        public IHttpActionResult PostEstudiante(Estudiante estudiante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Estudiante.Add(estudiante);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = estudiante.id }, estudiante);
        }

        // DELETE: api/Estudiantes/5
        [ResponseType(typeof(Estudiante))]
        public IHttpActionResult DeleteEstudiante(int id)
        {
            Estudiante estudiante = db.Estudiante.Find(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            db.Estudiante.Remove(estudiante);
            db.SaveChanges();

            return Ok(estudiante);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstudianteExists(int id)
        {
            return db.Estudiante.Count(e => e.id == id) > 0;
        }
    }
}