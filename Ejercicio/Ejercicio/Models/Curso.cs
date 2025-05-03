namespace Ejercicio.Models
{
    public class Curso
    {
        public int Id { get; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Matricula> Matriculas { get; } = [];
    }
}