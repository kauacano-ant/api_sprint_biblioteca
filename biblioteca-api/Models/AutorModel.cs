namespace biblioteca_api.Models
{
    public class AutorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nacionalidade { get; set; }
        public DateOnly DataNascimento { get; set; }
    }
}
