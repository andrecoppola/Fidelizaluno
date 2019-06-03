using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Infrastructure.Repositories.Mappings;

namespace FCNuvem.FidelizaAluno.Infraestructure.Repositories.Mappings
{
    internal class AlertEntityMap : EntityMapConfiguration<AlertEntity>
    {
        protected override void OnMapping()
        {
            Builder.HasOneWithMany(l => l.Reason);
            Builder.HasOneWithMany(l => l.Template);
        }
    }
}
