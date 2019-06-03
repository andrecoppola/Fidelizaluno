namespace FCNuvem.FidelizaAluno.Core.Entities
{
    public abstract class EntityBase<TKey> : IEntityBase
    {
        public TKey Id { get; protected set; }

        protected EntityBase(TKey id)
        {
            Id = id;
        }
    }

    public abstract class EntityBase : EntityBase<int>
    {
        protected EntityBase(int id) : base(id) { }
    }

    public interface IEntityBase { }
}
