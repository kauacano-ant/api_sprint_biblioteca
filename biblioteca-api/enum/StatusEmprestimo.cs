using System.ComponentModel;

namespace biblioteca_api
{
    public enum StatusEmprestimo
    {
        [Description("Disponivel")]
        Disponivel = 1,
        [Description("Aguardando")]
        Aguaedando = 2,
        [Description("Emprestado")]
        Emprestado = 3

    }
}
