namespace Ejercicio.Models
{
    public class Estudiante
    {
        public int Id { get; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Genero { get; set; } = null!;
        public int Edad { get; set; }
        public string Domicilio { get; set; } = null!;
        public string Correo { get; set; } = null!;

        public virtual ICollection<Matricula> Matriculas { get; } = [];
    }
}