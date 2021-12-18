public static class Extensions
{
    public static bool IsNull(this string entity)
    {
        if (string.IsNullOrWhiteSpace(entity))
            return true;
        return false;
    }

    public static bool IsNull(this object entity)
    {
        if (entity == null)
            return true;
        return false;
    }

    public static bool IsNull(this ICollection<object> collection)
    {
        if (collection == null)
            return true;
        return false;
    }

    public static bool HasAny(this ICollection<object> collection)
    {
        if (collection == null || !collection.Any())
            return false;
        return true;
    }
}
