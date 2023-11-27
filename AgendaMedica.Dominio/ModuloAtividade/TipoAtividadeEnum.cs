using System.ComponentModel;

namespace AgendaMedica.Dominio.ModuloAtividade
{
    public enum TipoAtividadeEnum
    {
        [Description("Consulta")]
        Consulta,

        [Description("Cirurgia")]
        Cirurgia
    }
}
