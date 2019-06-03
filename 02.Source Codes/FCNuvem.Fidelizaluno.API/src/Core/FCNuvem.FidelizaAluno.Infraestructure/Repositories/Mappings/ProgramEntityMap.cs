using FCNuvem.FidelizaAluno.Core.Entities;


namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories.Mappings
{
    internal class ProgramEntityMap : EntityMapConfiguration<ProgramEntity>
    {
        protected override void OnMapping()
        {
            Builder.HasOne(l => l.Coordinator).WithMany("Program").HasForeignKey(q => q.IdCoordinator);
        }
    }
}
