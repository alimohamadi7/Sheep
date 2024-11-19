namespace Sheep.Framework.Domain.Entities
{
    public interface IEntity
    {

    }
    public abstract class BaseEntity<TKey> : IEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public TKey Id { get; protected set; }
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
        }
    }

}
