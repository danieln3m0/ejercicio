namespace Ejercicio.Models
{
    public class Matricula
    {
        public int Id { get; set; }
        public int CursoId { get; set; }
        public int EstudianteId { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; } = null!;

        public virtual Curso Curso { get; } = null!;
        public virtual Estudiante Estudiante { get; } = null!;

        public Matricula() { }
        public Matricula(int cursoId, int estudianteId, DateTime fecha,string estado)
        {
            this.CursoId = cursoId;
            this.EstudianteId = estudianteId;
            this.Fecha = fecha;
            this.Estado = estado;
        }
    }
}