namespace APIProjectBackend.Entities
{
    public class Task : BDEntity
    {
        public Guid IdProyecto { get; set; }
        public Project Proyecto { get; set; }
        public string Nombre { get; set; }
        public Guid IdUsuario { get; set; }
        public User Usuario { get; set; }
        public int Tiempo { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Descripcion { get; set; }
        public TaskStatus Estado { get; set; }
    }
}
