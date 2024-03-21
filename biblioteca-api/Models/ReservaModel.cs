namespace biblioteca_api.Models
{
    public class ReservaModel
    {
        public int Id { get; set; }
        public int DataReserva { get; set; }
        public StatusReserva Status { get; set; }
        public int LivroId { get; set; }
        public int UsuarioId { get; set; }
        public virtual UsuarioModel? Usuario { get; set; }
        public virtual LivroModel? Livro { get; set; }

    }
}
