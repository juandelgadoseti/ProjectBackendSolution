namespace APIProjectBackend.Entities
{
    public class User : BDEntity
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public ICollection<Task> Tasks { get; set; }

    }
}
