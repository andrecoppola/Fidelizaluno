using System.ComponentModel;

namespace FCNuvem.FidelizaAluno.Core.Enums
{
    public enum EReason
    {
        [Description("Distancia")]
        Distancia = 1,

        [Description("Financeiro")]
        Financeiro = 2,

        [Description("Desempenho")]
        Desempenho = 3,

        [Description("Comportamento")]
        Comportamento = 4,

        [Description("Aptidão")]
        Aptidao = 5
    }
}
