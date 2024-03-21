namespace biblioteca_api.Models
{
    public class EmprestimoModel
    {
        public int Id { get; set; }
        public int DataEmprestimo { get; set; }
        public int DataDevolucao { get; set; }
        public StatusEmprestimo Status { get; set; }
        public int LivroId { get; set; }
        public int UsuarioId { get; set; }
        public virtual UsuarioModel? Usuario { get; set; }
        public virtual LivroModel? Livro { get; set; }

    }
}
