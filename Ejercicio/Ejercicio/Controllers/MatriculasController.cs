using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;
using Ejercicio.Models;
using Ejercicio.Resources.Matriculas;

namespace Ejercicio.Controllers
{
    [Route("api/matriculas/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [AllowAnonymous]
    public class MatriculasController(EjercicioContext context) : ControllerBase
    {
        [Route("crear-matricula")]
        [HttpPost]
        public async Task<IActionResult> CrearMatricula([FromBody] CrearMatricula crearMatricula)
        {
            var matricula = await context.Set<Matricula>()
                .Where(m => m.CursoId == crearMatricula.CursoId &&
                m.EstudianteId == crearMatricula.EstudianteId)
                .FirstOrDefaultAsync();

            if (matricula is not null || crearMatricula.Fecha.Date > DateTime.Now.Date)
                return BadRequest();

            await context.Set<Matricula>().AddAsync
                (new(crearMatricula.CursoId, crearMatricula.EstudianteId, crearMatricula.Fecha, crearMatricula.Estado));

            await context.SaveChangesAsync();

            return Ok();
        }

        [Route("actualizar-matricula")]
        [HttpPost]
        public async Task<IActionResult> ActualizarMatricula([FromBody] ActualizarMatricula actualizarMatricula)
        {
            var matricula = await context.Set<Matricula>()
                .Where(m => m.Id == actualizarMatricula.Id && m.Estado != "FINALIZADA")
                .FirstOrDefaultAsync();

            if (matricula is null)
                return BadRequest();

            await context.Set<Matricula>().Where(m => m.Id == actualizarMatricula.Id)
                .ExecuteUpdateAsync(u => u.SetProperty(m => m.Estado, actualizarMatricula.Estado));

            return Ok();
        }

        [Route("eliminar-matricula")]
        [HttpGet]
        public async Task<IActionResult> EliminarMatricula([FromQuery] int matriculaId)
        {
            var matricula = await context.Set<Matricula>()
                .Where(m => m.Id == matriculaId && m.Estado == "CANCELADA")
                .FirstOrDefaultAsync();

            if (matricula is null)
                return BadRequest();

            context.Set<Matricula>().Remove(matricula);

            await context.SaveChangesAsync();

            return Ok();
        }

        [Route("buscar-por-matricula")]
        [HttpGet]
        public async Task<IActionResult> BuscarPorMatricula
            ([FromQuery] int matriculaId) => Ok(await context.Set<Matricula>()
                .Where(m => m.Id == matriculaId).FirstOrDefaultAsync());

        [Route("buscar-por-estudiante")]
        [HttpGet]
        public async Task<IActionResult> BuscarPorEstudiante
            ([FromQuery] int estudianteId) => Ok(await context.Set<Matricula>()
                .Where(m => m.EstudianteId == estudianteId).ToListAsync());

        [Route("buscar-por-curso")]
        [HttpGet]
        public async Task<IActionResult> BuscarPorCurso
            ([FromQuery] int cursoId) => Ok(await context.Set<Matricula>()
                .Where(m => m.CursoId == cursoId).ToListAsync());

        [Route("buscar-por-estado")]
        [HttpGet]
        public async Task<IActionResult> BuscarPorEstado
            ([FromQuery] string estado) => Ok(await context.Set<Matricula>()
                .Where(m => m.Estado == estado).ToListAsync());
    }
}