namespace PontoDeVenda.Common;

public abstract class Entity<T>(T id)
{
    public T Id { get; private set; } = id;

    protected bool Equals(Entity<T> other) => EqualityComparer<T>.Default.Equals(Id, other.Id);

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Entity<T>)obj);
    }

    public override int GetHashCode() => EqualityComparer<T>.Default.GetHashCode(Id);
}