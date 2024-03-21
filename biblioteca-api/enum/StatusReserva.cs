using System.ComponentModel;

namespace biblioteca_api
{
    public enum StatusReserva
    {
        [Description("Diponivel")]
        Diponivel = 1,
        [Description("Reservado")]
        Reservado = 2,
    }
}
