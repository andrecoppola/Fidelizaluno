using FCNuvem.FidelizaAluno.Core.Entities;

namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories.Mappings
{
    internal class ClassRoomEntityMap : EntityMapConfiguration<ClassRoomEntity>
    {
        protected override void OnMapping()
        {
            Builder.HasOneWithMany(l => l.Program);
            Builder.HasOneWithMany(l => l.Period);
            Builder.HasOneWithOne(l => l.Employee);
            Builder.HasOneWithMany(l => l.Campus);
        }
    }
}
