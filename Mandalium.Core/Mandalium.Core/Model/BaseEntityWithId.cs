namespace Mandalium.Core.Model
{
    public abstract class BaseEntityWithId<T> where T : struct
    {
        public T Id { get; set; }
    }
}
