using FCNuvem.FidelizaAluno.Core.Entities;

namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories.Mappings
{
    internal class ClassDiaryEntityMap : EntityMapConfiguration<ClassDiaryEntity>
    {
        protected override void OnMapping()
        {
            Builder.HasOneWithMany(l => l.Employee);
            Builder.HasOneWithMany(l => l.Student);
            Builder.HasOneWithMany(l => l.Class);
        }
    }
}
