namespace ApprovalTests.Terminal;

internal static class EnumerableExtensions
{
    public static IEnumerable<(int Index, bool First, bool Last, T Item)> Enumerate<T>(this IEnumerable<T> source)
    {
        return Enumerate(source.NotNull().GetEnumerator());
    }

    public static IEnumerable<(int Index, bool First, bool Last, T Item)> Enumerate<T>(this IEnumerator<T> source)
    {
        source.NotNull();

        var first = true;
        var last = !source.MoveNext();
        T current;

        for (var index = 0; !last; index++)
        {
            current = source.Current;
            last = !source.MoveNext();
            yield return (index, first, last, current);
            first = false;
        }
    }
}
