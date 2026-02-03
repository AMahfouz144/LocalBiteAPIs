using System.ComponentModel.DataAnnotations;

namespace Domain.Common
{
    public interface IEntity 
    {
    }

    public interface IEntity<T> : IEntity
    {
        [Key]
        T Id { set; get; }
    }
}