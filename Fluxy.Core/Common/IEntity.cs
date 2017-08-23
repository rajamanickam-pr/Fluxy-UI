namespace Fluxy.Core.Common
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
