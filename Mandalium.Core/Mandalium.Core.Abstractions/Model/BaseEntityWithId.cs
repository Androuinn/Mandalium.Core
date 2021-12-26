namespace Mandalium.Core.Model.Abstractions
{
    public abstract class BaseEntityWithId<T> where T : struct
    {
        public T Id { get; set; }
    }
}
