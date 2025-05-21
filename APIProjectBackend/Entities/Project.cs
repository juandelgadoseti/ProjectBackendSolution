namespace APIProjectBackend.Entities
{
    public class Project : BDEntity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public ICollection<Task> Tasks { get; set; }

    }
}
