namespace APIProjectBackend.EntititesDto
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public Guid IdProyecto { get; set; }
        public string Nombre { get; set; }
        public Guid IdUsuario { get; set; }
        public int Tiempo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Descripcion { get; set; }
        public TaskStatus Estado { get; set; }

    }
}
